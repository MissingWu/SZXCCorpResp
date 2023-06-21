using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HCondition : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCondition() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCondition(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCondition(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("condition");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCondition obj)
		{
			obj = new HCondition(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCondition[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HCondition[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HCondition(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HCondition(HTuple attribName, HTuple attribValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(548);
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

		public HCondition(string attribName, string attribValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(548);
			SZXCArimAPI.StoreS(proc, 0, attribName);
			SZXCArimAPI.StoreS(proc, 1, attribValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearCondition()
		{
			IntPtr proc = SZXCArimAPI.PreCall(543);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void BroadcastCondition()
		{
			IntPtr proc = SZXCArimAPI.PreCall(544);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SignalCondition()
		{
			IntPtr proc = SZXCArimAPI.PreCall(545);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TimedWaitCondition(HMutex mutexHandle, int timeout)
		{
			IntPtr proc = SZXCArimAPI.PreCall(546);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, mutexHandle);
			SZXCArimAPI.StoreI(proc, 2, timeout);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(mutexHandle);
		}

		public void WaitCondition(HMutex mutexHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(547);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, mutexHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(mutexHandle);
		}

		public void CreateCondition(HTuple attribName, HTuple attribValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(548);
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

		public void CreateCondition(string attribName, string attribValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(548);
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
