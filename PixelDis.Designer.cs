namespace MyScreenShot
{
    partial class PixelDis
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PixelDis));
            this.pixelabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pixelabel
            // 
            this.pixelabel.AutoSize = true;
            this.pixelabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pixelabel.Location = new System.Drawing.Point(13, 9);
            this.pixelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pixelabel.Name = "pixelabel";
            this.pixelabel.Size = new System.Drawing.Size(92, 25);
            this.pixelabel.TabIndex = 0;
            this.pixelabel.Text = "#FFFAFA";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "按下Ctrl+C复制颜色";
            // 
            // PixelDis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(210, 86);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pixelabel);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PixelDis";
            this.Text = "拾色器";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PixelDis_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PixelDis_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pixelabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}