using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HBarrier : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBarrier() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBarrier(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBarrier(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("barrier");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarrier obj)
		{
			obj = new HBarrier(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarrier[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HBarrier[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HBarrier(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HBarrier(HTuple attribName, HTuple attribValue, int teamSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(552);
			SZXCArimAPI.Store(proc, 0, attribName);
			SZXCArimAPI.Store(proc, 1, attribValue);
			SZXCArimAPI.StoreI(proc, 2, teamSize);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attribName);
			SZXCArimAPI.UnpinTuple(attribValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HBarrier(string attribName, string attribValue, int teamSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(552);
			SZXCArimAPI.StoreS(proc, 0, attribName);
			SZXCArimAPI.StoreS(proc, 1, attribValue);
			SZXCArimAPI.StoreI(proc, 2, teamSize);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearBarrier()
		{
			IntPtr proc = SZXCArimAPI.PreCall(550);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WaitBarrier()
		{
			IntPtr proc = SZXCArimAPI.PreCall(551);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateBarrier(HTuple attribName, HTuple attribValue, int teamSize)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(552);
			SZXCArimAPI.Store(proc, 0, attribName);
			SZXCArimAPI.Store(proc, 1, attribValue);
			SZXCArimAPI.StoreI(proc, 2, teamSize);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attribName);
			SZXCArimAPI.UnpinTuple(attribValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateBarrier(string attribName, string attribValue, int teamSize)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(552);
			SZXCArimAPI.StoreS(proc, 0, attribName);
			SZXCArimAPI.StoreS(proc, 1, attribValue);
			SZXCArimAPI.StoreI(proc, 2, teamSize);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
