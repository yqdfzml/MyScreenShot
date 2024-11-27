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






namespace ScreenShot
{
    public partial class Form1 : Form
    {

        private readonly Utils utils = new Utils();
        //截屏窗口
        private Mask Mask;
        //显示窗口
        private Form2 form2;
        //联系窗口
        private Form connect;
        //打赏窗口
        private Form beg;
        //设置窗口
        private Setting setting;
        //网页浏览窗口
        private WebBrowser webBrowser;

        private Timer clipboardTimer;

        public bool CopyAuto = false;

        //快捷键是否禁用
        public bool HotKeyStus;

        private Magnifier loupewindow;

        public string LastSavePath = "";


        //放大镜
        public bool loupeRes = false;

        //快捷键注册状态
        #region
        private bool Allres;
        private bool Newres;
        private bool CopyAutores;
        #endregion


        //配置文件
        #region
        public Setting Setting;
        public string configpath;
        public ConfigFileHelper configFileHelper;
        #endregion


        //贴图窗口

        private Form2 tietuform;


        public enum ShotType
        {
            NewShot = 1,
            AllShot = 2,
            AutoCopyShot = 3,
            GifShot = 4,
            LongShot = 5,
        }

        public bool GifScreenShot = false;

        public string WaterMaskTextStr = "SuperDragon";

        public Form1()
        {

            //clipboardTimer = new Timer();
            //clipboardTimer.Interval = 10000;
            //clipboardTimer.Tick += CheckClipboard;
            //clipboardTimer.Start();
            InitializeComponent();
        }


        private void CheckClipboard(object sender, EventArgs e)
        {
            //clipboard();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            loupeToolStripMenuItem.Checked = loupeRes;

            HotKeyStus = true;
            configpath = Application.StartupPath + "/config.ini";
            configFileHelper = new ConfigFileHelper();


            this.BeginInvoke(new Action(() =>
            {
                this.Hide();
            }));
            Init();
        }







        ////轮训查询剪切板
        //private void clipboard()
        //{
        //    if (Clipboard.ContainsText())
        //    {
        //        string clipboardText = Clipboard.GetText();
        //        // 创建一个RichTextBox来获取文本格式
        //        RichTextBox rtb = new RichTextBox();
        //        rtb.Text = clipboardText;
        //        // 获取包含格式的RTF数据
        //        string rtfData = rtb.SelectedRtf;
        //        // 从RTF数据中解析出文本内容和部分格式信息（这里简单示例字体、字号和颜色）
        //        string textContent = rtb.Text;
        //        Font font = rtb.SelectionFont;
        //        Color color = rtb.SelectionColor;
        //        // 创建一个Bitmap对象作为图片基础
        //        Bitmap bitmap = new Bitmap(400, 300);
        //        // 从Bitmap对象获取Graphics对象，用于绘图
        //        using (Graphics g = Graphics.FromImage(bitmap))
        //        {
        //            // 设置文本绘制的字体、颜色等格式
        //            g.DrawString(textContent, font, new SolidBrush(color), 0, 0);
        //            // 保存图片为文件
        //            //bitmap.Save("rich_text_as_image.jpg", ImageFormat.Jpeg);
        //        }
        //        rtb.Dispose();
        //        tietuform = new Form2(this, bitmap);
        //        tietuform.Show();

