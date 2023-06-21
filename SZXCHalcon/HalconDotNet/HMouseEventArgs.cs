using System;
using System.Windows.Forms;

namespace SZXCArimEngine
{
	public class HMouseEventArgs : EventArgs
	{
		private readonly MouseButtons button;

		private readonly int clicks;

		private readonly double x;

		private readonly double y;

		private readonly int delta;

		public MouseButtons Button
		{
			get
			{
				return this.button;
			}
		}

		public int Clicks
		{
			get
			{
				return this.clicks;
			}
		}

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

		public int Delta
		{
			get
			{
				return this.delta;
			}
		}

		internal HMouseEventArgs(MouseButtons button, int clicks, double x, double y, int delta)
		{
			this.button = button;
			this.clicks = clicks;
			this.x = x;
			this.y = y;
			this.delta = delta;
		}
	}
}
