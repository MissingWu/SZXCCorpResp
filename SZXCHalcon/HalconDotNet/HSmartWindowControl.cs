using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SZXCArimEngine
{
	[ToolboxBitmap(typeof(HWindowControl))]
	public class HSmartWindowControl : UserControl
	{
		public delegate void HErrorHandler(SZXCArimException he);

		public enum DrawingObjectsModifier
		{
			None,
			Shift,
			Ctrl,
			Alt
		}

		public enum ZoomContent
		{
			Off,
			WheelForwardZoomsIn,
			WheelBackwardZoomsIn
		}

		private const string positionDescription = " The position is returned in the image coordinate system.";

		private HWindow _hwindow;

		private Point _last_position = new Point(0, 0);

		private HObject _netimg = new HObject();

		private Size _prevsize;

		private HTuple _dump_params;

		private bool _left_button_down;

		private Rectangle _part = new Rectangle(0, 0, 640, 480);

		private HSmartWindowControl.DrawingObjectsModifier _drawingObjectsModifier;

		private bool _automove = true;

		private bool _keepaspectratio = true;

		private HSmartWindowControl.ZoomContent _zooming = HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;

		private bool _resetpart = true;

		private IContainer components;

		private PictureBox WindowFrame;

		[Category("Mouse"), Description("Occurs when the mouse is moved over the SZXCArim window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandler HMouseMove;

		[Category("Mouse"), Description("Occurs when a button is pressed over the SZXCArim window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandler HMouseDown;

		[Category("Mouse"), Description("Occurs when a button is released over the SZXCArim window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandler HMouseUp;

		[Category("Mouse"), Description("Occurs when a button is double-clicked over a SZXCArim window. Note that delta is meaningless here. The position is returned in the image coordinate system.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandler HMouseDoubleClick;

		[Category("Mouse"), Description("Occurs when the wheel is used over a SZXCArim window while it has focus. Note that button is meaningless here. The position is returned in the image coordinate system.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandler HMouseWheel;

		[Category("Behavior"), Description("Occurs after the SZXCArim window has been initialized.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HInitWindowEventHandler HInitWindow;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HSmartWindowControl.HErrorHandler HErrorNotify;

		protected override Size DefaultSize
		{
			get
			{
				return new Size(320, 240);
			}
		}

		[Browsable(false)]
		public HWindow SZXCArimWindow
		{
			get
			{
				if (this._hwindow == null && base.Width > 0 && base.Height > 0)
				{
					this.CreateHWindow();
				}
				return this._hwindow;
			}
		}

		[Browsable(false)]
		public IntPtr SZXCArimID
		{
			get
			{
				if (this._hwindow != null)
				{
					return this._hwindow.Handle;
				}
				return IntPtr.Zero;
			}
		}

		private static bool RunningInDesignerMode
		{
			get
			{
				bool flag = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
				if (!flag)
				{
					using (Process currentProcess = Process.GetCurrentProcess())
					{
						string fileDescription = currentProcess.MainModule.FileVersionInfo.FileDescription;
						bool result;
						if (fileDescription != null && fileDescription.ToLowerInvariant().Contains("microsoft visual studio"))
						{
							result = true;
							return result;
						}
						result = currentProcess.ProcessName.ToLowerInvariant().Contains("devenv");
						return result;
					}
					return flag;
				}
				return flag;
			}
		}

		[Category("Layout"), Description("Size of the SZXCArim window in pixels.")]
		public Size WindowSize
		{
			get
			{
				if (HSmartWindowControl.RunningInDesignerMode || this._hwindow == null)
				{
					return base.Size;
				}
				int num;
				int num2;
				int width;
				int height;
				this._hwindow.GetWindowExtents(out num, out num2, out width, out height);
				return new Size(width, height);
			}
			set
			{
				if (value.Width > 0 && value.Height > 0)
				{
					base.Size = new Size(value.Width, value.Height);
				}
			}
		}

		[Category("Layout"), Description("Visible image part (Column, Row, Width, Height)."), EditorBrowsable(EditorBrowsableState.Always)]
		public Rectangle HImagePart
		{
			get
			{
				if (this._hwindow != null)
				{
					int num;
					int num2;
					int num3;
					int num4;
					this._hwindow.GetPart(out num, out num2, out num3, out num4);
					return new Rectangle(num2, num, num4 - num2 + 1, num3 - num + 1);
				}
				return this._part;
			}
			set
			{
				if (HSmartWindowControl.RunningInDesignerMode)
				{
					this._part = value;
					return;
				}
				if (value.Right <= 0 || value.Width <= 0)
				{
					return;
				}
				if (this._hwindow != null)
				{
					try
					{
						this._hwindow.SetPart(value.Top, value.Left, value.Top + value.Height - 1, value.Left + value.Width - 1);
						this._part = value;
						return;
					}
					catch (SZXCArimException)
					{
						return;
					}
				}
				this._part = value;
			}
		}

		[Category("Behavior"), Description("Modifier key to interact with drawing objects. If a modifier key is selected, the user can only interact with drawing objects while keeping the modifier key pressed. This is especially useful when interacting with XLD drawing objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public HSmartWindowControl.DrawingObjectsModifier HDrawingObjectsModifier
		{
			get
			{
				return this._drawingObjectsModifier;
			}
			set
			{
				this._drawingObjectsModifier = value;
			}
		}

		[Category("Behavior"), Description("If on, the content of the HSmartWindowControl is moved when the mouse pointer is dragged."), EditorBrowsable(EditorBrowsableState.Always)]
		public bool HMoveContent
		{
			get
			{
				return this._automove;
			}
			set
			{
				this._automove = value;
			}
		}

		[Category("Behavior"), Description("If on, the content of the HSmartWindowControl keeps its aspect ratio when the control is resized or zoomed."), EditorBrowsable(EditorBrowsableState.Always)]
		public bool HKeepAspectRatio
		{
			get
			{
				return this._keepaspectratio;
			}
			set
			{
				this._keepaspectratio = value;
			}
		}

		[Category("Behavior"), Description("Controls the behavior of the mouse wheel."), EditorBrowsable(EditorBrowsableState.Always)]
		public HSmartWindowControl.ZoomContent HZoomContent
		{
			get
			{
				return this._zooming;
			}
			set
			{
				this._zooming = value;
			}
		}

		[Category("Behavior"), Description("If on, double clicking resizes the content of the HSmartWindowControl to fit the size of the control. "), EditorBrowsable(EditorBrowsableState.Always)]
		public bool HDoubleClickToFitContent
		{
			get
			{
				return this._resetpart;
			}
			set
			{
				this._resetpart = value;
			}
		}

		public HSmartWindowControl()
		{
			this.InitializeComponent();
		}

		public void SetFullImagePart(HImage reference = null)
		{
			if (reference != null)
			{
				int num;
				int num2;
				reference.GetImageSize(out num, out num2);
				this._hwindow.SetPart(0, 0, num2 - 1, num - 1);
				return;
			}
			if (this.HKeepAspectRatio)
			{
				this._hwindow.SetPart(0, 0, -2, -2);
				return;
			}
			this._hwindow.SetPart(0, 0, -1, -1);
		}

		private int HWindowCallback(IntPtr context)
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new MethodInvoker(delegate
				{
					base.Invalidate();
				}));
			}
			else
			{
				base.Invalidate();
			}
			return 2;
		}

		private void ctrl_Click(object sender, EventArgs e)
		{
			base.InvokeOnClick(this, EventArgs.Empty);
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (!HSmartWindowControl.RunningInDesignerMode)
			{
				e.Control.Click += new EventHandler(this.ctrl_Click);
				e.Control.GotFocus += new EventHandler(this.Control_GotFocus);
				e.Control.LostFocus += new EventHandler(this.Control_LostFocus);
				e.Control.MouseEnter += new EventHandler(this.Control_MouseEnter);
				e.Control.MouseLeave += new EventHandler(this.Control_MouseLeave);
				e.Control.MouseHover += new EventHandler(this.Control_MouseHover);
				e.Control.SizeChanged += new EventHandler(this.Control_SizeChanged);
				e.Control.KeyDown += new KeyEventHandler(this.Control_KeyDown);
				e.Control.KeyPress += new KeyPressEventHandler(this.Control_KeyPress);
				e.Control.KeyUp += new KeyEventHandler(this.Control_KeyUp);
				e.Control.Resize += new EventHandler(this.Control_Resize);
			}
		}

		private void Control_Resize(object sender, EventArgs e)
		{
			this.OnResize(e);
		}

		private void Control_KeyUp(object sender, KeyEventArgs e)
		{
			this.OnKeyUp(e);
		}

		private void Control_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.OnKeyPress(e);
		}

		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			this.OnKeyDown(e);
		}

		private void Control_SizeChanged(object sender, EventArgs e)
		{
			this.OnSizeChanged(e);
		}

		private void Control_MouseHover(object sender, EventArgs e)
		{
			this.OnMouseHover(e);
		}

		private void Control_MouseLeave(object sender, EventArgs e)
		{
			this.OnMouseLeave(e);
		}

		private void Control_MouseEnter(object sender, EventArgs e)
		{
			this.OnMouseEnter(e);
		}

		private void Control_LostFocus(object sender, EventArgs e)
		{
			base.InvokeLostFocus(this, EventArgs.Empty);
		}

		private void Control_GotFocus(object sender, EventArgs e)
		{
			base.InvokeGotFocus(this, EventArgs.Empty);
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			if (!HSmartWindowControl.RunningInDesignerMode)
			{
				e.Control.Click -= new EventHandler(this.ctrl_Click);
				e.Control.GotFocus -= new EventHandler(this.Control_GotFocus);
				e.Control.LostFocus -= new EventHandler(this.Control_LostFocus);
				e.Control.MouseEnter -= new EventHandler(this.Control_MouseEnter);
				e.Control.MouseLeave -= new EventHandler(this.Control_MouseLeave);
				e.Control.MouseHover -= new EventHandler(this.Control_MouseHover);
				e.Control.SizeChanged -= new EventHandler(this.Control_SizeChanged);
				e.Control.KeyDown -= new KeyEventHandler(this.Control_KeyDown);
				e.Control.KeyPress -= new KeyPressEventHandler(this.Control_KeyPress);
				e.Control.KeyUp -= new KeyEventHandler(this.Control_KeyUp);
				e.Control.Resize -= new EventHandler(this.Control_Resize);
			}
			base.OnControlRemoved(e);
		}

		private void CreateHWindow()
		{
			if (!HSmartWindowControl.RunningInDesignerMode)
			{
				this._hwindow = new HWindow(0, 0, base.Width, base.Height, "", "buffer", "");
				this._hwindow.SetPart(this._part.Top, this._part.Left, this._part.Top + this._part.Height - 1, this._part.Left + this._part.Width - 1);
				this._hwindow.SetWindowParam("graphics_stack", "true");
				this._prevsize.Width = base.Width;
				this._prevsize.Height = base.Height;
				this._dump_params = new HTuple(this._hwindow);
				this._dump_params[1] = "interleaved";
				this._hwindow.OnContentUpdate(new HWindow.ContentUpdateCallback(this.HWindowCallback));
				base.SizeChanged += new EventHandler(this.HSmartWindowControl_SizeChanged);
				if (this.HInitWindow != null)
				{
					this.HInitWindow(this, new EventArgs());
				}
			}
		}

		private void HSmartWindowControl_SizeChanged(object sender, EventArgs e)
		{
			this.WindowFrame.Size = base.Size;
			if (this.HKeepAspectRatio)
			{
				using (HTuple hTuple = new HTuple(this._hwindow))
				{
					this.calculate_part(hTuple, this._prevsize.Width, this._prevsize.Height);
				}
			}
		}

		private void HSmartWindowControl_Load(object sender, EventArgs e)
		{
			if (this._hwindow == null)
			{
				this.CreateHWindow();
			}
		}

		private void GetFloatPart(HWindow window, out double l1, out double c1, out double l2, out double c2)
		{
			HTuple t;
			HTuple t2;
			HTuple t3;
			HTuple t4;
			window.GetPart(out t, out t2, out t3, out t4);
			l1 = t;
			c1 = t2;
			l2 = t3;
			c2 = t4;
		}

		public static Image SZXCArimToWinFormsImage(HImage himage)
		{
			HImage hImage = himage.InterleaveChannels("argb", "match", 255);
			string text;
			int num;
			int height;
			IntPtr imagePointer = hImage.GetImagePointer1(out text, out num, out height);
			Bitmap bitmap = new Bitmap(num / 4, height, num, PixelFormat.Format32bppPArgb, imagePointer);
			Image result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				memoryStream.Position = 0L;
				result = Image.FromStream(memoryStream);
			}
			hImage.Dispose();
			bitmap.Dispose();
			return result;
		}

		private bool InteractingWithDrawingObjs()
		{
			switch (this.HDrawingObjectsModifier)
			{
			case HSmartWindowControl.DrawingObjectsModifier.Shift:
				return Control.ModifierKeys == Keys.Shift;
			case HSmartWindowControl.DrawingObjectsModifier.Ctrl:
				return Control.ModifierKeys == Keys.Control;
			case HSmartWindowControl.DrawingObjectsModifier.Alt:
				return Control.ModifierKeys == Keys.Alt;
			default:
				return true;
			}
		}

		private int MouseEventToInt(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				return 1;
			}
			if (e.Button == MouseButtons.Right)
			{
				return 4;
			}
			if (e.Button == MouseButtons.Middle)
			{
				return 2;
			}
			return 0;
		}

		private HMouseEventArgs ToHMouse(MouseEventArgs e)
		{
			double y;
			double x;
			this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out y, out x);
			return new HMouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
		}

		private void WindowFrame_MouseDown(object sender, MouseEventArgs e)
		{
			HMouseEventArgs e2 = null;
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					this._left_button_down = true;
					this._last_position.X = e.X;
					this._last_position.Y = e.Y;
				}
				if (this.InteractingWithDrawingObjs())
				{
					double d;
					double d2;
					this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out d, out d2);
					this._hwindow.SendMouseDownEvent(d, d2, this.MouseEventToInt(e));
				}
				e2 = this.ToHMouse(e);
			}
			catch (SZXCArimException he)
			{
				if (this.HErrorNotify != null)
				{
					this.HErrorNotify(he);
				}
			}
			if (this.HMouseDown != null)
			{
				this.HMouseDown(this, e2);
			}
		}

		public void HShiftWindowContents(double dx, double dy)
		{
			double num;
			double num2;
			double num3;
			double num4;
			this.GetFloatPart(this._hwindow, out num, out num2, out num3, out num4);
			int num5;
			int num6;
			int num7;
			int num8;
			this._hwindow.GetWindowExtents(out num5, out num6, out num7, out num8);
			double num9 = (num4 - num2 + 1.0) / (double)num7;
			double num10 = (num3 - num + 1.0) / (double)num8;
			try
			{
				this._hwindow.SetPart(num + dy * num10, num2 + dx * num9, num3 + dy * num10, num4 + dx * num9);
			}
			catch (SZXCArimException)
			{
			}
		}

		private void WindowFrame_MouseMove(object sender, MouseEventArgs e)
		{
			HMouseEventArgs e2 = null;
			try
			{
				bool flag = false;
				if (this._left_button_down && this.InteractingWithDrawingObjs())
				{
					double d;
					double d2;
					this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out d, out d2);
					flag = this._hwindow.SendMouseDragEvent(d, d2, this.MouseEventToInt(e))[0].Equals("true");
				}
				if (!flag && this._left_button_down && this.HMoveContent)
				{
					this.HShiftWindowContents((double)(this._last_position.X - e.X), (double)(this._last_position.Y - e.Y));
				}
				this._last_position.X = e.X;
				this._last_position.Y = e.Y;
				e2 = this.ToHMouse(e);
			}
			catch (SZXCArimException he)
			{
				if (this.HErrorNotify != null)
				{
					this.HErrorNotify(he);
				}
			}
			if (this.HMouseMove != null)
			{
				this.HMouseMove(this, e2);
			}
		}

		private void WindowFrame_MouseUp(object sender, MouseEventArgs e)
		{
			HMouseEventArgs e2 = null;
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					double d;
					double d2;
					this._hwindow.ConvertCoordinatesWindowToImage((double)e.Y, (double)e.X, out d, out d2);
					this._hwindow.SendMouseUpEvent(d, d2, this.MouseEventToInt(e));
					this._left_button_down = false;
				}
				this._last_position.X = e.X;
				this._last_position.Y = e.Y;
				e2 = this.ToHMouse(e);
			}
			catch (SZXCArimException he)
			{
				if (this.HErrorNotify != null)
				{
					this.HErrorNotify(he);
				}
			}
			if (this.HMouseUp != null)
			{
				this.HMouseUp(this, e2);
			}
		}

		private void WindowFrame_DoubleClick(object sender, EventArgs e)
		{
			HMouseEventArgs e2 = null;
			try
			{
				bool flag = false;
				MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
				this._last_position.X = mouseEventArgs.X;
				this._last_position.Y = mouseEventArgs.Y;
				if (mouseEventArgs.Button == MouseButtons.Left && this.InteractingWithDrawingObjs())
				{
					double d;
					double d2;
					this._hwindow.ConvertCoordinatesWindowToImage((double)this._last_position.Y, (double)this._last_position.X, out d, out d2);
					flag = this._hwindow.SendMouseDoubleClickEvent(d, d2, this.MouseEventToInt(mouseEventArgs))[0].Equals("true");
				}
				if (!flag && this.HDoubleClickToFitContent)
				{
					this.SetFullImagePart(null);
				}
				e2 = this.ToHMouse(mouseEventArgs);
			}
			catch (SZXCArimException he)
			{
				if (this.HErrorNotify != null)
				{
					this.HErrorNotify(he);
				}
			}
			if (this.HMouseDoubleClick != null)
			{
				this.HMouseDoubleClick(this, e2);
			}
		}

		private void WindowFrame_MouseLeave(object sender, EventArgs e)
		{
			this._left_button_down = false;
		}

		public void HSmartWindowControl_MouseWheel(object sender, MouseEventArgs e)
		{
			HMouseEventArgs e2 = null;
			try
			{
				if (this._zooming != HSmartWindowControl.ZoomContent.Off)
				{
					HTuple homMat2D;
					HOperatorSet.HomMat2dIdentity(out homMat2D);
					Point point = base.PointToClient(Cursor.Position);
					double d;
					double d2;
					this._hwindow.ConvertCoordinatesWindowToImage((double)point.Y, (double)point.X, out d, out d2);
					double num = (e.Delta < 0) ? Math.Sqrt(2.0) : (1.0 / Math.Sqrt(2.0));
					if (this.HZoomContent == HSmartWindowControl.ZoomContent.WheelBackwardZoomsIn)
					{
						num = 1.0 / num;
					}
					for (int i = Math.Abs(e.Delta) / 120; i > 1; i--)
					{
						num *= ((e.Delta < 0) ? Math.Sqrt(2.0) : (1.0 / Math.Sqrt(2.0)));
					}
					HTuple homMat2D2;
					HOperatorSet.HomMat2dScale(homMat2D, num, num, d2, d, out homMat2D2);
					double d3;
					double d4;
					double d5;
					double d6;
					this.GetFloatPart(this._hwindow, out d3, out d4, out d5, out d6);
					HTuple hTuple;
					HTuple hTuple2;
					HOperatorSet.AffineTransPoint2d(homMat2D2, d4, d3, out hTuple, out hTuple2);
					HTuple hTuple3;
					HTuple hTuple4;
					HOperatorSet.AffineTransPoint2d(homMat2D2, d6, d5, out hTuple3, out hTuple4);
					e2 = this.ToHMouse(e);
					try
					{
						this._hwindow.SetPart(hTuple2.D, hTuple.D, hTuple4.D, hTuple3.D);
						goto IL_1BB;
					}
					catch (Exception)
					{
						this._hwindow.SetPart(d3, d4, d5, d6);
						goto IL_1BB;
					}
				}
				e2 = this.ToHMouse(e);
				IL_1BB:;
			}
			catch (SZXCArimException he)
			{
				if (this.HErrorNotify != null)
				{
					this.HErrorNotify(he);
				}
			}
			if (this.HMouseWheel != null)
			{
				this.HMouseWheel(this, e2);
			}
		}

		private void HSmartWindowControl_Paint(object sender, PaintEventArgs e)
		{
			if (this._hwindow == null || HSmartWindowControl.RunningInDesignerMode)
			{
				return;
			}
			bool flag = false;
			int num;
			int num2;
			int num3;
			int num4;
			this._hwindow.GetWindowExtents(out num, out num2, out num3, out num4);
			if (base.Width > 0 && base.Height > 0 && (num3 != base.Width || num4 != base.Height))
			{
				this.WindowFrame.Width = base.Width;
				this.WindowFrame.Height = base.Height;
				int num5;
				int num6;
				int width;
				int height;
				this._hwindow.GetWindowExtents(out num5, out num6, out width, out height);
				try
				{
					this._hwindow.SetWindowExtents(0, 0, base.Width, base.Height);
					flag = true;
				}
				catch (SZXCArimException)
				{
					this._hwindow.SetWindowExtents(0, 0, width, height);
				}
			}
			if (this.HKeepAspectRatio & flag)
			{
				using (HTuple hTuple = new HTuple(this._hwindow))
				{
					this.calculate_part(hTuple, this._prevsize.Width, this._prevsize.Height);
				}
			}
			this._prevsize.Width = this.WindowFrame.Width;
			this._prevsize.Height = this.WindowFrame.Height;
			this._netimg.Dispose();
			HOperatorSet.DumpWindowImage(out this._netimg, this._dump_params);
			HTuple hTuple2;
			HTuple hTuple3;
			HTuple hTuple4;
			HTuple t;
			HOperatorSet.GetImagePointer1(this._netimg, out hTuple2, out hTuple3, out hTuple4, out t);
			Bitmap image = new Bitmap(hTuple4 / 4, t, hTuple4, PixelFormat.Format32bppPArgb, (IntPtr)hTuple2.L);
			this.WindowFrame.Image = image;
		}

		private bool calculate_part(HTuple hv_WindowHandle, HTuple hv_WindowWidth, HTuple hv_WindowHeight)
		{
			HTuple hTuple = null;
			HTuple hTuple2 = null;
			HTuple hTuple3 = null;
			HTuple hTuple4 = null;
			HTuple hTuple5 = null;
			HTuple hTuple6 = null;
			HTuple t = null;
			HTuple t2 = null;
			HTuple homMat2D = null;
			HTuple homMat2D2 = null;
			HTuple hTuple7 = null;
			HTuple hTuple8 = null;
			bool result = true;
			HOperatorSet.GetPart(hv_WindowHandle, out hTuple, out hTuple2, out hTuple3, out hTuple4);
			try
			{
				HTuple arg_60_0 = hTuple4 - hTuple2 + 1;
				HTuple hTuple9 = hTuple3 - hTuple + 1;
				//arg_60_0 / hTuple9.TupleReal();
				HOperatorSet.GetWindowExtents(hv_WindowHandle, out hTuple5, out hTuple6, out t, out t2);
				HTuple sx = t / hv_WindowWidth.TupleReal();
				HTuple sy = t2 / hv_WindowHeight.TupleReal();
				HTuple hTuple10 = new HTuple();
				hTuple10 = hTuple10.TupleConcat((hTuple + hTuple3) * 0.5);
				hTuple10 = hTuple10.TupleConcat((hTuple2 + hTuple4) * 0.5);
				HOperatorSet.HomMat2dIdentity(out homMat2D);
				HOperatorSet.HomMat2dScale(homMat2D, sx, sy, hTuple10.TupleSelect(1), hTuple10.TupleSelect(0), out homMat2D2);
				HOperatorSet.AffineTransPoint2d(homMat2D2, hTuple2.TupleConcat(hTuple4), hTuple.TupleConcat(hTuple3), out hTuple7, out hTuple8);
				HOperatorSet.SetPart(hv_WindowHandle, hTuple8.TupleSelect(0), hTuple7.TupleSelect(0), hTuple8.TupleSelect(1), hTuple7.TupleSelect(1));
			}
			catch (SZXCArimException)
			{
				HOperatorSet.SetPart(hv_WindowHandle, hTuple, hTuple2, hTuple3, hTuple4);
				result = false;
			}
			return result;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this._hwindow != null)
				{
					this._hwindow.Dispose();
				}
				if (this._dump_params != null)
				{
					this._dump_params.Dispose();
				}
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.WindowFrame = new PictureBox();
			((ISupportInitialize)this.WindowFrame).BeginInit();
			base.SuspendLayout();
			this.WindowFrame.BackColor = SystemColors.Desktop;
			this.WindowFrame.Dock = DockStyle.Fill;
			this.WindowFrame.Location = new Point(0, 0);
			this.WindowFrame.Margin = new Padding(0);
			this.WindowFrame.Name = "WindowFrame";
			this.WindowFrame.Size = new Size(512, 512);
			this.WindowFrame.TabIndex = 0;
			this.WindowFrame.TabStop = false;
			this.WindowFrame.MouseDoubleClick += new MouseEventHandler(this.WindowFrame_DoubleClick);
			this.WindowFrame.MouseDown += new MouseEventHandler(this.WindowFrame_MouseDown);
			this.WindowFrame.MouseMove += new MouseEventHandler(this.WindowFrame_MouseMove);
			this.WindowFrame.MouseUp += new MouseEventHandler(this.WindowFrame_MouseUp);
			this.WindowFrame.MouseLeave += new EventHandler(this.WindowFrame_MouseLeave);
			base.AutoScaleMode = AutoScaleMode.None;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.AutoValidate = AutoValidate.EnableAllowFocusChange;
			base.Controls.Add(this.WindowFrame);
			base.Margin = new Padding(0);
			base.Name = "HSmartWindowControl";
			base.Size = new Size(512, 512);
			base.Load += new EventHandler(this.HSmartWindowControl_Load);
			base.Paint += new PaintEventHandler(this.HSmartWindowControl_Paint);
			((ISupportInitialize)this.WindowFrame).EndInit();
			base.ResumeLayout(false);
		}
	}
}
