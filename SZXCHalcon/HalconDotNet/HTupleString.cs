using System;

namespace SZXCArimEngine
{
	internal class HTupleString : HTupleImplementation
	{
		protected string[] s;

		public override string[] SArr
		{
			get
			{
				return this.s;
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
				return HTupleType.STRING;
			}
		}

		protected override Array CreateArray(int size)
		{
			string[] array = new string[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "";
			}
			return array;
		}

		protected override void NotifyArrayUpdate()
		{
			this.s = (string[])this.data;
		}

		public HTupleString(string s)
		{
			base.SetArray(new string[]
			{
				s
			}, false);
		}

		public HTupleString(string[] s, bool copy)
		{
			base.SetArray(s, copy);
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
			new HTupleElementsString(this, indices).setS(elements.SArr);
		}

		public override string[] ToSArr()
		{
			return (string[])base.ToArray(this.typeS);
		}

		public override int CopyToSArr(string[] dst, int offset)
		{
			Array.Copy(this.s, 0, dst, offset, this.iLength);
			return this.iLength;
		}

		public override int CopyToOArr(object[] dst, int offset)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				dst[i + offset] = this.s[i];
			}
			return this.iLength;
		}

		public override int CopyFrom(HTupleImplementation impl, int offset)
		{
			return impl.CopyToSArr(this.s, offset);
		}

		protected override void StoreData(IntPtr proc, IntPtr tuple)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetS(tuple, i, this.s[i], false));
			}
		}

		public static int Load(IntPtr tuple, out HTupleString data, bool force_utf8)
		{
			int num = 2;
			int num2;
			SZXCArimAPI.GetTupleLength(tuple, out num2);
			string[] array = new string[num2];
			for (int i = 0; i < num2; i++)
			{
				if (!SZXCArimAPI.IsFailure(num))
				{
					num = SZXCArimAPI.GetS(tuple, i, out array[i], force_utf8);
				}
			}
			data = new HTupleString(array, false);
			return num;
		}
	}
}
