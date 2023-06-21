using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HDeformableSurfaceMatchingResult : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableSurfaceMatchingResult() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableSurfaceMatchingResult(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableSurfaceMatchingResult(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("deformable_surface_matching_result");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableSurfaceMatchingResult obj)
		{
			obj = new HDeformableSurfaceMatchingResult(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableSurfaceMatchingResult[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDeformableSurfaceMatchingResult[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDeformableSurfaceMatchingResult(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HTuple GetDeformableSurfaceMatchingResult(HTuple resultName, HTuple resultIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1019);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, resultName);
			SZXCArimAPI.Store(proc, 2, resultIndex);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultName);
			SZXCArimAPI.UnpinTuple(resultIndex);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetDeformableSurfaceMatchingResult(string resultName, int resultIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1019);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, resultName);
			SZXCArimAPI.StoreI(proc, 2, resultIndex);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void ClearDeformableSurfaceMatchingResult(HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
		{
			HTuple hTuple = HHandleBase.ConcatArray(deformableSurfaceMatchingResult);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1020);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(deformableSurfaceMatchingResult);
		}

		public void ClearDeformableSurfaceMatchingResult()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1020);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HTuple RefineDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, HObjectModel3D objectModel3D, double relSamplingDistance, HObjectModel3D initialDeformationObjectModel3D, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1026);
			SZXCArimAPI.Store(expr_0A, 0, deformableSurfaceModel);
			SZXCArimAPI.Store(expr_0A, 1, objectModel3D);
			SZXCArimAPI.StoreD(expr_0A, 2, relSamplingDistance);
			SZXCArimAPI.Store(expr_0A, 3, initialDeformationObjectModel3D);
			SZXCArimAPI.Store(expr_0A, 4, genParamName);
			SZXCArimAPI.Store(expr_0A, 5, genParamValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			num = HDeformableSurfaceMatchingResult.LoadNew(expr_0A, 1, num, out deformableSurfaceMatchingResult);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(deformableSurfaceModel);
			GC.KeepAlive(objectModel3D);
			GC.KeepAlive(initialDeformationObjectModel3D);
			return result;
		}

		public double RefineDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, HObjectModel3D objectModel3D, double relSamplingDistance, HObjectModel3D initialDeformationObjectModel3D, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1026);
			SZXCArimAPI.Store(proc, 0, deformableSurfaceModel);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.Store(proc, 3, initialDeformationObjectModel3D);
			SZXCArimAPI.StoreS(proc, 4, genParamName);
			SZXCArimAPI.StoreS(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(deformableSurfaceModel);
			GC.KeepAlive(objectModel3D);
			GC.KeepAlive(initialDeformationObjectModel3D);
			return result;
		}

		public static HTuple FindDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, HObjectModel3D objectModel3D, double relSamplingDistance, HTuple minScore, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1027);
			SZXCArimAPI.Store(expr_0A, 0, deformableSurfaceModel);
			SZXCArimAPI.Store(expr_0A, 1, objectModel3D);
			SZXCArimAPI.StoreD(expr_0A, 2, relSamplingDistance);
			SZXCArimAPI.Store(expr_0A, 3, minScore);
			SZXCArimAPI.Store(expr_0A, 4, genParamName);
			SZXCArimAPI.Store(expr_0A, 5, genParamValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			num = HDeformableSurfaceMatchingResult.LoadNew(expr_0A, 1, num, out deformableSurfaceMatchingResult);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(deformableSurfaceModel);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public double FindDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, HObjectModel3D objectModel3D, double relSamplingDistance, double minScore, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1027);
			SZXCArimAPI.Store(proc, 0, deformableSurfaceModel);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 1, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(deformableSurfaceModel);
			GC.KeepAlive(objectModel3D);
			return result;
		}
	}
}
