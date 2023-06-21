using CCWin.SkinControl;
using Core;
using Core.core;
using Core.Motion;
using Core.Robot;
using Core.Set_UI;
using Core.SetUI;
using CPublicDefine;
using SZXCArimEngine;
using Microsoft.Win32;
using MyFormDesinger;
using OpenCVCore;
using OpenCVModuleUC;
using OpenCVParentForm;
using Spire.Xls;
using StartWindowForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionCore.Log4Net;
using VisionCore.Tools;
using static System.Windows.Forms.ImageList;
using SpeechDemo;
using System.Collections.Specialized;

namespace SZXCVision
{

    public partial class XCVisionForm : ParentForm1
    {

        #region 变量声明

        /// <summary>
        /// 消息窗体
        /// </summary>
        private Core.frmMessageDialog dlg;

        /// <summary>
        /// 是否登录
        /// </summary>
        bool  m_IsLoginOK=false;

        /// <summary>
        /// 项目路径
        /// </summary>
       string  FilesProject;

        /// <summary>
        /// 当前一个流程
        /// </summary>
       private Project m_Proj;

        /// <summary>
        /// 操作者运行窗口
        /// </summary>
        RunDesignForm windowss;

        /// <summary>
        /// 图像格式转换
        /// </summary>
        BitmapImgProcess m_BitmapImgProcess;

        /// <summary>
        /// 启动界面
        /// </summary>
        StartWindowForm1 startForm;

        /// <summary>
        /// 关闭界面
        /// </summary>
        ClosingForm1 from;
        /// <summary>
        /// 等待界面
        /// </summary>
        RunningForm frm ;

        /// <summary>
        /// 项目信息设置窗体
        /// </summary>
        Form_Set form_;

        /// <summary>
        /// 动态显示主界面
        /// </summary>
        Form_MainShow  m_MainShow;

        /// <summary>
        /// 当前项目编号
        /// </summary>
        int m_CurrentProjid=0;

        /// <summary>
        /// 
        /// </summary>
        bool m_bRunning=false;

        /// <summary>
        /// 
        /// </summary>
        bool m_bRunningClosing = false;

        /// <summary>
        /// 当前的流程编号
        /// </summary>
        int m_CurrentFlowIndex =0;
        delegate void ChangeMainPanel();
        ChangeMainPanel NotifyChangeMainPanel;

      /// <summary>
      /// 等待窗体
      /// </summary>
        frmWaitingBox f = null;
        delegate void UpdateWaitingBox();
        UpdateWaitingBox NotifyUpdateWaitingBox;

        bool m_Load;
        #endregion

        #region 窗体消息响应函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public XCVisionForm()
        {
            InitializeComponent();
        
            //frm = new RunningForm();
            windowss = new RunDesignForm();
            m_MainShow = new Form_MainShow();
            m_MainShow.TopLevel = false;

            //MainPanel.Controls.Add(tabControl1);
            //MainPanel.Controls.Add(flowUC1);
            //MainPanel.Controls.Add(moduleUC1);
            MainPanel.Controls.Add(rtfRichTextBox1);
            MainPanel.Controls.Add(m_MainShow);

            Program.startForm.processval = 90;

            DisplayMsg.HImageExtUpImageEvent += new DisplayMsg.HImageExtUpImage(UpdateImage);
            m_BitmapImgProcess = new BitmapImgProcess();
            NotifyUpdateOpenCVImage += new UpdateOpenCVImage(UpdateNotifyOpenCVImage);
            NotifyUpdateRunnigForm += new UpdateRunnigForm(UpdateRunninfFormfounction);
            NotifyUpdateShowMutipuleCamMode += new UpdateShowMutipuleCamMode(UpdateCamMode);
            NotifyUpdateFlowRefresh += new UpdateFlowRefresh(UpdateflowRefresh);
            NotifyUpdateFlowRefresh2 += new UpdateFlowRefresh(UpdateflowRefresh2);
            NotifyUpdateFlowRefresh3 += new UpdateFlowRefresh(UpdateflowRefresh3);
            NotifyUpdateFlowRefresh4 += new UpdateFlowRefresh(UpdateflowRefresh4);
            NotifyUpdateFlowRefresh5 += new UpdateFlowRefresh(UpdateflowRefresh5);

            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

//             backgroundWorker2.DoWork += BackgroundWorker2_DoWork;
//             backgroundWorker2.WorkerSupportsCancellation = true;
//             backgroundWorker2.RunWorkerCompleted += BackgroundWorker2_RunWorkerCompleted;
            NotifyChangeMainPanel += new ChangeMainPanel(RunChangeAdmintorMode);

            IEventSZXC.RunVoiceItemEvent += new RunVoiceItem(VoiceRunning);

            Program.startForm.processval = 95;

        }
     
        /// <summary>
        /// 登录函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            filehandler = new FileHandler();
            filehandler.NotifyUpdateSubItemClick += new FileHandler.UpdateSubItemClick(UpdateRecentSubItemClick);

			StringCollection fileListt=new StringCollection();

			DirectoryInfo di = new DirectoryInfo(Path.Combine(Application.StartupPath, "示范例子和视频", "教学视频"));
			FileInfo[]  m_FileList = di.GetFiles();

			for (int i = 0; i < m_FileList.Length; i++)						
				fileListt.Add(m_FileList[i].FullName);
			
			Videofilehandler = new FileHandler(fileListt);
			Videofilehandler.NotifyUpdateSubItemClick += new FileHandler.UpdateSubItemClick(UpdateVideoHelpSubItemClick);
			

			//tabControl1.SelectedIndex = 0;
			ServiceModule.Instance.bRunHalcon = false;

            Log.InitializeRichTextBox(rtfRichTextBox1);
            Log.Info("界面登录成功 " + DateTime.Now.ToString("f"));

          
            this.BeginInvoke(NotifyUpdateShowMutipuleCamMode,"多相机模式");
            m_Load = true;

            Program.startForm.processval = 100;
            Thread.Sleep(1000);
            Program.startthread.Abort();
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XCVisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.frmMessageDialog dig = new Core.frmMessageDialog();
            dig.message = "是否要关闭系统";
            e.Cancel = true;//先取消，再再另外一个窗口关闭退出
            dig.ShowDialog();
           
            try
            {
                if (dig.dlgResult == "确定")
                {
                    Core.frmMessageDialog digbaocun = new Core.frmMessageDialog();
                    digbaocun.message = "是否要保存界面设计及其他全部数据";
                    e.Cancel = true;//先取消，再再另外一个窗口关闭退出
                    digbaocun.ShowDialog();
                    if(digbaocun.dlgResult == "确定")
                    {
                      //获取保存路径路径
                      if(savepath=="")
                        {
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                string str = saveFileDialog1.FileName;
                                saveFileDialog1.InitialDirectory = str;
                                if (str.Contains(".cfg"))
                                    str = str.Replace(".cfg", "");
                                string files = str + ".cfg";
                                savepath = files;
                            }
                        }   
                      //保存信息
                      if (Solution.s_Instance != null)
                        {
                            try
                            {
                                FilesProject = "";
                                for (int i = 0; i < m_MainShow.m_SolutionView.m_ProjectTabList.Count; i++)
                                {
                                    try
                                    {

                                        ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList[i];
                                        Project proj = Solution.s_Instance.m_ProjectList[i];
                                        proj.treeNodeslist.Clear();
                                        foreach (TreeNode node in projtab.ModelFlow.skinTreeView1.Nodes)
                                        {
                                            //ServiceModule.Instance.treeNodeslist.Add(node);
                                            // Project m_pro = (Project)ServiceModule.Instance.m_obProj;
                                            proj.treeNodeslist.Add(node);
                                        }
                                    }
                                    catch (Exception ex) { Log.Error(ex.ToString()); break; }

                                }

                                //  m_Proj = (Project)ServiceModule.Instance.m_obProj;
                                // Solution.s_Instance.m_ProjectList[m_CurrentProjid] = (Project)ServiceModule.Instance.m_obProj;

                                Solution.SaveData(savepath, Solution.s_Instance);

                                string[] str1 = saveFileDialog1.FileName.Split('\\');
                                toolStripStatusLabel2.Text = "项目名称:" + str1[str1.Length - 1];
                                toolStripStatusLabel7.Text = savepath;

                                dlg = new Core.frmMessageDialog();
                                dlg.message = "保存成功";
                                dlg.ShowDialog();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                dlg = new Core.frmMessageDialog();
                                dlg.message = "保存文件出错!!!!!!!!!!!" + "\r\n" + ex.ToString();
                                dlg.ShowDialog();
                                return;
                            }

                        }

                    }

					/******************关闭软件系统*****************/
				    backgroundWorker1.RunWorkerAsync();

					Solution.s_Instance.m_bApplicationExit = true;

					if (Solution.s_Instance != null)
                    {
                        Solution.s_Instance.CloseProject();
                    }                                  
                    Thread.Sleep(500);
                    m_MainShow.Close();
                    e.Cancel = false;
					
                    backgroundWorker1.CancelAsync();
					if (backgroundWorker1.IsBusy) { from.m_bIsExit = true; backgroundWorker1.CancelAsync(); }
					Thread.Sleep(3000);

					Environment.Exit(0);
					
				}

