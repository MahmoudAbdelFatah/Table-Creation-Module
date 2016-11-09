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
using System.Globalization;

namespace Table
{
    public partial class Design : Form
    {
        private ToolTip toolTip = new ToolTip();
        public static DataTable designTable = new DataTable();
        public static DataTable dataSetTable = new DataTable();
        public static List<ColumnProperties> Properties= new List<ColumnProperties>(); 
        private bool constructing = false;
        private bool RowAddProblemAfterInitiation = false;

        public Design()
        {
            designTable = new DataTable();
            dataSetTable = new DataTable();

            Properties = new List<ColumnProperties>();
            
            InitializeComponent();
            label5.Text = Global.Curtable;
            dataSetTable.TableName = Global.Curtable;
           
            if (Global.from_Home == true)
            { //creating new table
                DesignDataGrid();
                RowAddProblemAfterInitiation = true;
            }
            else
            {
                //the form is opend from the Edit form
                constructing = true;

                DesignDataGrid();
                dataSetTable = Global.dataSet.Tables[Global.Curtable];
                initiate();

                constructing = false;
            }
            toolTip.SetToolTip(this.save_btn, "Save");
            toolTip.SetToolTip(this.DeleteCol_btn, "Delete Column");
            toolTip.SetToolTip(this.FK_constraint, "Add Forign Key");
        }

        /********* Link the comboBox with the table Column 4 *************/
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (constructing)
                return;
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (constructing)
                return;
            ComboBox cb = (ComboBox)sender;
            string item = cb.Text;
            //MessageBox.Show(item);
            if (item != null && ! dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[4].Value.ToString().Equals(item))
            {
                //MessageBox.Show(item);
                cb.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[4].Value = item;
                cb.SelectedIndex = cb.FindStringExact(item);
                cb.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }

        /**************************  Events   ***********************************/
 
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           ////add an empty Properties obj to the list

            if (constructing)
                return;

