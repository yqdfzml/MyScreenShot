using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyScreenShot
{
    public class Picker
    {

        // 导入必要的Windows API函数
        [DllImport("User32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hDCDest, int x, int y, int nWidth, int nHeight, IntPtr hDCSrc, int xSrc, int ySrc, int dwRop);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("user32.dll")]
        public static extern IntPtr GetCursorPos(out Point lpPoint);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]//取指定点颜色
        public static extern int GetPixel(IntPtr hdc, Point p);

        public int GetPixelColor(Point point)
        {
            IntPtr hdcScreen = GetDC(IntPtr.Zero);
            int color = GetPixel(hdcScreen, point);
            return color;
            
        }


    }
}