        //    }
        //}



        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY && HotKeyStus)
            {
                switch (m.WParam.ToInt32())
                {
                    case 100:
                        AreaToolStripMenuItem_Click(null, null);
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

        //新建截图
        private void AreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mask = new Mask(this, (int)ShotType.NewShot);
            Mask.Show();

        }

        private void BegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //beg = new Beg();
            //beg.Show();


        }
        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //connect = new Connect();
            //connect.Show();
        }


        //private void ReHook()
        //{
        //    Allres = utils.ReHook(Handle, 100, 0, 0x70);
        //    if (!Allres) MessageBox.Show("区域截图热键F1注册失败");
        //    Newres = utils.ReHook(Handle, 101, 0, 0x72);
        //    if (!Newres) MessageBox.Show("全屏截图热键F3注册失败");
        //    CopyAutores = utils.ReHook(Handle, 102, 2, 0x72);
        //    if (!CopyAutores) MessageBox.Show("截图自动保存热键Ctrl+F3注册失败");
        //}



        //检查是否创建ini配置文件
        private bool ConfigExist()
        {
            return configFileHelper.ReadConfig("Create", "First", "", 1024, configpath).Length > 0;
        }


        private void Init()
        {
            //检查是否创建ini配置文件
            bool IniExist = ConfigExist();
            if (!IniExist)
            {
                //MessageBox.Show("未创建");
                CreateConfigInit(configFileHelper, configpath);
            }
            //MessageBox.Show("已创建");
            ReadConfig(configFileHelper, configpath);
        }

        //首次生成默认ini配置文件
        public void CreateConfigInit(ConfigFileHelper configFileHelper, string configpath)
        {
            configFileHelper.WriteConfig("Create", "First", "true", configpath);
            configFileHelper.WriteConfig("HotKeys", "AreaKeyCombination", "F1", configpath);
            configFileHelper.WriteConfig("HotKeys", "AllKeyCombination", "F3", configpath);
            configFileHelper.WriteConfig("HotKeys", "CopyAutoCombination", "Ctrl+F3", configpath);
            configFileHelper.WriteConfig("HotKeys", "TietuCombination", "F4", configpath);

            configFileHelper.WriteConfig("WaterMask", "WaterMaskStr", WaterMaskTextStr, configpath);
            configFileHelper.WriteConfig("LastSavepath", "LastSave", LastSavePath, configpath);
        }

        public void SetLastPath(string path)
        {
            configFileHelper.WriteConfig("LastSavepath", "LastSave", path, configpath);
        }


        //读取配置文件
        public void ReadConfig(ConfigFileHelper configFileHelper, string configpath)
        {
            string AreaStatusText = configFileHelper.ReadConfig("HotKeys", "AreaKeyCombination", "", 1024, configpath);
            string AllStatusText = configFileHelper.ReadConfig("HotKeys", "AllKeyCombination", "", 1024, configpath);
            string CopyAutoStatusText = configFileHelper.ReadConfig("HotKeys", "CopyAutoCombination", "", 1024, configpath);
            string TietuStatusText = configFileHelper.ReadConfig("HotKeys", "TietuCombination", "", 1024, configpath);

            WaterMaskTextStr = configFileHelper.ReadConfig("WaterMask", "WaterMaskStr", "", 1024, configpath);

            utils.UpDateHotKey(AreaStatusText, 100, Handle);
            utils.UpDateHotKey(AllStatusText, 101, Handle);
            utils.UpDateHotKey(CopyAutoStatusText, 102, Handle);
            utils.UpDateHotKey(TietuStatusText, 103, Handle);

            NewToolStripMenuItem.Text = "新建截图            " + AreaStatusText;
            AllToolStripMenuItem.Text = "全屏截图            " + AllStatusText;
            AutoCopyToolStripMenuItem.Text = "截图并自动复制            " + CopyAutoStatusText;
            TieTuToolStripMenuItem.Text = "贴图                    " + TietuStatusText;

        }



        public void SetImage(Image finalImage)
        {
            form2 = new Form2(this, finalImage);
            form2.Show();
        }

        private void AutoCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyAuto = true;
            Mask = new Mask(this, (int)ShotType.AutoCopyShot);
            Mask.Show();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ExitOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("当前版本已是最新版");
        }

        private void UnHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotKeyStus = !HotKeyStus;
        }

        private void CustomShotToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GifScreenShot = true;
            Mask = new Mask(this, (int)ShotType.GifShot);
            Mask.Show();

        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setting = new Setting(this);
            setting.Show();
        }


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
                tietuform = new Form2(this, image);
                tietuform.Show();
            }
        }


        // 异步方法，用于截取网页截图
        private void WebShotToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loupeToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void loupeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loupeRes = !loupeRes;

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
