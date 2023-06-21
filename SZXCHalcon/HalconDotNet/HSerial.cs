using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HSerial : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSerial() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSerial(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSerial(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("serial");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerial obj)
		{
			obj = new HSerial(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSerial[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HSerial[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HSerial(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HSerial(string portName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(314);
			SZXCArimAPI.StoreS(proc, 0, portName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearSerial(string channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(307);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, channel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteSerial(HTuple data)
		{
			IntPtr proc = SZXCArimAPI.PreCall(308);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, data);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(data);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteSerial(int data)
		{
			IntPtr proc = SZXCArimAPI.PreCall(308);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, data);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ReadSerial(int numCharacters)
		{
			IntPtr proc = SZXCArimAPI.PreCall(309);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, numCharacters);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetSerialParam(out int dataBits, out string flowControl, out string parity, out int stopBits, out int totalTimeOut, out int interCharTimeOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(310);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out dataBits);
			num = SZXCArimAPI.LoadS(proc, 2, num, out flowControl);
			num = SZXCArimAPI.LoadS(proc, 3, num, out parity);
			num = SZXCArimAPI.LoadI(proc, 4, num, out stopBits);
			num = SZXCArimAPI.LoadI(proc, 5, num, out totalTimeOut);
			num = SZXCArimAPI.LoadI(proc, 6, num, out interCharTimeOut);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetSerialParam(HTuple baudRate, HTuple dataBits, string flowControl, string parity, HTuple stopBits, HTuple totalTimeOut, HTuple interCharTimeOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(311);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, baudRate);
			SZXCArimAPI.Store(proc, 2, dataBits);
			SZXCArimAPI.StoreS(proc, 3, flowControl);
			SZXCArimAPI.StoreS(proc, 4, parity);
			SZXCArimAPI.Store(proc, 5, stopBits);
			SZXCArimAPI.Store(proc, 6, totalTimeOut);
			SZXCArimAPI.Store(proc, 7, interCharTimeOut);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(baudRate);
			SZXCArimAPI.UnpinTuple(dataBits);
			SZXCArimAPI.UnpinTuple(stopBits);
			SZXCArimAPI.UnpinTuple(totalTimeOut);
			SZXCArimAPI.UnpinTuple(interCharTimeOut);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetSerialParam(int baudRate, int dataBits, string flowControl, string parity, int stopBits, int totalTimeOut, int interCharTimeOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(311);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, baudRate);
			SZXCArimAPI.StoreI(proc, 2, dataBits);
			SZXCArimAPI.StoreS(proc, 3, flowControl);
			SZXCArimAPI.StoreS(proc, 4, parity);
			SZXCArimAPI.StoreI(proc, 5, stopBits);
			SZXCArimAPI.StoreI(proc, 6, totalTimeOut);
			SZXCArimAPI.StoreI(proc, 7, interCharTimeOut);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CloseSerial()
		{
			IntPtr proc = SZXCArimAPI.PreCall(313);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void OpenSerial(string portName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(314);
			SZXCArimAPI.StoreS(proc, 0, portName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
