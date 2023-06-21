using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace SZXCArimEngine
{
	internal abstract class HTupleImplementation
	{
		public const int INTEGER = 1;

		public const int DOUBLE = 2;

		public const int STRING = 4;

		public const int HANDLE = 16;

		public const int ANY_ELEM = 23;

		public const int MIXED = 8;

		public const int ANY_TUPLE = 31;

		public const int LONG = 129;

		public const int FLOAT = 32898;

		public const int INTPTR = 32900;

		public const int BAN_IN_MIXED = 32768;

		protected Array data;

		protected int iLength;

		internal GCHandle pinHandle;

		internal int pinCount;

		protected Type typeI = typeof(int);

		protected Type typeL = typeof(long);

		protected Type typeD = typeof(double);

		protected Type typeS = typeof(string);

		protected Type typeH = typeof(HHandle);

		protected Type typeO = typeof(object);

		protected Type typeF = typeof(float);

		protected Type typeIP = typeof(IntPtr);

		protected int Capacity
		{
			get
			{
				return this.data.Length;
			}
		}

		public int Length
		{
			get
			{
				return this.iLength;
			}
		}

		public virtual HTupleType Type
		{
			get
			{
				throw new HTupleAccessException(this);
			}
		}

		public virtual int[] IArr
		{
			get
			{
				throw new HTupleAccessException(this);
			}
			set
			{
				throw new HTupleAccessException(this);
			}
		}

		public virtual long[] LArr
		{
			get
			{
				throw new HTupleAccessException(this);
			}
			set
			{
				throw new HTupleAccessException(this);
			}
		}

		public virtual double[] DArr
		{
			get
			{
				throw new HTupleAccessException(this);
			}
			set
			{
				throw new HTupleAccessException(this);
			}
		}

		public virtual string[] SArr
		{
			get
			{
				throw new HTupleAccessException(this);
			}
			set
			{
				throw new HTupleAccessException(this);
			}
		}

		public virtual HHandle[] HArr
		{
			get
			{
				throw new HTupleAccessException(this);
			}
			set
			{
				throw new HTupleAccessException(this);
			}
		}

		public virtual object[] OArr
		{
			get
			{
				throw new HTupleAccessException(this);
			}
			set
			{
				throw new HTupleAccessException(this);
			}
		}

		public static int GetObjectType(object o)
		{
			if (o is int)
			{
				return 1;
			}
			if (o is long)
			{
				return 129;
			}
			if (o is double)
			{
				return 2;
			}
			if (o is float)
			{
				return 32898;
			}
			if (o is string)
			{
				return 4;
			}
			if (o is HHandle)
			{
				return 16;
			}
			if (o is IntPtr)
			{
				return 32900;
			}
			return 31;
		}

		public static int GetObjectsType(object[] o)
		{
			if (o == null)
			{
				return 31;
			}
			int num = 31;
			int num2 = 31;
			for (int i = 0; i < o.Length; i++)
			{
				if (o[i] is int)
				{
					num = 1;
				}
				if (o[i] is long)
				{
					num = 129;
				}
				if (o[i] is double)
				{
					num = 2;
				}
				if (o[i] is float)
				{
					num = 32898;
				}
				if (o[i] is string)
				{
					num = 4;
				}
				if (o[i] is HHandle)
				{
					num = 16;
				}
				if (o[i] is IntPtr)
				{
					num = 32900;
				}
				if (i == 0)
				{
					num2 = num;
				}
				else if (num != num2)
				{
					return 8;
				}
			}
			return num2;
		}

		public static HTupleImplementation CreateInstanceForType(HTupleType type, int size = 0)
		{
			if (type <= HTupleType.MIXED)
			{
				switch (type)
				{
				case HTupleType.INTEGER:
					return new HTupleInt32(new int[size], false);
				case HTupleType.DOUBLE:
					return new HTupleDouble(new double[size], false);
				case (HTupleType)3:
					break;
				case HTupleType.STRING:
					return new HTupleString(new string[size], false);
				default:
					if (type == HTupleType.MIXED)
					{
						return new HTupleMixed(new object[size], false);
					}
					break;
				}
			}
			else
			{
				if (type == HTupleType.HANDLE)
				{
					return new HTupleHandle(new HHandle[size], false);
				}
				if (type == HTupleType.EMPTY)
				{
					return HTupleVoid.EMPTY;
				}
				if (type == HTupleType.LONG)
				{
					return new HTupleInt64(new long[size], false);
				}
			}
			throw new HTupleAccessException("Unknown HTupleType requested in TupleImplementation.CreateInstanceForType");
		}

		internal virtual void PinTuple()
		{
		}

		internal void UnpinTuple()
		{
			Monitor.Enter(this);
			if (this.pinCount > 0)
			{
				this.pinCount--;
				if (this.pinCount == 0)
				{
					this.pinHandle.Free();
				}
			}
			Monitor.Exit(this);
		}

		protected abstract Array CreateArray(int size);

		protected void SetArray(Array source, bool copy)
		{
			if (source == null)
			{
				source = this.CreateArray(0);
			}
			if (copy)
			{
				this.data = this.CreateArray(source.Length);
				Array.Copy(source, this.data, source.Length);
			}
			else
			{
				this.data = source;
			}
			this.iLength = this.data.Length;
			this.NotifyArrayUpdate();
		}

		protected virtual void NotifyArrayUpdate()
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual void AssertSize(int index)
		{
			if (index >= this.iLength)
			{
				if (index >= this.data.Length)
				{
					Array arg_3F_0 = this.data;
					this.data = this.CreateArray(Math.Max(10, 2 * index));
					Array.Copy(arg_3F_0, this.data, this.iLength);
					this.NotifyArrayUpdate();
				}
				this.iLength = index + 1;
			}
		}

		public virtual void AssertSize(int[] indices)
		{
			int num;
			if (indices.Length == 0)
			{
				num = 0;
			}
			else
			{
				num = indices[0];
				for (int i = 0; i < indices.Length; i++)
				{
					int num2 = indices[i];
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			this.AssertSize(num);
		}

		public virtual HTupleElements GetElement(int index, HTuple parent)
		{
			throw new HTupleAccessException(this);
		}

		public virtual HTupleElements GetElements(int[] indices, HTuple parent)
		{
			if (indices == null || indices.Length == 0)
			{
				return new HTupleElements();
			}
			throw new HTupleAccessException(this);
		}

		public virtual void SetElements(int[] indices, HTupleElements elements)
		{
			if (indices == null || indices.Length == 0)
			{
				return;
			}
			throw new HTupleAccessException(this);
		}

		protected Array ToArray(Type t)
		{
			Array array = Array.CreateInstance(t, this.iLength);
			Array.Copy(this.data, array, this.iLength);
			return array;
		}

		public virtual int[] ToIArr()
		{
			throw new HTupleAccessException(this, "Cannot convert to int array");
		}

		public virtual long[] ToLArr()
		{
			throw new HTupleAccessException(this, "Cannot convert to long array");
		}

		public virtual double[] ToDArr()
		{
			throw new HTupleAccessException(this, "Cannot convert to double array");
		}

		public virtual string[] ToSArr()
		{
			string[] array = new string[this.iLength];
			for (int i = 0; i < this.iLength; i++)
			{
				array[i] = this.data.GetValue(i).ToString();
			}
			return array;
		}

		public virtual HHandle[] ToHArr()
		{
			throw new HTupleAccessException(this, "Cannot convert to handle array");
		}

		public virtual object[] ToOArr()
		{
			return (object[])this.ToArray(this.typeO);
		}

		public virtual float[] ToFArr()
		{
			throw new HTupleAccessException(this, "Cannot convert to float array");
		}

		public virtual IntPtr[] ToIPArr()
		{
			throw new HTupleAccessException(this, "Values in tuple do not represent pointers on this platform");
		}

		public virtual int CopyToIArr(int[] dst, int offset)
		{
			Array array = this.ToArray(this.typeI);
			Array.Copy(array, 0, dst, offset, array.Length);
			return array.Length;
		}

		public virtual int CopyToLArr(long[] dst, int offset)
		{
			Array array = this.ToArray(this.typeL);
			Array.Copy(array, 0, dst, offset, array.Length);
			return array.Length;
		}

		public virtual int CopyToDArr(double[] dst, int offset)
		{
			Array array = this.ToArray(this.typeD);
			Array.Copy(array, 0, dst, offset, array.Length);
			return array.Length;
		}

		public virtual int CopyToSArr(string[] dst, int offset)
		{
			Array array = this.ToArray(this.typeS);
			Array.Copy(array, 0, dst, offset, array.Length);
			return array.Length;
		}

		public virtual int CopyToHArr(HHandle[] dst, int offset)
		{
			Array array = this.ToArray(this.typeH);
			Array.Copy(array, 0, dst, offset, array.Length);
			return array.Length;
		}

		public virtual int CopyToOArr(object[] dst, int offset)
		{
			Array.Copy(this.data, 0, dst, offset, this.iLength);
			return this.data.Length;
		}

		public abstract int CopyFrom(HTupleImplementation impl, int offset);

		public virtual void Store(IntPtr proc, int parIndex)
		{
			HTupleType type = this.Type;
			if (type <= HTupleType.MIXED)
			{
				switch (type)
				{
				case HTupleType.INTEGER:
					break;
				case HTupleType.DOUBLE:
				case HTupleType.STRING:
					goto IL_3A;
				case (HTupleType)3:
					goto IL_43;
				default:
					if (type != HTupleType.MIXED)
					{
						goto IL_43;
					}
					goto IL_3A;
				}
			}
			else
			{
				if (type == HTupleType.HANDLE)
				{
					goto IL_3A;
				}
				if (type != HTupleType.LONG)
				{
					goto IL_43;
				}
			}
			HTupleType type2 = HTupleType.INTEGER;
			goto IL_45;
			IL_3A:
			type2 = this.Type;
			goto IL_45;
			IL_43:
			type2 = HTupleType.MIXED;
			IL_45:
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateInputTuple(proc, parIndex, this.iLength, type2, out tuple));
			this.StoreData(proc, tuple);
		}

		protected abstract void StoreData(IntPtr proc, IntPtr tuple);

		public static int Load(IntPtr proc, int parIndex, HTupleType type, out HTupleImplementation data)
		{
			IntPtr tuple;
			SZXCArimAPI.GetOutputTuple(proc, parIndex, false, out tuple);
			return HTupleImplementation.LoadData(tuple, type, out data, false);
		}

		public static int LoadData(IntPtr tuple, HTupleType type, out HTupleImplementation data, bool force_utf8)
		{
			int result = 2;
			if (tuple == IntPtr.Zero)
			{
				data = HTupleVoid.EMPTY;
				return result;
			}
			int num;
			SZXCArimAPI.GetTupleTypeScanElem(tuple, out num);
			if (num <= 16)
			{
				switch (num)
				{
				case 1:
					if (SZXCArimAPI.isPlatform64)
					{
						HTupleInt64 hTupleInt;
						result = HTupleInt64.Load(tuple, out hTupleInt);
						data = hTupleInt;
					}
					else
					{
						HTupleInt32 hTupleInt2;
						result = HTupleInt32.Load(tuple, out hTupleInt2);
						data = hTupleInt2;
					}
					return result;
				case 2:
				{
					HTupleDouble hTupleDouble;
					result = HTupleDouble.Load(tuple, out hTupleDouble);
					data = hTupleDouble;
					return result;
				}
				case 3:
					break;
				case 4:
				{
					HTupleString hTupleString;
					result = HTupleString.Load(tuple, out hTupleString, force_utf8);
					data = hTupleString;
					return result;
				}
				default:
					if (num == 16)
					{
						HTupleHandle hTupleHandle;
						result = HTupleHandle.Load(tuple, out hTupleHandle);
						data = hTupleHandle;
						return result;
					}
					break;
				}
			}
			else
			{
				if (num == 23)
				{
					HTupleMixed hTupleMixed;
					result = HTupleMixed.Load(tuple, out hTupleMixed, force_utf8);
					data = hTupleMixed;
					return result;
				}
				if (num == 31)
				{
					data = HTupleVoid.EMPTY;
					return result;
				}
			}
			data = HTupleVoid.EMPTY;
			result = 7002;
			return result;
		}
	}
}
