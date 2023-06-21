using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Set_UI;
using OpenCVCore;
using Rex.UI;
using VisionCore.Log4Net;

namespace Plugin.Arithmetic
{
	public partial class AlrithmeticModuleForm : OpenCVModuleFormBase
	{
		/// <summary>
		/// 
		/// </summary>
		public ArithmeticModuleObj m_ModuleObj;


		VariableModule_Set m_VariableModule_Set;

		/// <summary>
		/// 全局变量列表和常量
		/// </summary>      
		public List<F_CELL_DATA> VariableList = new List<F_CELL_DATA>();

		/// <summary>
		/// 
		/// </summary>
		public AlrithmeticModuleForm()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="m_ModuleObj_"></param>
		public AlrithmeticModuleForm(ArithmeticModuleObj m_ModuleObj_) : base(m_ModuleObj_)
		{
			m_ModuleObj = m_ModuleObj_;
			InitializeComponent();

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DelayModuleForm_Load(object sender, EventArgs e)
		{
			VariableList = m_ModuleObj.g_VariableList;

			if (m_ModuleObj.LinkStr == null) m_ModuleObj.LinkStr = "";
			textBox_link.box.Text = m_ModuleObj.LinkStr;

			DataToForm();

			uiLinkData1.box.TextChanged += Box_TextChanged;
			textBox_link.box.TextChanged += Box_TextChanged1;

			uiLinkData2.box.TextChanged += Box_TextChanged2;
			textBox_link2.box.TextChanged += Box_TextChanged12;

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Box_TextChanged1(object sender, EventArgs e)
		{
			m_ModuleObj.LinkStr = textBox_link.box.Text;
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Box_TextChanged(object sender, EventArgs e)
		{
			m_ModuleObj.IndexLinkStr = uiLinkData1.box.Text;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Box_TextChanged12(object sender, EventArgs e)
		{
			m_ModuleObj.LinkStr2 = textBox_link.box.Text;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Box_TextChanged2(object sender, EventArgs e)
		{
			m_ModuleObj.IndexLinkStr2 = uiLinkData1.box.Text;
		}
		/// <summary>
		/// 
		/// </summary>
		public override void FormToData()
		{

			 m_ModuleObj.LinkStr= textBox_link.box.Text;
			 m_ModuleObj.LinkStr2 = textBox_link2.box.Text ;

			base.FormToData();
		}

		/// <summary>
		/// 
		/// </summary>
		public override void DataToForm()
		{

			textBox_link.box.Text = m_ModuleObj.LinkStr ;
			textBox_link2.box.Text = m_ModuleObj .LinkStr2;
			uiLinkData1.box.Text = m_ModuleObj.IndexLinkStr;
			uiLinkData2.box.Text = m_ModuleObj.IndexLinkStr2;
			base.DataToForm();
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
		private void button_run_Click(object sender, EventArgs e)
		{

			m_ModuleObj.ExeModule();
			uiTextBox3.Text = m_ModuleObj.Result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_cancel_Click(object sender, EventArgs e)
		{

			this.Close();
		}

	
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_link_BtnAdd(object sender, EventArgs e)
		{
			m_VariableModule_Set = new VariableModule_Set(m_ModuleObj);
			m_VariableModule_Set.ShowDialog();


			UITextBox box = (UITextBox)sender;
			box.Text = m_VariableModule_Set.m_StrResult;
			m_ModuleObj.LinkStr = box.Text;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_link_BtnDec(object sender, EventArgs e)
		{
			textBox_link.Text = "";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiLinkData1_BtnAdd(object sender, EventArgs e)
		{
			m_VariableModule_Set = new VariableModule_Set(m_ModuleObj);
			m_VariableModule_Set.ShowDialog();


			UITextBox box = (UITextBox)sender;
			box.Text = m_VariableModule_Set.m_StrResult;
			m_ModuleObj.LinkStr2 = box.Text;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiLinkData1_BtnDec(object sender, EventArgs e)
		{
			textBox_link2.Text = "";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiLinkData1_BtnAdd_1(object sender, EventArgs e)
		{
			m_VariableModule_Set = new VariableModule_Set(m_ModuleObj);
			m_VariableModule_Set.ShowDialog();

			m_ModuleObj.m_CurrentIndex = m_VariableModule_Set.m_CurrentIndex;
			UITextBox box = (UITextBox)sender;
			box.Text = m_VariableModule_Set.m_StrResult;
			m_ModuleObj.IndexLinkStr = box.Text;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiLinkData1_BtnDec_1(object sender, EventArgs e)
		{
			uiLinkData1.box.Text = "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void skinCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			m_ModuleObj.m__bIsAutoRecycle = skinCheckBox1.Checked;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiLinkData2_BtnAdd(object sender, EventArgs e)
		{
			m_VariableModule_Set = new VariableModule_Set(m_ModuleObj);
			m_VariableModule_Set.ShowDialog();

			m_ModuleObj.m_CurrentIndex2 = m_VariableModule_Set.m_CurrentIndex;
			UITextBox box = (UITextBox)sender;
			box.Text = m_VariableModule_Set.m_StrResult;
			m_ModuleObj.IndexLinkStr = box.Text;

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uiLinkData2_BtnDec(object sender, EventArgs e)
		{
			uiLinkData2.box.Text = "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void skinCheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			m_ModuleObj.m__bIsAutoRecycle = skinCheckBox1.Checked;
		}

		private void uiComboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_ModuleObj.symbol = uiComboBox3.Text;
		}
	}
}
