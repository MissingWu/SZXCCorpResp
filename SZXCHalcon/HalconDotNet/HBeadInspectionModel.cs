using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HBeadInspectionModel : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBeadInspectionModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBeadInspectionModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBeadInspectionModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("bead_inspection_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBeadInspectionModel obj)
		{
			obj = new HBeadInspectionModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBeadInspectionModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HBeadInspectionModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HBeadInspectionModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HBeadInspectionModel(HXLD beadContour, HTuple targetThickness, HTuple thicknessTolerance, HTuple positionTolerance, string polarity, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1985);
			SZXCArimAPI.Store(proc, 1, beadContour);
			SZXCArimAPI.Store(proc, 0, targetThickness);
			SZXCArimAPI.Store(proc, 1, thicknessTolerance);
			SZXCArimAPI.Store(proc, 2, positionTolerance);
			SZXCArimAPI.StoreS(proc, 3, polarity);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(targetThickness);
			SZXCArimAPI.UnpinTuple(thicknessTolerance);
			SZXCArimAPI.UnpinTuple(positionTolerance);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(beadContour);
		}

		public HBeadInspectionModel(HXLD beadContour, int targetThickness, int thicknessTolerance, int positionTolerance, string polarity, string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1985);
			SZXCArimAPI.Store(proc, 1, beadContour);
			SZXCArimAPI.StoreI(proc, 0, targetThickness);
			SZXCArimAPI.StoreI(proc, 1, thicknessTolerance);
			SZXCArimAPI.StoreI(proc, 2, positionTolerance);
			SZXCArimAPI.StoreS(proc, 3, polarity);
			SZXCArimAPI.StoreS(proc, 4, genParamName);
			SZXCArimAPI.StoreI(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(beadContour);
		}

		public HTuple GetBeadInspectionParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1981);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetBeadInspectionParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1981);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetBeadInspectionParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1982);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetBeadInspectionParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1982);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HXLD ApplyBeadInspectionModel(HImage image, out HXLD rightContour, out HXLD errorSegment, out HTuple errorType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1983);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			num = HXLD.LoadNew(proc, 2, num, out rightContour);
			num = HXLD.LoadNew(proc, 3, num, out errorSegment);
			num = HTuple.LoadNew(proc, 0, num, out errorType);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void ClearBeadInspectionModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1984);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateBeadInspectionModel(HXLD beadContour, HTuple targetThickness, HTuple thicknessTolerance, HTuple positionTolerance, string polarity, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1985);
			SZXCArimAPI.Store(proc, 1, beadContour);
			SZXCArimAPI.Store(proc, 0, targetThickness);
			SZXCArimAPI.Store(proc, 1, thicknessTolerance);
			SZXCArimAPI.Store(proc, 2, positionTolerance);
			SZXCArimAPI.StoreS(proc, 3, polarity);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(targetThickness);
			SZXCArimAPI.UnpinTuple(thicknessTolerance);
			SZXCArimAPI.UnpinTuple(positionTolerance);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(beadContour);
		}

		public void CreateBeadInspectionModel(HXLD beadContour, int targetThickness, int thicknessTolerance, int positionTolerance, string polarity, string genParamName, int genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1985);
			SZXCArimAPI.Store(proc, 1, beadContour);
			SZXCArimAPI.StoreI(proc, 0, targetThickness);
			SZXCArimAPI.StoreI(proc, 1, thicknessTolerance);
			SZXCArimAPI.StoreI(proc, 2, positionTolerance);
			SZXCArimAPI.StoreS(proc, 3, polarity);
			SZXCArimAPI.StoreS(proc, 4, genParamName);
			SZXCArimAPI.StoreI(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(beadContour);
		}
	}
}
