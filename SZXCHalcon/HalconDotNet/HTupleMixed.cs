using System;

namespace SZXCArimEngine
{
	internal class HTupleMixed : HTupleImplementation
	{
		protected object[] o;

		public override object[] OArr
		{
			get
			{
				return this.o;
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
				return HTupleType.MIXED;
			}
		}

		protected override Array CreateArray(int size)
		{
			object[] array = new object[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = 0;
			}
			return array;
		}

		protected override void NotifyArrayUpdate()
		{
			this.o = (object[])this.data;
		}

		public HTupleMixed(HTupleImplementation data) : this(data.ToOArr(), false)
		{
		}

		public HTupleMixed(object o) : this(new object[]
		{
			o
		}, false)
		{
		}

		public HTupleMixed(object[] o, bool copy)
		{
			if (copy)
			{
				object[] array = new object[o.Length];
				for (int i = 0; i < o.Length; i++)
				{
					if (o[i] != null)
					{
						int objectType = HTupleImplementation.GetObjectType(o[i]);
						if (objectType == 31 || (objectType & 32768) > 0)
						{
							throw new HTupleAccessException("Encountered invalid data types when creating HTuple");
						}
						if (objectType == 16)
						{
							array[i] = new HHandle((HHandle)o[i]);
						}
						else
						{
							array[i] = o[i];
						}
					}
				}
				base.SetArray(array, false);
				return;
			}
			for (int j = 0; j < o.Length; j++)
			{
				if (o[j] != null)
				{
					int objectType2 = HTupleImplementation.GetObjectType(o[j]);
					if (objectType2 == 31 || (objectType2 & 32768) > 0)
					{
						throw new HTupleAccessException("Encountered invalid data types when creating HTuple");
					}
				}
			}
			base.SetArray(o, false);
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
			new HTupleElementsMixed(this, indices).setO(elements.OArr);
		}

		public override void Dispose()
		{
			for (int i = 0; i < base.Length; i++)
			{
				if (this.GetElementType(i) == HTupleType.HANDLE)
				{
					((HHandle)this.o[i]).Dispose();
				}
			}
		}

		public HTupleType GetElementType(int index)
		{
			return (HTupleType)HTupleImplementation.GetObjectType(this.o[index]);
		}

		public HTupleType GetElementType(int[] indices)
		{
			if (indices == null || indices.Length == 0)
			{
				return HTupleType.EMPTY;
			}
			HTupleType objectType = (HTupleType)HTupleImplementation.GetObjectType(this.o[indices[0]]);
			for (int i = 1; i < indices.Length; i++)
			{
				if (HTupleImplementation.GetObjectType(this.o[indices[i]]) != (int)objectType)
				{
					return HTupleType.MIXED;
				}
			}
			return objectType;
		}

		public override HHandle[] ToHArr()
		{
			for (int i = 0; i < base.Length; i++)
			{
				if (this.GetElementType(i) != HTupleType.HANDLE)
				{
					throw new HTupleAccessException(this, "Copy of mixed tuple is only allowed with handle types");
				}
			}
			HHandle[] array = new HHandle[base.Length];
			for (int j = 0; j < base.Length; j++)
			{
				array[j] = new HHandle((HHandle)this.o[j]);
			}
			return array;
		}

		public override object[] ToOArr()
		{
			object[] array = new object[this.iLength];
			this.CopyToOArr(array, 0);
			return array;
		}

		public override int CopyToOArr(object[] dst, int offset)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				if (this.o[i] is HHandle)
				{
					dst[i + offset] = new HHandle((HHandle)this.o[i]);
				}
				else
				{
					dst[i + offset] = this.o[i];
				}
			}
			return this.iLength;
		}

		public override int CopyFrom(HTupleImplementation impl, int offset)
		{
			return impl.CopyToOArr(this.o, offset);
		}

		protected override void StoreData(IntPtr proc, IntPtr tuple)
		{
			for (int i = 0; i < this.iLength; i++)
			{
				int objectType = HTupleImplementation.GetObjectType(this.o[i]);
				switch (objectType)
				{
				case 1:
					SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetI(tuple, i, (int)this.o[i]));
					break;
				case 2:
					SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetD(tuple, i, (double)this.o[i]));
					break;
				case 3:
					break;
				case 4:
					SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetS(tuple, i, (string)this.o[i], false));
					break;
				default:
					if (objectType != 16)
					{
						if (objectType == 129)
						{
							SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetL(tuple, i, (long)this.o[i]));
						}
					}
					else
					{
						SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetH(tuple, i, (HHandle)this.o[i]));
					}
					break;
				}
			}
		}

		public static int Load(IntPtr tuple, out HTupleMixed data, bool force_utf8)
		{
			int num = 2;
			int num2;
			SZXCArimAPI.GetTupleLength(tuple, out num2);
			object[] array = new object[num2];
			for (int i = 0; i < num2; i++)
			{
				if (!SZXCArimAPI.IsFailure(num))
				{
					HTupleType hTupleType;
					SZXCArimAPI.GetElementType(tuple, i, out hTupleType);
					switch (hTupleType)
					{
					case HTupleType.INTEGER:
						if (SZXCArimAPI.isPlatform64)
						{
							long num3;
							num = SZXCArimAPI.GetL(tuple, i, out num3);
							array[i] = num3;
						}
						else
						{
							int num4;
							num = SZXCArimAPI.GetI(tuple, i, out num4);
							array[i] = num4;
						}
						break;
					case HTupleType.DOUBLE:
					{
						double num5;
						num = SZXCArimAPI.GetD(tuple, i, out num5);
						array[i] = num5;
						break;
					}
					case (HTupleType)3:
						break;
					case HTupleType.STRING:
					{
						string text;
						num = SZXCArimAPI.GetS(tuple, i, out text, force_utf8);
						array[i] = text;
						break;
					}
					default:
						if (hTupleType == HTupleType.HANDLE)
						{
							HHandle hHandle;
							num = SZXCArimAPI.GetH(tuple, i, out hHandle);
							array[i] = hHandle;
						}
						break;
					}
				}
			}
			data = new HTupleMixed(array, false);
			return num;
		}
	}
}
