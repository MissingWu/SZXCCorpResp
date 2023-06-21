using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SZXCArimEngine
{
	internal class HTupleInt64 : HTupleImplementation
	{
		protected long[] l;

		public override long[] LArr
		{
			get
			{
				return this.l;
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
				return HTupleType.LONG;
			}
		}

		protected override Array CreateArray(int size)
		{
			return new long[size];
		}

		protected override void NotifyArrayUpdate()
		{
			this.l = (long[])this.data;
		}

		internal override void PinTuple()
		{
			Monitor.Enter(this);
			if (this.pinCount == 0)
			{
				this.pinHandle = GCHandle.Alloc(this.l, GCHandleType.Pinned);
			}
			this.pinCount++;
			Monitor.Exit(this);
		}

		public HTupleInt64(long l)
		{
			base.SetArray(new long[]
			{
				l
			}, false);
		}

		public HTupleInt64(long[] l, bool copy)
		{
			base.SetArray(l, copy);
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
			new HTupleElementsInt64(this, indices).setL(elements.LArr);
		}

		public override int[] ToIArr()
		{
			int[] array = new int[this.iLength];
			for (int i = 0; i < this.iLength; i++)
			{
				array[i] = (int)this.l[i];
			}
			return array;
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
			if (!SZXCArimAPI.isPlatform64)
			{
				base.ToIPArr();
			}
			IntPtr[] array = new IntPtr[this.iLength];
			for (int i = 0; i < this.iLength; i++)
			{
				array[i] = new IntPtr(this.l[i]);
			}
			return array;
		}

		public override int CopyToLArr(long[] dst, int offset)
		{
			Array.Copy(this.l, 0, dst, offset, this.iLength);
			return this.iLength;
		}

		public override int CopyToOArr(object[] dst, int offset)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				dst[i + offset] = this.l[i];
			}
			return this.iLength;
		}

		public override int CopyFrom(HTupleImplementation impl, int offset)
		{
			return impl.CopyToLArr(this.l, offset);
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
			if (!SZXCArimAPI.isPlatform64)
			{
				SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateElementsOfType(tuple, base.Length, HTupleType.INTEGER));
				for (int i = 0; i < base.Length; i++)
				{
					SZXCArimAPI.SetL(tuple, i, this.l[i]);
				}
				return;
			}
			SZXCArimAPI.SetLArrPtr(tuple, this.l, this.iLength);
		}

		public static int Load(IntPtr tuple, out HTupleInt64 data)
		{
			int num;
			SZXCArimAPI.GetTupleLength(tuple, out num);
			long[] longArray = new long[num];
			int arg_20_0 = SZXCArimAPI.GetLArr(tuple, longArray);
			data = new HTupleInt64(longArray, false);
			return arg_20_0;
		}
	}
}
