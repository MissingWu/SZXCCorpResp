using System;
using System.Windows.Input;

namespace SZXCArimEngine
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
}
