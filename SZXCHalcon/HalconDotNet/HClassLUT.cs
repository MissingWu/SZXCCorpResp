using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HClassLUT : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassLUT() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassLUT(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassLUT(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("class_lut");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassLUT obj)
		{
			obj = new HClassLUT(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassLUT[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HClassLUT[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HClassLUT(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HClassLUT(HClassKnn KNNHandle, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1819);
			SZXCArimAPI.Store(proc, 0, KNNHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(KNNHandle);
		}

		public HClassLUT(HClassGmm GMMHandle, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1820);
			SZXCArimAPI.Store(proc, 0, GMMHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(GMMHandle);
		}

		public HClassLUT(HClassSvm SVMHandle, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1821);
			SZXCArimAPI.Store(proc, 0, SVMHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SVMHandle);
		}

		public HClassLUT(HClassMlp MLPHandle, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1822);
			SZXCArimAPI.Store(proc, 0, MLPHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(MLPHandle);
		}

		public HRegion ClassifyImageClassLut(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(428);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public static void ClearClassLut(HClassLUT[] classLUTHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(classLUTHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1818);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(classLUTHandle);
		}

		public void ClearClassLut()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1818);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateClassLutKnn(HClassKnn KNNHandle, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1819);
			SZXCArimAPI.Store(proc, 0, KNNHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(KNNHandle);
		}

		public void CreateClassLutGmm(HClassGmm GMMHandle, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1820);
			SZXCArimAPI.Store(proc, 0, GMMHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(GMMHandle);
		}

		public void CreateClassLutSvm(HClassSvm SVMHandle, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1821);
			SZXCArimAPI.Store(proc, 0, SVMHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SVMHandle);
		}

		public void CreateClassLutMlp(HClassMlp MLPHandle, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1822);
			SZXCArimAPI.Store(proc, 0, MLPHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(MLPHandle);
		}
	}
}
