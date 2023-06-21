using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Common;
using CCWin;

namespace SZXCVision
{
    public partial class VertifiedForm : Skin_Mac
    {
        public VertifiedForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double times=UTool.timeout;

            var helper = new EncryptionHelper(EncryptionKeyEnum.KeyA);
            string  dt =System.DateTime.Now.ToString();

            string timekey = helper.EncryptString(dt);
            string md5key1 = helper.DecryptString(timekey);
            label3.Text ="登录时间："+ md5key1;
            label2.Text = "剩余时间：" + times.ToString("f2") + "天";

        }
    }
}
