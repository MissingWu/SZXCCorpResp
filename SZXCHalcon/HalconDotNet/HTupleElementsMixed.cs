using System;

namespace SZXCArimEngine
{
	internal class HTupleElementsMixed : HTupleElementsImplementation
	{
		internal HTupleElementsMixed(HTupleMixed source, int index) : base(source, index)
		{
		}

		internal HTupleElementsMixed(HTupleMixed source, int[] indices) : base(source, indices)
		{
		}

		public override int[] getI()
		{
			if (this.indices == null)
			{
				return null;
			}
			HTupleType type = this.getType();
			if (type == HTupleType.INTEGER)
			{
				int[] array = new int[this.indices.Length];
				for (int i = 0; i < this.indices.Length; i++)
				{
					array[i] = (int)this.source.OArr[this.indices[i]];
				}
				return array;
			}
			if (type == HTupleType.LONG)
			{
				int[] array2 = new int[this.indices.Length];
				for (int j = 0; j < this.indices.Length; j++)
				{
					array2[j] = (int)((long)this.source.OArr[this.indices[j]]);
				}
				return array2;
			}
			if (type == HTupleType.HANDLE)
			{
				int[] array3 = new int[this.indices.Length];
				for (int k = 0; k < this.indices.Length; k++)
				{
					if (!SZXCArimAPI.IsLegacyHandleMode())
					{
						throw new HTupleAccessException("Implicit access to handle as number is only allowed in legacy handle mode. Use *.H.Handle to get IntPtr value.");
					}
					if (SZXCArimAPI.isPlatform64)
					{
						throw new HTupleAccessException("System.Int32 cannot represent a handle on this platform");
					}
					array3[k] = (int)((HHandle)this.source.OArr[this.indices[k]]).Handle;
					((HHandle)this.source.OArr[this.indices[k]]).Detach();
				}
				return array3;
			}
			throw new HTupleAccessException(this.source, "Mixed tuple does not contain integer " + ((this.indices.Length == 1) ? ("value at index " + this.indices[0]) : "values at given indices"));
		}

		public override long[] getL()
		{
			if (this.indices == null)
			{
				return null;
			}
			HTupleType type = this.getType();
			if (type == HTupleType.INTEGER)
			{
				long[] array = new long[this.indices.Length];
				for (int i = 0; i < this.indices.Length; i++)
				{
					array[i] = (long)((int)this.source.OArr[this.indices[i]]);
				}
				return array;
			}
			if (type == HTupleType.LONG)
			{
				long[] array2 = new long[this.indices.Length];
				for (int j = 0; j < this.indices.Length; j++)
				{
					array2[j] = (long)this.source.OArr[this.indices[j]];
				}
				return array2;
			}
			if (type == HTupleType.HANDLE)
			{
				long[] array3 = new long[this.indices.Length];
				for (int k = 0; k < this.indices.Length; k++)
				{
					if (!SZXCArimAPI.IsLegacyHandleMode())
					{
						throw new HTupleAccessException("Implicit access to handle as number is only allowed in legacy handle mode. Use *.H.Handle to get IntPtr value.");
					}
					array3[k] = (long)((HHandle)this.source.OArr[this.indices[k]]).Handle;
					((HHandle)this.source.OArr[this.indices[k]]).Detach();
				}
				return array3;
			}
			throw new HTupleAccessException(this.source, "Mixed tuple does not contain integer " + ((this.indices.Length == 1) ? ("value at index " + this.indices[0]) : "values at given indices"));
		}

