namespace Table
{
    partial class ForeignKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForeignKey));
            this.label1 = new System.Windows.Forms.Label();
            this.Relationship_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PK_comboBox = new System.Windows.Forms.ComboBox();
            this.PKT_Columns_Box = new System.Windows.Forms.ComboBox();
            this.FK_Columns_Box = new System.Windows.Forms.ComboBox();
            this.FKT_txt = new System.Windows.Forms.TextBox();
            this.OK_btn = new System.Windows.Forms.Button();
            this.Rule_Box = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relationship Name :-";
            // 
            // Relationship_txt
            // 
            this.Relationship_txt.Location = new System.Drawing.Point(12, 29);
            this.Relationship_txt.Name = "Relationship_txt";
            this.Relationship_txt.Size = new System.Drawing.Size(168, 20);
            this.Relationship_txt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Primary key Table";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Foreign key Table";
            // 
            // PK_comboBox
            // 
            this.PK_comboBox.FormattingEnabled = true;
            this.PK_comboBox.Location = new System.Drawing.Point(12, 85);
            this.PK_comboBox.Name = "PK_comboBox";
            this.PK_comboBox.Size = new System.Drawing.Size(121, 21);
            this.PK_comboBox.TabIndex = 4;
            this.PK_comboBox.SelectedIndexChanged += new System.EventHandler(this.PK_comboBox_SelectedIndexChanged);
            // 
            // PKT_Columns_Box
            // 
            this.PKT_Columns_Box.FormattingEnabled = true;
            this.PKT_Columns_Box.Location = new System.Drawing.Point(12, 121);
            this.PKT_Columns_Box.Name = "PKT_Columns_Box";
            this.PKT_Columns_Box.Size = new System.Drawing.Size(121, 21);
            this.PKT_Columns_Box.TabIndex = 6;
            // 
            // FK_Columns_Box
            // 
            this.FK_Columns_Box.FormattingEnabled = true;
            this.FK_Columns_Box.Location = new System.Drawing.Point(172, 121);
            this.FK_Columns_Box.Name = "FK_Columns_Box";
            this.FK_Columns_Box.Size = new System.Drawing.Size(121, 21);
            this.FK_Columns_Box.TabIndex = 7;
            // 
            // FKT_txt
            // 
            this.FKT_txt.Location = new System.Drawing.Point(172, 85);
            this.FKT_txt.Name = "FKT_txt";
            this.FKT_txt.Size = new System.Drawing.Size(120, 20);
            this.FKT_txt.TabIndex = 8;
            // 
            // OK_btn
            // 
            this.OK_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OK_btn.BackgroundImage")));
            this.OK_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OK_btn.Location = new System.Drawing.Point(252, 170);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(40, 40);
            this.OK_btn.TabIndex = 9;
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // Rule_Box
            // 
            this.Rule_Box.FormattingEnabled = true;
            this.Rule_Box.Location = new System.Drawing.Point(83, 170);
            this.Rule_Box.Name = "Rule_Box";
            this.Rule_Box.Size = new System.Drawing.Size(121, 21);
            this.Rule_Box.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rule setting";
            // 
            // ForeignKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 222);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Rule_Box);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.FKT_txt);
            this.Controls.Add(this.FK_Columns_Box);
            this.Controls.Add(this.PKT_Columns_Box);
            this.Controls.Add(this.PK_comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Relationship_txt);
            this.Controls.Add(this.label1);
            this.Name = "ForeignKey";
            this.Text = "ForeignKey";
            this.Load += new System.EventHandler(this.ForeignKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Relationship_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PK_comboBox;
        private System.Windows.Forms.ComboBox PKT_Columns_Box;
        private System.Windows.Forms.ComboBox FK_Columns_Box;
        private System.Windows.Forms.TextBox FKT_txt;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.ComboBox Rule_Box;
        private System.Windows.Forms.Label label4;

    }
}