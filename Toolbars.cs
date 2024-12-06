using System;
using System.Windows.Forms;

namespace MyScreenShot
{
    public partial class Toolbars : UserControl
    {
        // 定义自定义事件
        public event EventHandler FinishClicked;
        public event EventHandler CancelClicked;

        private string str1,str2;

        private bool recording = false;

        public Toolbars()
        {
            //str2 = control2;
            //str1 = control1;

            InitializeComponent();
            // 订阅按钮的 Click 事件
            //this.finishbutton.Click += new EventHandler(this.finishbutton_Click);
            //this.cancelbutton.Click += new EventHandler(this.cancelbutton_Click);
            //this.recordbutton.Click += new EventHandler(this.recordbutton_Click);
        }

        private void finishbutton_Click(object sender, EventArgs e)
        {
            OnFinishClicked(EventArgs.Empty);
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            OnCancelClicked(EventArgs.Empty);
        }
       

        // 触发 FinishClicked 事件的方法
        protected virtual void OnFinishClicked(EventArgs e)
        {
            //recording = !recording;
            //if(recording)
            //{
            //    finishbutton.Text = "停止";

            //}
            //else
            //{
            //    finishbutton.Text = "完成";
            //}
            FinishClicked?.Invoke(this, e);
        }

        // 触发 CancelClicked 事件的方法
        protected virtual void OnCancelClicked(EventArgs e)
        {
            CancelClicked?.Invoke(this, e);
        }

        private void Toolbars_Load(object sender, EventArgs e)
        {
            //finishbutton.Text = str1;
            //cancelbutton.Text = str2;
        }
    }
}
