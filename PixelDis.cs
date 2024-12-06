using ScreenShot;
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
using static ScreenShot.MyEnum;

namespace MyScreenShot
{
    public partial class PixelDis : Form
    {

        public Picker Picker = new Picker();
        private Utils utils = new Utils();

        private string RGBText;
        private string hexText;

        private bool dispixel = false;
        private string copypixeltext;



        public PixelDis()
        {
            InitializeComponent();
        }

        private void updatetext()
        {

        }

        private void PixelDis_Load(object sender, EventArgs e)
        {
            HotKey.RegisterHotKey(Handle, 200, 0x0002, Keys.C);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(Cursor.Position.X+10 , Cursor.Position.Y+10);
            Point p;
            Picker.GetCursorPos(out p);
            int pixel = Picker.GetPixelColor(p);
            int r = (pixel & 0xFF);//转换R
            int g = (pixel & 0xFF00) / 256;//转换G
            int b = (pixel & 0xFF0000) / 65536;//转换B
            hexText = ('#' + r.ToString("x").PadLeft(2, '0') + g.ToString("x").PadLeft(2, '0') + b.ToString("x").PadLeft(2, '0')).ToUpper();//输出16进制颜色
            RGBText = r.ToString() + ',' + g.ToString() + ',' + b.ToString();//输出RGB
            pixelabel.Text = RGBText;
        }


        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 200:
                        PixelDis_KeyDown(null, null);
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void PixelDis_KeyDown(object sender, KeyEventArgs e)
        {
            //if ( e.Control && e.KeyCode == Keys.C)
            //{
                Console.WriteLine("我按了Control + C"+"颜色是"+ pixelabel.Text);
                Clipboard.SetDataObject(pixelabel.Text);
            //}
        }
    }
}
