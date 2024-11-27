using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class Setting : Form
    {

        #region
        //private readonly int AreahotKeyId = 100; // 热键ID，必须是唯一的
        //private readonly int AllhotKeyId = 101; // 热键ID，必须是唯一的
        //private readonly int CopyAutohotKeyId = 102; // 热键ID，必须是唯一的
        private string AreaKeyCombination = "";
        private string AllKeyCombination = "";
        private string CopyAutoCombination = "";
        private string TietuCombination = "";
        private string WaterMaskTextStr;
        #endregion


        //快捷键冲突状态
        #region
        public bool AreaStatus;
        public bool AllStatus;
        public bool CopAutoStatus;
        #endregion


        public string configpath;
        private ConfigFileHelper configFileHelper;

        private readonly Form1 parentform;

        private readonly Utils utils = new Utils();

        public Setting(Form1 parentform)
        {
            InitializeComponent();
            this.parentform = parentform;
            configFileHelper = parentform.configFileHelper;
            configpath = parentform.configpath;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            ReadConfig(configFileHelper, configpath);
            //WaterMaskText.Text = WaterMaskTextStr;
            utils.UnHook(parentform.Handle, 100);
            utils.UnHook(parentform.Handle, 101);
            utils.UnHook(parentform.Handle, 102);
            utils.UnHook(parentform.Handle, 103);

        }


        //读取配置文件
        private void ReadConfig(ConfigFileHelper configFileHelper, string configpath)
        {
            AreaKeyCombination = configFileHelper.ReadConfig("HotKeys", "AreaKeyCombination", "", 1024, configpath);
            AllKeyCombination = configFileHelper.ReadConfig("HotKeys", "AllKeyCombination", "", 1024, configpath);
            CopyAutoCombination = configFileHelper.ReadConfig("HotKeys", "CopyAutoCombination", "", 1024, configpath);
            TietuCombination = configFileHelper.ReadConfig("HotKeys", "TietuCombination", "", 1024, configpath);
            WaterMaskTextStr = configFileHelper.ReadConfig("WaterMask", "WaterMaskStr", "", 1024, configpath);
            AreaHotKeyBox.Text = AreaKeyCombination.ToString();
            AllHotKeyBox.Text = AllKeyCombination.ToString();
            AutoCopyHotKeyBox.Text = CopyAutoCombination.ToString();
            //Console.WriteLine("AreaStatusText1---->" + AreaStatusText1);
        }



        //保存配置
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (AreaKeyCombination == AllKeyCombination ||
                AreaKeyCombination == CopyAutoCombination ||
                CopyAutoCombination == AllKeyCombination
                )
            {
                MessageBox.Show("快捷键冲突");
                ResetButton_Click(null, null);
            }
            else
            {
                configFileHelper.WriteConfig("HotKeys", "AreaKeyCombination", AreaKeyCombination, configpath);
                configFileHelper.WriteConfig("HotKeys", "AllKeyCombination", AllKeyCombination, configpath);
                configFileHelper.WriteConfig("HotKeys", "CopyAutoCombination", CopyAutoCombination, configpath);
                configFileHelper.WriteConfig("HotKeys", "TietuCombination", TietuCombination, configpath);
                configFileHelper.WriteConfig("WaterMask", "WaterMaskStr", WaterMaskTextStr, configpath);
                parentform.ReadConfig(configFileHelper, configpath);
                MessageBox.Show("快捷键更新成功");
            }
        }

        //重置
        private void ResetButton_Click(object sender, EventArgs e)
        {
            parentform.CreateConfigInit(configFileHelper, configpath);
            //热更新
            ReadConfig(configFileHelper, configpath);

        }

        private void AreaHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            AreaHotKeyBox.Text = AreaKeyCombination = utils.UpdateHotKeyCom(e);
            //Console.WriteLine(AreaKeyCombination);
        }


        private void AreaHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void AutoCopyHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void AllHotKeyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void AllHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            AllHotKeyBox.Text = AllKeyCombination = utils.UpdateHotKeyCom(e);

        }

        private void AutoCopyHotKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            AutoCopyHotKeyBox.Text = CopyAutoCombination = utils.UpdateHotKeyCom(e);
        }

        private void WaterMaskText_TextChanged(object sender, EventArgs e)
        {
            //parentform.WaterMaskTextStr = WaterMaskTextStr = WaterMaskText.Text;
        }

        private void TietuBox_KeyDown(object sender, KeyEventArgs e)
        {
            TietuBox.Text = TietuCombination = utils.UpdateHotKeyCom(e);
        }

        private void TietuBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
