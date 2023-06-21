using System;
using System.ComponentModel;
using System.Windows;

namespace SZXCArimEngine
{
	public class HMessageDisplayObjectWPF : HDisplayObjectWPF
	{
		public static readonly DependencyProperty HFontProperty = DependencyProperty.Register("HFont", typeof(string), typeof(HMessageDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HMessageDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty MessageTextProperty = DependencyProperty.Register("HMessageText", typeof(string), typeof(HMessageDisplayObjectWPF), new PropertyMetadata(null, new PropertyChangedCallback(HMessageDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty CoordinateSystemProperty = DependencyProperty.Register("HCoordinateSystem", typeof(string), typeof(HMessageDisplayObjectWPF), new PropertyMetadata("window", new PropertyChangedCallback(HMessageDisplayObjectWPF.OnPropertyChanged)));

		private HTuple _row = new HTuple("top");

		public static readonly DependencyProperty RowProperty = DependencyProperty.Register("HRow", typeof(string), typeof(HMessageDisplayObjectWPF), new PropertyMetadata("top", new PropertyChangedCallback(HMessageDisplayObjectWPF.OnPropertyChanged)));

		private HTuple _column = new HTuple("left");

		public static readonly DependencyProperty ColProperty = DependencyProperty.Register("HColumn", typeof(string), typeof(HMessageDisplayObjectWPF), new PropertyMetadata("left", new PropertyChangedCallback(HMessageDisplayObjectWPF.OnPropertyChanged)));

		public static readonly DependencyProperty HColorProperty = DependencyProperty.Register("HColor", typeof(string), typeof(HMessageDisplayObjectWPF), new PropertyMetadata("black"));

		private string _tmpFont;

		[Category("Appearance"), Description("Font of the displayes message."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HFont
		{
			get
			{
				return (string)base.GetValue(HMessageDisplayObjectWPF.HFontProperty);
			}
			set
			{
				base.SetValue(HMessageDisplayObjectWPF.HFontProperty, value);
			}
		}

		[Category("Appearance"), Description("Text to display in the message."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HMessageText
		{
			get
			{
				return (string)base.GetValue(HMessageDisplayObjectWPF.MessageTextProperty);
			}
			set
			{
				base.SetValue(HMessageDisplayObjectWPF.MessageTextProperty, value);
			}
		}

		[Category("Appearance"), Description("Coordinate system for the HRow and HColumn properties. Can either be 'window' or 'image'."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HCoordinateSystem
		{
			get
			{
				return (string)base.GetValue(HMessageDisplayObjectWPF.CoordinateSystemProperty);
			}
			set
			{
				base.SetValue(HMessageDisplayObjectWPF.CoordinateSystemProperty, value);
			}
		}

		[Category("Appearance"), Description("Row coordinate of the message. Can either be 'top', 'middle', 'bottom' or a double or an int"), EditorBrowsable(EditorBrowsableState.Always)]
		public string HRow
		{
			get
			{
				return (string)base.GetValue(HMessageDisplayObjectWPF.RowProperty);
			}
			set
			{
				base.SetValue(HMessageDisplayObjectWPF.RowProperty, value);
			}
		}

		[Category("Appearance"), Description("HColumn coordinate of the message. Can either be 'left', 'center', 'right' or a double or an int"), EditorBrowsable(EditorBrowsableState.Always)]
		public string HColumn
		{
			get
			{
				return (string)base.GetValue(HMessageDisplayObjectWPF.ColProperty);
			}
			set
			{
				base.SetValue(HMessageDisplayObjectWPF.ColProperty, value);
			}
		}

		[Category("Appearance"), Description("Color of the text to display in the message."), EditorBrowsable(EditorBrowsableState.Always)]
		public string HColor
		{
			get
			{
				return (string)base.GetValue(HMessageDisplayObjectWPF.HColorProperty);
			}
			set
			{
				base.SetValue(HMessageDisplayObjectWPF.HColorProperty, value);
			}
		}

		public HMessageDisplayObjectWPF(HTuple msg)
		{
			this.HMessageText = msg;
		}

		public HMessageDisplayObjectWPF()
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				this.disposed = true;
			}
		}

		private static void OnPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
		{
			HMessageDisplayObjectWPF hMessageDisplayObjectWPF = source as HMessageDisplayObjectWPF;
			if (hMessageDisplayObjectWPF == null)
			{
				return;
			}
			string name = e.Property.Name;
			double d;
			if (!(name == "HRow"))
			{
				if (name == "HColumn")
				{
					if (double.TryParse((string)e.NewValue, out d))
					{
						hMessageDisplayObjectWPF._column = new HTuple(d);
					}
					else
					{
						hMessageDisplayObjectWPF._column = new HTuple((string)e.NewValue);
					}
				}
			}
			else if (double.TryParse((string)e.NewValue, out d))
			{
				hMessageDisplayObjectWPF._row = new HTuple(d);
			}
			else
			{
				hMessageDisplayObjectWPF._row = new HTuple((string)e.NewValue);
			}
			HSmartWindowControlWPF parentHSmartWindowControlWPF = hMessageDisplayObjectWPF.ParentHSmartWindowControlWPF;
			if (parentHSmartWindowControlWPF != null)
			{
				parentHSmartWindowControlWPF.NotifyItemsChanged();
			}
		}

		public override void Display(HWindow hWindow)
		{
			if (this.HMessageText != null)
			{
				if (this.HFont != null)
				{
					this._tmpFont = hWindow.GetFont();
					hWindow.SetFont(this.HFont);
				}
				hWindow.DispText(new HTuple(this.HMessageText), this.HCoordinateSystem, this._row, this._column, new HTuple(this.HColor), new HTuple(), new HTuple());
				if (this.HFont != null)
				{
					hWindow.SetFont(this._tmpFont);
				}
			}
		}
	}
}
