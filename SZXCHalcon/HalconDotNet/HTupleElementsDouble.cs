using System;

namespace SZXCArimEngine
{
	internal class HTupleElementsDouble : HTupleElementsImplementation
	{
		internal HTupleElementsDouble(HTupleDouble source, int index) : base(source, index)
		{
		}

		internal HTupleElementsDouble(HTupleDouble source, int[] indices) : base(source, indices)
		{
		}

		public override double[] getD()
		{
			if (this.indices == null)
			{
				return null;
			}
			double[] array = new double[this.indices.Length];
			for (int i = 0; i < this.indices.Length; i++)
			{
				array[i] = this.source.DArr[this.indices[i]];
			}
			return array;
		}

		public override void setD(double[] d)
		{
			if (!base.IsValidArrayForSetX(d))
			{
				return;
			}
			bool flag = d.Length == 1;
			for (int i = 0; i < this.indices.Length; i++)
			{
				this.source.DArr[this.indices[i]] = d[flag ? 0 : i];
			}
		}

		public override object[] getO()
		{
			if (this.indices == null)
			{
				return null;
			}
			object[] array = new object[this.indices.Length];
			for (int i = 0; i < this.indices.Length; i++)
			{
				array[i] = this.source.DArr[this.indices[i]];
			}
			return array;
		}

		public override HTupleType getType()
		{
			return HTupleType.DOUBLE;
		}
	}
}
