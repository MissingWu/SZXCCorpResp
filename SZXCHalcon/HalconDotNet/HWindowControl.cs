using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SZXCArimEngine
{
	[DefaultEvent("HMouseMove"), Designer(typeof(HWindowControlDesigner)), ToolboxBitmap(typeof(HWindowControl))]
	public class HWindowControl : UserControl
	{
		private IntPtr hwnd = IntPtr.Zero;

		private HWindow window;

		private Rectangle imagePart = new Rectangle(0, 0, 640, 480);

		private Rectangle windowExtents = new Rectangle(0, 0, 320, 240);

		private int borderWidth;

		private Color borderColor = Color.Black;

		private PaintEventHandler paintEventDelegate;

		private Container components;

		private const string positionDescription = " The position is returned in the image coordinate system.";

		[Category("Behavior"), Description("Occurs after the SZXCArim window has been initialized.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HInitWindowEventHandler HInitWindow;

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

		[Category("Mouse"), Description("Occurs when the wheel is used over the SZXCArim window. Note that button is meaningless here. The position is returned in the image coordinate system.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandler HMouseWheel;

		protected override Size DefaultSize
		{
			get
			{
				return new Size(320, 240);
			}
		}

		[Category("Layout"), Description("Size of the SZXCArim window in pixels. Without border, this will be identical to the control size")]
		public Size WindowSize
		{
			get
			{
				return this.windowExtents.Size;
			}
			set
			{
				base.ClientSize = new Size(value.Width + 2 * this.borderWidth, value.Height + 2 * this.borderWidth);
			}
		}

		[Category("Layout"), Description("This rectangle specifies the image part to be displayed, which will automatically be zoomed to fill the window. To display a full image of size W x H, set this to 0;0;W;H")]
		public Rectangle ImagePart
		{
			get
			{
				if (this.window != null)
				{
					int num;
					int num2;
					int num3;
					int num4;
					this.window.GetPart(out num, out num2, out num3, out num4);
					this.imagePart = new Rectangle(num2, num, num4 - num2 + 1, num3 - num + 1);
				}
				return this.imagePart;
			}
			set
			{
				if (value.IsEmpty)
				{
					this.imagePart = new Rectangle(0, 0, base.Width - 2 * this.borderWidth, base.Height - 2 * this.BorderWidth);
				}
				else
				{
					this.imagePart = value;
				}
				this.UpdatePart();
			}
		}

		[Category("Appearance"), DefaultValue(0), Description("Width of optional border in pixels")]
		public int BorderWidth
		{
			get
			{
				return this.borderWidth;
			}
			set
			{
				this.borderWidth = value;
				this.UpdateWindowExtents();
			}
		}

		[Category("Appearance"), Description("Color of optional border around window")]
		public Color BorderColor
		{
			get
			{
				return this.borderColor;
			}
			set
			{
				this.borderColor = value;
				this.BackColor = this.borderColor;
			}
		}

		[Browsable(false)]
		public HWindow HalconWindow
		{
			get
			{
				if (this.window != null)
				{
					return this.window;
				}
				return new HWindow();
			}
		}

		[Browsable(false)]
		public IntPtr HalconID
		{
			get
			{
				if (this.window != null)
				{
					return this.window.Handle;
				}
				return IntPtr.Zero;
			}
		}

		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Browsable(false)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		[Browsable(false)]
		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		public HWindowControl()
		{
			this.InitializeComponent();
			if (SZXCArimAPI.isWindows)
			{
				this.createWindow(false);
			}
			this.paintEventDelegate = new PaintEventHandler(this.HWindowControl_Paint);
			base.Paint += this.paintEventDelegate;
		}

		private void HWindowControl_Paint(object sender, PaintEventArgs e)
		{
			base.Paint -= this.paintEventDelegate;
			if (!SZXCArimAPI.isWindows)
			{
				this.createWindow(false);
				try
				{
					((Form)base.TopLevelControl).Closing += new CancelEventHandler(this.Form_Closing);
				}
				catch (Exception)
				{
				}
			}
			this.OnHInitWindow();
		}

		private void Form_Closing(object sender, CancelEventArgs e)
		{
			base.Dispose();
		}

		private void HWindowControl_VisibleChanged(object sender, EventArgs e)
		{
			if (this.window != null && base.Visible && this.hwnd != base.Handle)
			{
				this.createWindow(true);
			}
		}

		private void createWindow(bool repair)
		{
			this.BackColor = this.BorderColor;
			if ((this.window == null | repair) && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
			{
				try
				{
					HOperatorSet.SetCheck("~father");
					if (this.window == null)
					{
						this.window = new HWindow();
					}
					else
					{
						int num;
						int num2;
						int num3;
						int num4;
						this.window.GetPart(out num, out num2, out num3, out num4);
						this.imagePart = new Rectangle(num2, num, num4 - num2 + 1, num3 - num + 1);
					}
					this.hwnd = base.Handle;
					this.window.OpenWindow(this.borderWidth, this.borderWidth, base.Width - 2 * this.borderWidth, base.Height - 2 * this.borderWidth, this.hwnd, "visible", "");
					this.UpdatePart();
				}
				catch (HOperatorException ex)
				{
					int errorCode = ex.GetErrorCode();
					if (errorCode >= 5100 && errorCode < 5200)
					{
						throw ex;
					}
				}
				catch (DllNotFoundException)
				{
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.window != null)
			{
				this.window.Dispose();
				this.window = null;
				if (this.components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.Name = "HWindowControl";
			base.Size = new Size(320, 240);
			base.VisibleChanged += new EventHandler(this.HWindowControl_VisibleChanged);
			base.Resize += new EventHandler(this.HWindowControl_Resize);
			base.MouseUp += new MouseEventHandler(this.HWindowControl_MouseUp);
			base.MouseMove += new MouseEventHandler(this.HWindowControl_MouseMove);
			base.MouseWheel += new MouseEventHandler(this.HWindowControl_MouseWheel);
			base.MouseDown += new MouseEventHandler(this.HWindowControl_MouseDown);
		}

		private void UpdateWindowExtents()
		{
			this.windowExtents = new Rectangle(this.borderWidth, this.borderWidth, base.ClientSize.Width - 2 * this.borderWidth, base.ClientSize.Height - 2 * this.borderWidth);
			if (this.window != null && this.windowExtents.Width > 0 && this.windowExtents.Height > 0)
			{
				int x;
				int y;
				int width;
				int height;
				this.window.GetWindowExtents(out x, out y, out width, out height);
				if (!this.windowExtents.Equals(new Rectangle(x, y, width, height)))
				{
					this.window.SetWindowExtents(this.windowExtents.Left, this.windowExtents.Top, this.windowExtents.Width, this.windowExtents.Height);
					if (HSystem.GetSystem(new HTuple("flush_graphic")).S == "true")
					{
						this.Refresh();
						return;
					}
				}
			}
			else
			{
				this.Refresh();
			}
		}

		private void UpdatePart()
		{
			if (this.window != null)
			{
				this.window.SetPart(this.imagePart.Top, this.imagePart.Left, this.imagePart.Top + this.imagePart.Height - 1, this.imagePart.Left + this.imagePart.Width - 1);
			}
		}

		private void HWindowControl_Resize(object sender, EventArgs e)
		{
			this.UpdateWindowExtents();
		}

		public void SetFullImagePart(HImage reference)
		{
			string text;
			int width;
			int height;
			reference.GetImagePointer1(out text, out width, out height);
			this.ImagePart = new Rectangle(0, 0, width, height);
		}

		protected virtual void OnHInitWindow()
		{
			if (this.HInitWindow != null)
			{
				this.HInitWindow(this, new EventArgs());
			}
		}

		protected virtual void OnHMouseMove(HMouseEventArgs e)
		{
			if (this.HMouseMove != null)
			{
				this.HMouseMove(this, e);
			}
		}

		protected virtual void OnHMouseDown(HMouseEventArgs e)
		{
			if (this.HMouseDown != null)
			{
				this.HMouseDown(this, e);
			}
		}

		protected virtual void OnHMouseUp(HMouseEventArgs e)
		{
			if (this.HMouseUp != null)
			{
				this.HMouseUp(this, e);
			}
		}

		protected virtual void OnHMouseWheel(HMouseEventArgs e)
		{
			if (this.HMouseWheel != null)
			{
				this.HMouseWheel(this, e);
			}
		}

		private HMouseEventArgs ToHMouse(MouseEventArgs e)
		{
			double y;
			double x;
			if (this.window == null)
			{
				y = (double)this.imagePart.Top + (double)(e.Y - this.borderWidth) * (double)this.imagePart.Height / (double)this.windowExtents.Height;
				x = (double)this.imagePart.Left + (double)(e.X - this.borderWidth) * (double)this.imagePart.Width / (double)this.windowExtents.Width;
			}
			else
			{
				this.window.ConvertCoordinatesWindowToImage((double)(e.Y - this.borderWidth), (double)(e.X - this.borderWidth), out y, out x);
			}
			return new HMouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
		}

		private void HWindowControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.windowExtents.Contains(e.X, e.Y))
			{
				this.OnHMouseMove(this.ToHMouse(e));
			}
		}

		private void HWindowControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.windowExtents.Contains(e.X, e.Y))
			{
				this.OnHMouseDown(this.ToHMouse(e));
			}
		}

		private void HWindowControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.windowExtents.Contains(e.X, e.Y))
			{
				this.OnHMouseUp(this.ToHMouse(e));
			}
		}

		private void HWindowControl_MouseWheel(object sender, MouseEventArgs e)
		{
			if (this.windowExtents.Contains(e.X, e.Y))
			{
				this.OnHMouseWheel(this.ToHMouse(e));
			}
		}
	}
}
