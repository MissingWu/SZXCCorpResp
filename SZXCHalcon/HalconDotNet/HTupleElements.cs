using System;
using System.Windows;

namespace SZXCArimEngine
{
	public class HTupleElements
	{
		private HTuple parent;

		private HTupleElementsImplementation elements;

		public int I
		{
			get
			{
				return this.elements.I[0];
			}
			set
			{
				int[] i = new int[]
				{
					value
				};
				try
				{
					this.elements.I = i;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.I = i;
				}
			}
		}

		public int[] IArr
		{
			get
			{
				return this.elements.I;
			}
			set
			{
				try
				{
					this.elements.I = value;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.I = value;
				}
			}
		}

		public long L
		{
			get
			{
				return this.elements.L[0];
			}
			set
			{
				long[] l = new long[]
				{
					value
				};
				try
				{
					this.elements.L = l;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.L = l;
				}
			}
		}

		public long[] LArr
		{
			get
			{
				return this.elements.L;
			}
			set
			{
				try
				{
					this.elements.L = value;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.L = value;
				}
			}
		}

		public double D
		{
			get
			{
				return this.elements.D[0];
			}
			set
			{
				double[] d = new double[]
				{
					value
				};
				try
				{
					this.elements.D = d;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.D = d;
				}
			}
		}

		public double[] DArr
		{
			get
			{
				return this.elements.D;
			}
			set
			{
				try
				{
					this.elements.D = value;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.D = value;
				}
			}
		}

		public string S
		{
			get
			{
				return this.elements.S[0];
			}
			set
			{
				string[] s = new string[]
				{
					value
				};
				try
				{
					this.elements.S = s;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.S = s;
				}
			}
		}

		public string[] SArr
		{
			get
			{
				return this.elements.S;
			}
			set
			{
				try
				{
					this.elements.S = value;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.S = value;
				}
			}
		}

		public HHandle H
		{
			get
			{
				return this.elements.H[0];
			}
			set
			{
				HHandle[] h = new HHandle[]
				{
					value
				};
				try
				{
					this.elements.H = h;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.H = h;
				}
			}
		}

		public HHandle[] HArr
		{
			get
			{
				return this.elements.H;
			}
			set
			{
				try
				{
					this.elements.H = value;
				}
				catch (HTupleAccessException)
				{
					this.ConvertToMixed();
					this.elements.H = value;
				}
			}
		}

		public object O
		{
			get
			{
				return this.elements.O[0];
			}
			set
			{
				if (this.elements is HTupleElementsMixed)
				{
					this.elements.O[0] = value;
					return;
				}
				int objectType = HTupleImplementation.GetObjectType(value);
				if (objectType <= 16)
				{
					switch (objectType)
					{
					case 1:
						this.I = (int)value;
						return;
					case 2:
						this.D = (double)value;
						return;
					case 3:
						break;
					case 4:
						this.S = (string)value;
						return;
					default:
						if (objectType == 16)
						{
							this.H = (HHandle)value;
							return;
						}
						break;
					}
				}
				else
				{
					if (objectType == 129)
					{
						this.L = (long)value;
						return;
					}
					if (objectType == 32898)
					{
						this.F = (float)value;
						return;
					}
					if (objectType == 32900)
					{
						this.IP = (IntPtr)value;
						return;
					}
				}
				throw new HTupleAccessException("Attempting to assign object containing invalid type");
			}
		}

		public object[] OArr
		{
			get
			{
				return this.elements.O;
			}
			set
			{
				if (this.elements is HTupleElementsMixed)
				{
					this.elements.O = value;
					return;
				}
				int objectsType = HTupleImplementation.GetObjectsType(value);
				if (objectsType <= 16)
				{
					switch (objectsType)
					{
					case 1:
						this.IArr = Array.ConvertAll<object, int>(value, new Converter<object, int>(HTupleElements.ObjectToInt));
						return;
					case 2:
						this.DArr = Array.ConvertAll<object, double>(value, new Converter<object, double>(HTupleElements.ObjectToDouble));
						return;
					case 3:
						break;
					case 4:
						this.SArr = Array.ConvertAll<object, string>(value, new Converter<object, string>(HTupleElements.ObjectToString));
						return;
					default:
						if (objectsType == 16)
						{
							this.HArr = Array.ConvertAll<object, HHandle>(value, new Converter<object, HHandle>(HTupleElements.ObjectToHandle));
							return;
						}
						break;
					}
				}
				else
				{
					if (objectsType == 129)
					{
						this.LArr = Array.ConvertAll<object, long>(value, new Converter<object, long>(HTupleElements.ObjectToLong));
						return;
					}
					if (objectsType == 32898)
					{
						this.FArr = Array.ConvertAll<object, float>(value, new Converter<object, float>(HTupleElements.ObjectToFloat));
						return;
					}
					if (objectsType == 32900)
					{
						this.IPArr = Array.ConvertAll<object, IntPtr>(value, new Converter<object, IntPtr>(HTupleElements.ObjectToIntPtr));
						return;
					}
				}
				throw new HTupleAccessException("Attempting to assign object containing invalid type");
			}
		}

