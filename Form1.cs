using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using MyScreenShot;
using System.Diagnostics;
using static ScreenShot.MyEnum;


namespace ScreenShot
{
    public partial class Form1 : Form
    {
        private readonly Utils utils = new Utils();
        //截屏窗口
        private Mask Mask;
        //设置窗口
        private Setting setting;

        private Recording  recording;

        public bool CopyAuto = false;
        //快捷键是否禁用
        public bool HotKeyStus;
        private Magnifier loupewindow;
        public string LastSavePath = "";
        //放大镜
        public bool loupeRes = false;
        //拾色器
        public Picker Picker = new Picker();
        public Point p;
        public bool pickres;
        private PixelDis pixeldis = new PixelDis();

        public bool isrecord = false;

        private string end;
        private string begin;


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


        private List<MyEnum.HotKeystruct> hotKeystructs;

        public Form1()
        {
            configpath = Application.StartupPath + "/config.ini";
            configFileHelper = new ConfigFileHelper();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //ShadowWindow shadowWindow = new ShadowWindow();
            //shadowWindow.Show();

            pickres = PickerToolStripMenuItem.Checked;
          


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
                    case 104:
                        recordGIFToolStripMenuItem_Click(null, null);
                        break;
                    case 105:
                        recording.recordend();
                        break;

                }
            }
            base.WndProc(ref m);
        }

        //新建截图
        private async void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = await utils.ScreenBack();
            Mask = new Mask(this, (int)MyEnum.ShotType.NewShot,bitmap);
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
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "config.ini"));
        }

        //检查是否创建video文件夹
        private bool CVideoExist()
        {
            return Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "video"));
        }
        //检查是否创建gif文件夹
        private bool GifExist()
        {
            return Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "gif"));
        }

        private void Init()
        {
            //检查是否创建ini配置文件
            if (!ConfigExist())
            {
                CreateConfigInit(configFileHelper, configpath);
            }
            if (!CVideoExist())
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "video"));
            }
            if (!GifExist())
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "gif"));
            }
            ReadConfig();
            loupeRes = loupeToolStripMenuItem.Checked;
            HotKeyStus = UnHotKeyToolStripMenuItem.Checked;
        }

        public void ReadConfig()
        {
            hotKeystructs = hotKey.RegisterAllHotkeys(configpath, Handle);
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
                    case "BeginReCombination":
                        begin = recordGIFToolStripMenuItem.ShortcutKeyDisplayString = hotKeystruct.keycombina;
                        break;
                    case "EndReCombination":
                        end = hotKeystruct.keycombina;
                        break;
                }
            });
            string fails ="";
            List<string> sds = hotKey.failhotkeys;
            foreach (string s in sds)
            {
                Console.WriteLine(s);
                switch (s)
                {
                    case "NewKeyCombination":
                        fails += "新建截图热键注册失败\n";
                        break;
                    case "AllKeyCombination":
                        fails += "全屏截图热键注册失败\n";
                        break;
                    case "CopyAutoCombination":
                        fails += "自动复制热键注册失败\n";
                        break;
                    case "TietuCombination":
                        fails +="贴图热键注册失败\n";
                        break;
                    case "BeginReCombination":
                        fails +="开始录制热键注册失败\n";
                        break;
                    case "EndReCombination":
                        fails +="结束录制热键注册失败\n";
                        break;
                }
            }
            if(fails != string.Empty)
            {
                MessageBox.Show(fails);
            }

        }

        //首次生成默认ini配置文件
        public void CreateConfigInit(ConfigFileHelper configFileHelper, string configpath)
        {
            configFileHelper.WriteAllConfig(configpath);

        }

        //截图自动复制
        private async void AutoCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = await utils.ScreenBack();
            if(Mask == null)
            {
                Mask = new Mask(this, (int)MyEnum.ShotType.CopyShot, bitmap);
                Mask.Show();
            }
            bitmap.Dispose();
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
            Console.WriteLine("sadasd"+UnHotKeyToolStripMenuItem.Checked);
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
        
        //拾色器
        private void PickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void PickerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            pickres = PickerToolStripMenuItem.Checked;
            Console.WriteLine("-----" + pickres);
            if (pixeldis != null)
            {
                pixeldis.Show();
            }
            if (!pickres)
            {
                pixeldis.Close();
                pixeldis.Dispose();
            }
        }

        private void RecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

        }

        private void AllrecorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int recodertype = 1;
            recording = new Recording(recodertype,false,this);
            recording.Show();
        }

        private void ArearecoderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int recodertype = 1;
            recording = new Recording(recodertype,true,this);
            recording.Show();
        }

        private void recordGIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isrecord = !isrecord;
            if (isrecord)
            {
                recordGIFToolStripMenuItem.Text = "停止录制";
                recordGIFToolStripMenuItem.ShortcutKeyDisplayString = end;
                int recodertype = 0;
                recording = new Recording(recodertype, true, this);
                recording.Show();
            }
            else
            {
                recording.recordend();
                recordGIFToolStripMenuItem.Text = "录制GIF";
                recordGIFToolStripMenuItem.ShortcutKeyDisplayString = begin;
            }
            
        }
    }
}
