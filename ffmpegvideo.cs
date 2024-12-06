using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using ScreenShot;


namespace MyScreenShot
{
    public class ffmpegvideo
    {
        //private readonly string _ffmpegPath;

        #region 模拟控制台信号需要使用的API

        [DllImport("kernel32.dll")]
        static extern bool GenerateConsoleCtrlEvent(int dwCtrlEvent, int dwProcessGroupId);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(IntPtr handlerRoutine, bool add);

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        #endregion

        private static string savepath;

        //ffmpeg进程
        static Process ffmpegProcess = new Process();
        
        private static string _ffmpegPath = Path.Combine(Directory.GetCurrentDirectory(), "ffmpeg\\ffmpeg.exe");

        private static int isgif = 0;


        private static Utils utils = new Utils();
        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="outFilePath">录屏文件保存路径</param>
        public static void Start(string outFilePath,Rectangle rectangle,int ReGif)
        {
            isgif = ReGif;
            savepath = outFilePath;
            Console.WriteLine("--->" + isgif);
            string arguments = $"-f gdigrab -framerate  15 -r 15 -video_size {(rectangle.Width%2 ==0? rectangle.Width:rectangle.Width+1)}x{(rectangle.Height%2 == 0?rectangle.Height:rectangle.Height+1)} -offset_x {rectangle.Left} -offset_y {rectangle.Top} -i desktop -pix_fmt yuv420p {outFilePath}";
            Console.WriteLine(arguments);
            ProcessStartInfo startInfo = new ProcessStartInfo(_ffmpegPath);
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;//不使用操作系统外壳程序启动
            startInfo.RedirectStandardError = true;//重定向标准错误流
            startInfo.CreateNoWindow = true;//默认不显示窗口
            startInfo.RedirectStandardInput = true;//启用模拟该进程控制台输入的开关
            ffmpegProcess.ErrorDataReceived += new DataReceivedEventHandler(Output);//把FFmpeg的输出写到StandardError流中
            ffmpegProcess.StartInfo = startInfo;
            ffmpegProcess.Start();//启动
            ffmpegProcess.BeginErrorReadLine();//开始异步读取输出
        }

        /// <summary>
        /// 停止录制
        /// </summary>
        public static void Stop()
        {
            ffmpegProcess.StandardInput.WriteLine("q");//在这个进程的控制台中模拟输入q,用于停止录制
            ffmpegProcess.Close();
            ffmpegProcess.Dispose();
            if (isgif == 1)
            {
                ConvertToGif(savepath);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 将录制的视频转换为 GIF
        /// </summary>
        /// <param name="inputPath">输入的视频文件路径</param>
        private static void ConvertToGif(string inputPath)
        {

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"gif\\{utils.GetFileName() + ".gif"}");

            //Console.WriteLine(outputPath);
    
            //Path.Combine(Directory.GetCurrentDirectory(), $"video\\{filename}.mp4").ToString()

            //ffmpeg - i 2024 - 12 - 05_13 - 35 - 40 - 180.mp4 - vf "fps=10,scale=320:-1:flags=lanczos" output.gif

            string arguments = $"-i {inputPath} -vf \"fps=10,scale=320:-1:flags=lanczos\" {outputPath}";

            ProcessStartInfo startInfo = new ProcessStartInfo(_ffmpegPath)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process convertProcess = Process.Start(startInfo))
            {
                convertProcess.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data); // 输出错误到控制台
                convertProcess.WaitForExit();
            }

            Console.WriteLine($"Conversion to GIF completed: {outputPath}");

            File.Delete(inputPath);

        }

        /// <summary>
        /// 控制台输出信息
        /// </summary>
        private static void Output(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data.ToString());
            }

        }

    }
}
