using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SZXCArimEngine
{
	internal class HTupleInt32 : HTupleImplementation
	{
		protected int[] i;

		public override int[] IArr
		{
			get
			{
				return this.i;
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
				return HTupleType.INTEGER;
			}
		}

		protected override Array CreateArray(int size)
		{
			return new int[size];
		}

		protected override void NotifyArrayUpdate()
		{
			this.i = (int[])this.data;
		}

		internal override void PinTuple()
		{
			Monitor.Enter(this);
			if (this.pinCount == 0)
			{
				this.pinHandle = GCHandle.Alloc(this.i, GCHandleType.Pinned);
			}
			this.pinCount++;
			Monitor.Exit(this);
		}

		public HTupleInt32(int i)
		{
			base.SetArray(new int[]
			{
				i
			}, false);
		}

		public HTupleInt32(int[] i, bool copy)
		{
			base.SetArray(i, copy);
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
			new HTupleElementsInt32(this, indices).setI(elements.IArr);
		}

		public override int[] ToIArr()
		{
			return (int[])base.ToArray(this.typeI);
		}

		public override long[] ToLArr()
		{
			return (long[])base.ToArray(this.typeL);
		}

		public override double[] ToDArr()
		{
			return (double[])base.ToArray(this.typeD);
		}

		public override float[] ToFArr()
		{
			return (float[])base.ToArray(this.typeF);
		}

		public override IntPtr[] ToIPArr()
		{
			if (SZXCArimAPI.isPlatform64)
			{
				base.ToIPArr();
			}
			IntPtr[] array = new IntPtr[this.iLength];
			for (int i = 0; i < this.iLength; i++)
			{
				array[i] = new IntPtr(this.i[i]);
			}
			return array;
		}

		public override int CopyToIArr(int[] dst, int offset)
		{
			Array.Copy(this.data, 0, dst, offset, this.iLength);
			return this.iLength;
		}

		public override int CopyToOArr(object[] dst, int offset)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				dst[i + offset] = this.i[i];
			}
			return this.iLength;
		}

		public override int CopyFrom(HTupleImplementation impl, int offset)
		{
			return impl.CopyToIArr(this.i, offset);
		}

		public override void Store(IntPtr proc, int parIndex)
		{
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.GetInputTuple(proc, parIndex, out tuple));
			this.StoreData(proc, tuple);
		}

		protected override void StoreData(IntPtr proc, IntPtr tuple)
		{
			this.PinTuple();
			if (SZXCArimAPI.isPlatform64)
			{
				SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateElementsOfType(tuple, base.Length, HTupleType.INTEGER));
				for (int i = 0; i < base.Length; i++)
				{
					SZXCArimAPI.SetI(tuple, i, this.i[i]);
				}
				return;
			}
			SZXCArimAPI.SetIArrPtr(tuple, this.i, this.iLength);
		}

		public static int Load(IntPtr tuple, out HTupleInt32 data)
		{
			int num;
			SZXCArimAPI.GetTupleLength(tuple, out num);
			int[] intArray = new int[num];
			int arg_20_0 = SZXCArimAPI.GetIArr(tuple, intArray);
			data = new HTupleInt32(intArray, false);
			return arg_20_0;
		}
	}
}
