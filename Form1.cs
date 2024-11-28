using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Policy;
using MyScreenShot.Properties;
using System.Runtime.Remoting.Contexts;
using System.Runtime.InteropServices;
using System.Diagnostics;



namespace ScreenShot
{
    public partial class Form1 : Form
    {
        private readonly Utils utils = new Utils();
        //截屏窗口
        private Mask Mask;
        //设置窗口
        private Setting setting;
        public bool CopyAuto = false;
        //快捷键是否禁用
        public bool HotKeyStus;
        private Magnifier loupewindow;
        public string LastSavePath = "";
        //放大镜
        public bool loupeRes = false;

        //快捷键注册
        #region
        private string Newkeycombina;
        private string Allkeycombina;
        private string CopyAutokeycombina;
        private string Tietukeycombina;
        #endregion

        //快捷键列表
        public List<string> keycombinas;

        //配置文件
        #region
        public Setting Setting;
        public string configpath;
        public ConfigFileHelper configFileHelper;
        #endregion
        //贴图窗口
        private Form2 tietuform;
        //热键类
        private HotKey hotKey = new HotKey();



        public Form1()
        {
            configpath = Application.StartupPath + "/config.ini";
            configFileHelper = new ConfigFileHelper();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            this.BeginInvoke(new Action(() =>
            {
                this.Hide();
            }));
           
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY && !HotKeyStus)
            {
                switch (m.WParam.ToInt32())
                {
                    case 100:
                        NewToolStripMenuItem_Click(null, null);
                        break;
                    case 101:
                        AllToolStripMenuItem_Click(null, null);
                        break;
                    case 102:
                        AutoCopyToolStripMenuItem_Click(null, null);
                        break;
                    case 103:
                        TieTuToolStripMenuItem_Click(null, null);
                        break;
                }
            }
            base.WndProc(ref m);
        }

        //新建截图
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mask = new Mask(this, (int)MyEnum.ShotType.NewShot);
            Mask.Show();
        }
        //全屏截图
        private async void AllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = await utils.ScreenBack();
            if (bitmap != null)
            {
                utils.SaveImage(bitmap, true);
                bitmap.Dispose();
            }
            else
            {
                MessageBox.Show("截取失败");
            }

        }

        //检查是否创建ini配置文件
        private bool ConfigExist()
        {
            //Console.WriteLine(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "config.ini")));
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "config.ini"));
        }

        private void Init()
        {
            //检查是否创建ini配置文件
            if (!ConfigExist())
            {
                CreateConfigInit(configFileHelper, configpath);
            }
            List<MyEnum.HotKeystruct> hotKeystructs = hotKey.RegisterAllHotkeys(configpath, Handle);
            hotKeystructs.ForEach(hotKeystruct =>
            {
                Console.WriteLine(hotKeystruct.functionname + "---->" + hotKeystruct.regeditres);
                //keycombinas.Add(hotKeystruct.keycombina);
                switch (hotKeystruct.functionname)
                {
                    case "NewKeyCombination":
                        NewToolStripMenuItem.ShortcutKeyDisplayString = hotKeystruct.keycombina;
                        break;
                    case "AllKeyCombination":
                        AllToolStripMenuItem.ShortcutKeyDisplayString = hotKeystruct.keycombina;
                        break;
                    case "CopyAutoCombination":
                        CopyAutoToolStripMenuItem.ShortcutKeyDisplayString = hotKeystruct.keycombina;
                        break;
                    case "TietuCombination":
                        TieTuToolStripMenuItem.ShortcutKeyDisplayString = hotKeystruct.keycombina;
                        break;
                }

            });
            loupeRes = loupeToolStripMenuItem.Checked;
            HotKeyStus = UnHotKeyToolStripMenuItem.Checked;
        }

        //首次生成默认ini配置文件
        public void CreateConfigInit(ConfigFileHelper configFileHelper, string configpath)
        {
            configFileHelper.WriteAllConfgig(configpath);
        }

        //截图自动复制
        private void AutoCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mask = new Mask(this, (int)MyEnum.ShotType.CopyShot);
            Mask.Show();
        }
        //重启
        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        //退出
        private void ExitOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //检查更新
        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("当前版本已是最新版");
        }
        //设置
        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setting = new Setting(this);
            setting.Show();
        }
        //贴图
        private void TieTuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = configFileHelper.ReadConfig("LastSavepath", "LastSave", "", 1024, configpath);
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("没有文件");
            }
            else
            {
                Image image = Image.FromFile(path);
                tietuform = new Form2(image);
                tietuform.Show();
            }
        }
        //禁用快捷键
        private void UnHotKeyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("sadasd"+UnHotKeyToolStripMenuItem.Checked);
            HotKeyStus = UnHotKeyToolStripMenuItem.Checked;
        }
        //放大镜
        private void loupeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            loupeRes = loupeToolStripMenuItem.Checked;
            Console.WriteLine("sadasd" + loupeRes);
            if (loupeRes && loupewindow == null)
            {
                loupewindow = new Magnifier();
                loupewindow.Show();
            }
            else
            {
                loupewindow.Close();
                loupewindow.Dispose();
            }
        }


    }
}
