using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    public partial class ForeignKey : Form
    {
        public ForeignKey()
        {
            InitializeComponent();
            DataTable dt = Design.designTable;
            FKT_txt.Text = Global.Curtable;
            FKT_txt.ReadOnly = true;

            Rule_Box.Items.Add("Cascade");
            Rule_Box.Items.Add("SetNull");
            Rule_Box.Items.Add("SetDefault");
            Rule_Box.Items.Add("None");
            Rule_Box.SelectedIndex = 3;

            foreach(DataColumn col in Global.dataSet.Tables[Global.Curtable].Columns){
                FK_Columns_Box.Items.Add(col.ColumnName);
            }

            foreach (string item in Home.openExistTable_combo.Items)
            {
                if(item!= Global.Curtable)
                    PK_comboBox.Items.Add(item);
            }

        }

        private void PK_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(PK_comboBox.SelectedItem.ToString());
            foreach (DataColumn col in Global.dataSet.Tables[PK_comboBox.SelectedItem.ToString()].Columns)
            {
                PKT_Columns_Box.Items.Add(col.ColumnName);
            }
            Relationship_txt.Text = FKT_txt.Text +"_"+ PK_comboBox.SelectedItem.ToString() + "_FK";
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (PK_comboBox.SelectedItem.ToString() != "" && PKT_Columns_Box.SelectedItem.ToString() != "" && FK_Columns_Box.SelectedItem.ToString() != "")
            {
                ForeignKeyConstraint custOrderFK = new ForeignKeyConstraint(
                                    Relationship_txt.Text,
                                    Global.dataSet.Tables[Global.Curtable].Columns[FK_Columns_Box.SelectedItem.ToString()],
                                    Global.dataSet.Tables[PK_comboBox.SelectedItem.ToString()].Columns[PKT_Columns_Box.SelectedItem.ToString()] 
                                    );

                if(Rule_Box.SelectedIndex == 0)
                    custOrderFK.DeleteRule = Rule.Cascade;
                else if (Rule_Box.SelectedIndex == 1)
                    custOrderFK.DeleteRule = Rule.SetNull;
                else if (Rule_Box.SelectedIndex == 2)
                    custOrderFK.DeleteRule = Rule.SetDefault;
                else if (Rule_Box.SelectedIndex == 3)
                    custOrderFK.DeleteRule = Rule.None;

                // Cannot delete a customer value that has associated existing orders.
                if (Global.dataSet.Tables[PK_comboBox.SelectedItem.ToString()].Constraints.Contains(Relationship_txt.Text))
                {
                    MessageBox.Show("already exist  !");
                    return;
                }

                Global.dataSet.Tables[PK_comboBox.SelectedItem.ToString()].Constraints.Add(custOrderFK);
                MessageBox.Show("Done .");
            }
        }

        private void ForeignKey_Load(object sender, EventArgs e)
        {

        }
 
    }
}
