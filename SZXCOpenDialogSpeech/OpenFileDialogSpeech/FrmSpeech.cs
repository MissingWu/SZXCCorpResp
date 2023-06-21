using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using DotNetSpeech;
using System.Threading;
using CCWin;
using System.Runtime.InteropServices;

namespace SpeechDemo
{
    public partial class FrmSpeech : Skin_Mac
    {

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechVoiceSpeakFlags spFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
        SpVoice sp = new SpVoice();

        private SpSharedRecoContext ssrc;
        private ISpeechRecoGrammar srg;

        public FrmSpeech()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Choices preCmd = new Choices();
            preCmd.Add(new string[] {"水晶", "关闭系统", "退出系统","返回上一级","切换","打开", "寻焦点", "往下移", "往上移", "往左移", "往右移" });
           
            preCmd.Add(new string[] { "第","一" , "二", "三" , "四", "五" , "六", "七", "八", "九" ,"十","个" });

            //             string 文字集合 = "一  乙 二  十  丁  厂  七  卜  人  入  八  九  几 儿  了  力  乃  刀  又  三  于  干  亏  士  工  土  才  寸  下  大  丈  与  万  上  小  口  巾  山  千  乞  川  亿  个  勺  久  凡  及  夕  丸  么  广  亡  " +
            //                 "门  义  之  尸  弓  己  已  子  卫  也  女  飞  刃  习  叉 马  乡 丰  王  井  开  夫   天  无  元  专  云  扎 艺  木  五  支  厅  不  太  犬  区  历  尤  " +
            //                 "友  匹  车  巨  牙  屯  比  互  切  瓦  止  少  日  中  冈  贝  内  水  见  午  牛  手  毛  气  升  长  仁  什  片  仆  化  仇  币  仍  仅  斤  爪  反  介  父  从  今  凶  分  " +
            //                 "乏  公  仓  月  氏  勿  欠  风  丹  匀  乌  凤  勾  文  六  方  火  为  斗  忆  订  计  户  认  心  尺  引  丑  巴  孔  队  办  以  允  予  劝  双  书  幻 常  玉  刊  示  末  未  击  打  巧  正  扑  扒 功  扔  去  甘  世  古  节  本  术  可  丙  " +
            //                 "左  厉  右  石  布  龙  平  灭  轧  东  卡  北  占  业  旧  帅  归  且  旦  目  叶  甲  申  叮  电  号  田  由  史  只  央  兄  叼  叫  另  叨  叹  四  生  失  禾  丘  付  仗 代  仙  们  仪  白  仔  他  斥  瓜  乎  丛 令  用  甩  印  乐  句  匆  册  犯  外  处 冬  鸟  务  包  饥  主  市  立  闪  兰  半 " +
            //                 "汁  汇  头  汉  宁  穴  它  讨  写  让  礼  训  必  议  讯  记  永  司  尼  民  出  辽  奶  奴  加  召  皮  边  发  孕  圣  对  台  矛  纠  母  幼  丝  式  刑  动  扛  寺  吉  扣  考  托  老  执  巩  圾  扩  扫  地  扬  场  耳  共  芒  亚";
            // 
            //            string[] 文字分割= 文字集合.Split(new string[] {"  "," "},StringSplitOptions.RemoveEmptyEntries);

            //   preCmd.Add(文字分割);

            GrammarBuilder gb = new GrammarBuilder();              
            gb.Append(preCmd);

            Grammar gr = new Grammar(gb);
            recEngine.LoadGrammarAsync(gr);
            recEngine.SetInputToDefaultAudioDevice();
          
         
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork; //开启语音后，运行
            backgroundWorker1.WorkerSupportsCancellation=true;

            backgroundWorker2.DoWork += BackgroundWorker2_DoWork; //开启语音后，运行
            backgroundWorker2.WorkerSupportsCancellation = true;

			this.KeyDown += this.FrmSpeech_KeyDown;
			//this.OnKeyDown(new KeyEventArgs(Keys.Back));

			sp.Speak("是否需要寻焦点！", spFlags);
			button2.Enabled = true;
			button1.Enabled = false;
			if (!backgroundWorker2.IsBusy)
				backgroundWorker2.RunWorkerAsync();
			
		}

