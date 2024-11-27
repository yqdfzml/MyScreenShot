﻿namespace ScreenShot
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.Tips = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AreaHotKeyBox = new System.Windows.Forms.TextBox();
            this.AllHotKeyBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoCopyHotKeyBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TietuBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tips
            // 
            this.Tips.AutoSize = true;
            this.Tips.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tips.ForeColor = System.Drawing.SystemColors.Control;
            this.Tips.Location = new System.Drawing.Point(555, -7);
            this.Tips.Name = "Tips";
            this.Tips.Size = new System.Drawing.Size(0, 20);
            this.Tips.TabIndex = 4;
            this.Tips.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SaveButton.Location = new System.Drawing.Point(393, 476);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(48, 25);
            this.SaveButton.TabIndex = 22;
            this.SaveButton.Text = "保存";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.AutoSize = true;
            this.ResetButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResetButton.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ResetButton.Location = new System.Drawing.Point(453, 476);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(48, 25);
            this.ResetButton.TabIndex = 23;
            this.ResetButton.Text = "重置";
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(72, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "区域截图";
            // 
            // AreaHotKeyBox
            // 
            this.AreaHotKeyBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AreaHotKeyBox.Location = new System.Drawing.Point(181, 30);
            this.AreaHotKeyBox.Name = "AreaHotKeyBox";
            this.AreaHotKeyBox.Size = new System.Drawing.Size(127, 27);
            this.AreaHotKeyBox.TabIndex = 25;
            this.AreaHotKeyBox.Text = "F1";
            this.AreaHotKeyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AreaHotKeyBox_KeyDown);
            this.AreaHotKeyBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AreaHotKeyBox_KeyPress);
            // 
            // AllHotKeyBox
            // 
            this.AllHotKeyBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.AllHotKeyBox.Location = new System.Drawing.Point(181, 86);
            this.AllHotKeyBox.Name = "AllHotKeyBox";
            this.AllHotKeyBox.Size = new System.Drawing.Size(127, 27);
            this.AllHotKeyBox.TabIndex = 28;
            this.AllHotKeyBox.Text = "F3";
            this.AllHotKeyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AllHotKeyBox_KeyDown);
            this.AllHotKeyBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllHotKeyBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(72, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "全屏截图";
            // 
            // AutoCopyHotKeyBox
            // 
            this.AutoCopyHotKeyBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.AutoCopyHotKeyBox.Location = new System.Drawing.Point(181, 137);
            this.AutoCopyHotKeyBox.Name = "AutoCopyHotKeyBox";
            this.AutoCopyHotKeyBox.Size = new System.Drawing.Size(127, 27);
            this.AutoCopyHotKeyBox.TabIndex = 31;
            this.AutoCopyHotKeyBox.Text = "Ctrl+F3";
            this.AutoCopyHotKeyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AutoCopyHotKeyBox_KeyDown);
            this.AutoCopyHotKeyBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AutoCopyHotKeyBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(18, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "截图并自动复制";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TietuBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.AreaHotKeyBox);
            this.panel1.Controls.Add(this.AutoCopyHotKeyBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.AllHotKeyBox);
            this.panel1.Location = new System.Drawing.Point(23, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 291);
            this.panel1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(72, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "贴图";
            // 
            // TietuBox
            // 
            this.TietuBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TietuBox.Location = new System.Drawing.Point(181, 187);
            this.TietuBox.Name = "TietuBox";
            this.TietuBox.Size = new System.Drawing.Size(127, 27);
            this.TietuBox.TabIndex = 34;
            this.TietuBox.Text = "F4";
            this.TietuBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TietuBox_KeyDown);
            this.TietuBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TietuBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "快捷键";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(519, 526);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Tips);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setting";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Tips;
        private System.Windows.Forms.Label SaveButton;
        private System.Windows.Forms.Label ResetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AreaHotKeyBox;
        private System.Windows.Forms.TextBox AllHotKeyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AutoCopyHotKeyBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TietuBox;
    }
}