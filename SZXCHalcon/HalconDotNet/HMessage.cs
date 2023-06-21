using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HMessage : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMessage(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMessage(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("message");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessage obj)
		{
			obj = new HMessage(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMessage[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HMessage[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HMessage(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HMessage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(541);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMessage(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2164);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMessage(string fileName, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2164);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetMessageParam(string genParamName, HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(534);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, key);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMessageParam(string genParamName, string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(534);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, key);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetMessageParam(string genParamName, HTuple key, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(535);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, key);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMessageParam(string genParamName, string key, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(535);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, key);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HObject GetMessageObj(HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(536);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, key);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject GetMessageObj(string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(536);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, key);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetMessageObj(HObject objectData, HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(537);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectData);
			SZXCArimAPI.Store(proc, 1, key);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectData);
		}

		public void SetMessageObj(HObject objectData, string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(537);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectData);
			SZXCArimAPI.StoreS(proc, 1, key);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectData);
		}

		public HTuple GetMessageTuple(HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(538);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, key);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMessageTuple(string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(538);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, key);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetMessageTuple(HTuple key, HTuple tupleData)
		{
			IntPtr proc = SZXCArimAPI.PreCall(539);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, key);
			SZXCArimAPI.Store(proc, 2, tupleData);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			SZXCArimAPI.UnpinTuple(tupleData);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMessageTuple(string key, HTuple tupleData)
		{
			IntPtr proc = SZXCArimAPI.PreCall(539);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, key);
			SZXCArimAPI.Store(proc, 2, tupleData);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(tupleData);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ClearMessage(HMessage[] messageHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(messageHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(540);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(messageHandle);
		}

		public void ClearMessage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(540);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateMessage()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(541);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ReadMessage(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2164);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ReadMessage(string fileName, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2164);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteMessage(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2175);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteMessage(string fileName, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2175);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}
	}
}
