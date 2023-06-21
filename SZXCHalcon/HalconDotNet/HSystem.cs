using System;

namespace SZXCArimEngine
{
	public class HSystem
	{
		public static void WaitSeconds(double seconds)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(315);
			SZXCArimAPI.StoreD(expr_0A, 0, seconds);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SystemCall(string command)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(316);
			SZXCArimAPI.StoreS(expr_0A, 0, command);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetSystem(HTuple systemParameter, HTuple value)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(317);
			SZXCArimAPI.Store(expr_0A, 0, systemParameter);
			SZXCArimAPI.Store(expr_0A, 1, value);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(systemParameter);
			SZXCArimAPI.UnpinTuple(value);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetSystem(string systemParameter, string value)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(317);
			SZXCArimAPI.StoreS(expr_0A, 0, systemParameter);
			SZXCArimAPI.StoreS(expr_0A, 1, value);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetCheck(HTuple check)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(318);
			SZXCArimAPI.Store(expr_0A, 0, check);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(check);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetCheck(string check)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(318);
			SZXCArimAPI.StoreS(expr_0A, 0, check);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void ResetObjDb(int defaultImageWidth, int defaultImageHeight, int defaultChannels)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(319);
			SZXCArimAPI.StoreI(expr_0A, 0, defaultImageWidth);
			SZXCArimAPI.StoreI(expr_0A, 1, defaultImageHeight);
			SZXCArimAPI.StoreI(expr_0A, 2, defaultChannels);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple GetSystem(HTuple query)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(320);
			SZXCArimAPI.Store(expr_0A, 0, query);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(query);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetSystem(string query)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(320);
			SZXCArimAPI.StoreS(expr_0A, 0, query);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetCheck()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(321);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string GetErrorText(int errorCode)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(322);
			SZXCArimAPI.StoreI(expr_0A, 0, errorCode);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static double CountSeconds()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(323);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			double result;
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static int CountRelation(string relationName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(324);
			SZXCArimAPI.StoreS(expr_0A, 0, relationName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			int result;
			num = SZXCArimAPI.LoadI(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string GetExtendedErrorInfo(out int errorCode, out string errorMessage)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(344);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadI(expr_0A, 1, num, out errorCode);
			num = SZXCArimAPI.LoadS(expr_0A, 2, num, out errorMessage);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetModules(out int moduleKey)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(345);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadI(expr_0A, 1, num, out moduleKey);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QuerySpy(out HTuple values)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(371);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out values);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void SetSpy(string classVal, HTuple value)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(372);
			SZXCArimAPI.StoreS(expr_0A, 0, classVal);
			SZXCArimAPI.Store(expr_0A, 1, value);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(value);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetSpy(string classVal, string value)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(372);
			SZXCArimAPI.StoreS(expr_0A, 0, classVal);
			SZXCArimAPI.StoreS(expr_0A, 1, value);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple GetSpy(string classVal)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(373);
			SZXCArimAPI.StoreS(expr_0A, 0, classVal);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void SetAopInfo(HTuple operatorName, HTuple indexName, HTuple indexValue, string infoName, HTuple infoValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(566);
			SZXCArimAPI.Store(expr_0A, 0, operatorName);
			SZXCArimAPI.Store(expr_0A, 1, indexName);
			SZXCArimAPI.Store(expr_0A, 2, indexValue);
			SZXCArimAPI.StoreS(expr_0A, 3, infoName);
			SZXCArimAPI.Store(expr_0A, 4, infoValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(operatorName);
			SZXCArimAPI.UnpinTuple(indexName);
			SZXCArimAPI.UnpinTuple(indexValue);
			SZXCArimAPI.UnpinTuple(infoValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetAopInfo(string operatorName, string indexName, string indexValue, string infoName, int infoValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(566);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.StoreS(expr_0A, 1, indexName);
			SZXCArimAPI.StoreS(expr_0A, 2, indexValue);
			SZXCArimAPI.StoreS(expr_0A, 3, infoName);
			SZXCArimAPI.StoreI(expr_0A, 4, infoValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple GetAopInfo(HTuple operatorName, HTuple indexName, HTuple indexValue, string infoName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(567);
			SZXCArimAPI.Store(expr_0A, 0, operatorName);
			SZXCArimAPI.Store(expr_0A, 1, indexName);
			SZXCArimAPI.Store(expr_0A, 2, indexValue);
			SZXCArimAPI.StoreS(expr_0A, 3, infoName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(operatorName);
			SZXCArimAPI.UnpinTuple(indexName);
			SZXCArimAPI.UnpinTuple(indexValue);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string GetAopInfo(string operatorName, HTuple indexName, HTuple indexValue, string infoName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(567);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.Store(expr_0A, 1, indexName);
			SZXCArimAPI.Store(expr_0A, 2, indexValue);
			SZXCArimAPI.StoreS(expr_0A, 3, infoName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(indexName);
			SZXCArimAPI.UnpinTuple(indexValue);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QueryAopInfo(HTuple operatorName, HTuple indexName, HTuple indexValue, out HTuple value)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(568);
			SZXCArimAPI.Store(expr_0A, 0, operatorName);
			SZXCArimAPI.Store(expr_0A, 1, indexName);
			SZXCArimAPI.Store(expr_0A, 2, indexValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(operatorName);
			SZXCArimAPI.UnpinTuple(indexName);
			SZXCArimAPI.UnpinTuple(indexValue);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out value);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QueryAopInfo(string operatorName, string indexName, string indexValue, out HTuple value)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(568);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.StoreS(expr_0A, 1, indexName);
			SZXCArimAPI.StoreS(expr_0A, 2, indexValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out value);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void OptimizeAop(HTuple operatorName, HTuple iconicType, HTuple fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(569);
			SZXCArimAPI.Store(expr_0A, 0, operatorName);
			SZXCArimAPI.Store(expr_0A, 1, iconicType);
			SZXCArimAPI.Store(expr_0A, 2, fileName);
			SZXCArimAPI.Store(expr_0A, 3, genParamName);
			SZXCArimAPI.Store(expr_0A, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(operatorName);
			SZXCArimAPI.UnpinTuple(iconicType);
			SZXCArimAPI.UnpinTuple(fileName);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void OptimizeAop(string operatorName, string iconicType, string fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(569);
			SZXCArimAPI.StoreS(expr_0A, 0, operatorName);
			SZXCArimAPI.StoreS(expr_0A, 1, iconicType);
			SZXCArimAPI.StoreS(expr_0A, 2, fileName);
			SZXCArimAPI.Store(expr_0A, 3, genParamName);
			SZXCArimAPI.Store(expr_0A, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void WriteAopKnowledge(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(570);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.Store(expr_0A, 1, genParamName);
			SZXCArimAPI.Store(expr_0A, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void WriteAopKnowledge(string fileName, string genParamName, string genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(570);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.StoreS(expr_0A, 1, genParamName);
			SZXCArimAPI.StoreS(expr_0A, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple ReadAopKnowledge(string fileName, HTuple genParamName, HTuple genParamValue, out HTuple operatorNames)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(571);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.Store(expr_0A, 1, genParamName);
			SZXCArimAPI.Store(expr_0A, 2, genParamValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out operatorNames);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple ReadAopKnowledge(string fileName, string genParamName, string genParamValue, out string operatorNames)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(571);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.StoreS(expr_0A, 1, genParamName);
			SZXCArimAPI.StoreS(expr_0A, 2, genParamValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadS(expr_0A, 1, num, out operatorNames);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void SetWindowType(string windowType)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1173);
			SZXCArimAPI.StoreS(expr_0A, 0, windowType);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple GetWindowAttr(string attributeName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1175);
			SZXCArimAPI.StoreS(expr_0A, 0, attributeName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void SetWindowAttr(string attributeName, HTuple attributeValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1176);
			SZXCArimAPI.StoreS(expr_0A, 0, attributeName);
			SZXCArimAPI.Store(expr_0A, 1, attributeValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(attributeValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetWindowAttr(string attributeName, string attributeValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1176);
			SZXCArimAPI.StoreS(expr_0A, 0, attributeName);
			SZXCArimAPI.StoreS(expr_0A, 1, attributeValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
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

		public static int GetCurrentHthreadId()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2152);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			int result;
			num = SZXCArimAPI.LoadI(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetSystemInfo(HTuple query)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2160);
			SZXCArimAPI.Store(expr_0A, 0, query);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(query);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GetSystemInfo(string query)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2160);
			SZXCArimAPI.StoreS(expr_0A, 0, query);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void InterruptOperator(int HThreadID, string mode)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2161);
			SZXCArimAPI.StoreI(expr_0A, 0, HThreadID);
			SZXCArimAPI.StoreS(expr_0A, 1, mode);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}
	}
}
