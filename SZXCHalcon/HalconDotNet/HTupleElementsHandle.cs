using System;

namespace SZXCArimEngine
{
	internal class HTupleElementsHandle : HTupleElementsImplementation
	{
		internal HTupleElementsHandle(HTupleHandle source, int index) : base(source, index)
		{
		}

		internal HTupleElementsHandle(HTupleHandle source, int[] indices) : base(source, indices)
		{
		}

		public override HHandle[] getH()
		{
			if (this.indices == null)
			{
				return null;
			}
			HHandle[] array = new HHandle[this.indices.Length];
			for (int i = 0; i < this.indices.Length; i++)
			{
				array[i] = this.source.HArr[this.indices[i]];
			}
			return array;
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
				if (!SZXCArimAPI.IsLegacyHandleMode())
				{
					throw new HTupleAccessException("Implicit access to handle as number is only allowed in legacy handle mode. Use *.H.Handle to get IntPtr value.");
				}
				if (SZXCArimAPI.isPlatform64)
				{
					throw new HTupleAccessException("System.Int32 cannot represent a handle on this platform");
				}
				array[i] = (int)this.source.HArr[this.indices[i]].Handle;
				this.source.HArr[this.indices[i]].Detach();
			}
			return array;
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
				if (!SZXCArimAPI.IsLegacyHandleMode())
				{
					throw new HTupleAccessException("Implicit access to handle as number is only allowed in legacy handle mode. Use *.H.Handle to get IntPtr value.");
				}
				array[i] = (long)this.source.HArr[this.indices[i]].Handle;
				this.source.HArr[this.indices[i]].Detach();
			}
			return array;
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
				if (this.source.HArr[this.indices[i]] != null)
				{
					this.source.HArr[this.indices[i]].Dispose();
				}
				this.source.HArr[this.indices[i]] = new HHandle(h[flag ? 0 : i]);
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
				array[i] = this.source.HArr[this.indices[i]];
			}
			return array;
		}

		public override HTupleType getType()
		{
			return HTupleType.HANDLE;
		}
	}
}