		public float F
		{
			get
			{
				return (float)this.D;
			}
			set
			{
				this.D = (double)value;
			}
		}

		public float[] FArr
		{
			get
			{
				double[] dArr = this.DArr;
				float[] array = new float[dArr.Length];
				for (int i = 0; i < dArr.Length; i++)
				{
					array[i] = (float)dArr[i];
				}
				return array;
			}
			set
			{
				double[] array = new double[value.Length];
				for (int i = 0; i < value.Length; i++)
				{
					array[i] = (double)value[i];
				}
				this.DArr = array;
			}
		}

		public IntPtr IP
		{
			get
			{
				if (SZXCArimAPI.isPlatform64)
				{
					if (this.Type == HTupleType.LONG || this.Type == HTupleType.HANDLE)
					{
						return new IntPtr(this.L);
					}
				}
				else if (this.Type == HTupleType.INTEGER || this.Type == HTupleType.HANDLE)
				{
					return new IntPtr(this.I);
				}
				throw new HTupleAccessException("Value does not represent a pointer on this platform");
			}
			set
			{
				if (this.Type == HTupleType.HANDLE)
				{
					value = this.H.Handle;
				}
				if (SZXCArimAPI.isPlatform64)
				{
					this.L = value.ToInt64();
					return;
				}
				this.I = value.ToInt32();
			}
		}

		public IntPtr[] IPArr
		{
			get
			{
				if (SZXCArimAPI.isPlatform64 && this.Type == HTupleType.LONG)
				{
					IntPtr[] array = new IntPtr[this.LArr.Length];
					for (int i = 0; i < this.LArr.Length; i++)
					{
						array[i] = new IntPtr(this.LArr[i]);
					}
					return array;
				}
				if (this.Type == HTupleType.INTEGER)
				{
					IntPtr[] array2 = new IntPtr[this.IArr.Length];
					for (int j = 0; j < this.IArr.Length; j++)
					{
						array2[j] = new IntPtr(this.IArr[j]);
					}
					return array2;
				}
				throw new HTupleAccessException("Value does not represent a pointer on this platform");
			}
			set
			{
				if (SZXCArimAPI.isPlatform64)
				{
					long[] array = new long[value.Length];
					for (int i = 0; i < value.Length; i++)
					{
						array[i] = value[i].ToInt64();
					}
					this.LArr = array;
					return;
				}
				int[] array2 = new int[value.Length];
				for (int j = 0; j < value.Length; j++)
				{
					array2[j] = value[j].ToInt32();
				}
				this.IArr = array2;
			}
		}

		public HTupleType Type
		{
			get
			{
				return this.elements.Type;
			}
		}

		internal int Length
		{
			get
			{
				return this.elements.Length;
			}
		}

		internal HTupleElements()
		{
			this.parent = null;
			this.elements = new HTupleElementsImplementation();
		}

		internal HTupleElements(HTuple parent, HTupleInt32 source, int index)
		{
			this.parent = parent;
			this.elements = new HTupleElementsInt32(source, index);
		}

		internal HTupleElements(HTuple parent, HTupleInt32 source, int[] indices)
		{
			this.parent = parent;
			this.elements = new HTupleElementsInt32(source, indices);
		}

		internal HTupleElements(HTuple parent, HTupleInt64 tupleImp, int index)
		{
			this.parent = parent;
			this.elements = new HTupleElementsInt64(tupleImp, index);
		}

		internal HTupleElements(HTuple parent, HTupleInt64 tupleImp, int[] indices)
		{
			this.parent = parent;
			this.elements = new HTupleElementsInt64(tupleImp, indices);
		}

		internal HTupleElements(HTuple parent, HTupleDouble tupleImp, int index)
		{
			this.parent = parent;
			this.elements = new HTupleElementsDouble(tupleImp, index);
		}

		internal HTupleElements(HTuple parent, HTupleDouble tupleImp, int[] indices)
		{
			this.parent = parent;
			this.elements = new HTupleElementsDouble(tupleImp, indices);
		}

