namespace MyScreenShot
{
    partial class Toolbars
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.finishbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // finishbutton
            // 
            this.finishbutton.ForeColor = System.Drawing.Color.Black;
            this.finishbutton.Location = new System.Drawing.Point(199, 3);
            this.finishbutton.Name = "finishbutton";
            this.finishbutton.Size = new System.Drawing.Size(80, 30);
            this.finishbutton.TabIndex = 0;
            this.finishbutton.Text = "完成";
            this.finishbutton.UseVisualStyleBackColor = true;
            this.finishbutton.Click += new System.EventHandler(this.finishbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.ForeColor = System.Drawing.Color.Black;
            this.cancelbutton.Location = new System.Drawing.Point(109, 3);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(80, 30);
            this.cancelbutton.TabIndex = 1;
            this.cancelbutton.Text = "取消";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // Toolbars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.finishbutton);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "Toolbars";
            this.Size = new System.Drawing.Size(284, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button finishbutton;
        private System.Windows.Forms.Button cancelbutton;
    }
}
