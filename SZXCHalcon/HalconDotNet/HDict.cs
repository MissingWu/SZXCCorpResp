using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HDict : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDict(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDict(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("dict");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDict obj)
		{
			obj = new HDict(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDict[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDict[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDict(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDict()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2149);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDict(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2162);
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

		public HDict(string fileName, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2162);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDict CopyDict(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2148);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HDict result;
			num = HDict.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDict CopyDict(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2148);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HDict result;
			num = HDict.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateDict()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2149);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HObject GetDictObject(HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2153);
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

		public HObject GetDictObject(string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2153);
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

		public HTuple GetDictParam(string genParamName, HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2154);
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

		public HTuple GetDictParam(string genParamName, string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2154);
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

		public HTuple GetDictTuple(HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2155);
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

		public HTuple GetDictTuple(string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2155);
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

		public void ReadDict(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2162);
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

		public void ReadDict(string fileName, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2162);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void RemoveDictKey(HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2165);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, key);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveDictKey(string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2165);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, key);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDictObject(HObject objectVal, HTuple key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2169);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectVal);
			SZXCArimAPI.Store(proc, 1, key);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectVal);
		}

		public void SetDictObject(HObject objectVal, string key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2169);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectVal);
			SZXCArimAPI.StoreS(proc, 1, key);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectVal);
		}

		public void SetDictTuple(HTuple key, HTuple tuple)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2170);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, key);
			SZXCArimAPI.Store(proc, 2, tuple);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(key);
			SZXCArimAPI.UnpinTuple(tuple);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDictTuple(string key, HTuple tuple)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2170);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, key);
			SZXCArimAPI.Store(proc, 2, tuple);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(tuple);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteDict(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2173);
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

		public void WriteDict(string fileName, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2173);
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
