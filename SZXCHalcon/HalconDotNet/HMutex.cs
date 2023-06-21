using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HMutex : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMutex() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMutex(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMutex(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("mutex");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMutex obj)
		{
			obj = new HMutex(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMutex[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HMutex[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HMutex(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HMutex(HTuple attribName, HTuple attribValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(564);
			SZXCArimAPI.Store(proc, 0, attribName);
			SZXCArimAPI.Store(proc, 1, attribValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attribName);
			SZXCArimAPI.UnpinTuple(attribValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMutex(string attribName, string attribValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(564);
			SZXCArimAPI.StoreS(proc, 0, attribName);
			SZXCArimAPI.StoreS(proc, 1, attribValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearMutex()
		{
			IntPtr proc = SZXCArimAPI.PreCall(560);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void UnlockMutex()
		{
			IntPtr proc = SZXCArimAPI.PreCall(561);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int TryLockMutex()
		{
			IntPtr proc = SZXCArimAPI.PreCall(562);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void LockMutex()
		{
			IntPtr proc = SZXCArimAPI.PreCall(563);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateMutex(HTuple attribName, HTuple attribValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(564);
			SZXCArimAPI.Store(proc, 0, attribName);
			SZXCArimAPI.Store(proc, 1, attribValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attribName);
			SZXCArimAPI.UnpinTuple(attribValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateMutex(string attribName, string attribValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(564);
			SZXCArimAPI.StoreS(proc, 0, attribName);
			SZXCArimAPI.StoreS(proc, 1, attribValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
