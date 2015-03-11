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
            this.Lbl_Turn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl_Turn
            // 
            this.Lbl_Turn.AutoEllipsis = true;
            this.Lbl_Turn.AutoSize = true;
            this.Lbl_Turn.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Turn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Turn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Turn.Location = new System.Drawing.Point(402, 9);
            this.Lbl_Turn.Name = "Lbl_Turn";
            this.Lbl_Turn.Size = new System.Drawing.Size(168, 31);
            this.Lbl_Turn.TabIndex = 1;
            this.Lbl_Turn.Text = "Current Turn";
            this.Lbl_Turn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 770);
            this.Controls.Add(this.Lbl_Turn);
            this.Name = "LevelForm";
            this.Text = "LevelForm";
            this.Click += new System.EventHandler(this.LevelForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Turn;
    }
}