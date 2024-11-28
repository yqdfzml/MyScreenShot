using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ScreenShot.MyEnum;


namespace ScreenShot
{
    public partial class Mask : Form
    {
        private readonly Form1 parentform;
        private readonly Utils utils = new Utils();
        //是否开始绘制
        private bool Drawwing = false;
        //绘制起点
        private Point StartPoint;
        //绘制终点
        public Point EndPoint;
        //最终矩形
        public Rectangle FinalRect;
        //最终图像
        public Image FinalImage;
        //截图类型
        public int shottype;
        //显示窗口
        private Form2 displaywindow;


        public Mask(Form1 parent,  int ShotType)
        {
            shottype = ShotType;
            InitializeComponent();
            parentform = parent;

        }

        private void Mask_Load(object sender, EventArgs e)
        {
            
        }

        //绘制结束
        private void OverDraw()
        {
            FinalRect = utils.GetRectangle(StartPoint, EndPoint);
            FinalImage = utils.GetFinalImage(FinalRect);
            if(displaywindow == null)
            {
                displaywindow = new Form2(FinalImage);
            }
            displaywindow.Show();
            if (shottype == 3)
            {
                utils.CopyImage(FinalImage);
            }
            this.Close();
            this.Dispose();
        }

        private void Mask_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Drawwing = true;
                StartPoint = new Point(e.X, e.Y);

            }
            else if (e.Button == MouseButtons.Right)
            {
                Drawwing = false;
                this.Close();
            }

        }

        //绘制截取矩形
        private void Mask_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Drawwing)
            {
                //窗体重绘
                this.Invalidate();
            }
        }

        //结束绘制
        private void Mask_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Drawwing)
            {
                Drawwing = false;
                //获取当前鼠标位置
                EndPoint = e.Location;
                OverDraw();
            }
        }


        private void Mask_Paint(object sender, PaintEventArgs e)
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

                    // 定义文本字符串、字体、画笔和位置
                    string cinchutext = rect.Size.ToString().Replace('{',' ').Replace('}', ' ');
                    string zuobiaotext = CurrentPoint.ToString().Replace('{',' ').Replace('}', ' ');

                    Font textFont = new Font("simhei", 10);

                    // 设置背景颜色并使用SolidBrush填充矩形  
                    Color backgroundColor = Color.White;
                    using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
                    {
                        e.Graphics.FillRectangle(backgroundBrush, rect);
                        // 绘制文本
                        e.Graphics.DrawString(cinchutext, textFont, backgroundBrush, formLocation);
                        e.Graphics.DrawString(zuobiaotext, textFont, backgroundBrush, new Point(formLocation.X,formLocation.Y+20));
                    }
                }
            }
        }

    }


}
