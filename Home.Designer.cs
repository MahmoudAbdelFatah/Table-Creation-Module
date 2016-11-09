namespace Table
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.CreateTable_btn = new System.Windows.Forms.Button();
            this.CreateTable_txt = new System.Windows.Forms.TextBox();
            this.OpenTable_btn = new System.Windows.Forms.Button();
            this.DelTable_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateTable_btn
            // 
            this.CreateTable_btn.BackColor = System.Drawing.SystemColors.Control;
            this.CreateTable_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreateTable_btn.BackgroundImage")));
            this.CreateTable_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateTable_btn.Location = new System.Drawing.Point(48, 20);
            this.CreateTable_btn.Name = "CreateTable_btn";
            this.CreateTable_btn.Size = new System.Drawing.Size(30, 30);
            this.CreateTable_btn.TabIndex = 0;
            this.CreateTable_btn.UseVisualStyleBackColor = false;
            this.CreateTable_btn.Click += new System.EventHandler(this.CreateTable_btn_Click);
            // 
            // CreateTable_txt
            // 
            this.CreateTable_txt.Location = new System.Drawing.Point(84, 26);
            this.CreateTable_txt.Name = "CreateTable_txt";
            this.CreateTable_txt.Size = new System.Drawing.Size(121, 20);
            this.CreateTable_txt.TabIndex = 2;
            this.CreateTable_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateTable_txt_KeyDown);
            // 
            // OpenTable_btn
            // 
            this.OpenTable_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenTable_btn.BackgroundImage")));
            this.OpenTable_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenTable_btn.Location = new System.Drawing.Point(48, 60);
            this.OpenTable_btn.Name = "OpenTable_btn";
            this.OpenTable_btn.Size = new System.Drawing.Size(30, 30);
            this.OpenTable_btn.TabIndex = 5;
            this.OpenTable_btn.UseVisualStyleBackColor = true;
            this.OpenTable_btn.Click += new System.EventHandler(this.OpenTable_btn_Click);
            // 
            // DelTable_btn
            // 
            this.DelTable_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DelTable_btn.BackgroundImage")));
            this.DelTable_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DelTable_btn.Location = new System.Drawing.Point(12, 60);
            this.DelTable_btn.Name = "DelTable_btn";
            this.DelTable_btn.Size = new System.Drawing.Size(30, 30);
            this.DelTable_btn.TabIndex = 6;
            this.DelTable_btn.UseVisualStyleBackColor = true;
            this.DelTable_btn.Click += new System.EventHandler(this.DelTable_btn_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(242, 119);
            this.Controls.Add(this.DelTable_btn);
            this.Controls.Add(this.OpenTable_btn);
            this.Controls.Add(this.CreateTable_txt);
            this.Controls.Add(this.CreateTable_btn);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateTable_btn;
        private System.Windows.Forms.TextBox CreateTable_txt;

        public static System.Windows.Forms.ComboBox openExistTable_combo;

        private System.Windows.Forms.Button OpenTable_btn;
        private System.Windows.Forms.Button DelTable_btn;


    }
}

