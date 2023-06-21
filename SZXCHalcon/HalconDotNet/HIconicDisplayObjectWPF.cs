using System;
using System.ComponentModel;
using System.Windows;

namespace SZXCArimEngine
{
	public class HIconicDisplayObjectWPF : HDisplayObjectWPF
	{
		public static readonly DependencyProperty IconicObjectProperty = DependencyProperty.Register("IconicObject", typeof(HObject), typeof(HIconicDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HIconicDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty HColorProperty = DependencyProperty.Register("HColor", typeof(string), typeof(HIconicDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HIconicDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty HColoredProperty = DependencyProperty.Register("HColored", typeof(int?), typeof(HIconicDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HIconicDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty HLineStyleProperty = DependencyProperty.Register("LineStyle", typeof(HLineStyleWPF), typeof(HIconicDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HIconicDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty HLineWidthProperty = DependencyProperty.Register("LineWidth", typeof(double?), typeof(HIconicDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HIconicDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty HDrawProperty = DependencyProperty.Register("HDraw", typeof(string), typeof(HIconicDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HIconicDisplayObjectWPF.OnPropertyChanged)));

		private HTuple _tempLineStyle;

		private HTuple _tempLineWidth;

		private HTuple _tempDraw;

		public HObject IconicObject
		{
			get
			{
				return (HObject)base.GetValue(HIconicDisplayObjectWPF.IconicObjectProperty);
			}
			set
			{
				base.SetValue(HIconicDisplayObjectWPF.IconicObjectProperty, value);
			}
		}

		[Category("Appearance"), Description("Color for displaying HRegion and HXLDCont objects. If HColor is set, HColored is set to null."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HColor
		{
			get
			{
				return (string)base.GetValue(HIconicDisplayObjectWPF.HColorProperty);
			}
			set
			{
				base.SetValue(HIconicDisplayObjectWPF.HColorProperty, value);
			}
		}

		[Category("Appearance"), Description("Set of colors for displaying HRegion and HXLDCont objects. If HColored is set, HColor is set to null."), EditorBrowsable(EditorBrowsableState.Always)]
		public int? HColored
		{
			get
			{
				return (int?)base.GetValue(HIconicDisplayObjectWPF.HColoredProperty);
			}
			set
			{
				base.SetValue(HIconicDisplayObjectWPF.HColoredProperty, value);
			}
		}

		[Category("Appearance"), Description("Output pattern of the margin of HRegion objects and of HXLDCont objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public HLineStyleWPF LineStyle
		{
			get
			{
				return (HLineStyleWPF)base.GetValue(HIconicDisplayObjectWPF.HLineStyleProperty);
			}
			set
			{
				base.SetValue(HIconicDisplayObjectWPF.HLineStyleProperty, value);
			}
		}

		[Category("Appearance"), Description("Line width of the margin of HRegion objects and of HXLDCont objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public double? LineWidth
		{
			get
			{
				return (double?)base.GetValue(HIconicDisplayObjectWPF.HLineWidthProperty);
			}
			set
			{
				base.SetValue(HIconicDisplayObjectWPF.HLineWidthProperty, value);
			}
		}

		[Category("Appearance"), Description("Fill mode of HRegion objects."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HDraw
		{
			get
			{
				return (string)base.GetValue(HIconicDisplayObjectWPF.HDrawProperty);
			}
			set
			{
				base.SetValue(HIconicDisplayObjectWPF.HDrawProperty, value);
			}
		}

		public HIconicDisplayObjectWPF(HObject obj)
		{
			this.IconicObject = obj;
		}

		public HIconicDisplayObjectWPF()
		{
		}

		private static void OnPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			HIconicDisplayObjectWPF hIconicDisplayObjectWPF = source as HIconicDisplayObjectWPF;
			if (hIconicDisplayObjectWPF == null)
			{
				return;
			}
			string name = e.Property.Name;
			if (!(name == "HColor"))
			{
				if (name == "HColored")
				{
					hIconicDisplayObjectWPF.HColor = null;
				}
			}
			else
			{
				hIconicDisplayObjectWPF.HColored = null;
			}
			HSmartWindowControlWPF parentHSmartWindowControlWPF = hIconicDisplayObjectWPF.ParentHSmartWindowControlWPF;
			if (parentHSmartWindowControlWPF != null)
			{
				parentHSmartWindowControlWPF.NotifyItemsChanged();
			}
		}

		public override void Display(HWindow hWindow)
		{
			if (this.IconicObject != null && this.IconicObject.IsInitialized())
			{
				if (this.HColor != null)
				{
					hWindow.SetColor(this.HColor);
				}
				if (this.HColored.HasValue)
				{
					hWindow.SetColored(this.HColored ?? 0);
				}
				if (this.HDraw != null)
				{
					this._tempDraw = hWindow.GetDraw();
					hWindow.SetDraw(this.HDraw);
				}
				if (this.LineStyle != null)
				{
					this._tempLineStyle = hWindow.GetLineStyle();
					hWindow.SetLineStyle(this.LineStyle);
				}
				if (this.LineWidth.HasValue)
				{
					this._tempLineWidth = hWindow.GetLineWidth();
					hWindow.SetLineWidth(this.LineWidth ?? 1.0);
				}
				this.IconicObject.DispObj(hWindow);
				if (this.LineStyle != null)
				{
					hWindow.SetLineStyle(this._tempLineStyle);
					this._tempLineStyle.Dispose();
				}
				if (this.LineWidth.HasValue)
				{
					hWindow.SetLineWidth(this._tempLineWidth);
					this._tempLineWidth.Dispose();
				}
				if (this.HDraw != null)
				{
					hWindow.SetDraw(this._tempDraw);
					this._tempDraw.Dispose();
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing && this.IconicObject != null)
				{
					this.IconicObject.Dispose();
				}
				this.disposed = true;
			}
		}
	}
}
