using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HTuple : ISerializable, ICloneable, IDisposable
	{
		private delegate void NativeInt2To1(int[] in1, int[] in2, int[] buffer);

		private delegate void NativeLong2To1(long[] in1, long[] in2, long[] buffer);

		private delegate void NativeDouble2To1(double[] in1, double[] in2, double[] buffer);

		private enum ResultSize
		{
			EQUAL,
			SUM
		}

		internal HTupleImplementation data;

		private static HTuple.NativeInt2To1 addInt = new HTuple.NativeInt2To1(HTuple.NativeIntAdd);

		private static HTuple.NativeLong2To1 addLong = new HTuple.NativeLong2To1(HTuple.NativeLongAdd);

		private static HTuple.NativeDouble2To1 addDouble = new HTuple.NativeDouble2To1(HTuple.NativeDoubleAdd);

		private static HTuple.NativeInt2To1 subInt = new HTuple.NativeInt2To1(HTuple.NativeIntSub);

		private static HTuple.NativeLong2To1 subLong = new HTuple.NativeLong2To1(HTuple.NativeLongSub);

		private static HTuple.NativeDouble2To1 subDouble = new HTuple.NativeDouble2To1(HTuple.NativeDoubleSub);

		private static HTuple.NativeInt2To1 multInt = new HTuple.NativeInt2To1(HTuple.NativeIntMult);

		private static HTuple.NativeLong2To1 multLong = new HTuple.NativeLong2To1(HTuple.NativeLongMult);

		private static HTuple.NativeDouble2To1 multDouble = new HTuple.NativeDouble2To1(HTuple.NativeDoubleMult);

		public HTupleType Type
		{
			get
			{
				return this.data.Type;
			}
		}

		public int Length
		{
			get
			{
				return this.data.Length;
			}
		}

		public HTupleElements this[int[] indices]
		{
			get
			{
				for (int i = 0; i < indices.Length; i++)
				{
					int num = indices[i];
					if (num < 0 || num >= this.data.Length)
					{
						throw new HTupleAccessException("Index out of range");
					}
				}
				return this.data.GetElements(indices, this);
			}
			set
			{
				if (indices.Length != 0)
				{
					for (int i = 0; i < indices.Length; i++)
					{
						if (indices[i] < 0)
						{
							throw new HTupleAccessException("Index out of range");
						}
					}
					if (this.data.Type == HTupleType.EMPTY)
					{
						HTupleType type = value.Type;
						if (type <= HTupleType.MIXED)
						{
							switch (type)
							{
							case HTupleType.INTEGER:
								this.data = new HTupleInt32(0);
								goto IL_F5;
							case HTupleType.DOUBLE:
								this.data = new HTupleDouble(0.0);
								goto IL_F5;
							case (HTupleType)3:
								break;
							case HTupleType.STRING:
								this.data = new HTupleString("");
								goto IL_F5;
							default:
								if (type == HTupleType.MIXED)
								{
									this.data = new HTupleMixed(0);
									goto IL_F5;
								}
								break;
							}
						}
						else
						{
							if (type == HTupleType.HANDLE)
							{
								this.data = new HTupleHandle(null);
								goto IL_F5;
							}
							if (type == HTupleType.LONG)
							{
								this.data = new HTupleInt64(0L);
								goto IL_F5;
							}
						}
						throw new HTupleAccessException("Inconsistent tuple state encountered");
					}
					IL_F5:
					this.data.AssertSize(indices);
					if (value.Type != this.data.Type)
					{
						this.ConvertToMixed();
					}
					try
					{
						this.data.SetElements(indices, value);
					}
					catch (HTupleAccessException)
					{
						this.ConvertToMixed();
						this.data.SetElements(indices, value);
					}
					return;
				}
				if (value.Length <= 1)
				{
					return;
				}
				throw new HTupleAccessException("Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
			}
		}

		public HTupleElements this[int index]
		{
			get
			{
				if (index < 0 || index >= this.data.Length)
				{
					throw new HTupleAccessException("Index out of range");
				}
				return this.data.GetElement(index, this);
			}
			set
			{
				this[new int[]
				{
					index
				}] = value;
			}
		}

		public HTupleElements this[HTuple indices]
		{
			get
			{
				return this[HTuple.GetIndicesFromTuple(indices)];
			}
			set
			{
				this[HTuple.GetIndicesFromTuple(indices)] = value;
			}
		}

		public int[] IArr
		{
			get
			{
				return this.data.IArr;
			}
			set
			{
				if (this.Type == HTupleType.INTEGER)
				{
					this.data.IArr = value;
					return;
				}
				this.data = new HTupleInt32(value, false);
			}
		}

		public long[] LArr
		{
			get
			{
				return this.data.LArr;
			}
			set
			{
				if (this.Type == HTupleType.LONG)
				{
					this.data.LArr = value;
					return;
				}
				this.data = new HTupleInt64(value, false);
			}
		}

		public double[] DArr
		{
			get
			{
				return this.data.DArr;
			}
			set
			{
				if (this.Type == HTupleType.DOUBLE)
				{
					this.data.DArr = value;
					return;
				}
				this.data = new HTupleDouble(value, false);
			}
		}

		public string[] SArr
		{
			get
			{
				return this.data.SArr;
			}
			set
			{
				if (this.Type == HTupleType.STRING)
				{
					this.data.SArr = value;
					return;
				}
				this.data = new HTupleString(value, false);
			}
		}

		public HHandle[] HArr
		{
			get
			{
				return this.data.HArr;
			}
			set
			{
				if (this.Type == HTupleType.HANDLE)
				{
					this.data.HArr = value;
					return;
				}
				this.data = new HTupleHandle(value, false);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public object[] OArr
		{
			get
			{
				return this.data.OArr;
			}
		}

		public int I
		{
			get
			{
				return this[0].I;
			}
			set
			{
				this[0].I = value;
			}
		}

		public long L
		{
			get
			{
				return this[0].L;
			}
			set
			{
				this[0].L = value;
			}
		}

		public double D
		{
			get
			{
				return this[0].D;
			}
			set
			{
				this[0].D = value;
			}
		}

		public string S
		{
			get
			{
				return this[0].S;
			}
			set
			{
				this[0].S = value;
			}
		}

		public HHandle H
		{
			get
			{
				return this[0].H;
			}
			set
			{
				this[0].H = value;
			}
		}

		public object O
		{
			get
			{
				return this[0].O;
			}
			set
			{
				this[0].O = value;
			}
		}

		public IntPtr IP
		{
			get
			{
				return this[0].IP;
			}
			set
			{
				this[0].IP = value;
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeTuple();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTuple(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_25 = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			HTuple hTuple = HTuple.DeserializeTuple(expr_25);
			this.data = hTuple.data;
			expr_25.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeTuple();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HTuple Deserialize(Stream stream)
		{
			HTuple result = new HTuple();
			HSerializedItem expr_0C = HSerializedItem.Deserialize(stream);
			result = HTuple.DeserializeTuple(expr_0C);
			expr_0C.Dispose();
			return result;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HTuple TupleUnion(HTuple set2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(96);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, set2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(set2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIntersection(HTuple set2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(97);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, set2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(set2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleDifference(HTuple set2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(98);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, set2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(set2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSymmdiff(HTuple set2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(99);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, set2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(set2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsStringElem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(100);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsRealElem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(101);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsIntElem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(102);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleTypeElem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(103);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsMixed()
		{
			IntPtr proc = SZXCArimAPI.PreCall(104);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsString()
		{
			IntPtr proc = SZXCArimAPI.PreCall(105);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsReal()
		{
			IntPtr proc = SZXCArimAPI.PreCall(106);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsInt()
		{
			IntPtr proc = SZXCArimAPI.PreCall(107);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleType()
		{
			IntPtr proc = SZXCArimAPI.PreCall(108);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleHistoRange(HTuple min, HTuple max, HTuple numBins, out HTuple binSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(109);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, min);
			SZXCArimAPI.Store(proc, 2, max);
			SZXCArimAPI.Store(proc, 3, numBins);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			SZXCArimAPI.UnpinTuple(numBins);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out binSize);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRegexpSelect(HTuple expression)
		{
			IntPtr proc = SZXCArimAPI.PreCall(110);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, expression);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(expression);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRegexpTest(HTuple expression)
		{
			IntPtr proc = SZXCArimAPI.PreCall(111);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, expression);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(expression);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRegexpReplace(HTuple expression, HTuple replace)
		{
			IntPtr proc = SZXCArimAPI.PreCall(112);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, expression);
			SZXCArimAPI.Store(proc, 2, replace);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(expression);
			SZXCArimAPI.UnpinTuple(replace);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRegexpMatch(HTuple expression)
		{
			IntPtr proc = SZXCArimAPI.PreCall(113);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, expression);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(expression);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple TupleRand(HTuple length)
		{
			IntPtr expr_07 = SZXCArimAPI.PreCall(114);
			SZXCArimAPI.Store(expr_07, 0, length);
			SZXCArimAPI.InitOCT(expr_07, 0);
			int num = SZXCArimAPI.CallProcedure(expr_07);
			SZXCArimAPI.UnpinTuple(length);
			HTuple result;
			num = HTuple.LoadNew(expr_07, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_07, num);
			return result;
		}

		private HTuple TupleLengthOp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(115);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSgn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(116);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleMax2(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(117);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleMin2(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(118);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleMax()
		{
			IntPtr proc = SZXCArimAPI.PreCall(119);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleMin()
		{
			IntPtr proc = SZXCArimAPI.PreCall(120);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleCumul()
		{
			IntPtr proc = SZXCArimAPI.PreCall(121);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSelectRank(HTuple rankIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(122);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, rankIndex);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rankIndex);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleMedian()
		{
			IntPtr proc = SZXCArimAPI.PreCall(123);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSum()
		{
			IntPtr proc = SZXCArimAPI.PreCall(124);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleMean()
		{
			IntPtr proc = SZXCArimAPI.PreCall(125);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleDeviation()
		{
			IntPtr proc = SZXCArimAPI.PreCall(126);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleUniq()
		{
			IntPtr proc = SZXCArimAPI.PreCall(127);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleFindLast(HTuple toFind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(128);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toFind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(toFind);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleFindFirst(HTuple toFind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(129);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toFind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(toFind);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleFind(HTuple toFind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(130);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toFind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(toFind);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSortIndex()
		{
			IntPtr proc = SZXCArimAPI.PreCall(131);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSort()
		{
			IntPtr proc = SZXCArimAPI.PreCall(132);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleInverse()
		{
			IntPtr proc = SZXCArimAPI.PreCall(133);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		private HTuple TupleConcatOp(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(134);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSelectRange(HTuple leftindex, HTuple rightindex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(135);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, leftindex);
			SZXCArimAPI.Store(proc, 2, rightindex);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(leftindex);
			SZXCArimAPI.UnpinTuple(rightindex);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLastN(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(136);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleFirstN(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(137);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleInsert(HTuple index, HTuple insertTuple)
		{
			IntPtr proc = SZXCArimAPI.PreCall(138);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, insertTuple);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(insertTuple);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleReplace(HTuple index, HTuple replaceTuple)
		{
			IntPtr proc = SZXCArimAPI.PreCall(139);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, replaceTuple);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(replaceTuple);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRemove(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(140);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSelectMask(HTuple mask)
		{
			IntPtr proc = SZXCArimAPI.PreCall(141);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, mask);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(mask);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSelect(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(142);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrBitSelect(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(143);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple TupleGenSequence(HTuple start, HTuple end, HTuple step)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(144);
			SZXCArimAPI.Store(expr_0A, 0, start);
			SZXCArimAPI.Store(expr_0A, 1, end);
			SZXCArimAPI.Store(expr_0A, 2, step);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(start);
			SZXCArimAPI.UnpinTuple(end);
			SZXCArimAPI.UnpinTuple(step);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple TupleGenConst(HTuple length, HTuple constVal)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(145);
			SZXCArimAPI.Store(expr_0A, 0, length);
			SZXCArimAPI.Store(expr_0A, 1, constVal);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(length);
			SZXCArimAPI.UnpinTuple(constVal);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public HTuple TupleEnvironment()
		{
			IntPtr proc = SZXCArimAPI.PreCall(146);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSplit(HTuple separator)
		{
			IntPtr proc = SZXCArimAPI.PreCall(147);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, separator);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(separator);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSubstr(HTuple position1, HTuple position2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(148);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, position1);
			SZXCArimAPI.Store(proc, 2, position2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(position1);
			SZXCArimAPI.UnpinTuple(position2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrLastN(HTuple position)
		{
			IntPtr proc = SZXCArimAPI.PreCall(149);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, position);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(position);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrFirstN(HTuple position)
		{
			IntPtr proc = SZXCArimAPI.PreCall(150);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, position);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(position);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrrchr(HTuple toFind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(151);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toFind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(toFind);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrchr(HTuple toFind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(152);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toFind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(toFind);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrrstr(HTuple toFind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(153);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toFind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(toFind);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrstr(HTuple toFind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(154);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toFind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(toFind);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleStrlen()
		{
			IntPtr proc = SZXCArimAPI.PreCall(155);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLessEqualElem(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(156);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLessElem(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(157);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleGreaterEqualElem(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(158);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleGreaterElem(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(159);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleNotEqualElem(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(160);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleEqualElem(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(161);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLessEqual(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(162);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLess(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(163);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleGreaterEqual(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(164);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleGreater(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(165);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleNotEqual(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(166);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleEqual(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(167);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleNot()
		{
			IntPtr proc = SZXCArimAPI.PreCall(168);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleXor(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(169);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleOr(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(170);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleAnd(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(171);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleBnot()
		{
			IntPtr proc = SZXCArimAPI.PreCall(172);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleBxor(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(173);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleBor(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(174);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleBand(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(175);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRsh(HTuple shift)
		{
			IntPtr proc = SZXCArimAPI.PreCall(176);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, shift);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(shift);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLsh(HTuple shift)
		{
			IntPtr proc = SZXCArimAPI.PreCall(177);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, shift);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(shift);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleChrt()
		{
			IntPtr proc = SZXCArimAPI.PreCall(178);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleOrds()
		{
			IntPtr proc = SZXCArimAPI.PreCall(179);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleChr()
		{
			IntPtr proc = SZXCArimAPI.PreCall(180);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleOrd()
		{
			IntPtr proc = SZXCArimAPI.PreCall(181);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleString(HTuple format)
		{
			IntPtr proc = SZXCArimAPI.PreCall(182);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, format);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(format);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsNumber()
		{
			IntPtr proc = SZXCArimAPI.PreCall(183);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleNumber()
		{
			IntPtr proc = SZXCArimAPI.PreCall(184);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRound()
		{
			IntPtr proc = SZXCArimAPI.PreCall(185);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleInt()
		{
			IntPtr proc = SZXCArimAPI.PreCall(186);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleReal()
		{
			IntPtr proc = SZXCArimAPI.PreCall(187);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLdexp(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(188);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleFmod(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(189);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleMod(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(190);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleCeil()
		{
			IntPtr proc = SZXCArimAPI.PreCall(191);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleFloor()
		{
			IntPtr proc = SZXCArimAPI.PreCall(192);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TuplePow(HTuple t2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(193);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, t2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(t2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLog10()
		{
			IntPtr proc = SZXCArimAPI.PreCall(194);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleLog()
		{
			IntPtr proc = SZXCArimAPI.PreCall(195);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleExp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(196);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleTanh()
		{
			IntPtr proc = SZXCArimAPI.PreCall(197);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleCosh()
		{
			IntPtr proc = SZXCArimAPI.PreCall(198);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSinh()
		{
			IntPtr proc = SZXCArimAPI.PreCall(199);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleRad()
		{
			IntPtr proc = SZXCArimAPI.PreCall(200);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleDeg()
		{
			IntPtr proc = SZXCArimAPI.PreCall(201);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleAtan2(HTuple x)
		{
			IntPtr proc = SZXCArimAPI.PreCall(202);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, x);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(x);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleAtan()
		{
			IntPtr proc = SZXCArimAPI.PreCall(203);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleAcos()
		{
			IntPtr proc = SZXCArimAPI.PreCall(204);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleAsin()
		{
			IntPtr proc = SZXCArimAPI.PreCall(205);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleTan()
		{
			IntPtr proc = SZXCArimAPI.PreCall(206);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleCos()
		{
			IntPtr proc = SZXCArimAPI.PreCall(207);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSin()
		{
			IntPtr proc = SZXCArimAPI.PreCall(208);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleFabs()
		{
			IntPtr proc = SZXCArimAPI.PreCall(209);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSqrt()
		{
			IntPtr proc = SZXCArimAPI.PreCall(210);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleAbs()
		{
			IntPtr proc = SZXCArimAPI.PreCall(211);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleNeg()
		{
			IntPtr proc = SZXCArimAPI.PreCall(212);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleDiv(HTuple q2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(213);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, q2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(q2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		private HTuple TupleMultOp(HTuple p2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(214);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, p2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(p2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		private HTuple TupleSubOp(HTuple d2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(215);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, d2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(d2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		private HTuple TupleAddOp(HTuple s2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(216);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, s2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(s2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple DeserializeTuple(HSerializedItem serializedItemHandle)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(217);
			SZXCArimAPI.Store(expr_0A, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(serializedItemHandle);
			return result;
		}

		public HSerializedItem SerializeTuple()
		{
			IntPtr proc = SZXCArimAPI.PreCall(218);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WriteTuple(HTuple fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(219);
			this.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.UnpinTuple(fileName);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HTuple ReadTuple(HTuple fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(220);
			SZXCArimAPI.Store(expr_0A, 0, fileName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(fileName);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public void ClearHandle()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2134);
			this.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple TupleIsHandle()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2139);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsHandleElem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2140);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsSerializable()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2141);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsSerializableElem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2142);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleIsValidHandle()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2143);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSemType()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2144);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TupleSemTypeElem()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2145);
			this.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			this.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple()
		{
			this.data = HTupleVoid.EMPTY;
		}

		public HTuple(bool b) : this(new IntPtr(b ? 1 : 0))
		{
		}

		public HTuple(int i)
		{
			this.data = new HTupleInt32(i);
		}

		public HTuple(params int[] i)
		{
			this.data = new HTupleInt32(i, true);
		}

		public HTuple(long l)
		{
			this.data = new HTupleInt64(l);
		}

		public HTuple(params long[] l)
		{
			this.data = new HTupleInt64(l, true);
		}

		public HTuple(IntPtr ip) : this(new IntPtr[]
		{
			ip
		})
		{
		}

		public HTuple(params IntPtr[] ip)
		{
			if (SZXCArimAPI.isPlatform64)
			{
				long[] array = new long[ip.Length];
				for (int i = 0; i < ip.Length; i++)
				{
					array[i] = ip[i].ToInt64();
				}
				this.data = new HTupleInt64(array, false);
				return;
			}
			int[] array2 = new int[ip.Length];
			for (int j = 0; j < ip.Length; j++)
			{
				array2[j] = ip[j].ToInt32();
			}
			this.data = new HTupleInt32(array2, false);
		}

		internal HTuple(int i, bool platformSize)
		{
			if (platformSize && SZXCArimAPI.isPlatform64)
			{
				this.data = new HTupleInt64((long)i);
				return;
			}
			this.data = new HTupleInt32(i);
		}

		public HTuple(double d)
		{
			this.data = new HTupleDouble(d);
		}

		public HTuple(params double[] d)
		{
			this.data = new HTupleDouble(d, true);
		}

		public HTuple(float f)
		{
			this.data = new HTupleDouble((double)f);
		}

		public HTuple(params float[] f)
		{
			this.data = new HTupleDouble(f);
		}

		public HTuple(string s)
		{
			this.data = new HTupleString(s);
		}

		public HTuple(params string[] s)
		{
			this.data = new HTupleString(s, true);
		}

		public HTuple(HHandle h)
		{
			this.data = new HTupleHandle(h);
		}

		public HTuple(params HHandle[] h)
		{
			this.data = new HTupleHandle(h, true);
		}

		internal HTuple(object o)
		{
			this.data = new HTupleMixed(o);
		}

		public HTuple(params object[] o)
		{
			this.data = new HTupleMixed(o, true);
		}

		public HTuple(HTuple t)
		{
			HTupleType type = t.Type;
			if (type <= HTupleType.MIXED)
			{
				switch (type)
				{
				case HTupleType.INTEGER:
					this.data = new HTupleInt32(t.ToIArr(), false);
					return;
				case HTupleType.DOUBLE:
					this.data = new HTupleDouble(t.ToDArr(), false);
					return;
				case (HTupleType)3:
					break;
				case HTupleType.STRING:
					this.data = new HTupleString(t.ToSArr(), false);
					return;
				default:
					if (type == HTupleType.MIXED)
					{
						this.data = new HTupleMixed(t.ToOArr(), false);
						return;
					}
					break;
				}
			}
			else
			{
				if (type == HTupleType.HANDLE)
				{
					this.data = new HTupleHandle(t.ToHArr(), false);
					return;
				}
				if (type == HTupleType.EMPTY)
				{
					this.data = HTupleVoid.EMPTY;
					return;
				}
				if (type == HTupleType.LONG)
				{
					this.data = new HTupleInt64(t.ToLArr(), false);
					return;
				}
			}
			throw new HTupleAccessException("Inconsistent tuple state encountered");
		}

		public HTuple(params HTuple[] t) : this()
		{
			HTuple hTuple = new HTuple();
			hTuple = hTuple.TupleConcat(t);
			this.TransferOwnership(hTuple);
		}

		internal HTuple(HTupleImplementation data)
		{
			this.data = data;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TransferOwnership(HTuple source)
		{
			if (source == this)
			{
				return;
			}
			if (source == null)
			{
				this.data = HTupleVoid.EMPTY;
				return;
			}
			this.data = source.data;
			source.data = HTupleVoid.EMPTY;
		}

		public HTuple Clone()
		{
			if (this.Type == HTupleType.HANDLE || this.Type == HTupleType.MIXED)
			{
				using (HSerializedItem hSerializedItem = this.SerializeTuple())
				{
					return HTuple.DeserializeTuple(hSerializedItem);
				}
			}
			return new HTuple(this);
		}

		public void Dispose()
		{
			this.data.Dispose();
		}

		public void UnpinTuple()
		{
			this.data.UnpinTuple();
		}

		internal static int[] GetIndicesFromTuple(HTuple indices)
		{
			if (indices.Type == HTupleType.LONG || indices.Type == HTupleType.INTEGER)
			{
				return indices.ToIArr();
			}
			int[] array = new int[indices.Length];
			for (int i = 0; i < indices.Length; i++)
			{
				if (indices[i].Type == HTupleType.INTEGER)
				{
					array[i] = indices[i].I;
				}
				else if (indices[i].Type == HTupleType.LONG)
				{
					array[i] = indices[i].I;
				}
				else
				{
					if (indices[i].Type != HTupleType.DOUBLE)
					{
						throw new HTupleAccessException("Invalid index type");
					}
					double d = indices[i].D;
					int num = (int)d;
					if ((double)num != d)
					{
						throw new HTupleAccessException("Index has fractional part");
					}
					array[i] = num;
				}
			}
			return array;
		}

		private void ConvertToMixed()
		{
			if (!(this.data is HTupleMixed))
			{
				HTupleImplementation hTupleImplementation = new HTupleMixed(this.data);
				this.data.Dispose();
				this.data = hTupleImplementation;
			}
		}

		internal HTupleElementsMixed ConvertToMixed(int[] indices)
		{
			this.ConvertToMixed();
			return new HTupleElementsMixed((HTupleMixed)this.data, indices);
		}

		public int[] ToIArr()
		{
			return this.data.ToIArr();
		}

		public long[] ToLArr()
		{
			return this.data.ToLArr();
		}

		public double[] ToDArr()
		{
			return this.data.ToDArr();
		}

		public string[] ToSArr()
		{
			return this.data.ToSArr();
		}

		public HHandle[] ToHArr()
		{
			return this.data.ToHArr();
		}

		public object[] ToOArr()
		{
			return this.data.ToOArr();
		}

		public float[] ToFArr()
		{
			return this.data.ToFArr();
		}

		public IntPtr[] ToIPArr()
		{
			return this.data.ToIPArr();
		}

		public static implicit operator HTupleElements(HTuple t)
		{
			if (t.Length == 1)
			{
				return t[0];
			}
			int[] array = new int[t.Length];
			for (int i = 0; i < t.Length; i++)
			{
				array[i] = i;
			}
			return t[array];
		}

		public static implicit operator bool(HTuple t)
		{
			return t[0];
		}

		public static implicit operator int(HTuple t)
		{
			return t[0];
		}

		public static implicit operator long(HTuple t)
		{
			return t[0];
		}

		public static implicit operator double(HTuple t)
		{
			return t[0];
		}

		public static implicit operator string(HTuple t)
		{
			return t[0];
		}

		public static implicit operator IntPtr(HTuple t)
		{
			return t[0];
		}

		public static implicit operator int[](HTuple t)
		{
			return t.ToIArr();
		}

		public static implicit operator long[](HTuple t)
		{
			return t.ToLArr();
		}

		public static implicit operator double[](HTuple t)
		{
			return t.ToDArr();
		}

		public static implicit operator string[](HTuple t)
		{
			return t.ToSArr();
		}

		public static implicit operator HHandle[](HTuple t)
		{
			return t.ToHArr();
		}

		public static implicit operator IntPtr[](HTuple t)
		{
			return t.ToIPArr();
		}

		public static implicit operator HTuple(HTupleElements e)
		{
			HTupleType type = e.Type;
			if (type <= HTupleType.MIXED)
			{
				switch (type)
				{
				case HTupleType.INTEGER:
					return new HTuple(e.IArr);
				case HTupleType.DOUBLE:
					return new HTuple(e.DArr);
				case (HTupleType)3:
					break;
				case HTupleType.STRING:
					return new HTuple(e.SArr);
				default:
					if (type == HTupleType.MIXED)
					{
						return new HTuple(e.OArr);
					}
					break;
				}
			}
			else
			{
				if (type == HTupleType.HANDLE)
				{
					return new HTuple(e.HArr);
				}
				if (type == HTupleType.EMPTY)
				{
					return new HTuple();
				}
				if (type == HTupleType.LONG)
				{
					return new HTuple(e.LArr);
				}
			}
			throw new HTupleAccessException("Inconsistent tuple state encountered");
		}

		public static implicit operator HTuple(int i)
		{
			return new HTuple(i);
		}

		public static implicit operator HTuple(int[] i)
		{
			return new HTuple(i);
		}

		public static implicit operator HTuple(long l)
		{
			return new HTuple(l);
		}

		public static implicit operator HTuple(long[] l)
		{
			return new HTuple(l);
		}

		public static implicit operator HTuple(double d)
		{
			return new HTuple(d);
		}

		public static implicit operator HTuple(double[] d)
		{
			return new HTuple(d);
		}

		public static implicit operator HTuple(string s)
		{
			return new HTuple(s);
		}

		public static implicit operator HTuple(string[] s)
		{
			return new HTuple(s);
		}

		public static implicit operator HTuple(HHandle h)
		{
			return new HTuple(h);
		}

		public static implicit operator HTuple(HHandle[] h)
		{
			return new HTuple(h);
		}

		public static implicit operator HTuple(object[] o)
		{
			return new HTuple(o);
		}

		public static implicit operator HTuple(IntPtr ip)
		{
			return new HTuple(ip);
		}

		public static implicit operator HTuple(IntPtr[] ip)
		{
			return new HTuple(ip);
		}

		internal void Store(IntPtr proc, int parIndex)
		{
			this.data.Store(proc, parIndex);
		}

		internal int Load(IntPtr proc, int parIndex, HTupleType type, int err)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				this.data = HTupleVoid.EMPTY;
				return err;
			}
			return HTupleImplementation.Load(proc, parIndex, type, out this.data);
		}

		internal int Load(IntPtr proc, int parIndex, int err)
		{
			return this.Load(proc, parIndex, HTupleType.MIXED, err);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HTuple tuple)
		{
			tuple = new HTuple();
			return tuple.Load(proc, parIndex, type, err);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HTuple tuple)
		{
			tuple = new HTuple();
			return tuple.Load(proc, parIndex, HTupleType.MIXED, err);
		}

		public override string ToString()
		{
			object[] array = this.ToOArr();
			string text = "";
			if (this.Length != 1)
			{
				text += "[";
			}
			for (int i = 0; i < array.Length; i++)
			{
				text += ((i > 0) ? ", " : "");
				if (this[i].Type == HTupleType.STRING)
				{
					text = text + "\"" + array[i].ToString() + "\"";
				}
				else
				{
					text += array[i].ToString();
				}
				IDisposable disposable = array[i] as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (this.Length != 1)
			{
				text += "]";
			}
			return text;
		}

		public static HTuple operator +(HTuple t1, HTuple t2)
		{
			return t1.TupleAdd(t2);
		}

		public static HTuple operator +(HTuple t1, int t2)
		{
			int val=t1.I;
			val=val + t2;

			return val;
		}

		public static HTuple operator +(HTuple t1, long t2)
		{
			return t1.L + t2;
		}

		public static HTuple operator +(HTuple t1, float t2)
		{
			return t1.D + (double)t2;
		}

		public static HTuple operator +(HTuple t1, double t2)
		{
			return t1.D + t2;
		}

		public static HTuple operator +(HTuple t1, string t2)
		{
			
			return t1.S + t2; 

		}

		public static HTuple operator +(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = t1 + hTuple;
			}
			return result;
		}

		public static HTuple operator -(HTuple t1, HTuple t2)
		{
			return t1.TupleSub(t2);
		}

		public static HTuple operator -(HTuple t1, int t2)
		{
			return t1.I - t2;
		}

		public static HTuple operator -(HTuple t1, long t2)
		{
			return t1.L - t2;
		}

		public static HTuple operator -(HTuple t1, float t2)
		{
			return t1.D - (double)t2;
		}

		public static HTuple operator -(HTuple t1, double t2)
		{
			return t1.D - t2;
		}

		public static HTuple operator -(HTuple t1, string t2)
		{
			return t1.S.Replace( t2,"");
		}

		public static HTuple operator -(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = t1 - hTuple;
			}
			return result;
		}

		public static HTuple operator *(HTuple t1, HTuple t2)
		{
			return t1.TupleMult(t2);
		}

		public static HTuple operator *(HTuple t1, int t2)
		{
			return t1.I * t2;
		}

		public static HTuple operator *(HTuple t1, long t2)
		{
			return t1.L * t2;
		}

		public static HTuple operator *(HTuple t1, float t2)
		{
			return t1.D * (double)t2;
		}

		public static HTuple operator *(HTuple t1, double t2)
		{
			return t1.D * t2;
		}

		public static HTuple operator *(HTuple t1, string t2)
		{
			return t2;
		}

		public static HTuple operator *(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = t1 * hTuple;
			}
			return result;
		}

		public static HTuple operator /(HTuple t1, HTuple t2)
		{
			return t1.TupleDiv(t2);
		}

		public static HTuple operator /(HTuple t1, int t2)
		{
			return t1.I / t2;
		}

		public static HTuple operator /(HTuple t1, long t2)
		{
			return t1.L / t2;
		}

		public static HTuple operator /(HTuple t1, float t2)
		{
			return t1.D / (double)t2;
		}

		public static HTuple operator /(HTuple t1, double t2)
		{
			return t1.D / t2;
		}

		public static HTuple operator /(HTuple t1, string t2)
		{
			return t2;
		}

		public static HTuple operator /(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = t1 / hTuple;
			}
			return result;
		}

		public static HTuple operator %(HTuple t1, HTuple t2)
		{
			return t1.TupleMod(t2);
		}

		public static HTuple operator %(HTuple t1, int t2)
		{
			return t1.I % t2;
		}

		public static HTuple operator %(HTuple t1, long t2)
		{
			return t1.L % t2;
		}

		public static HTuple operator %(HTuple t1, float t2)
		{
			return t1.D % (double)t2;
		}

		public static HTuple operator %(HTuple t1, double t2)
		{
			return t1.D % t2;
		}

		public static HTuple operator %(HTuple t1, string t2)
		{
			return  t2;
		}

		public static HTuple operator %(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = t1 % hTuple;
			}
			return result;
		}

		public static HTuple operator &(HTuple t1, HTuple t2)
		{
			return t1.TupleAnd(t2);
		}

		public static HTuple operator &(HTuple t1, int t2)
		{
			return t1.I & t2;
		}

		public static HTuple operator &(HTuple t1, long t2)
		{
			return t1.L & t2;
		}

		public static HTuple operator &(HTuple t1, float t2)
		{
			return t1 & (double)t2;
		}

		public static HTuple operator &(HTuple t1, double t2)
		{
			return t1 & t2;
		}

		public static HTuple operator &(HTuple t1, string t2)
		{
			return t1 & t2;
		}

		public static HTuple operator &(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = (t1 & hTuple);
			}
			return result;
		}

		public static HTuple operator |(HTuple t1, HTuple t2)
		{
			return t1.TupleOr(t2);
		}

		public static HTuple operator |(HTuple t1, int t2)
		{
			return t1 | t2;
		}

		public static HTuple operator |(HTuple t1, long t2)
		{
			return t1 | t2;
		}

		public static HTuple operator |(HTuple t1, float t2)
		{
			return t1 | (double)t2;
		}

		public static HTuple operator |(HTuple t1, double t2)
		{
			return t1 | t2;
		}

		public static HTuple operator |(HTuple t1, string t2)
		{
			return t1 | t2;
		}

		public static HTuple operator |(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = (t1 | hTuple);
			}
			return result;
		}

		public static HTuple operator ^(HTuple t1, HTuple t2)
		{
			return t1.TupleXor(t2);
		}

		public static HTuple operator ^(HTuple t1, int t2)
		{
			return t1 ^ t2;
		}

		public static HTuple operator ^(HTuple t1, long t2)
		{
			return t1 ^ t2;
		}

		public static HTuple operator ^(HTuple t1, float t2)
		{
			return t1 ^ (double)t2;
		}

		public static HTuple operator ^(HTuple t1, double t2)
		{
			return t1 ^ t2;
		}

		public static HTuple operator ^(HTuple t1, string t2)
		{
			return t1 ^ t2;
		}

		public static HTuple operator ^(HTuple t1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = t2)
			{
				result = (t1 ^ hTuple);
			}
			return result;
		}

		public static bool operator false(HTuple t)
		{
			return !t;
		}

		public static bool operator true(HTuple t)
		{
			return t;
		}

		public static HTuple operator <<(HTuple t1, int shift)
		{
			return t1.TupleLsh(shift);
		}

		public static HTuple operator >>(HTuple t1, int shift)
		{
			return t1.TupleRsh(shift);
		}

		public static bool operator <(HTuple t1, HTuple t2)
		{
			return t1.TupleLess(t2) != 0;
		}

		public static bool operator <(HTuple t1, int t2)
		{
			return t1.I < t2;
		}

		public static bool operator <(HTuple t1, long t2)
		{
			return t1.L < t2;
		}

		public static bool operator <(HTuple t1, float t2)
		{
			return t1.D < (double)t2;
		}

		public static bool operator <(HTuple t1, double t2)
		{
			return t1.D < t2;
		}

		public static bool operator <(HTuple t1, string t2)
		{
			return t1.S.Length < t2.Length;
		}

		public static bool operator <(HTuple t1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = t2)
			{
				result = (t1 < hTuple);
			}
			return result;
		}

		public static bool operator >(HTuple t1, HTuple t2)
		{
			return t1.TupleGreater(t2) != 0;
		}

		public static bool operator >(HTuple t1, int t2)
		{
			return t1.I > t2;
		}

		public static bool operator >(HTuple t1, long t2)
		{
			return t1.L > t2;
		}

		public static bool operator >(HTuple t1, float t2)
		{
			return t1.D > (double)t2;
		}

		public static bool operator >(HTuple t1, double t2)
		{
			return t1.D > t2;
		}

		public static bool operator >(HTuple t1, string t2)
		{
			return t1.S.Length > t2.Length;
		}

		public static bool operator >(HTuple t1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = t2)
			{
				result = (t1 > hTuple);
			}
			return result;
		}

		public static bool operator >=(HTuple t1, HTuple t2)
		{
			return !(t1 < t2);
		}

		public static bool operator >=(HTuple t1, int t2)
		{
			return t1 >= t2;
		}

		public static bool operator >=(HTuple t1, long t2)
		{
			return t1 >= t2;
		}

		public static bool operator >=(HTuple t1, float t2)
		{
			return t1 >= (double)t2;
		}

		public static bool operator >=(HTuple t1, double t2)
		{
			return t1 >= t2;
		}

		public static bool operator >=(HTuple t1, string t2)
		{
			return t1 >= t2;
		}

		public static bool operator >=(HTuple t1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = t2)
			{
				result = (t1 >= hTuple);
			}
			return result;
		}

		public static bool operator <=(HTuple t1, HTuple t2)
		{
			return !(t1 > t2);
		}

		public static bool operator <=(HTuple t1, int t2)
		{
			return t1.I <= t2;
		}

		public static bool operator <=(HTuple t1, long t2)
		{
			return t1.L <= t2;
		}

		public static bool operator <=(HTuple t1, float t2)
		{
			return t1.D <= (double)t2;
		}

		public static bool operator <=(HTuple t1, double t2)
		{
			return t1.D <= t2;
		}

		public static bool operator <=(HTuple t1, string t2)
		{
			return t1.S.Length <= t2.Length;
		}

		public static bool operator <=(HTuple t1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = t2)
			{
				result = (t1 <= hTuple);
			}
			return result;
		}

		public static HTuple operator -(HTuple t)
		{
			return t.TupleNeg();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Continue(HTuple final_value, HTuple increment)
		{
			if (increment[0] < 0.0)
			{
				return this[0].D >= final_value[0].D;
			}
			return this[0].D <= final_value[0].D;
		}

		public void Append(HTuple tuple)
		{
			HTupleImplementation arg_18_0 = this.data;
			this.data = this.TupleConcat(tuple).data;
			arg_18_0.Dispose();
		}

		private bool ProcessNative2To1(HTuple t2, HTuple.ResultSize type, out HTuple result, HTuple.NativeInt2To1 opInt, HTuple.NativeLong2To1 opLong, HTuple.NativeDouble2To1 opDouble)
		{
			int num = (type == HTuple.ResultSize.EQUAL) ? this.Length : (this.Length + t2.Length);
			if (num == 0)
			{
				result = new HTuple();
				return true;
			}
			if (this.Type == t2.Type && (this.Length == t2.Length || type == HTuple.ResultSize.SUM))
			{
				if (this.Type == HTupleType.DOUBLE && opDouble != null)
				{
					double[] dArr = this.DArr;
					double[] dArr2 = t2.DArr;
					double[] array = new double[num];
					array[0] = (double)this.Length;
					opDouble(dArr, dArr2, array);
					result = new HTuple(new HTupleDouble(array, false));
					return true;
				}
				if (this.Type == HTupleType.INTEGER && opInt != null)
				{
					int[] iArr = this.IArr;
					int[] iArr2 = t2.IArr;
					int[] array2 = new int[num];
					array2[0] = this.Length;
					opInt(iArr, iArr2, array2);
					result = new HTuple(new HTupleInt32(array2, false));
					return true;
				}
				if (this.Type == HTupleType.LONG && opLong != null)
				{
					long[] lArr = this.LArr;
					long[] lArr2 = t2.LArr;
					long[] array3 = new long[num];
					array3[0] = (long)this.Length;
					opLong(lArr, lArr2, array3);
					result = new HTuple(new HTupleInt64(array3, false));
					return true;
				}
			}
			result = null;
			return false;
		}

		private static void NativeIntAdd(int[] in1, int[] in2, int[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] + in2[i];
			}
		}

		private static void NativeLongAdd(long[] in1, long[] in2, long[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] + in2[i];
			}
		}

		private static void NativeDoubleAdd(double[] in1, double[] in2, double[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] + in2[i];
			}
		}

		private static void NativeIntSub(int[] in1, int[] in2, int[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] - in2[i];
			}
		}

		private static void NativeLongSub(long[] in1, long[] in2, long[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] - in2[i];
			}
		}

		private static void NativeDoubleSub(double[] in1, double[] in2, double[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] - in2[i];
			}
		}

		private static void NativeIntMult(int[] in1, int[] in2, int[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] * in2[i];
			}
		}

		private static void NativeLongMult(long[] in1, long[] in2, long[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] * in2[i];
			}
		}

		private static void NativeDoubleMult(double[] in1, double[] in2, double[] buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				buffer[i] = in1[i] * in2[i];
			}
		}

		public int TupleLength()
		{
			return this.Length;
		}

		public HTuple TupleAdd(HTuple s2)
		{
			HTuple result;
			if (!this.ProcessNative2To1(s2, HTuple.ResultSize.EQUAL, out result, HTuple.addInt, HTuple.addLong, HTuple.addDouble))
			{
				result = this.TupleAddOp(s2);
			}
			return result;
		}

		public HTuple TupleSub(HTuple d2)
		{
			HTuple result;
			if (!this.ProcessNative2To1(d2, HTuple.ResultSize.EQUAL, out result, HTuple.subInt, HTuple.subLong, HTuple.subDouble))
			{
				result = this.TupleSubOp(d2);
			}
			return result;
		}

		public HTuple TupleMult(HTuple p2)
		{
			HTuple result;
			if (!this.ProcessNative2To1(p2, HTuple.ResultSize.EQUAL, out result, HTuple.multInt, HTuple.multLong, HTuple.multDouble))
			{
				result = this.TupleMultOp(p2);
			}
			return result;
		}

		public HTuple TupleConcat(params HTuple[] tuples)
		{
			HTupleType hTupleType = this.Type;
			int num = this.Length;
			for (int i = 0; i < tuples.Length; i++)
			{
				if (hTupleType == HTupleType.EMPTY)
				{
					hTupleType = tuples[i].Type;
				}
				else if (hTupleType != tuples[i].Type && tuples[i].Type != HTupleType.EMPTY)
				{
					hTupleType = HTupleType.MIXED;
				}
				num += tuples[i].Length;
			}
			if ((hTupleType == HTupleType.MIXED || hTupleType == HTupleType.HANDLE) && SZXCArimAPI.IsLegacyHandleMode())
			{
				HTuple hTuple = this;
				for (int j = 0; j < tuples.Length; j++)
				{
					HTuple hTuple2 = hTuple;
					hTuple = hTuple.TupleConcat(tuples[j]);
					if (j > 0)
					{
						hTuple2.Dispose();
					}
				}
				return hTuple;
			}
			HTupleImplementation hTupleImplementation = HTupleImplementation.CreateInstanceForType(hTupleType, num);
			int num2 = hTupleImplementation.CopyFrom(this.data, 0);
			for (int k = 0; k < tuples.Length; k++)
			{
				num2 += hTupleImplementation.CopyFrom(tuples[k].data, num2);
			}
			return new HTuple(hTupleImplementation);
		}

		public HTuple TupleConcat(HTuple t2)
		{
			HTupleType hTupleType = this.Type;
			int size = this.Length + t2.Length;
			if (hTupleType == HTupleType.EMPTY)
			{
				hTupleType = t2.Type;
			}
			else if (hTupleType != t2.Type && t2.Type != HTupleType.EMPTY)
			{
				hTupleType = HTupleType.MIXED;
			}
			if ((hTupleType == HTupleType.MIXED || hTupleType == HTupleType.HANDLE) && SZXCArimAPI.IsLegacyHandleMode())
			{
				return this.TupleConcatOp(t2);
			}
			HTupleImplementation hTupleImplementation = HTupleImplementation.CreateInstanceForType(hTupleType, size);
			hTupleImplementation.CopyFrom(t2.data, hTupleImplementation.CopyFrom(this.data, 0));
			return new HTuple(hTupleImplementation);
		}
	}
}
