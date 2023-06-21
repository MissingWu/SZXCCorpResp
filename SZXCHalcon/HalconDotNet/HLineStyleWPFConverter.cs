using System;
using System.ComponentModel;
using System.Globalization;

namespace SZXCArimEngine
{
	internal class HLineStyleWPFConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			string text = value as string;
			if (text != null)
			{
				return HLineStyleWPF.Parse(text);
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
