namespace Table
{
    partial class Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.save_btn = new System.Windows.Forms.Button();
            this.Delete_Row_btn = new System.Windows.Forms.Button();
            this.EditTable_btn = new System.Windows.Forms.Button();
            this.Table_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(659, 325);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // save_btn
            // 
            this.save_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save_btn.BackgroundImage")));
            this.save_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save_btn.Location = new System.Drawing.Point(674, 26);
            this.save_btn.Margin = new System.Windows.Forms.Padding(0);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(30, 30);
            this.save_btn.TabIndex = 1;
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // Delete_Row_btn
            // 
            this.Delete_Row_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Delete_Row_btn.BackgroundImage")));
            this.Delete_Row_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Delete_Row_btn.Location = new System.Drawing.Point(674, 60);
            this.Delete_Row_btn.Name = "Delete_Row_btn";
            this.Delete_Row_btn.Size = new System.Drawing.Size(30, 30);
            this.Delete_Row_btn.TabIndex = 3;
            this.Delete_Row_btn.UseVisualStyleBackColor = true;
            this.Delete_Row_btn.Click += new System.EventHandler(this.Delete_Row_btn_Click);
            // 
            // EditTable_btn
            // 
            this.EditTable_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditTable_btn.BackgroundImage")));
            this.EditTable_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EditTable_btn.Location = new System.Drawing.Point(674, 96);
            this.EditTable_btn.Name = "EditTable_btn";
            this.EditTable_btn.Size = new System.Drawing.Size(30, 30);
            this.EditTable_btn.TabIndex = 4;
            this.EditTable_btn.UseVisualStyleBackColor = true;
            this.EditTable_btn.Click += new System.EventHandler(this.EditTable_btn_Click);
            // 
            // Table_Name
            // 
            this.Table_Name.AutoSize = true;
            this.Table_Name.Location = new System.Drawing.Point(9, 10);
            this.Table_Name.Name = "Table_Name";
            this.Table_Name.Size = new System.Drawing.Size(35, 13);
            this.Table_Name.TabIndex = 5;
            this.Table_Name.Text = "label1";
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 363);
            this.Controls.Add(this.Table_Name);
            this.Controls.Add(this.EditTable_btn);
            this.Controls.Add(this.Delete_Row_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Edit_FormClosing);
            this.Load += new System.EventHandler(this.Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button Delete_Row_btn;
        private System.Windows.Forms.Button EditTable_btn;
        private System.Windows.Forms.Label Table_Name;
    }
}