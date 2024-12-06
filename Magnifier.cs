using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class Magnifier : Form
    {


        public Magnifier()
        {

            InitializeComponent();
        }
        // 初始化Pen对象

        private void Magnifier_Load(object sender, EventArgs e)
        {
            //pictureBox1.MouseWheel += new MouseEventHandler(MY_MouseWheel);
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //// 绘制横线
            //e.Graphics.DrawLine(_pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            //// 绘制竖线
            //e.Graphics.DrawLine(_pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
            //放大倍数
            int n = 2;
            Bitmap bitmap = new Bitmap(pictureBox1.Width / n, pictureBox1.Height / n);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // 绘制从当前鼠标位置减去图片一半的屏幕大小到bitmap中
                g.CopyFromScreen(new Point(Cursor.Position.X - bitmap.Width/n, Cursor.Position.Y - bitmap.Height), new Point(0, 0), new Size(bitmap.Width, bitmap.Height));
            }
            pictureBox1.Image = bitmap;

        }


        //private void MY_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (e.Delta > 0)
        //    {
        //        this.Size = new Size(Size.Width - 10, Size.Height - 10);

        //        Console.WriteLine("缩小");
        //    }
        //    else
        //    {
        //        this.Size = new Size(Size.Width + 10, Size.Height + 10);
        //        Console.WriteLine("放大");
        //    }
        //}
    }
}
