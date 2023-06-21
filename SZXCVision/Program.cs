using Common;
using Core;
using Core.Service;
using StartWindowForm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionCore.service;
using VisionCore.service.camera;

namespace SZXCVision
{
    

    static class Program
    {

        public static StartWindowForm1 startForm;
        public  static Thread startthread;

       public static void CallToChildThread()
        {
            startForm = new StartWindowForm1();
            startForm.ShowDialog();
           
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (RegistFileHelper.ExistRegistInfofile() == true)
            {

                string info = RegistFileHelper.ReadRegistFile();
                if (/*UTool.CheckRegist(info) == true*/true)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                
                    Process instance = RunningInstance();
                    if (instance == null)
                    {

                        startthread = new Thread(CallToChildThread);
                        startthread.IsBackground = true;
                        startthread.Start();
                        Thread.Sleep(1000);

                        //加载插件
                        ToolPluginService.InitPlugin();
                        startForm.processval = 25;
                        CameraPluginService.InitPlugin();
                        startForm.processval = 50;
                        MotionPluginService.InitPlugin();
                        startForm.processval = 70;
                        RobotPluginService.InitPlugin();
                        startForm.processval = 80;
                  
                        Application.Run(new XCVisionForm());
                    }
                    else
                    {
                        HandleRunningInstance(instance);
                    }
                }
                else
                {
                   
                    VertifyForm frm=new VertifyForm();
                    frm.ShowDialog();
                }
            }
            else
            {
               // MessageBox.Show("缺少系统文件，请与管理员联系");
				frmMessageDialog dlg = new frmMessageDialog();
				dlg.message = "缺少RegistInfo.key文件，请与管理员联系";
				dlg.ShowDialog();

			}



         
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表
            foreach (Process process in processes)
            {
                //保证要打开的进程同已经存在的进程来自同一文件路径
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回已经存在的事例
                        return process;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private static void HandleRunningInstance(Process instance)
        {
            MessageBox.Show("程序已经运行", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ShowWindowAsync(instance.MainWindowHandle, 1); //正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //把窗口置于前端
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
    }
}