		internal HTupleElements(HTuple parent, HTupleString tupleImp, int index)
		{
			this.parent = parent;
			this.elements = new HTupleElementsString(tupleImp, index);
		}

		internal HTupleElements(HTuple parent, HTupleString tupleImp, int[] indices)
		{
			this.parent = parent;
			this.elements = new HTupleElementsString(tupleImp, indices);
		}

		internal HTupleElements(HTuple parent, HTupleHandle tupleImp, int index)
		{
			this.parent = parent;
			this.elements = new HTupleElementsHandle(tupleImp, index);
		}

		internal HTupleElements(HTuple parent, HTupleHandle tupleImp, int[] indices)
		{
			this.parent = parent;
			this.elements = new HTupleElementsHandle(tupleImp, indices);
		}

		internal HTupleElements(HTuple parent, HTupleMixed tupleImp, int index)
		{
			this.parent = parent;
			this.elements = new HTupleElementsMixed(tupleImp, index);
		}

		internal HTupleElements(HTuple parent, HTupleMixed tupleImp, int[] indices)
		{
			this.parent = parent;
			this.elements = new HTupleElementsMixed(tupleImp, indices);
		}

		public static int ObjectToInt(object o)
		{
			return (int)o;
		}

		public static long ObjectToLong(object o)
		{
			return (long)o;
		}

		public static double ObjectToDouble(object o)
		{
			return (double)o;
		}

		public static float ObjectToFloat(object o)
		{
			return (float)o;
		}

		public static string ObjectToString(object o)
		{
			return (string)o;
		}

		public static HHandle ObjectToHandle(object o)
		{
			return (HHandle)o;
		}

		public static IntPtr ObjectToIntPtr(object o)
		{
			return (IntPtr)o;
		}

		internal void ConvertToMixed()
		{
			if (this.elements is HTupleElementsMixed)
			{
				//throw new HTupleAccessException();
				MessageBox.Show(elements.ToString()+"³ö´í");
			}
			this.elements = this.parent.ConvertToMixed(this.elements.getIndices());
		}

