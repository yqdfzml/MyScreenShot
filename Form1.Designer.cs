using MyScreenShot.Properties;

namespace ScreenShot
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyAutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TieTuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loupeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.长截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnHotKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenshot = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.AllToolStripMenuItem,
            this.CopyAutoToolStripMenuItem,
            this.TieTuToolStripMenuItem,
            this.loupeToolStripMenuItem,
            this.toolStripSeparator4,
            this.长截图ToolStripMenuItem,
            this.UnHotKeyToolStripMenuItem,
            this.toolStripSeparator3,
            this.ConnectToolStripMenuItem,
            this.toolStripSeparator1,
            this.SettingToolStripMenuItem,
            this.UpdateToolStripMenuItem,
            this.toolStripSeparator2,
            this.RestartToolStripMenuItem,
            this.ExitOneToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(247, 316);
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.NewToolStripMenuItem.Text = "新建截图";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // AllToolStripMenuItem
            // 
            this.AllToolStripMenuItem.Name = "AllToolStripMenuItem";
            this.AllToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.AllToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.AllToolStripMenuItem.Text = "全屏截图";
            this.AllToolStripMenuItem.Click += new System.EventHandler(this.AllToolStripMenuItem_Click);
            // 
            // CopyAutoToolStripMenuItem
            // 
            this.CopyAutoToolStripMenuItem.Name = "CopyAutoToolStripMenuItem";
            this.CopyAutoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F3";
            this.CopyAutoToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.CopyAutoToolStripMenuItem.Text = "截图并自动复制";
            this.CopyAutoToolStripMenuItem.Click += new System.EventHandler(this.AutoCopyToolStripMenuItem_Click);
            // 
            // TieTuToolStripMenuItem
            // 
            this.TieTuToolStripMenuItem.Name = "TieTuToolStripMenuItem";
            this.TieTuToolStripMenuItem.ShortcutKeyDisplayString = "F4";
            this.TieTuToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.TieTuToolStripMenuItem.Text = "贴图";
            this.TieTuToolStripMenuItem.Click += new System.EventHandler(this.TieTuToolStripMenuItem_Click);
            // 
            // loupeToolStripMenuItem
            // 
            this.loupeToolStripMenuItem.CheckOnClick = true;
            this.loupeToolStripMenuItem.Name = "loupeToolStripMenuItem";
            this.loupeToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.loupeToolStripMenuItem.Text = "放大镜";
            this.loupeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.loupeToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(243, 6);
            // 
            // 长截图ToolStripMenuItem
            // 
            this.长截图ToolStripMenuItem.Enabled = false;
            this.长截图ToolStripMenuItem.Name = "长截图ToolStripMenuItem";
            this.长截图ToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.长截图ToolStripMenuItem.Text = "长截图";
            // 
            // UnHotKeyToolStripMenuItem
            // 
            this.UnHotKeyToolStripMenuItem.CheckOnClick = true;
            this.UnHotKeyToolStripMenuItem.Name = "UnHotKeyToolStripMenuItem";
            this.UnHotKeyToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.UnHotKeyToolStripMenuItem.Text = "禁用快捷键";
            this.UnHotKeyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.UnHotKeyToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
            // 
            // ConnectToolStripMenuItem
            // 
            this.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem";
            this.ConnectToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.SettingToolStripMenuItem.Text = "设置";
            this.SettingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.UpdateToolStripMenuItem.Text = "检查更新";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // RestartToolStripMenuItem
            // 
            this.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem";
            this.RestartToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.RestartToolStripMenuItem.Text = "重新启动";
            this.RestartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // ExitOneToolStripMenuItem
            // 
            this.ExitOneToolStripMenuItem.Name = "ExitOneToolStripMenuItem";
            this.ExitOneToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.ExitOneToolStripMenuItem.Text = "退出";
            this.ExitOneToolStripMenuItem.Click += new System.EventHandler(this.ExitOneToolStripMenuItem_Click);
            // 
            // screenshot
            // 
            this.screenshot.ContextMenuStrip = this.contextMenuStrip1;
            this.screenshot.Icon = ((System.Drawing.Icon)(resources.GetObject("screenshot.Icon")));
            this.screenshot.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(150, 150);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AllToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon screenshot;
        private System.Windows.Forms.ToolStripMenuItem ExitOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnHotKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 长截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyAutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TieTuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loupeToolStripMenuItem;
    }
}

