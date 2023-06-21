using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[TypeConverter(typeof(HLineStyleWPFConverter))]
	public class HLineStyleWPF
	{
		public int Visible
		{
			get;
			set;
		}

		public int Invisible
		{
			get;
			set;
		}

		public HLineStyleWPF()
		{
		}

		public HLineStyleWPF(int visible, int invisible)
		{
			this.Visible = visible;
			this.Invisible = invisible;
		}

		public static HLineStyleWPF Parse(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return new HLineStyleWPF();
			}
			string[] array = str.Split(new char[]
			{
				' '
			});
			if (array.Length > 2)
			{
				throw new FormatException(string.Format("Cannot parse '{0}' into a HLineStyleWPF object because it is not in the \"<visible> (<invisible>)\" format.", str));
			}
			if (array.Length == 2)
			{
				return new HLineStyleWPF(int.Parse(array[0].Trim()), int.Parse(array[1].Trim()));
			}
			return new HLineStyleWPF(int.Parse(array[0].Trim()), int.Parse(array[0].Trim()));
		}

		public static implicit operator HTuple(HLineStyleWPF ls)
		{
			return new HTuple(new int[]
			{
				ls.Visible,
				ls.Invisible
			});
		}
	}
}
