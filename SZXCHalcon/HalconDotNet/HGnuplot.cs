using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HGnuplot : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HGnuplot() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HGnuplot(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HGnuplot(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("gnuplot");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HGnuplot obj)
		{
			obj = new HGnuplot(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HGnuplot[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HGnuplot[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HGnuplot(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public void GnuplotPlotFunct1d(HFunction1D function)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1295);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, function);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(function);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GnuplotPlotCtrl(HTuple values)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1296);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, values);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(values);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GnuplotPlotImage(HImage image, int samplesX, int samplesY, HTuple viewRotX, HTuple viewRotZ, string hidden3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1297);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 1, samplesX);
			SZXCArimAPI.StoreI(proc, 2, samplesY);
			SZXCArimAPI.Store(proc, 3, viewRotX);
			SZXCArimAPI.Store(proc, 4, viewRotZ);
			SZXCArimAPI.StoreS(proc, 5, hidden3D);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(viewRotX);
			SZXCArimAPI.UnpinTuple(viewRotZ);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void GnuplotPlotImage(HImage image, int samplesX, int samplesY, double viewRotX, double viewRotZ, string hidden3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1297);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 1, samplesX);
			SZXCArimAPI.StoreI(proc, 2, samplesY);
			SZXCArimAPI.StoreD(proc, 3, viewRotX);
			SZXCArimAPI.StoreD(proc, 4, viewRotZ);
			SZXCArimAPI.StoreS(proc, 5, hidden3D);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void GnuplotClose()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1298);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GnuplotOpenFile(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1299);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GnuplotOpenPipe()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1300);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
