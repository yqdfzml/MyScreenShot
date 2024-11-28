using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScreenShot.MyEnum;

namespace ScreenShot
{
    public class Config
    {
        public string ConfigValue { get; set; }
        public string ConfigKey { get; set; }

        //上一次的保存文件路径
        public static string folderpath { get; set; }

    }
}
