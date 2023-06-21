using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HTextModel : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("text_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextModel obj)
		{
			obj = new HTextModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HTextModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HTextModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HTextModel(string mode, HTuple OCRClassifier)
		{
			IntPtr proc = SZXCArimAPI.PreCall(422);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, OCRClassifier);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(OCRClassifier);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTextModel(string mode, string OCRClassifier)
		{
			IntPtr proc = SZXCArimAPI.PreCall(422);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreS(proc, 1, OCRClassifier);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTextModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(423);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTextResult FindText(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(417);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTextResult result;
			num = HTextResult.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple GetTextModelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(418);
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

		public void SetTextModelParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(419);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetTextModelParam(string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(419);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreI(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ClearTextModel(HTextModel[] textModel)
		{
			HTuple hTuple = HHandleBase.ConcatArray(textModel);
			IntPtr expr_13 = SZXCArimAPI.PreCall(421);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(textModel);
		}

		public void ClearTextModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(421);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateTextModelReader(string mode, HTuple OCRClassifier)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(422);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, OCRClassifier);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(OCRClassifier);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateTextModelReader(string mode, string OCRClassifier)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(422);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreS(proc, 1, OCRClassifier);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateTextModel()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(423);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