                else if (dig.dlgResult == "取消")
                {
                    Log.Info("窗体关闭取消");
                }
            }
            catch(Exception ex) { m_MainShow.Close(); e.Cancel = false; Console.WriteLine(ex.ToString()); Log.Error(ex.ToString());}


        }


        /// <summary>
        /// 语音实现
        /// </summary>
        /// <param name="item"></param>
        private void VoiceRunning(string item)
        {                  
            RunItems(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modulename"></param>
        private void RunItems(string modulename)
        {

            try
            {

                if (modulename == "打开ui界面设计")
                {

                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }

                    //UpdateRunninfFormfounction("启动");
                    RunningForm form1 = new RunningForm();
                    form1.BringToFront();
                    form1.Show();
                    MyFormDesigner form = new MyFormDesigner();
                    form.Modules = Solution.s_Instance.m_ProjectList[0].ModuleObjList;
                    MyFormDesinger.ConPropertyInfos.Instance = (MyFormDesinger.ConPropertyInfos)Solution.s_Instance.m_ConPropertyInfos;
                    form.Show();
                    form1.Close();
                    // UpdateRunninfFormfounction("关闭");
                }

                if (modulename == "新建项目")
                {
                    if (Solution.s_Instance == null)
                    {
                        //先清理TabPage
                        m_MainShow.m_SolutionView.m_ProjectTabList.Clear();

                        FlowUC m_flowuc = new FlowUC();
                        Solution.s_Instance = new Solution();
                        int id = Solution.s_Instance.CreateProject(m_flowuc.skinTreeView1);
                        m_CurrentProjid = id;
                        m_MainShow.m_SolutionView.AddProjectTab(Solution.GetProjectById(id));
                        Solution.GetProjectById(m_CurrentProjid).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
                        // m_flowuc.m_Project = Solution.s_Instance.m_ProjectList[id];
                        // Solution.s_Instance.NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
                        // flowUC1.skinTreeView1.BackColor = Color.LightSkyBlue;
                        //  flowUC1.skinTreeView1.Nodes.Clear();
                        // m_Proj = Solution.s_Instance.m_ProjectList[0];
                        ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[0];
                        Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1 = m_MainShow.m_SolutionView.CurrentFlow.skinTreeView1;

                    }
                    else
                    {

                        if (MessageBox.Show("是否保存当前项目?", "消息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            string files;
                            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                files = saveProjectFileDialog.FileName;
                                try
                                {
                                    FilesProject = "";
                                    Solution.SaveData(files, Solution.s_Instance);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "保存文件出错！");
                                }
                                toolStripStatusLabel7.Text = files;
                            }
                        }
                        Solution.s_Instance.Dispose();

                        //先清理TabPage
                        m_MainShow.m_SolutionView.m_ProjectTabList.Clear();
                        //先清理TabPage
                        m_MainShow.m_SolutionView.tabProject.TabPages.Clear();

                        Solution.s_Instance.CloseProject();
                        Solution.s_Instance = new Solution();

                        FlowUC m_flowuc = new FlowUC();
                        int id = Solution.s_Instance.CreateProject(m_flowuc.skinTreeView1);
                        m_CurrentProjid = id;
                        m_MainShow.m_SolutionView.AddProjectTab(Solution.GetProjectById(m_CurrentProjid));
                        Solution.GetProjectById(m_CurrentProjid).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem); ;
                        //flowUC1.skinTreeView1.BackColor = Color.LightSkyBlue;
                        //flowUC1.skinTreeView1.Nodes.Clear();
                        ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[m_CurrentProjid];
                    }

                }

                if (modulename == "打开项目")
                {
                    try
                    {
						process1.StartInfo.FileName = Path.Combine(Application.StartupPath, "OS", "OpenFileDialogSpeech.exe");
						process1.Start();
					
						if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string str = openFileDialog1.FileName;
                            openFileDialog1.InitialDirectory = str;

                            toolStripStatusLabel2.Text = "项目名称:" + openFileDialog1.SafeFileName;
                            toolStripStatusLabel7.Text = str;

                            //先清理TabPage
                            m_MainShow.m_SolutionView.m_ProjectTabList.Clear();
                            //先清理TabPage
                            try
                            {

                                m_MainShow.m_SolutionView.tabProject.TabPages.Clear();//

                            }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                            FilesProject = str;//项目名称

                            if (Solution.s_Instance != null)
                            {
                                Solution.s_Instance.CloseProject();
                            }
                            Solution.IsStop = true;
                            Solution.s_Instance = Solution.ReadData(str);
                            Solution.s_Instance.InitDevStatus();

                            ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[0];//第一个流程作为当前选择
                            m_Proj = (Project)ServiceModule.Instance.m_obProj;

                            foreach (Project proj in Solution.s_Instance.m_ProjectList)
                            {
                                if (proj == null)
                                    return;

                                m_MainShow.m_SolutionView.AddProjectTab(proj);
                                ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList.Find(e2 => e2.ProjectInfo.ProjectName == proj.ProjectInfo.ProjectName);
                                proj.skinTreeView1 = projtab.ModelFlow.skinTreeView1;

                                if (proj.treeNodeslist.Count > 0)
                                {
                                    proj.skinTreeView1.Nodes.Clear();
                                    foreach (TreeNode node in proj.treeNodeslist)
                                    {
                                        proj.skinTreeView1.Nodes.Add(node);
                                    }
                                }

                                proj.skinTreeView1.ExpandAll();
                                proj.NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);

                            }

                            m_CurrentProjid = 0;//当前流程代号

                            //显示窗体数量
                            int n = Solution.s_Instance.curScreenNum;
                            if (n >= 0)
                            {
                                Solution.s_Instance.curScreenNum = n;
                                m_MainShow.Form_set(n);
                            }
                            filehandler.AddRecentFile(openFileDialog1.FileName);
                            // Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1.BackColor = Color.SpringGreen;
                            // Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1.ExpandAll();
                            //ServiceModule.Instance.ReadConfig(str);
                            //                             if (ServiceModule.Instance.treeNodeslist == null)
                            //                                 return;
                            //                             if (ServiceModule.Instance.treeNodeslist.Count > 0)
                            //                             {
                            //                                 flowUC1.skinTreeView1.Nodes.Clear();
                            //                                 foreach (TreeNode node in ServiceModule.Instance.treeNodeslist)
                            //                                 {
                            //                                     flowUC1.skinTreeView1.Nodes.Add(node);
                            //                                 }
                            //                             }
                            //                         flowUC1.skinTreeView1.ExpandAll();
                            //                         ServiceModule.Instance.m_obTreeView = flowUC1.skinTreeView1;
                            //                         flowUC1.m_Project = (Project)ServiceModule.Instance.m_obProj;
                            //                         




                        }

						if (Solution.s_Instance.m_IsLoginOK)
						{
							ChangeAdmintorMode();
							m_IsLoginOK = false; Solution.s_Instance.m_IsLoginOK = false;
						}

					}
                    catch (Exception ex)
                    {

                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = ex.ToString();
                        dlg.ShowDialog();
                    }
                }

                if (modulename == "保存项目")
                {
                    try
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {

                            string str = saveFileDialog1.FileName;
                            saveFileDialog1.InitialDirectory = str;
                            if (str.Contains(".cfg"))
                                str = str.Replace(".cfg", "");
                            string files = str + ".cfg";
                            savepath = files;

                            if (Solution.s_Instance != null)
                            {
                                try
                                {
                                    FilesProject = "";
                                    for (int i = 0; i < m_MainShow.m_SolutionView.m_ProjectTabList.Count; i++)
                                    {
                                        try
                                        {

                                            ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList[i];
                                            Project proj = Solution.s_Instance.m_ProjectList[i];
                                            proj.treeNodeslist.Clear();
                                            foreach (TreeNode node in projtab.ModelFlow.skinTreeView1.Nodes)
                                            {
                                                //ServiceModule.Instance.treeNodeslist.Add(node);
                                                // Project m_pro = (Project)ServiceModule.Instance.m_obProj;
                                                proj.treeNodeslist.Add(node);
                                            }
                                        }
                                        catch (Exception ex) { Log.Error(ex.ToString()); break; }

                                    }

                                    //  m_Proj = (Project)ServiceModule.Instance.m_obProj;
                                    // Solution.s_Instance.m_ProjectList[m_CurrentProjid] = (Project)ServiceModule.Instance.m_obProj;

                                    Solution.SaveData(files, Solution.s_Instance);

                                    string[] str1 = saveFileDialog1.FileName.Split('\\');
                                    toolStripStatusLabel2.Text = "项目名称:" + str1[str1.Length - 1];
                                    toolStripStatusLabel7.Text = files;

                                    dlg = new Core.frmMessageDialog();
                                    dlg.message = "保存成功";
                                    dlg.ShowDialog();

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    dlg = new Core.frmMessageDialog();
                                    dlg.message = "保存文件出错!!!!!!!!!!!" + "\r\n" + ex.ToString();
                                    dlg.ShowDialog();
                                    return;
                                }

                            }


                            //                         object ob = ServiceModule.Instance.m_obTreeView;
                            //                         SkinTreeView skinTreeView1 = (SkinTreeView)ob;
                            //                         TreeNodeCollection treeNodeCollection = skinTreeView1.Nodes;
                            //                         ServiceModule.Instance.treeNodeCollection = treeNodeCollection;
                            //                         ServiceModule.Instance.treeNodeslist.Clear();
                            //                         ServiceModule.Instance.Imagelist = new List<int>();

                            //                         foreach (TreeNode node in ServiceModule.Instance.treeNodeCollection)
                            //                         {
                            //                             ServiceModule.Instance.treeNodeslist.Add(node);
                            //                         }
                            //                        
                            //                         ServiceModule.Instance.m_obProj= flowUC1.m_Project;


                            //                         if (File.Exists(str))
                            //                         {
                            //                             File.Delete(str);
                            //                             ServiceModule.Instance.SaveConfig(str + ".cfg");
                            //                         }
                            //                         else
                            //                             ServiceModule.Instance.SaveConfig(str + ".cfg");


                            //                         ServiceModule.Instance.SaveName = "ProjectConfig";
                            //                         ServiceModule.Instance.SaveConfig(ServiceModule.Instance.m_obProj);


                        }
                    }
                    catch (Exception ex)
                    {
                        dlg = new Core.frmMessageDialog();
                        dlg.message = ex.ToString();
                        dlg.ShowDialog();
                    }

                }

                if (modulename == "打开相机设置")
                {

                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    RunningForm form1 = new RunningForm();
                    form1.BringToFront();
                    form1.Show();

                    Cameras_Set set_ = new Cameras_Set();
                    set_.g_AcqDeviceList = Solution.s_Instance.g_AcqDeviceList;
                    set_.Show();

                    form1.Close();
                }

                if (modulename == "打开运动设置")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }

                    MotionCard_Set frm = new MotionCard_Set();
                    frm.g_AcqDeviceList = Solution.s_Instance.g_CardDeviceList;
                    frm.ShowDialog();

                    // List<CardBase>  m_gDeviceList =frm.g_AcqDeviceList;
                    Form_Motion motion = new Form_Motion();
                    motion.Motiondevice_ = frm.Motiondevice_;
                    motion.Text = frm.Motiondevice_.m_CardName;
                    motion.Show();

                }

                if (modulename == "打开机器人设置")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    Rotbot_Set frm = new Rotbot_Set();
                    frm.g_AcqDeviceList = Solution.s_Instance.g_RobotDeviceList;
                    frm.ShowDialog();

                    // List<RobotServiceBase>  m_gDeviceList =frm.g_AcqDeviceList;
                    Form_Robot motion = new Form_Robot();
                    motion.Motiondevice_ = frm.Robotdevice_;
                    motion.Text = frm.Robotdevice_.m_CardName;
                    //motion.TopLevel = true;
                    motion.Show();

                }

                if (modulename == "权限登录")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }

                    if (m_IsLoginOK)
                    {
                        ChangeAdmintorMode();
                       // m_IsLoginOK = false; Solution.s_Instance.m_IsLoginOK = false;
					}

                    else
                    {

						UpdateRunninfFormfounction("启动" + "关闭");

						/*   RunChangeAdmintorMode();*/
						//UpdateRunninfFormfounction("关闭");

						m_IsLoginOK = true;
						Solution.s_Instance.m_IsLoginOK = true;					
					}

                }

                if (modulename == "打开全局变量")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    Variable_Set set = new Variable_Set(Solution.s_Instance.g_VariableList);
                    set.ShowDialog();
                }

                if (modulename == "打开网络连接")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    Communication_Set set = new Communication_Set(Solution.s_Instance.g_Com_list);
                    set.ShowDialog();

                }

                if (modulename == "停止")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    if (Solution.s_Instance != null)
                    {
                        Solution.StopRun();
                    }

                }

                if (modulename == "单次执行流程")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    if (Solution.s_Instance != null)
                    {
                        Solution.ExecuteOnce();
                    }
                }

                if (modulename == "循环执行流程")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    if (Solution.s_Instance != null)
                    {
                        Solution.StartRun();
                    }

                }

                if (modulename == "关于")
                {
                    FrmAbout form_ = new FrmAbout();
                    form_.ShowDialog();
                }

               

                Log.Info(modulename + " RunOK " + DateTime.Now.ToString("f"));

               

            }//try

            catch (Exception ex) { MessageBox.Show(ex.ToString()); Log.Info(ex.Message + DateTime.Now.ToString("f")); }

        }

        /// <summary>
        /// 打开最近文件的时候调用该函数
        /// </summary>
        /// <param name="str"></param>
        void UpdateRecentSubItemClick(string str)
        {
            try
            {
                    string str2 = str;
                    openFileDialog1.InitialDirectory = str2;

                    toolStripStatusLabel2.Text = openFileDialog1.SafeFileName;
                    toolStripStatusLabel7.Text = str2;

                    //先清理TabPage
                    m_MainShow.m_SolutionView.m_ProjectTabList.Clear();
                    //先清理TabPage
                    try
                    {
                        m_MainShow.m_SolutionView.tabProject.TabPages.Clear();//
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                    FilesProject = str;//项目名称

                    if (Solution.s_Instance != null)
                    {
                        Solution.s_Instance.CloseProject();
                    }
                    Solution.IsStop = true;
                    Solution.s_Instance = Solution.ReadData(str);
                    Solution.s_Instance.InitDevStatus();

                    ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[0];//第一个流程作为当前选择
                    m_Proj = (Project)ServiceModule.Instance.m_obProj;

                    foreach (Project proj in Solution.s_Instance.m_ProjectList)
                    {
                        if (proj == null)
                            return;

                        m_MainShow.m_SolutionView.AddProjectTab(proj);
                        ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList.Find(e2 => e2.ProjectInfo.ProjectName == proj.ProjectInfo.ProjectName);
                        proj.skinTreeView1 = projtab.ModelFlow.skinTreeView1;

                        if (proj.treeNodeslist.Count > 0)
                        {
                            proj.skinTreeView1.Nodes.Clear();
                            foreach (TreeNode node in proj.treeNodeslist)
                            {
                                proj.skinTreeView1.Nodes.Add(node);
                            }
                        }

                        proj.NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);

                    }

                    m_CurrentProjid = 0;//当前流程代号
				    m_MainShow.m_SolutionView.tabProject.SelectedIndex = m_CurrentProjid;

					//显示窗体数量
				    int n = Solution.s_Instance.curScreenNum;
                    if (n >= 0)
                    {
                        Solution.s_Instance.curScreenNum = n;
                        m_MainShow.Form_set(n);
                    }
                   
                           




                
            }
            catch (Exception ex)
            {

                Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                dlg.message = ex.ToString();
                dlg.ShowDialog();


            }

        }

		/// <summary>
		/// 打开教学视频的时候调用该函数
		/// </summary>
		/// <param name="str"></param>
		void UpdateVideoHelpSubItemClick(string str)
		{
			try
			{

				// 				MP4Form frm = new MP4Form(str);
				// 				frm.Show();

				System.Diagnostics.Process.Start(str);


			}
			catch (Exception ex)
			{

				Core.frmMessageDialog dlg = new Core.frmMessageDialog();
				dlg.message = ex.ToString();
				dlg.ShowDialog();


			}

		}
		/// <summary>
		/// 切换显示
		/// </summary>
		/// <param name="frm"></param>
		private void ChangeMainPanelf(Form frm)
        {
            frm.TopLevel = false;
            frm.TopMost = true;
           // frm.Dock = DockStyle.Fill;
            frm.ControlBox = false;
            frm.BackColor = Color.LightSkyBlue;
            if (MainPanel.Controls.Count >= 6)//去掉窗体
                MainPanel.Controls.RemoveAt(5);
            MainPanel.Controls.Add(frm);

            m_MainShow.Hide();//原来添加的窗体控件隐藏起来，显示当前的控件窗体
//             tabControl1.Hide();
//             flowUC1.Hide();
//             moduleUC1.Hide();
            frm.Show();

            Thread.Sleep(10);      
            frm.Dock = DockStyle.Fill;

            Size m_Size = frm.Size;
            m_Size.Width = +10;
            m_Size.Height = +10;
            frm.Size = m_Size;


        }

        /// <summary>
        /// 操作员界面
        /// </summary>
        private void ChangeOperaMode()
        {
            #region 二级界面控件模块信息

            MyFormDesinger.StructInfo.Instance = (MyFormDesinger.StructInfo)Solution.s_Instance.m_ControlDesignInfo;
			MyFormDesinger.StructInfo.Instance.m_gVariable = Solution.s_Instance.g_VariableList;
			MyFormDesinger.StructInfo.Instance.m_ModuleVariables = ServiceModule.Instance.m_obProj.ModuleObjList;

            #endregion

            #region 显示二级用户界面

            if (Solution.s_Instance.m_ConPropertyInfos == null)
            {
                string path = Path.Combine(Application.StartupPath, "FormDesign", "Debug", "Config", "自定义界面", "ZiDingYiJieMian.XCCorp");
                string pathh = path;
                path = pathh;
                FileStream stream = new FileStream(path, FileMode.Open);
                BinaryFormatter bFormat = new BinaryFormatter();
                ConPropertyInfos controltainers = (ConPropertyInfos)bFormat.Deserialize(stream);
                ConPropertyInfos.Instance = controltainers;
                stream.Close();
            }
            else
            {
                ConPropertyInfos controltainers = (ConPropertyInfos)Solution.s_Instance.m_ConPropertyInfos;
                ConPropertyInfos.Instance = controltainers;
            }

            int num = ConPropertyInfos.Instance.m_MutipulControlProtylist.Count;
            ControlHelper.Instance.controls = new List<Control>();
            for (int i = 0; i < num; i++)
            {
                //获取属性信息
                F_DATA_CELL_FormDesign data = ConPropertyInfos.Instance.m_MutipulControlProtylist[i];
                //获取属性信息对应的值
                Dictionary<string, object> savepropertyvals = (Dictionary<string, object>)data.m_Data_Value;
                if (i < num - 1)//获取控件信息
                {
                    //获取控件的类型
                    string name = data.m_Module_Name;
                    string[] names = name.Split('.');
                    names[names.Length - 1] = names[names.Length - 1].Replace("UC", "");
                    Control con = ControlHelper.Instance.CreateControl(names[names.Length - 1], "/");
                    con.BackgroundImageLayout = ImageLayout.Stretch;//控件背景拉伸显示
                    PropertyInfo[] pis = con.GetType().GetProperties();//获取新的控件属性信息
                    for (int j = 0; j < pis.Length; j++)
                    {
                        try
                        {

                            object val = savepropertyvals[pis[j].Name];



							if (pis[j].Name == "AdvancedCellBorderStyle" || pis[j].Name == "AdvancedColumnHeadersBorderStyle" || pis[j].Name == "AdvancedRowHeadersBorderStyle" || pis[j].Name == "AdjustedTopLeftHeaderBorderStyle")//因为不能被序列化
							{
								continue;
							}

							else if (pis[j].Name == "m_ColListInfos")
							{

								List <datasourceColumnInfos> m_list= (List<datasourceColumnInfos> )val;
								DataSourceUC  uc= (DataSourceUC)con;
								uc.m_ColListInfos = m_list;
								uc.Columns.Clear();

								for (int m = 0; m < uc.m_ColListInfos.Count; m++)
									uc.Columns.Add(uc.m_ColListInfos[m].headTextname, uc.m_ColListInfos[m].headTextname);

								continue;
							}
							else if (pis[j].Name == "ColumnHeadersDefaultCellStyle" || pis[j].Name == "DefaultCellStyle" || pis[j].Name == "FirstDisplayedCell" || pis[j].Name == "RowTemplate")//因为不能被序列化
							{
								continue;
							}
							else if (pis[j].Name == "RowHeadersDefaultCellStyle" || pis[j].Name == "RowsDefaultCellStyle" || pis[j].Name == "AlternatingRowsDefaultCellStyle" || pis[j].Name == "TopLeftHeaderCell")//因为不能被序列化
							{
								continue;
							}

							else if (!val.ToString().Contains("."))
							{
								pis[j].SetValue(con, val, null); continue;
							}

							else
							{
								if (val.ToString().Contains("System.Drawing.Bitmap"))
									pis[j].SetValue(con, val, null);
							}
                        }
                        catch(Exception ex) { Log.Error(ex.ToString()); }

                    }
                    ControlHelper.Instance.controls.Add(con);
                }
                else//获取窗体属性信息
                {
                    PropertyInfo[] pis = windowss.GetType().GetProperties();//获取新的控件属性信息
                    foreach (PropertyInfo pi in pis)
                    {
                        try
                        {
                            if (pi.Name.ToString() == "Size" || pi.Name.ToString() == "Location" || pi.Name.ToString() == "BackColor" || pi.Name.ToString() == "Dock" || pi.Name.ToString() == "BackgroundImage")
                            {
                                object val = savepropertyvals[pi.Name];
                                if (!val.ToString().Contains("."))
                                {
                                    pi.SetValue(windowss, val, null);
                                }
                                else
                                {
                                    if (val.ToString().Contains("System.Drawing.Bitmap"))
                                        pi.SetValue(windowss, val, null);
                                }
                            }
                        }
                        catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                    }
                }//else
               // Thread.Sleep(0);
            }  
            
            #endregion

        }

        /// <summary>
        /// 管理员界面
        /// </summary>
        private void ChangeAdmintorMode()
        {

            LoginLoad load = new LoginLoad();
            load.ShowDialog();

            if (!load.m_LoginResult) { load.Dispose(); m_IsLoginOK = true;
				Solution.s_Instance.m_IsLoginOK = true; return; }

            #region 显示一级用户界面

            // m_MainShow.Show();


//             tabControl1.Hide();
//             flowUC1.Hide();
//             moduleUC1.Hide();
            windowss.Hide();
            m_MainShow.Show();


			#endregion


			m_IsLoginOK = false;
			Solution.s_Instance.m_IsLoginOK = false;
		}

        /// <summary>
        /// 运行切换
        /// </summary>
       public void RunChangeAdmintorMode()
        {
            //更改为操作员模式
            ChangeOperaMode();

            windowss = new RunDesignForm();
            //自定义界面所有控件信息
            foreach (Control con in ControlHelper.Instance.controls)
            {
                windowss.Controls.Add(con);
                windowss.ConList.Add(con);
            }

            ChangeMainPanelf(windowss);

        }

        /// <summary>
        /// 保存路径
        /// </summary>
       private string savepath="";

        /// <summary>
        /// 打开路径
        /// </summary>
        private string Openpath = "";

        /// <summary>
        /// 工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {  
            
         try {
               
            if ( e.ClickedItem.Text== "ui界面设计")
                {

                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }

                    //UpdateRunninfFormfounction("启动");
                    RunningForm form1 = new RunningForm();
                    form1.BringToFront();
                    form1.Show();

                    MyFormDesigner form = new MyFormDesigner();
                    form.Modules = Solution.s_Instance.m_ProjectList[0].ModuleObjList;
                    form.Projs = Solution.s_Instance.m_ProjectList;

                    MyFormDesinger.ConPropertyInfos.Instance = (MyFormDesinger.ConPropertyInfos) Solution.s_Instance.m_ConPropertyInfos;
                    form.Show();
                    form1.Close();

                    // UpdateRunninfFormfounction("关闭");
                }

            if (e.ClickedItem.Text == "新建项目")
                {
                    if (Solution.s_Instance == null)
                    {
                        //先清理TabPage
                        m_MainShow.m_SolutionView.m_ProjectTabList.Clear();

                        FlowUC m_flowuc = new FlowUC();
                        Solution.s_Instance = new Solution();
                        int id = Solution.s_Instance.CreateProject(m_flowuc.skinTreeView1);
                        m_CurrentProjid = id;
                        m_MainShow.m_SolutionView.AddProjectTab(Solution.GetProjectById(id));
                        Solution.GetProjectById(m_CurrentProjid).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
                       // m_flowuc.m_Project = Solution.s_Instance.m_ProjectList[id];
                        // Solution.s_Instance.NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
                        // flowUC1.skinTreeView1.BackColor = Color.LightSkyBlue;
                        //  flowUC1.skinTreeView1.Nodes.Clear();
                        // m_Proj = Solution.s_Instance.m_ProjectList[0];
                        ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[0];
                        Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1 = m_MainShow.m_SolutionView.CurrentFlow.skinTreeView1;

                    }
                    else
                    {
						Core.frmMessageDialog dlg = new Core.frmMessageDialog();
						dlg.message = "是否保存当前项目 ? ";
						dlg.ShowDialog();

						if (dlg.dlgResult=="确定")
                        {
                            string files;
                            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                files = saveProjectFileDialog.FileName;
                                try
                                {
                                    FilesProject = "";
                                    Solution.SaveData(files, Solution.s_Instance);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "保存文件出错！");
                                }
                                toolStripStatusLabel7.Text = files;
                            }
                        }

                        Solution.s_Instance.Dispose();

                        //先清理TabPage
                        m_MainShow.m_SolutionView.m_ProjectTabList.Clear();
                        //先清理TabPage
                        m_MainShow.m_SolutionView.tabProject.TabPages.Clear();

                        Solution.s_Instance.CloseProject();
                        Solution.s_Instance = new Solution();

                        FlowUC m_flowuc = new FlowUC();
                        int id = Solution.s_Instance.CreateProject(m_flowuc.skinTreeView1);
                        m_CurrentProjid = id;
                        m_MainShow.m_SolutionView.AddProjectTab(Solution.GetProjectById(m_CurrentProjid));
                        Solution.GetProjectById(m_CurrentProjid).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem); ;
                        //flowUC1.skinTreeView1.BackColor = Color.LightSkyBlue;
                        //flowUC1.skinTreeView1.Nodes.Clear();
                        ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[m_CurrentProjid];
                    }

                }

            if (e.ClickedItem.Text == "打开项目")
            {

			RunningForm frm = new RunningForm();
			  try
                {

				openFileDialog1.Filter = "程序|*.cfg;|图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;|word文档|*.doc;|Excel文档|*.xls;*.xlsx;";
						if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {

							
							frm.TopLevel = true;
                            frm.TopMost = true;
                            frm.Show();

                        string str= openFileDialog1.FileName;
                        openFileDialog1.InitialDirectory = str;

                        toolStripStatusLabel2.Text = "项目名称:"+openFileDialog1.SafeFileName;
                        toolStripStatusLabel7.Text = str;

                            //先清理TabPage
                            m_MainShow.m_SolutionView.m_ProjectTabList.Clear();
                            //先清理TabPage
                            try
                            {

                                m_MainShow.m_SolutionView.tabProject.TabPages.Clear();//

                            }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                            
                        FilesProject = str;//项目名称

                        if (Solution.s_Instance != null)
                            {
                                Solution.s_Instance.CloseProject();
                            }
                            Solution.IsStop = true;
                            Solution.s_Instance = Solution.ReadData(str);
                            Solution.s_Instance.InitDevStatus();//初始化相机

                            ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[0];//第一个流程作为当前选择
                            m_Proj=(Project) ServiceModule.Instance.m_obProj;  
                            
                            foreach(Project proj in Solution.s_Instance.m_ProjectList)
                            {
                                if (proj == null)
                                    return;

                               m_MainShow.m_SolutionView.AddProjectTab(proj);                             
                               ProjectTab projtab   =m_MainShow.m_SolutionView.m_ProjectTabList.Find(e2=>e2.ProjectInfo.ProjectName== proj.ProjectInfo.ProjectName);
                               proj.skinTreeView1 = projtab.ModelFlow.skinTreeView1;
                              
                                if (proj.treeNodeslist.Count > 0)
                                {
                                    proj.skinTreeView1.Nodes.Clear();
                                    foreach (TreeNode node in proj.treeNodeslist)
                                    {
                                        proj.skinTreeView1.Nodes.Add(node);
                                    }
                                }

                                proj.skinTreeView1.ExpandAll();
                                proj.NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);

                            }

                            m_CurrentProjid = 0;//当前流程代号
							m_MainShow.m_SolutionView.tabProject.SelectedIndex = 0;

							//显示窗体数量
							int n = Solution.s_Instance.curScreenNum;
                            if (n >= 0)
                            {
                                Solution.s_Instance.curScreenNum = n;
                                m_MainShow.Form_set(n);
                            }
                            filehandler.AddRecentFile(openFileDialog1.FileName);

                            // Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1.BackColor = Color.SpringGreen;
                            // Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1.ExpandAll();
                            //ServiceModule.Instance.ReadConfig(str);
                            //                             if (ServiceModule.Instance.treeNodeslist == null)
                            //                                 return;
                            //                             if (ServiceModule.Instance.treeNodeslist.Count > 0)
                            //                             {
                            //                                 flowUC1.skinTreeView1.Nodes.Clear();
                            //                                 foreach (TreeNode node in ServiceModule.Instance.treeNodeslist)
                            //                                 {
                            //                                     flowUC1.skinTreeView1.Nodes.Add(node);
                            //                                 }
                            //                             }
                            //                         flowUC1.skinTreeView1.ExpandAll();
                            //                         ServiceModule.Instance.m_obTreeView = flowUC1.skinTreeView1;
                            //                         flowUC1.m_Project = (Project)ServiceModule.Instance.m_obProj;
                            //                         


                            frm.Close();

                        }

						if (Solution.s_Instance.m_IsLoginOK)
						{
							ChangeAdmintorMode();
							m_IsLoginOK = false; Solution.s_Instance.m_IsLoginOK = false;
						}
					}
                    catch(Exception ex)
                    {
                        frm.Close();
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                            dlg.message = ex.ToString();
                            dlg.ShowDialog();                                                
                    }
            }    
            
            if (e.ClickedItem.Text == "保存项目")
            {              
                try
                {
						saveFileDialog1.Filter = "程序|*.cfg;|图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;|word文档|*.doc;|Excel文档|*.xls;*.xlsx;";
						if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                           string str = saveFileDialog1.FileName;
                            saveFileDialog1.InitialDirectory = str;
                            if (str.Contains(".cfg"))
                                str= str.Replace(".cfg", "");
                            string files= str+".cfg";
                            savepath = files;

                            if (Solution.s_Instance != null)
                            {                                                             
                                 try
                                {
									RunningForm frm = new RunningForm();
									frm.Show();
                                    FilesProject = "";
                                    for(int i=0;i< m_MainShow.m_SolutionView.m_ProjectTabList.Count; i++)
                                    {
                                        try
                                        {

                                            ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList[i];
                                            Project proj = Solution.s_Instance.m_ProjectList[i];
                                            proj.treeNodeslist.Clear();
                                            foreach (TreeNode node in projtab.ModelFlow.skinTreeView1.Nodes)
                                            {
                                                //ServiceModule.Instance.treeNodeslist.Add(node);
                                                // Project m_pro = (Project)ServiceModule.Instance.m_obProj;
                                                proj.treeNodeslist.Add(node);
                                            }
                                        }
                                        catch(Exception ex) { Log.Error(ex.ToString()); break; }

                                    }
                                    
                                  //  m_Proj = (Project)ServiceModule.Instance.m_obProj;
                                  // Solution.s_Instance.m_ProjectList[m_CurrentProjid] = (Project)ServiceModule.Instance.m_obProj;

                                    Solution.SaveData(files, Solution.s_Instance);

                                   string[] str1= saveFileDialog1.FileName.Split('\\');
                                    toolStripStatusLabel2.Text = "项目名称:" + str1[str1.Length-1];
                                    toolStripStatusLabel7.Text = files;

									frm.Close();

									dlg = new Core.frmMessageDialog();
                                    dlg.message = "保存成功";
                                    dlg.ShowDialog();

                                }
                              catch (Exception ex)
                                    {
                                    Console.WriteLine(ex);
                                    dlg = new Core.frmMessageDialog();
                                    dlg.message = "保存文件出错!!!!!!!!!!!"+ "\r\n"+ex.ToString();
                                    dlg.ShowDialog();
                                    return;
                                }
                                
                            }


                            //                         object ob = ServiceModule.Instance.m_obTreeView;
                            //                         SkinTreeView skinTreeView1 = (SkinTreeView)ob;
                            //                         TreeNodeCollection treeNodeCollection = skinTreeView1.Nodes;
                            //                         ServiceModule.Instance.treeNodeCollection = treeNodeCollection;
                            //                         ServiceModule.Instance.treeNodeslist.Clear();
                            //                         ServiceModule.Instance.Imagelist = new List<int>();
                            
                            //                         foreach (TreeNode node in ServiceModule.Instance.treeNodeCollection)
                            //                         {
                            //                             ServiceModule.Instance.treeNodeslist.Add(node);
                            //                         }
                            //                        
                            //                         ServiceModule.Instance.m_obProj= flowUC1.m_Project;
                            

                            //                         if (File.Exists(str))
                            //                         {
                            //                             File.Delete(str);
                            //                             ServiceModule.Instance.SaveConfig(str + ".cfg");
                            //                         }
                            //                         else
                            //                             ServiceModule.Instance.SaveConfig(str + ".cfg");


                            //                         ServiceModule.Instance.SaveName = "ProjectConfig";
                            //                         ServiceModule.Instance.SaveConfig(ServiceModule.Instance.m_obProj);

                       
                    }
                }
                catch (Exception ex)
                {
                    dlg = new Core.frmMessageDialog();
                    dlg.message = ex.ToString();
                    dlg.ShowDialog();
                }

            }

            if (e.ClickedItem.Text == "相机设置")
            {

                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    RunningForm form1 = new RunningForm();
                    form1.BringToFront();
                    form1.Show();

                    Cameras_Set set_ = new Cameras_Set();
                    set_.g_AcqDeviceList = Solution.s_Instance.g_AcqDeviceList;
                    set_.Show();

                    form1.Close();
             }

            if (e.ClickedItem.Text == "运动设置")
            {
            if (Solution.s_Instance == null) 
           {
           Core.frmMessageDialog dlg = new Core.frmMessageDialog();
           dlg.message = "请先新建项目或者打开项目";
           dlg.ShowDialog();
           return; }

           MotionCard_Set frm = new MotionCard_Set();
           frm.g_AcqDeviceList = Solution.s_Instance.g_CardDeviceList;
           frm.ShowDialog();

       
          Form_Motion motion = new Form_Motion();
		  motion.m_gDeviceList = Solution.s_Instance.g_CardDeviceList;
		  motion.Motiondevice_ = frm.Motiondevice_;
          motion.Text = frm.Motiondevice_.m_CardName;
          motion.Show();

          }

            if (e.ClickedItem.Text == "机器人设置")
                {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    Rotbot_Set frm = new Rotbot_Set();
                    frm.g_AcqDeviceList = Solution.s_Instance.g_RobotDeviceList;
                    frm.ShowDialog();

                    // List<RobotServiceBase>  m_gDeviceList =frm.g_AcqDeviceList;
                    Form_Robot motion = new Form_Robot();
					frm.Robotdevice_.mainwindow = this;//仿真停靠的父类窗体
					motion.Motiondevice_ = frm.Robotdevice_;
                    motion.Text = frm.Robotdevice_.m_CardName;                
                    motion.Show();
                  

                }

            if (e.ClickedItem.Text == "权限登录")
            {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                                  
                    if (m_IsLoginOK)
                    {
                        ChangeAdmintorMode();

                        

					}

                    else
                    {

                     UpdateRunninfFormfounction("启动"+ "关闭");
                     
                  /*   RunChangeAdmintorMode();*/
                     //UpdateRunninfFormfounction("关闭");

                     m_IsLoginOK = true;
				     Solution.s_Instance.m_IsLoginOK = true;

					}
                                                      
                }

            if (e.ClickedItem.Text == "全局变量")
            {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    Variable_Set set = new Variable_Set(Solution.s_Instance.g_VariableList);
                    set.ShowDialog();
                }

            if (e.ClickedItem.Text == "网络连接")
            {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    Communication_Set set = new Communication_Set(Solution.s_Instance.g_Com_list);
                    set.ShowDialog();

                }

            if (e.ClickedItem.Text == "停止")
            {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    if (Solution.s_Instance != null)
                    {
                        Solution.StopRun();
                    }

                }

            if (e.ClickedItem.Text == "单步执行")
            {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }

                    if (Solution.s_Instance != null)
                    {
						ProjListRunForm frm = new ProjListRunForm();
						frm.ShowDialog();
					    if (frm.m_bCancel) return;

                       Solution.ExecuteOnce();                    
                    }
                }

            if (e.ClickedItem.Text == "连续执行")
            {
                    if (Solution.s_Instance == null)
                    {
                        Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                        dlg.message = "请先新建项目或者打开项目";
                        dlg.ShowDialog();
                        return;
                    }
                    if (Solution.s_Instance != null)
                    {
						ProjListRunForm frm = new ProjListRunForm();
						frm.ShowDialog();
						if (frm.m_bCancel) return;

						Solution.StartRun();
                    }

                }

            if (e.ClickedItem.Text == "关于")
                {
                    FrmAbout form_ = new FrmAbout();
                    form_.ShowDialog();
                }

            if (e.ClickedItem.Text == "智能语音")
            {
                FrmSpeech frm = new FrmSpeech();

                frm.Show();
                
                
                
            }

            Log.Info(e.ClickedItem.Text+" RunOK "+DateTime.Now.ToString("f"));
           
                base.toolStrip1_ItemClicked(sender, e);

            }//try

            catch (Exception ex){ MessageBox.Show(ex.ToString()) ; Log.Info(ex.Message + DateTime.Now.ToString("f")); }
        }

        /// <summary>
        /// 菜单栏没有用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            base.menuStrip2_ItemClicked(sender, e);

            try {
               
                e.ClickedItem.Click += ClickedItem_Click;
              

            } catch (Exception ex){ ex.ToString(); }

        }
        /// <summary>
        /// 菜单栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void menuStrip2_SubItemClicked(object sender, EventArgs e)
        {
                     
            if (sender.ToString() == "新建项目")
            {
				if (Solution.s_Instance == null)
				{
					//先清理TabPage
					m_MainShow.m_SolutionView.m_ProjectTabList.Clear();

					FlowUC m_flowuc = new FlowUC();
					Solution.s_Instance = new Solution();
					int id = Solution.s_Instance.CreateProject(m_flowuc.skinTreeView1);
					m_CurrentProjid = id;
					m_MainShow.m_SolutionView.AddProjectTab(Solution.GetProjectById(id));
					Solution.GetProjectById(m_CurrentProjid).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
					// m_flowuc.m_Project = Solution.s_Instance.m_ProjectList[id];
					// Solution.s_Instance.NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
					// flowUC1.skinTreeView1.BackColor = Color.LightSkyBlue;
					//  flowUC1.skinTreeView1.Nodes.Clear();
					// m_Proj = Solution.s_Instance.m_ProjectList[0];
					ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[0];
					Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1 = m_MainShow.m_SolutionView.CurrentFlow.skinTreeView1;

				}
				else
				{
					Core.frmMessageDialog dlg = new Core.frmMessageDialog();
					dlg.message = "是否保存当前项目 ? ";
					dlg.ShowDialog();

					if (dlg.dlgResult=="确定")
					{
						string files;
						if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
						{
							files = saveProjectFileDialog.FileName;
							try
							{
								FilesProject = "";
								Solution.SaveData(files, Solution.s_Instance);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message, "保存文件出错！");
							}
							toolStripStatusLabel7.Text = files;
						}
					}


					Solution.s_Instance.Dispose();

					//先清理TabPage
					m_MainShow.m_SolutionView.m_ProjectTabList.Clear();
					//先清理TabPage
					m_MainShow.m_SolutionView.tabProject.TabPages.Clear();

					Solution.s_Instance.CloseProject();
					Solution.s_Instance = new Solution();

					FlowUC m_flowuc = new FlowUC();
					int id = Solution.s_Instance.CreateProject(m_flowuc.skinTreeView1);
					m_CurrentProjid = id;
					m_MainShow.m_SolutionView.AddProjectTab(Solution.GetProjectById(m_CurrentProjid));
					Solution.GetProjectById(m_CurrentProjid).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem); ;
					//flowUC1.skinTreeView1.BackColor = Color.LightSkyBlue;
					//flowUC1.skinTreeView1.Nodes.Clear();
					ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[m_CurrentProjid];
				}
			}

            if (sender.ToString() == "打开项目")
            {

				try
				{
					openFileDialog1.Filter = "程序|*.cfg;|图片|*.gif;*.jpg;*.jpeg;*.bmp;*.jfif;*.png;|word文档|*.doc;|Excel文档|*.xls;*.xlsx;";
					if (openFileDialog1.ShowDialog() == DialogResult.OK)
					{
						RunningForm frm = new RunningForm();
						frm.TopLevel = true;
						frm.TopMost = true;
						frm.Show();

						string str = openFileDialog1.FileName;
						openFileDialog1.InitialDirectory = str;

						toolStripStatusLabel2.Text = "项目名称:" + openFileDialog1.SafeFileName;
						toolStripStatusLabel7.Text = str;

						//先清理TabPage
						m_MainShow.m_SolutionView.m_ProjectTabList.Clear();
						//先清理TabPage
						try
						{

							m_MainShow.m_SolutionView.tabProject.TabPages.Clear();//

						}
						catch (Exception ex) { Console.WriteLine(ex.ToString()); }

						FilesProject = str;//项目名称

						if (Solution.s_Instance != null)
						{
							Solution.s_Instance.CloseProject();
						}
						Solution.IsStop = true;
						Solution.s_Instance = Solution.ReadData(str);
						Solution.s_Instance.InitDevStatus();

						ServiceModule.Instance.m_obProj = Solution.s_Instance.m_ProjectList[0];//第一个流程作为当前选择
						m_Proj = (Project)ServiceModule.Instance.m_obProj;

						foreach (Project proj in Solution.s_Instance.m_ProjectList)
						{
							if (proj == null)
								return;

							m_MainShow.m_SolutionView.AddProjectTab(proj);
							ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList.Find(e2 => e2.ProjectInfo.ProjectName == proj.ProjectInfo.ProjectName);
							proj.skinTreeView1 = projtab.ModelFlow.skinTreeView1;

							if (proj.treeNodeslist.Count > 0)
							{
								proj.skinTreeView1.Nodes.Clear();
								foreach (TreeNode node in proj.treeNodeslist)
								{
									proj.skinTreeView1.Nodes.Add(node);
								}
							}

							proj.skinTreeView1.ExpandAll();
							proj.NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);

						}

						m_CurrentProjid = 0;//当前流程代号

						//显示窗体数量
						int n = Solution.s_Instance.curScreenNum;
						if (n >= 0)
						{
							Solution.s_Instance.curScreenNum = n;
							m_MainShow.Form_set(n);
						}
						filehandler.AddRecentFile(openFileDialog1.FileName);
						// Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1.BackColor = Color.SpringGreen;
						// Solution.s_Instance.m_ProjectList[m_CurrentProjid].skinTreeView1.ExpandAll();
						//ServiceModule.Instance.ReadConfig(str);
						//                             if (ServiceModule.Instance.treeNodeslist == null)
						//                                 return;
						//                             if (ServiceModule.Instance.treeNodeslist.Count > 0)
						//                             {
						//                                 flowUC1.skinTreeView1.Nodes.Clear();
						//                                 foreach (TreeNode node in ServiceModule.Instance.treeNodeslist)
						//                                 {
						//                                     flowUC1.skinTreeView1.Nodes.Add(node);
						//                                 }
						//                             }
						//                         flowUC1.skinTreeView1.ExpandAll();
						//                         ServiceModule.Instance.m_obTreeView = flowUC1.skinTreeView1;
						//                         flowUC1.m_Project = (Project)ServiceModule.Instance.m_obProj;
						//                         


						frm.Close();

					}

					if (Solution.s_Instance.m_IsLoginOK)
					{
						ChangeAdmintorMode();
						m_IsLoginOK = false; Solution.s_Instance.m_IsLoginOK = false;
					}
				}
				catch (Exception ex)
				{
					m_IsLoginOK = true; Solution.s_Instance.m_IsLoginOK = true;
					frm.Close();
					Core.frmMessageDialog dlg = new Core.frmMessageDialog();
					dlg.message = ex.ToString();
					dlg.ShowDialog();
				}

            }

            if (sender.ToString() == "保存项目")
            {
				try
				{
					if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					{

						string str = saveFileDialog1.FileName;
						saveFileDialog1.InitialDirectory = str;
						if (str.Contains(".cfg"))
							str = str.Replace(".cfg", "");
						string files = str + ".cfg";
						savepath = files;

						if (Solution.s_Instance != null)
						{
							try
							{
								RunningForm frm = new RunningForm();
								frm.Show();
								FilesProject = "";
								for (int i = 0; i < m_MainShow.m_SolutionView.m_ProjectTabList.Count; i++)
								{
									try
									{

										ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList[i];
										Project proj = Solution.s_Instance.m_ProjectList[i];
										proj.treeNodeslist.Clear();
										foreach (TreeNode node in projtab.ModelFlow.skinTreeView1.Nodes)
										{
											//ServiceModule.Instance.treeNodeslist.Add(node);
											// Project m_pro = (Project)ServiceModule.Instance.m_obProj;
											proj.treeNodeslist.Add(node);
										}
									}
									catch (Exception ex) { Log.Error(ex.ToString()); break; }

								}

								//  m_Proj = (Project)ServiceModule.Instance.m_obProj;
								// Solution.s_Instance.m_ProjectList[m_CurrentProjid] = (Project)ServiceModule.Instance.m_obProj;

								Solution.SaveData(files, Solution.s_Instance);

								string[] str1 = saveFileDialog1.FileName.Split('\\');
								toolStripStatusLabel2.Text = "项目名称:" + str1[str1.Length - 1];
								toolStripStatusLabel7.Text = files;

								frm.Close();

								dlg = new Core.frmMessageDialog();
								dlg.message = "保存成功";
								dlg.ShowDialog();

							}
							catch (Exception ex)
							{
								Console.WriteLine(ex);
								dlg = new Core.frmMessageDialog();
								dlg.message = "保存文件出错!!!!!!!!!!!" + "\r\n" + ex.ToString();
								dlg.ShowDialog();
								return;
							}

						}


						//                         object ob = ServiceModule.Instance.m_obTreeView;
						//                         SkinTreeView skinTreeView1 = (SkinTreeView)ob;
						//                         TreeNodeCollection treeNodeCollection = skinTreeView1.Nodes;
						//                         ServiceModule.Instance.treeNodeCollection = treeNodeCollection;
						//                         ServiceModule.Instance.treeNodeslist.Clear();
						//                         ServiceModule.Instance.Imagelist = new List<int>();

						//                         foreach (TreeNode node in ServiceModule.Instance.treeNodeCollection)
						//                         {
						//                             ServiceModule.Instance.treeNodeslist.Add(node);
						//                         }
						//                        
						//                         ServiceModule.Instance.m_obProj= flowUC1.m_Project;


						//                         if (File.Exists(str))
						//                         {
						//                             File.Delete(str);
						//                             ServiceModule.Instance.SaveConfig(str + ".cfg");
						//                         }
						//                         else
						//                             ServiceModule.Instance.SaveConfig(str + ".cfg");


						//                         ServiceModule.Instance.SaveName = "ProjectConfig";
						//                         ServiceModule.Instance.SaveConfig(ServiceModule.Instance.m_obProj);


					}
				}
				catch (Exception ex)
				{
					dlg = new Core.frmMessageDialog();
					dlg.message = ex.ToString();
					dlg.ShowDialog();
				}
			}

            if (sender.ToString() == "项目另存为")
            {
				try
				{
					if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					{

						string str = saveFileDialog1.FileName;
						saveFileDialog1.InitialDirectory = str;
						if (str.Contains(".cfg"))
							str = str.Replace(".cfg", "");
						string files = str + ".cfg";
						savepath = files;

						if (Solution.s_Instance != null)
						{
							try
							{
								RunningForm frm = new RunningForm();
								frm.Show();
								FilesProject = "";
								for (int i = 0; i < m_MainShow.m_SolutionView.m_ProjectTabList.Count; i++)
								{
									try
									{

										ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList[i];
										Project proj = Solution.s_Instance.m_ProjectList[i];
										proj.treeNodeslist.Clear();
										foreach (TreeNode node in projtab.ModelFlow.skinTreeView1.Nodes)
										{
											//ServiceModule.Instance.treeNodeslist.Add(node);
											// Project m_pro = (Project)ServiceModule.Instance.m_obProj;
											proj.treeNodeslist.Add(node);
										}
									}
									catch (Exception ex) { Log.Error(ex.ToString()); break; }

								}

								//  m_Proj = (Project)ServiceModule.Instance.m_obProj;
								// Solution.s_Instance.m_ProjectList[m_CurrentProjid] = (Project)ServiceModule.Instance.m_obProj;

								Solution.SaveData(files, Solution.s_Instance);

								string[] str1 = saveFileDialog1.FileName.Split('\\');
								toolStripStatusLabel2.Text = "项目名称:" + str1[str1.Length - 1];
								toolStripStatusLabel7.Text = files;

								frm.Close();

								dlg = new Core.frmMessageDialog();
								dlg.message = "保存成功";
								dlg.ShowDialog();

							}
							catch (Exception ex)
							{
								Console.WriteLine(ex);
								dlg = new Core.frmMessageDialog();
								dlg.message = "保存文件出错!!!!!!!!!!!" + "\r\n" + ex.ToString();
								dlg.ShowDialog();
								return;
							}

						}


						//                         object ob = ServiceModule.Instance.m_obTreeView;
						//                         SkinTreeView skinTreeView1 = (SkinTreeView)ob;
						//                         TreeNodeCollection treeNodeCollection = skinTreeView1.Nodes;
						//                         ServiceModule.Instance.treeNodeCollection = treeNodeCollection;
						//                         ServiceModule.Instance.treeNodeslist.Clear();
						//                         ServiceModule.Instance.Imagelist = new List<int>();

						//                         foreach (TreeNode node in ServiceModule.Instance.treeNodeCollection)
						//                         {
						//                             ServiceModule.Instance.treeNodeslist.Add(node);
						//                         }
						//                        
						//                         ServiceModule.Instance.m_obProj= flowUC1.m_Project;


						//                         if (File.Exists(str))
						//                         {
						//                             File.Delete(str);
						//                             ServiceModule.Instance.SaveConfig(str + ".cfg");
						//                         }
						//                         else
						//                             ServiceModule.Instance.SaveConfig(str + ".cfg");


						//                         ServiceModule.Instance.SaveName = "ProjectConfig";
						//                         ServiceModule.Instance.SaveConfig(ServiceModule.Instance.m_obProj);


					}
				}
				catch (Exception ex)
				{
					dlg = new Core.frmMessageDialog();
					dlg.message = ex.ToString();
					dlg.ShowDialog();
				}
			}

            if (sender.ToString() == "打开最近项目")
            {
                base.menuStrip2_SubItemClicked(sender, e); }

            if (sender.ToString() == "退出程序")
            {			
				try
				{
					Core.frmMessageDialog dig = new Core.frmMessageDialog();
					dig.message = "是否要关闭系统";					
				    dig.ShowDialog();

					if (dig.dlgResult == "确定")
					{

						Core.frmMessageDialog digbaocun = new Core.frmMessageDialog();
						digbaocun.message = "是否要保存界面设计及其他全部数据";
						digbaocun.ShowDialog();

						if (digbaocun.dlgResult == "确定")
						{
							//获取保存路径路径
							if (savepath == "")
							{
								if (saveFileDialog1.ShowDialog() == DialogResult.OK)
								{
									string str = saveFileDialog1.FileName;
									saveFileDialog1.InitialDirectory = str;
									if (str.Contains(".cfg"))
										str = str.Replace(".cfg", "");
									string files = str + ".cfg";
									savepath = files;
								}
							}
							//保存信息
							if (Solution.s_Instance != null)
							{
								try
								{
									FilesProject = "";
									for (int i = 0; i < m_MainShow.m_SolutionView.m_ProjectTabList.Count; i++)
									{
										try
										{

											ProjectTab projtab = m_MainShow.m_SolutionView.m_ProjectTabList[i];
											Project proj = Solution.s_Instance.m_ProjectList[i];
											proj.treeNodeslist.Clear();
											foreach (TreeNode node in projtab.ModelFlow.skinTreeView1.Nodes)
											{
												//ServiceModule.Instance.treeNodeslist.Add(node);
												// Project m_pro = (Project)ServiceModule.Instance.m_obProj;
												proj.treeNodeslist.Add(node);
											}
										}
										catch (Exception ex) { Log.Error(ex.ToString()); break; }

									}

									//  m_Proj = (Project)ServiceModule.Instance.m_obProj;
									// Solution.s_Instance.m_ProjectList[m_CurrentProjid] = (Project)ServiceModule.Instance.m_obProj;

									Solution.SaveData(savepath, Solution.s_Instance);

									string[] str1 = saveFileDialog1.FileName.Split('\\');
									toolStripStatusLabel2.Text = "项目名称:" + str1[str1.Length - 1];
									toolStripStatusLabel7.Text = savepath;

									dlg = new Core.frmMessageDialog();
									dlg.message = "保存成功";
									dlg.ShowDialog();

								}
								catch (Exception ex)
								{
									Console.WriteLine(ex);
									dlg = new Core.frmMessageDialog();
									dlg.message = "保存文件出错!!!!!!!!!!!" + "\r\n" + ex.ToString();
									dlg.ShowDialog();
									return;
								}

							}

						}

						/******************关闭软件系统*****************/
						backgroundWorker1.RunWorkerAsync();

						Solution.s_Instance.m_bApplicationExit = true;

						if (Solution.s_Instance != null)
						{
							Solution.s_Instance.CloseProject();
						}

						Thread.Sleep(500);
						m_MainShow.Close();

						backgroundWorker1.CancelAsync();

						Thread.Sleep(1000);
					}
					else
					{
						Log.Info("窗体关闭取消");
					}
					
				}
				catch (Exception ex) { m_MainShow.Close();  Console.WriteLine(ex.ToString()); Log.Error(ex.ToString()); }
			}

            if (sender.ToString() == "默认布局") { m_MainShow.show_默认布局();}
            if (sender.ToString() == "保存布局") { m_MainShow.show_布局保存();}
            if (sender.ToString() == "流程栏") { m_MainShow.show_流程框();}
            if (sender.ToString() == "工具栏") { m_MainShow.show_工具框();}
            if (sender.ToString() == "数据栏") { m_MainShow.show_数据显示框();}
            if (sender.ToString() == "日志栏") { m_MainShow.show_日志显示框();}
            if (sender.ToString() == "图像显示") {m_MainShow.show_图像显示框();}
            if (sender.ToString() == "模块信息") { m_MainShow.show_模块信息();}
            if (sender.ToString() == "通讯监视") { m_MainShow.show_通讯监视();}

            if (sender.ToString() == "开机启用")
            {
                if (Solution.s_Instance.m_StartUpRun)
                //此方法把启动项加载到注册表中
                //获得应用程序路径
                {
                    string strAssName = Application.StartupPath + @"\" + Application.ProductName + @".exe";
                    //获得应用程序名
                    string ShortFileName = Application.ProductName;
                    RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (rgkRun == null)
                    {
                        rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    }
                    rgkRun.SetValue(ShortFileName, strAssName);
                    Solution.s_Instance.m_StartUpRun = false;
                    
                }
                else
                {
                    //此删除注册表中启动项
                    //获得应用程序名
                    string ShortFileName = Application.ProductName;
                    RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (rgkRun == null)
                    {
                        rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    }
                    rgkRun.DeleteValue(ShortFileName, false);

                    Solution.s_Instance.m_StartUpRun = true;
                }

            }
            if (sender.ToString() == "解决方案初始路径") { }

            if (sender.ToString() == "采集设备")
            {
                if (Solution.s_Instance == null)
                {
                    Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                    dlg.message = "请先新建项目或者打开项目";
                    dlg.ShowDialog();
                    return;
                }
                RunningForm form1 = new RunningForm();
                form1.BringToFront();
                form1.Show();

                Cameras_Set set_ = new Cameras_Set();
                set_.g_AcqDeviceList = Solution.s_Instance.g_AcqDeviceList;
                set_.Show();

                form1.Close();
            }
            if (sender.ToString() == "通讯设备")
            {
                if (Solution.s_Instance == null)
                {
                    Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                    dlg.message = "请先新建项目或者打开项目";
                    dlg.ShowDialog();
                    return;
                }
                Communication_Set set = new Communication_Set(Solution.s_Instance.g_Com_list);
                set.ShowDialog();

            }
            if (sender.ToString() == "全局变量")
            {
                if (Solution.s_Instance == null)
                {
                    Core.frmMessageDialog dlg = new Core.frmMessageDialog();
                    dlg.message = "请先新建项目或者打开项目";
                    dlg.ShowDialog();
                    return;
                }
                Variable_Set set = new Variable_Set(Solution.s_Instance.g_VariableList);
                set.ShowDialog();
            }
            if (sender.ToString() == "图像窗口设置")
            {
                if (Solution.s_Instance == null) { OpenCVModuleUC.frmMessageDialog dlg = new OpenCVModuleUC.frmMessageDialog(); dlg.message = "请先建好项目或者加载项目";dlg.Show(); return; }
//                 tabControl1.Hide();
//                 flowUC1.Hide();
//                 moduleUC1.Hide();
                rtfRichTextBox1.Hide();

                m_MainShow.TopLevel = false;             
                m_MainShow.TopMost = true;
                m_MainShow.Dock = DockStyle.Fill;
                m_MainShow.Show(); 

                SetWindow();
                m_MainShow.show_图像显示框();

            }
            if (sender.ToString() == "静态单相机模式")
            {
                m_MainShow.TopLevel = false;
                m_MainShow.TopMost = true;
                m_MainShow.Dock = DockStyle.Fill;
                m_MainShow.Hide();

//                 tabControl1.Show();
//                 flowUC1.Show();
//                 moduleUC1.Show();
                rtfRichTextBox1.Show();
                ServiceModule.Instance.RunningMode = "静态单相机模式";
            }
            if (sender.ToString() == "动态多相机模式")
            {
//                 tabControl1.Hide();
//                 flowUC1.Hide();
//                 moduleUC1.Hide();
                rtfRichTextBox1.Hide();

                m_MainShow.TopLevel = false;
                m_MainShow.TopMost = true;
                m_MainShow.Dock = DockStyle.Fill;
                m_MainShow.Visible = true;
                m_MainShow.Show();


                m_MainShow.show_工具框();

                m_MainShow.show_图像显示框();

                m_MainShow.show_日志显示框();

                m_MainShow.show_流程框();

                ServiceModule.Instance.RunningMode = "动态多相机模式";


            }
            if (sender.ToString() == "启用GPU")
            {
                HandleUnit = "GPU";

            }
            if (sender.ToString() == "启用CPU")
            {
                HandleUnit = "CPU";

            }
            if (sender.ToString() == "导入") { }
            if (sender.ToString() == "导出") { }

            if (sender.ToString() == "权限管理")
            {
                LoginSetting grm = new LoginSetting();
                grm.Show();
            }
            if (sender.ToString() == "注册延期")
            {
                VertifiedForm frm = new VertifiedForm();
                frm.ShowDialog();
            }

            if (sender.ToString() == "关于XCVision")
            {
                FrmAbout form_ = new FrmAbout();
                form_.ShowDialog();
            }
            if (sender.ToString() == "帮助")
            {
                 string path= Path.Combine(Application.StartupPath, "非标型拖拽式软件说明书使用手册.pdf");

//                 if (openFileDialog1.ShowDialog() == DialogResult.OK)
//                 {
                    System.Diagnostics.Process.Start(path);
               // }
            }
			if(sender.ToString() != "退出程序")
            base.menuStrip2_SubItemClicked(sender, e);//父类执行代码


        }
        /// <summary>
        /// meiyoushiyong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickedItem_Click(object sender, EventArgs e)
        {
          
           
        }

        /// <summary>
        /// 自定义控件按键响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ctrl_Click(object sender, EventArgs e)
        {
           Control con=(Control)sender;
            if (sender.GetType().FullName == "System.Windows.Forms.Button")
            {
                string tag= (string)con.Tag;
                MessageBox.Show(tag); }


            if (sender.GetType().FullName == "System.Windows.Forms.TextBox")
                MessageBox.Show(sender.GetType().FullName);

        }

        /// <summary>
        /// OpenCV和Halcon切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

