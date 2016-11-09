using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
namespace Table
{
    public partial class Edit : Form
    {
        private ToolTip toolTip = new ToolTip();

        public Edit()
        {
            InitializeComponent();
            Design.dataSetTable = Global.dataSet.Tables[Global.Curtable];
            ColumnProperties p = new ColumnProperties();

            for (int i = 0; i < Design.dataSetTable.Columns.Count; i++)
            {
                //fills the CheckCons of the list from the ConstraintTable
                string TableColName = "'" + Global.Curtable + Design.dataSetTable.Columns[i].ColumnName + "'";
                DataRow[] CheckConstraint = Global.ConstraintTable.Select("TableColName = " + TableColName);
                if (CheckConstraint.Count() > 0)
                {
                    p.CheckCons = new List<string>(CheckConstraint[0][2].ToString().Split(','));
                }
                p.Allow_null = Design.dataSetTable.Columns[i].AllowDBNull;
                Design.Properties.Add(p);
                p = new ColumnProperties();
            }
        }
        private void Edit_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = Global.dataSet.Tables[Global.Curtable];
           // dataGridView1.DataSource =Design.dataSetTable;
            Table_Name.Text = Global.Curtable;
            toolTip.SetToolTip(this.save_btn , "Save");
            toolTip.SetToolTip(this.Delete_Row_btn, "Delete Row");
            toolTip.SetToolTip(this.EditTable_btn, "Edit Table");


        }

        private void Delete_Row_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    dataGridView1.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (Global.dataSet.Tables[Global.Curtable].Rows.Count >=1)
            {
                System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(Global.FilePath);
                Global.dataSet.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
                xmlSW.Close();


                if (!Home.openExistTable_combo.Items.Contains(Global.Curtable))
                    Home.openExistTable_combo.Items.Add(Global.Curtable);
            }
            else
            {
                DialogResult res = MessageBox.Show("the table has no Rows , Do You want to delete it ? ", "Warning ", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
  
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    //delete from DS & close the form
                    Global.dataSet.Tables.Remove(Global.dataSet.Tables[Global.Curtable]);

                    System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(Global.FilePath);
                    Global.dataSet.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
                    xmlSW.Close();

                    Home.openExistTable_combo.Items.Remove(Global.Curtable);

                    this.Close();
                }
                else
                {
                    //nothing - return
                    return;
                }
            }
            
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.dataSet.Tables.Contains(Global.Curtable))
            {
                    if (Global.dataSet.Tables[Global.Curtable].Rows.Count >= 1)
                    {
                        System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(Global.FilePath);
                        Global.dataSet.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
                        xmlSW.Close();

                        if (!Home.openExistTable_combo.Items.Contains(Global.Curtable))
                            Home.openExistTable_combo.Items.Add(Global.Curtable);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("the table has no Rows , Do You want to delete it ? ", "Warning ",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (res == System.Windows.Forms.DialogResult.Yes)
                        {
                            //delete from DS & close the form
                            Global.dataSet.Tables.Remove(Global.dataSet.Tables[Global.Curtable]);
                            Home.openExistTable_combo.Items.Remove(Global.Curtable);


                            System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(Global.FilePath);
                            Global.dataSet.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
                            xmlSW.Close();
                        }
                        else
                        {
                            //nothing - return
                            e.Cancel = true;
                        }
                    }
            }
        }
        private void EditTable_btn_Click(object sender, EventArgs e)
        {
            Global.from_Home = false;
            Design d = new Design();
            d.Show();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger;
            string header = dataGridView1.Columns[dataGridView1.CurrentCellAddress.X].HeaderText;
      
            for (int i = 0; i < Design.Properties[dataGridView1.CurrentCellAddress.X].CheckCons.Count; i++)
            {
                if (Design.Properties[dataGridView1.CurrentCellAddress.X].CheckCons[i] != "")
                {
                    string str = Design.Properties[dataGridView1.CurrentCellAddress.X].CheckCons[i].Remove(0, header.Count() + 1);
                    // check the value that written in cell
                    if (e.FormattedValue.ToString() != "")
                    {
                        if (str[0] == '>')
                        {
                            if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < int.Parse(str.Substring(2, str.Count() - 2)))
                            {
                                dataGridView1.Rows[e.RowIndex].ErrorText = "no it's smaller than the cons";
                                e.Cancel = true;
                            }
                        }
                        else if (str[0] == '<')
                        {
                            if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger > int.Parse(str.Substring(2, str.Count() - 2)))
                            {
                                dataGridView1.Rows[e.RowIndex].ErrorText = "no it's greater than the cons";
                                e.Cancel = true;                                
                            }
                        }
                        else if (str[0] == '!')
                        {
                            if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger == int.Parse(str.Substring(3, str.Count() - 3)))
                            {
                                dataGridView1.Rows[e.RowIndex].ErrorText = "no it's equal";
                                e.Cancel = true;
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // to remove  ErrorText 
            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
        }

     }
 }

