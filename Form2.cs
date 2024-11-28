using MyScreenShot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace ScreenShot
{
    public partial class Form2 : Form
    {
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
            InitializeComponent();
            ShotImage = ImageBox.Image = image;
            Size = OrginalSize = image.Size;
            //截图完成后自动保存图片
            utils.SaveImage(ShotImage, true);
            Console.WriteLine(Config.folderpath);
            ConfigFileHelper.WritePrivateProfileString("LastSavepath", "LastSave", Config.folderpath, Application.StartupPath + "/config.ini");
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            ColorInvertStatus = ColorInvertToolStripMenuItem.Checked;
            ImageBox.MouseWheel += new MouseEventHandler(MY_MouseWheel);
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
                utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize, ImageBox);
            }

        }


        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Moving = true;
                StartPoint = e.Location;
            }

        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Moving)
            {
                EndPoint = e.Location;

                this.Location = new Point(this.Location.X + e.X - StartPoint.X, this.Location.Y + e.Y - StartPoint.Y);
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
            if (ImageBox.Image != null)
            {
                ImageBox.Image.Dispose();
                ImageBox.Image = null;
            }
            if (ColorInvertBItmap != null)
            {
                ColorInvertBItmap.Dispose();
            }
            this.Close();
            this.Dispose();
        }

        private void ScaleUpImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.Resizeform(ScaleRatio += 0.1, this, ScaleText, OrginalSize, ImageBox);
        }

        private void ScaleLowImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.Resizeform(ScaleRatio -= 0.1, this, ScaleText, OrginalSize, ImageBox);
        }

        private void ThumImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.3;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize, ImageBox);
        }

        private void DisImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        internal void setImage(Image finalImage)
        {
            Size = finalImage.Size;
            ImageBox.Image = finalImage;
        }

        private void HandleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void Scale30_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.3333;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize, ImageBox);
        }

        private void Scale100_Click(object sender, EventArgs e)
        {
            ScaleRatio = 1.0;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize, ImageBox);
        }

        private void Scale80_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.8;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize, ImageBox);
        }

        private void Scale50_Click(object sender, EventArgs e)
        {
            ScaleRatio = 0.5;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize, ImageBox);
        }

        private void Scale200_Click(object sender, EventArgs e)
        {
            ScaleRatio = 2.0;
            utils.Resizeform(ScaleRatio, this, ScaleText, OrginalSize, ImageBox);
        }


        private void RotateRight_Click(object sender, EventArgs e)
        {
            utils.RotateImage(ImageBox, ShotImage, 2);

        }

        private void RotateLeft_Click(object sender, EventArgs e)
        {
            utils.RotateImage(ImageBox, ShotImage, 1);
        }

        private void RotateHorizon_Click(object sender, EventArgs e)
        {
            utils.RotateImage(ImageBox, ShotImage, 3);
        }

        private void RotateVertical_Click(object sender, EventArgs e)
        {
            utils.RotateImage(ImageBox, ShotImage, 4);
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
                    ImageBox.Image = ColorInvertBItmap;
                    SaveColorInvertToolStripMenuItem.Enabled = ColorInvertStatus;
                }
                
            }
            else
            {
                ImageBox.Image = ShotImage;
            }
        }
    }
}



