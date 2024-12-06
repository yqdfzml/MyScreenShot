using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class Setting : Form
    {

        //快捷键冲突状态
        #region
        public bool AreaStatus;
        public bool AllStatus;
        public bool CopAutoStatus;
        #endregion

        //快捷键列表
        //private List<string> hotkeylist = new List<string>();
        private List<MyEnum.HotKeystruct1> hotkeylist = new List<MyEnum.HotKeystruct1>();


        List<MyEnum.HotKeystruct> hotKeystructs;

        public string NewKeyCombination;
        public string AllKeyCombination;
        public string CopyAutoCombination;
        public string TietuCombination;
        public string BeginReCombination;
        public string EndReCombination;

        //private List<string> hotkeycombinations = new List<string>
        //{
        //    NewKeyCombination,
        //    AllKeyCombination,
        //    CopyAutoCombination,
        //    TietuCombination
        //};




        public string configpath;
        private ConfigFileHelper configFileHelper;

        private readonly Form1 parentform;

        private readonly Utils utils = new Utils();

        private readonly HotKey hotKey = new HotKey();

        //是否进行热键修改
        //private bool ho

        public Setting(Form1 parentform)
        {
            InitializeComponent();
            this.parentform = parentform;

        }

        private void Setting_Load(object sender, EventArgs e)
        {
            configpath = parentform.configpath;
            configFileHelper = parentform.configFileHelper;
            ReadConfig();
            HotKey.UnRegisterAllHotkeys(parentform.Handle);
           
        }


        //读取配置文件
        private void ReadConfig()
        {
            hotKeystructs = hotKey.ReadAllHotkeys(parentform.configpath, Handle);

            hotKeystructs.ForEach(hotKeystruct =>
            {
                Console.WriteLine("setting"+hotKeystruct.functionname + "---->" + hotKeystruct.keycombina);
                
                switch (hotKeystruct.functionname)
                {
                    case "NewKeyCombination":
                        NewKeyCombination =  NewHotKeyBox.Text = hotKeystruct.keycombina;
                        break;
                    case "AllKeyCombination":
                        AllKeyCombination =  AllHotKeyBox.Text = hotKeystruct.keycombina;
                        break;
                    case "CopyAutoCombination":
                        CopyAutoCombination =  CopyAutoHotKeyBox.Text = hotKeystruct.keycombina;
                        break;
                    case "TietuCombination":
                        TietuCombination =  TietuHotKeyBox.Text = hotKeystruct.keycombina;
                        break;
                    case "BeginReCombination":
                        BeginReCombination = BeginReHotKeyBox.Text = hotKeystruct.keycombina;
                        break;
                    case "EndReCombination":
                        EndReCombination = EndReHotKeyBox.Text = hotKeystruct.keycombina;
                        break;

                }

            });
        }



        //保存配置
        private void SaveButton_Click(object sender, EventArgs e)
        {
            hotkeylist.Add(new MyEnum.HotKeystruct1
            {
                functionname = "NewKeyCombination",
                keycombina = NewKeyCombination
            });
            hotkeylist.Add(new MyEnum.HotKeystruct1
            {
                functionname = "AllKeyCombination",
                keycombina = AllKeyCombination
            });
            hotkeylist.Add(new MyEnum.HotKeystruct1
            {
                functionname = "CopyAutoCombination",
                keycombina = CopyAutoCombination
            });
            hotkeylist.Add(new MyEnum.HotKeystruct1
            {
                functionname = "TietuCombination",
                keycombina = TietuCombination
            });
            hotkeylist.Add(new MyEnum.HotKeystruct1
            {
                functionname = "BeginReCombination",
                keycombina = BeginReCombination
            });
            hotkeylist.Add(new MyEnum.HotKeystruct1
            {
                functionname = "EndReCombination",
                keycombina = EndReCombination
            });
            configFileHelper.UpdateAllConfig(hotkeylist, configpath);
            parentform.ReadConfig();

        }

        //重置
        private void ResetButton_Click(object sender, EventArgs e)
        {
            parentform.CreateConfigInit(parentform.configFileHelper, parentform.configpath);
            ReadConfig();

        }

 

        //新建截图
        private void NewHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            NewKeyCombination = NewHotKeyBox.Text = utils.UpdateHotKeyCom(e);

        }

        private void NewHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            e.Handled = true;
        }

        //截图复制
        private void CopyAutoHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            CopyAutoCombination = CopyAutoHotKeyBox.Text = utils.UpdateHotKeyCom(e);

        }
        private void CopyAutoHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled  =true;
        }

        //全屏截图
        private void AllHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            AllKeyCombination = AllHotKeyBox.Text  = utils.UpdateHotKeyCom(e);


        }
        private void AllHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //贴图
        private void TietuBox_KeyDown(object sender, KeyEventArgs e)
        {
            TietuCombination = TietuHotKeyBox.Text =  utils.UpdateHotKeyCom(e);

        }

        private void TietuBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BeginReHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void EndReHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BeginReHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            BeginReCombination = BeginReHotKeyBox.Text = utils.UpdateHotKeyCom(e);
        }

        private void EndReHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            EndReCombination = EndReHotKeyBox.Text = utils.UpdateHotKeyCom(e);
        }
    }
}
