using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HXLD : HObject, ISerializable, ICloneable
	{
		public new HXLD this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HXLD() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLD(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLD(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLD(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
			SZXCArimAPI.AssertObjectClass(this.key, "xld");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLD obj)
		{
			obj = new HXLD(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeXld();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLD(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeXld(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeXld();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HXLD Deserialize(Stream stream)
		{
			HXLD arg_0C_0 = new HXLD();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeXld(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HXLD Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeXld();
			HXLD expr_0C = new HXLD();
			expr_0C.DeserializeXld(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void GetParallelsXld(out HTuple row1, out HTuple col1, out HTuple length1, out HTuple phi1, out HTuple row2, out HTuple col2, out HTuple length2, out HTuple phi2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(41);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row1);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out col1);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out length1);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out phi1);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out row2);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out col2);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out length2);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out phi2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DispXld(HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(74);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void ReceiveXld(HSocket socket)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(329);
			SZXCArimAPI.Store(proc, 0, socket);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public void SendXld(HSocket socket)
		{
			IntPtr proc = SZXCArimAPI.PreCall(330);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, socket);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public HXLD ObjDiff(HXLD objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public HImage PaintXld(HImage image, HTuple grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(575);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, grayval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayval);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage PaintXld(HImage image, double grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(575);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreD(proc, 0, grayval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public new HXLD CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD ConcatObj(HXLD objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public new HXLD SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLD SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HXLD objects2, HTuple epsilon)
		{
			IntPtr proc = SZXCArimAPI.PreCall(588);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.Store(proc, 0, epsilon);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(epsilon);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public int CompareObj(HXLD objects2, double epsilon)
		{
			IntPtr proc = SZXCArimAPI.PreCall(588);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.StoreD(proc, 0, epsilon);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public int TestEqualObj(HXLD objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(591);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public HImage GenGridRectificationMap(HImage image, out HXLD meshes, int gridSpacing, HTuple rotation, HTuple row, HTuple column, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1159);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 0, gridSpacing);
			SZXCArimAPI.Store(proc, 1, rotation);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.StoreS(proc, 4, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLD.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage GenGridRectificationMap(HImage image, out HXLD meshes, int gridSpacing, string rotation, HTuple row, HTuple column, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1159);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 0, gridSpacing);
			SZXCArimAPI.StoreS(proc, 1, rotation);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.StoreS(proc, 4, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLD.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void DeserializeXld(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1632);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1633);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TestClosedXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1667);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsAnyPointsXld(string mode, HTuple area, HTuple centerRow, HTuple centerCol, HTuple p, HTuple q)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1669);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, area);
			SZXCArimAPI.Store(proc, 2, centerRow);
			SZXCArimAPI.Store(proc, 3, centerCol);
			SZXCArimAPI.Store(proc, 4, p);
			SZXCArimAPI.Store(proc, 5, q);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(area);
			SZXCArimAPI.UnpinTuple(centerRow);
			SZXCArimAPI.UnpinTuple(centerCol);
			SZXCArimAPI.UnpinTuple(p);
			SZXCArimAPI.UnpinTuple(q);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsAnyPointsXld(string mode, double area, double centerRow, double centerCol, int p, int q)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1669);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, area);
			SZXCArimAPI.StoreD(proc, 2, centerRow);
			SZXCArimAPI.StoreD(proc, 3, centerCol);
			SZXCArimAPI.StoreI(proc, 4, p);
			SZXCArimAPI.StoreI(proc, 5, q);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EccentricityPointsXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1670);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EllipticAxisPointsXld(out HTuple rb, out HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1671);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out rb);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double EllipticAxisPointsXld(out double rb, out double phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1671);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out rb);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple OrientationPointsXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1672);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsPointsXld(out HTuple m20, out HTuple m02)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1673);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out m20);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out m02);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsPointsXld(out double m20, out double m02)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1673);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out m20);
			num = SZXCArimAPI.LoadD(proc, 2, num, out m02);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple AreaCenterPointsXld(out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1674);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double AreaCenterPointsXld(out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1674);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out row);
			num = SZXCArimAPI.LoadD(proc, 2, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TestSelfIntersectionXld(string closeXLD)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1675);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, closeXLD);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD SelectXldPoint(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD SelectXldPoint(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TestXldPoint(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1677);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int TestXldPoint(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1677);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD SelectShapeXld(HTuple features, string operation, HTuple min, HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1678);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.Store(proc, 2, min);
			SZXCArimAPI.Store(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD SelectShapeXld(string features, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1678);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple OrientationXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1679);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EccentricityXld(out HTuple bulkiness, out HTuple structureFactor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1680);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out bulkiness);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out structureFactor);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double EccentricityXld(out double bulkiness, out double structureFactor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1680);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out bulkiness);
			num = SZXCArimAPI.LoadD(proc, 2, num, out structureFactor);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple CompactnessXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1681);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DiameterXld(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2, out HTuple diameter)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1682);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row1);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column1);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out row2);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out column2);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out diameter);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DiameterXld(out double row1, out double column1, out double row2, out double column2, out double diameter)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1682);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadD(proc, 3, num, out column2);
			num = SZXCArimAPI.LoadD(proc, 4, num, out diameter);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple ConvexityXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1683);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple CircularityXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1684);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EllipticAxisXld(out HTuple rb, out HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1685);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out rb);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double EllipticAxisXld(out double rb, out double phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1685);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out rb);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SmallestRectangle2Xld(out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1686);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out length1);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out length2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestRectangle2Xld(out double row, out double column, out double phi, out double length1, out double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1686);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out length2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestRectangle1Xld(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1687);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row1);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column1);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out row2);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestRectangle1Xld(out double row1, out double column1, out double row2, out double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1687);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadD(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestCircleXld(out HTuple row, out HTuple column, out HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1688);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestCircleXld(out double row, out double column, out double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1688);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLD ShapeTransXld(string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1689);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple LengthXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1690);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsAnyXld(string mode, HTuple pointOrder, HTuple area, HTuple centerRow, HTuple centerCol, HTuple p, HTuple q)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1691);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, pointOrder);
			SZXCArimAPI.Store(proc, 2, area);
			SZXCArimAPI.Store(proc, 3, centerRow);
			SZXCArimAPI.Store(proc, 4, centerCol);
			SZXCArimAPI.Store(proc, 5, p);
			SZXCArimAPI.Store(proc, 6, q);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pointOrder);
			SZXCArimAPI.UnpinTuple(area);
			SZXCArimAPI.UnpinTuple(centerRow);
			SZXCArimAPI.UnpinTuple(centerCol);
			SZXCArimAPI.UnpinTuple(p);
			SZXCArimAPI.UnpinTuple(q);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsAnyXld(string mode, string pointOrder, double area, double centerRow, double centerCol, int p, int q)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1691);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreS(proc, 1, pointOrder);
			SZXCArimAPI.StoreD(proc, 2, area);
			SZXCArimAPI.StoreD(proc, 3, centerRow);
			SZXCArimAPI.StoreD(proc, 4, centerCol);
			SZXCArimAPI.StoreI(proc, 5, p);
			SZXCArimAPI.StoreI(proc, 6, q);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsXld(out HTuple m20, out HTuple m02)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1692);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out m20);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out m02);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsXld(out double m20, out double m02)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1692);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out m20);
			num = SZXCArimAPI.LoadD(proc, 2, num, out m02);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple AreaCenterXld(out HTuple row, out HTuple column, out HTuple pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1693);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 3, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double AreaCenterXld(out double row, out double column, out string pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1693);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out row);
			num = SZXCArimAPI.LoadD(proc, 2, num, out column);
			num = SZXCArimAPI.LoadS(proc, 3, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] GetRectanglePose(HCamPar cameraParam, HTuple width, HTuple height, string weightingMode, double clippingFactor, out HTuple covPose, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1908);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, width);
			SZXCArimAPI.Store(proc, 2, height);
			SZXCArimAPI.StoreS(proc, 3, weightingMode);
			SZXCArimAPI.StoreD(proc, 4, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(width);
			SZXCArimAPI.UnpinTuple(height);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_AE_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			return arg_AE_0;
		}

		public HPose GetRectanglePose(HCamPar cameraParam, double width, double height, string weightingMode, double clippingFactor, out HTuple covPose, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1908);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.StoreD(proc, 1, width);
			SZXCArimAPI.StoreD(proc, 2, height);
			SZXCArimAPI.StoreS(proc, 3, weightingMode);
			SZXCArimAPI.StoreD(proc, 4, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetCirclePose(HCamPar cameraParam, HTuple radius, string outputType, out HTuple pose2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1909);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, radius);
			SZXCArimAPI.StoreS(proc, 2, outputType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(radius);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out pose2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetCirclePose(HCamPar cameraParam, double radius, string outputType, out HTuple pose2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1909);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.StoreD(proc, 1, radius);
			SZXCArimAPI.StoreS(proc, 2, outputType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out pose2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple HeightWidthRatioXld(out HTuple width, out HTuple ratio)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2120);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out width);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out ratio);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double HeightWidthRatioXld(out double width, out double ratio)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2120);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out width);
			num = SZXCArimAPI.LoadD(proc, 2, num, out ratio);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD InsertObj(HXLD objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public new HXLD RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLD RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD ReplaceObj(HXLD objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HXLD ReplaceObj(HXLD objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HTuple RectangularityXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2186);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
