using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SZXCArimEngine
{
	[ToolboxBitmap(typeof(HWindowControlWPF), "HWindowControlWPF.icon.bmp")]
	public class HWindowControlWPF : UserControl, IDisposable
	{
		private Canvas windowCanvas;

		private HWindowWPF windowWPF;

		private HWindow window;

		private Rect imagePart = new Rect(0.0, 0.0, 640.0, 480.0);

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HInitWindowEventHandlerWPF HInitWindow;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandlerWPF HMouseMove;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandlerWPF HMouseDown;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandlerWPF HMouseUp;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HMouseEventHandlerWPF HMouseWheel;

		internal Canvas Container
		{
			get
			{
				return this.windowCanvas;
			}
		}

		public HWindow SZXCArimWindow
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

		public IntPtr SZXCArimID
		{
			get
			{
				if (this.window != null)
				{
					return this.window.Handle;
				}
				return HHandleBase.UNDEF;
			}
		}

		public Rect ImagePart
		{
			get
			{
				if (this.windowWPF != null && this.windowWPF.SZXCArimWindow != null)
				{
					int num;
					int num2;
					int num3;
					int num4;
					this.windowWPF.SZXCArimWindow.GetPart(out num, out num2, out num3, out num4);
					this.imagePart = new Rect((double)num2, (double)num, (double)(num4 - num2 + 1), (double)(num3 - num + 1));
				}
				return this.imagePart;
			}
			set
			{
				this.imagePart = new Rect((double)((int)value.Left), (double)((int)value.Top), (double)((int)value.Width), (double)((int)value.Height));
				this.UpdatePart();
			}
		}

		public HWindowControlWPF()
		{
			this.windowCanvas = new Canvas();
			this.windowCanvas.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
			this.windowCanvas.Background = System.Windows.Media.Brushes.Red;
			this.windowCanvas.Height = double.NaN;
			this.windowCanvas.Width = double.NaN;
			base.Content = this.windowCanvas;
			this.windowCanvas.Loaded += new RoutedEventHandler(this.windowCanvas_Loaded);
			this.windowCanvas.SizeChanged += new SizeChangedEventHandler(this.windowCanvas_SizeChanged);
			base.Width = double.NaN;
			base.Height = double.NaN;
			base.Background = System.Windows.Media.Brushes.LightGreen;
		}

		private void ApplyScalingFactor(Visual visual)
		{
			PresentationSource presentationSource = PresentationSource.FromVisual(visual);
			if (presentationSource != null)
			{
				Matrix transformToDevice = presentationSource.CompositionTarget.TransformToDevice;
				double m = transformToDevice.M11;
				double m2 = transformToDevice.M22;
				if (m != 0.0 && m != 0.0)
				{
					double scaleX = 1.0 / m;
					double scaleY = 1.0 / m2;
					this.windowCanvas.LayoutTransform = new ScaleTransform(scaleX, scaleY);
					this.windowCanvas.UpdateLayout();
				}
			}
		}

		private void windowCanvas_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.windowWPF != null)
			{
				return;
			}
			this.windowCanvas.Background = System.Windows.Media.Brushes.Black;
			if (base.IsVisible)
			{
				this.ApplyScalingFactor(this);
			}
			else
			{
				this.windowCanvas.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.windowCanvas_IsVisibleChanged);
			}
			if (!DesignerProperties.GetIsInDesignMode(this))
			{
				try
				{
					HObject hObject;
					HOperatorSet.GenEmptyObj(out hObject);
					hObject.Dispose();
					this.windowWPF = new HWindowWPF(this);
					this.windowWPF.HWButtonEvent += new HWButtonEventHandler(this.windowWPF_ButtonEvent);
					this.windowWPF.HWMouseEvent += new HWMouseEventHandler(this.windowWPF_MouseEvent);
					this.windowWPF.HWInitEvent += new HWInitEventHandler(this.windowWPF_InitEvent);
					this.windowCanvas.Children.Add(this.windowWPF);
				}
				catch (DllNotFoundException)
				{
				}
			}
		}

		private void windowCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (this.windowWPF != null)
			{
				try
				{
					this.windowWPF.SetWindowExtents((int)this.windowCanvas.ActualWidth, (int)this.windowCanvas.ActualHeight);
					if (HSystem.GetSystem(new HTuple("flush_graphic")).S == "true")
					{
						this.windowWPF.UpdateLayout();
					}
				}
				catch (HOperatorException)
				{
				}
			}
		}

		private void windowCanvas_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				this.ApplyScalingFactor(this);
				this.windowCanvas.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(this.windowCanvas_IsVisibleChanged);
			}
		}

		private void UpdatePart()
		{
			if (this.windowWPF == null || this.windowWPF.SZXCArimWindow == null)
			{
				return;
			}
			this.windowWPF.SZXCArimWindow.SetPart((int)this.imagePart.Top, (int)this.imagePart.Left, (int)(this.imagePart.Top + this.imagePart.Height - 1.0), (int)(this.imagePart.Left + this.imagePart.Width - 1.0));
		}

		public void SetFullImagePart(HImage reference)
		{
			string text;
			int num;
			int num2;
			reference.GetImagePointer1(out text, out num, out num2);
			this.imagePart = new Rect(0.0, 0.0, (double)num, (double)num2);
			this.UpdatePart();
		}

		public new bool Focus()
		{
			base.Focusable = true;
			this.windowWPF.SetNativeFocus();
			return true;
		}

		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		public virtual void Dispose()
		{
			if (this.windowWPF != null)
			{
				this.windowWPF.Dispose();
				this.windowWPF = null;
			}
		}

		protected virtual void OnHInitWindow()
		{
			if (this.HInitWindow != null)
			{
				this.HInitWindow(this, new EventArgs());
			}
		}

		protected virtual void OnHMouseMove(HMouseEventArgsWPF e)
		{
			if (this.HMouseMove != null)
			{
				this.HMouseMove(this, e);
			}
		}

		protected virtual void OnHMouseDown(HMouseEventArgsWPF e)
		{
			if (this.HMouseDown != null)
			{
				this.HMouseDown(this, e);
			}
		}

		protected virtual void OnHMouseUp(HMouseEventArgsWPF e)
		{
			if (this.HMouseUp != null)
			{
				this.HMouseUp(this, e);
			}
		}

		protected virtual void OnHMouseWheel(HMouseEventArgsWPF e)
		{
			if (this.HMouseWheel != null)
			{
				this.HMouseWheel(this, e);
			}
		}

		private HMouseEventArgsWPF ToHMouse(int x, int y, MouseButton? button, int delta)
		{
			double row;
			double column;
			if (this.window == null)
			{
				row = ((this.windowWPF == null) ? ((double)y) : (this.imagePart.Top + (double)y * this.imagePart.Height / this.windowWPF.Height));
				column = ((this.windowWPF == null) ? ((double)x) : (this.imagePart.Left + (double)x * this.imagePart.Width / this.windowWPF.Width));
			}
			else
			{
				this.window.ConvertCoordinatesWindowToImage((double)y, (double)x, out row, out column);
			}
			return new HMouseEventArgsWPF((double)x, (double)y, row, column, delta, button);
		}

		private void windowWPF_InitEvent()
		{
			this.window = this.windowWPF.SZXCArimWindow;
			this.UpdatePart();
			base.Focusable = true;
			this.OnHInitWindow();
		}

		private void windowWPF_ButtonEvent(int x, int y, MouseButton button, MouseButtonState state)
		{
			if (state == MouseButtonState.Released)
			{
				this.OnHMouseUp(this.ToHMouse(x, y, new MouseButton?(button), 0));
				return;
			}
			this.OnHMouseDown(this.ToHMouse(x, y, new MouseButton?(button), 0));
			if (base.Focusable)
			{
				this.windowWPF.SetNativeFocus();
			}
		}

		private void windowWPF_MouseEvent(int x, int y, MouseButton? button, int delta)
		{
			if (delta == 0)
			{
				this.OnHMouseMove(this.ToHMouse(x, y, button, 0));
				return;
			}
			this.OnHMouseWheel(this.ToHMouse(x, y, null, delta));
		}
	}
}
