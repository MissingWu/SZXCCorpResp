using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HFramegrabber : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFramegrabber() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFramegrabber(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFramegrabber(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("framegrabber");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFramegrabber obj)
		{
			obj = new HFramegrabber(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFramegrabber[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HFramegrabber[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HFramegrabber(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HFramegrabber(string name, int horizontalResolution, int verticalResolution, int imageWidth, int imageHeight, int startRow, int startColumn, string field, HTuple bitsPerChannel, HTuple colorSpace, HTuple generic, string externalTrigger, HTuple cameraType, HTuple device, HTuple port, HTuple lineIn)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2037);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.StoreI(proc, 1, horizontalResolution);
			SZXCArimAPI.StoreI(proc, 2, verticalResolution);
			SZXCArimAPI.StoreI(proc, 3, imageWidth);
			SZXCArimAPI.StoreI(proc, 4, imageHeight);
			SZXCArimAPI.StoreI(proc, 5, startRow);
			SZXCArimAPI.StoreI(proc, 6, startColumn);
			SZXCArimAPI.StoreS(proc, 7, field);
			SZXCArimAPI.Store(proc, 8, bitsPerChannel);
			SZXCArimAPI.Store(proc, 9, colorSpace);
			SZXCArimAPI.Store(proc, 10, generic);
			SZXCArimAPI.StoreS(proc, 11, externalTrigger);
			SZXCArimAPI.Store(proc, 12, cameraType);
			SZXCArimAPI.Store(proc, 13, device);
			SZXCArimAPI.Store(proc, 14, port);
			SZXCArimAPI.Store(proc, 15, lineIn);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(bitsPerChannel);
			SZXCArimAPI.UnpinTuple(colorSpace);
			SZXCArimAPI.UnpinTuple(generic);
			SZXCArimAPI.UnpinTuple(cameraType);
			SZXCArimAPI.UnpinTuple(device);
			SZXCArimAPI.UnpinTuple(port);
			SZXCArimAPI.UnpinTuple(lineIn);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HFramegrabber(string name, int horizontalResolution, int verticalResolution, int imageWidth, int imageHeight, int startRow, int startColumn, string field, int bitsPerChannel, string colorSpace, double generic, string externalTrigger, string cameraType, string device, int port, int lineIn)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2037);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.StoreI(proc, 1, horizontalResolution);
			SZXCArimAPI.StoreI(proc, 2, verticalResolution);
			SZXCArimAPI.StoreI(proc, 3, imageWidth);
			SZXCArimAPI.StoreI(proc, 4, imageHeight);
			SZXCArimAPI.StoreI(proc, 5, startRow);
			SZXCArimAPI.StoreI(proc, 6, startColumn);
			SZXCArimAPI.StoreS(proc, 7, field);
			SZXCArimAPI.StoreI(proc, 8, bitsPerChannel);
			SZXCArimAPI.StoreS(proc, 9, colorSpace);
			SZXCArimAPI.StoreD(proc, 10, generic);
			SZXCArimAPI.StoreS(proc, 11, externalTrigger);
			SZXCArimAPI.StoreS(proc, 12, cameraType);
			SZXCArimAPI.StoreS(proc, 13, device);
			SZXCArimAPI.StoreI(proc, 14, port);
			SZXCArimAPI.StoreI(proc, 15, lineIn);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetFramegrabberParam(HTuple param)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2025);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, param);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(param);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetFramegrabberParam(string param)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2025);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, param);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetFramegrabberParam(HTuple param, HTuple value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2026);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, param);
			SZXCArimAPI.Store(proc, 2, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(param);
			SZXCArimAPI.UnpinTuple(value);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetFramegrabberParam(string param, string value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2026);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, param);
			SZXCArimAPI.StoreS(proc, 2, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public IntPtr GetFramegrabberCallback(string callbackType, out IntPtr userContext)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2027);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, callbackType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			IntPtr result;
			num = SZXCArimAPI.LoadIP(proc, 0, num, out result);
			num = SZXCArimAPI.LoadIP(proc, 1, num, out userContext);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetFramegrabberCallback(string callbackType, IntPtr callbackFunction, IntPtr userContext)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2028);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, callbackType);
			SZXCArimAPI.StoreIP(proc, 2, callbackFunction);
			SZXCArimAPI.StoreIP(proc, 3, userContext);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage GrabDataAsync(out HRegion region, out HXLDCont contours, double maxDelay, out HTuple data)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2029);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out region);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrabDataAsync(out HRegion region, out HXLDCont contours, double maxDelay, out string data)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2029);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out region);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = SZXCArimAPI.LoadS(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrabData(out HRegion region, out HXLDCont contours, out HTuple data)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2030);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out region);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrabData(out HRegion region, out HXLDCont contours, out string data)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2030);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out region);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = SZXCArimAPI.LoadS(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrabImageAsync(double maxDelay)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2031);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GrabImageStart(double maxDelay)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2032);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage GrabImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2033);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CloseFramegrabber()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2036);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void OpenFramegrabber(string name, int horizontalResolution, int verticalResolution, int imageWidth, int imageHeight, int startRow, int startColumn, string field, HTuple bitsPerChannel, HTuple colorSpace, HTuple generic, string externalTrigger, HTuple cameraType, HTuple device, HTuple port, HTuple lineIn)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2037);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.StoreI(proc, 1, horizontalResolution);
			SZXCArimAPI.StoreI(proc, 2, verticalResolution);
			SZXCArimAPI.StoreI(proc, 3, imageWidth);
			SZXCArimAPI.StoreI(proc, 4, imageHeight);
			SZXCArimAPI.StoreI(proc, 5, startRow);
			SZXCArimAPI.StoreI(proc, 6, startColumn);
			SZXCArimAPI.StoreS(proc, 7, field);
			SZXCArimAPI.Store(proc, 8, bitsPerChannel);
			SZXCArimAPI.Store(proc, 9, colorSpace);
			SZXCArimAPI.Store(proc, 10, generic);
			SZXCArimAPI.StoreS(proc, 11, externalTrigger);
			SZXCArimAPI.Store(proc, 12, cameraType);
			SZXCArimAPI.Store(proc, 13, device);
			SZXCArimAPI.Store(proc, 14, port);
			SZXCArimAPI.Store(proc, 15, lineIn);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(bitsPerChannel);
			SZXCArimAPI.UnpinTuple(colorSpace);
			SZXCArimAPI.UnpinTuple(generic);
			SZXCArimAPI.UnpinTuple(cameraType);
			SZXCArimAPI.UnpinTuple(device);
			SZXCArimAPI.UnpinTuple(port);
			SZXCArimAPI.UnpinTuple(lineIn);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenFramegrabber(string name, int horizontalResolution, int verticalResolution, int imageWidth, int imageHeight, int startRow, int startColumn, string field, int bitsPerChannel, string colorSpace, double generic, string externalTrigger, string cameraType, string device, int port, int lineIn)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2037);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.StoreI(proc, 1, horizontalResolution);
			SZXCArimAPI.StoreI(proc, 2, verticalResolution);
			SZXCArimAPI.StoreI(proc, 3, imageWidth);
			SZXCArimAPI.StoreI(proc, 4, imageHeight);
			SZXCArimAPI.StoreI(proc, 5, startRow);
			SZXCArimAPI.StoreI(proc, 6, startColumn);
			SZXCArimAPI.StoreS(proc, 7, field);
			SZXCArimAPI.StoreI(proc, 8, bitsPerChannel);
			SZXCArimAPI.StoreS(proc, 9, colorSpace);
			SZXCArimAPI.StoreD(proc, 10, generic);
			SZXCArimAPI.StoreS(proc, 11, externalTrigger);
			SZXCArimAPI.StoreS(proc, 12, cameraType);
			SZXCArimAPI.StoreS(proc, 13, device);
			SZXCArimAPI.StoreI(proc, 14, port);
			SZXCArimAPI.StoreI(proc, 15, lineIn);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetFramegrabberLut(out HTuple imageRed, out HTuple imageGreen, out HTuple imageBlue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2038);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out imageRed);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out imageGreen);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out imageBlue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SetFramegrabberLut(HTuple imageRed, HTuple imageGreen, HTuple imageBlue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2039);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imageRed);
			SZXCArimAPI.Store(proc, 2, imageGreen);
			SZXCArimAPI.Store(proc, 3, imageBlue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(imageRed);
			SZXCArimAPI.UnpinTuple(imageGreen);
			SZXCArimAPI.UnpinTuple(imageBlue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}
	}
}
