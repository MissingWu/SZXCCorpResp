using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HDlClassifierTrainResult : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlClassifierTrainResult() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlClassifierTrainResult(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlClassifierTrainResult(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("dl_classifier_train_result");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifierTrainResult obj)
		{
			obj = new HDlClassifierTrainResult(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlClassifierTrainResult[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDlClassifierTrainResult[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDlClassifierTrainResult(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDlClassifierTrainResult(HImage batchImages, HDlClassifier DLClassifierHandle, HTuple batchLabels)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2131);
			SZXCArimAPI.Store(proc, 1, batchImages);
			SZXCArimAPI.Store(proc, 0, DLClassifierHandle);
			SZXCArimAPI.Store(proc, 1, batchLabels);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(batchLabels);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(batchImages);
			GC.KeepAlive(DLClassifierHandle);
		}

		public static void ClearDlClassifierTrainResult(HDlClassifierTrainResult[] DLClassifierTrainResultHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(DLClassifierTrainResultHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2105);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(DLClassifierTrainResultHandle);
		}

		public void ClearDlClassifierTrainResult()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2105);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetDlClassifierTrainResult(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2116);
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

		public HTuple GetDlClassifierTrainResult(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2116);
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

		public void TrainDlClassifierBatch(HImage batchImages, HDlClassifier DLClassifierHandle, HTuple batchLabels)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2131);
			SZXCArimAPI.Store(proc, 1, batchImages);
			SZXCArimAPI.Store(proc, 0, DLClassifierHandle);
			SZXCArimAPI.Store(proc, 1, batchLabels);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(batchLabels);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(batchImages);
			GC.KeepAlive(DLClassifierHandle);
		}
	}
}
