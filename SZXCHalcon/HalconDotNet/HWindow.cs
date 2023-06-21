using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SZXCArimEngine
{
	public class HWindow : HHandle
	{
		internal delegate int ContentUpdateCallback(IntPtr context);

		private HWindow.ContentUpdateCallback _callback;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HWindow() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HWindow(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HWindow(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("window");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HWindow obj)
		{
			obj = new HWindow(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HWindow[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HWindow[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HWindow(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HWindow(int row, int column, int width, int height, HTuple fatherWindow, string mode, string machine)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1178);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.Store(proc, 4, fatherWindow);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreS(proc, 6, machine);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fatherWindow);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HWindow(int row, int column, int width, int height, IntPtr fatherWindow, string mode, string machine)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1178);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreIP(proc, 4, fatherWindow);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreS(proc, 6, machine);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		[DllImport("X11", EntryPoint = "XInitThreads")]
		private static extern int _XInitThreads();

		public static int XInitThreads()
		{
			int result;
			try
			{
				result = HWindow._XInitThreads();
			}
			catch (DllNotFoundException)
			{
				result = 0;
			}
			return result;
		}

		internal void OnContentUpdate(HWindow.ContentUpdateCallback f)
		{
			this._callback = f;
			this.SetContentUpdateCallback(Marshal.GetFunctionPointerForDelegate(this._callback), new IntPtr(0));
		}

		public void DispXld(HXLD XLDObject)
		{
			IntPtr proc = SZXCArimAPI.PreCall(74);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, XLDObject);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(XLDObject);
		}

		public HImage GetWindowBackgroundImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1161);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DetachBackgroundFromWindow()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1163);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AttachBackgroundToWindow(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1164);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void DetachDrawingObjectFromWindow(HDrawingObject drawHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1165);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, drawHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(drawHandle);
		}

		public void AttachDrawingObjectToWindow(HDrawingObject drawHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1166);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, drawHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(drawHandle);
		}

		public void UpdateWindowPose(HTuple lastRow, HTuple lastCol, HTuple currentRow, HTuple currentCol, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1167);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, lastRow);
			SZXCArimAPI.Store(proc, 2, lastCol);
			SZXCArimAPI.Store(proc, 3, currentRow);
			SZXCArimAPI.Store(proc, 4, currentCol);
			SZXCArimAPI.StoreS(proc, 5, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(lastRow);
			SZXCArimAPI.UnpinTuple(lastCol);
			SZXCArimAPI.UnpinTuple(currentRow);
			SZXCArimAPI.UnpinTuple(currentCol);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void UpdateWindowPose(double lastRow, double lastCol, double currentRow, double currentCol, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1167);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, lastRow);
			SZXCArimAPI.StoreD(proc, 2, lastCol);
			SZXCArimAPI.StoreD(proc, 3, currentRow);
			SZXCArimAPI.StoreD(proc, 4, currentCol);
			SZXCArimAPI.StoreS(proc, 5, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void UnprojectCoordinates(HImage image, HTuple row, HTuple column, out int imageRow, out int imageColumn, out HTuple height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1168);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			num = SZXCArimAPI.LoadI(proc, 0, num, out imageRow);
			num = SZXCArimAPI.LoadI(proc, 1, num, out imageColumn);
			num = HTuple.LoadNew(proc, 2, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void UnprojectCoordinates(HImage image, double row, double column, out int imageRow, out int imageColumn, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1168);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out imageRow);
			num = SZXCArimAPI.LoadI(proc, 1, num, out imageColumn);
			num = SZXCArimAPI.LoadI(proc, 2, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public IntPtr GetOsWindowHandle(out IntPtr OSDisplayHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1169);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			IntPtr result;
			num = SZXCArimAPI.LoadIP(proc, 0, num, out result);
			num = SZXCArimAPI.LoadIP(proc, 1, num, out OSDisplayHandle);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetWindowDc(IntPtr WINHDC)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1170);
			base.Store(proc, 0);
			SZXCArimAPI.StoreIP(proc, 1, WINHDC);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void NewExternWindow(IntPtr WINHWnd, int row, int column, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1171);
			SZXCArimAPI.StoreIP(proc, 0, WINHWnd);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SlideImage(HWindow windowHandleSource2, HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1172);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, windowHandleSource2);
			SZXCArimAPI.Store(proc, 2, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandleSource2);
			GC.KeepAlive(windowHandle);
		}

		public void SetWindowExtents(int row, int column, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1174);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void OpenWindow(int row, int column, int width, int height, HTuple fatherWindow, string mode, string machine)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1178);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.Store(proc, 4, fatherWindow);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreS(proc, 6, machine);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fatherWindow);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenWindow(int row, int column, int width, int height, IntPtr fatherWindow, string mode, string machine)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1178);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreIP(proc, 4, fatherWindow);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreS(proc, 6, machine);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenTextwindow(int row, int column, int width, int height, int borderWidth, string borderColor, string backgroundColor, HTuple fatherWindow, string mode, string machine)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1179);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreI(proc, 4, borderWidth);
			SZXCArimAPI.StoreS(proc, 5, borderColor);
			SZXCArimAPI.StoreS(proc, 6, backgroundColor);
			SZXCArimAPI.Store(proc, 7, fatherWindow);
			SZXCArimAPI.StoreS(proc, 8, mode);
			SZXCArimAPI.StoreS(proc, 9, machine);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fatherWindow);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenTextwindow(int row, int column, int width, int height, int borderWidth, string borderColor, string backgroundColor, IntPtr fatherWindow, string mode, string machine)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1179);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreI(proc, 4, borderWidth);
			SZXCArimAPI.StoreS(proc, 5, borderColor);
			SZXCArimAPI.StoreS(proc, 6, backgroundColor);
			SZXCArimAPI.StoreIP(proc, 7, fatherWindow);
			SZXCArimAPI.StoreS(proc, 8, mode);
			SZXCArimAPI.StoreS(proc, 9, machine);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void MoveRectangle(HTuple row1, HTuple column1, HTuple row2, HTuple column2, HTuple destRow, HTuple destColumn)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1180);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row1);
			SZXCArimAPI.Store(proc, 2, column1);
			SZXCArimAPI.Store(proc, 3, row2);
			SZXCArimAPI.Store(proc, 4, column2);
			SZXCArimAPI.Store(proc, 5, destRow);
			SZXCArimAPI.Store(proc, 6, destColumn);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.UnpinTuple(destRow);
			SZXCArimAPI.UnpinTuple(destColumn);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void MoveRectangle(int row1, int column1, int row2, int column2, int destRow, int destColumn)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1180);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row1);
			SZXCArimAPI.StoreI(proc, 2, column1);
			SZXCArimAPI.StoreI(proc, 3, row2);
			SZXCArimAPI.StoreI(proc, 4, column2);
			SZXCArimAPI.StoreI(proc, 5, destRow);
			SZXCArimAPI.StoreI(proc, 6, destColumn);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetWindowType()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1181);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetWindowPointer3(out int imageRed, out int imageGreen, out int imageBlue, out int width, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1182);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out imageRed);
			num = SZXCArimAPI.LoadI(proc, 1, num, out imageGreen);
			num = SZXCArimAPI.LoadI(proc, 2, num, out imageBlue);
			num = SZXCArimAPI.LoadI(proc, 3, num, out width);
			num = SZXCArimAPI.LoadI(proc, 4, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetWindowExtents(out int row, out int column, out int width, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1183);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column);
			num = SZXCArimAPI.LoadI(proc, 2, num, out width);
			num = SZXCArimAPI.LoadI(proc, 3, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage DumpWindowImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1184);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DumpWindow(HTuple device, string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1185);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, device);
			SZXCArimAPI.StoreS(proc, 2, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(device);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DumpWindow(string device, string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1185);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, device);
			SZXCArimAPI.StoreS(proc, 2, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CopyRectangle(HWindow windowHandleDestination, HTuple row1, HTuple column1, HTuple row2, HTuple column2, HTuple destRow, HTuple destColumn)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1186);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, windowHandleDestination);
			SZXCArimAPI.Store(proc, 2, row1);
			SZXCArimAPI.Store(proc, 3, column1);
			SZXCArimAPI.Store(proc, 4, row2);
			SZXCArimAPI.Store(proc, 5, column2);
			SZXCArimAPI.Store(proc, 6, destRow);
			SZXCArimAPI.Store(proc, 7, destColumn);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.UnpinTuple(destRow);
			SZXCArimAPI.UnpinTuple(destColumn);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandleDestination);
		}

		public void CopyRectangle(HWindow windowHandleDestination, int row1, int column1, int row2, int column2, int destRow, int destColumn)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1186);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, windowHandleDestination);
			SZXCArimAPI.StoreI(proc, 2, row1);
			SZXCArimAPI.StoreI(proc, 3, column1);
			SZXCArimAPI.StoreI(proc, 4, row2);
			SZXCArimAPI.StoreI(proc, 5, column2);
			SZXCArimAPI.StoreI(proc, 6, destRow);
			SZXCArimAPI.StoreI(proc, 7, destColumn);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandleDestination);
		}

		public static void CloseWindow(HWindow[] windowHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(windowHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1187);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(windowHandle);
		}

		public void CloseWindow()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1187);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearWindow()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1188);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearRectangle(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1189);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row1);
			SZXCArimAPI.Store(proc, 2, column1);
			SZXCArimAPI.Store(proc, 3, row2);
			SZXCArimAPI.Store(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearRectangle(int row1, int column1, int row2, int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1189);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row1);
			SZXCArimAPI.StoreI(proc, 2, column1);
			SZXCArimAPI.StoreI(proc, 3, row2);
			SZXCArimAPI.StoreI(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteString(HTuple stringVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1190);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, stringVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(stringVal);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteString(string stringVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1190);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, stringVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetTshape(string textCursor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1191);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, textCursor);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetTposition(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1192);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string ReadString(string inString, int length)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1193);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, inString);
			SZXCArimAPI.StoreI(proc, 2, length);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string ReadChar(out string code)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1194);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadS(proc, 1, num, out code);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void NewLine()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1195);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetTshape()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1196);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetTposition(out int row, out int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1197);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetFontExtents(out HTuple maxDescent, out HTuple maxWidth, out HTuple maxHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1198);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out maxDescent);
			num = HTuple.LoadNew(proc, 2, num, out maxWidth);
			num = HTuple.LoadNew(proc, 3, num, out maxHeight);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetFontExtents(out int maxDescent, out int maxWidth, out int maxHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1198);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out maxDescent);
			num = SZXCArimAPI.LoadI(proc, 2, num, out maxWidth);
			num = SZXCArimAPI.LoadI(proc, 3, num, out maxHeight);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetStringExtents(HTuple values, out HTuple descent, out HTuple width, out HTuple height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1199);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, values);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(values);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out descent);
			num = HTuple.LoadNew(proc, 2, num, out width);
			num = HTuple.LoadNew(proc, 3, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetStringExtents(string values, out int descent, out int width, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1199);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, values);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out descent);
			num = SZXCArimAPI.LoadI(proc, 2, num, out width);
			num = SZXCArimAPI.LoadI(proc, 3, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryFont()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1200);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryTshape()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1201);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetFont(string font)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1202);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, font);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetFont()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1203);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetWindowParam(string param)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1221);
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

		public void SetWindowParam(string param, HTuple value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1222);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, param);
			SZXCArimAPI.Store(proc, 2, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(value);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetWindowParam(string param, string value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1222);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, param);
			SZXCArimAPI.StoreS(proc, 2, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetShape(string shape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1223);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, shape);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRgb(HTuple red, HTuple green, HTuple blue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1224);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, red);
			SZXCArimAPI.Store(proc, 2, green);
			SZXCArimAPI.Store(proc, 3, blue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(red);
			SZXCArimAPI.UnpinTuple(green);
			SZXCArimAPI.UnpinTuple(blue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRgb(int red, int green, int blue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1224);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, red);
			SZXCArimAPI.StoreI(proc, 2, green);
			SZXCArimAPI.StoreI(proc, 3, blue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetPixel(HTuple pixel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1225);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pixel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pixel);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetPixel(int pixel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1225);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, pixel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetPartStyle(int style)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1226);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, style);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetPart(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1227);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row1);
			SZXCArimAPI.Store(proc, 2, column1);
			SZXCArimAPI.Store(proc, 3, row2);
			SZXCArimAPI.Store(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetPart(int row1, int column1, int row2, int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1227);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row1);
			SZXCArimAPI.StoreI(proc, 2, column1);
			SZXCArimAPI.StoreI(proc, 3, row2);
			SZXCArimAPI.StoreI(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetPaint(HTuple mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1228);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mode);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetLineWidth(double width)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1229);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, width);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetLineStyle(HTuple style)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1230);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, style);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(style);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetLineApprox(int approximation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1231);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, approximation);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetInsert(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1232);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetHsi(HTuple hue, HTuple saturation, HTuple intensity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1233);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hue);
			SZXCArimAPI.Store(proc, 2, saturation);
			SZXCArimAPI.Store(proc, 3, intensity);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hue);
			SZXCArimAPI.UnpinTuple(saturation);
			SZXCArimAPI.UnpinTuple(intensity);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetHsi(int hue, int saturation, int intensity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1233);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, hue);
			SZXCArimAPI.StoreI(proc, 2, saturation);
			SZXCArimAPI.StoreI(proc, 3, intensity);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetGray(HTuple grayValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1234);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, grayValues);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayValues);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetGray(int grayValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1234);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, grayValues);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDraw(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1235);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetComprise(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1236);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetColored(int numberOfColors)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1237);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, numberOfColors);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetColor(HTuple color)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1238);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, color);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(color);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetColor(string color)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1238);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, color);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetShape()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1239);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetRgb(out HTuple red, out HTuple green, out HTuple blue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1240);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out red);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out green);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out blue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetPixel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1241);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetPartStyle()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1242);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetPart(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1243);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, num, out row1);
			num = HTuple.LoadNew(proc, 1, num, out column1);
			num = HTuple.LoadNew(proc, 2, num, out row2);
			num = HTuple.LoadNew(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetPart(out int row1, out int column1, out int row2, out int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1243);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadI(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadI(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetPaint()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1244);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetLineWidth()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1245);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetLineStyle()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1246);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetLineApprox()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1247);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string GetInsert()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1248);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetHsi(out HTuple saturation, out HTuple intensity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1249);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out saturation);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out intensity);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string GetDraw()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1250);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryPaint()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1253);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryInsert()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1255);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryGray()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1256);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryAllColors()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1258);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryColor()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1259);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetIcon()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1260);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetIcon(HRegion icon)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1261);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, icon);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(icon);
		}

		public void DispRegion(HRegion dispRegions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1262);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, dispRegions);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(dispRegions);
		}

		public void DispRectangle2(HTuple centerRow, HTuple centerCol, HTuple phi, HTuple length1, HTuple length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1263);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, centerRow);
			SZXCArimAPI.Store(proc, 2, centerCol);
			SZXCArimAPI.Store(proc, 3, phi);
			SZXCArimAPI.Store(proc, 4, length1);
			SZXCArimAPI.Store(proc, 5, length2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(centerRow);
			SZXCArimAPI.UnpinTuple(centerCol);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(length1);
			SZXCArimAPI.UnpinTuple(length2);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispRectangle2(double centerRow, double centerCol, double phi, double length1, double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1263);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, centerRow);
			SZXCArimAPI.StoreD(proc, 2, centerCol);
			SZXCArimAPI.StoreD(proc, 3, phi);
			SZXCArimAPI.StoreD(proc, 4, length1);
			SZXCArimAPI.StoreD(proc, 5, length2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispRectangle1(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1264);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row1);
			SZXCArimAPI.Store(proc, 2, column1);
			SZXCArimAPI.Store(proc, 3, row2);
			SZXCArimAPI.Store(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispRectangle1(double row1, double column1, double row2, double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1264);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row1);
			SZXCArimAPI.StoreD(proc, 2, column1);
			SZXCArimAPI.StoreD(proc, 3, row2);
			SZXCArimAPI.StoreD(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispPolygon(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1265);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispLine(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1266);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row1);
			SZXCArimAPI.Store(proc, 2, column1);
			SZXCArimAPI.Store(proc, 3, row2);
			SZXCArimAPI.Store(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispLine(double row1, double column1, double row2, double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1266);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row1);
			SZXCArimAPI.StoreD(proc, 2, column1);
			SZXCArimAPI.StoreD(proc, 3, row2);
			SZXCArimAPI.StoreD(proc, 4, column2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispCross(HTuple row, HTuple column, double size, double angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1267);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, size);
			SZXCArimAPI.StoreD(proc, 4, angle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispCross(double row, double column, double size, double angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1267);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, size);
			SZXCArimAPI.StoreD(proc, 4, angle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispImage(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1268);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void DispChannel(HImage multichannelImage, HTuple channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1269);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, multichannelImage);
			SZXCArimAPI.Store(proc, 1, channel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(channel);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(multichannelImage);
		}

		public void DispChannel(HImage multichannelImage, int channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1269);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, multichannelImage);
			SZXCArimAPI.StoreI(proc, 1, channel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(multichannelImage);
		}

		public void DispColor(HImage colorImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1270);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, colorImage);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(colorImage);
		}

		public void DispEllipse(HTuple centerRow, HTuple centerCol, HTuple phi, HTuple radius1, HTuple radius2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1271);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, centerRow);
			SZXCArimAPI.Store(proc, 2, centerCol);
			SZXCArimAPI.Store(proc, 3, phi);
			SZXCArimAPI.Store(proc, 4, radius1);
			SZXCArimAPI.Store(proc, 5, radius2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(centerRow);
			SZXCArimAPI.UnpinTuple(centerCol);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(radius1);
			SZXCArimAPI.UnpinTuple(radius2);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispEllipse(int centerRow, int centerCol, double phi, double radius1, double radius2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1271);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, centerRow);
			SZXCArimAPI.StoreI(proc, 2, centerCol);
			SZXCArimAPI.StoreD(proc, 3, phi);
			SZXCArimAPI.StoreD(proc, 4, radius1);
			SZXCArimAPI.StoreD(proc, 5, radius2);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispDistribution(HTuple distribution, int row, int column, int scale)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1272);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, distribution);
			SZXCArimAPI.StoreI(proc, 2, row);
			SZXCArimAPI.StoreI(proc, 3, column);
			SZXCArimAPI.StoreI(proc, 4, scale);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(distribution);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispCircle(HTuple row, HTuple column, HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1273);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, radius);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispCircle(double row, double column, double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1273);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, radius);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispArrow(HTuple row1, HTuple column1, HTuple row2, HTuple column2, HTuple size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1274);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row1);
			SZXCArimAPI.Store(proc, 2, column1);
			SZXCArimAPI.Store(proc, 3, row2);
			SZXCArimAPI.Store(proc, 4, column2);
			SZXCArimAPI.Store(proc, 5, size);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.UnpinTuple(size);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispArrow(double row1, double column1, double row2, double column2, double size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1274);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row1);
			SZXCArimAPI.StoreD(proc, 2, column1);
			SZXCArimAPI.StoreD(proc, 3, row2);
			SZXCArimAPI.StoreD(proc, 4, column2);
			SZXCArimAPI.StoreD(proc, 5, size);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispArc(HTuple centerRow, HTuple centerCol, HTuple angle, HTuple beginRow, HTuple beginCol)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1275);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, centerRow);
			SZXCArimAPI.Store(proc, 2, centerCol);
			SZXCArimAPI.Store(proc, 3, angle);
			SZXCArimAPI.Store(proc, 4, beginRow);
			SZXCArimAPI.Store(proc, 5, beginCol);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(centerRow);
			SZXCArimAPI.UnpinTuple(centerCol);
			SZXCArimAPI.UnpinTuple(angle);
			SZXCArimAPI.UnpinTuple(beginRow);
			SZXCArimAPI.UnpinTuple(beginCol);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispArc(double centerRow, double centerCol, double angle, int beginRow, int beginCol)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1275);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, centerRow);
			SZXCArimAPI.StoreD(proc, 2, centerCol);
			SZXCArimAPI.StoreD(proc, 3, angle);
			SZXCArimAPI.StoreI(proc, 4, beginRow);
			SZXCArimAPI.StoreI(proc, 5, beginCol);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispObj(HObject objectVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1276);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectVal);
		}

		public void SetMshape(string cursor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1277);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, cursor);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetMshape()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1278);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryMshape()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1279);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetMpositionSubPix(out double row, out double column, out int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1280);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadI(proc, 2, num, out button);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetMposition(out int row, out int column, out int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1281);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column);
			num = SZXCArimAPI.LoadI(proc, 2, num, out button);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetMbuttonSubPix(out double row, out double column, out int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1282);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadI(proc, 2, num, out button);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetMbutton(out int row, out int column, out int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1283);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column);
			num = SZXCArimAPI.LoadI(proc, 2, num, out button);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteLut(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1284);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispLut(int row, int column, int scale)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1285);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, scale);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple QueryLut()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1286);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetLutStyle(out double saturation, out double intensity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1287);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out saturation);
			num = SZXCArimAPI.LoadD(proc, 2, num, out intensity);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetLutStyle(double hue, double saturation, double intensity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1288);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, hue);
			SZXCArimAPI.StoreD(proc, 2, saturation);
			SZXCArimAPI.StoreD(proc, 3, intensity);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetLut()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1289);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetLut(HTuple lookUpTable)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1290);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, lookUpTable);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(lookUpTable);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetLut(string lookUpTable)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1290);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, lookUpTable);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetFix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1291);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetFix(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1292);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetFixedLut()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1293);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetFixedLut(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1294);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HRegion DragRegion3(HRegion sourceRegion, HRegion maskRegion, int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1315);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sourceRegion);
			SZXCArimAPI.Store(proc, 2, maskRegion);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sourceRegion);
			GC.KeepAlive(maskRegion);
			return result;
		}

		public HRegion DragRegion2(HRegion sourceRegion, int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1316);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sourceRegion);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sourceRegion);
			return result;
		}

		public HRegion DragRegion1(HRegion sourceRegion)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1317);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sourceRegion);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sourceRegion);
			return result;
		}

		public HXLDCont DrawNurbsInterpMod(string rotate, string move, string scale, string keepRatio, string edit, int degree, HTuple rowsIn, HTuple colsIn, HTuple tangentsIn, out HTuple controlRows, out HTuple controlCols, out HTuple knots, out HTuple rows, out HTuple cols, out HTuple tangents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1318);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreS(proc, 5, edit);
			SZXCArimAPI.StoreI(proc, 6, degree);
			SZXCArimAPI.Store(proc, 7, rowsIn);
			SZXCArimAPI.Store(proc, 8, colsIn);
			SZXCArimAPI.Store(proc, 9, tangentsIn);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowsIn);
			SZXCArimAPI.UnpinTuple(colsIn);
			SZXCArimAPI.UnpinTuple(tangentsIn);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out controlRows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out controlCols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out knots);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out tangents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont DrawNurbsInterp(string rotate, string move, string scale, string keepRatio, int degree, out HTuple controlRows, out HTuple controlCols, out HTuple knots, out HTuple rows, out HTuple cols, out HTuple tangents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1319);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreI(proc, 5, degree);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out controlRows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out controlCols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out knots);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out tangents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont DrawNurbsMod(string rotate, string move, string scale, string keepRatio, string edit, int degree, HTuple rowsIn, HTuple colsIn, HTuple weightsIn, out HTuple rows, out HTuple cols, out HTuple weights)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1320);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreS(proc, 5, edit);
			SZXCArimAPI.StoreI(proc, 6, degree);
			SZXCArimAPI.Store(proc, 7, rowsIn);
			SZXCArimAPI.Store(proc, 8, colsIn);
			SZXCArimAPI.Store(proc, 9, weightsIn);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowsIn);
			SZXCArimAPI.UnpinTuple(colsIn);
			SZXCArimAPI.UnpinTuple(weightsIn);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out weights);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont DrawNurbs(string rotate, string move, string scale, string keepRatio, int degree, out HTuple rows, out HTuple cols, out HTuple weights)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1321);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreI(proc, 5, degree);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out weights);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont DrawXldMod(HXLDCont contIn, string rotate, string move, string scale, string keepRatio, string edit)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1322);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contIn);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreS(proc, 5, edit);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contIn);
			return result;
		}

		public HXLDCont DrawXld(string rotate, string move, string scale, string keepRatio)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1323);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DrawRectangle2Mod(double rowIn, double columnIn, double phiIn, double length1In, double length2In, out double row, out double column, out double phi, out double length1, out double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1324);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, rowIn);
			SZXCArimAPI.StoreD(proc, 2, columnIn);
			SZXCArimAPI.StoreD(proc, 3, phiIn);
			SZXCArimAPI.StoreD(proc, 4, length1In);
			SZXCArimAPI.StoreD(proc, 5, length2In);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out length2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawRectangle2(out double row, out double column, out double phi, out double length1, out double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1325);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out length2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawRectangle1Mod(double row1In, double column1In, double row2In, double column2In, out double row1, out double column1, out double row2, out double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1326);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row1In);
			SZXCArimAPI.StoreD(proc, 2, column1In);
			SZXCArimAPI.StoreD(proc, 3, row2In);
			SZXCArimAPI.StoreD(proc, 4, column2In);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadD(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawRectangle1(out double row1, out double column1, out double row2, out double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1327);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadD(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawPointMod(double rowIn, double columnIn, out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1328);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, rowIn);
			SZXCArimAPI.StoreD(proc, 2, columnIn);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawPoint(out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1329);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawLineMod(double row1In, double column1In, double row2In, double column2In, out double row1, out double column1, out double row2, out double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1330);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row1In);
			SZXCArimAPI.StoreD(proc, 2, column1In);
			SZXCArimAPI.StoreD(proc, 3, row2In);
			SZXCArimAPI.StoreD(proc, 4, column2In);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadD(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawLine(out double row1, out double column1, out double row2, out double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1331);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadD(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawEllipseMod(double rowIn, double columnIn, double phiIn, double radius1In, double radius2In, out double row, out double column, out double phi, out double radius1, out double radius2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1332);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, rowIn);
			SZXCArimAPI.StoreD(proc, 2, columnIn);
			SZXCArimAPI.StoreD(proc, 3, phiIn);
			SZXCArimAPI.StoreD(proc, 4, radius1In);
			SZXCArimAPI.StoreD(proc, 5, radius2In);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out radius1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out radius2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawEllipse(out double row, out double column, out double phi, out double radius1, out double radius2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1333);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out radius1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out radius2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawCircleMod(double rowIn, double columnIn, double radiusIn, out double row, out double column, out double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1334);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, rowIn);
			SZXCArimAPI.StoreD(proc, 2, columnIn);
			SZXCArimAPI.StoreD(proc, 3, radiusIn);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DrawCircle(out double row, out double column, out double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1335);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion DrawRegion()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1336);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion DrawPolygon()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1337);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DispCaltab(string calPlateDescr, HCamPar cameraParam, HPose calPlatePose, double scaleFac)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1945);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, calPlateDescr);
			SZXCArimAPI.Store(proc, 2, cameraParam);
			SZXCArimAPI.Store(proc, 3, calPlatePose);
			SZXCArimAPI.StoreD(proc, 4, scaleFac);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(calPlatePose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ConvertCoordinatesImageToWindow(HTuple rowImage, HTuple columnImage, out HTuple rowWindow, out HTuple columnWindow)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2049);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, rowImage);
			SZXCArimAPI.Store(proc, 2, columnImage);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowImage);
			SZXCArimAPI.UnpinTuple(columnImage);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowWindow);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnWindow);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ConvertCoordinatesImageToWindow(double rowImage, double columnImage, out double rowWindow, out double columnWindow)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2049);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, rowImage);
			SZXCArimAPI.StoreD(proc, 2, columnImage);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out rowWindow);
			num = SZXCArimAPI.LoadD(proc, 1, num, out columnWindow);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ConvertCoordinatesWindowToImage(HTuple rowWindow, HTuple columnWindow, out HTuple rowImage, out HTuple columnImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2050);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, rowWindow);
			SZXCArimAPI.Store(proc, 2, columnWindow);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowWindow);
			SZXCArimAPI.UnpinTuple(columnWindow);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowImage);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnImage);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ConvertCoordinatesWindowToImage(double rowWindow, double columnWindow, out double rowImage, out double columnImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2050);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, rowWindow);
			SZXCArimAPI.StoreD(proc, 2, columnWindow);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out rowImage);
			num = SZXCArimAPI.LoadD(proc, 1, num, out columnImage);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DispText(HTuple stringVal, string coordSystem, HTuple row, HTuple column, HTuple color, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2055);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, stringVal);
			SZXCArimAPI.StoreS(proc, 2, coordSystem);
			SZXCArimAPI.Store(proc, 3, row);
			SZXCArimAPI.Store(proc, 4, column);
			SZXCArimAPI.Store(proc, 5, color);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(stringVal);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(color);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DispText(string stringVal, string coordSystem, int row, int column, string color, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2055);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, stringVal);
			SZXCArimAPI.StoreS(proc, 2, coordSystem);
			SZXCArimAPI.StoreI(proc, 3, row);
			SZXCArimAPI.StoreI(proc, 4, column);
			SZXCArimAPI.StoreS(proc, 5, color);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void FlushBuffer()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2070);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GetRgba(out HTuple red, out HTuple green, out HTuple blue, out HTuple alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2073);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out red);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out green);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out blue);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out alpha);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public string SendMouseDoubleClickEvent(HTuple row, HTuple column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2088);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string SendMouseDoubleClickEvent(int row, int column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2088);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string SendMouseDownEvent(HTuple row, HTuple column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2089);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string SendMouseDownEvent(int row, int column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2089);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string SendMouseDragEvent(HTuple row, HTuple column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2090);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string SendMouseDragEvent(int row, int column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2090);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string SendMouseUpEvent(HTuple row, HTuple column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2091);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string SendMouseUpEvent(int row, int column, int button)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2091);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, button);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetContentUpdateCallback(IntPtr callbackFunction, HTuple callbackContext)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2095);
			base.Store(proc, 0);
			SZXCArimAPI.StoreIP(proc, 1, callbackFunction);
			SZXCArimAPI.Store(proc, 2, callbackContext);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(callbackContext);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetContentUpdateCallback(IntPtr callbackFunction, IntPtr callbackContext)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2095);
			base.Store(proc, 0);
			SZXCArimAPI.StoreIP(proc, 1, callbackFunction);
			SZXCArimAPI.StoreIP(proc, 2, callbackContext);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRgba(HTuple red, HTuple green, HTuple blue, HTuple alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2096);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, red);
			SZXCArimAPI.Store(proc, 2, green);
			SZXCArimAPI.Store(proc, 3, blue);
			SZXCArimAPI.Store(proc, 4, alpha);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(red);
			SZXCArimAPI.UnpinTuple(green);
			SZXCArimAPI.UnpinTuple(blue);
			SZXCArimAPI.UnpinTuple(alpha);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRgba(int red, int green, int blue, int alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2096);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, red);
			SZXCArimAPI.StoreI(proc, 2, green);
			SZXCArimAPI.StoreI(proc, 3, blue);
			SZXCArimAPI.StoreI(proc, 4, alpha);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string GetContourStyle()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2177);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetContourStyle(string style)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2179);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, style);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}
	}
}
