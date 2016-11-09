namespace Table
{
    partial class Design
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Design));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteCol_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.Seed = new System.Windows.Forms.Label();
            this.seed_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.len_txt = new System.Windows.Forms.TextBox();
            this.Exp_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inc_dec_txt = new System.Windows.Forms.TextBox();
            this.unique_check = new System.Windows.Forms.CheckBox();
            this.DefVal_txt = new System.Windows.Forms.TextBox();
            this.inc_dec_checkedList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FK_constraint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridView1.Location = new System.Drawing.Point(15, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 177);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Column Constrains";
            // 
            // DeleteCol_btn
            // 
            this.DeleteCol_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteCol_btn.BackgroundImage")));
            this.DeleteCol_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeleteCol_btn.Location = new System.Drawing.Point(464, 70);
            this.DeleteCol_btn.Name = "DeleteCol_btn";
            this.DeleteCol_btn.Size = new System.Drawing.Size(30, 30);
            this.DeleteCol_btn.TabIndex = 2;
            this.DeleteCol_btn.UseVisualStyleBackColor = true;
            this.DeleteCol_btn.Click += new System.EventHandler(this.DeleteCol_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Seed);
            this.panel1.Controls.Add(this.seed_txt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.len_txt);
            this.panel1.Controls.Add(this.Exp_txt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.inc_dec_txt);
            this.panel1.Controls.Add(this.unique_check);
            this.panel1.Controls.Add(this.DefVal_txt);
            this.panel1.Controls.Add(this.inc_dec_checkedList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 140);
            this.panel1.TabIndex = 3;
            this.panel1.Enter += new System.EventHandler(this.panel1_Enter);
            this.panel1.Leave += new System.EventHandler(this.panel1_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Step";
            // 
            // Seed
            // 
            this.Seed.AutoSize = true;
            this.Seed.Location = new System.Drawing.Point(105, 90);
            this.Seed.Name = "Seed";
            this.Seed.Size = new System.Drawing.Size(31, 13);
            this.Seed.TabIndex = 8;
            this.Seed.Text = "Seed";
            // 
            // seed_txt
            // 
            this.seed_txt.Location = new System.Drawing.Point(96, 69);
            this.seed_txt.Multiline = true;
            this.seed_txt.Name = "seed_txt";
            this.seed_txt.Size = new System.Drawing.Size(53, 18);
            this.seed_txt.TabIndex = 7;
            this.seed_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.seed_txt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Length";
            // 
            // len_txt
            // 
            this.len_txt.Location = new System.Drawing.Point(316, 117);
            this.len_txt.Name = "len_txt";
            this.len_txt.Size = new System.Drawing.Size(130, 20);
            this.len_txt.TabIndex = 5;
            this.len_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.len_txt_KeyPress);
            // 
            // Exp_txt
            // 
            this.Exp_txt.Location = new System.Drawing.Point(316, 47);
            this.Exp_txt.Multiline = true;
            this.Exp_txt.Name = "Exp_txt";
            this.Exp_txt.Size = new System.Drawing.Size(130, 64);
            this.Exp_txt.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Check Constrains";
            // 
            // inc_dec_txt
            // 
            this.inc_dec_txt.Location = new System.Drawing.Point(155, 69);
            this.inc_dec_txt.Multiline = true;
            this.inc_dec_txt.Name = "inc_dec_txt";
            this.inc_dec_txt.Size = new System.Drawing.Size(53, 18);
            this.inc_dec_txt.TabIndex = 2;
            this.inc_dec_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inc_dec_txt_KeyPress);
            // 
            // unique_check
            // 
            this.unique_check.AutoSize = true;
            this.unique_check.Location = new System.Drawing.Point(13, 46);
            this.unique_check.Name = "unique_check";
            this.unique_check.Size = new System.Drawing.Size(77, 17);
            this.unique_check.TabIndex = 0;
            this.unique_check.Text = "IS Identity";
            this.unique_check.UseVisualStyleBackColor = true;
            this.unique_check.CheckedChanged += new System.EventHandler(this.unique_check_CheckedChanged);
            // 
            // DefVal_txt
            // 
            this.DefVal_txt.Location = new System.Drawing.Point(85, 17);
            this.DefVal_txt.Name = "DefVal_txt";
            this.DefVal_txt.Size = new System.Drawing.Size(361, 20);
            this.DefVal_txt.TabIndex = 2;
            this.DefVal_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DefVal_txt_KeyPress);
            this.DefVal_txt.Leave += new System.EventHandler(this.DefVal_txt_Leave);
            // 
            // inc_dec_checkedList
            // 
            this.inc_dec_checkedList.FormattingEnabled = true;
            this.inc_dec_checkedList.Items.AddRange(new object[] {
            "Increment",
            "Decrement"});
            this.inc_dec_checkedList.Location = new System.Drawing.Point(10, 69);
            this.inc_dec_checkedList.Name = "inc_dec_checkedList";
            this.inc_dec_checkedList.Size = new System.Drawing.Size(80, 34);
            this.inc_dec_checkedList.TabIndex = 1;
            this.inc_dec_checkedList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.inc_dec_checkedList_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Defult Value";
            // 
            // save_btn
            // 
            this.save_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save_btn.BackgroundImage")));
            this.save_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save_btn.Location = new System.Drawing.Point(464, 33);
            this.save_btn.Margin = new System.Windows.Forms.Padding(0);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(30, 30);
            this.save_btn.TabIndex = 4;
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            // 
            // FK_constraint
            // 
            this.FK_constraint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FK_constraint.BackgroundImage")));
            this.FK_constraint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FK_constraint.Location = new System.Drawing.Point(464, 180);
            this.FK_constraint.Name = "FK_constraint";
            this.FK_constraint.Size = new System.Drawing.Size(30, 30);
            this.FK_constraint.TabIndex = 7;
            this.FK_constraint.UseVisualStyleBackColor = true;
            this.FK_constraint.Click += new System.EventHandler(this.FK_constraint_Click);
            // 
            // Design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 381);
            this.Controls.Add(this.FK_constraint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DeleteCol_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Design";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Design";
            this.Load += new System.EventHandler(this.Design_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteCol_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DefVal_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox unique_check;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Exp_txt;
        private System.Windows.Forms.TextBox inc_dec_txt;
        private System.Windows.Forms.CheckedListBox inc_dec_checkedList;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox len_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Seed;
        private System.Windows.Forms.TextBox seed_txt;
        private System.Windows.Forms.Button FK_constraint;


    }
}