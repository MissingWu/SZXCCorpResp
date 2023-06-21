using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HIODevice : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HIODevice() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HIODevice(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HIODevice(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("io_device");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIODevice obj)
		{
			obj = new HIODevice(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HIODevice[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HIODevice[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HIODevice(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HIODevice(string IOInterfaceName, HTuple IODeviceName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2022);
			SZXCArimAPI.StoreS(proc, 0, IOInterfaceName);
			SZXCArimAPI.Store(proc, 1, IODeviceName);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(IODeviceName);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HIOChannel[] OpenIoChannel(HTuple IOChannelName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2016);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, IOChannelName);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(IOChannelName);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HIOChannel[] result;
			num = HIOChannel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HIOChannel OpenIoChannel(string IOChannelName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2016);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, IOChannelName);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HIOChannel result;
			num = HIOChannel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryIoDevice(HTuple IOChannelName, HTuple query)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2017);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, IOChannelName);
			SZXCArimAPI.Store(proc, 2, query);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(IOChannelName);
			SZXCArimAPI.UnpinTuple(query);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryIoDevice(string IOChannelName, HTuple query)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2017);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, IOChannelName);
			SZXCArimAPI.Store(proc, 2, query);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(query);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ControlIoDevice(string action, HTuple argument)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2018);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, action);
			SZXCArimAPI.Store(proc, 2, argument);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(argument);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ControlIoDevice(string action, string argument)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2018);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, action);
			SZXCArimAPI.StoreS(proc, 2, argument);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetIoDeviceParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2019);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetIoDeviceParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2019);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetIoDeviceParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2020);
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

		public HTuple GetIoDeviceParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2020);
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

		public void CloseIoDevice()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2021);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void OpenIoDevice(string IOInterfaceName, HTuple IODeviceName, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2022);
			SZXCArimAPI.StoreS(proc, 0, IOInterfaceName);
			SZXCArimAPI.Store(proc, 1, IODeviceName);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(IODeviceName);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HTuple ControlIoInterface(string IOInterfaceName, string action, HTuple argument)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2023);
			SZXCArimAPI.StoreS(expr_0A, 0, IOInterfaceName);
			SZXCArimAPI.StoreS(expr_0A, 1, action);
			SZXCArimAPI.Store(expr_0A, 2, argument);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(argument);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple ControlIoInterface(string IOInterfaceName, string action, string argument)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2023);
			SZXCArimAPI.StoreS(expr_0A, 0, IOInterfaceName);
			SZXCArimAPI.StoreS(expr_0A, 1, action);
			SZXCArimAPI.StoreS(expr_0A, 2, argument);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QueryIoInterface(string IOInterfaceName, HTuple query)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2024);
			SZXCArimAPI.StoreS(expr_0A, 0, IOInterfaceName);
			SZXCArimAPI.Store(expr_0A, 1, query);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(query);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QueryIoInterface(string IOInterfaceName, string query)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2024);
			SZXCArimAPI.StoreS(expr_0A, 0, IOInterfaceName);
			SZXCArimAPI.StoreS(expr_0A, 1, query);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}
	}
}
