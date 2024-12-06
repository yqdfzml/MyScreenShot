using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot
{
    public class MyEnum
    {
        [Flags()]
        public enum KeysModifiers
        {
            MOD_NONE = 0x0000,  // 通常添加一个无值成员表示没有修饰符
            MOD_ALT = 0x0001,
            MOD_CONTROL = 0x0002,
            MOD_SHIFT = 0x0004,
            MOD_WIN = 0x0008
        }


        //热键结构体
        public struct HotKeystruct {
            public int modifiers;
            public Keys keys;
            public bool regeditres;
            public string functionname;
            public string keycombina;
        }

        public struct HotKeystruct1
        {
            public string functionname;
            public string keycombina;
        }

        //截图类型
        [Flags()]
        public enum ShotType
        {
            NewShot = 1,
            CopyShot = 3
        }



    }
}
