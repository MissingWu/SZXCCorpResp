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

namespace 安装等待运行项目
{
    public partial class InstallWaitting : Form
    {

		delegate void Run();
		Run NotifyRun;

		delegate void RunText();
		RunText NotifyRunText;

		public InstallWaitting()
        {
            InitializeComponent();

			//this.BringToFront();
			backgroundWorker1.DoWork += this.BackgroundWorker1_DoWork;
			backgroundWorker1.WorkerSupportsCancellation = true;

			NotifyRun += new Run(NoRunf);
			NotifyRunText += new RunText(NoRunTextf);


		}

		/// <summary>
		/// 
		/// </summary>
		void NoRunf()
		{

			//Thread.Sleep(3000);
			Application.DoEvents();
			Process.Start("XICH环境.exe");

		}
		/// <summary>
		/// 
		/// </summary>
		int index = 0;
		/// <summary>
		/// 
		/// </summary>
		void NoRunTextf()
		{
			string str = "安装运行中";
			for (int i = 0; i <= index; i++)
			{
				str += "*";
				Application.DoEvents();
			}

			label1.Text = str;


			index++;
			if (index >= 20) index = 0;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{

			

			do
			{
				this.BeginInvoke(NotifyRunText);
				Thread.Sleep(10);
			}
			while (!backgroundWorker1.CancellationPending);
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InstallWaitting_Load(object sender, EventArgs e)
		{

			this.BeginInvoke(NotifyRun);
			Application.DoEvents();
			backgroundWorker1.RunWorkerAsync();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InstallWaitting_Shown(object sender, EventArgs e)
		{
			

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InstallWaitting_FormClosed(object sender, FormClosedEventArgs e)
		{
			backgroundWorker1.CancelAsync();

		}
	}
}
