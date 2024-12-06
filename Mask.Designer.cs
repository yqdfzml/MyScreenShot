namespace ScreenShot
{
    partial class Mask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mask));
            this.MaskBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MaskBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MaskBox
            // 
            this.MaskBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaskBox.Location = new System.Drawing.Point(0, 0);
            this.MaskBox.Name = "MaskBox";
            this.MaskBox.Size = new System.Drawing.Size(905, 490);
            this.MaskBox.TabIndex = 0;
            this.MaskBox.TabStop = false;
            this.MaskBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MaskBox_Paint);
            this.MaskBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MaskBox_MouseDown);
            this.MaskBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MaskBox_MouseMove);
            this.MaskBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MaskBox_MouseUp);
            // 
            // Mask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(905, 490);
            this.Controls.Add(this.MaskBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Mask";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Mask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MaskBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MaskBox;
    }
}