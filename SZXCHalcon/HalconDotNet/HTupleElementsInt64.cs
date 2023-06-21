using System;

namespace SZXCArimEngine
{
	internal class HTupleElementsInt64 : HTupleElementsImplementation
	{
		internal HTupleElementsInt64(HTupleInt64 source, int index) : base(source, index)
		{
		}

		internal HTupleElementsInt64(HTupleInt64 source, int[] indices) : base(source, indices)
		{
		}

		public override int[] getI()
		{
			if (this.indices == null)
			{
				return null;
			}
			int[] array = new int[this.indices.Length];
			for (int i = 0; i < this.indices.Length; i++)
			{
				array[i] = (int)this.source.LArr[this.indices[i]];
			}
			return array;
		}

		public override void setI(int[] i)
		{
			if (!base.IsValidArrayForSetX(i))
			{
				return;
			}
			bool flag = i.Length == 1;
			for (int j = 0; j < this.indices.Length; j++)
			{
				this.source.LArr[this.indices[j]] = (long)i[flag ? 0 : j];
			}
		}

		public override long[] getL()
		{
			if (this.indices == null)
			{
				return null;
			}
			long[] array = new long[this.indices.Length];
			for (int i = 0; i < this.indices.Length; i++)
			{
				array[i] = this.source.LArr[this.indices[i]];
			}
			return array;
		}

		public override void setL(long[] l)
		{
			if (!base.IsValidArrayForSetX(l))
			{
				return;
			}
			bool flag = l.Length == 1;
			for (int i = 0; i < this.indices.Length; i++)
			{
				this.source.LArr[this.indices[i]] = l[flag ? 0 : i];
			}
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
				array[i] = (double)this.source.LArr[this.indices[i]];
			}
			return array;
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
				array[i] = this.source.LArr[this.indices[i]];
			}
			return array;
		}

		public override HTupleType getType()
		{
			return HTupleType.LONG;
		}
	}
}
