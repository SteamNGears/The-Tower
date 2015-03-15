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
<<<<<<< HEAD
            this.Lbl_Turn = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
=======
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
>>>>>>> Jakes_Branch
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 55);
            this.button1.Name = "Btn_endTurn";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "end turn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.endTurn_Click);
            // 
            // LevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 770);
<<<<<<< HEAD
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lbl_Turn);
=======
            this.Controls.Add(this.pictureBox1);
>>>>>>> Jakes_Branch
            this.Name = "LevelForm";
            this.Text = "LevelForm";
            this.Click += new System.EventHandler(this.LevelForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

<<<<<<< HEAD
        private System.Windows.Forms.Label Lbl_Turn;
        private System.Windows.Forms.Button button1;
=======
        private System.Windows.Forms.PictureBox pictureBox1;

>>>>>>> Jakes_Branch
    }
}