using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SZXCArimEngine
{
	[ToolboxBitmap(typeof(HSmartWindowControlWPF), "HWindowControlWPF.icon.bmp")]
	public class HSmartWindowControlWPF : ItemsControl, INotifyPropertyChanged, IDisposable
	{
		public class HMouseEventArgsWPF : EventArgs
		{
			private readonly double x;

			private readonly double y;

			private readonly double row;

			private readonly double column;

			private readonly int delta;

			private readonly MouseButton? button;

			public double X
			{
				get
				{
					return this.x;
				}
			}

			public double Y
			{
				get
				{
					return this.y;
				}
			}

			public double Row
			{
				get
				{
					return this.row;
				}
			}

			public double Column
			{
				get
				{
					return this.column;
				}
			}

			public int Delta
			{
				get
				{
					return this.delta;
				}
			}

			public MouseButton? Button
			{
				get
				{
					return this.button;
				}
			}

			internal HMouseEventArgsWPF(double x, double y, double row, double column, int delta, MouseButton? button)
			{
				this.x = x;
				this.y = y;
				this.row = row;
				this.column = column;
				this.delta = delta;
				this.button = button;
			}
		}

		public enum ZoomContent
		{
			Off,
			WheelForwardZoomsIn,
			WheelBackwardZoomsIn
		}

		public enum DrawingObjectsModifier
		{
			None,
			Shift,
			Ctrl,
			Alt
		}

		public delegate void HMouseEventHandlerWPF(object sender, HSmartWindowControlWPF.HMouseEventArgsWPF e);

		public delegate void HErrorHandler(SZXCArimException he);

		public static readonly DependencyProperty HMoveContentProperty = DependencyProperty.Register("HMoveContent", typeof(bool), typeof(HSmartWindowControlWPF), new PropertyMetadata(true));

		public static readonly DependencyProperty HZoomContentProperty = DependencyProperty.Register("HZoomContent", typeof(HSmartWindowControlWPF.ZoomContent), typeof(HSmartWindowControlWPF), new PropertyMetadata(HSmartWindowControlWPF.ZoomContent.WheelForwardZoomsIn));

		private const int HZoomFactorMin = 1;

		private const int HZoomFactorMax = 100;

		public static DependencyProperty HZoomFactorProperty = DependencyProperty.Register("HZoomFactor", typeof(double), typeof(HSmartWindowControlWPF), new PropertyMetadata(Math.Round(Math.Sqrt(2.0), 2)), new ValidateValueCallback(HSmartWindowControlWPF.HZoomFactorValidation));

		public static readonly DependencyProperty HColorProperty = DependencyProperty.Register("HColor", typeof(string), typeof(HSmartWindowControlWPF), new PropertyMetadata(null, new PropertyChangedCallback(HSmartWindowControlWPF.OnDrawingPropertyChanged)));

		public static readonly DependencyProperty HColoredProperty = DependencyProperty.Register("HColored", typeof(int?), typeof(HSmartWindowControlWPF), new PropertyMetadata(null, new PropertyChangedCallback(HSmartWindowControlWPF.OnDrawingPropertyChanged)));

		public static readonly DependencyProperty HLineStyleProperty = DependencyProperty.Register("HLineStyle", typeof(HLineStyleWPF), typeof(HSmartWindowControlWPF), new PropertyMetadata(null, new PropertyChangedCallback(HSmartWindowControlWPF.OnDrawingPropertyChanged)));

		public static readonly DependencyProperty HLineWidthProperty = DependencyProperty.Register("HLineWidth", typeof(double?), typeof(HSmartWindowControlWPF), new PropertyMetadata(null, new PropertyChangedCallback(HSmartWindowControlWPF.OnDrawingPropertyChanged)));

		public static readonly DependencyProperty HDrawProperty = DependencyProperty.Register("HDraw", typeof(string), typeof(HSmartWindowControlWPF), new PropertyMetadata(null, new PropertyChangedCallback(HSmartWindowControlWPF.OnDrawingPropertyChanged)));

		public static readonly DependencyProperty HFontProperty = DependencyProperty.Register("HFont", typeof(string), typeof(HSmartWindowControlWPF), new PropertyMetadata(null, new PropertyChangedCallback(HSmartWindowControlWPF.OnDrawingPropertyChanged)));

		public static readonly DependencyProperty HDisableAutoResizeProperty = DependencyProperty.Register("HDisableAutoResize", typeof(bool), typeof(HSmartWindowControlWPF), new PropertyMetadata(false));

		public static DependencyProperty HDisplayCurrentObjectProperty = DependencyProperty.Register("HDisplayCurrentObject", typeof(HObject), typeof(HSmartWindowControlWPF), new FrameworkPropertyMetadata(new PropertyChangedCallback(HSmartWindowControlWPF.OnDisplayObjectChanged)));

		public static readonly DependencyProperty HDrawingObjectsModifierProperty = DependencyProperty.Register("HDrawingObjectsModifier", typeof(HSmartWindowControlWPF.DrawingObjectsModifier), typeof(HSmartWindowControlWPF), new PropertyMetadata(HSmartWindowControlWPF.DrawingObjectsModifier.None));

		public static readonly DependencyProperty HKeepAspectRatioProperty = DependencyProperty.Register("HKeepAspectRatio", typeof(bool), typeof(HSmartWindowControlWPF), new PropertyMetadata(true));

		public static readonly DependencyProperty HDoubleClickToFitContentProperty = DependencyProperty.Register("HDoubleClickToFitContent", typeof(bool), typeof(HSmartWindowControlWPF), new PropertyMetadata(true));

		public static readonly DependencyProperty HImagePartProperty = DependencyProperty.Register("HImagePart", typeof(Rect), typeof(HSmartWindowControlWPF), new PropertyMetadata(new Rect(0.0, 0.0, 640.0, 480.0), new PropertyChangedCallback(HSmartWindowControlWPF.OnHImagePartChanged)));

		public static readonly DependencyProperty WindowSizeProperty = DependencyProperty.Register("WindowSize", typeof(System.Windows.Size), typeof(HSmartWindowControlWPF), new PropertyMetadata(new System.Windows.Size(320.0, 200.0)));

		private bool _left_button_down;

		private System.Windows.Point _last_position;

		private HWindow _hwindow;

		private Viewbox _window_frame;

		private double _dpiX;

		private double _dpiY;

		private HTuple _dump_params;

		private bool _delayed;

		private System.Drawing.Size _prevsize;

		private HObject _dumpimg;

		private WriteableBitmap _wbitmap;

		[Category("Behavior"), Description("Occurs after the SZXCArim window has been initialized.")]
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HInitWindowEventHandler HInitWindow;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HSmartWindowControlWPF.HMouseEventHandlerWPF HMouseDown;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HSmartWindowControlWPF.HMouseEventHandlerWPF HMouseUp;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HSmartWindowControlWPF.HMouseEventHandlerWPF HMouseWheel;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HSmartWindowControlWPF.HMouseEventHandlerWPF HMouseMove;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HSmartWindowControlWPF.HMouseEventHandlerWPF HMouseDoubleClick;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HSmartWindowControlWPF.HErrorHandler HErrorNotify;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event PropertyChangedEventHandler PropertyChanged;

		public HWindow SZXCArimWindow
		{
			get
			{
				if (this._delayed)
				{
					this.HInitializeWindow();
				}
				return this._hwindow;
			}
		}

		public IntPtr SZXCArimID
		{
			get
			{
				if (this._delayed)
				{
					this.HInitializeWindow();
				}
				if (this._hwindow != null)
				{
					return this._hwindow.Handle;
				}
				return HHandleBase.UNDEF;
			}
		}

		[Category("Behavior"), Description("If on, the content of the HSmartWindowControlWPF is moved when the mouse pointer is dragged."), EditorBrowsable(EditorBrowsableState.Always)]
		public bool HMoveContent
		{
			get
			{
				return (bool)base.GetValue(HSmartWindowControlWPF.HMoveContentProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HMoveContentProperty, value);
			}
		}

		[Category("Behavior"), Description("Controls the behavior of the mouse wheel."), EditorBrowsable(EditorBrowsableState.Always)]
		public HSmartWindowControlWPF.ZoomContent HZoomContent
		{
			get
			{
				return (HSmartWindowControlWPF.ZoomContent)base.GetValue(HSmartWindowControlWPF.HZoomContentProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HZoomContentProperty, value);
			}
		}

		[Category("Behavior"), Description("Controls the behavior of the zoom factor controlled by the mouse wheel."), EditorBrowsable(EditorBrowsableState.Always)]
		public double HZoomFactor
		{
			get
			{
				return (double)base.GetValue(HSmartWindowControlWPF.HZoomFactorProperty);
			}
			set
			{
				if (value > 1.0 && value <= 100.0)
				{
					base.SetValue(HSmartWindowControlWPF.HZoomFactorProperty, value);
				}
			}
		}

		[Category("Appearance"), Description("Default color for displaying HRegion and HXLDCont objects. If HColor is set, HColored is set to null."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HColor
		{
			get
			{
				return (string)base.GetValue(HSmartWindowControlWPF.HColorProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HColorProperty, value);
			}
		}

		[Category("Appearance"), Description("Default set of colors for displaying HRegion and HXLDCont objects. If HColored is set, HColor is set to null."), EditorBrowsable(EditorBrowsableState.Always)]
		public int? HColored
		{
			get
			{
				return (int?)base.GetValue(HSmartWindowControlWPF.HColoredProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HColoredProperty, value);
			}
		}

		[Category("Appearance"), Description("Default output pattern of the margin of HRegion objects and of HXLDCont objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public HLineStyleWPF HLineStyle
		{
			get
			{
				return (HLineStyleWPF)base.GetValue(HSmartWindowControlWPF.HLineStyleProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HLineStyleProperty, value);
			}
		}

		[Category("Appearance"), Description("Default line width of the margin of HRegion objects and of HXLDCont objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public double? HLineWidth
		{
			get
			{
				return (double?)base.GetValue(HSmartWindowControlWPF.HLineWidthProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HLineWidthProperty, value);
			}
		}

		[Category("Appearance"), Description("Default fill mode of HRegion objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HDraw
		{
			get
			{
				return (string)base.GetValue(HSmartWindowControlWPF.HDrawProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HDrawProperty, value);
			}
		}

		[Category("Appearance"), Description("Font for displaying messages in the HSmartWindowControlWPF."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HFont
		{
			get
			{
				return (string)base.GetValue(HSmartWindowControlWPF.HFontProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HFontProperty, value);
			}
		}

		[Category("Behavior"), Description("Disable that images are automatically scaled when they are displayed."), EditorBrowsable(EditorBrowsableState.Always)]
		public bool HDisableAutoResize
		{
			get
			{
				return (bool)base.GetValue(HSmartWindowControlWPF.HDisableAutoResizeProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HDisableAutoResizeProperty, value);
			}
		}

		[Category("Miscellaneous"), Description("Displays the assigned HImage or HObject."), EditorBrowsable(EditorBrowsableState.Never), Obsolete("This property has been depcrecated. Please us the Items property instead.")]
		public HObject HDisplayCurrentObject
		{
			get
			{
				return (HObject)base.GetValue(HSmartWindowControlWPF.HDisplayCurrentObjectProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HDisplayCurrentObjectProperty, value);
			}
		}

		[Category("Behavior"), Description("Modifier key to interact with drawing objects. If a modifier key is selected, the user can only interact with drawing objects while keeping the modifier key pressed. This is especially useful when interacting with XLD drawing objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public HSmartWindowControlWPF.DrawingObjectsModifier HDrawingObjectsModifier
		{
			get
			{
				return (HSmartWindowControlWPF.DrawingObjectsModifier)base.GetValue(HSmartWindowControlWPF.HDrawingObjectsModifierProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HDrawingObjectsModifierProperty, value);
			}
		}

		[Category("Behavior"), Description("If on, the content of the HSmartWindowControlWPF keeps its aspect ratio when the control is resized or zoomed."), EditorBrowsable(EditorBrowsableState.Always)]
		public bool HKeepAspectRatio
		{
			get
			{
				return (bool)base.GetValue(HSmartWindowControlWPF.HKeepAspectRatioProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HKeepAspectRatioProperty, value);
			}
		}

		[Category("Behavior"), Description("If on, double clicking resizes the content of the HSmartWindowControlWPF to fit the size of the control."), EditorBrowsable(EditorBrowsableState.Always)]
		public bool HDoubleClickToFitContent
		{
			get
			{
				return (bool)base.GetValue(HSmartWindowControlWPF.HDoubleClickToFitContentProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HDoubleClickToFitContentProperty, value);
			}
		}

		[Category("Layout"), Description("Visible image part (Column, Row, Width, Height)."), EditorBrowsable(EditorBrowsableState.Always)]
		public Rect HImagePart
		{
			get
			{
				if (this._hwindow != null)
				{
					double num;
					double num2;
					double num3;
					double num4;
					this.GetFloatPart(this._hwindow, out num, out num2, out num3, out num4);
					Rect rect = default(Rect);
					rect.X = num2;
					rect.Y = num;
					rect.Width = num4 - num2 + 1.0;
					rect.Height = num3 - num + 1.0;
					base.SetValue(HSmartWindowControlWPF.HImagePartProperty, rect);
					return rect;
				}
				return (Rect)base.GetValue(HSmartWindowControlWPF.HImagePartProperty);
			}
			set
			{
				base.SetValue(HSmartWindowControlWPF.HImagePartProperty, value);
			}
		}

		public System.Windows.Size WindowSize
		{
			get
			{
				return (System.Windows.Size)base.GetValue(HSmartWindowControlWPF.WindowSizeProperty);
			}
			set
			{
				if (value.Width <= 0.0 || value.Height <= 0.0)
				{
					return;
				}
				if (!this._delayed)
				{
					int num;
					int num2;
					int width;
					int height;
					this._hwindow.GetWindowExtents(out num, out num2, out width, out height);
					try
					{
						this._hwindow.SetWindowExtents(0, 0, (int)this.WindowSize.Width, (int)this.WindowSize.Height);
						base.SetValue(HSmartWindowControlWPF.WindowSizeProperty, value);
					}
					catch (SZXCArimException)
					{
						this._hwindow.SetWindowExtents(0, 0, width, height);
					}
				}
			}
		}

		protected virtual void OnHInitWindow()
		{
			if (this.HInitWindow != null)
			{
				this.HInitWindow(this, new EventArgs());
			}
		}

		private static bool HZoomFactorValidation(object value)
		{
			return (double)value > 1.0 && (double)value <= 100.0;
		}

		private static void OnDrawingPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			HSmartWindowControlWPF hSmartWindowControlWPF = sender as HSmartWindowControlWPF;
			if (hSmartWindowControlWPF == null)
			{
				return;
			}
			if (hSmartWindowControlWPF._hwindow != null)
			{
				string name = e.Property.Name;
				if (!(name == "HLineStyle"))
				{
					if (!(name == "HLineWidth"))
					{
						if (!(name == "HDraw"))
						{
							if (!(name == "HColored"))
							{
								if (!(name == "HColor"))
								{
									if (name == "HFont")
									{
										hSmartWindowControlWPF._hwindow.SetFont((string)e.NewValue);
									}
								}
								else
								{
									hSmartWindowControlWPF.HColored = null;
									hSmartWindowControlWPF._hwindow.SetColor((string)e.NewValue);
								}
							}
							else
							{
								hSmartWindowControlWPF.HColor = null;
								hSmartWindowControlWPF._hwindow.SetColored(((int?)e.NewValue) ?? 0);
							}
						}
						else
						{
							hSmartWindowControlWPF._hwindow.SetDraw((string)e.NewValue);
						}
					}
					else
					{
						hSmartWindowControlWPF._hwindow.SetLineWidth(((double?)e.NewValue) ?? 1.0);
					}
				}
				else
				{
					hSmartWindowControlWPF._hwindow.SetLineStyle((HLineStyleWPF)e.NewValue);
				}
				hSmartWindowControlWPF.OnItemsChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		private static void OnDisplayObjectChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			HSmartWindowControlWPF arg_13_0 = source as HSmartWindowControlWPF;
			HObject newItem = (HObject)e.NewValue;
			arg_13_0.Items.Clear();
			arg_13_0.Items.Add(newItem);
		}

		internal void NotifyItemsChanged()
		{
			this.OnItemsChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			if (this._hwindow == null)
			{
				return;
			}
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (object current in e.NewItems)
				{
					if (current.GetType().IsSubclassOf(typeof(HObject)) || current.GetType() == typeof(HObject))
					{
						((HObject)current).DispObj(this._hwindow);
					}
					else if (current.GetType().IsSubclassOf(typeof(HDisplayObjectWPF)))
					{
						((HDisplayObjectWPF)current).Display(this._hwindow);
						if (this.HColor != null)
						{
							this._hwindow.SetColor(this.HColor);
						}
						if (this.HColored.HasValue)
						{
							this._hwindow.SetColored(this.HColored ?? 0);
						}
					}
				}
				if (!this.HDisableAutoResize)
				{
					this.SetFullImagePart(null);
					return;
				}
			}
			else
			{
				this._hwindow.ClearWindow();
				foreach (object current2 in ((IEnumerable)base.Items))
				{
					if (current2.GetType().IsSubclassOf(typeof(HObject)) || current2.GetType() == typeof(HObject))
					{
						((HObject)current2).DispObj(this._hwindow);
						if (this.HColor != null)
						{
							this._hwindow.SetColor(this.HColor);
						}
						if (this.HColored.HasValue)
						{
							this._hwindow.SetColored(this.HColored ?? 0);
						}
					}
					else if (current2.GetType().IsSubclassOf(typeof(HDisplayObjectWPF)))
					{
						((HDisplayObjectWPF)current2).Display(this._hwindow);
						if (this.HColor != null)
						{
							this._hwindow.SetColor(this.HColor);
						}
						if (this.HColored.HasValue)
						{
							this._hwindow.SetColored(this.HColored ?? 0);
						}
					}
				}
				if (!this.HDisableAutoResize)
				{
					this.SetFullImagePart(null);
				}
			}
		}

		private static void OnHImagePartChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			HSmartWindowControlWPF hSmartWindowControlWPF = sender as HSmartWindowControlWPF;
			if (hSmartWindowControlWPF._hwindow != null)
			{
				Rect rect = (Rect)e.NewValue;
				hSmartWindowControlWPF._hwindow.SetPart(rect.Top, rect.Left, rect.Bottom - 1.0, rect.Right - 1.0);
			}
		}

		public HSmartWindowControlWPF()
		{
			base.Margin = new Thickness(0.0);
			base.MouseWheel += new MouseWheelEventHandler(this.HWPFWindow_MouseWheel);
			base.MouseMove += new MouseEventHandler(this.HWPFWindow_MouseMove);
			base.MouseDown += new MouseButtonEventHandler(this.HWPFWindow_MouseDown);
			base.MouseUp += new MouseButtonEventHandler(this.HWPFWindow_MouseUp);
			base.MouseDoubleClick += new MouseButtonEventHandler(this.HWPFWindow_MouseDoubleClick);
			base.MouseLeave += new MouseEventHandler(this.HWPFWindow_MouseLeave);
			base.ItemsPanel = null;
			this._window_frame = new Viewbox();
			this._window_frame.Stretch = Stretch.None;
			this._window_frame.MouseLeave += new MouseEventHandler(this.HWPFWindow_MouseLeave);
			this.HInitializeWindow();
		}

		private void HInitializeWindow()
		{
			this._delayed = (base.RenderSize.Width <= 0.0 || base.RenderSize.Height <= 0.0);
			if (this._delayed && base.Parent != null)
			{
				FrameworkElement frameworkElement = base.Parent as FrameworkElement;
				if (frameworkElement != null)
				{
					base.RenderSize = frameworkElement.RenderSize;
					this._delayed = (base.RenderSize.Width <= 0.0 || base.RenderSize.Height <= 0.0);
				}
			}
			if (!this._delayed)
			{
				System.Windows.Size renderSize = base.RenderSize;
				base.Dispatcher.ShutdownStarted += new EventHandler(this.Dispatcher_ShutdownStarted);
				Rect hImagePart = this.HImagePart;
				this._hwindow = new HWindow(0, 0, (int)renderSize.Width, (int)renderSize.Height, 0, "buffer", "");
				this._hwindow.SetWindowParam("graphics_stack", "true");
				if (this.HDraw != null)
				{
					this._hwindow.SetDraw(this.HDraw);
				}
				if (this.HLineStyle != null)
				{
					this._hwindow.SetLineStyle(this.HLineStyle);
				}
				if (this.HLineWidth.HasValue)
				{
					this._hwindow.SetLineWidth(this.HLineWidth ?? 1.0);
				}
				if (this.HColor != null)
				{
					this._hwindow.SetColor(this.HColor);
				}
				if (this.HColored.HasValue)
				{
					this._hwindow.SetColored(this.HColored ?? 0);
				}
				if (this.HFont != null)
				{
					this._hwindow.SetFont(this.HFont);
				}
				this._hwindow.SetPart(hImagePart.Top, hImagePart.Left, hImagePart.Bottom - 1.0, hImagePart.Right - 1.0);
				this._prevsize.Width = (int)base.ActualWidth;
				this._prevsize.Height = (int)base.ActualHeight;
				using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
				{
					this._dpiX = (double)graphics.DpiX;
					this._dpiY = (double)graphics.DpiY;
				}
				this._dump_params = new HTuple(this._hwindow);
				this._dump_params[1] = "interleaved";
				this._hwindow.OnContentUpdate(delegate(IntPtr content)
				{
					base.Dispatcher.BeginInvoke(new Action(base.InvalidateVisual), new object[0]);
					return 2;
				});
				if (this.HInitWindow != null)
				{
					this.OnHInitWindow();
				}
			}
		}

		private System.Drawing.Size AspectRatioSize(System.Drawing.Size imgsize)
		{
			return default(System.Drawing.Size);
		}

		private void Dispatcher_ShutdownStarted(object sender, EventArgs e)
		{
			this.Dispose();
		}

		public void Dispose()
		{
			base.Dispatcher.ShutdownStarted -= new EventHandler(this.Dispatcher_ShutdownStarted);
			if (this._hwindow != null)
			{
				this._hwindow.Dispose();
			}
			if (this._dump_params != null)
			{
				this._dump_params.Dispose();
			}
		}

		private Matrix GetVisualTransform(Visual v)
		{
			if (v != null)
			{
				Matrix matrix = Matrix.Identity;
				Transform transform = VisualTreeHelper.GetTransform(v);
				if (transform != null)
				{
					Matrix value = transform.Value;
					matrix = Matrix.Multiply(matrix, value);
				}
				Vector offset = VisualTreeHelper.GetOffset(v);
				matrix.Translate(offset.X, offset.Y);
				return matrix;
			}
			return Matrix.Identity;
		}

		private System.Windows.Point TryApplyVisualTransform(System.Windows.Point point, Visual v, bool inverse, bool throwOnError, out bool success)
		{
			success = true;
			if (v != null)
			{
				Matrix visualTransform = this.GetVisualTransform(v);
				if (inverse)
				{
					if (!throwOnError && !visualTransform.HasInverse)
					{
						success = false;
						return new System.Windows.Point(0.0, 0.0);
					}
					visualTransform.Invert();
				}
				point = visualTransform.Transform(point);
			}
			return point;
		}

		private System.Windows.Point ApplyVisualTransform(System.Windows.Point point, Visual v, bool inverse)
		{
			bool flag = true;
			return this.TryApplyVisualTransform(point, v, inverse, true, out flag);
		}

		private System.Windows.Point GetPixelOffset()
		{
			System.Windows.Point point = default(System.Windows.Point);
			PresentationSource presentationSource = PresentationSource.FromVisual(this);
			if (presentationSource != null)
			{
				Visual rootVisual = presentationSource.RootVisual;
				if (((FrameworkElement)rootVisual).ActualHeight > 0.0 && ((FrameworkElement)rootVisual).ActualWidth > 0.0)
				{
					point = base.TransformToAncestor(rootVisual).Transform(point);
					point = this.ApplyVisualTransform(point, rootVisual, false);
					point = presentationSource.CompositionTarget.TransformToDevice.Transform(point);
					point.X = Math.Round(point.X);
					point.Y = Math.Round(point.Y);
					point = presentationSource.CompositionTarget.TransformFromDevice.Transform(point);
					point = this.ApplyVisualTransform(point, rootVisual, true);
					point = rootVisual.TransformToDescendant(this).Transform(point);
				}
			}
			return point;
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			bool flag = false;
			if (base.Background != null)
			{
				base.Background = null;
			}
			if (DesignerProperties.GetIsInDesignMode(this))
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SZXCArimEngine.SZXCArim_icon_48.png");
				if (manifestResourceStream == null)
				{
					drawingContext.DrawRectangle(new SolidColorBrush(Colors.Black), null, new Rect(0.0, 0.0, base.ActualWidth, base.ActualHeight));
					return;
				}
				try
				{
					BitmapImage bitmapImage = new BitmapImage();
					bitmapImage.BeginInit();
					bitmapImage.StreamSource = manifestResourceStream;
					bitmapImage.EndInit();
					int num = (int)base.ActualWidth / 2 - 24;
					int num2 = (int)base.ActualHeight / 2 - 24;
					drawingContext.DrawRectangle(new SolidColorBrush(Colors.Black), null, new Rect(0.0, 0.0, base.ActualWidth, base.ActualHeight));
					if (base.ActualWidth > 48.0 && base.ActualHeight > 48.0)
					{
						drawingContext.DrawImage(bitmapImage, new Rect((double)num, (double)num2, 48.0, 48.0));
					}
				}
				catch
				{
				}
				return;
			}
			else
			{
				if (this._hwindow == null || this._delayed)
				{
					this.HInitializeWindow();
				}
				if (this._hwindow == null)
				{
					base.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
					return;
				}
				if (base.ActualWidth < 1.0 || base.ActualHeight < 1.0)
				{
					drawingContext.DrawRectangle(new SolidColorBrush(Colors.Black), null, new Rect(0.0, 0.0, base.ActualWidth, base.ActualHeight));
					return;
				}
				int num3;
				int num4;
				int num5;
				int num6;
				this._hwindow.GetWindowExtents(out num3, out num4, out num5, out num6);
				if (num5 != (int)base.ActualWidth || num6 != (int)base.ActualHeight)
				{
					this.WindowSize = new System.Windows.Size(base.ActualWidth, base.ActualHeight);
					flag = true;
				}
				if (this.HKeepAspectRatio & flag)
				{
					HTuple hTuple = new HTuple(this._hwindow);
					this.calculate_part(hTuple, this._prevsize.Width, this._prevsize.Height);
					hTuple.Dispose();
					this.SetFullImagePart(null);
				}
				this._prevsize.Width = (int)base.ActualWidth;
				this._prevsize.Height = (int)base.ActualHeight;
				if (this._dumpimg != null)
				{
					this._dumpimg.Dispose();
				}
				HOperatorSet.DumpWindowImage(out this._dumpimg, this._dump_params);
				HTuple hTuple2;
				HTuple hTuple3;
				HTuple hTuple4;
				HTuple hTuple5;
				HOperatorSet.GetImagePointer1(this._dumpimg, out hTuple2, out hTuple3, out hTuple4, out hTuple5);
				IntPtr buffer = (IntPtr)hTuple2.L;
				if (this._wbitmap == null || hTuple4 / 4 != (int)this._wbitmap.Width || hTuple5 != (int)this._wbitmap.Height)
				{
					this._wbitmap = new WriteableBitmap(hTuple4 / 4, hTuple5, this._dpiX, this._dpiY, PixelFormats.Bgra32, null);
				}
				this._wbitmap.Lock();
				this._wbitmap.WritePixels(new Int32Rect(0, 0, hTuple4 / 4, hTuple5), buffer, hTuple4 * hTuple5, hTuple4);
				this._wbitmap.Unlock();
				System.Windows.Point pixelOffset = this.GetPixelOffset();
				drawingContext.DrawImage(this._wbitmap, new Rect(pixelOffset.X, pixelOffset.Y, hTuple4 / 4, hTuple5));
				return;
			}
		}

		private HSmartWindowControlWPF.HMouseEventArgsWPF ToHMouse(int x, int y, MouseEventArgs e, int delta)
		{
			MouseButton? button = null;
			double row;
			double column;
			this._hwindow.ConvertCoordinatesWindowToImage((double)y, (double)x, out row, out column);
			if (e != null)
			{
				if (e.LeftButton == MouseButtonState.Pressed)
				{
					button = new MouseButton?(MouseButton.Left);
				}
				else if (e.RightButton == MouseButtonState.Pressed)
				{
					button = new MouseButton?(MouseButton.Right);
				}
				else if (e.MiddleButton == MouseButtonState.Pressed)
				{
					button = new MouseButton?(MouseButton.Middle);
				}
				else if (e.XButton1 == MouseButtonState.Pressed)
				{
					button = new MouseButton?(MouseButton.XButton1);
				}
				else if (e.XButton2 == MouseButtonState.Pressed)
				{
					button = new MouseButton?(MouseButton.XButton2);
				}
			}
			return new HSmartWindowControlWPF.HMouseEventArgsWPF((double)x, (double)y, row, column, delta, button);
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

		public void HZoomWindowContents(double x, double y, int Delta)
		{
			HTuple homMat2D;
			HOperatorSet.HomMat2dIdentity(out homMat2D);
			double d;
			double d2;
			this.ConvertWindowsCoordinatesToHImage(y, x, out d, out d2);
			double num = (Delta < 0) ? this.HZoomFactor : (1.0 / this.HZoomFactor);
			if (this.HZoomContent == HSmartWindowControlWPF.ZoomContent.WheelBackwardZoomsIn)
			{
				num = 1.0 / num;
			}
			for (int i = Math.Abs(Delta) / 120; i > 1; i--)
			{
				num *= ((Delta < 0) ? this.HZoomFactor : (1.0 / this.HZoomFactor));
			}
			HTuple homMat2D2;
			HOperatorSet.HomMat2dScale(homMat2D, num, num, d2, d, out homMat2D2);
			double num2;
			double num3;
			double num4;
			double num5;
			this.GetFloatPart(this._hwindow, out num2, out num3, out num4, out num5);
			HTuple hTuple;
			HTuple hTuple2;
			HOperatorSet.AffineTransPoint2d(homMat2D2, num3, num2, out hTuple, out hTuple2);
			HTuple hTuple3;
			HTuple hTuple4;
			HOperatorSet.AffineTransPoint2d(homMat2D2, num5, num4, out hTuple3, out hTuple4);
			try
			{
				this.HImagePart = new Rect(hTuple.D, hTuple2.D, hTuple3.D - hTuple.D + 1.0, hTuple4.D - hTuple2.D + 1.0);
			}
			catch (Exception)
			{
				try
				{
					this.HImagePart = new Rect(num3, num2, num5 - num3 + 1.0, num4 - num2 + 1.0);
				}
				catch (SZXCArimException)
				{
				}
			}
		}

		private void HWPFWindow_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			HSmartWindowControlWPF.HMouseEventArgsWPF e2 = null;
			try
			{
				if (this.HZoomContent != HSmartWindowControlWPF.ZoomContent.Off)
				{
					this._last_position = this.GetPosition(e);
					this.HZoomWindowContents(this._last_position.X, this._last_position.Y, e.Delta);
				}
				e2 = this.ToHMouse((int)this._last_position.X, (int)this._last_position.Y, null, e.Delta);
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

		private void ConvertWindowsCoordinatesToHImage(double wr, double wc, out double ir, out double ic)
		{
			this._hwindow.ConvertCoordinatesWindowToImage(wr, wc, out ir, out ic);
		}

		private int MouseEventToInt(MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed || e.LeftButton == MouseButtonState.Released)
			{
				return 1;
			}
			if (e.RightButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Released)
			{
				return 4;
			}
			if (e.MiddleButton == MouseButtonState.Pressed || e.MiddleButton == MouseButtonState.Released)
			{
				return 2;
			}
			return 0;
		}

		private bool InteractingWithDrawingObjs()
		{
			switch (this.HDrawingObjectsModifier)
			{
			case HSmartWindowControlWPF.DrawingObjectsModifier.Shift:
				return Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
			case HSmartWindowControlWPF.DrawingObjectsModifier.Ctrl:
				return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
			case HSmartWindowControlWPF.DrawingObjectsModifier.Alt:
				return Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt);
			default:
				return true;
			}
		}

		public void HShiftWindowContents(double dx, double dy)
		{
			int num;
			int num2;
			int num3;
			int num4;
			this._hwindow.GetWindowExtents(out num, out num2, out num3, out num4);
			double num5;
			double num6;
			double num7;
			double num8;
			this.GetFloatPart(this._hwindow, out num5, out num6, out num7, out num8);
			double num9 = (num8 - num6 + 1.0) / (double)num3;
			double num10 = (num7 - num5 + 1.0) / (double)num4;
			try
			{
				double num11 = num5 + dy * num10;
				double num12 = num7 + dy * num10;
				double num13 = num6 + dx * num9;
				double num14 = num8 + dx * num9;
				this.HImagePart = new Rect(num13, num11, num14 - num13 + 1.0, num12 - num11 + 1.0);
			}
			catch (SZXCArimException)
			{
				this.HImagePart = new Rect(num6, num5, num8 - num6 + 1.0, num7 - num5 + 1.0);
			}
		}

		private void HWPFWindow_MouseMove(object sender, MouseEventArgs e)
		{
			HSmartWindowControlWPF.HMouseEventArgsWPF e2 = null;
			try
			{
				if (this._delayed)
				{
					return;
				}
				System.Windows.Point position = this.GetPosition(e);
				bool flag = false;
				if (this._left_button_down && this.InteractingWithDrawingObjs())
				{
					double d;
					double d2;
					this.ConvertWindowsCoordinatesToHImage(position.Y, position.X, out d, out d2);
					flag = this._hwindow.SendMouseDragEvent(d, d2, this.MouseEventToInt(e))[0].Equals("true");
				}
				if (this._left_button_down && !flag && this.HMoveContent)
				{
					this.HShiftWindowContents(this._last_position.X - position.X, this._last_position.Y - position.Y);
				}
				this._last_position = position;
				e2 = this.ToHMouse((int)this._last_position.X, (int)this._last_position.Y, e, 0);
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

		private System.Windows.Point GetPosition(MouseEventArgs e)
		{
			return e.GetPosition(this);
		}

		private void HWPFWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
			HSmartWindowControlWPF.HMouseEventArgsWPF e2 = null;
			try
			{
				if (this._delayed)
				{
					return;
				}
				this._left_button_down = (e.LeftButton == MouseButtonState.Pressed);
				this._last_position = this.GetPosition(e);
				if (this.InteractingWithDrawingObjs())
				{
					double d;
					double d2;
					this.ConvertWindowsCoordinatesToHImage(this._last_position.Y, this._last_position.X, out d, out d2);
					this._hwindow.SendMouseDownEvent(d, d2, this.MouseEventToInt(e));
				}
				e2 = this.ToHMouse((int)this._last_position.X, (int)this._last_position.Y, e, 0);
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

		private Rect Part2Rect()
		{
			HTuple hTuple;
			HTuple hTuple2;
			HTuple t;
			HTuple t2;
			this._hwindow.GetPart(out hTuple, out hTuple2, out t, out t2);
			return new Rect(hTuple2, hTuple, t2 - hTuple2 + 1, t - hTuple + 1);
		}

		public void SetFullImagePart(HImage reference = null)
		{
			if (base.ActualHeight == 0.0 || base.ActualWidth == 0.0)
			{
				return;
			}
			if (reference != null)
			{
				int num;
				int num2;
				reference.GetImageSize(out num, out num2);
				this.HImagePart = new Rect(0.0, 0.0, (double)(num - 1), (double)(num2 - 1));
				return;
			}
			if (this.HKeepAspectRatio)
			{
				this._hwindow.SetPart(0, 0, -2, -2);
				this.HImagePart = this.Part2Rect();
				return;
			}
			this._hwindow.SetPart(0, 0, -1, -1);
			this.HImagePart = this.Part2Rect();
		}

		private void HWPFWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			HSmartWindowControlWPF.HMouseEventArgsWPF e2 = null;
			try
			{
				bool flag = false;
				this._last_position = this.GetPosition(e);
				if (e.ChangedButton == MouseButton.Left && this.InteractingWithDrawingObjs())
				{
					double d;
					double d2;
					this.ConvertWindowsCoordinatesToHImage(this._last_position.Y, this._last_position.X, out d, out d2);
					flag = this._hwindow.SendMouseDoubleClickEvent(d, d2, this.MouseEventToInt(e))[0].Equals("true");
				}
				if (!flag && this.HDoubleClickToFitContent)
				{
					this.SetFullImagePart(null);
				}
				e2 = this.ToHMouse((int)this._last_position.X, (int)this._last_position.Y, e, 0);
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

		private void HWPFWindow_MouseUp(object sender, MouseButtonEventArgs e)
		{
			HSmartWindowControlWPF.HMouseEventArgsWPF e2 = null;
			try
			{
				this._left_button_down = false;
				this._last_position = this.GetPosition(e);
				if (this.InteractingWithDrawingObjs())
				{
					double d;
					double d2;
					this.ConvertWindowsCoordinatesToHImage(this._last_position.Y, this._last_position.X, out d, out d2);
					this._hwindow.SendMouseUpEvent(d, d2, this.MouseEventToInt(e));
				}
				e2 = this.ToHMouse((int)this._last_position.X, (int)this._last_position.Y, e, 0);
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
				this.HImagePart = new Rect(hTuple7.TupleSelect(0), hTuple8.TupleSelect(0), hTuple7.TupleSelect(1) - hTuple7.TupleSelect(0) + 1, hTuple8.TupleSelect(1) - hTuple8.TupleSelect(0) + 1);
			}
			catch (SZXCArimException)
			{
				this.HImagePart = new Rect(hTuple2, hTuple, hTuple4 - hTuple2 + 1, hTuple3 - hTuple + 1);
				result = false;
			}
			return result;
		}

		private void HWPFWindow_MouseLeave(object sender, MouseEventArgs e)
		{
			this._left_button_down = false;
		}

		protected internal void OnPropertyChanged(string propertyname)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
			}
		}
	}
}
