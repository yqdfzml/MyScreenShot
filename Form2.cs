using MyScreenShot;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ScreenShot
{
    public partial class Form2 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect, // x-coordinate of upper-left corner
    int nTopRect, // y-coordinate of upper-left corner
    int nRightRect, // x-coordinate of lower-right corner
    int nBottomRect, // y-coordinate of lower-right corner
    int nWidthEllipse, // height of ellipse
    int nHeightEllipse // width of ellipse
 );
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
            //if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            //    m.Result = (IntPtr)HTCAPTION;
        }


        #region
        private bool Moving = false;
        private Point StartPoint;
        private Point EndPoint;

        #endregion


        private readonly Utils utils = new Utils();
        //初始缩放倍率
        private double ScaleRatio = 1.0;
        //初始尺寸
        private Size OrginalSize;
        //截取图像
        public Image ShotImage;
        //颜色反转图片
        private Bitmap ColorInvertBItmap;
        //颜色是否已反转
        private bool ColorInvertStatus;
        public string WaterMaskStr;

        public Form2( Image image)
        {
            m_aeroEnabled = false;
            InitializeComponent();
            ShotImage = this.BackgroundImage = image;
            Size = OrginalSize = image.Size;
            //ImageBox.Size = new Size(OrginalSize.Width,OrginalSize.Height);
            //截图完成后自动保存图片
            utils.SaveImage(ShotImage, true);
            Console.WriteLine(Config.folderpath);
            ConfigFileHelper.WritePrivateProfileString("LastSavepath", "LastSave", Config.folderpath, Application.StartupPath + "/config.ini");
        
        }


        private void UpdateButtonPosition()
        {
            //// 模拟一些工作
            //Thread.Sleep(100);
            //// 使用Invoke方法来在UI线程上更新按钮的位置
            //this.Invoke(new Action(() =>
            //{
            //    ImageBox.Dock = DockStyle.Fill;
            //}));
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            // 启动一个新线程来更新按钮的位置
            //Thread updateThread = new Thread(new ThreadStart(UpdateButtonPosition));
            //updateThread.Start();
            //ShadowWindow shadowWindow = new ShadowWindow();
            //shadowWindow.Show();
            ColorInvertStatus = ColorInvertToolStripMenuItem.Checked;
            this.MouseWheel += new MouseEventHandler(MY_MouseWheel);
        }


        //鼠标滚轮事件 改变透明度
        private void MY_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta < 0)
                {
                    this.Opacity -= 0.1;
                    if (Opacity <= 0.3)
                    {
                        this.Opacity = 0.3;
                    }
                }
                else
                {
                    this.Opacity += 0.1;
                }

                ScaleText.Text = "不透明度:" + (Opacity * 100).ToString() + "%";

            }
            else
            {
                if (e.Delta < 0)
                {
                    ScaleRatio -= 0.05;
                    if (ScaleRatio <= 0.3)
                    {
                        ScaleRatio = 0.3;
                    }
                    //Console.WriteLine("down");
                }
                else
                {
                    //Console.WriteLine("up");
                    ScaleRatio += 0.05;
                }
                utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize);
            }

        }


        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !Moving)
            {
                Moving = true;
                StartPoint = e.Location;
               
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Moving)
            {
                this.Location = new Point(this.Location.X + e.Location.X - StartPoint.X, this.Location.Y + e.Location.Y - StartPoint.Y);


            }
        }

        private void Image_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Moving)
            {
                Moving = false;
            }

        }

        private void CopyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.CopyImage(ShotImage);
        }

        private void SaveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.SaveImage(ShotImage, false);
        }

        private void OcrImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
  

        }

        private void DestoryImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ShotImage != null)
            {
                ShotImage.Dispose();
            }
            this.Close();
            this.Dispose();
        }

        private void ScaleUpImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.Resizeform(ScaleRatio += 0.1, this, ScaleText, OrginalSize);
        }

        private void ScaleLowImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.Resizeform(ScaleRatio -= 0.1, this, ScaleText, OrginalSize);
        }

        private void ThumImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.3;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize);
        }

        private void DisImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //internal void setImage(Image finalImage)
        //{
        //    Size = finalImage.Size;
        //    //ImageBox.Image = finalImage;
        //}

        private void HandleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void Scale30_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.3333;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize);
        }

        private void Scale100_Click(object sender, EventArgs e)
        {
            ScaleRatio = 1.0;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize);
        }

        private void Scale80_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.8;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize);
        }

        private void Scale50_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.5;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize);
        }

        private void Scale200_Click(object sender, EventArgs e)
        {
            ScaleRatio = 2.0;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize);
        }


        private void RotateRight_Click(object sender, EventArgs e)
        {
            utils.RotateImage(this, ShotImage, 2);
            //this.BackgroundImage = ShotImage.RotateFlip(RotateFlipType.Rotate180FlipX);
        }

        private void RotateLeft_Click(object sender, EventArgs e)
        {
            utils.RotateImage(this, ShotImage, 1);
        }

        private void RotateHorizon_Click(object sender, EventArgs e)
        {
            utils.RotateImage(this, ShotImage, 3);
        }

        private void RotateVertical_Click(object sender, EventArgs e)
        {
            utils.RotateImage(this, ShotImage, 4);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            SizeBoxText.Text = utils.GetSize(Size);
        }




        //在文件夹中查看
        private void LookFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.LookFile();
        }

        

        //另存为
        private void SaveColorInvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.SaveImage(ColorInvertBItmap, false);

        }



        //查看图片
        private void viewImage_Click(object sender, EventArgs e)
        {
            utils.ViewImage();
        }
        //颜色反转
        private void ColorInvertToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            ColorInvertStatus = ColorInvertToolStripMenuItem.Checked;
            if(ColorInvertStatus)
            {
                ColorInvertBItmap = utils.ColorInvert(ShotImage);
                if(ColorInvertBItmap != null)
                {
                    //ImageBox.Image = ColorInvertBItmap;
                    SaveColorInvertToolStripMenuItem.Enabled = ColorInvertStatus;
                    this.BackgroundImage = ColorInvertBItmap;
                }
            }
            else
            {
                //ImageBox.Image = ShotImage;
                this.BackgroundImage = ShotImage;
            }
        }

        private void PickerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            // 绘制背景图片，位置固定
            //e.Graphics.DrawImage(ShotImage, new Point(0, 0)); // 你可以根据需要调整位置

        }
    }
}



