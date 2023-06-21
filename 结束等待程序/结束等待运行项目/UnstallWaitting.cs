using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 结束等待运行项目
{
    public partial class UnstallWaitting : Form
    {
		/// <summary>
		/// 
		/// </summary>
        public UnstallWaitting()
        {
            InitializeComponent();

			this.BringToFront();

        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{

			//***********清除等待运行窗体**************//


			System.Diagnostics.Process[] myProgress;
			myProgress = System.Diagnostics.Process.GetProcesses(); //获取当前启动的所有进程
			foreach (System.Diagnostics.Process p in myProgress) //关闭当前启动的Excel进程
			{
				if (p.ProcessName == "安装等待运行项目") //通过进程名来寻找
				{
					p.Kill();
					return;
				}
				Application.DoEvents();

			}


		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UnstallWaitting_Shown(object sender, EventArgs e)
		{

			// 			Thread.Sleep(3000);
			// 			this.Close();
			for (int i = 0; i < 20; i++)
			{
				Application.DoEvents();Thread.Sleep(500);
			}
			this.Close();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