		private void FrmSpeech_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Back)
			{
			      

			}
			if (e.KeyCode == Keys.Tab)
			{


			}

			//throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
        {

            sp.Speak("是否需要切换！", spFlags);

            button2.Enabled = true;
            button1.Enabled = false;
            if(!backgroundWorker2.IsBusy)
            backgroundWorker2.RunWorkerAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            button2.Enabled = false;
            button1.Enabled = true;

            //backgroundWorker1.CancelAsync();
            //recEngine.SpeechRecognized -= recEngine_SpeechRecognized;
            //backgroundWorker2.CancelAsync();
            recEngine.SpeechRecognized -= recEngine_SpeechRecognized;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
        }
        /// <summary>
        /// 开启语音后，运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            do
            {
                Thread.Sleep(100);

            } while (SpeechRunState.SRSEDone != sp.Status.RunningState);

            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            backgroundWorker1.CancelAsync();

        }

        /// <summary>
        /// 刚启动语音时运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                Thread.Sleep(100);
            } while (SpeechRunState.SRSEDone != sp.Status.RunningState);


            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            
            backgroundWorker2.CancelAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {

           // recEngine.SpeechRecognized += recEngine_SpeechRecognized;
         
        }

		[DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
		public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

		void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            recEngine.SpeechRecognized -= recEngine_SpeechRecognized;
		
			this.TopMost=false;
            switch (e.Result.Text)
            {
                case "关闭系统":
                    richTextBox1.Text += "\n好的，关闭系统";
                    sp.Speak("好的，现在执行关闭系统", spFlags);
					this.Close();
                    break;
				case "返回上一级":
					keybd_event(Keys.Back, 0, 0, 0);
					richTextBox1.Text += "\n好的，返回上一级";
					sp.Speak("好的，现在执行返回上一级", spFlags);
					//this.OnKeyDown(new KeyEventArgs(Keys.Back));
					
					break;
				case "寻焦点":

					for (int i = 0; i <8; i++)
					{
						keybd_event(Keys.Tab, 0, 0, 0);		
						//Application.DoEvents();
						Thread.Sleep(1000);
					}
				    richTextBox1.Text += "\n好的，寻焦点";
					sp.Speak("好的，现在执行寻焦点", spFlags);
					//this.OnKeyDown(new KeyEventArgs(Keys.Tab));					
					break;
				case "往下移":
					keybd_event(Keys.Down, 0, 0, 0);
					richTextBox1.Text += "\n好的，往下移动";
					sp.Speak("好的，现在执行往下移动", spFlags);
					//this.OnKeyDown(new KeyEventArgs(Keys.Tab));					
					break;
				case "往上移":
					keybd_event(Keys.Up, 0, 0, 0);
					richTextBox1.Text += "\n好的，往上移动";
					sp.Speak("好的，现在执行往上移动", spFlags);
					//this.OnKeyDown(new KeyEventArgs(Keys.Tab));					
					break;
				case "往左移":
					keybd_event(Keys.Left, 0, 0, 0);
					richTextBox1.Text += "\n好的，往左移动";
					sp.Speak("好的，现在执行往左移动", spFlags);
					//this.OnKeyDown(new KeyEventArgs(Keys.Tab));					
					break;
				case "往右移":
					keybd_event(Keys.Right, 0, 0, 0);
					richTextBox1.Text += "\n好的，往右移动";
					sp.Speak("好的，现在执行往右移动", spFlags);
					//this.OnKeyDown(new KeyEventArgs(Keys.Tab));					
					break;
				case "打开":
					keybd_event(Keys.Enter, 0, 0, 0);
					richTextBox1.Text += "\n好的，打开";
					sp.Speak("好的，现在执行打开", spFlags);
					//this.OnKeyDown(new KeyEventArgs(Keys.Tab));	
					this.Close();
					break;
				default:
                    richTextBox1.Text += "\n" + e.Result.Text;
                    sp.Speak("\n" + e.Result.Text, spFlags);

                 

                    break;
            }

          
            if(!backgroundWorker1.IsBusy)
            backgroundWorker1.RunWorkerAsync();

        }

		private void FrmSpeech_Shown(object sender, EventArgs e)
		{

			this.WindowState = FormWindowState.Minimized;

		}
	}
}
