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
using CCWin.SkinControl;
using Core;
using Core.core;
using Core.Set_UI;
using VisionCore.Log4Net;

namespace SZXCVision
{
	public partial class ProjListRunForm : OpenCVModuleFormBase
	{

		/// <summary>
		/// 
		/// </summary>
		private int indexofsource2, indexoftarget2, indexofprocess2;

		/// <summary>
		/// 光标
		/// </summary>
		Set_gCusor set_GCusor;

		/// <summary>
		/// 光标
		/// </summary>
		private Cursor g_cursor;


		/// <summary>
		/// 
		/// </summary>
		private object Dragobject;


		/// <summary>
		/// 
		/// </summary>
		private List<Project> m_Projs;

		/// <summary>
		/// 
		/// </summary>
		public bool m_bCancel=false;
		/// <summary>
		/// 
		/// </summary>
		public bool m_bRun = false;

		/// <summary>
		/// 
		/// </summary>
		public ProjListRunForm()
		{
			InitializeComponent();

			set_GCusor = new Set_gCusor();

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProjListRunForm_Load(object sender, EventArgs e)
		{
			if (Solution.s_Instance.m_ProjectList.Count == 0 || Solution.s_Instance.m_ProjectList == null) Log.Error("无可启动的流程!!!");

			m_Projs = Solution.s_Instance.m_ProjectList;

			if (Solution.s_Instance.m_AllRunProjNamelist == null) Solution.s_Instance.m_AllRunProjNamelist = new List<string>();


			//if (Solution.s_Instance.m_AllRunProjNamelist.Count <=0)
			//	{
			    Solution.s_Instance.m_AllRunProjNamelist.Clear();
			    skinListBox1.Items.Clear();
			    foreach (Project proj in m_Projs)
				{
					
					SkinListBoxItem item = new SkinListBoxItem(proj.ProjectInfo.ProjectName);
					skinListBox1.Items.Add(item);
					Solution.s_Instance.m_AllRunProjNamelist.Add(proj.ProjectInfo.ProjectName);
				}
		//	}
// 			else
// 			{
// 				skinListBox1.Items.Clear();
// 
// 				foreach (string axisname in Solution.s_Instance.m_AllRunProjNamelist)
// 				{
// 					SkinListBoxItem item = new SkinListBoxItem(axisname);
// 					skinListBox1.Items.Add(item);
// 				}
// 
// 			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void skinListBox1_MouseDown(object sender, MouseEventArgs e)
		{

			Dragobject = skinListBox1;//全局使用

			if (e.Button == MouseButtons.Left && skinListBox1.SelectedItem != null)
			{
				set_GCusor.SetCursor(skinListBox1, Properties.Resources.Pointer.ToBitmap(), new System.Drawing.Point(0, 0));
				g_cursor = set_GCusor.g_cursor;

				indexofsource2 = ((SkinListBox)sender).IndexFromPoint(e.X, e.Y);
				if (indexofsource2 != SkinListBox.NoMatches)
				{
					((SkinListBox)sender).DoDragDrop(((SkinListBox)sender).Items[indexofsource2].ToString(), DragDropEffects.Move);
				}


			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void skinListBox1_DragDrop(object sender, DragEventArgs e)
		{
			SkinListBox listbox = (SkinListBox)sender;
			indexoftarget2 = listbox.IndexFromPoint(listbox.PointToClient(new System.Drawing.Point(e.X, e.Y)));//目标行
			try
			{
				if (indexoftarget2 != SkinListBox.NoMatches)
				{
					skinListBox1.SelectionMode = SelectionMode.One;
					SkinListBoxItem item = new SkinListBoxItem(listbox.Items[indexofsource2].Text);
					skinListBox1.Items.RemoveAt(indexofsource2);//把拖拽前先删除掉
					skinListBox1.Items.Insert(indexoftarget2, item);

					// string temp = listbox.Items[indexoftarget2].ToString();
					// listbox.Items[indexoftarget2] = listbox.Items[indexofsource2];
					// SkinListBoxItem item = new SkinListBoxItem(temp);
					// skinListBox1.Items[indexofsource2] = item;
					// skinListBox1.SelectedIndex = indexoftarget2;
					//skinListBox1.SelectionMode = SelectionMode.None;
				}
				if (Solution.s_Instance.m_AllRunProjNamelist.Count > 0) Solution.s_Instance.m_AllRunProjNamelist.Clear();

				foreach (SkinListBoxItem item in skinListBox1.Items)
					Solution.s_Instance.m_AllRunProjNamelist.Add(item.Text);
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void skinListBox1_DragOver(object sender, DragEventArgs e)
		{
			object ob = e.Data.GetData("CCWin.SkinControl.SkinCaptionPanel");

			if (e.Data.GetDataPresent(typeof(System.String)) && ((SkinListBox)sender).Equals(skinListBox1))
			{
				e.Effect = DragDropEffects.Move;
				SkinListBox listbox = (SkinListBox)sender;
				indexofprocess2 = listbox.IndexFromPoint(listbox.PointToClient(new System.Drawing.Point(e.X, e.Y)));


				try
				{
					skinListBox1.Refresh();
					DrawItemEventArgs e2 = new DrawItemEventArgs(skinListBox1.CreateGraphics(), skinListBox1.Font, skinListBox1.GetItemRectangle(indexofprocess2), 0, DrawItemState.HotLight);
					skinListBox2_DrawItem(sender, e2);
				}
				catch (System.Exception ex)
				{
					Console.WriteLine(ex.ToString());

				}
				Thread.Sleep(50);

			}

			else if (!ob.IsNull())
			{


				e.Effect = DragDropEffects.Move;

				try
				{
					skinListBox1.Refresh();

				}
				catch (System.Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
			else
				e.Effect = DragDropEffects.None;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void skinListBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{

			e.UseDefaultCursors = false;
			Cursor.Current = g_cursor;

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_run_Click(object sender, EventArgs e)
		{
			m_bRun = true;
			m_bCancel = false;
			this.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_save_Click(object sender, EventArgs e)
		{

			this.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_cancel_Click(object sender, EventArgs e)
		{

			m_bRun = false;
			m_bCancel = true;

			this.Close();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProjListRunForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		   if(!m_bRun)
			m_bCancel = true;

			this.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void skinListBox2_DrawItem(object sender, DrawItemEventArgs e)
		{

			e.DrawBackground();          //先调用基类实现           
			if (e.Index < 0)            //form load 的时候return
				return;

			if (e.Index == indexofprocess2)
			{
				Pen Blue = new Pen(Brushes.Blue);
				e.Graphics.DrawRectangle(Blue, skinListBox1.GetItemRectangle(indexofprocess2));
				e.Graphics.DrawString(skinListBox1.Items[indexofprocess2].ToString(), e.Font, Brushes.Black, e.Bounds);
				//Console.WriteLine("skinlistbox2绘画矩形");

			}
			else
			{
				Pen white = new Pen(Brushes.Blue);
				e.Graphics.DrawRectangle(white, skinListBox1.GetItemRectangle(indexofprocess2));
				e.Graphics.DrawString(skinListBox1.Items[indexofprocess2].ToString(), e.Font, Brushes.Black, e.Bounds);
				//Console.WriteLine("skinlistbox2绘画");
			}


		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

			if (e.ClickedItem.Text.Contains("禁用"))
			{

				string item =Solution.s_Instance. m_AllRunProjNamelist[skinListBox1.SelectedIndex];
				if (item.Contains("_")) { string[] items = item.Split('_'); item = items[0] + "_禁用"; }
				else
					item = item + "_禁用";

				Solution.s_Instance.m_AllRunProjNamelist[skinListBox1.SelectedIndex] = item;
			}


			if (e.ClickedItem.Text.Contains("无需等待或禁用"))
			{
				string item = Solution.s_Instance.m_AllRunProjNamelist[skinListBox1.SelectedIndex];

				if (item.Contains("_")) { string[] items = item.Split('_'); item = items[0]; }

				Solution.s_Instance.m_AllRunProjNamelist[skinListBox1.SelectedIndex] = item;


			}

			if (e.ClickedItem.Text.Contains("等待完成"))
			{
				string itemstr = Solution.s_Instance.m_AllRunProjNamelist[skinListBox1.SelectedIndex];

				if (!itemstr.Contains("_")) { itemstr = itemstr + "_" + "等待完成"; }
				else
				{
					string[] items = itemstr.Split('_'); itemstr = items[0] + "_等待完成";
				}

				Solution.s_Instance.m_AllRunProjNamelist[skinListBox1.SelectedIndex] = itemstr;
			}

			skinListBox1.Items.Clear();
			foreach (string item1 in Solution.s_Instance.m_AllRunProjNamelist)
			{
				SkinListBoxItem item2 = new SkinListBoxItem(item1);
				skinListBox1.Items.Add(item2);
			}
			skinListBox1.Refresh();

		}

	}
}
