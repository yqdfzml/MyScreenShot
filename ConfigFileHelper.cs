using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

    }
}
