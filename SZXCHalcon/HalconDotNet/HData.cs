using System;

namespace SZXCArimEngine
{
	public class HData
	{
		internal HTuple tuple;

		public HTuple RawData
		{
			get
			{
				return this.tuple;
			}
			set
			{
				this.tuple = new HTuple(value);
			}
		}

		public HTupleElements this[int index]
		{
			get
			{
				return this.tuple[index];
			}
			set
			{
				this.tuple[index] = value;
			}
		}

		internal HData()
		{
			this.tuple = new HTuple();
		}

		internal HData(HTuple t)
		{
			this.tuple = t;
		}

		internal HData(HData data)
		{
			this.tuple = data.tuple;
		}

		internal static HTuple ConcatArray(HData[] data)
		{
			HTuple hTuple = new HTuple();
			for (int i = 0; i < data.Length; i++)
			{
				hTuple = hTuple.TupleConcat(data[i].tuple);
			}
			return hTuple;
		}

		internal void UnpinTuple()
		{
			this.tuple.UnpinTuple();
		}

		internal void Store(IntPtr proc, int parIndex)
		{
			this.tuple.Store(proc, parIndex);
		}

		internal int Load(IntPtr proc, int parIndex, int err)
		{
			return this.tuple.Load(proc, parIndex, err);
		}

		internal int Load(IntPtr proc, int parIndex, HTupleType type, int err)
		{
			return this.tuple.Load(proc, parIndex, type, err);
		}

		public static implicit operator HTuple(HData data)
		{
			return data.tuple;
		}
	}
}
