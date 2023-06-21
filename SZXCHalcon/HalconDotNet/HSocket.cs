using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HSocket : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSocket() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSocket(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSocket(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("socket");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSocket obj)
		{
			obj = new HSocket(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSocket[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HSocket[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HSocket(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HSocket(string hostName, int port, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(342);
			SZXCArimAPI.StoreS(proc, 0, hostName);
			SZXCArimAPI.StoreI(proc, 1, port);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSocket(string hostName, int port, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(342);
			SZXCArimAPI.StoreS(proc, 0, hostName);
			SZXCArimAPI.StoreI(proc, 1, port);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSocket(int port, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(343);
			SZXCArimAPI.StoreI(proc, 0, port);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSocket(int port, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(343);
			SZXCArimAPI.StoreI(proc, 0, port);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage ReceiveImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(325);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SendImage(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(326);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public HRegion ReceiveRegion()
		{
			IntPtr proc = SZXCArimAPI.PreCall(327);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SendRegion(HRegion region)
		{
			IntPtr proc = SZXCArimAPI.PreCall(328);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, region);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
		}

		public HXLD ReceiveXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(329);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SendXld(HXLD XLD)
		{
			IntPtr proc = SZXCArimAPI.PreCall(330);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, XLD);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(XLD);
		}

		public HTuple ReceiveTuple()
		{
			IntPtr proc = SZXCArimAPI.PreCall(331);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SendTuple(HTuple tuple)
		{
			IntPtr proc = SZXCArimAPI.PreCall(332);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, tuple);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(tuple);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SendTuple(string tuple)
		{
			IntPtr proc = SZXCArimAPI.PreCall(332);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, tuple);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ReceiveData(HTuple format, out HTuple from)
		{
			IntPtr proc = SZXCArimAPI.PreCall(333);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, format);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(format);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out from);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ReceiveData(string format, out string from)
		{
			IntPtr proc = SZXCArimAPI.PreCall(333);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, format);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadS(proc, 1, num, out from);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SendData(string format, HTuple data, HTuple to)
		{
			IntPtr proc = SZXCArimAPI.PreCall(334);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, format);
			SZXCArimAPI.Store(proc, 2, data);
			SZXCArimAPI.Store(proc, 3, to);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(data);
			SZXCArimAPI.UnpinTuple(to);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SendData(string format, string data, string to)
		{
			IntPtr proc = SZXCArimAPI.PreCall(334);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, format);
			SZXCArimAPI.StoreS(proc, 2, data);
			SZXCArimAPI.StoreS(proc, 3, to);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetSocketParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(335);
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

		public HTuple GetSocketParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(335);
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

		public void SetSocketParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(336);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetSocketParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(336);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetNextSocketDataType()
		{
			IntPtr proc = SZXCArimAPI.PreCall(337);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetSocketDescriptor()
		{
			IntPtr proc = SZXCArimAPI.PreCall(338);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void CloseAllSockets()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(339);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public void CloseSocket()
		{
			IntPtr proc = SZXCArimAPI.PreCall(340);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HSocket SocketAcceptConnect(string wait)
		{
			IntPtr proc = SZXCArimAPI.PreCall(341);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, wait);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSocket result;
			num = HSocket.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void OpenSocketConnect(string hostName, int port, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(342);
			SZXCArimAPI.StoreS(proc, 0, hostName);
			SZXCArimAPI.StoreI(proc, 1, port);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenSocketConnect(string hostName, int port, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(342);
			SZXCArimAPI.StoreS(proc, 0, hostName);
			SZXCArimAPI.StoreI(proc, 1, port);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenSocketAccept(int port, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(343);
			SZXCArimAPI.StoreI(proc, 0, port);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenSocketAccept(int port, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(343);
			SZXCArimAPI.StoreI(proc, 0, port);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSerializedItem ReceiveSerializedItem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(403);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SendSerializedItem(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(404);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, serializedItemHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}
	}
}
