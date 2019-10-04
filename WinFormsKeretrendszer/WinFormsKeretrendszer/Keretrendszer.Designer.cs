namespace WinFormsKeretrendszer
{
    partial class Keretrendszer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Canny = new System.Windows.Forms.Button();
            this.Thresholding = new System.Windows.Forms.Button();
            this.Watershed = new System.Windows.Forms.Button();
            this.Algoritmusok = new System.Windows.Forms.Label();
            this.BackToNormal = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 376);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(857, 376);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Canny
            // 
            this.Canny.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Canny.Location = new System.Drawing.Point(102, 45);
            this.Canny.Name = "Canny";
            this.Canny.Size = new System.Drawing.Size(75, 23);
            this.Canny.TabIndex = 2;
            this.Canny.Text = "Canny";
            this.Canny.UseVisualStyleBackColor = true;
            this.Canny.Click += new System.EventHandler(this.Canny_Click);
            // 
            // Thresholding
            // 
            this.Thresholding.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Thresholding.Location = new System.Drawing.Point(183, 45);
            this.Thresholding.Name = "Thresholding";
            this.Thresholding.Size = new System.Drawing.Size(108, 23);
            this.Thresholding.TabIndex = 3;
            this.Thresholding.Text = "Thresholding";
            this.Thresholding.UseVisualStyleBackColor = true;
            this.Thresholding.Click += new System.EventHandler(this.Thresholding_Click);
            // 
            // Watershed
            // 
            this.Watershed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Watershed.Location = new System.Drawing.Point(297, 45);
            this.Watershed.Name = "Watershed";
            this.Watershed.Size = new System.Drawing.Size(75, 23);
            this.Watershed.TabIndex = 4;
            this.Watershed.Text = "Watershed";
            this.Watershed.UseVisualStyleBackColor = true;
            this.Watershed.Click += new System.EventHandler(this.Watershed_Click);
            // 
            // Algoritmusok
            // 
            this.Algoritmusok.AutoSize = true;
            this.Algoritmusok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Algoritmusok.Location = new System.Drawing.Point(13, 54);
            this.Algoritmusok.Name = "Algoritmusok";
            this.Algoritmusok.Size = new System.Drawing.Size(83, 13);
            this.Algoritmusok.TabIndex = 5;
            this.Algoritmusok.Text = "Algoritmusok:";
            // 
            // BackToNormal
            // 
            this.BackToNormal.Location = new System.Drawing.Point(735, 41);
            this.BackToNormal.Name = "BackToNormal";
            this.BackToNormal.Size = new System.Drawing.Size(133, 23);
            this.BackToNormal.TabIndex = 6;
            this.BackToNormal.Text = "Back to normal";
            this.BackToNormal.UseVisualStyleBackColor = true;
            this.BackToNormal.Click += new System.EventHandler(this.BackToNormal_Click);
            // 
            // Keretrendszer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 458);
            this.Controls.Add(this.BackToNormal);
            this.Controls.Add(this.Algoritmusok);
            this.Controls.Add(this.Watershed);
            this.Controls.Add(this.Thresholding);
            this.Controls.Add(this.Canny);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Keretrendszer";
            this.Text = "Keretrendszer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Canny;
        private System.Windows.Forms.Button Thresholding;
        private System.Windows.Forms.Button Watershed;
        private System.Windows.Forms.Label Algoritmusok;
        private System.Windows.Forms.Button BackToNormal;
    }
}

