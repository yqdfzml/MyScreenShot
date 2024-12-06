using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Policy;
using MyScreenShot.Properties;
using System.Runtime.Remoting.Contexts;
using static ScreenShot.MyEnum;





namespace ScreenShot
{
    public class HotKey
    {
        public List<string> failhotkeys = new List<string>();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, Keys vk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private ConfigFileHelper configFileHelper = new ConfigFileHelper();

        private Utils utils = new Utils();

        //private string configpath = Application.StartupPath + "/config.ini";
        private List<Config> configs = new List<Config>();

        // 用于存储所有热键结构体的列表
        private List<HotKeystruct> hotKeysList = new List<HotKeystruct>();

        //注册全部热键
        public  List<HotKeystruct> RegisterAllHotkeys(string configpath, IntPtr handle)
        {
            configFileHelper.ReadAllConfgig(configpath);
            configs = configFileHelper.ReadAllConfgig(configpath);
            int index = 100;
            foreach (Config config in configs)
            {
                if (config.ConfigKey != "LastSave" && config.ConfigKey != "First")
                {
                    HotKeystruct hotKeystruct = utils.StringToKey(config.ConfigValue);
                    hotKeystruct.functionname = config.ConfigKey;
                    hotKeystruct.keycombina = config.ConfigValue;
                    Console.WriteLine(hotKeystruct.modifiers +"--56--"+ hotKeystruct.keys);
                    Console.WriteLine(index);
                    bool res = RegisterHotKey(handle, index, hotKeystruct.modifiers, hotKeystruct.keys);
                    hotKeystruct.regeditres = res;
                    if (!res)
                    {
                        failhotkeys.Add(hotKeystruct.functionname);
                    }
                    hotKeysList.Add(hotKeystruct);
                    index++;
                }
                
            }
            return hotKeysList;
        }


        //读取全部热键

        public List<HotKeystruct> ReadAllHotkeys(string configpath, IntPtr handle)
        {
            configFileHelper.ReadAllConfgig(configpath);
            configs = configFileHelper.ReadAllConfgig(configpath);
            foreach (Config config in configs)
            {
                if (config.ConfigKey != "LastSave" && config.ConfigKey != "First")
                {
                    HotKeystruct hotKeystruct = utils.StringToKey(config.ConfigValue);
                    hotKeystruct.functionname = config.ConfigKey;
                    hotKeystruct.keycombina = config.ConfigValue;
                    hotKeysList.Add(hotKeystruct);
                }
            }
            return hotKeysList;
        }





        //卸载全部热键
        public static void UnRegisterAllHotkeys(IntPtr handle)
        {
            for(int i =100;i<105;i++)
            {
                UnregisterHotKey(handle, i);
                //Console.WriteLine(i + "----unre-->" + UnregisterHotKey(handle, i));
            }

        }

        //更新热键
        public void Updatehotkey(List<string> strings, IntPtr handle)
        {
            int index = 100;
            strings.ForEach(s =>
            {
                Console.WriteLine(s);
                HotKeystruct hotKeystruct = utils.StringToKey(s);
                bool res = RegisterHotKey(handle, index, hotKeystruct.modifiers, hotKeystruct.keys);
                Console.WriteLine(index + "----re-->" + res);
                index++;
            });

        }
        


    }
    
}