		public static HTuple operator +(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple + hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator +(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple + hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator +(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = hTuple + hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator +(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple + hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator +(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple + hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator +(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple + hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator +(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = hTuple + t2;
			}
			return result;
		}

		public static HTuple operator -(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple - hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator -(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple - hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator -(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = hTuple - hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator -(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple - hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator -(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple - hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator -(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple - hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator -(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = hTuple - t2;
			}
			return result;
		}

		public static HTuple operator *(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple * hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator *(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple * hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator *(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = hTuple * hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator *(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple * hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator *(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple * hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator *(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple * hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator *(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = hTuple * t2;
			}
			return result;
		}

		public static HTuple operator /(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple / hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator /(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple / hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator /(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = hTuple / hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator /(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple / hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator /(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple / hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator /(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple / hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator /(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = hTuple / t2;
			}
			return result;
		}

		public static HTuple operator %(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple % hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator %(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple % hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator %(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = hTuple % hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator %(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple % hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator %(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple % hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator %(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = hTuple % hTuple2;
				}
			}
			return result;
		}

		public static HTuple operator %(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = hTuple % t2;
			}
			return result;
		}

		public static HTuple operator &(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple & hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator &(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple & hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator &(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = (hTuple & hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator &(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple & hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator &(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple & hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator &(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple & hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator &(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = (hTuple & t2);
			}
			return result;
		}

		public static HTuple operator |(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple | hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator |(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple | hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator |(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = (hTuple | hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator |(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple | hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator |(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple | hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator |(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple | hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator |(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = (hTuple | t2);
			}
			return result;
		}

		public static HTuple operator ^(HTupleElements e1, int t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple ^ hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator ^(HTupleElements e1, long t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple ^ hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator ^(HTupleElements e1, float t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = (hTuple ^ hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator ^(HTupleElements e1, double t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple ^ hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator ^(HTupleElements e1, string t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple ^ hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator ^(HTupleElements e1, HTupleElements t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple ^ hTuple2);
				}
			}
			return result;
		}

		public static HTuple operator ^(HTupleElements e1, HTuple t2)
		{
			HTuple result;
			using (HTuple hTuple = e1)
			{
				result = (hTuple ^ t2);
			}
			return result;
		}

		public static bool operator <(HTupleElements e1, int t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple < hTuple2);
				}
			}
			return result;
		}

		public static bool operator <(HTupleElements e1, long t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple < hTuple2);
				}
			}
			return result;
		}

		public static bool operator <(HTupleElements e1, float t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = (hTuple < hTuple2);
				}
			}
			return result;
		}

		public static bool operator <(HTupleElements e1, double t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple < hTuple2);
				}
			}
			return result;
		}

		public static bool operator <(HTupleElements e1, string t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple < hTuple2);
				}
			}
			return result;
		}

		public static bool operator <(HTupleElements e1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple < hTuple2);
				}
			}
			return result;
		}

		public static bool operator <(HTupleElements e1, HTuple t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				result = (hTuple < t2);
			}
			return result;
		}

		public static bool operator >(HTupleElements e1, int t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple > hTuple2);
				}
			}
			return result;
		}

		public static bool operator >(HTupleElements e1, long t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple > hTuple2);
				}
			}
			return result;
		}

		public static bool operator >(HTupleElements e1, float t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = (hTuple > hTuple2);
				}
			}
			return result;
		}

		public static bool operator >(HTupleElements e1, double t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple > hTuple2);
				}
			}
			return result;
		}

		public static bool operator >(HTupleElements e1, string t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple > hTuple2);
				}
			}
			return result;
		}

		public static bool operator >(HTupleElements e1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple > hTuple2);
				}
			}
			return result;
		}

		public static bool operator >(HTupleElements e1, HTuple t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				result = (hTuple > t2);
			}
			return result;
		}

		public static bool operator <=(HTupleElements e1, int t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple <= hTuple2);
				}
			}
			return result;
		}

		public static bool operator <=(HTupleElements e1, long t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple <= hTuple2);
				}
			}
			return result;
		}

		public static bool operator <=(HTupleElements e1, float t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = (hTuple <= hTuple2);
				}
			}
			return result;
		}

		public static bool operator <=(HTupleElements e1, double t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple <= hTuple2);
				}
			}
			return result;
		}

		public static bool operator <=(HTupleElements e1, string t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple <= hTuple2);
				}
			}
			return result;
		}

		public static bool operator <=(HTupleElements e1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple <= hTuple2);
				}
			}
			return result;
		}

		public static bool operator <=(HTupleElements e1, HTuple t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				result = (hTuple <= t2);
			}
			return result;
		}

		public static bool operator >=(HTupleElements e1, int t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple >= hTuple2);
				}
			}
			return result;
		}

		public static bool operator >=(HTupleElements e1, long t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple >= hTuple2);
				}
			}
			return result;
		}

		public static bool operator >=(HTupleElements e1, float t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = (double)t2)
				{
					result = (hTuple >= hTuple2);
				}
			}
			return result;
		}

		public static bool operator >=(HTupleElements e1, double t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple >= hTuple2);
				}
			}
			return result;
		}

		public static bool operator >=(HTupleElements e1, string t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple >= hTuple2);
				}
			}
			return result;
		}

		public static bool operator >=(HTupleElements e1, HTupleElements t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				using (HTuple hTuple2 = t2)
				{
					result = (hTuple >= hTuple2);
				}
			}
			return result;
		}

		public static bool operator >=(HTupleElements e1, HTuple t2)
		{
			bool result;
			using (HTuple hTuple = e1)
			{
				result = (hTuple >= t2);
			}
			return result;
		}

		public static implicit operator bool(HTupleElements hte)
		{
			return hte.I != 0;
		}

		public static implicit operator int(HTupleElements hte)
		{
			return hte.I;
		}

		public static implicit operator long(HTupleElements hte)
		{
			return hte.L;
		}

		public static implicit operator IntPtr(HTupleElements hte)
		{
			return hte.IP;
		}

		public static implicit operator double(HTupleElements hte)
		{
			return hte.D;
		}

		public static implicit operator string(HTupleElements hte)
		{
			return hte.S;
		}

		public static implicit operator HTupleElements(int i)
		{
			return new HTuple(i)[0];
		}

		public static implicit operator HTupleElements(long l)
		{
			return new HTuple(l)[0];
		}

		public static implicit operator HTupleElements(IntPtr ip)
		{
			return new HTuple(ip)[0];
		}

		public static implicit operator HTupleElements(double d)
		{
			return new HTuple(d)[0];
		}

		public static implicit operator HTupleElements(string s)
		{
			return new HTuple(s)[0];
		}

		public static implicit operator HTupleElements(HHandle h)
		{
			return new HTuple(new HTupleHandle(new HHandle[]
			{
				h
			}, false));
		}
	}
}
