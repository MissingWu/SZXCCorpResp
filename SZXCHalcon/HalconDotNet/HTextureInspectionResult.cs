using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HTextureInspectionResult : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextureInspectionResult() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextureInspectionResult(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextureInspectionResult(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("texture_inspection_result");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextureInspectionResult obj)
		{
			obj = new HTextureInspectionResult(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextureInspectionResult[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HTextureInspectionResult[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HTextureInspectionResult(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HTextureInspectionResult(HImage image, out HRegion noveltyRegion, HTextureInspectionModel textureInspectionModel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2044);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, textureInspectionModel);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			num = HRegion.LoadNew(proc, 1, num, out noveltyRegion);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(textureInspectionModel);
		}

		public static HTuple AddTextureInspectionModelImage(HImage image, HTextureInspectionModel textureInspectionModel)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2043);
			SZXCArimAPI.Store(expr_0A, 1, image);
			SZXCArimAPI.Store(expr_0A, 0, textureInspectionModel);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(image);
			GC.KeepAlive(textureInspectionModel);
			return result;
		}

		public HRegion ApplyTextureInspectionModel(HImage image, HTextureInspectionModel textureInspectionModel)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2044);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, textureInspectionModel);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(textureInspectionModel);
			return result;
		}

		public static void ClearTextureInspectionResult(HTextureInspectionResult[] textureInspectionResultID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(textureInspectionResultID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2048);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(textureInspectionResultID);
		}

		public void ClearTextureInspectionResult()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2048);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HImage GetTextureInspectionModelImage(HTextureInspectionModel textureInspectionModel)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2075);
			SZXCArimAPI.Store(expr_0A, 0, textureInspectionModel);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HImage result;
			num = HImage.LoadNew(expr_0A, 1, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(textureInspectionModel);
			return result;
		}

		public HObject GetTextureInspectionResultObject(HTuple resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2077);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultName);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject GetTextureInspectionResultObject(string resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2077);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void TrainTextureInspectionModel(HTextureInspectionModel textureInspectionModel)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2099);
			SZXCArimAPI.Store(expr_0A, 0, textureInspectionModel);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(textureInspectionModel);
		}
	}
}
