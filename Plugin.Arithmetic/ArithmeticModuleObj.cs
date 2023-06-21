using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.core;
using OpenCVCore;
using VisionCore.core;
using VisionCore.Log4Net;

namespace Plugin.Arithmetic
{
	[Category("系统工具")]
	[DisplayName("四则运算")]
	[Serializable]
	public class ArithmeticModuleObj : OpenCVModuleBase
	{

		/// <summary>
		/// 
		/// </summary>
		public string m_DataName, m_remarkName, m_DataName2, m_remarkName2;

		/// <summary>
		/// 
		/// </summary>
		public string LinkStr, LinkStr2,Result,symbol;

		/// <summary>
		/// 
		/// 是否自循坏
		/// </summary>
		public bool m__bIsAutoRecycle, m__bIsAutoRecycle2;
		/// <summary>
		/// 索引链接数据
		/// </summary>
		public string IndexLinkStr, IndexLinkStr2;

		/// <summary>
		/// 
		/// </summary>
		public int m_CurrentIndex, m_CurrentIndex2;


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override bool ExeModule()
		{
			ModuleParam.State = ModuleState.Start;
			double resu=0.0;
			object ob=0.0; object ob2=0.0;
			try
			{

				if (LinkStr.Contains("[") && LinkStr2.Contains("["))
				{

					ob = GetModuleLinkData(LinkStr);
					string obtype = ob.GetType().FullName;//数据类型
					if (obtype == "System.Boolean" || obtype == "System.String") { Log.Error("数据类型不能为布尔或者字符串"); }

					ob2 = GetModuleLinkData(LinkStr2);
					string obtype2 = ob2.GetType().FullName;//数据类型
					if (obtype2 == "System.Boolean" || obtype2 == "System.String") { Log.Error("数据类型不能为布尔或者字符串"); }



				}
				else if (!LinkStr.Contains("[") && LinkStr2.Contains("["))
				{
					ob2 = GetModuleLinkData(LinkStr2);
					string obtype2 = ob2.GetType().FullName;//数据类型
					if (obtype2 == "System.Boolean" || obtype2 == "System.String") { Log.Error("数据类型不能为布尔或者字符串"); }

				}
				else if (LinkStr.Contains("[") && !LinkStr2.Contains("["))
				{
					ob = GetModuleLinkData(LinkStr);
					string obtype = ob.GetType().FullName;//数据类型
					if (obtype == "System.Boolean" || obtype == "System.String") { Log.Error("数据类型不能为布尔或者字符串"); }
				}
				else
				{
					ob = LinkStr;
					ob2 = LinkStr2;
				}
				switch (symbol)
					{
						case "加法":
							resu    =double.Parse(ob.ToString())+ double.Parse(ob2.ToString());
							break;
						case "减法":
							resu = double.Parse(ob.ToString()) - double.Parse(ob2.ToString());
							break;
						case "乘法":
							resu = double.Parse(ob.ToString()) * double.Parse(ob2.ToString());
							break;
						case "除法":
							resu = double.Parse(ob.ToString()) / double.Parse(ob2.ToString());
							break;
										
				}
				Result = resu.ToString();
				/***********************结果数据************************/
				//F_CELL_DATA data_ = new F_CELL_DATA();
				//data_.InitValue(this.ModuleParam.ModuleName, this.ModuleParam.ModuleEncode,  ConstVavriable.outResult, DataType.字符串, "0");
				//data_.m_Data_Value = splitresultstr;
				//UpdateVariableValue(ref m_VariableList, data_);
				m_HiperTimer.Stop();
				double times = m_HiperTimer.EliminatedMicroSecond;

				////结果数据参数
				F_CELL_DATA datacel = new F_CELL_DATA(ModuleParam.ModuleName, 1, VisionCore.core.DataGroup.单量, DataType.Double,
				"数据值", ConstVavriable.outResult, "0", 1, Result, DataAtrribution.系统变量);
				//结果数据参数
				F_CELL_DATA datacel2 = new F_CELL_DATA(ModuleParam.ModuleName, 1, VisionCore.core.DataGroup.单量, DataType.Int,
				"运动时间", ConstVavriable.outResult, "0", 1, times, DataAtrribution.系统变量);
				//运行结果数据参数
				F_CELL_DATA datacel3 = new F_CELL_DATA(ModuleParam.ModuleName, 1, VisionCore.core.DataGroup.单量, DataType.布尔型,
				"运行结果", ConstVavriable.outResult, "0", 1, true, DataAtrribution.系统变量);

				//运行结果数据参数汇总
				List<F_CELL_DATA> Reslist = new List<F_CELL_DATA>();
				Reslist.Add(datacel);//结果区域
				Reslist.Add(datacel2);//运行结果
				Reslist.Add(datacel3);//运行时间

				F_CELL_DATA datacelT = new F_CELL_DATA(this.ModuleParam.ModuleName, ModuleParam.ModuleEncode, VisionCore.core.DataGroup.单量, DataType.数值型,
				"四则运算", ConstVavriable.outResult, "0", Reslist.Count, (object)Reslist, DataAtrribution.系统变量);
				UpdateVariableValue(ref g_VariableList, datacelT);//g_VariableList父类用的




				ModuleParam.State = ModuleState.OK;
				Retsult_ = 1;

			}
			catch (Exception ex)
			{
				////结果数据参数
				F_CELL_DATA datacel = new F_CELL_DATA(ModuleParam.ModuleName, 1, VisionCore.core.DataGroup.单量, DataType.Double,
				"数据值", ConstVavriable.outResult, "0", 1, 0.0, DataAtrribution.系统变量);
				//结果数据参数
				F_CELL_DATA datacel2 = new F_CELL_DATA(ModuleParam.ModuleName, 1, VisionCore.core.DataGroup.单量, DataType.Int,
				"运动时间", ConstVavriable.outResult, "0", 1, 0.0, DataAtrribution.系统变量);
				//运行结果数据参数
				F_CELL_DATA datacel3 = new F_CELL_DATA(ModuleParam.ModuleName, 1, VisionCore.core.DataGroup.单量, DataType.布尔型,
				"运行结果", ConstVavriable.outResult, "0", 1, true, DataAtrribution.系统变量);

				//运行结果数据参数汇总
				List<F_CELL_DATA> Reslist = new List<F_CELL_DATA>();
				Reslist.Add(datacel);//结果区域
				Reslist.Add(datacel2);//运行结果
				Reslist.Add(datacel3);//运行时间

				F_CELL_DATA datacelT = new F_CELL_DATA(this.ModuleParam.ModuleName, ModuleParam.ModuleEncode, VisionCore.core.DataGroup.数组, DataType.数值型,
				"四则运算", ConstVavriable.outResult, "0", Reslist.Count, (object)Reslist, DataAtrribution.系统变量);
				UpdateVariableValue(ref g_VariableList, datacelT);//g_VariableList父类用的


				ModuleParam.State = ModuleState.NG;
				Retsult_ = 1;
				Log.Error(ex.ToString()+"数据类型不对");
			}

			return true;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override bool Interrupt()
		{


			return base.Interrupt();
		}

		/// <summary>
		/// 
		/// </summary>
		public override void SetInfo()
		{
			base.SetInfo();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="basemodule"></param>
		public override void SetShowModule(OpenCVModuleBase basemodule)
		{
			AlrithmeticModuleForm frm = new AlrithmeticModuleForm((ArithmeticModuleObj)basemodule);
			frm.Show();

			base.SetShowModule(basemodule);
		}
		/// <summary>
		/// 获取模块连接信息
		/// </summary>
		public object GetModuleLinkData(string LinkStr)
		{

			string tip = LinkStr;//对应模块信息
			if (!tip.Contains('[')) return "0";

			int m_GetModuleIndex1 = tip.IndexOf('[');
			int m_GetModuleIndex2 = tip.IndexOf(']');
			int m_GetDataIndex = tip.IndexOf(':');

			string ModuleName = tip.Substring(0, m_GetModuleIndex1);
			string ValueIndex = tip.Substring(m_GetModuleIndex1 + 1, 1);
			string dataName = tip.Substring(m_GetDataIndex + 1, tip.Length - (m_GetDataIndex + 1));

			F_CELL_DATA m_F_CELL_DATA = g_VariableList.Find(e => e.m_Module_Name == ModuleName);//在该流程中对应模块数据集合

			if (m_F_CELL_DATA.m_Module_Name == null) m_F_CELL_DATA = Solution.s_Instance.g_VariableList.Find(e => e.m_Module_Name == ModuleName);//在全局中对应模块数据集合

			List<F_CELL_DATA> obs = (List<F_CELL_DATA>)m_F_CELL_DATA.m_Data_Value;//获取对应模块中不同数据名称的数据

			F_CELL_DATA data = obs.Find(e => e.m_Data_Name == dataName);//单个数据名称的数据

			string obtype = data.m_Data_Value.GetType().FullName;//数据类型

			object val = data.m_Data_Value; int valindex = int.Parse(ValueIndex);

			if (!m__bIsAutoRecycle || !m__bIsAutoRecycle2)
				valindex = int.Parse(ValueIndex);
			else
			{
				valindex++; if (IndexLinkStr == "" || IndexLinkStr == null || IndexLinkStr2 == "" || IndexLinkStr2 == null) Log.Error("ArithmeticModule自循环关联的数据信息为空");
				object ob = GetModuleLinkData(IndexLinkStr);
				if (valindex >= (int)ob) valindex = 0;
			}

			if (obtype == "System.Double[]") { double[] m_datas = (double[])data.m_Data_Value; val = m_datas[int.Parse(ValueIndex)]; }
			if (obtype == "System.Int[]") { List<object> m_datas = new List<object>(); val = m_datas[int.Parse(ValueIndex)]; }
			if (obtype == "System.String[]") { List<object> m_datas = new List<object>(); val = m_datas[int.Parse(ValueIndex)]; }
			if (obtype == "System.Boolean[]") { List<object> m_datas = new List<object>(); val = m_datas[int.Parse(ValueIndex)]; }

			if (obtype == "System.Boolean") { val = (bool)data.m_Data_Value; }
			if (obtype == "System.Int") { val = (int)data.m_Data_Value; }
			if (obtype == "System.Float") { val = (int)data.m_Data_Value; }
			if (obtype == "System.Int32") { val = (int)data.m_Data_Value; }
			if (obtype == "System.Int64") { val = (int)data.m_Data_Value; }
			if (obtype == "System.Long") { val = (int)data.m_Data_Value; }
			if (obtype == "System.Double") { val = (double)data.m_Data_Value; }
			if (obtype == "System.String")
			{
				val = data.m_Data_Value;

				if (val.ToString().IndexOf('[') >= 0)
				{
					val = GetModuleLinkData(val.ToString());
				}


			}

			return val;

		}

	}
}
