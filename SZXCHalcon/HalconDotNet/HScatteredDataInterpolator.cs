using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HScatteredDataInterpolator : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HScatteredDataInterpolator() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HScatteredDataInterpolator(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HScatteredDataInterpolator(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("scattered_data_interpolator");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HScatteredDataInterpolator obj)
		{
			obj = new HScatteredDataInterpolator(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HScatteredDataInterpolator[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HScatteredDataInterpolator[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HScatteredDataInterpolator(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HScatteredDataInterpolator(string method, HTuple rows, HTuple columns, HTuple values, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(292);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.Store(proc, 1, rows);
			SZXCArimAPI.Store(proc, 2, columns);
			SZXCArimAPI.Store(proc, 3, values);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(columns);
			SZXCArimAPI.UnpinTuple(values);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static void ClearScatteredDataInterpolator(HScatteredDataInterpolator[] scatteredDataInterpolatorHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(scatteredDataInterpolatorHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(290);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(scatteredDataInterpolatorHandle);
		}

		public void ClearScatteredDataInterpolator()
		{
			IntPtr proc = SZXCArimAPI.PreCall(290);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple InterpolateScatteredData(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(291);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double InterpolateScatteredData(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(291);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateScatteredDataInterpolator(string method, HTuple rows, HTuple columns, HTuple values, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(292);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.Store(proc, 1, rows);
			SZXCArimAPI.Store(proc, 2, columns);
			SZXCArimAPI.Store(proc, 3, values);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(columns);
			SZXCArimAPI.UnpinTuple(values);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
