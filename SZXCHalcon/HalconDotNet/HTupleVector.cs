using System;

namespace SZXCArimEngine
{
	public class HTupleVector : HVector
	{
		private HTuple mTuple;

		public HTuple T
		{
			get
			{
				base.AssertDimension(0);
				return this.mTuple;
			}
			set
			{
				base.AssertDimension(0);
				if (value == null)
				{
					throw new HVectorAccessException("Null tuple not allowed in vector");
				}
				this.mTuple.Dispose();
				this.mTuple = new HTuple(value);
			}
		}

		public new HTupleVector this[int index]
		{
			get
			{
				return (HTupleVector)base[index];
			}
			set
			{
				base[index] = value;
			}
		}

		public HTupleVector(int dimension) : base(dimension)
		{
			this.mTuple = ((dimension <= 0) ? new HTuple() : null);
		}

		public HTupleVector(HTuple tuple) : base(0)
		{
			if (tuple == null)
			{
				throw new HVectorAccessException("Null tuple not allowed in vector");
			}
			this.mTuple = new HTuple(tuple);
		}

		public HTupleVector(HTuple tuple, int blockSize) : base(1)
		{
			if (blockSize <= 0)
			{
				throw new HVectorAccessException("Invalid block size in vector constructor");
			}
			int num = 0;
			while ((double)num < Math.Ceiling((double)tuple.Length / (double)blockSize))
			{
				int i = num * blockSize;
				int i2 = Math.Min((num + 1) * blockSize, tuple.Length) - 1;
				this[num] = new HTupleVector(tuple.TupleSelectRange(i, i2));
				num++;
			}
		}

		public HTupleVector(HTupleVector vector) : base(vector)
		{
			if (this.mDimension <= 0)
			{
				this.mTuple = new HTuple(vector.mTuple);
			}
		}

		protected override HVector GetDefaultElement()
		{
			return new HTupleVector(this.mDimension - 1);
		}

		public new HTupleVector At(int index)
		{
			return (HTupleVector)base.At(index);
		}

		protected override bool EqualsImpl(HVector vector)
		{
			if (this.mDimension >= 1)
			{
				return base.EqualsImpl(vector);
			}
			return ((HTupleVector)vector).T.TupleEqual(this.T);
		}

		public bool VectorEqual(HTupleVector vector)
		{
			return this.EqualsImpl(vector);
		}

		public HTupleVector Concat(HTupleVector vector)
		{
			return (HTupleVector)base.ConcatImpl(vector, false, true);
		}

		public HTupleVector Append(HTupleVector vector)
		{
			return (HTupleVector)base.ConcatImpl(vector, true, true);
		}

		public HTupleVector Insert(int index, HTupleVector vector)
		{
			base.InsertImpl(index, vector, true);
			return this;
		}

		public new HTupleVector Remove(int index)
		{
			base.RemoveImpl(index);
			return this;
		}

		public new HTupleVector Clear()
		{
			this.ClearImpl();
			return this;
		}

		public new HTupleVector Clone()
		{
			return (HTupleVector)this.CloneImpl();
		}

		protected override HVector CloneImpl()
		{
			return new HTupleVector(this);
		}

		protected override void DisposeLeafObject()
		{
			if (this.mDimension <= 0)
			{
				this.mTuple.Dispose();
			}
		}

		public HTuple ConvertVectorToTuple()
		{
			if (this.mDimension > 0)
			{
				HTuple hTuple = new HTuple();
				for (int i = 0; i < base.Length; i++)
				{
					hTuple.Append(this[i].ConvertVectorToTuple());
				}
				return hTuple;
			}
			return this.mTuple;
		}

		public override string ToString()
		{
			if (this.mDimension <= 0)
			{
				return this.mTuple.ToString();
			}
			return base.ToString();
		}
	}
}
