using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyScreenShot
{
    public class LowMouseHotKey
    {
        private PixelDis PixelDis;

        private const int WH_MOUSE_LL = 14; // 低级鼠标钩子
        private static IntPtr hookID = IntPtr.Zero;
        private static MouseHook mouseHookProc;

        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowsHookEx(int idHook, MouseHook lpfn, IntPtr hMod, int dwThreadId);

        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int UnhookWindowsHookEx(IntPtr idHook);

        //传递钩子
        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string name);

        private delegate int MouseHook(int nCode, IntPtr wParam, IntPtr lParam);


        //回调函数
        private static IntPtr LowLevelMouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //PixelDis.

            // 调用下一个钩子
            return (IntPtr)CallNextHookEx(hookID, nCode, wParam, lParam);
        }


    }
}
