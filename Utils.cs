using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ScreenShot.MyEnum;


namespace ScreenShot
{
    public class Utils
    {
       

        private HotKey HotKey;



        //配置文件
        //#region
        //public string configpath = Application.StartupPath + "/config.ini";
        //public ConfigFileHelper configFileHelper = new ConfigFileHelper();
        //#endregion

        //复制图片函数
        public void CopyImage(System.Drawing.Image image)
        {
            Bitmap copymap = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(copymap))
            {
                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
                Clipboard.SetImage(copymap);
                g.Dispose();
            }
        }

        //文件名
        public string GetFileName()
        {
            DateTime currentTime = DateTime.Now;
            return currentTime.ToString("yyyy-MM-dd_HH-mm-ss-fff");

            //string Formatter = currentTime.ToString("yyyy-MM-dd_HH-mm-ss");
            //return Formatter;
        }


        //根据时间新建文件夹
        public string CreateFile(string FileName)
        {
            string folderPath = null;
            string datePattern = @"(\d{4})-(\d{2})-(\d{2})";
            Match match = Regex.Match(FileName.Trim(), datePattern);
            if (match.Success)
            {
                //string NewFileName = match.Value;
                //Console.WriteLine("--------->" + NewFileName);
                string currentDirectory = Directory.GetCurrentDirectory();
                // 构建文件夹的完整路径  
                folderPath = Path.Combine(currentDirectory, match.Value);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            return folderPath;
        }


        //保存函数
        public void SaveImage(System.Drawing.Image image, bool AutoSave)
        {
            if (!AutoSave)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG 图像|*.png|JPEG 图像|*.jpg|BMP 图像|*.bmp|GIF 图像|*.gif";
                    saveFileDialog.FileName = GetFileName();
                    saveFileDialog.InitialDirectory = CreateFile(saveFileDialog.FileName);
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string FileName = saveFileDialog.FileName;
                        string Extenison = Path.GetExtension(FileName).ToLower();
                        switch (Extenison)
                        {
                            case ".png":
                                image.Save(FileName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case ".jpg":
                                image.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case ".bmp":
                                image.Save(FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case "gif":
                                image.Save(FileName, System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            default:
                                image.Save(FileName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("自动保存");
                string filename = GetFileName() + ".png";
                Config.folderpath = Path.Combine(CreateFile(filename), filename);
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                Console.WriteLine("------->" + Config.folderpath);
                image.Save(Config.folderpath, format);
            }
        }

        //截取全屏图片
        public async Task<Bitmap> ScreenBack()
        {
            //form.Visible = false;
            //异步截图
            return await Task.Run(() =>
            {
                Rectangle screensize = Screen.PrimaryScreen.Bounds;
                Bitmap bitmap = new Bitmap(screensize.Width, screensize.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(0, 0, 0, 0, screensize.Size);
                }
                return bitmap;
            });
        }

        //缩略图
        public void LowImageShow(double ratio, Form form)
        {
            form.Width = (int)(form.Width * ratio);
            form.Height = (int)(form.Height * ratio);
        }



        //大小缩放
        public void Resizeform(double ratio, Form form, Label label, Size size, PictureBox pictureBox)
        {
            label.Visible = true;
            label.Text = "缩放大小:" + (ratio * 100).ToString() + "%";
            pictureBox.Width = form.Width = (int)(size.Width * ratio);
            pictureBox.Height = form.Height = (int)(size.Height * ratio);
        }


        //旋转
        public void RotateImage(PictureBox pictureBox, Image image, int RotateType)
        {
            switch (RotateType)
            {
                case 1:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case 2:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 3:
                    image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    break;
                case 4:
                    image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
            }
            pictureBox.Image = image;

        }


        public Rectangle GetRectangle(Point startpoint, Point endpoint)
        {
            return new Rectangle(
                Math.Min(startpoint.X, endpoint.X),
                Math.Min(startpoint.Y, endpoint.Y),
                Math.Abs(endpoint.X - startpoint.X),
                Math.Abs(endpoint.Y - startpoint.Y)
                );
        }



        //获取最终截图
        public Bitmap GetFinalImage(Rectangle rect)
        {
            if (!rect.IsEmpty)
            {
                Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size);
                }
                return bitmap;
            }
            else
            {
                throw new InvalidOperationException("The specified rectangle is empty.");
            }
        }


        //注册热键
        //public bool ReHook(IntPtr handle, int HotkeyId, int Modifiers, int vk)
        //{
            //return HotKey.RegisterHotKey(handle, HotkeyId, Modifiers, vk);

        //}
        //卸载热键
        public bool UnHook(IntPtr handle, int HotkeyId)
        {
            return HotKey.UnregisterHotKey(handle, HotkeyId);

        }


        //更新注册快捷键函数
        public bool UpDateHotKey(string keys, int KeyId, IntPtr handle)
        {
            return true;
            ////Console.WriteLine("keys---->" + keys);

            //List<string> TempkeyList = keys.Split('+').ToList();

            //int modifiers = 0;
            //int vk = 0;

            ////Console.WriteLine("keys0---->" + TempkeyList[0] + "keys1---->" + TempkeyList[1]);

            //foreach (string key in TempkeyList)
            //{
            //    switch (key.ToUpper())
            //    {
            //        case "CTRL":
            //            modifiers |= MOD_CONTROL;
            //            break;
            //        case "ALT":
            //            modifiers |= MOD_ALT;
            //            break;
            //        case "SHIFT":
            //            modifiers |= MOD_SHIFT;
            //            break;
            //        case "WIN":
            //            modifiers |= MOD_WIN;
            //            break;
            //        case "F1":
            //            vk |= VK_F1;
            //            break;
            //        case "F2":
            //            vk |= VK_F2;
            //            break;
            //        case "F3":
            //            vk |= VK_F3;
            //            break;
            //        case "F4":
            //            vk |= VK_F4;
            //            break;
            //        case "F5":
            //            vk |= VK_F5;
            //            break;
            //        case "F6":
            //            vk |= VK_F6;
            //            break;
            //        case "F7":
            //            vk |= VK_F7;
            //            break;
            //        case "F8":
            //            vk |= VK_F8;
            //            break;
            //        case "F9":
            //            vk |= VK_F9;
            //            break;
            //        case "F10":
            //            vk |= VK_F10;
            //            break;
            //        case "F11":
            //            vk |= VK_F11;
            //            break;
            //        case "F12":
            //            vk |= VK_F12;
            //            break;
            //        case "shift":
            //            vk |= VK_SHIFT;
            //            break;
            //        default:
            //            if (char.IsLetter(key[0]) && char.IsUpper(key[0]))
            //            {
            //                vk = (key[0] - 'A' + (int)Keys.A);
            //            }
            //            break;
            //    }
            //}

            //if (vk == 0)
            //{
            //    // 如果没有指定具体的键（只有修饰键），则无法注册热键  
            //    MessageBox.Show("热键不能只包含功能键");
            //    return false;
            //}
            //if (!HotKey.RegisterHotKey(handle, KeyId, modifiers, vk))
            //{
            //    MessageBox.Show("热键注册失败");
            //    return false;
            //}
            //else
            //{
            //    MessageBox.Show("热键注册成功");
            //}

            //return true;
        }

        //获取尺寸
        public string GetSize(Size size)
        {
            string SizeText = size.Width.ToString() + " x " + size.Height.ToString();

            return SizeText;

        }


        //在文件夹中查看
        public void LookFile()
        {

            //Console.WriteLine(Config.folderpath);

            Process.Start("explorer.exe", "/select, " + Config.folderpath);

        }

        //预览查看图像
        public void ViewImage()
        {
            Console.WriteLine(Config.folderpath);

            Process.Start(new ProcessStartInfo { FileName = "explorer.exe", Arguments = Config.folderpath});

        }


        //像素化



        //颜色反转

        public Bitmap ColorInvert(Image image)
        {
            Bitmap originalBitmap = (Bitmap)image;

            Bitmap invertedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    Color originalColor = originalBitmap.GetPixel(x, y);
                    Color invertedColor = Color.FromArgb((int)((255 - originalColor.R)), (int)((255 - originalColor.G)), (int)((255 - originalColor.B)));
                    invertedBitmap.SetPixel(x, y, invertedColor);
                }
            }
            return invertedBitmap;
        }



        //快捷键更新
        public string UpdateHotKeyCom(KeyEventArgs e)
        {
            string KeyCombination = "";
            if (e.Alt)
            {
                KeyCombination += "Alt+";
            }
            if (e.Control)
            {
                KeyCombination += "Control+";
            }
            if (e.Shift)
            {
                KeyCombination += "Shift+";
            }
            else
            {
                KeyCombination += e.KeyCode.ToString();
            }

            return KeyCombination;

        }


        static bool IsModifierKey(Keys key)
        {
            // Check if the key is a modifier key
            return key == Keys.Control ||
                   key == Keys.Shift ||
                   key == Keys.Alt ||
                   key == Keys.LControlKey ||
                   key == Keys.RControlKey ||
                   key == Keys.LShiftKey ||
                   key == Keys.RShiftKey ||
                   key == Keys.LMenu ||
                   key == Keys.RMenu ||
                   key == Keys.LWin||
                   key == Keys.RWin
                   ;
        }

        //热键配置
        public HotKeystruct StringToKey(string configstring)
        {
            string[] keys = configstring.Split('+');
            HotKeystruct result = new HotKeystruct {
                modifiers = (int)KeysModifiers.MOD_NONE,
                keys = Keys.None
            };
            foreach (string key in keys)
            {
                string trimkey = key.Trim();
                if (Enum.TryParse(trimkey, true, out Keys parsedKey))
                {
                    if (IsModifierKey(parsedKey))
                    {
                        switch (parsedKey)
                        {
                            case Keys.Control:
                                result.modifiers = (int)KeysModifiers.MOD_CONTROL;
                                break;
                            case Keys.Alt:
                                result.modifiers = (int)KeysModifiers.MOD_ALT;
                                break;
                            case Keys.Shift:
                                result.modifiers = (int)KeysModifiers.MOD_SHIFT;
                                break;
   
                        }
                        //Console.WriteLine("-->>>"+result.modifiers);
                    }
                    else
                    {
                        result.keys = parsedKey;
                    }
                }

            }
            return result;
        }

        


    }
}
