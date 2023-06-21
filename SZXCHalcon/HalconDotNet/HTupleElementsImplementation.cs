using System;

namespace SZXCArimEngine
{
	internal class HTupleElementsImplementation
	{
		protected int[] indices;

		protected HTupleImplementation source;

		public int[] I
		{
			get
			{
				return this.getI();
			}
			set
			{
				this.source.AssertSize(this.indices);
				this.setI(value);
			}
		}

		public long[] L
		{
			get
			{
				return this.getL();
			}
			set
			{
				this.source.AssertSize(this.indices);
				this.setL(value);
			}
		}

		public double[] D
		{
			get
			{
				return this.getD();
			}
			set
			{
				this.source.AssertSize(this.indices);
				this.setD(value);
			}
		}

		public string[] S
		{
			get
			{
				return this.getS();
			}
			set
			{
				this.source.AssertSize(this.indices);
				this.setS(value);
			}
		}

		public HHandle[] H
		{
			get
			{
				return this.getH();
			}
			set
			{
				this.source.AssertSize(this.indices);
				this.setH(value);
			}
		}

		public object[] O
		{
			get
			{
				return this.getO();
			}
			set
			{
				this.source.AssertSize(this.indices);
				this.setO(value);
			}
		}

		public HTupleType Type
		{
			get
			{
				return this.getType();
			}
		}

		public int Length
		{
			get
			{
				return this.indices.Length;
			}
		}

		public HTupleElementsImplementation()
		{
			this.source = null;
			this.indices = new int[0];
		}

		public HTupleElementsImplementation(HTupleImplementation source, int index)
		{
			this.source = source;
			this.indices = new int[]
			{
				index
			};
		}

		public virtual void Dispose()
		{
		}

		public HTupleElementsImplementation(HTupleImplementation source, int[] indices)
		{
			this.source = source;
			this.indices = indices;
		}

		public int[] getIndices()
		{
			return this.indices;
		}

		public virtual int[] getI()
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual long[] getL()
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual double[] getD()
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual string[] getS()
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual HHandle[] getH()
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual object[] getO()
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual void setI(int[] i)
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual void setL(long[] l)
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual void setD(double[] d)
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual void setS(string[] s)
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual void setH(HHandle[] h)
		{
			throw new HTupleAccessException(this.source);
		}

		public virtual void setO(object[] o)
		{
			throw new HTupleAccessException(this.source);
		}

		protected bool IsValidArrayForSetX(Array a)
		{
			if (a == null)
			{
				return false;
			}
			if (a.Length != 1 && a.Length != this.indices.Length)
			{
				throw new HTupleAccessException(this.source, "Number of values must be one or match number of indexed elements");
			}
			return true;
		}

		public virtual HTupleType getType()
		{
			if (this.indices.Length == 0)
			{
				return HTupleType.EMPTY;
			}
			throw new HTupleAccessException(this.source);
		}
	}
}
