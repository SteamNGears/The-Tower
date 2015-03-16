namespace TheTower
{
    partial class LevelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtBox_GameInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(426, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 71);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.endTurn_Click);
            // 
            // TxtBox_GameInfo
            // 
            this.TxtBox_GameInfo.BackColor = System.Drawing.Color.Wheat;
            this.TxtBox_GameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBox_GameInfo.Location = new System.Drawing.Point(-3, 626);
            this.TxtBox_GameInfo.Multiline = true;
            this.TxtBox_GameInfo.Name = "TxtBox_GameInfo";
            this.TxtBox_GameInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtBox_GameInfo.Size = new System.Drawing.Size(1027, 125);
            this.TxtBox_GameInfo.TabIndex = 1;
            // 
            // LevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 882);
            this.Controls.Add(this.TxtBox_GameInfo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LevelForm";
            this.Text = "LevelForm";
            this.Click += new System.EventHandler(this.LevelForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtBox_GameInfo;

    }
}