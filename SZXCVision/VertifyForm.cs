using CCWin;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZXCVision
{
    public partial class VertifyForm : Skin_Mac
    {
        public VertifyForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private string encryptComputer = string.Empty;

     /// <summary>
     /// 
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {

            string computer = ComputerInfo.GetComputerInfo();
            textBox1.Text = computer;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (RegistFileHelper.ExistRegistInfofile() == true)
            {
                string key = textBox2.Text.Trim();
                if (UTool.CheckRegist(key) == true)
                {

                    MessageBox.Show("注册成功！");

                    VertifiedForm f = new VertifiedForm();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }
            }
            else
            {
                MessageBox.Show("缺少系统文件，请联系管理员");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("已复制到剪切板");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
