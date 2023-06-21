using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HDlClassifierResult : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlClassifierResult() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlClassifierResult(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlClassifierResult(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("dl_classifier_result");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifierResult obj)
		{
			obj = new HDlClassifierResult(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifierResult[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDlClassifierResult[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDlClassifierResult(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDlClassifierResult(HImage images, HDlClassifier DLClassifierHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2102);
			SZXCArimAPI.Store(proc, 1, images);
			SZXCArimAPI.Store(proc, 0, DLClassifierHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(images);
			GC.KeepAlive(DLClassifierHandle);
		}

		public static void ClearDlClassifierResult(HDlClassifierResult[] DLClassifierResultHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(DLClassifierResultHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2104);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(DLClassifierResultHandle);
		}

		public void ClearDlClassifierResult()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2104);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetDlClassifierResult(HTuple index, HTuple genResultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2115);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genResultName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(genResultName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetDlClassifierResult(string index, string genResultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2115);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.StoreS(proc, 2, genResultName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
