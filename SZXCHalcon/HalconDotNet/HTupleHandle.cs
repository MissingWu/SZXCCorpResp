using System;

namespace SZXCArimEngine
{
	internal class HTupleHandle : HTupleImplementation
	{
		protected HHandle[] h;

		public override HHandle[] HArr
		{
			get
			{
				return this.h;
			}
			set
			{
				base.SetArray(value, false);
			}
		}

		public override HTupleType Type
		{
			get
			{
				return HTupleType.HANDLE;
			}
		}

		protected override Array CreateArray(int size)
		{
			HHandle[] array = new HHandle[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = new HHandle();
			}
			return array;
		}

		protected override void NotifyArrayUpdate()
		{
			this.h = (HHandle[])this.data;
		}

		public HTupleHandle(HHandle h)
		{
			base.SetArray(new HHandle[]
			{
				new HHandle(h)
			}, false);
		}

		public HTupleHandle(HHandle[] h, bool copy)
		{
			if (copy)
			{
				HHandle[] array = new HHandle[h.Length];
				for (int i = 0; i < h.Length; i++)
				{
					array[i] = new HHandle(h[i]);
				}
				base.SetArray(array, false);
				return;
			}
			base.SetArray(h, false);
		}

		public override HTupleElements GetElement(int index, HTuple parent)
		{
			return new HTupleElements(parent, this, index);
		}

		public override HTupleElements GetElements(int[] indices, HTuple parent)
		{
			if (indices == null || indices.Length == 0)
			{
				return new HTupleElements();
			}
			return new HTupleElements(parent, this, indices);
		}

		public override void SetElements(int[] indices, HTupleElements elements)
		{
			new HTupleElementsHandle(this, indices).setH(elements.HArr);
		}

		public override void Dispose()
		{
			for (int i = 0; i < base.Length; i++)
			{
				if (this.h[i] != null)
				{
					this.h[i].Dispose();
				}
			}
		}

		public override HHandle[] ToHArr()
		{
			HHandle[] array = new HHandle[this.iLength];
			this.CopyToHArr(array, 0);
			return array;
		}

		public override object[] ToOArr()
		{
			object[] array = new object[this.iLength];
			this.CopyToOArr(array, 0);
			return array;
		}

		public override int CopyToHArr(HHandle[] dst, int offset)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				dst[i + offset] = new HHandle(this.h[i]);
			}
			return this.iLength;
		}

		public override int CopyToOArr(object[] dst, int offset)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				dst[i + offset] = new HHandle(this.h[i]);
			}
			return this.iLength;
		}

		public override int CopyFrom(HTupleImplementation impl, int offset)
		{
			return impl.CopyToHArr(this.h, offset);
		}

		protected override void StoreData(IntPtr proc, IntPtr tuple)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetH(tuple, i, this.h[i]));
			}
		}

		public static int Load(IntPtr tuple, out HTupleHandle data)
		{
			int num = 2;
			int num2;
			SZXCArimAPI.GetTupleLength(tuple, out num2);
			HHandle[] array = new HHandle[num2];
			for (int i = 0; i < num2; i++)
			{
				if (!SZXCArimAPI.IsFailure(num))
				{
					num = SZXCArimAPI.GetH(tuple, i, out array[i]);
				}
			}
			data = new HTupleHandle(array, false);
			return num;
		}
	}
}
