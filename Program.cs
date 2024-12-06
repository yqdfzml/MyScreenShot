using ScreenShot;
using System;
using System.Threading;
using System.Windows.Forms;

namespace winForm
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isOpen;

            using (Mutex mutex = new Mutex(true, Application.ProductName, out isOpen))
            {
                if (!isOpen)
                {
                    MessageBox.Show("程序已经在运行中");
                    return;

                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }


        }
    }
}
