namespace ScreenShot
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.CopyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.HandleImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateRight = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateHorizon = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale30 = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale50 = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale80 = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale100 = new System.Windows.Forms.ToolStripMenuItem();
            this.Scale200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LookFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DestoryImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SizeBoxText = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ColorInvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveColorInvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewImage = new System.Windows.Forms.ToolStripMenuItem();
            this.ScaleText = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CopyImageToolStripMenuItem
            // 
            this.CopyImageToolStripMenuItem.Name = "CopyImageToolStripMenuItem";
            this.CopyImageToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.CopyImageToolStripMenuItem.Text = "复制图像";
            this.CopyImageToolStripMenuItem.Click += new System.EventHandler(this.CopyImageToolStripMenuItem_Click);
            // 
            // SaveImageToolStripMenuItem
            // 
            this.SaveImageToolStripMenuItem.Name = "SaveImageToolStripMenuItem";
            this.SaveImageToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.SaveImageToolStripMenuItem.Text = "图像另存为";
            this.SaveImageToolStripMenuItem.Click += new System.EventHandler(this.SaveImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // HandleImageToolStripMenuItem
            // 
            this.HandleImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RotateRight,
            this.RotateLeft,
            this.RotateHorizon,
            this.RotateVertical});
            this.HandleImageToolStripMenuItem.Name = "HandleImageToolStripMenuItem";
            this.HandleImageToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.HandleImageToolStripMenuItem.Text = "图像处理";
            this.HandleImageToolStripMenuItem.Click += new System.EventHandler(this.HandleImageToolStripMenuItem_Click);
            // 
            // RotateRight
            // 
            this.RotateRight.Name = "RotateRight";
            this.RotateRight.Size = new System.Drawing.Size(224, 26);
            this.RotateRight.Text = "向右旋转";
            this.RotateRight.Click += new System.EventHandler(this.RotateRight_Click);
            // 
            // RotateLeft
            // 
            this.RotateLeft.Name = "RotateLeft";
            this.RotateLeft.Size = new System.Drawing.Size(224, 26);
            this.RotateLeft.Text = "向左旋转";
            this.RotateLeft.Click += new System.EventHandler(this.RotateLeft_Click);
            // 
            // RotateHorizon
            // 
            this.RotateHorizon.Name = "RotateHorizon";
            this.RotateHorizon.Size = new System.Drawing.Size(224, 26);
            this.RotateHorizon.Text = "水平翻转";
            this.RotateHorizon.Click += new System.EventHandler(this.RotateHorizon_Click);
            // 
            // RotateVertical
            // 
            this.RotateVertical.Name = "RotateVertical";
            this.RotateVertical.Size = new System.Drawing.Size(224, 26);
            this.RotateVertical.Text = "垂直翻转";
            this.RotateVertical.Click += new System.EventHandler(this.RotateVertical_Click);
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Scale30,
            this.Scale50,
            this.Scale80,
            this.Scale100,
            this.Scale200});
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.缩放ToolStripMenuItem.Text = "缩放";
            // 
            // Scale30
            // 
            this.Scale30.Name = "Scale30";
            this.Scale30.Size = new System.Drawing.Size(224, 26);
            this.Scale30.Text = "33.33%";
            this.Scale30.Click += new System.EventHandler(this.Scale30_Click);
            // 
            // Scale50
            // 
            this.Scale50.Name = "Scale50";
            this.Scale50.Size = new System.Drawing.Size(224, 26);
            this.Scale50.Text = "50%";
            this.Scale50.Click += new System.EventHandler(this.Scale50_Click);
            // 
            // Scale80
            // 
            this.Scale80.Name = "Scale80";
            this.Scale80.Size = new System.Drawing.Size(224, 26);
            this.Scale80.Text = "80%";
            this.Scale80.Click += new System.EventHandler(this.Scale80_Click);
            // 
            // Scale100
            // 
            this.Scale100.Name = "Scale100";
            this.Scale100.Size = new System.Drawing.Size(224, 26);
            this.Scale100.Text = "100%";
            this.Scale100.Click += new System.EventHandler(this.Scale100_Click);
            // 
            // Scale200
            // 
            this.Scale200.Name = "Scale200";
            this.Scale200.Size = new System.Drawing.Size(224, 26);
            this.Scale200.Text = "200%";
            this.Scale200.Click += new System.EventHandler(this.Scale200_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // LookFileToolStripMenuItem
            // 
            this.LookFileToolStripMenuItem.Name = "LookFileToolStripMenuItem";
            this.LookFileToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.LookFileToolStripMenuItem.Text = "打开所在文件夹";
            this.LookFileToolStripMenuItem.Click += new System.EventHandler(this.LookFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // DestoryImageToolStripMenuItem
            // 
            this.DestoryImageToolStripMenuItem.Name = "DestoryImageToolStripMenuItem";
            this.DestoryImageToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.DestoryImageToolStripMenuItem.Text = "销毁";
            this.DestoryImageToolStripMenuItem.Click += new System.EventHandler(this.DestoryImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(207, 6);
            // 
            // SizeBoxText
            // 
            this.SizeBoxText.Name = "SizeBoxText";
            this.SizeBoxText.Size = new System.Drawing.Size(210, 24);
            this.SizeBoxText.Text = "0 x 0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyImageToolStripMenuItem,
            this.SaveImageToolStripMenuItem,
            this.toolStripSeparator2,
            this.ColorInvertToolStripMenuItem,
            this.SaveColorInvertToolStripMenuItem,
            this.HandleImageToolStripMenuItem,
            this.缩放ToolStripMenuItem,
            this.toolStripSeparator1,
            this.viewImage,
            this.LookFileToolStripMenuItem,
            this.toolStripSeparator3,
            this.DestoryImageToolStripMenuItem,
            this.toolStripSeparator4,
            this.SizeBoxText});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 296);
            // 
            // ColorInvertToolStripMenuItem
            // 
            this.ColorInvertToolStripMenuItem.CheckOnClick = true;
            this.ColorInvertToolStripMenuItem.Name = "ColorInvertToolStripMenuItem";
            this.ColorInvertToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.ColorInvertToolStripMenuItem.Text = "颜色反转";
            this.ColorInvertToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ColorInvertToolStripMenuItem_CheckedChanged);
            // 
            // SaveColorInvertToolStripMenuItem
            // 
            this.SaveColorInvertToolStripMenuItem.Enabled = false;
            this.SaveColorInvertToolStripMenuItem.Name = "SaveColorInvertToolStripMenuItem";
            this.SaveColorInvertToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.SaveColorInvertToolStripMenuItem.Text = "保存颜色反转图片";
            this.SaveColorInvertToolStripMenuItem.Click += new System.EventHandler(this.SaveColorInvertToolStripMenuItem_Click);
            // 
            // viewImage
            // 
            this.viewImage.Name = "viewImage";
            this.viewImage.Size = new System.Drawing.Size(210, 24);
            this.viewImage.Text = "查看图像";
            this.viewImage.Click += new System.EventHandler(this.viewImage_Click);
            // 
            // ScaleText
            // 
            this.ScaleText.AutoSize = true;
            this.ScaleText.Location = new System.Drawing.Point(2, 2);
            this.ScaleText.Name = "ScaleText";
            this.ScaleText.Size = new System.Drawing.Size(107, 15);
            this.ScaleText.TabIndex = 1;
            this.ScaleText.Text = "缩放大小:100%";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(445, 293);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.ScaleText);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1918, 1040);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Image_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_MouseUp);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem CopyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DestoryImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HandleImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem RotateRight;
        private System.Windows.Forms.ToolStripMenuItem RotateLeft;
        private System.Windows.Forms.ToolStripMenuItem RotateHorizon;
        private System.Windows.Forms.ToolStripMenuItem RotateVertical;
        private System.Windows.Forms.ToolStripMenuItem 缩放ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Scale30;
        private System.Windows.Forms.ToolStripMenuItem Scale50;
        private System.Windows.Forms.ToolStripMenuItem Scale80;
        private System.Windows.Forms.ToolStripMenuItem Scale100;
        private System.Windows.Forms.ToolStripMenuItem Scale200;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem LookFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SizeBoxText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ColorInvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveColorInvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewImage;
        private System.Windows.Forms.Label ScaleText;
    }
}