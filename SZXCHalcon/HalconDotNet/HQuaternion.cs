using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HQuaternion : HData, ISerializable, ICloneable
	{
		private const int FIXEDSIZE = 4;

		public HQuaternion()
		{
		}

		public HQuaternion(HTuple tuple) : base(tuple)
		{
		}

		internal HQuaternion(HData data) : base(data)
		{
		}

		internal static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HQuaternion obj)
		{
			HTuple t;
			err = HTuple.LoadNew(proc, parIndex, err, out t);
			obj = new HQuaternion(new HData(t));
			return err;
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HQuaternion obj)
		{
			return HQuaternion.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
		}

		internal static HQuaternion[] SplitArray(HTuple data)
		{
			int num = data.Length / 4;
			HQuaternion[] array = new HQuaternion[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new HQuaternion(new HData(data.TupleSelectRange(i * 4, (i + 1) * 4 - 1)));
			}
			return array;
		}

		public HQuaternion(HTuple axisX, HTuple axisY, HTuple axisZ, HTuple angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(225);
			SZXCArimAPI.Store(proc, 0, axisX);
			SZXCArimAPI.Store(proc, 1, axisY);
			SZXCArimAPI.Store(proc, 2, axisZ);
			SZXCArimAPI.Store(proc, 3, angle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(axisX);
			SZXCArimAPI.UnpinTuple(axisY);
			SZXCArimAPI.UnpinTuple(axisZ);
			SZXCArimAPI.UnpinTuple(angle);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HQuaternion(double axisX, double axisY, double axisZ, double angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(225);
			SZXCArimAPI.StoreD(proc, 0, axisX);
			SZXCArimAPI.StoreD(proc, 1, axisY);
			SZXCArimAPI.StoreD(proc, 2, axisZ);
			SZXCArimAPI.StoreD(proc, 3, angle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeQuat();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HQuaternion(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeQuat(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeQuat();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HQuaternion Deserialize(Stream stream)
		{
			HQuaternion arg_0C_0 = new HQuaternion();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeQuat(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HQuaternion Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeQuat();
			HQuaternion expr_0C = new HQuaternion();
			expr_0C.DeserializeQuat(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static HQuaternion operator *(HQuaternion left, HQuaternion right)
		{
			return left.QuatCompose(right);
		}

		public static implicit operator HPose(HQuaternion quaternion)
		{
			return quaternion.QuatToPose();
		}

		public static implicit operator HHomMat3D(HQuaternion quaternion)
		{
			return quaternion.QuatToHomMat3d();
		}

		public static HQuaternion operator ~(HQuaternion quaternion)
		{
			return quaternion.QuatConjugate();
		}

		public double QuatRotatePoint3d(double px, double py, double pz, out double qy, out double qz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(222);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.StoreD(proc, 3, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out qy);
			num = SZXCArimAPI.LoadD(proc, 2, num, out qz);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HQuaternion QuatConjugate()
		{
			IntPtr proc = SZXCArimAPI.PreCall(223);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HQuaternion result;
			num = HQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HQuaternion QuatNormalize()
		{
			IntPtr proc = SZXCArimAPI.PreCall(224);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HQuaternion result;
			num = HQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AxisAngleToQuat(HTuple axisX, HTuple axisY, HTuple axisZ, HTuple angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(225);
			SZXCArimAPI.Store(proc, 0, axisX);
			SZXCArimAPI.Store(proc, 1, axisY);
			SZXCArimAPI.Store(proc, 2, axisZ);
			SZXCArimAPI.Store(proc, 3, angle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(axisX);
			SZXCArimAPI.UnpinTuple(axisY);
			SZXCArimAPI.UnpinTuple(axisZ);
			SZXCArimAPI.UnpinTuple(angle);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void AxisAngleToQuat(double axisX, double axisY, double axisZ, double angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(225);
			SZXCArimAPI.StoreD(proc, 0, axisX);
			SZXCArimAPI.StoreD(proc, 1, axisY);
			SZXCArimAPI.StoreD(proc, 2, axisZ);
			SZXCArimAPI.StoreD(proc, 3, angle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HPose QuatToPose()
		{
			IntPtr proc = SZXCArimAPI.PreCall(226);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D QuatToHomMat3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(229);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HQuaternion[] PoseToQuat(HPose[] pose)
		{
			HTuple hTuple = HData.ConcatArray(pose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(230);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			SZXCArimAPI.PostCall(expr_13, num);
			return HQuaternion.SplitArray(data);
		}

		public void PoseToQuat(HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(230);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HQuaternion QuatInterpolate(HQuaternion quaternionEnd, HTuple interpPos)
		{
			IntPtr proc = SZXCArimAPI.PreCall(231);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, quaternionEnd);
			SZXCArimAPI.Store(proc, 2, interpPos);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(quaternionEnd);
			SZXCArimAPI.UnpinTuple(interpPos);
			HQuaternion result;
			num = HQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HQuaternion QuatCompose(HQuaternion quaternionRight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(232);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, quaternionRight);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(quaternionRight);
			HQuaternion result;
			num = HQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeQuat(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(237);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeQuat()
		{
			IntPtr proc = SZXCArimAPI.PreCall(238);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
