using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ScreenShot.MyEnum;

namespace ScreenShot
{
    public class ConfigFileHelper
    {

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public static extern long WritePrivateProfileString(string section, string key, string value, string lpFileName);


        [DllImport("kernel32", CharSet = CharSet.Auto)]
        public extern static long GetPrivateProfileString(string section, string key, string strDefault, StringBuilder retVal, int size, string FilePath);

        public string ReadConfig(string section, string key, string strDefault, int size, string FilePath)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            GetPrivateProfileString(section, key, strDefault, stringBuilder, size, FilePath);
            return stringBuilder.ToString();
        }



        public long WriteConfig(string section, string key, string val, string path)
        {
            return WritePrivateProfileString(section, key, val, path);
        }


        //写入热键配置文件
        public void WriteAllConfgig(string configpath)
        {
            WriteConfig("HotKeys", "NewKeyCombination", "F1", configpath);
            WriteConfig("HotKeys", "AllKeyCombination", "F3", configpath);
            WriteConfig("HotKeys", "CopyAutoCombination", "Control+F3", configpath);
            WriteConfig("HotKeys", "TietuCombination", "F4", configpath);
        }

        //[LastSavepath]
        //LastSave=E:\MyScreenShot\bin\Debug\2024-11-28\2024-11-28_12-55-29-907.png

        //读取热键配置文件
        public List<Config> ReadAllConfgig(string path)
        {
            List<Config> configs = new List<Config>();

            try
            {
                string[] lines =  File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    // 跳过注释行和空行
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";") || line.StartsWith("#"))
                    {
                        continue;
                    }
                    // 解析键值对
                    string[] keyValue = line.Split(new[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);

                    if (keyValue.Length == 2)
                    {
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();
                        configs.Add(new Config { ConfigKey = key, ConfigValue = value });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading config file: " + ex.Message);
            }


            return configs;
        }

    }
}
