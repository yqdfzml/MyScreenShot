using ScreenShot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace MyScreenShot
{
    public partial class Recording : Form
    {
        //是否开始绘制
        private bool Drawwing = false;
        //绘制起点
        private Point StartPoint;
        //绘制终点
        public Point EndPoint;
        //最终矩形
        public Rectangle FinalRect;

        private bool overchoose =false;

        private bool Isrecording = false;

        private Button recordbutton;

        //private ffmpegvideo Ffmpegvideo;


        private readonly Utils utils = new Utils(); //工具函数类

        private readonly Form1 parentform;

        #region
        private int Retype;
        private bool Rregion;
        private string filename;
        private string outputVideoPath;
        private string ffmpegpath = Application.StartupPath + "\\ffmpeg\\ffmpeg.exe";
        #endregion



        public Recording(int type,bool region, Form1 parentform)
        {
            Retype = type;
            Rregion = region;
            InitializeComponent();
            this.parentform = parentform;
        }


        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_HOTKEY = 0x0312;
        //    if (m.Msg == WM_HOTKEY)
        //    {
        //        switch (m.WParam.ToInt32())
        //        {
        //            case 300:
        //                recordbegin();
        //                break;
        //            case 301:
        //                recordend();
        //                break;
        //        }
        //    }
        //    base.WndProc(ref m);
        //}


        private void Recording_Load(object sender, EventArgs e)
        {
            //HotKey.RegisterHotKey(Handle, 300, 0x0002, Keys.F7);
            //HotKey.RegisterHotKey(Handle, 301, 0x0002, Keys.F2);

            if (Retype == 1 && !Rregion)
            {
                FinalRect = Screen.PrimaryScreen.Bounds;
                recordbegin();
            }
           
        }


        private void Recording_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && !overchoose)
            {
                Drawwing = true;
                StartPoint = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                Drawwing = false;
                this.Close();
            }
        }

        private void Recording_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Drawwing)
            {
                //窗体重绘
                this.Invalidate();
            }

        }

        private void Recording_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Drawwing)
            {
                Drawwing = false;
                //获取当前鼠标位置
                EndPoint = e.Location;
                FinalRect = utils.GetRectangle(StartPoint, EndPoint);
                recordbegin();
            }
        }

       

        private void Recording_Paint(object sender, PaintEventArgs e)
        {
            if (Drawwing)
            {
                //获取当前鼠标位置
                Point CurrentPoint = Cursor.Position;
                Point formLocation = this.PointToClient(CurrentPoint);
                using (Pen pen = new Pen(Color.YellowGreen, 2))
                {
                    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    pen.DashPattern = new float[] { 10, 5 };
                    //pen.LineJoin = LineJoin.Round; // 可选：设置线条连接点的样式
                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Rectangle rect = utils.GetRectangle(StartPoint, formLocation);
                    e.Graphics.DrawRectangle(pen, rect);
                    // 设置背景颜色并使用SolidBrush填充矩形  
                    Color backgroundColor = Color.White;
                    using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
                    {
                        e.Graphics.FillRectangle(backgroundBrush, rect);
                    }
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.YellowGreen, 2))
                {
                    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    pen.DashPattern = new float[] { 10, 5 };
                    //pen.LineJoin = LineJoin.Round; // 可选：设置线条连接点的样式
                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawRectangle(pen, FinalRect);
                    // 设置背景颜色并使用SolidBrush填充矩形  
                    Color backgroundColor = Color.White;
                    using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
                    {
                        e.Graphics.FillRectangle(backgroundBrush, FinalRect);
                    }
                }
            }
        }

        private void recordbegin()
        {
            this.Hide();
            Console.WriteLine("开始录制");
            filename = utils.GetFileName();
            if (Retype == 0)
            {
                ffmpegvideo.Start(Path.Combine(Directory.GetCurrentDirectory(), $"video\\{filename}.mp4").ToString(), FinalRect, 1);

            }
            else
            {
                ffmpegvideo.Start(Path.Combine(Directory.GetCurrentDirectory(), $"video\\{filename}.mp4").ToString(), FinalRect, 0);

            }


        }
        public void recordend()
        {
            Console.WriteLine("停止录制");
            ffmpegvideo.Stop();
            this.Close();
            this.Dispose();
        }

    }
}