//             if(tabControl1.SelectedIndex==0)
//                 ServiceModule.Instance.bRunHalcon = false;//启用OpenCV
// 
//             else if(tabControl1.SelectedIndex==1)
//                 ServiceModule.Instance.bRunHalcon = true;//启动halcon

             Log.Info(e.GetType().Name +" "+ DateTime.Now.ToString("f"));

        }

        /// <summary>
        /// 接收flow窗体切换流程的时候发过来的消息
        /// 
        /// </summary>
        private void UpdatetabProjectSelectedIndex(int index)
        {
            m_CurrentFlowIndex = index;

            for(int i=0;i< Solution.s_Instance.m_ProjectList.Count;i++)
            {
                if (Solution.GetProjectById(i) != null)
                {
                    if(i== index)
                    {
                        Solution.GetProjectById(i).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
                        Solution.GetProjectById(i).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
                    }
                    else
                    Solution.GetProjectById(i).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);

                }
                Application.DoEvents();
                Thread.Sleep(2);
            }

            //             switch(m_CurrentFlowIndex)
            //             {
            //                 case 0:
            //                     if(Solution.GetProjectById(1)!=null)
            //                     Solution.GetProjectById(1).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(2) != null)
            //                         Solution.GetProjectById(2).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(3) != null)
            //                         Solution.GetProjectById(3).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(4) != null)
            //                         Solution.GetProjectById(4).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            // 
            //                     Solution.GetProjectById(index).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     Solution.GetProjectById(index).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                 
            //                     break;
            //                 case 1:
            //                     if (Solution.GetProjectById(0) != null)
            //                         Solution.GetProjectById(0).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(2) != null)
            //                         Solution.GetProjectById(2).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(3) != null)
            //                         Solution.GetProjectById(3).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(4) != null)
            //                         Solution.GetProjectById(4).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            // 
            //                     Solution.GetProjectById(index).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem2);
            //                     Solution.GetProjectById(index).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem2);
            //                     break;
            //                 case 2:
            //                     if (Solution.GetProjectById(0) != null)
            //                         Solution.GetProjectById(0).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(1) != null)
            //                         Solution.GetProjectById(1).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(3) != null)
            //                         Solution.GetProjectById(3).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(4) != null)
            //                         Solution.GetProjectById(4).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     Solution.GetProjectById(index).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem3);
            //                     Solution.GetProjectById(index).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem3);
            //                     break;
            //                 case 3:
            //                     if (Solution.GetProjectById(0) != null)
            //                         Solution.GetProjectById(0).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(2) != null)
            //                         Solution.GetProjectById(2).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(1) != null)
            //                         Solution.GetProjectById(1).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(4) != null)
            //                         Solution.GetProjectById(4).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     Solution.GetProjectById(index).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem4);
            //                     Solution.GetProjectById(index).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem4);
            //                     break;
            //                 case 4:
            //                     if (Solution.GetProjectById(0) != null)
            //                         Solution.GetProjectById(0).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(2) != null)
            //                         Solution.GetProjectById(2).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(3) != null)
            //                         Solution.GetProjectById(3).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            //                     if (Solution.GetProjectById(1) != null)
            //                         Solution.GetProjectById(1).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem);
            // 
            //                     Solution.GetProjectById(index).NotifyRefreshItem -= new Core.RefreshItem(NotifyUpdateRefreshItem5);
            //                     Solution.GetProjectById(index).NotifyRefreshItem += new Core.RefreshItem(NotifyUpdateRefreshItem5);
            //                     break;
            //             }


        }

        /// <summary>
        /// 关闭完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            from.Close();
           
        }
        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {         
            UpdateClosdFormfounction();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke(NotifyUpdateRunnigForm, "关闭");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            do
            {

                //this.BeginInvoke(NotifyUpdateRunnigForm, "启动");
                if (m_bRunning)
                { this.BeginInvoke(NotifyChangeMainPanel); m_bRunning = false; }

//                 else if (m_bRunningClosing)
//                 { this.BeginInvoke(NotifyUpdateRunnigForm, "关闭"); m_bRunningClosing = false; }
                else
                Thread.Sleep(50);

            } while (!backgroundWorker2.CancellationPending);

        }

        #endregion

        #region 委派消息
        delegate void UpdateOpenCVImage(object image);
        UpdateOpenCVImage NotifyUpdateOpenCVImage;


        delegate void UpdateFlowRefresh(string name,object  ob);
        UpdateFlowRefresh NotifyUpdateFlowRefresh;

        delegate void UpdateFlowRefresh2(string name, object ob);
        UpdateFlowRefresh NotifyUpdateFlowRefresh2;
        delegate void UpdateFlowRefresh3(string name, object ob);
        UpdateFlowRefresh NotifyUpdateFlowRefresh3;
        delegate void UpdateFlowRefresh4(string name, object ob);
        UpdateFlowRefresh NotifyUpdateFlowRefresh4;
        delegate void UpdateFlowRefresh5(string name, object ob);
        UpdateFlowRefresh NotifyUpdateFlowRefresh5;

        delegate void UpdateRunnigForm(string name);
        UpdateRunnigForm NotifyUpdateRunnigForm;

        delegate void UpdateShowMutipuleCamMode(string str);
        UpdateShowMutipuleCamMode NotifyUpdateShowMutipuleCamMode;

        #endregion

        #region 消息响应函数

        /// <summary>
        /// 刷新条目
        /// </summary>
        private void UpdateflowRefresh(string name,object ob)
        {
           string[] time= name.Split('_');
           string timename = "  "+time[1] + "ms";
           string state= " " + time[2];
           string remark= "  " + time[3];

           TreeView view= Solution.GetProjectById(m_CurrentFlowIndex).skinTreeView1;
           TreeNode node=(TreeNode)ob;
           Rectangle rectangle = node.Bounds;
           rectangle.Width = 250;            
           rectangle.X = node.Bounds.X-30;
		  

			if (state==" OK")
            {
				view.CreateGraphics().FillRectangle(new SolidBrush(Color.Green), rectangle);
				view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                
                Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                rectangle.Width = 150;

				rectangle.Y = node.Bounds.Y + 5;

				view.CreateGraphics().DrawString(node.Text, foreFont, new SolidBrush(Color.Black), rectangle);
                Font foreFont2 = new Font("宋体", 9F, FontStyle.Bold);
                rectangle.Width = 170;
                rectangle.X = 140;
			
				view.CreateGraphics().DrawString(remark + "\r\n" + timename, foreFont2, new SolidBrush(Color.Black), rectangle);              
            }
            if (state == " NG")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);

                Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                rectangle.Width = 80;
				rectangle.Y = node.Bounds.Y + 5;
				view.CreateGraphics().DrawString(node.Text, foreFont, new SolidBrush(Color.Black), rectangle);
                Font foreFont2 = new Font("宋体", 9F, FontStyle.Bold);
                rectangle.Width = 120;
                rectangle.X = 120;
                //rectangle.Y = 2;
                view.CreateGraphics().DrawString(remark + "\r\n" + timename, foreFont2, new SolidBrush(Color.Black), rectangle);

                // Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                // view.CreateGraphics().DrawString(node.Text + " 备注" + "\r\n" + timename , foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " None")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                rectangle.Width = 80;
				rectangle.Y = node.Bounds.Y + 5;
				view.CreateGraphics().DrawString(node.Text, foreFont, new SolidBrush(Color.Black), rectangle);

                Font foreFont2 = new Font("宋体", 9F, FontStyle.Bold);
                rectangle.Width = 120;
                rectangle.X = 120;
                rectangle.Y = 2;
                view.CreateGraphics().DrawString(remark + "\r\n" + timename, foreFont2, new SolidBrush(Color.Black), rectangle);
                // Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                // view.CreateGraphics().DrawString(node.Text + " 备注" + "\r\n" + timename , foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NoImage")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                rectangle.Width = 80;
				rectangle.Y = node.Bounds.Y + 5;
				view.CreateGraphics().DrawString(node.Text, foreFont, new SolidBrush(Color.Black), rectangle);

                Font foreFont2 = new Font("宋体", 9F, FontStyle.Bold);
                rectangle.Width = 120;
                rectangle.X = 120;
               // rectangle.Y = 2;
                view.CreateGraphics().DrawString(remark + "\r\n" + timename, foreFont2, new SolidBrush(Color.Black), rectangle);
                // Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                // view.CreateGraphics().DrawString(node.Text + " 备注"+ "\r\n" + timename , foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " Start")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.MediumBlue), rectangle);

                Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                rectangle.Width = 80;

				rectangle.Y = node.Bounds.Y + 5;

				view.CreateGraphics().DrawString(node.Text, foreFont, new SolidBrush(Color.Black), rectangle);

                Font foreFont2 = new Font("宋体", 9F, FontStyle.Bold);
                rectangle.Width = 120;
                rectangle.X = 120;
            
                view.CreateGraphics().DrawString(remark + "\r\n" + timename, foreFont2, new SolidBrush(Color.Black), rectangle);

                // Font foreFont = new Font("宋体", 10F, FontStyle.Bold);
                // view.CreateGraphics().DrawString(node.Text +" 备注"+ "\r\n" + ".....", foreFont, new SolidBrush(Color.Black), rectangle);
            }


        }

        /// <summary>
        /// 刷新条目
        /// </summary>
        private void UpdateflowRefresh2(string name, object ob)
        {
            string[] time = name.Split('_');
            string timename = "  " + time[1] + "ms";
            string state = " " + time[2];
            string remark = "  " + time[3];
            TreeView view = Solution.GetProjectById(m_CurrentFlowIndex).skinTreeView1;
            TreeNode node = (TreeNode)ob;
            Rectangle rectangle = node.Bounds;
            rectangle.Width = 170;
            rectangle.X = node.Bounds.X - 30;
            if (state == " OK")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Green), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NG")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " None")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NoImage")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }

            if (state == " Start")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.MediumBlue), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + ".....", foreFont, new SolidBrush(Color.Black), rectangle);
            }
        }

        /// <summary>
        /// 刷新条目
        /// </summary>
        private void UpdateflowRefresh3(string name, object ob)
        {
            string[] time = name.Split('_');
            string timename = "  " + time[1] + "ms";
            string state = " " + time[2];
            string remark = "  " + time[3];
            TreeView view = Solution.GetProjectById(m_CurrentFlowIndex).skinTreeView1;
            TreeNode node = (TreeNode)ob;
            Rectangle rectangle = node.Bounds;
            rectangle.Width = 170;
            rectangle.X = node.Bounds.X - 30;
            if (state == " OK")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Green), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NG")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " None")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NoImage")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }

            if (state == " Start")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.MediumBlue), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + ".....", foreFont, new SolidBrush(Color.Black), rectangle);
            }
        }

        /// <summary>
        /// 刷新条目
        /// </summary>
        private void UpdateflowRefresh4(string name, object ob)
        {
            string[] time = name.Split('_');
            string timename = "  " + time[1] + "ms";
            string state = " " + time[2];
            string remark = "  " + time[3];

            TreeView view = Solution.GetProjectById(m_CurrentFlowIndex).skinTreeView1;
            TreeNode node = (TreeNode)ob;
            Rectangle rectangle = node.Bounds;
            rectangle.Width = 170;
            rectangle.X = node.Bounds.X - 30;
            if (state == " OK")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Green), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NG")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " None")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NoImage")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }

            if (state == " Start")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.MediumBlue), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + ".....", foreFont, new SolidBrush(Color.Black), rectangle);
            }
        }

        /// <summary>
        /// 刷新条目
        /// </summary>
        private void UpdateflowRefresh5(string name, object ob)
        {
            string[] time = name.Split('_');
            string timename = "  " + time[1] + "ms";
            string state = " " + time[2];
            string remark = "  " + time[3];

            TreeView view = Solution.GetProjectById(m_CurrentFlowIndex).skinTreeView1;
            TreeNode node = (TreeNode)ob;
            Rectangle rectangle = node.Bounds;
            rectangle.Width = 170;
            rectangle.X = node.Bounds.X - 30;
            if (state == " OK")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Green), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NG")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " None")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }
            if (state == " NoImage")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.Red), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + timename, foreFont, new SolidBrush(Color.Black), rectangle);
            }

            if (state == " Start")
            {
                view.CreateGraphics().DrawRectangle(new Pen(Color.Black), rectangle);
                view.CreateGraphics().FillRectangle(new SolidBrush(Color.MediumBlue), rectangle);
                Font foreFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                view.CreateGraphics().DrawString(node.Text + ".....", foreFont, new SolidBrush(Color.Black), rectangle);
            }
        }

        /// <summary>
        /// 界面关闭
        /// </summary>
        private void UpdateClosdFormfounction()
        {
            from = new ClosingForm1();
            from.ShowDialog();
        }


        /// <summary>
        /// 正在加载界面
        /// </summary>
        private void WaitingBoxf()
        {
            f = new frmWaitingBox((obj, args) =>
            {
             
                Thread.Sleep(1000);
            }, 10000, "准备加载...", true, true);       
            f.ShowDialog(this);

        }

        /// <summary>
        /// 没有使用
        /// </summary>
        private void WaitingBoxDoing()
        {
            ChangeOperaMode();

        }
        /// <summary>
        /// 切换界面
        /// </summary>
        private void UpdateRunninfFormfounction(string str)
        {
           
//             if (str=="启动")
//             {
                //NotifyUpdateWaitingBox += new UpdateWaitingBox(WaitingBoxDoing);
                //this.BeginInvoke(NotifyUpdateWaitingBox);
                // WaitingBoxf();
                // RunChangeAdmintorMode();
            
                    frm = new RunningForm();
                    frm.FormBorderStyle = FormBorderStyle.None;
				    frm.Shown += this.UpdateRunninfFormFrm_Shown;
					frm.ShowDialog();
//             }
//             else
//             {
// 
//                 frm.Close();
//              
//             }
        }

		/// <summary>
		/// 切换界面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateRunninfFormFrm_Shown(object sender, EventArgs e)
		{

			RunChangeAdmintorMode();
			frm.Close();

		}

		/// <summary>
		/// OpenCV相应函数
		/// </summary>
		/// <param name="image"></param>
		private void UpdateNotifyItemRefresh(string name, object ob)
        {

            //添加矩形框
            TreeNode node = (TreeNode)ob;
            Rectangle rectangle = node.Bounds;
           // flowUC1. skinTreeView1.Refresh();
          //  flowUC1.skinTreeView1.CreateGraphics().DrawRectangle(new Pen(Color.DeepSkyBlue), rectangle);
           // flowUC1.skinTreeView1.Refresh();
        }

        /// <summary>
        /// 操作员界面
        /// </summary>
        /// <param name="image"></param>
        private void UpdateNotifyOpenCVImage(object image)
        {
            try {
                if (!m_IsLoginOK)
                {

                    //pictureShowUC1.InitialPicture(image);
                    //Console.WriteLine("XCVisionForm.cs 1785行,该处为空");

                }

                else
                {
                    MyFormDesinger.StructInfo.Instance = (MyFormDesinger.StructInfo)Solution.s_Instance.m_ControlDesignInfo;

                    foreach (Control con in windowss.Controls)
                    {
						string name = con.GetType().FullName;
						string[] strs = new string[2];
						try
						{

							if (name.Contains("."))
							{
								strs = name.Split('.');
							}
							else
								strs[1] = name;

							if (strs[1].Equals("HWindowControlUC"))
							{
								HWindowControlUC conuc = (HWindowControlUC)con;
								string tag = (string)con.Tag;//获取对应流程的模块名称
								string[] tagss = tag.Split(':');
								Project proj = Solution.s_Instance.m_ProjectList.Find(e2 => e2.ProjectInfo.ProjectName == tagss[0]);
								F_CELL_DATA datas = proj.ModuleObjList[0].m_VariableList.Find(e2 => e2.m_Module_Name == tagss[1]);
								object moduleVal = datas.m_Data_Value;
								string str = moduleVal.GetType().Name;

								if (str == "Bitmap")
								{
									HWindowControlUC uc = (HWindowControlUC)con;
									uc.SizeMode = PictureBoxSizeMode.StretchImage;
									Bitmap bp = (Bitmap)moduleVal;
									uc.Image = bp;
								}
								if (str == "HImageExt")
								{
									HWindowControlUC uc = (HWindowControlUC)con;
									uc.SizeMode = PictureBoxSizeMode.StretchImage;
									//Bitmap bp = (Bitmap)m_image.m_image;
									//HImage m_OutImage = (HImage)m_image.m_image; Bitmap img;
									HImageExt m_OutImage = (HImageExt)moduleVal;
									Bitmap img;
									if (m_OutImage.CountChannels().I > 1)
										m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out img);
									else
										m_BitmapImgProcess.Hobject8Bpp_aboveFramework4(m_OutImage, out img);
									uc.Image = img;
								}


							}

							else if (strs[1].Equals("PictureBoxUC"))
							{
								PictureBoxUC conuc = (PictureBoxUC)con;
								string tag = (string)con.Tag;//获取对应流程的模块名称
								string[] tagss = tag.Split(':');
								Project proj = Solution.s_Instance.m_ProjectList.Find(e2 => e2.ProjectInfo.ProjectName == tagss[0]);
								F_CELL_DATA datas = proj.ModuleObjList[0].m_VariableList.Find(e2 => e2.m_Module_Name == tagss[1]);
								object moduleVal = datas.m_Data_Value;
								string str = moduleVal.GetType().Name;

								if (str == "Bitmap")
								{
									HWindowControlUC uc = (HWindowControlUC)con;
									uc.SizeMode = PictureBoxSizeMode.StretchImage;
									Bitmap bp = (Bitmap)moduleVal;
									uc.Image = bp;
								}
								if (str == "HImageExt")
								{
									HWindowControlUC uc = (HWindowControlUC)con;
									uc.SizeMode = PictureBoxSizeMode.StretchImage;
									//Bitmap bp = (Bitmap)m_image.m_image;
									//HImage m_OutImage = (HImage)m_image.m_image; Bitmap img;
									HImageExt m_OutImage = (HImageExt)moduleVal;
									Bitmap img;
									if (m_OutImage.CountChannels().I > 1)
										m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out img);
									else
										m_BitmapImgProcess.Hobject8Bpp_aboveFramework4(m_OutImage, out img);
									uc.Image = img;
								}

							}

							else if (strs[1].Equals("HViewUC"))
							{

								HViewUC conuc = (HViewUC)con;
								string tag = (string)con.Tag;//获取对应流程的模块名称
								string[] tagss = tag.Split(':');
								Project proj = Solution.s_Instance.m_ProjectList.Find(e2 => e2.ProjectInfo.ProjectName == tagss[0]);
								F_CELL_DATA datas = proj.ModuleObjList[0].m_VariableList.Find(e2 => e2.m_Module_Name == tagss[1]);
								object moduleVal = datas.m_Data_Value;
								string str = moduleVal.GetType().Name;

								if (str == "Bitmap")
								{
									HViewUC uc = (HViewUC)con;
									//uc.SizeMode = PictureBoxSizeMode.StretchImage;
									//Bitmap bp = (Bitmap)moduleVal;
									HImageExt m_OutImage = (HImageExt)moduleVal;
									uc.hWindow_Fit1.Image = m_OutImage;
								}
								if (str == "HImageExt")
								{
									HViewUC uc = (HViewUC)con;
									// uc.SizeMode = PictureBoxSizeMode.StretchImage; 
									HImageExt m_OutImage = null;
									if (((HImageExt)moduleVal).IsInitialized())
										m_OutImage = (HImageExt)moduleVal;

									if (uc.hWindow_Fit1.hv_imageExt == null)
										uc.hWindow_Fit1.hv_imageExt = new HImageExt();
									uc.hWindow_Fit1.hv_imageExt.measureROIlist = m_OutImage.measureROIlist;
									uc.hWindow_Fit1.Image = m_OutImage;
									foreach (MeasureROI roi in m_OutImage.measureROIlist)
									{
										if (roi != null && roi.roiType == enMeasureROIType.文字显示.ToString())
										{
											MeasureROIText roiText = (MeasureROIText)roi;
											ShowMsg.set_display_font1(uc.hWindow_Fit1.HWindowID, roiText.size, roiText.font, "false", "false");
											ShowMsg.disp_message1(uc.hWindow_Fit1.HWindowID, roiText.text, "image", roiText.row, roiText.col, roiText.drawColor, "false");
										}
										else
										{
											if (roi != null && roi.hobject.IsInitialized())
											{
												uc.hWindow_Fit1.HWindowID.SetColor(roi.drawColor);
												uc.hWindow_Fit1.HWindowID.DispObj(roi.hobject);
												ShowMsg.set_display_font1(uc.hWindow_Fit1.HWindowID, 30, "Courier", "true", "false");
												ShowMsg.disp_message1(uc.hWindow_Fit1.HWindowID, ModuleState.OK.ToString(), "image", 10, 10, "blue", "false");
											}
										}
									}
								}
								if (str == "HObject")
								{
									HViewUC uc = (HViewUC)con;
									HObject m_OutImage = (HObject)moduleVal;
									//                             Bitmap img;
									//                             if (m_OutImage.CountChannels().I > 1)
									//                                 m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out img);
									//                             else
									//                                 m_BitmapImgProcess.Hobject8Bpp_aboveFramework4(m_OutImage, out img);

									uc.hWindow_Fit1.Image = new HImage(m_OutImage);
								}
							}

							else if (strs[1].Equals("TextBoxUC"))
							{
								TextBoxUC textboxcon = (TextBoxUC)con;

								object infos = Solution.s_Instance.m_ConPropertyInfos;

								Modulenames ConName = MyFormDesinger.StructInfo.Instance.m_AdmintorControllist.Find(e => e.Remark == textboxcon.TextName && e.ControlName == con.Tag.ToString());
								int ProjIndex = Solution.s_Instance.m_ProjectList.FindIndex(e => e.ProjectInfo.ProjectName == textboxcon.ProjName);

								F_CELL_DATA data = Solution.s_Instance.m_ProjectList[ProjIndex].g_VariableList.Find(e => e.m_Module_Name == ConName.Modulename);

								if (data.m_Data_Name == null)
									data = Solution.s_Instance.g_VariableList.Find(e => e.m_Module_Name == ConName.Modulename);

								string linkdata = ConName.LinkData;
								if (linkdata == null) continue;
								int m_GetModuleIndex1 = linkdata.IndexOf('[');
								int m_GetModuleIndex2 = linkdata.IndexOf(']');
								int m_GetDataIndex = linkdata.IndexOf(':');

								string ModuleName = linkdata.Substring(0, m_GetModuleIndex1);
								string ValueIndex = linkdata.Substring(m_GetModuleIndex1 + 1, 1);
								string dataName = linkdata.Substring(m_GetDataIndex + 1, linkdata.Length - (m_GetDataIndex + 1));

								// F_CELL_DATA m_F_CELL_DATA = Solution.s_Instance.m_ProjectList[m_CurrentProjid].g_VariableList.Find(e => e.m_Module_Name == ModuleName);//对应模块数据集合
								F_CELL_DATA m_F_CELL_DATA = data;
								List<F_CELL_DATA> obs = (List<F_CELL_DATA>)m_F_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据
								F_CELL_DATA dataa = obs.Find(e => e.m_Data_Name == dataName);//单个数据名称的数据
								string obtype = dataa.m_Data_Value.GetType().FullName;//数据类型

								object val = null;
								if (obtype == "System.Double[]") { double[] m_datas = (double[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.Int[]") { int[] m_datas = (int[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.String[]") { string[] m_datas = (string[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.object[]") { object[] m_datas = (object[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.Boolean[]") { bool[] m_datas = (bool[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }

								if (obtype == "System.Boolean") { val = dataa.m_Data_Value; bool m_bval = (bool)val; if (m_bval) con.BackColor = Color.Green; else con.BackColor = Color.Red; }
								if (obtype == "System.Int") { val = dataa.m_Data_Value; }
								if (obtype == "System.Double") { val = dataa.m_Data_Value; }
								//if (obtype == "System.String") { val = dataa.m_Data_Value; }
								if (obtype == "System.Int32") { val = dataa.m_Data_Value; }
								if (obtype == "System.String")
								{
									val = dataa.m_Data_Value;

									if (val.ToString().IndexOf('[') >= 0)
									{
										Log.Error("字符包含[");
									}

									if (val.ToString().IndexOf('_') >= 0)
									{
										object vall = val.ToString().Clone();
										string[] vals = vall.ToString().Split('_');
										vall = vals[int.Parse(ValueIndex)];
										val = vall;
									}

								}

								con.Text = val.ToString();//显示

								if (val.ToString().ToLower() == "true" || val.ToString().ToLower() == "false")
								{
									bool m_bval = bool.Parse(val.ToString());
									if (m_bval) con.BackColor = Color.Green; else con.BackColor = Color.Red;
								}

								else if (val.ToString() == "运行中")
									con.BackColor = Color.Blue;

								else if (val.ToString() == "运行成功")
									con.BackColor = Color.Green;

								else if (val.ToString() == "运行错误")
									con.BackColor = Color.Red;

								else
									con.BackColor = Color.White;



							}

							else if (strs[1].Equals("LabelUC"))
							{
								LabelUC textboxcon = (LabelUC)con;
							}

							else if (strs[1].Equals("ProgressBarUC"))
							{
								ProgressBarUC textboxcon = (ProgressBarUC)con;

								object infos = Solution.s_Instance.m_ConPropertyInfos;

								Modulenames ConName = MyFormDesinger.StructInfo.Instance.m_AdmintorControllist.Find(e => e.Remark == textboxcon.TextName && e.ControlName == con.Tag.ToString());
								int ProjIndex = Solution.s_Instance.m_ProjectList.FindIndex(e => e.ProjectInfo.ProjectName == textboxcon.ProjName);

								F_CELL_DATA data = Solution.s_Instance.m_ProjectList[ProjIndex].g_VariableList.Find(e => e.m_Module_Name == ConName.Modulename);

								if (data.m_Data_Name == null)
									data = Solution.s_Instance.g_VariableList.Find(e => e.m_Module_Name == ConName.Modulename);

								string linkdata = ConName.LinkData;
								if (linkdata == null) continue;
								int m_GetModuleIndex1 = linkdata.IndexOf('[');
								int m_GetModuleIndex2 = linkdata.IndexOf(']');
								int m_GetDataIndex = linkdata.IndexOf(':');

								string ModuleName = linkdata.Substring(0, m_GetModuleIndex1);
								string ValueIndex = linkdata.Substring(m_GetModuleIndex1 + 1, 1);
								string dataName = linkdata.Substring(m_GetDataIndex + 1, linkdata.Length - (m_GetDataIndex + 1));

								// F_CELL_DATA m_F_CELL_DATA = Solution.s_Instance.m_ProjectList[m_CurrentProjid].g_VariableList.Find(e => e.m_Module_Name == ModuleName);//对应模块数据集合
								F_CELL_DATA m_F_CELL_DATA = data;
								List<F_CELL_DATA> obs = (List<F_CELL_DATA>)m_F_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据
								F_CELL_DATA dataa = obs.Find(e => e.m_Data_Name == dataName);//单个数据名称的数据
								string obtype = dataa.m_Data_Value.GetType().FullName;//数据类型

								object val = null;
								if (obtype == "System.Double[]") { double[] m_datas = (double[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; textboxcon.Value = (int)val; }
								if (obtype == "System.Int[]") { int[] m_datas = (int[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; textboxcon.Value = (int)val; }
								if (obtype == "System.String[]") { string[] m_datas = (string[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; textboxcon.Value = (int)val; }
								if (obtype == "System.object[]") { object[] m_datas = (object[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; textboxcon.Value = (int)val; }
								if (obtype == "System.Boolean[]") { bool[] m_datas = (bool[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; textboxcon.Value = (int)val; }

								if (obtype == "System.Boolean") { val = dataa.m_Data_Value; bool m_bval = (bool)val; if (m_bval) con.BackColor = Color.Green; else con.BackColor = Color.Red; }
								if (obtype == "System.Int") { val = dataa.m_Data_Value; textboxcon.Value = (int)val; }
								if (obtype == "System.Double") { val = dataa.m_Data_Value; textboxcon.Value = (int)val; }
								
								if (obtype == "System.Int32") { val = dataa.m_Data_Value; textboxcon.Value = (int)val; }

								if (obtype == "System.String")
								{
									val = dataa.m_Data_Value;

									if (val.ToString().IndexOf('[') >= 0)
									{
										Log.Error("字符包含[");
									}

									if (val.ToString().IndexOf('_') >= 0)
									{
										object vall = val.ToString().Clone();
										string[] vals = vall.ToString().Split('_');
										vall = vals[int.Parse(ValueIndex)];
										val = vall;
									}

								}

								
							}

							else if (strs[1].Equals("DataSourceUC"))
							{
								DataSourceUC textboxcon = (DataSourceUC)con;

								object infos = Solution.s_Instance.m_ConPropertyInfos;

								Modulenames ConName = MyFormDesinger.StructInfo.Instance.m_AdmintorControllist.Find(e => e.Remark == textboxcon.TextName && e.ControlName == con.Tag.ToString());
								int ProjIndex = Solution.s_Instance.m_ProjectList.FindIndex(e => e.ProjectInfo.ProjectName == textboxcon.ProjName);

								F_CELL_DATA data = Solution.s_Instance.m_ProjectList[ProjIndex].g_VariableList.Find(e => e.m_Module_Name == ConName.Modulename);

								if (data.m_Data_Name == null)
									data = Solution.s_Instance.g_VariableList.Find(e => e.m_Module_Name == ConName.Modulename);

								#region LinkData
								
								string linkdata = ConName.LinkData;
								if (linkdata == null) continue;
								int m_GetModuleIndex1 = linkdata.IndexOf('[');
								int m_GetModuleIndex2 = linkdata.IndexOf(']');
								int m_GetDataIndex = linkdata.IndexOf(':');

								string ModuleName = linkdata.Substring(0, m_GetModuleIndex1);
								string ValueIndex = linkdata.Substring(m_GetModuleIndex1 + 1, 1);
								string dataName = linkdata.Substring(m_GetDataIndex + 1, linkdata.Length - (m_GetDataIndex + 1));

								// F_CELL_DATA m_F_CELL_DATA = Solution.s_Instance.m_ProjectList[m_CurrentProjid].g_VariableList.Find(e => e.m_Module_Name == ModuleName);//对应模块数据集合
								F_CELL_DATA m_F_CELL_DATA = data;
								List<F_CELL_DATA> obs = (List<F_CELL_DATA>)m_F_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据
								F_CELL_DATA dataa = obs.Find(e => e.m_Data_Name == dataName);//单个数据名称的数据
								string obtype = dataa.m_Data_Value.GetType().FullName;//数据类型

								object val = null;
								if (obtype == "System.Double[]") { double[] m_datas = (double[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.Int[]") { int[] m_datas = (int[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.String[]") { string[] m_datas = (string[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.object[]") { object[] m_datas = (object[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
								if (obtype == "System.Boolean[]") { bool[] m_datas = (bool[])dataa.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }

								if (obtype == "System.Boolean") { val = dataa.m_Data_Value; bool m_bval = (bool)val; if (m_bval) con.BackColor = Color.Green; else con.BackColor = Color.Red; }
								if (obtype == "System.Int") { val = dataa.m_Data_Value; }
								if (obtype == "System.Double") { val = dataa.m_Data_Value; }							
								if (obtype == "System.Int32") { val = dataa.m_Data_Value; }
								if (obtype == "System.String")
								{
									val = dataa.m_Data_Value;

									if (val.ToString().IndexOf('[') >= 0)
									{
										Log.Error("字符包含[");
									}

									if (val.ToString().IndexOf('_') >= 0)
									{
										object vall = val.ToString().Clone();
										string[] vals = vall.ToString().Split('_');
										vall = vals[int.Parse(ValueIndex)];
										val = vall;
									}

								}

								if (obtype == "System.Data.DataTable")
								{
									DataTable  tables= (DataTable)val;
									textboxcon.table = tables;
									textboxcon.DataSource = textboxcon.table;

									continue;
								}

								#endregion

								#region RowIndexLinkData
								//string RowIndexlinkdata = ConName.RowIndexLinkData;
								//if (RowIndexlinkdata == null) continue;
								//int m_RowIndexGetModuleIndex1 = RowIndexlinkdata.IndexOf('[');
								//int m_RowIndexGetModuleIndex2 = RowIndexlinkdata.IndexOf(']');
								//int m_RowIndexGetDataIndex = RowIndexlinkdata.IndexOf(':');

								//string RowIndexModuleName = RowIndexlinkdata.Substring(0, m_RowIndexGetModuleIndex1);
								//string RowIndexValueIndex = RowIndexlinkdata.Substring(m_RowIndexGetModuleIndex1 + 1, 1);
								//string RowIndexdataName = RowIndexlinkdata.Substring(m_RowIndexGetDataIndex + 1, RowIndexlinkdata.Length - (m_RowIndexGetDataIndex + 1));

								//// F_CELL_DATA m_F_CELL_DATA = Solution.s_Instance.m_ProjectList[m_CurrentProjid].g_VariableList.Find(e => e.m_Module_Name == ModuleName);//对应模块数据集合
								//F_CELL_DATA m_RowIndexF_CELL_DATA = data;
								//List<F_CELL_DATA> RowIndexobs = (List<F_CELL_DATA>)m_RowIndexF_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据
								//F_CELL_DATA RowIndexdataa = RowIndexobs.Find(e => e.m_Data_Name == dataName);//单个数据名称的数据
								//string RowIndexobtype = RowIndexdataa.m_Data_Value.GetType().FullName;//数据类型

								//object RowIndexval = null;
								//if (RowIndexobtype == "System.Double[]") { double[] m_datas = (double[])dataa.m_Data_Value; RowIndexval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowIndexobtype == "System.Int[]") { int[] m_datas = (int[])dataa.m_Data_Value; RowIndexval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowIndexobtype == "System.String[]") { string[] m_datas = (string[])dataa.m_Data_Value; RowIndexval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowIndexobtype == "System.object[]") { object[] m_datas = (object[])dataa.m_Data_Value; RowIndexval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowIndexobtype == "System.Boolean[]") { bool[] m_datas = (bool[])dataa.m_Data_Value; RowIndexval = m_datas[int.Parse(ValueIndex)]; }

								//if (RowIndexobtype == "System.Boolean") { RowIndexval = dataa.m_Data_Value;}
								//if (RowIndexobtype == "System.Int") { RowIndexval = dataa.m_Data_Value; }
								//if (RowIndexobtype == "System.Double") { RowIndexval = dataa.m_Data_Value; }
								////if (obtype == "System.String") { val = dataa.m_Data_Value; }
								//if (RowIndexobtype == "System.Int32") { RowIndexval = dataa.m_Data_Value; }
								//if (RowIndexobtype == "System.String")
								//{
								//	RowIndexval = dataa.m_Data_Value;

								//	if (RowIndexval.ToString().IndexOf('[') >= 0)
								//	{
								//		Log.Error("字符包含[");
								//	}

								//	if (RowIndexval.ToString().IndexOf('_') >= 0)
								//	{
								//		object vall = val.ToString().Clone();
								//		string[] vals = vall.ToString().Split('_');
								//		vall = vals[int.Parse(ValueIndex)];
								//		RowIndexval = vall;
								//	}

								//}

								#endregion

								#region ColIndexLinkData

								string ColIndexlinkdata = ConName.ColIndexLinkData;
								if (ColIndexlinkdata == null) continue;
								int m_ColIndexGetModuleIndex1 = ColIndexlinkdata.IndexOf('[');
								int m_ColIndexGetModuleIndex2 = ColIndexlinkdata.IndexOf(']');
								int m_ColIndexGetDataIndex = ColIndexlinkdata.IndexOf(':');

								string ColIndexModuleName = ColIndexlinkdata.Substring(0, m_ColIndexGetModuleIndex1);
								string ColIndexValueIndex = ColIndexlinkdata.Substring(m_ColIndexGetModuleIndex1 + 1, 1);
								string ColIndexdataName = ColIndexlinkdata.Substring(m_ColIndexGetDataIndex + 1, ColIndexlinkdata.Length - (m_ColIndexGetDataIndex + 1));

								// F_CELL_DATA m_F_CELL_DATA = Solution.s_Instance.m_ProjectList[m_CurrentProjid].g_VariableList.Find(e => e.m_Module_Name == ModuleName);//对应模块数据集合
								F_CELL_DATA m_ColIndexF_CELL_DATA = data;
								List<F_CELL_DATA> ColIndexobs = (List<F_CELL_DATA>)m_ColIndexF_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据
								F_CELL_DATA ColIndexdataa = ColIndexobs.Find(e => e.m_Data_Name == dataName);//单个数据名称的数据
								string ColIndexobtype = ColIndexdataa.m_Data_Value.GetType().FullName;//数据类型

								object ColIndexval = null;
								if (ColIndexobtype == "System.Double[]") { double[] m_datas = (double[])dataa.m_Data_Value; ColIndexval = m_datas[int.Parse(ValueIndex)]; }
								if (ColIndexobtype == "System.Int[]") { int[] m_datas = (int[])dataa.m_Data_Value; ColIndexval = m_datas[int.Parse(ValueIndex)]; }
								if (ColIndexobtype == "System.String[]") { string[] m_datas = (string[])dataa.m_Data_Value; ColIndexval = m_datas[int.Parse(ValueIndex)]; }
								if (ColIndexobtype == "System.object[]") { object[] m_datas = (object[])dataa.m_Data_Value; ColIndexval = m_datas[int.Parse(ValueIndex)]; }
								if (ColIndexobtype == "System.Boolean[]") { bool[] m_datas = (bool[])dataa.m_Data_Value; ColIndexval = m_datas[int.Parse(ValueIndex)]; }

								if (ColIndexobtype == "System.Boolean") { ColIndexval = dataa.m_Data_Value; }
								if (ColIndexobtype == "System.Int") { ColIndexval = dataa.m_Data_Value; }
								if (ColIndexobtype == "System.Double") { ColIndexval = dataa.m_Data_Value; }
								//if (obtype == "System.String") { val = dataa.m_Data_Value; }
								if (ColIndexobtype == "System.Int32") { ColIndexval = dataa.m_Data_Value; }
								if (ColIndexobtype == "System.String")
								{
									ColIndexval = dataa.m_Data_Value;

									if (ColIndexval.ToString().IndexOf('[') >= 0)
									{
										Log.Error("字符包含[");
									}

									if (ColIndexval.ToString().IndexOf('_') >= 0)
									{
										object vall = val.ToString().Clone();
										string[] vals = vall.ToString().Split('_');
										vall = vals[int.Parse(ValueIndex)];
										ColIndexval = vall;
									}

								}

								#endregion

								#region RowNumLinkData
								//string RowNumlinkdata = ConName.RowNumLinkData;
								//if (RowNumlinkdata == null) continue;
								//int m_RowNumGetModuleIndex1 = RowNumlinkdata.IndexOf('[');
								//int m_RowNumGetModuleIndex2 = RowNumlinkdata.IndexOf(']');
								//int m_RowNumGetDataIndex = RowNumlinkdata.IndexOf(':');

								//string RowNumModuleName = RowNumlinkdata.Substring(0, m_RowNumGetModuleIndex1);
								//string RowNumValueIndex = RowNumlinkdata.Substring(m_RowNumGetModuleIndex1 + 1, 1);
								//string RowNumdataName = RowNumlinkdata.Substring(m_RowNumGetDataIndex + 1, RowNumlinkdata.Length - (m_RowNumGetDataIndex + 1));

								//// F_CELL_DATA m_F_CELL_DATA = Solution.s_Instance.m_ProjectList[m_CurrentProjid].g_VariableList.Find(e => e.m_Module_Name == ModuleName);//对应模块数据集合
								//F_CELL_DATA m_RowNumF_CELL_DATA = data;
								//List<F_CELL_DATA> RowNumobs = (List<F_CELL_DATA>)m_RowNumF_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据
								//F_CELL_DATA RowNumdataa = RowNumobs.Find(e => e.m_Data_Name == RowNumdataName);//单个数据名称的数据
								//string RowNumobtype = RowNumdataa.m_Data_Value.GetType().FullName;//数据类型

								//object RowNumval = null;
								//if (RowNumobtype == "System.Double[]") { double[] m_datas = (double[])RowNumdataa.m_Data_Value; RowNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowNumobtype == "System.Int[]") { int[] m_datas = (int[])RowNumdataa.m_Data_Value; RowNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowNumobtype == "System.String[]") { string[] m_datas = (string[])RowNumdataa.m_Data_Value; RowNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowNumobtype == "System.object[]") { object[] m_datas = (object[])RowNumdataa.m_Data_Value; RowNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (RowNumobtype == "System.Boolean[]") { bool[] m_datas = (bool[])RowNumdataa.m_Data_Value; RowNumval = m_datas[int.Parse(ValueIndex)]; }

								//if (RowNumobtype == "System.Boolean") { RowNumval = RowNumdataa.m_Data_Value;}
								//if (RowNumobtype == "System.Int") { RowNumval = RowNumdataa.m_Data_Value; }
								//if (RowNumobtype == "System.Double") { RowNumval = RowNumdataa.m_Data_Value; }
								////if (obtype == "System.String") { val = dataa.m_Data_Value; }
								//if (RowNumobtype == "System.Int32") { RowNumval = RowNumdataa.m_Data_Value; }
								//if (RowNumobtype == "System.String")
								//{
								//	RowNumval = RowNumdataa.m_Data_Value;

								//	if (RowNumval.ToString().IndexOf('[') >= 0)
								//	{
								//		Log.Error("字符包含[");
								//	}

								//	if (RowNumval.ToString().IndexOf('_') >= 0)
								//	{
								//		object vall = RowNumval.ToString().Clone();
								//		string[] vals = vall.ToString().Split('_');
								//		vall = vals[int.Parse(ValueIndex)];
								//		RowNumval = vall;
								//	}

								//}

								#endregion

								#region ColNumLinkData
								//string ColNumLinklinkdata = ConName.ColNumLinkData;
								//if (ColNumLinklinkdata == null) continue;
								//int m_ColNumLinkGetModuleIndex1 = ColNumLinklinkdata.IndexOf('[');
								//int m_ColNumLinkGetModuleIndex2 = ColNumLinklinkdata.IndexOf(']');
								//int m_ColNumLinkGetDataIndex = ColNumLinklinkdata.IndexOf(':');

								//string ColNumLinkModuleName = ColNumLinklinkdata.Substring(0, m_ColNumLinkGetModuleIndex1);
								//string ColNumLinkValueIndex = ColNumLinklinkdata.Substring(m_ColNumLinkGetModuleIndex1 + 1, 1);
								//string ColNumLinkdataName = ColNumLinklinkdata.Substring(m_ColNumLinkGetDataIndex + 1, ColNumLinklinkdata.Length - (m_ColNumLinkGetDataIndex + 1));

								//// F_CELL_DATA m_F_CELL_DATA = Solution.s_Instance.m_ProjectList[m_CurrentProjid].g_VariableList.Find(e => e.m_Module_Name == ModuleName);//对应模块数据集合
								//F_CELL_DATA m_ColNumLinkF_CELL_DATA = data;
								//List<F_CELL_DATA> ColNumLinkobs = (List<F_CELL_DATA>)m_ColNumLinkF_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据
								//F_CELL_DATA ColNumLinkdataa = ColNumLinkobs.Find(e => e.m_Data_Name == dataName);//单个数据名称的数据
								//string ColNumLinkobtype = ColNumLinkdataa.m_Data_Value.GetType().FullName;//数据类型

								//object ColNumval = null;
								//if (ColNumLinkobtype == "System.Double[]") { double[] m_datas = (double[])dataa.m_Data_Value; ColNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (ColNumLinkobtype == "System.Int[]") { int[] m_datas = (int[])dataa.m_Data_Value; ColNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (ColNumLinkobtype == "System.String[]") { string[] m_datas = (string[])dataa.m_Data_Value; ColNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (ColNumLinkobtype == "System.object[]") { object[] m_datas = (object[])dataa.m_Data_Value; ColNumval = m_datas[int.Parse(ValueIndex)]; }
								//if (ColNumLinkobtype == "System.Boolean[]") { bool[] m_datas = (bool[])dataa.m_Data_Value; ColNumval = m_datas[int.Parse(ValueIndex)]; }

								//if (ColNumLinkobtype == "System.Boolean") { ColNumval = dataa.m_Data_Value;}
								//if (ColNumLinkobtype == "System.Int") { ColNumval = dataa.m_Data_Value; }
								//if (ColNumLinkobtype == "System.Double") { ColNumval = dataa.m_Data_Value; }
								////if (obtype == "System.String") { val = dataa.m_Data_Value; }
								//if (ColNumLinkobtype == "System.Int32") { ColNumval = dataa.m_Data_Value; }
								//if (ColNumLinkobtype == "System.String")
								//{
								//	ColNumval = dataa.m_Data_Value;

								//	if (ColNumval.ToString().IndexOf('[') >= 0)
								//	{
								//		Log.Error("字符包含[");
								//	}

								//	if (ColNumval.ToString().IndexOf('_') >= 0)
								//	{
								//		object vall = ColNumval.ToString().Clone();
								//		string[] vals = vall.ToString().Split('_');
								//		vall = vals[int.Parse(ValueIndex)];
								//		ColNumval = vall;
								//	}

								//}

								#endregion

								#region 刷新数据
								//刷新数据
								textboxcon.DataToDataGridView(textboxcon, int.Parse(ColIndexval.ToString())+1, textboxcon .table.Rows.Count+1, int.Parse(ColIndexval.ToString()), textboxcon.table.Rows.Count, val);
                                #endregion

							}

						}
                        
						catch(Exception ex) { Log.Error(ex.ToString()); }
                       


                    }
                    GC.Collect(0);

                }//try


            } catch (Exception ex) { Core.frmMessageDialog dlg = new Core.frmMessageDialog();dlg.message = ex.ToString();dlg.ShowDialog();Log.Error(ex.ToString()); }
            

        }
	

		/// <summary>
		/// /
		/// </summary>
		Form_MainView he = new Form_MainView();

        /// <summary>
        /// 工程师界面 || 操作员界面
        /// </summary>
        private void UpdateImage(string name,object image)
        {
            try {

                //工程师界面
                if (!m_IsLoginOK)
                    {
                    if (ServiceModule.Instance.RunningMode == "静态单相机模式")
                    {
                        if (image != null && !ServiceModule.Instance.bRunHalcon)
                    {
                        Bitmap m_image = (Bitmap)image;
                        this.BeginInvoke(NotifyUpdateOpenCVImage, m_image);
                    }

                        else if (image != null && ServiceModule.Instance.bRunHalcon)
                    {
                        string str = image.GetType().Name;

                        if (str == "Bitmap")
                        {
                           // Bitmap m_OutImage = (Bitmap)image; HObject ob;
                           // m_BitmapImgProcess.Bitmap2HObjectBpp24_90ms(m_OutImage, out ob);
                           // hWindow_Fit1.Image = new HImage(ob);
                        }
                        else if (str == "HObject")
                        {
                            //HObject m_OutImage = (HObject)image;
                            //hWindow_Fit1.Image = new HImage(m_OutImage);
                        }
                        else if (str == "Himage")
                        {
                            // HObject m_OutImage = new HObject((HImage)image);
                            //hWindow_Fit1.Image = new HImage((HImage)image);
                        }
                        else if (str == "HImageExt")
                        {
                            //HImage m_OutImage = (HImage)image;
                           // hWindow_Fit1.Image = m_OutImage;

                        }
                        //m_OutImage=(HObject)image;
                        //m_BitmapImgProcess.Bitmap2HObjectBpp24_90ms(image, out m_OutImage);
                        Thread.Sleep(5);
                    }

                    }

                    #region 没有使用

                   
                    //if (image != null && !ServiceModule.Instance.bRunHalcon)
                    //    {
                    //        Bitmap m_image = (Bitmap)image;
                    //        this.BeginInvoke(NotifyUpdateOpenCVImage, m_image);
                    //    }
                    //    else
                    //    {
                    //        string str = image.GetType().Name;
                    //        Bitmap ob = null;
                    //        if (str == "Bitmap")
                    //        {
                    //            // Bitmap m_OutImage = (Bitmap)image;HObject ob;
                    //            // m_BitmapImgProcess.Bitmap2HObjectBpp24_90ms(m_OutImage, out ob);                           
                    //        }
                    //        else if (str == "HObject")
                    //        {
                    //            HObject m_OutImage = (HObject)image;
                    //            m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out ob);

                    //        }
                    //        else if (str == "Himage")
                    //        {
                    //            HObject m_OutImage = new HObject((HImage)image);
                    //            m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out ob);

                    //        }
                    //        else if (str == "HImageExt")
                    //        {
                    //            HImage m_OutImage = (HImage)image;
                    //            m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out ob);
                    //        }
                    //        this.BeginInvoke(NotifyUpdateOpenCVImage, ob);
                    //    }
                    #endregion

                    else if (ServiceModule.Instance.RunningMode == "动态多相机模式")
                    {
                        if (image != null && !ServiceModule.Instance.bRunHalcon)
                        {
                            BitmapExt m_image = (BitmapExt)image;

                           // Form_MainView he = new Form_MainView();

                            he.m_OutImage =m_image.m_image;
                            he.Screen = m_image.m_ScreenNum;
                            img_get(name, he);
                            //this.BeginInvoke(NotifyUpdateOpenCVImage, m_image);
                        }

                        else if (image != null && ServiceModule.Instance.bRunHalcon)
                        {
                            BitmapExt m_image = (BitmapExt)image;
                            string str = m_image.m_image.GetType().Name;

                            if (str == "Bitmap")
                            {
                                Bitmap m_OutImage = (Bitmap)m_image.m_image; HObject ob;
                                m_BitmapImgProcess.Bitmap2HObjectBpp24_90ms(m_OutImage, out ob);
                              
                                  he.m_OutImage = ob.Clone();
                                  he.Screen = m_image.m_ScreenNum;
                                  img_get(name, he);
                            }
                            else if (str == "HObject")
                            {
                                HObject m_OutImage = (HObject)m_image.m_image;
                                //m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out ob);
                               // Form_MainView he = new Form_MainView();
                                he.m_OutImage = m_OutImage;
                                he.Screen = m_image.m_ScreenNum;
                                img_get(name, he);
                            }
                            else if (str == "Himage")
                            {
                                HObject m_OutImage = new HObject((HImage)m_image.m_image);
                                //m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out ob);
                               // Form_MainView he = new Form_MainView();
                                he.m_OutImage = m_OutImage;
                                he.Screen = m_image.m_ScreenNum;
                                //img_get(name, he);
                            }
                            else if (str == "HImageExt")
                            {
                                HImage m_OutImage = (HImage)m_image.m_image;
                                // m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out ob);
                               // Form_MainView he = new Form_MainView();
                                he.m_OutImage = m_OutImage;
                                he.Screen = m_image.m_ScreenNum;
                                img_get(name, he);
                            }
                            GC.Collect();
                           // Thread.Sleep(10);
                        }

                    }
                }

               //操作员界面
                else//操作员界面
                 {
                    BitmapExt m_image = (BitmapExt)image;
                    string str = m_image.m_image.GetType().Name;

                    if (str == "Bitmap")
                    {
                        // Bitmap m_OutImage = (Bitmap)image;HObject ob;
                        // m_BitmapImgProcess.Bitmap2HObjectBpp24_90ms(m_OutImage, out ob);
                         this.BeginInvoke(NotifyUpdateOpenCVImage, m_image.m_image);
                        Thread.Sleep(30);
                    }
                    else if (str == "HObject")
                    {
                        //HImage m_OutImage = new HImage((HObject)m_image.m_image); //Bitmap img;

//                         if (m_OutImage.CountChannels().I > 1)
//                             m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out img);
//                         else
//                             m_BitmapImgProcess.Hobject8Bpp_aboveFramework4(m_OutImage, out img);

                        this.BeginInvoke(NotifyUpdateOpenCVImage, m_image.m_image);
                        Thread.Sleep(30);
                    }
                    else if (str == "Himage")
                    {
                        //HImage m_OutImage = (HImage)m_image.m_image; Bitmap img;

//                         if (m_OutImage.CountChannels().I > 1)
//                             m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out img);
//                         else
//                             m_BitmapImgProcess.Hobject8Bpp_aboveFramework4(m_OutImage, out img);

                        this.BeginInvoke(NotifyUpdateOpenCVImage, m_image.m_image);
                        Thread.Sleep(30);
                    }
                    else if (str == "HImageExt")
                    {
                        //HImage m_OutImage = (HImage)m_image.m_image; Bitmap img;

//                         if (m_OutImage.CountChannels().I > 1)
//                             m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out img);
//                         else
//                             m_BitmapImgProcess.Hobject8Bpp_aboveFramework4(m_OutImage, out img);

                        this.BeginInvoke(NotifyUpdateOpenCVImage, m_image.m_image);
                        Thread.Sleep(30);
                    }
					else if (str == "String")
					{
						//HImage m_OutImage = (HImage)m_image.m_image; Bitmap img;

						//                         if (m_OutImage.CountChannels().I > 1)
						//                             m_BitmapImgProcess.HObject2Bpp24_aboveFramework4(m_OutImage, out img);
						//                         else
						//                             m_BitmapImgProcess.Hobject8Bpp_aboveFramework4(m_OutImage, out img);

						this.BeginInvoke(NotifyUpdateOpenCVImage, m_image.m_image);
						Thread.Sleep(30);
					}

				}

               
            } 
            catch(Exception ex) 
            {
				Log.Error("请按下屏幕切换合适的算法模式\r\n" + ex.ToString());
				/*Core.frmMessageDialog dlg = new Core.frmMessageDialog();dlg.message = "请按下屏幕切换合适的算法模式\r\n"+ex.ToString();dlg.TopMost = true;dlg.BringToFront(); dlg.ShowDialog(); */}


           

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        private void UpdateCamMode(string str)
        {


            Thread.Sleep(10);
            if(str=="多相机模式")
            {

//                 tabControl1.Hide();
//                 flowUC1.Hide();
//                 moduleUC1.Hide();
                rtfRichTextBox1.Hide();

                m_MainShow.TopLevel = false;
                m_MainShow.TopMost = true;
                m_MainShow.Dock = DockStyle.Fill;
                m_MainShow.Visible = true;
                m_MainShow.Show();


                m_MainShow.show_工具框();

                m_MainShow.show_图像显示框();

                m_MainShow.show_日志显示框();

                m_MainShow.show_流程框();

                m_MainShow.m_SolutionView.NotifyUpdatetabProject_SelectedIndex += new Form_Flow.UpdatetabProject_SelectedIndex(UpdatetabProjectSelectedIndex);

                ServiceModule.Instance.RunningMode = "动态多相机模式";


            }

        }

        /// <summary>
		/// 刷新条目1
		/// </summary>
		private void NotifyUpdateRefreshItem(string name, object control)
        {
//            switch(m_CurrentFlowIndex)
//             {
//                 case 0:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                     this.BeginInvoke(NotifyUpdateFlowRefresh, name, control);
//                     break;
//                 case 1:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh2, name, control);
//                     break;
//                 case 2:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh3, name, control);
//                     break;
//                 case 3:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh4, name, control);
//                     break;
//                 case 4:
                    if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
                        this.BeginInvoke(NotifyUpdateFlowRefresh, name, control);

                    //break;
          //  }
            
        }

        /// <summary>
        /// 刷新条目2
        /// </summary>
        private void NotifyUpdateRefreshItem2(string name, object control)
        {
//             switch (m_CurrentFlowIndex)
//             {
//                 case 0:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh, name, control);
//                     break;
//                 case 1:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh2, name, control);
//                     break;
//                 case 2:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh3, name, control);
//                     break;
//                 case 3:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh4, name, control);
//                     break;
//                 case 4:
                    if (Solution.GetProjectById(1).m_OpenCVThreadStatus && m_CurrentFlowIndex == 1)
                        this.BeginInvoke(NotifyUpdateFlowRefresh2, name, control);
                  //  break;
          //  }

        }

        /// <summary>
        /// 刷新条目3
        /// </summary>
        private void NotifyUpdateRefreshItem3(string name, object control)
        {
//             switch (m_CurrentFlowIndex)
//             {
//                 case 0:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh, name, control);
//                     break;
//                 case 1:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh2, name, control);
//                     break;
//                 case 2:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh3, name, control);
//                     break;
//                 case 3:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh4, name, control);
//                     break;
//                 case 4:
                    if (Solution.GetProjectById(2).m_OpenCVThreadStatus && m_CurrentFlowIndex == 2)
                        this.BeginInvoke(NotifyUpdateFlowRefresh3, name, control);
                  //  break;
          //  }

        }

        /// <summary>
        /// 刷新条目4
        /// </summary>
        private void NotifyUpdateRefreshItem4(string name, object control)
        {
//             switch (m_CurrentFlowIndex)
//             {
//                 case 0:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh, name, control);
//                     break;
//                 case 1:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh2, name, control);
//                     break;
//                 case 2:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh3, name, control);
//                     break;
//                 case 3:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh4, name, control);
//                     break;
//                 case 4:
                    if (Solution.GetProjectById(3).m_OpenCVThreadStatus && m_CurrentFlowIndex == 3)
                        this.BeginInvoke(NotifyUpdateFlowRefresh4, name, control);
                   // break;
            //}

        }

        /// <summary>
        /// 刷新条目5
        /// </summary>
        private void NotifyUpdateRefreshItem5(string name, object control)
        {
//             switch (m_CurrentFlowIndex)
//             {
//                 case 0:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh, name, control);
//                     break;
//                 case 1:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh2, name, control);
//                     break;
//                 case 2:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh3, name, control);
//                     break;
//                 case 3:
//                     if (Solution.GetProjectById(m_CurrentFlowIndex).m_OpenCVThreadStatus)
//                         this.BeginInvoke(NotifyUpdateFlowRefresh4, name, control);
//                     break;
//                 case 4:
                    if (Solution.GetProjectById(4).m_OpenCVThreadStatus && m_CurrentFlowIndex == 4)
                        this.BeginInvoke(NotifyUpdateFlowRefresh5, name, control);
                 //   break;
           // }

        }

        #endregion

        #region  自动状态显示相关
        /// <summary>
        /// 
        /// </summary>
        public void SetWindow()
        {
            if (Solution.s_Instance != null)
            {
                form_ = new Form_Set(Solution.s_Instance.curScreenNum);
               // form_.num_old = Solution.s_Instance.curScreenNum;
                form_.ShowDialog();
                
                int n = Solution.s_Instance.curScreenNum;              
                if (n >= 0)
                {
                    Solution.s_Instance.curScreenNum = n;
                    m_MainShow.Form_set(n);
                }


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="he"></param>
        protected void img_get(string name, Form_MainView he)
        {
            try
            {
                if (he.Screen <= 0)
                { return; }
                m_MainShow.Invoke(new Action(() => { m_MainShow.show_screen(he);}));
            }
            catch(Exception ex) { Log.Error(ex.ToString()); }
        }
        #endregion

        #region 清理内存
   
        /// <summary>
        ///设置线程工作的空间
        /// </summary>
        /// <param name="process">线程</param>
        /// <param name="minSize">最小空间</param>
        /// <param name="maxSize">最大空间</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>      
        /// 释放内存      
        /// </summary>      
        public  void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
           
            try
            {             
              base.WndProc(ref m);
            }

            catch(Exception ex) { Log.Error(ex.ToString()); }
        }
      

    }

    /// <summary>
    /// 结构体
    /// </summary>
    public struct IOStruct
    {
        /// <summary>
        /// IO名称
        /// </summary>
        public string name;
        /// <summary>
        /// IO值
        /// </summary>
        public object IOValue;

    }

}
