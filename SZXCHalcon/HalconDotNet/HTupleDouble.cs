using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SZXCArimEngine
{
	internal class HTupleDouble : HTupleImplementation
	{
		protected double[] d;

		public override double[] DArr
		{
			get
			{
				return this.d;
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
				return HTupleType.DOUBLE;
			}
		}

		protected override Array CreateArray(int size)
		{
			return new double[size];
		}

		protected override void NotifyArrayUpdate()
		{
			this.d = (double[])this.data;
		}

		public HTupleDouble(double d)
		{
			base.SetArray(new double[]
			{
				d
			}, false);
		}

		public HTupleDouble(double[] d, bool copy)
		{
			base.SetArray(d, copy);
		}

		public HTupleDouble(float[] f)
		{
			base.SetArray(f, true);
		}

		internal override void PinTuple()
		{
			Monitor.Enter(this);
			if (this.pinCount == 0)
			{
				this.pinHandle = GCHandle.Alloc(this.d, GCHandleType.Pinned);
			}
			this.pinCount++;
			Monitor.Exit(this);
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
			new HTupleElementsDouble(this, indices).setD(elements.DArr);
		}

		public override double[] ToDArr()
		{
			return (double[])base.ToArray(this.typeD);
		}

		public override float[] ToFArr()
		{
			float[] array = new float[this.iLength];
			for (int i = 0; i < this.iLength; i++)
			{
				array[i] = (float)this.d[i];
			}
			return array;
		}

		public override int CopyToDArr(double[] dst, int offset)
		{
			Array.Copy(this.d, 0, dst, offset, this.iLength);
			return this.iLength;
		}

		public override int CopyToOArr(object[] dst, int offset)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				dst[i + offset] = this.d[i];
			}
			return this.iLength;
		}

		public override int CopyFrom(HTupleImplementation impl, int offset)
		{
			return impl.CopyToDArr(this.d, offset);
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
			SZXCArimAPI.SetDArrPtr(tuple, this.d, this.iLength);
		}

		public static int Load(IntPtr tuple, out HTupleDouble data)
		{
			int num;
			SZXCArimAPI.GetTupleLength(tuple, out num);
			double[] doubleArray = new double[num];
			int arg_20_0 = SZXCArimAPI.GetDArr(tuple, doubleArray);
			data = new HTupleDouble(doubleArray, false);
			return arg_20_0;
		}
	}
}
