using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HTextResult : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextResult() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextResult(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextResult(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("text_result");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextResult obj)
		{
			obj = new HTextResult(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextResult[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HTextResult[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HTextResult(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HTextResult(HImage image, HTextModel textModel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(417);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, textModel);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(textModel);
		}

		public static void ClearTextResult(HTextResult[] textResultID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(textResultID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(414);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(textResultID);
		}

		public void ClearTextResult()
		{
			IntPtr proc = SZXCArimAPI.PreCall(414);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HObject GetTextObject(HTuple resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(415);
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

		public HObject GetTextObject(string resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(415);
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

		public HTuple GetTextResult(HTuple resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(416);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetTextResult(string resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(416);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void FindText(HImage image, HTextModel textModel)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(417);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, textModel);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(textModel);
		}
	}
}
