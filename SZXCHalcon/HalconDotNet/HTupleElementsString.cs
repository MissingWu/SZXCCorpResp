using System;

namespace SZXCArimEngine
{
	internal class HTupleElementsString : HTupleElementsImplementation
	{
		internal HTupleElementsString(HTupleString source, int index) : base(source, index)
		{
		}

		internal HTupleElementsString(HTupleString source, int[] indices) : base(source, indices)
		{
		}

		public override string[] getS()
		{
			if (this.indices == null)
			{
				return null;
			}
			string[] array = new string[this.indices.Length];
			for (int i = 0; i < this.indices.Length; i++)
			{
				array[i] = this.source.SArr[this.indices[i]];
			}
			return array;
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
				this.source.SArr[this.indices[i]] = s[flag ? 0 : i];
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
				array[i] = this.source.SArr[this.indices[i]];
			}
			return array;
		}

		public override HTupleType getType()
		{
			return HTupleType.STRING;
		}
	}
}
