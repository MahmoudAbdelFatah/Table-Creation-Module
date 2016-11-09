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
    public partial class Home : Form
    {
        private ToolTip toolTip = new ToolTip();
        
        public Home()
        {
            InitializeComponent();

            Home.openExistTable_combo = new System.Windows.Forms.ComboBox();
            Home.openExistTable_combo.FormattingEnabled = true;
            Home.openExistTable_combo.Location = new System.Drawing.Point(this.CreateTable_txt.Location.X, this.CreateTable_txt.Location.Y+38);
            Home.openExistTable_combo.Name = "openExistTable_combo";
            Home.openExistTable_combo.Size = new System.Drawing.Size(121, 21);
            Home.openExistTable_combo.TabIndex = 3;
            this.Controls.Add(Home.openExistTable_combo);

            toolTip.SetToolTip(this.CreateTable_btn, "Create A New Table");
            toolTip.SetToolTip(this.OpenTable_btn, "Open the Selected Table");
            toolTip.SetToolTip(this.DelTable_btn, "Delete the Selected Table");

            this.ActiveControl = CreateTable_txt;
            Global.ConstraintTable.TableName = "ConstraintTable";
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Global.FilePath))
            {
                FileStream f = new FileStream(Global.FilePath, FileMode.Create);
                f.Close();
            }
            if (new FileInfo(Global.FilePath).Length != 0)
            {

                StreamReader xmlSW = new StreamReader(Global.FilePath);
                Global.dataSet.ReadXml(xmlSW,XmlReadMode.ReadSchema);
                xmlSW.Close();

            }

            foreach (DataTable table in Global.dataSet.Tables)
            {
                if (table.TableName != "ConstraintTable")
                    Home.openExistTable_combo.Items.Add(table.TableName);
            }

            Global.ConstraintTable = Global.dataSet.Tables[Global.ConstraintTable.TableName];
            //Global.dataSet.Tables.Remove(Global.ConstraintTable.TableName);  
        }

        private void CreateTable_btn_Click(object sender, EventArgs e)
        {
            if (CreateTable_txt.Text == "" )
                return;
            if (Global.dataSet.Tables.Contains(CreateTable_txt.Text))
            {
                MessageBox.Show("A Table of the Same Name is Alrady Exist ! ", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Global.Curtable = CreateTable_txt.Text;
            Global.from_Home = true;

            Design d = new Design();
            d.Show();
        }

        private void CreateTable_txt_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
                 CreateTable_btn_Click(sender, e);
        }

        private void OpenTable_btn_Click(object sender, EventArgs e)
        {
            if ((string)openExistTable_combo.SelectedItem == "")
                return;
            Global.Curtable = openExistTable_combo.SelectedItem.ToString();

            Edit E = new Edit();
            E.Show();
        }

        private void DelTable_btn_Click(object sender, EventArgs e)
        {
            if (Home.openExistTable_combo.Text != "")
            {
                if (Home.openExistTable_combo.SelectedItem.ToString() != "")
                {
                    DialogResult res = MessageBox.Show("Do You want to delete " + Home.openExistTable_combo.SelectedItem.ToString() + " ? ",
                                                        "Warning ",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                                                         );

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Global.dataSet.Tables[Home.openExistTable_combo.SelectedItem.ToString()].Constraints.Count > 0)
                            Global.dataSet.Tables[Home.openExistTable_combo.SelectedItem.ToString()].Constraints.Clear();

                        // delete the constraints for constraintstable 
                        for (int count = 0; count < Global.ConstraintTable.Rows.Count; count++)
                        {
                            if (Global.ConstraintTable.Rows[count]["TableName"].ToString() == Home.openExistTable_combo.SelectedItem.ToString())
                                Global.ConstraintTable.Rows[count].Delete();
                        }
                        Global.dataSet.Tables.Remove(Home.openExistTable_combo.SelectedItem.ToString());
                        Home.openExistTable_combo.Items.Remove(Home.openExistTable_combo.SelectedItem);

                        
                       

                    }
                }
            }
           
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(Global.FilePath);

            Global.dataSet.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
            xmlSW.Close();
        }

    
    }
}
