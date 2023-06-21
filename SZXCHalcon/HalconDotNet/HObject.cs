using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HObject : HObjectBase, ISerializable, ICloneable
	{
		public HObject this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HObject() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObject(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObject(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObject(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HObject obj)
		{
			obj = new HObject(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeObject();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObject(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeObject(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeObject();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HObject Deserialize(Stream stream)
		{
			HObject arg_0C_0 = new HObject();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeObject(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HObject Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeObject();
			HObject expr_0C = new HObject();
			expr_0C.DeserializeObject(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HObject ObjDiff(HObject objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public void IntegerToObj(HTuple surrogateTuple)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(581);
			SZXCArimAPI.Store(proc, 0, surrogateTuple);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(surrogateTuple);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void IntegerToObj(IntPtr surrogateTuple)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(581);
			SZXCArimAPI.StoreIP(proc, 0, surrogateTuple);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple ObjToInteger(int index, int number)
		{
			IntPtr proc = SZXCArimAPI.PreCall(582);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, number);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject ConcatObj(HObject objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public HObject SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HObject objects2, HTuple epsilon)
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

		public int CompareObj(HObject objects2, double epsilon)
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

		public int TestEqualObj(HObject objects2)
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

		public int CountObj()
		{
			IntPtr proc = SZXCArimAPI.PreCall(592);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetChannelInfo(string request, HTuple channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(593);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, request);
			SZXCArimAPI.Store(proc, 1, channel);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(channel);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string GetChannelInfo(string request, int channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(593);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, request);
			SZXCArimAPI.StoreI(proc, 1, channel);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetObjClass()
		{
			IntPtr proc = SZXCArimAPI.PreCall(594);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenEmptyObj()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(617);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DispObj(HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1276);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void ReadObject(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1646);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteObject(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1647);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeObject(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1648);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeObject()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1649);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject InsertObj(HObject objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public HObject RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject ReplaceObj(HObject objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HObject ReplaceObj(HObject objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}
	}
}
