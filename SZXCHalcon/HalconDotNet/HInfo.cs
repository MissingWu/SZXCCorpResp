using System;

namespace SZXCArimEngine
{
	public class HInfo
	{
		public static HTuple QueryOperatorInfo()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1108);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QueryParamInfo()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1109);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetOperatorName(string pattern)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1110);
			SZXCArimAPI.StoreS(expr_0A, 0, pattern);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetParamTypes(string operatorName, out HTuple outpCtrlParType)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1111);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out outpCtrlParType);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string GetParamNum(string operatorName, out int inpObjPar, out int outpObjPar, out int inpCtrlPar, out int outpCtrlPar, out string type)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1112);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			SZXCArimAPI.InitOCT(expr_0A, 4);
			SZXCArimAPI.InitOCT(expr_0A, 5);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadI(expr_0A, 1, num, out inpObjPar);
			num = SZXCArimAPI.LoadI(expr_0A, 2, num, out outpObjPar);
			num = SZXCArimAPI.LoadI(expr_0A, 3, num, out inpCtrlPar);
			num = SZXCArimAPI.LoadI(expr_0A, 4, num, out outpCtrlPar);
			num = SZXCArimAPI.LoadS(expr_0A, 5, num, out type);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetParamNames(string operatorName, out HTuple outpObjPar, out HTuple inpCtrlPar, out HTuple outpCtrlPar)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1113);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out outpObjPar);
			num = HTuple.LoadNew(expr_0A, 2, num, out inpCtrlPar);
			num = HTuple.LoadNew(expr_0A, 3, num, out outpCtrlPar);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetOperatorInfo(string operatorName, string slot)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1114);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.StoreS(expr_0A, 1, slot);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetParamInfo(string operatorName, string paramName, string slot)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1115);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.StoreS(expr_0A, 1, paramName);
			SZXCArimAPI.StoreS(expr_0A, 2, slot);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple SearchOperator(string keyword)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1116);
			SZXCArimAPI.StoreS(expr_0A, 0, keyword);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetKeywords(string operatorName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1117);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetChapterInfo(HTuple chapter)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1118);
			SZXCArimAPI.Store(expr_0A, 0, chapter);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(chapter);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetChapterInfo(string chapter)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1118);
			SZXCArimAPI.StoreS(expr_0A, 0, chapter);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QueryWindowType()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1177);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string GetComprise(HWindow windowHandle)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1251);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static HTuple QueryShape()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1252);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void QueryLineWidth(out int min, out int max)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1254);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadI(expr_0A, 0, num, out min);
			num = SZXCArimAPI.LoadI(expr_0A, 1, num, out max);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static HTuple QueryColored()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1257);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string InfoFramegrabber(string name, string query, out HTuple valueList)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2034);
			SZXCArimAPI.StoreS(expr_0A, 0, name);
			SZXCArimAPI.StoreS(expr_0A, 1, query);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out valueList);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}
	}
}
