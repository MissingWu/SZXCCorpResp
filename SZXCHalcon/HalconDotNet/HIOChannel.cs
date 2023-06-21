using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HIOChannel : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HIOChannel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HIOChannel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HIOChannel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("io_channel");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIOChannel obj)
		{
			obj = new HIOChannel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIOChannel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HIOChannel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HIOChannel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HIOChannel(HIODevice IODeviceHandle, string IOChannelName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2016);
			SZXCArimAPI.Store(proc, 0, IODeviceHandle);
			SZXCArimAPI.StoreS(proc, 1, IOChannelName);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(IODeviceHandle);
		}

		public static HTuple ControlIoChannel(HIOChannel[] IOChannelHandle, string paramAction, HTuple paramArgument)
		{
			HTuple hTuple = HHandleBase.ConcatArray(IOChannelHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2010);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, paramAction);
			SZXCArimAPI.Store(expr_13, 2, paramArgument);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(paramArgument);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(IOChannelHandle);
			return result;
		}

		public HTuple ControlIoChannel(string paramAction, HTuple paramArgument)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2010);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, paramAction);
			SZXCArimAPI.Store(proc, 2, paramArgument);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(paramArgument);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple WriteIoChannel(HIOChannel[] IOChannelHandle, HTuple value)
		{
			HTuple hTuple = HHandleBase.ConcatArray(IOChannelHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2011);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, value);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(value);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(IOChannelHandle);
			return result;
		}

		public HTuple WriteIoChannel(HTuple value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2011);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, value);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(value);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple ReadIoChannel(HIOChannel[] IOChannelHandle, out HTuple status)
		{
			HTuple hTuple = HHandleBase.ConcatArray(IOChannelHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2012);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, num, out result);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.INTEGER, num, out status);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(IOChannelHandle);
			return result;
		}

		public HTuple ReadIoChannel(out HTuple status)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2012);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out status);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void SetIoChannelParam(HIOChannel[] IOChannelHandle, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(IOChannelHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2013);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, genParamName);
			SZXCArimAPI.Store(expr_13, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(IOChannelHandle);
		}

		public void SetIoChannelParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2013);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HTuple GetIoChannelParam(HIOChannel[] IOChannelHandle, HTuple genParamName)
		{
			HTuple hTuple = HHandleBase.ConcatArray(IOChannelHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2014);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, genParamName);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(IOChannelHandle);
			return result;
		}

		public HTuple GetIoChannelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2014);
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

		public static void CloseIoChannel(HIOChannel[] IOChannelHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(IOChannelHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2015);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(IOChannelHandle);
		}

		public void CloseIoChannel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2015);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HIOChannel[] OpenIoChannel(HIODevice IODeviceHandle, HTuple IOChannelName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2016);
			SZXCArimAPI.Store(expr_0A, 0, IODeviceHandle);
			SZXCArimAPI.Store(expr_0A, 1, IOChannelName);
			SZXCArimAPI.Store(expr_0A, 2, genParamName);
			SZXCArimAPI.Store(expr_0A, 3, genParamValue);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(IOChannelName);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HIOChannel[] result;
			num = HIOChannel.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(IODeviceHandle);
			return result;
		}

		public void OpenIoChannel(HIODevice IODeviceHandle, string IOChannelName, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2016);
			SZXCArimAPI.Store(proc, 0, IODeviceHandle);
			SZXCArimAPI.StoreS(proc, 1, IOChannelName);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(IODeviceHandle);
		}
	}
}
