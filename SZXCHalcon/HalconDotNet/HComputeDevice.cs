using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HComputeDevice : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComputeDevice() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComputeDevice(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComputeDevice(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("compute_device");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComputeDevice obj)
		{
			obj = new HComputeDevice(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComputeDevice[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HComputeDevice[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HComputeDevice(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HComputeDevice(int deviceIdentifier)
		{
			IntPtr proc = SZXCArimAPI.PreCall(304);
			SZXCArimAPI.StoreI(proc, 0, deviceIdentifier);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetComputeDeviceParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(296);
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

		public void SetComputeDeviceParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(297);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetComputeDeviceParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(297);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ReleaseAllComputeDevices()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(298);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public void ReleaseComputeDevice()
		{
			IntPtr proc = SZXCArimAPI.PreCall(299);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void DeactivateAllComputeDevices()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(300);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public void DeactivateComputeDevice()
		{
			IntPtr proc = SZXCArimAPI.PreCall(301);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ActivateComputeDevice()
		{
			IntPtr proc = SZXCArimAPI.PreCall(302);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void InitComputeDevice(HTuple operators)
		{
			IntPtr proc = SZXCArimAPI.PreCall(303);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, operators);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(operators);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void OpenComputeDevice(int deviceIdentifier)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(304);
			SZXCArimAPI.StoreI(proc, 0, deviceIdentifier);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HTuple GetComputeDeviceInfo(int deviceIdentifier, string infoName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(305);
			SZXCArimAPI.StoreI(expr_0A, 0, deviceIdentifier);
			SZXCArimAPI.StoreS(expr_0A, 1, infoName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple QueryAvailableComputeDevices()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(306);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}
	}
}
