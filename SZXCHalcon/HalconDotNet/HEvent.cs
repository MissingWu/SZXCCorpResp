using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HEvent : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HEvent() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HEvent(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HEvent(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("event");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HEvent obj)
		{
			obj = new HEvent(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HEvent[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HEvent[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HEvent(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HEvent(HTuple attribName, HTuple attribValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(558);
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

		public HEvent(string attribName, string attribValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(558);
			SZXCArimAPI.StoreS(proc, 0, attribName);
			SZXCArimAPI.StoreS(proc, 1, attribValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearEvent()
		{
			IntPtr proc = SZXCArimAPI.PreCall(554);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SignalEvent()
		{
			IntPtr proc = SZXCArimAPI.PreCall(555);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int TryWaitEvent()
		{
			IntPtr proc = SZXCArimAPI.PreCall(556);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WaitEvent()
		{
			IntPtr proc = SZXCArimAPI.PreCall(557);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateEvent(HTuple attribName, HTuple attribValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(558);
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

		public void CreateEvent(string attribName, string attribValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(558);
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
