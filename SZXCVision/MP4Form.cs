using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace SZXCVision
{
	public partial class MP4Form : Skin_Mac
	{

		delegate void PlayVideoMessage();

		PlayVideoMessage NotifyPlayVideoMessage;

		/// <summary>
		/// 
		/// </summary>
		private string path;


		/// <summary>
		/// 
		/// </summary>
		public MP4Form()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		public MP4Form(string pathh)
		{
			InitializeComponent();

			path = pathh;

			NotifyPlayVideoMessage += new PlayVideoMessage(PlayNotify);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MP4Form_Shown(object sender, EventArgs e)
		{
			
			this.BeginInvoke(NotifyPlayVideoMessage);
		}

		/// <summary>
		/// 
		/// </summary>
		private void PlayNotify()
		{

		 //   Thread.Sleep(2000);

			//axWindowsMediaPlayer1.settings.autoStart = false;
			////this.axWindowsMediaPlayer1.settings.playCount = 1;//播放次数；
			//axWindowsMediaPlayer1.URL = path;
			//axWindowsMediaPlayer1.Ctlcontrols.play();
		

		}

		private void button1_Click(object sender, EventArgs e)
		{
			//axWindowsMediaPlayer1.settings.autoStart = false;
			//this.axWindowsMediaPlayer1.settings.playCount = 1;//播放次数；
			
			//axWindowsMediaPlayer1.URL = path;
			//axWindowsMediaPlayer1.Ctlcontrols.play();
			System.Diagnostics.Process.Start(path);
			//if (axWindowsMediaPlayer1.currentMedia.duration == 0)
			//{
			//	timer1.Interval = 50;
			//	timer1.Enabled = true;
			//}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
//			axWindowsMediaPlayer1.Ctlcontrols.play();
//			if (axWindowsMediaPlayer1.currentMedia.duration > 0)
//			{
//// 				FrmClass.Example_TimeSizeD = axWindowsMediaPlayer1.currentMedia.duration;
//// 
//// 				((Frm_Play)FrmClass.F_MPlay).pictureBox_Hold.Left = 0;
//// 				FrmClass.Example_FileInfoL.Add("文件名称:" + axWindowsMediaPlayer1.currentMedia.getItemInfo("Title"));
//// 				FrmClass.Example_FileInfoL.Add(axWindowsMediaPlayer1.currentMedia.getItemInfo("Duration"));
//// 				FrmClass.Example_FileInfoL.Add("文件类型:" + axWindowsMediaPlayer1.currentMedia.getItemInfo("FileType"));
//				timer1.Enabled = false;
//			}

		}
	}
}
