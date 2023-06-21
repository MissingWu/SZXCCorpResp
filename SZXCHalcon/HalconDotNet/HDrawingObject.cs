using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SZXCArimEngine
{
	public class HDrawingObject : HHandle
	{
		public delegate void HDrawingObjectCallback(IntPtr drawid, IntPtr windowHandle, string type);

		public delegate void HDrawingObjectCallbackClass(HDrawingObject drawid, HWindow window, string type);

		public enum HDrawingObjectType
		{
			RECTANGLE1,
			RECTANGLE2,
			CIRCLE,
			ELLIPSE,
			CIRCLE_SECTOR,
			ELLIPSE_SECTOR,
			LINE,
			XLD_CONTOUR,
			TEXT
		}

		private HDrawingObject.HDrawingObjectCallback onresize;

		private HDrawingObject.HDrawingObjectCallback onattach;

		private HDrawingObject.HDrawingObjectCallback ondetach;

		private HDrawingObject.HDrawingObjectCallback ondrag;

		private HDrawingObject.HDrawingObjectCallback onselect;

		public long ID
		{
			get
			{
				return base.Handle.ToInt64();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDrawingObject() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDrawingObject(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDrawingObject(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("drawing_object");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDrawingObject obj)
		{
			obj = new HDrawingObject(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDrawingObject[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDrawingObject[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDrawingObject(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDrawingObject(double row, double column, double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1311);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDrawingObject(double row, double column, double phi, double length1, double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1313);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, length1);
			SZXCArimAPI.StoreD(proc, 4, length2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDrawingObject(double row1, double column1, double row2, double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1314);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		protected IntPtr DelegateToCallbackPointer(HDrawingObject.HDrawingObjectCallback c)
		{
			return Marshal.GetFunctionPointerForDelegate(c);
		}

		protected IntPtr DelegateToCallbackPointer(HDrawingObject.HDrawingObjectCallbackClass c, string evt)
		{
			HDrawingObject.HDrawingObjectCallback hDrawingObjectCallback = delegate(IntPtr drawid, IntPtr window, string type)
			{
				HDrawingObject hDrawingObject = new HDrawingObject(drawid);
				HWindow hWindow = new HWindow(window);
				hDrawingObject.Detach();
				hWindow.Detach();
				c(hDrawingObject, hWindow, type);
			};
			GC.KeepAlive(hDrawingObjectCallback);
			GC.SuppressFinalize(hDrawingObjectCallback);
			if (!(evt == "on_resize"))
			{
				if (!(evt == "on_attach"))
				{
					if (!(evt == "on_detach"))
					{
						if (!(evt == "on_drag"))
						{
							if (evt == "on_select")
							{
								this.onselect = hDrawingObjectCallback;
							}
						}
						else
						{
							this.ondrag = hDrawingObjectCallback;
						}
					}
					else
					{
						this.ondetach = hDrawingObjectCallback;
					}
				}
				else
				{
					this.onattach = hDrawingObjectCallback;
				}
			}
			else
			{
				this.onresize = hDrawingObjectCallback;
			}
			return Marshal.GetFunctionPointerForDelegate(hDrawingObjectCallback);
		}

		public void OnResize(HDrawingObject.HDrawingObjectCallback f)
		{
			this.SetDrawingObjectCallback("on_resize", Marshal.GetFunctionPointerForDelegate(f));
		}

		public void OnAttach(HDrawingObject.HDrawingObjectCallback f)
		{
			this.SetDrawingObjectCallback("on_attach", Marshal.GetFunctionPointerForDelegate(f));
		}

		public void OnDetach(HDrawingObject.HDrawingObjectCallback f)
		{
			this.SetDrawingObjectCallback("on_detach", Marshal.GetFunctionPointerForDelegate(f));
		}

		public void OnDrag(HDrawingObject.HDrawingObjectCallback f)
		{
			this.SetDrawingObjectCallback("on_drag", Marshal.GetFunctionPointerForDelegate(f));
		}

		public void OnSelect(HDrawingObject.HDrawingObjectCallback f)
		{
			this.SetDrawingObjectCallback("on_select", Marshal.GetFunctionPointerForDelegate(f));
		}

		public void OnResize(HDrawingObject.HDrawingObjectCallbackClass f)
		{
			this.SetDrawingObjectCallback("on_resize", this.DelegateToCallbackPointer(f, "on_resize"));
		}

		public void OnDrag(HDrawingObject.HDrawingObjectCallbackClass f)
		{
			this.SetDrawingObjectCallback("on_drag", this.DelegateToCallbackPointer(f, "on_drag"));
		}

		public void OnSelect(HDrawingObject.HDrawingObjectCallbackClass f)
		{
			this.SetDrawingObjectCallback("on_select", this.DelegateToCallbackPointer(f, "on_select"));
		}

		public void OnAttach(HDrawingObject.HDrawingObjectCallbackClass f)
		{
			this.SetDrawingObjectCallback("on_attach", this.DelegateToCallbackPointer(f, "on_attach"));
		}

		public void OnDetach(HDrawingObject.HDrawingObjectCallbackClass f)
		{
			this.SetDrawingObjectCallback("on_detach", this.DelegateToCallbackPointer(f, "on_detach"));
		}

		public static HDrawingObject CreateDrawingObject(HDrawingObject.HDrawingObjectType type, params HTuple[] values)
		{
			HDrawingObject hDrawingObject = new HDrawingObject();
			switch (type)
			{
			case HDrawingObject.HDrawingObjectType.RECTANGLE1:
				hDrawingObject.CreateDrawingObjectRectangle1(values[0], values[1], values[2], values[3]);
				break;
			case HDrawingObject.HDrawingObjectType.RECTANGLE2:
				hDrawingObject.CreateDrawingObjectRectangle2(values[0], values[1], values[2], values[3], values[4]);
				break;
			case HDrawingObject.HDrawingObjectType.CIRCLE:
				hDrawingObject.CreateDrawingObjectCircle(values[0], values[1], values[2]);
				break;
			case HDrawingObject.HDrawingObjectType.ELLIPSE:
				hDrawingObject.CreateDrawingObjectEllipse(values[0], values[1], values[2], values[3], values[4]);
				break;
			case HDrawingObject.HDrawingObjectType.CIRCLE_SECTOR:
				hDrawingObject.CreateDrawingObjectCircleSector(values[0], values[1], values[2], values[3], values[4]);
				break;
			case HDrawingObject.HDrawingObjectType.ELLIPSE_SECTOR:
				hDrawingObject.CreateDrawingObjectEllipseSector(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
				break;
			case HDrawingObject.HDrawingObjectType.LINE:
				hDrawingObject.CreateDrawingObjectLine(values[0], values[1], values[2], values[3]);
				break;
			case HDrawingObject.HDrawingObjectType.XLD_CONTOUR:
				if (values.Length != 2)
				{
					throw new SZXCArimException("Invalid number of parameters");
				}
				if (values[0].Length != values[1].Length)
				{
					throw new SZXCArimException("The length of the input tuples must be identical");
				}
				hDrawingObject.CreateDrawingObjectXld(values[0].DArr, values[1].DArr);
				break;
			case HDrawingObject.HDrawingObjectType.TEXT:
				hDrawingObject.CreateDrawingObjectText(values[0], values[1], values[2]);
				break;
			}
			return hDrawingObject;
		}

		public void SetDrawingObjectCallback(HTuple drawObjectEvent, HTuple callbackFunction)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1162);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, drawObjectEvent);
			SZXCArimAPI.Store(proc, 2, callbackFunction);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(drawObjectEvent);
			SZXCArimAPI.UnpinTuple(callbackFunction);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDrawingObjectCallback(string drawObjectEvent, IntPtr callbackFunction)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1162);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, drawObjectEvent);
			SZXCArimAPI.StoreIP(proc, 2, callbackFunction);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void DetachBackgroundFromWindow(HWindow windowHandle)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1163);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(windowHandle);
		}

		public static void AttachBackgroundToWindow(HImage image, HWindow windowHandle)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1164);
			SZXCArimAPI.Store(expr_0A, 1, image);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(image);
			GC.KeepAlive(windowHandle);
		}

		public void CreateDrawingObjectText(int row, int column, string stringVal)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1301);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreS(proc, 2, stringVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HObject GetDrawingObjectIconic()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1302);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ClearDrawingObject()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1303);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDrawingObjectParams(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1304);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDrawingObjectParams(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1304);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetDrawingObjectParams(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1305);
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

		public HTuple GetDrawingObjectParams(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1305);
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

		public void SetDrawingObjectXld(HXLDCont contour)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1306);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contour);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
		}

		public void CreateDrawingObjectXld(HTuple row, HTuple column)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1307);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateDrawingObjectCircleSector(double row, double column, double radius, double startAngle, double endAngle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1308);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, startAngle);
			SZXCArimAPI.StoreD(proc, 4, endAngle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateDrawingObjectEllipseSector(double row, double column, double phi, double radius1, double radius2, double startAngle, double endAngle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1309);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, radius1);
			SZXCArimAPI.StoreD(proc, 4, radius2);
			SZXCArimAPI.StoreD(proc, 5, startAngle);
			SZXCArimAPI.StoreD(proc, 6, endAngle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateDrawingObjectLine(double row1, double column1, double row2, double column2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1310);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateDrawingObjectCircle(double row, double column, double radius)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1311);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateDrawingObjectEllipse(double row, double column, double phi, double radius1, double radius2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1312);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, radius1);
			SZXCArimAPI.StoreD(proc, 4, radius2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateDrawingObjectRectangle2(double row, double column, double phi, double length1, double length2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1313);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, length1);
			SZXCArimAPI.StoreD(proc, 4, length2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateDrawingObjectRectangle1(double row1, double column1, double row2, double column2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1314);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static string SendMouseDoubleClickEvent(HWindow windowHandle, HTuple row, HTuple column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2088);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.Store(expr_0A, 1, row);
			SZXCArimAPI.Store(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static string SendMouseDoubleClickEvent(HWindow windowHandle, int row, int column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2088);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.StoreI(expr_0A, 1, row);
			SZXCArimAPI.StoreI(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static string SendMouseDownEvent(HWindow windowHandle, HTuple row, HTuple column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2089);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.Store(expr_0A, 1, row);
			SZXCArimAPI.Store(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static string SendMouseDownEvent(HWindow windowHandle, int row, int column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2089);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.StoreI(expr_0A, 1, row);
			SZXCArimAPI.StoreI(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static string SendMouseDragEvent(HWindow windowHandle, HTuple row, HTuple column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2090);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.Store(expr_0A, 1, row);
			SZXCArimAPI.Store(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static string SendMouseDragEvent(HWindow windowHandle, int row, int column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2090);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.StoreI(expr_0A, 1, row);
			SZXCArimAPI.StoreI(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static string SendMouseUpEvent(HWindow windowHandle, HTuple row, HTuple column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2091);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.Store(expr_0A, 1, row);
			SZXCArimAPI.Store(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static string SendMouseUpEvent(HWindow windowHandle, int row, int column, int button)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2091);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.StoreI(expr_0A, 1, row);
			SZXCArimAPI.StoreI(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, button);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}
	}
}
