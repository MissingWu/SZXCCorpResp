using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HSurfaceMatchingResult : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSurfaceMatchingResult() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSurfaceMatchingResult(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSurfaceMatchingResult(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("surface_matching_result");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSurfaceMatchingResult obj)
		{
			obj = new HSurfaceMatchingResult(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSurfaceMatchingResult[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HSurfaceMatchingResult[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HSurfaceMatchingResult(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HTuple GetSurfaceMatchingResult(HTuple resultName, int resultIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1032);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, resultName);
			SZXCArimAPI.StoreI(proc, 2, resultIndex);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetSurfaceMatchingResult(string resultName, int resultIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1032);
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

		public static void ClearSurfaceMatchingResult(HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(surfaceMatchingResultID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1034);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(surfaceMatchingResultID);
		}

		public void ClearSurfaceMatchingResult()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1034);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HPose[] RefineSurfaceModelPose(HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, HPose[] initialPose, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			HTuple hTuple = HData.ConcatArray(initialPose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1041);
			SZXCArimAPI.Store(expr_13, 0, surfaceModelID);
			SZXCArimAPI.Store(expr_13, 1, objectModel3D);
			SZXCArimAPI.Store(expr_13, 2, hTuple);
			SZXCArimAPI.Store(expr_13, 3, minScore);
			SZXCArimAPI.StoreS(expr_13, 4, returnResultHandle);
			SZXCArimAPI.Store(expr_13, 5, genParamName);
			SZXCArimAPI.Store(expr_13, 6, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			SZXCArimAPI.InitOCT(expr_13, 2);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(expr_13, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(expr_13, num);
			HPose[] arg_C1_0 = HPose.SplitArray(data);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return arg_C1_0;
		}

		public HPose RefineSurfaceModelPose(HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, HPose initialPose, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1041);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, initialPose);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(initialPose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 2, num);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public static HPose[] FindSurfaceModel(HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1042);
			SZXCArimAPI.Store(expr_0A, 0, surfaceModelID);
			SZXCArimAPI.Store(expr_0A, 1, objectModel3D);
			SZXCArimAPI.StoreD(expr_0A, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(expr_0A, 3, keyPointFraction);
			SZXCArimAPI.Store(expr_0A, 4, minScore);
			SZXCArimAPI.StoreS(expr_0A, 5, returnResultHandle);
			SZXCArimAPI.Store(expr_0A, 6, genParamName);
			SZXCArimAPI.Store(expr_0A, 7, genParamValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(expr_0A, 0, num, out data);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(expr_0A, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(expr_0A, num);
			HPose[] arg_BC_0 = HPose.SplitArray(data);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return arg_BC_0;
		}

		public HPose FindSurfaceModel(HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1042);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 2, num);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public static HPose[] FindSurfaceModelImage(HImage image, HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2069);
			SZXCArimAPI.Store(expr_0A, 1, image);
			SZXCArimAPI.Store(expr_0A, 0, surfaceModelID);
			SZXCArimAPI.Store(expr_0A, 1, objectModel3D);
			SZXCArimAPI.StoreD(expr_0A, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(expr_0A, 3, keyPointFraction);
			SZXCArimAPI.Store(expr_0A, 4, minScore);
			SZXCArimAPI.StoreS(expr_0A, 5, returnResultHandle);
			SZXCArimAPI.Store(expr_0A, 6, genParamName);
			SZXCArimAPI.Store(expr_0A, 7, genParamValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(expr_0A, 0, num, out data);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(expr_0A, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(expr_0A, num);
			HPose[] arg_CB_0 = HPose.SplitArray(data);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return arg_CB_0;
		}

		public HPose FindSurfaceModelImage(HImage image, HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2069);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 2, num);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public static HPose[] RefineSurfaceModelPoseImage(HImage image, HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, HPose[] initialPose, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			HTuple hTuple = HData.ConcatArray(initialPose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2084);
			SZXCArimAPI.Store(expr_13, 1, image);
			SZXCArimAPI.Store(expr_13, 0, surfaceModelID);
			SZXCArimAPI.Store(expr_13, 1, objectModel3D);
			SZXCArimAPI.Store(expr_13, 2, hTuple);
			SZXCArimAPI.Store(expr_13, 3, minScore);
			SZXCArimAPI.StoreS(expr_13, 4, returnResultHandle);
			SZXCArimAPI.Store(expr_13, 5, genParamName);
			SZXCArimAPI.Store(expr_13, 6, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			SZXCArimAPI.InitOCT(expr_13, 2);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(expr_13, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(expr_13, num);
			HPose[] arg_D1_0 = HPose.SplitArray(data);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return arg_D1_0;
		}

		public HPose RefineSurfaceModelPoseImage(HImage image, HSurfaceModel surfaceModelID, HObjectModel3D objectModel3D, HPose initialPose, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2084);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, initialPose);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(initialPose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 2, num);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			GC.KeepAlive(objectModel3D);
			return result;
		}
	}
}