		public override double[] getD()
		{
			if (this.indices == null)
			{
				return null;
			}
			HTupleType type = this.getType();
			if (type == HTupleType.DOUBLE)
			{
				double[] array = new double[this.indices.Length];
				for (int i = 0; i < this.indices.Length; i++)
				{
					array[i] = (double)this.source.OArr[this.indices[i]];
				}
				return array;
			}
			if (type == HTupleType.INTEGER)
			{
				double[] array2 = new double[this.indices.Length];
				for (int j = 0; j < this.indices.Length; j++)
				{
					array2[j] = (double)((int)this.source.OArr[this.indices[j]]);
				}
				return array2;
			}
			if (type == HTupleType.LONG)
			{
				double[] array3 = new double[this.indices.Length];
				for (int k = 0; k < this.indices.Length; k++)
				{
					array3[k] = (double)((long)this.source.OArr[this.indices[k]]);
				}
				return array3;
			}
			throw new HTupleAccessException(this.source, "Mixed tuple does not contain numeric " + ((this.indices.Length == 1) ? ("value at index " + this.indices[0]) : "values at given indices"));
		}

		public override string[] getS()
		{
			if (this.indices == null)
			{
				return null;
			}
			if (this.getType() == HTupleType.STRING)
			{
				string[] array = new string[this.indices.Length];
				for (int i = 0; i < this.indices.Length; i++)
				{
					array[i] = (string)this.source.OArr[this.indices[i]];
				}
				return array;
			}
			throw new HTupleAccessException(this.source, "Mixed tuple does not contain string " + ((this.indices.Length == 1) ? ("value at index " + this.indices[0]) : "values at given indices"));
		}

		public override HHandle[] getH()
		{
			if (this.indices == null)
			{
				return null;
			}
			if (this.getType() == HTupleType.HANDLE)
			{
				HHandle[] array = new HHandle[this.indices.Length];
				for (int i = 0; i < this.indices.Length; i++)
				{
					array[i] = (HHandle)this.source.OArr[this.indices[i]];
				}
				return array;
			}
			throw new HTupleAccessException(this.source, "Mixed tuple does not contain handle " + ((this.indices.Length == 1) ? ("value at index " + this.indices[0]) : "values at given indices"));
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
				array[i] = this.source.OArr[this.indices[i]];
			}
			return array;
		}

		protected void DisposeElement(int index)
		{
			IDisposable disposable = this.source.OArr[index] as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
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
				this.DisposeElement(this.indices[j]);
				this.source.OArr[this.indices[j]] = i[flag ? 0 : j];
			}
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
				this.DisposeElement(this.indices[i]);
				this.source.OArr[this.indices[i]] = l[flag ? 0 : i];
			}
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
				this.DisposeElement(this.indices[i]);
				this.source.OArr[this.indices[i]] = d[flag ? 0 : i];
			}
		}

		public override void setS(string[] s)
		{
			if (!base.IsValidArrayForSetX(s))
			{
				return;
			}
			bool flag = s.Length == 1;
			for (int i = 0; i < this.indices.Length; i++)
			{
				this.DisposeElement(this.indices[i]);
				this.source.OArr[this.indices[i]] = s[flag ? 0 : i];
			}
		}

		public override void Dispose()
		{
			GC.SuppressFinalize(this);
			GC.KeepAlive(this);
		}

		public override void setH(HHandle[] h)
		{
			if (!base.IsValidArrayForSetX(h))
			{
				return;
			}
			bool flag = h.Length == 1;
			for (int i = 0; i < this.indices.Length; i++)
			{
				this.DisposeElement(this.indices[i]);
				this.source.OArr[this.indices[i]] = new HHandle(h[flag ? 0 : i]);
			}
		}

		public override void setO(object[] o)
		{
			if (!base.IsValidArrayForSetX(o))
			{
				return;
			}
			bool flag = o.Length == 1;
			for (int i = 0; i < this.indices.Length; i++)
			{
				this.DisposeElement(this.indices[i]);
				object obj = o[flag ? 0 : i];
				if (HTupleImplementation.GetObjectType(obj) == 16)
				{
					obj = new HHandle((HHandle)obj);
				}
				this.source.OArr[this.indices[i]] = obj;
			}
		}

		public override HTupleType getType()
		{
			return ((HTupleMixed)this.source).GetElementType(this.indices);
		}
	}
}
