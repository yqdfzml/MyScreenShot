using MyScreenShot;
using System;
using System.Drawing;
using System.Windows.Forms;

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

        private Bitmap Orginbitmap;

        private bool moving = false;

        //工具栏
        private Toolbars toolbars;


        private Point mouseoffset = new Point();

        //完成绘制
        private bool drawover =false;



        ////录屏相关变量
        //#region
        //private string ffmpegpath = Application.StartupPath + "\\ffmpeg\\ffmpeg.exe";
        //private int _frameCount = 0; // 帧计数
        //private Rectangle _captureArea;
        //private bool _isRecording = false; // 是否正在录屏
        //private string _tempImagePath; // 临时图像文件路径
        //private string _outputVideoPath; // 输出视频文件路径
        //private Thread _captureThread; // 捕获屏幕图像的线程
        //#endregion

        //是否固定
        private bool pintoclient =false;


        public Mask(Form1 parent,  int ShotType,Bitmap bitmap)
        {
            this.DoubleBuffered = true;
            Orginbitmap = bitmap;
            shottype = ShotType;
            InitializeComponent();
            parentform = parent;

        }

       



        private  void Mask_Load(object sender, EventArgs e)
        {
            if(toolbars == null)
            {
                toolbars = new Toolbars();
                // 订阅 Toolbars 的自定义事件
                toolbars.FinishClicked += Toolbars_FinishClicked;
                toolbars.CancelClicked += Toolbars_CancelClicked;
                //toolbars.Location = new Point(Screen.PrimaryScreen.Bounds.Right - toolbars.Width,Screen.PrimaryScreen.Bounds.Bottom - toolbars.Height);
                //StartPoint = new Point(0, 0);
                //EndPoint = new Point(Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Bottom);
                //FinalRect = utils.GetRectangle(StartPoint, EndPoint);
                //toolbars.Show();
            }
            MaskBox.Image = Orginbitmap;
            this.DoubleBuffered = true;
            
        }


        //绘制结束
        private void OverDraw()
        {
            FinalImage = utils.GetFinalImage(FinalRect);
            if (displaywindow == null)
            {
                displaywindow = new Form2(FinalImage);
                displaywindow.Show();
            }
            if (shottype == 3)
            {
                utils.CopyImage(FinalImage);
            }
            if (MaskBox.Image != null || Orginbitmap != null)
            {
                Orginbitmap.Dispose();
                MaskBox.Image.Dispose();
            }
            toolbars.Dispose();
            this.Close();
            this.Dispose();

        }





        private void MaskBox_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (FinalRect.Contains(e.Location) && drawover)
                {
                    Console.WriteLine("开始移动");
                    toolbars.Hide();
                    moving = true;
                    mouseoffset = new Point(e.X - FinalRect.X, e.Y - FinalRect.Y);
                    Cursor.Current = Cursors.SizeAll;
                }
                else if (!drawover)
                {
                    Console.WriteLine("开始绘图");
                    Drawwing = true;
                    StartPoint = e.Location;
                    Cursor.Current = Cursors.Cross;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
                this.Dispose();
            }
            
        }

        private void MaskBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drawwing && !drawover)
            {
                //窗体重绘
                MaskBox.Invalidate();
            }
            else if (moving && drawover)
            {
                FinalRect = new Rectangle(e.X - mouseoffset.X, e.Y - mouseoffset.Y, FinalRect.Width, FinalRect.Height);
                //窗体重绘
                MaskBox.Invalidate();

            }

        }

        private void MaskBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (Drawwing && !drawover)
            {
                Drawwing = false;
                drawover = true;
                //获取当前鼠标位置
                EndPoint = e.Location;
                FinalRect = utils.GetRectangle(StartPoint, EndPoint);
            }
            if (moving && drawover)
            {
                moving = false;
                EndPoint = e.Location;
                
            }
            toolbars.Location = new Point(FinalRect.Right - toolbars.Width, FinalRect.Bottom);
            MaskBox.Controls.Add(toolbars);
            toolbars.Show();
        }


        // 处理 Toolbars 的 FinishClicked 事件
        private void Toolbars_FinishClicked(object sender, EventArgs e)
        {
            OverDraw();
        }

        // 处理 Toolbars 的 CancelClicked 事件
        private void Toolbars_CancelClicked(object sender, EventArgs e)
        {

            if (MaskBox.Image != null || Orginbitmap != null)
            {
                Orginbitmap.Dispose();
                MaskBox.Image.Dispose();
            }
            this.Close();
            this.Dispose();
        }


 

        private void MaskBox_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Orange, 2);

            if (Drawwing &&  !drawover)
            {
                //获取当前鼠标位置
                Point CurrentPoint = Cursor.Position;
                Point formLocation = this.PointToClient(CurrentPoint);

                using (pen)
                {
                    //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    pen.DashPattern = new float[] { 10, 5 };
                    //pen.LineJoin = LineJoin.Round; // 可选：设置线条连接点的样式
                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Rectangle rect = utils.GetRectangle(StartPoint, formLocation);
                    e.Graphics.DrawRectangle(pen, rect);
                    // 定义文本字符串、字体、画笔和位置
                    string cinchutext = '(' + rect.Size.Width.ToString() + "px" + "," + rect.Size.Height.ToString() + "px" + ')';
                    string zuobiaotext = CurrentPoint.ToString().Replace('{', ' ').Replace('}', ' ');
                    Font textFont = new Font("simhei", 12);
                    // 绘制文本
                    e.Graphics.DrawString(cinchutext, textFont, new SolidBrush(Color.Black), new Point(StartPoint.X, StartPoint.Y - 30));

                }
            }
            else if (moving && drawover)
            {
                using (pen)
                {
                    pen.DashPattern = new float[] { 10, 5 };
                    e.Graphics.DrawRectangle(pen, FinalRect);
                }
            }
            else if (!drawover && FinalRect.IsEmpty)
            {
                using (pen)
                {
                    pen.DashPattern = new float[] { 10, 5 };
                    Rectangle screensize = Screen.PrimaryScreen.Bounds;
                    Rectangle rect = utils.GetRectangle(new Point(screensize.Left + 1, screensize.Top + 1), new Point(screensize.Right - 1, screensize.Bottom - 1));
                    e.Graphics.DrawRectangle(pen, rect);
                    // 定义文本字符串、字体、画笔和位置
                    string cinchutext = '(' + rect.Size.Width.ToString() + "px" + "," + rect.Size.Height.ToString() + "px" + ')';
                    Font textFont = new Font("simhei", 12);
                }
            }
            else
            {
                using (pen)
                {
                    pen.DashPattern = new float[] { 10, 5 };
                    e.Graphics.DrawRectangle(pen, FinalRect);
                }
            }
        }


    }


}
