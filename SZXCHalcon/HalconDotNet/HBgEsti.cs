using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HBgEsti : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBgEsti() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBgEsti(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBgEsti(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("bg_estimation");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBgEsti obj)
		{
			obj = new HBgEsti(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBgEsti[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HBgEsti[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HBgEsti(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HBgEsti(HImage initializeImage, double syspar1, double syspar2, string gainMode, double gain1, double gain2, string adaptMode, double minDiff, int statNum, double confidenceC, double timeC)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2008);
			SZXCArimAPI.Store(proc, 1, initializeImage);
			SZXCArimAPI.StoreD(proc, 0, syspar1);
			SZXCArimAPI.StoreD(proc, 1, syspar2);
			SZXCArimAPI.StoreS(proc, 2, gainMode);
			SZXCArimAPI.StoreD(proc, 3, gain1);
			SZXCArimAPI.StoreD(proc, 4, gain2);
			SZXCArimAPI.StoreS(proc, 5, adaptMode);
			SZXCArimAPI.StoreD(proc, 6, minDiff);
			SZXCArimAPI.StoreI(proc, 7, statNum);
			SZXCArimAPI.StoreD(proc, 8, confidenceC);
			SZXCArimAPI.StoreD(proc, 9, timeC);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(initializeImage);
		}

		public void CloseBgEsti()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2002);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage GiveBgEsti()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2003);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void UpdateBgEsti(HImage presentImage, HRegion upDateRegion)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2004);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, presentImage);
			SZXCArimAPI.Store(proc, 2, upDateRegion);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(presentImage);
			GC.KeepAlive(upDateRegion);
		}

		public HRegion RunBgEsti(HImage presentImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2005);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, presentImage);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(presentImage);
			return result;
		}

		public double GetBgEstiParams(out double syspar2, out string gainMode, out double gain1, out double gain2, out string adaptMode, out double minDiff, out int statNum, out double confidenceC, out double timeC)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2006);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			SZXCArimAPI.InitOCT(proc, 8);
			SZXCArimAPI.InitOCT(proc, 9);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out syspar2);
			num = SZXCArimAPI.LoadS(proc, 2, num, out gainMode);
			num = SZXCArimAPI.LoadD(proc, 3, num, out gain1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out gain2);
			num = SZXCArimAPI.LoadS(proc, 5, num, out adaptMode);
			num = SZXCArimAPI.LoadD(proc, 6, num, out minDiff);
			num = SZXCArimAPI.LoadI(proc, 7, num, out statNum);
			num = SZXCArimAPI.LoadD(proc, 8, num, out confidenceC);
			num = SZXCArimAPI.LoadD(proc, 9, num, out timeC);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetBgEstiParams(double syspar1, double syspar2, string gainMode, double gain1, double gain2, string adaptMode, double minDiff, int statNum, double confidenceC, double timeC)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2007);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, syspar1);
			SZXCArimAPI.StoreD(proc, 2, syspar2);
			SZXCArimAPI.StoreS(proc, 3, gainMode);
			SZXCArimAPI.StoreD(proc, 4, gain1);
			SZXCArimAPI.StoreD(proc, 5, gain2);
			SZXCArimAPI.StoreS(proc, 6, adaptMode);
			SZXCArimAPI.StoreD(proc, 7, minDiff);
			SZXCArimAPI.StoreI(proc, 8, statNum);
			SZXCArimAPI.StoreD(proc, 9, confidenceC);
			SZXCArimAPI.StoreD(proc, 10, timeC);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateBgEsti(HImage initializeImage, double syspar1, double syspar2, string gainMode, double gain1, double gain2, string adaptMode, double minDiff, int statNum, double confidenceC, double timeC)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2008);
			SZXCArimAPI.Store(proc, 1, initializeImage);
			SZXCArimAPI.StoreD(proc, 0, syspar1);
			SZXCArimAPI.StoreD(proc, 1, syspar2);
			SZXCArimAPI.StoreS(proc, 2, gainMode);
			SZXCArimAPI.StoreD(proc, 3, gain1);
			SZXCArimAPI.StoreD(proc, 4, gain2);
			SZXCArimAPI.StoreS(proc, 5, adaptMode);
			SZXCArimAPI.StoreD(proc, 6, minDiff);
			SZXCArimAPI.StoreI(proc, 7, statNum);
			SZXCArimAPI.StoreD(proc, 8, confidenceC);
			SZXCArimAPI.StoreD(proc, 9, timeC);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(initializeImage);
		}
	}
}