            if (dataGridView1.Rows.Count > 1 && dataGridView1.CurrentCellAddress.Y >= 0)
                {   //NOTE :- the Rows.Count = 1 at the begin of the form
                    if (dataGridView1.CurrentCellAddress.Y <= Properties.Count)
                    {
                        if ( RowAddProblemAfterInitiation )
                        {
                            Properties.Add(new ColumnProperties());
                            dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].Value = false;
                            dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[3].Value = false;
                            this.unique_check.Checked = false;
                            this.inc_dec_checkedList.SetItemChecked(0, false);
                            this.inc_dec_checkedList.SetItemChecked(1, false);

                            if (Global.from_Home == false)
                            {
                                dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].Value = true;
                                dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].ReadOnly = true;
                                dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[3].ReadOnly = true;
                            }
                        }
                        RowAddProblemAfterInitiation = true;

                    }
                }
            
            
        }
        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (constructing)
                return;

            if (!dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].IsNewRow )
                Properties[dataGridView1.CurrentCellAddress.Y] = getProperties(dataGridView1.CurrentCellAddress.Y);
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //Only called when a dataGridView Exeption "row deleted by system"
            if (constructing)
                return;
            //dataGridView1.CurrentCellAddress.Y = -1 when the row is deleted by the user

            if (dataGridView1.Rows.Count > 1 && dataGridView1.CurrentCellAddress.Y != -1 )
            {
                if (dataSetTable.Columns.Contains(Properties[dataGridView1.CurrentCellAddress.Y + 1].Column_Name))
                    dataSetTable.Columns.Remove(Properties[dataGridView1.CurrentCellAddress.Y + 1].Column_Name);

                Properties.RemoveAt(dataGridView1.CurrentCellAddress.Y + 1);
            }
            //delete the Y+1
        }
        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {//called when a row is deleted by Delete button
            //remove the row data from the list
            if (constructing)
                return;

            if (dataGridView1.CurrentCellAddress.Y == dataGridView1.Rows.Count - 2)
            {
                if (dataSetTable.Columns.Contains(Properties[dataGridView1.CurrentCellAddress.Y + 1].Column_Name))
                    dataSetTable.Columns.Remove(Properties[dataGridView1.CurrentCellAddress.Y + 1].Column_Name);

                Properties.RemoveAt(dataGridView1.CurrentCellAddress.Y + 1); //the last row
            }
            else
            {
                if (dataSetTable.Columns.Contains(Properties[dataGridView1.CurrentCellAddress.Y ].Column_Name))
                    dataSetTable.Columns.Remove(Properties[dataGridView1.CurrentCellAddress.Y ].Column_Name);

                Properties.RemoveAt(dataGridView1.CurrentCellAddress.Y);
            }
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validate the AllowNUll & PK CheckBoxS
            if(constructing)
                return ;

                Validate_PK_Allow();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (constructing)
                return;

            set_Footer(dataGridView1.CurrentCellAddress.Y);
        }
        private void inc_dec_checkedList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //force to only check either increment OR decrement
            if (constructing)
                return;

            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < this.inc_dec_checkedList.Items.Count; ++ix)
                    if (e.Index != ix) inc_dec_checkedList.SetItemChecked(ix, false);

                this.DefVal_txt.Text = "";
                this.DefVal_txt.ReadOnly = true;
            }
            else
            {
                this.DefVal_txt.ReadOnly = false;
            }
                

        }
        private void inc_dec_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (constructing)
                return;
            //force the text box in footer to only accept Int
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void unique_check_CheckedChanged(object sender, EventArgs e)
        {
            if (constructing)
                return;

            //when Unique NO Default Value
            if (unique_check.Checked == true)
            {
                DefVal_txt.Text = "";
                DefVal_txt.Enabled = false;
            }
            else
            {
                DefVal_txt.Enabled = true;
            }
        }
        private void panel1_Leave(object sender, EventArgs e)
        {
            if (constructing)
                return;
            //MessageBox.Show("plane leave ! so go save to list ");
            if (!dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].IsNewRow)
                Properties[dataGridView1.CurrentCellAddress.Y] = getProperties(dataGridView1.CurrentCellAddress.Y);
            Activate_Footer(true);
            // panel1.Enabled = true;
        }
        private void len_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (constructing)
                return;
            //force the text box to only accept Int
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void seed_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (constructing)
                return;
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void DefVal_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (constructing)
                return;
            // to handle Exception Datatype
            string str = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();

            // intger 
            if (str == "Int16" || str == "Int32" || str == "Int64")
                if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '+')))
                {
                    e.Handled = true;
                }
                //Byte
                else if (str == "Byte")
                    if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar) && (e.KeyChar != '+')))
                    {
                        e.Handled = true;
                    }
                    // Decimal && double 
                    else if (str == "Decimal" || str == "Double")
                        if (!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '+') && (e.KeyChar != '.')))
                        {
                            e.Handled = true;
                        }
        }
        private void DefVal_txt_Leave(object sender, EventArgs e)
        {
            if (constructing)
                return;
            string str = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();


            if (DefVal_txt.Text!= "")
            {
                            if (str == "Int16"  )
                                {
                                    Int16 parsedValue;
                                    if (!Int16.TryParse(DefVal_txt.Text, out parsedValue))
                                    {
                                        if(this.DefVal_txt.Enabled==true)
                                            MessageBox.Show("Invalid Int16 !");
                                        DefVal_txt.Text = "";
                                    }
                                }
                                else if (  str == "Int32"  )
                                {
                                    Int32 parsedValue;
                                    if (!Int32.TryParse(DefVal_txt.Text, out parsedValue))
                                    {
                                        if (this.DefVal_txt.Enabled == true)
                                        MessageBox.Show("Invalid Int32 !");
                                        DefVal_txt.Text = "";
                                    }
                                } 
                                else if (  str == "Int64")
                                {
                                    Int64 parsedValue;
                                    if (!Int64.TryParse(DefVal_txt.Text, out parsedValue))
                                    {
                                        if (this.DefVal_txt.Enabled == true)
                                        MessageBox.Show("Invalid Int64 !");
                                        DefVal_txt.Text = "";
                                    }
                                }
                                else if (str == "Byte")
                                {
                                    byte parsedValue;
                                    if (!byte.TryParse(DefVal_txt.Text, out parsedValue) )
                                    {
                                        if (this.DefVal_txt.Enabled == true)
                                        MessageBox.Show("Invalid Byte !");
                                        DefVal_txt.Text = "";
                                    }
                                }
                                else if (str == "Double")
                                {
                                    double parsedValue;
                                    if (!double.TryParse(DefVal_txt.Text, out parsedValue))
                                    {
                                        if (this.DefVal_txt.Enabled == true)
                                        MessageBox.Show("Invalid Double !");
                                        DefVal_txt.Text = "";
                                    }
                                }
                                else if (str == "Decimal")
                                {
                                    decimal parsedValue;
                                    if (!decimal.TryParse(DefVal_txt.Text, out parsedValue))
                                    {
                                        if (this.DefVal_txt.Enabled == true)
                                        MessageBox.Show("Invalid decimal !");
                                        DefVal_txt.Text = "";
                                    }
                                }
                                else if (str == "DateTime")
                                {
                                    if (!IsDateTime(DefVal_txt.Text))
                                    {
                                        if (this.DefVal_txt.Enabled == true)
                                        MessageBox.Show("Invalid DateTime !");
                                        DefVal_txt.Text = "";
                                    }
                                }
                                else if (str == "Char" && DefVal_txt.Text.Length > 1)
                                {
                                    if (this.DefVal_txt.Enabled == true)
                                    MessageBox.Show("Invalid Char!");
                                    DefVal_txt.Text = "";
                                }

            }//end if


        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (constructing)
                return;

            for (int i = 0; i < designTable.Rows.Count; i++)
            {
                Properties[i].Allow_null = (bool)designTable.Rows[i][1];
                Properties[i].IS_primKey = (bool)designTable.Rows[i][2];
                Properties[i].Column_Name = designTable.Rows[i][0].ToString();
                Properties[i].Data_Type = designTable.Rows[i][3].ToString();
            }
            for (int i = 0; i < Properties.Count; i++)
            {
                // Column_Name
                if (!dataSetTable.Columns.Contains(Properties[i].Column_Name))
                { 
                    //MessageBox.Show(Properties[i].Column_Name);
                    dataSetTable.Columns.Add(Properties[i].Column_Name, System.Type.GetType("System." + Properties[i].Data_Type));
                    //DataType
                    //dataSetTable.Columns[Properties[i].Column_Name].DataType = System.Type.GetType("System." + Properties[i].Data_Type);
                }

                //default_Value
                if (Properties[i].default_Value != "" && Properties[i].default_Value != " ")
                    dataSetTable.Columns[Properties[i].Column_Name].DefaultValue = Properties[i].default_Value;

                // unique && Allow_Null && primaryKey 
                if (Properties[i].Data_Type != "Boolean")
                {
                    // check if the column is suitable to allow Null
                    try
                    {
                        dataSetTable.Columns[Properties[i].Column_Name].AllowDBNull = Properties[i].Allow_null;
                    }
                    catch
                    {
                        MessageBox.Show("Edit the column first!");
                    }
                    dataSetTable.Columns[Properties[i].Column_Name].Unique = Properties[i].Isunique;
                    if (Properties[i].IS_primKey)
                            dataSetTable.PrimaryKey = new DataColumn[] { dataSetTable.Columns[i] };
                        
                }
                //  inCrement && deCrement 
                if (Properties[i].Data_Type == "Int16" || Properties[i].Data_Type == "Int32" || Properties[i].Data_Type == "Int64" || Properties[i].Data_Type == "Byte")
                {
                    if (Properties[i].inCrement)
                    {
                        dataSetTable.Columns[Properties[i].Column_Name].AutoIncrement = true;
                        dataSetTable.Columns[Properties[i].Column_Name].AutoIncrementStep = Properties[i].step;
                        dataSetTable.Columns[Properties[i].Column_Name].AutoIncrementSeed = Properties[i].seed;
                    }
                    else if (Properties[i].deCrement && Properties[i].Data_Type != "Byte")
                    {
                        dataSetTable.Columns[Properties[i].Column_Name].AutoIncrement = true;
                        dataSetTable.Columns[Properties[i].Column_Name].AutoIncrementStep = -1 * Properties[i].step;
                        dataSetTable.Columns[Properties[i].Column_Name].AutoIncrementSeed = Properties[i].seed;
                    }
                }

                // length
                if (Properties[i].Data_Type == "String")
                    dataSetTable.Columns[Properties[i].Column_Name].MaxLength = Properties[i].Length;


                //check constraint
                for (int count = 0; count < Global.ConstraintTable.Rows.Count; count++)
                {
                    if (Global.ConstraintTable.Rows[count]["TableColName"].ToString() == Global.Curtable + Properties[i].Column_Name)
                    Global.ConstraintTable.Rows[count].Delete();
                }
                //MessageBox.Show(Properties[i].CheckCons.Count().ToString());
                if (Properties[i].CheckCons.Count() > 0)
                {
                        Global.ConstraintTable.Rows.Add(Global.Curtable,
                                                    Properties[i].Column_Name,
                                                    Properties[i].CheckCons.Aggregate((k, j) => k + ',' + j),
                                                    Global.Curtable + Properties[i].Column_Name
                                                    );
                }
                


            }//end for


            if (Global.dataSet.Tables.Contains(dataSetTable.TableName))
            {//the table is exist in the DataSet
                //Came from Edit
                Global.dataSet.Tables[dataSetTable.TableName].Merge(dataSetTable);
            }
            else
            {
                //Came from Home - CreateNew Table
                Global.dataSet.Tables.Add(dataSetTable);
            }
           

            Edit ee = new Edit();
            ee.Show();
            this.Close();
        }
        private void panel1_Enter(object sender, EventArgs e)
        {
            if (constructing)
                return;
            ActivateDataType_Panal();
        }
        private void Design_Load(object sender, EventArgs e)
        {
            //update the sellection of the DataGridViewComboBox
            fill_DataGridViewComBoxCells();
        }

        /**********************   Functions     **********************************/

        private void DesignDataGrid()
        {
            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            cmbCol.HeaderText = "Data_Type";
            cmbCol.Name = "Data_Type";

            cmbCol.Items.Add("Boolean");
            cmbCol.Items.Add("Byte");
            cmbCol.Items.Add("Char");
            cmbCol.Items.Add("DateTime");
            cmbCol.Items.Add("Decimal");
            cmbCol.Items.Add("Double");
            cmbCol.Items.Add("Int16");
            cmbCol.Items.Add("Int32");
            cmbCol.Items.Add("Int64");
            cmbCol.Items.Add("String");

            dataGridView1.DataSource = designTable;

            designTable.Columns.Add("Column Name");
            dataGridView1.Columns.Add(cmbCol);
            dataGridView1.Columns[cmbCol.Name].DisplayIndex = 1;
            designTable.Columns.Add("Allow Null", typeof(bool));
            designTable.Columns.Add("Primary Key", typeof(bool));
            designTable.Columns.Add("DataType_Table");

            designTable.PrimaryKey = new DataColumn[] { designTable.Columns["Column Name"] };
            designTable.Columns["DataType_Table"].AllowDBNull = false;

            dataGridView1.Columns["DataType_Table"].Visible = false;

            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
        private void Activate_Footer(bool activ)
        {
            inc_dec_checkedList.Enabled = activ;
            inc_dec_txt.ReadOnly = !activ;
            len_txt.ReadOnly = !activ;
            unique_check.Enabled = activ;
            DefVal_txt.ReadOnly = !activ;
            Exp_txt.ReadOnly = !activ;
            seed_txt.ReadOnly = !activ;
        }
        private void Clean_Footer()
        {
            this.DefVal_txt.Text = "cleaned footer";
            this.unique_check.Checked = false;
            this.inc_dec_txt.Text = "";
            this.Exp_txt.Text = "";
            this.len_txt.Text = "";
            for (int ix = 0; ix < this.inc_dec_checkedList.Items.Count; ++ix)
                inc_dec_checkedList.SetItemChecked(ix, false);
        }
        private void set_Footer(int index)
        {
            if (index < Properties.Count && index >= 0)
            {
                ColumnProperties p = Properties[index];


                this.DefVal_txt.Text = p.default_Value;

                this.unique_check.Checked = p.Isunique;
                this.inc_dec_checkedList.SetItemChecked(0, p.inCrement);
                this.inc_dec_checkedList.SetItemChecked(1, p.deCrement);
                this.inc_dec_txt.Text = p.step.ToString();

                this.Exp_txt.Text = "";
                for (int i = 0; i < p.CheckCons.Count; i++)
                {
                    this.Exp_txt.Text += p.CheckCons[i];
                    if(i<p.CheckCons.Count-1)
                        this.Exp_txt.Text += Environment.NewLine;
                }

                this.len_txt.Text = p.Length.ToString();
                this.seed_txt.Text = p.seed.ToString();
            }
            //else if (index!=0)
            //{
            //    MessageBox.Show("index out of range ! ");
            //}
        }
        private void set_Footer(ColumnProperties p)
        {

                this.DefVal_txt.Text = p.default_Value;

                this.unique_check.Checked = p.Isunique;
                this.inc_dec_checkedList.SetItemChecked(0, p.inCrement);
                this.inc_dec_checkedList.SetItemChecked(1, p.deCrement);
                this.inc_dec_txt.Text = p.step.ToString();

                this.Exp_txt.Text = "";
                for (int i = 0; i < p.CheckCons.Count; i++)
                {
                    this.Exp_txt.Text += p.CheckCons[i];
                    if (i < p.CheckCons.Count - 1)
                        this.Exp_txt.Text += Environment.NewLine;
                }

                this.len_txt.Text = p.Length.ToString();
                this.seed_txt.Text = p.seed.ToString();
        }
        private void Validate_PK_Allow()
        {

            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {//allow NULL
 
                    if (dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[3].Value.Equals(true))
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[3].ReadOnly == false)
                                row.Cells[2].ReadOnly = false;
                        }
                        dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].ReadOnly = true;
                        MessageBox.Show("This is primary key! \n Can Not Allow NULL");
                    }
                    else if (dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[3].Value.Equals(false) 
                            && dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[3].ReadOnly == false)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].ReadOnly = false;
                    }

            }

            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                if (dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].ReadOnly == true
                    && dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].Value.Equals(true))
                    return;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[3].Value = false;
                    }
 
                        dataGridView1.CurrentCell.Value = true;
                        dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[2].Value = false;
                
            }

        }
        private ColumnProperties getProperties(int rowIndex)
        {//gets the properties from the form fields
            
            if (rowIndex >= 0 && !dataGridView1.Rows[rowIndex].IsNewRow)
            {
                /*  assum that this values is from the form   */
                ColumnProperties p = new ColumnProperties();

                p.index = dataGridView1.CurrentCellAddress.Y;

                if (Convert.ToBoolean(dataGridView1.Rows[rowIndex].Cells[2].Value) == true)
                    p.Allow_null = true;

                p.IS_primKey = Convert.ToBoolean(dataGridView1.Rows[rowIndex].Cells[3].Value);

                if (this.DefVal_txt.Text != "")
                    p.default_Value = this.DefVal_txt.Text.ToString();       //data type

                p.Isunique = this.unique_check.Checked;

                p.inCrement = this.inc_dec_checkedList.GetItemChecked(0);
                p.deCrement = this.inc_dec_checkedList.GetItemChecked(1);
                if (this.inc_dec_txt.Text != "")
                    p.step = int.Parse(this.inc_dec_txt.Text.ToString());   //int 
                if (this.Exp_txt.Text != "")
                {
                    string[] ls = this.Exp_txt.Text.ToString().Split('\n');
                    for (int i = 0; i < ls.Count(); i++)
                        p.CheckCons.Add(ls[i]);
                }



                if (this.len_txt.Text != "")
                    p.Length = int.Parse(this.len_txt.Text.ToString());         //int

                if(this.seed_txt.Text != "")
                {
                    p.seed = int.Parse(seed_txt.Text);
                }
                return p;
            }

            return null;
        }
        public void ActivateDataType_Panal()
        {
            string str;
            try
            {
                str = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString();
            }
            catch
            {
                return;
            }

            Exp_txt.Enabled = false;
            if (str != "Int16" && str != "Int32" && str != "Int64" && str != "Byte")
            {
                inc_dec_checkedList.Enabled = false;
                inc_dec_txt.ReadOnly = true;
                unique_check.Enabled = false;
                seed_txt.ReadOnly = true;
            }
            if (str == "Int16" || str == "Int32" || str == "Int64" || str == "Byte" || str == "Decimal" || str == "Double")
            {
                Exp_txt.Enabled = true;
            }
            if (str != "String")
            {
                len_txt.ReadOnly = true;
                //unique_check.Enabled = true;
            }
            if (str == "Boolean")
            {
                DefVal_txt.ReadOnly = true;
                Exp_txt.ReadOnly = true;
                //unique_check.Enabled = false;
            }

            if ((bool)dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[3].Value == true)
                DefVal_txt.ReadOnly = true;
        }
        private bool IsDateTime(string DateVal)
        {
            string[] arr = { "MM/dd/yyyy", "M/dd/yyyy", "MM/d/yyyy", "M/d/yyyy", "MM-dd-yyyy", "M-dd-yyyy", "MM-d-yyyy", "M-d-yyyy" };

            int c = 0;
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    DateTime dateTime = DateTime.ParseExact(DateVal, arr[i], System.Globalization.CultureInfo.InvariantCulture);
                    return true;
                }
                catch
                {
                    c++;
                    if (c == 8)
                    {
                        return false;
                    }
                }
            } return false;
        }
        private void initiate()
        {
            ColumnProperties p = new ColumnProperties();

            for (int i = 0; i < dataSetTable.Columns.Count; i++)
            {
                //fills the CheckCons of the list from the ConstraintTable
                string TableColName =  "'"+ Global.Curtable + dataSetTable.Columns[i].ColumnName + "'";
                DataRow[] CheckConstraint = Global.ConstraintTable.Select("TableColName = " + TableColName);
                if (CheckConstraint.Count() > 0)
                {
                    p.CheckCons = new List<string>(CheckConstraint[0][2].ToString().Split(','));
                }
                //MessageBox.Show(p.CheckCons.Count.ToString());
                /********************/

                designTable.Rows.Add(
                                     dataSetTable.Columns[i].ColumnName,
                                     dataSetTable.Columns[i].AllowDBNull,
                                     dataSetTable.PrimaryKey.Contains(dataSetTable.Columns[i]),
                                     dataSetTable.Columns[i].DataType.ToString().Remove(0, 7)
                                     );


                p.IS_primKey = dataSetTable.PrimaryKey.Contains(dataSetTable.Columns[i]);
                p.Allow_null = dataSetTable.Columns[i].AllowDBNull;
                p.Column_Name = dataSetTable.Columns[i].ColumnName;
                p.Data_Type = dataSetTable.Columns[i].DataType.ToString().Remove(0, 7);
                if (dataSetTable.Columns[i].AutoIncrement)
                {
                    p.step = int.Parse(dataSetTable.Columns[i].AutoIncrementStep.ToString());
                    p.seed = int.Parse(dataSetTable.Columns[i].AutoIncrementSeed.ToString());
                    if (dataSetTable.Columns[i].AutoIncrementStep < 0)
                    {
                        p.deCrement = true;
                        p.step = -p.step;
                    }
                    else
                        p.inCrement = true;
                }
                p.Isunique = dataSetTable.Columns[i].Unique;
                p.Length = dataSetTable.Columns[i].MaxLength;
                p.default_Value = dataSetTable.Columns[i].DefaultValue.ToString();
                p.index = i;
                //p.GetAllData();
                    
                Properties.Add(p);
                p = new ColumnProperties();
            }

            //MessageBox.Show(p.Column_Name + "   " + Properties.Count.ToString());

        }
        private void fill_DataGridViewComBoxCells()
        {
            for (int i = 0; i < Properties.Count; i++)
            {
                (dataGridView1.Rows[i].Cells[0] as DataGridViewComboBoxCell).Value = dataGridView1.Rows[i].Cells[4].Value;
                                    //NOTE :- dataGridView1.Rows[i].Cells[4].Value = Properties[i].Data_Type
                (dataGridView1.Rows[i].Cells[0] as DataGridViewComboBoxCell).ReadOnly = true;
            }
        }


        /************************    Under Construction     ***********************************/

        private void FK_constraint_Click(object sender, EventArgs e)
        {
            ForeignKey fr = new ForeignKey();
            fr.Show();
        }
        private void DeleteCol_btn_Click(object sender, EventArgs e)
        {
            //this.dataGridView1_UserDeletedRow(this, e);
        }
       

    }
}

