using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HDualQuaternion : HData, ISerializable, ICloneable
	{
		private const int FIXEDSIZE = 8;

		public HDualQuaternion()
		{
		}

		public HDualQuaternion(HTuple tuple) : base(tuple)
		{
		}

		internal HDualQuaternion(HData data) : base(data)
		{
		}

		internal static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HDualQuaternion obj)
		{
			HTuple t;
			err = HTuple.LoadNew(proc, parIndex, err, out t);
			obj = new HDualQuaternion(new HData(t));
			return err;
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDualQuaternion obj)
		{
			return HDualQuaternion.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
		}

		internal static HDualQuaternion[] SplitArray(HTuple data)
		{
			int num = data.Length / 8;
			HDualQuaternion[] array = new HDualQuaternion[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new HDualQuaternion(new HData(data.TupleSelectRange(i * 8, (i + 1) * 8 - 1)));
			}
			return array;
		}

		public HDualQuaternion(HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2080);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDualQuaternion(string screwFormat, HTuple axisDirectionX, HTuple axisDirectionY, HTuple axisDirectionZ, HTuple axisMomentOrPointX, HTuple axisMomentOrPointY, HTuple axisMomentOrPointZ, HTuple rotation, HTuple translation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2086);
			SZXCArimAPI.StoreS(proc, 0, screwFormat);
			SZXCArimAPI.Store(proc, 1, axisDirectionX);
			SZXCArimAPI.Store(proc, 2, axisDirectionY);
			SZXCArimAPI.Store(proc, 3, axisDirectionZ);
			SZXCArimAPI.Store(proc, 4, axisMomentOrPointX);
			SZXCArimAPI.Store(proc, 5, axisMomentOrPointY);
			SZXCArimAPI.Store(proc, 6, axisMomentOrPointZ);
			SZXCArimAPI.Store(proc, 7, rotation);
			SZXCArimAPI.Store(proc, 8, translation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(axisDirectionX);
			SZXCArimAPI.UnpinTuple(axisDirectionY);
			SZXCArimAPI.UnpinTuple(axisDirectionZ);
			SZXCArimAPI.UnpinTuple(axisMomentOrPointX);
			SZXCArimAPI.UnpinTuple(axisMomentOrPointY);
			SZXCArimAPI.UnpinTuple(axisMomentOrPointZ);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(translation);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDualQuaternion(string screwFormat, double axisDirectionX, double axisDirectionY, double axisDirectionZ, double axisMomentOrPointX, double axisMomentOrPointY, double axisMomentOrPointZ, double rotation, double translation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2086);
			SZXCArimAPI.StoreS(proc, 0, screwFormat);
			SZXCArimAPI.StoreD(proc, 1, axisDirectionX);
			SZXCArimAPI.StoreD(proc, 2, axisDirectionY);
			SZXCArimAPI.StoreD(proc, 3, axisDirectionZ);
			SZXCArimAPI.StoreD(proc, 4, axisMomentOrPointX);
			SZXCArimAPI.StoreD(proc, 5, axisMomentOrPointY);
			SZXCArimAPI.StoreD(proc, 6, axisMomentOrPointZ);
			SZXCArimAPI.StoreD(proc, 7, rotation);
			SZXCArimAPI.StoreD(proc, 8, translation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeDualQuat();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDualQuaternion(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeDualQuat(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeDualQuat();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HDualQuaternion Deserialize(Stream stream)
		{
			HDualQuaternion arg_0C_0 = new HDualQuaternion();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeDualQuat(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HDualQuaternion Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeDualQuat();
			HDualQuaternion expr_0C = new HDualQuaternion();
			expr_0C.DeserializeDualQuat(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static HDualQuaternion operator *(HDualQuaternion left, HDualQuaternion right)
		{
			return left.DualQuatCompose(right);
		}

		public static implicit operator HPose(HDualQuaternion dualQuaternion)
		{
			return dualQuaternion.DualQuatToPose();
		}

		public static implicit operator HHomMat3D(HDualQuaternion dualQuaternion)
		{
			return dualQuaternion.DualQuatToHomMat3d();
		}

		public static HDualQuaternion operator ~(HDualQuaternion dualQuaternion)
		{
			return dualQuaternion.DualQuatConjugate();
		}

		public HDualQuaternion(double realW, double realX, double realY, double realZ, double dualW, double dualX, double dualY, double dualZ) : base(new HTuple(new double[]
		{
			realW,
			realX,
			realY,
			realZ,
			dualW,
			dualX,
			dualY,
			dualZ
		}))
		{
		}

		public HDualQuaternion(HQuaternion quat1, HQuaternion quat2) : base(quat1.RawData.TupleConcat(quat2.RawData))
		{
		}

		public void DeserializeDualQuat(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2052);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public static HDualQuaternion[] DualQuatCompose(HDualQuaternion[] dualQuaternionLeft, HDualQuaternion[] dualQuaternionRight)
		{
			HTuple hTuple = HData.ConcatArray(dualQuaternionLeft);
			HTuple hTuple2 = HData.ConcatArray(dualQuaternionRight);
			IntPtr expr_20 = SZXCArimAPI.PreCall(2059);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, hTuple2);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HTuple data;
			num = HTuple.LoadNew(expr_20, 0, num, out data);
			SZXCArimAPI.PostCall(expr_20, num);
			return HDualQuaternion.SplitArray(data);
		}

		public HDualQuaternion DualQuatCompose(HDualQuaternion dualQuaternionRight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2059);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, dualQuaternionRight);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(dualQuaternionRight);
			HDualQuaternion result;
			num = HDualQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HDualQuaternion[] DualQuatConjugate(HDualQuaternion[] dualQuaternion)
		{
			HTuple hTuple = HData.ConcatArray(dualQuaternion);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2060);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			SZXCArimAPI.PostCall(expr_13, num);
			return HDualQuaternion.SplitArray(data);
		}

		public HDualQuaternion DualQuatConjugate()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2060);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HDualQuaternion result;
			num = HDualQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDualQuaternion[] DualQuatInterpolate(HDualQuaternion dualQuaternionEnd, HTuple interpPos)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2061);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, dualQuaternionEnd);
			SZXCArimAPI.Store(proc, 2, interpPos);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(dualQuaternionEnd);
			SZXCArimAPI.UnpinTuple(interpPos);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			HDualQuaternion[] arg_6C_0 = HDualQuaternion.SplitArray(data);
			GC.KeepAlive(this);
			return arg_6C_0;
		}

		public HDualQuaternion DualQuatInterpolate(HDualQuaternion dualQuaternionEnd, double interpPos)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2061);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, dualQuaternionEnd);
			SZXCArimAPI.StoreD(proc, 2, interpPos);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(dualQuaternionEnd);
			HDualQuaternion result;
			num = HDualQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HDualQuaternion[] DualQuatNormalize(HDualQuaternion[] dualQuaternion)
		{
			HTuple hTuple = HData.ConcatArray(dualQuaternion);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2062);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			SZXCArimAPI.PostCall(expr_13, num);
			return HDualQuaternion.SplitArray(data);
		}

		public HDualQuaternion DualQuatNormalize()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2062);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HDualQuaternion result;
			num = HDualQuaternion.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D DualQuatToHomMat3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2063);
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

		public static HPose[] DualQuatToPose(HDualQuaternion[] dualQuaternion)
		{
			HTuple hTuple = HData.ConcatArray(dualQuaternion);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2064);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			SZXCArimAPI.PostCall(expr_13, num);
			return HPose.SplitArray(data);
		}

		public HPose DualQuatToPose()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2064);
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

		public void DualQuatToScrew(string screwFormat, out double axisDirectionX, out double axisDirectionY, out double axisDirectionZ, out double axisMomentOrPointX, out double axisMomentOrPointY, out double axisMomentOrPointZ, out double rotation, out double translation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2065);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, screwFormat);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = SZXCArimAPI.LoadD(proc, 0, num, out axisDirectionX);
			num = SZXCArimAPI.LoadD(proc, 1, num, out axisDirectionY);
			num = SZXCArimAPI.LoadD(proc, 2, num, out axisDirectionZ);
			num = SZXCArimAPI.LoadD(proc, 3, num, out axisMomentOrPointX);
			num = SZXCArimAPI.LoadD(proc, 4, num, out axisMomentOrPointY);
			num = SZXCArimAPI.LoadD(proc, 5, num, out axisMomentOrPointZ);
			num = SZXCArimAPI.LoadD(proc, 6, num, out rotation);
			num = SZXCArimAPI.LoadD(proc, 7, num, out translation);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DualQuatTransLine3d(string lineFormat, HTuple lineDirectionX, HTuple lineDirectionY, HTuple lineDirectionZ, HTuple lineMomentOrPointX, HTuple lineMomentOrPointY, HTuple lineMomentOrPointZ, out HTuple transLineDirectionX, out HTuple transLineDirectionY, out HTuple transLineDirectionZ, out HTuple transLineMomentOrPointX, out HTuple transLineMomentOrPointY, out HTuple transLineMomentOrPointZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2066);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, lineFormat);
			SZXCArimAPI.Store(proc, 2, lineDirectionX);
			SZXCArimAPI.Store(proc, 3, lineDirectionY);
			SZXCArimAPI.Store(proc, 4, lineDirectionZ);
			SZXCArimAPI.Store(proc, 5, lineMomentOrPointX);
			SZXCArimAPI.Store(proc, 6, lineMomentOrPointY);
			SZXCArimAPI.Store(proc, 7, lineMomentOrPointZ);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(lineDirectionX);
			SZXCArimAPI.UnpinTuple(lineDirectionY);
			SZXCArimAPI.UnpinTuple(lineDirectionZ);
			SZXCArimAPI.UnpinTuple(lineMomentOrPointX);
			SZXCArimAPI.UnpinTuple(lineMomentOrPointY);
			SZXCArimAPI.UnpinTuple(lineMomentOrPointZ);
			num = HTuple.LoadNew(proc, 0, num, out transLineDirectionX);
			num = HTuple.LoadNew(proc, 1, num, out transLineDirectionY);
			num = HTuple.LoadNew(proc, 2, num, out transLineDirectionZ);
			num = HTuple.LoadNew(proc, 3, num, out transLineMomentOrPointX);
			num = HTuple.LoadNew(proc, 4, num, out transLineMomentOrPointY);
			num = HTuple.LoadNew(proc, 5, num, out transLineMomentOrPointZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DualQuatTransLine3d(string lineFormat, double lineDirectionX, double lineDirectionY, double lineDirectionZ, double lineMomentOrPointX, double lineMomentOrPointY, double lineMomentOrPointZ, out double transLineDirectionX, out double transLineDirectionY, out double transLineDirectionZ, out double transLineMomentOrPointX, out double transLineMomentOrPointY, out double transLineMomentOrPointZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2066);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, lineFormat);
			SZXCArimAPI.StoreD(proc, 2, lineDirectionX);
			SZXCArimAPI.StoreD(proc, 3, lineDirectionY);
			SZXCArimAPI.StoreD(proc, 4, lineDirectionZ);
			SZXCArimAPI.StoreD(proc, 5, lineMomentOrPointX);
			SZXCArimAPI.StoreD(proc, 6, lineMomentOrPointY);
			SZXCArimAPI.StoreD(proc, 7, lineMomentOrPointZ);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = SZXCArimAPI.LoadD(proc, 0, num, out transLineDirectionX);
			num = SZXCArimAPI.LoadD(proc, 1, num, out transLineDirectionY);
			num = SZXCArimAPI.LoadD(proc, 2, num, out transLineDirectionZ);
			num = SZXCArimAPI.LoadD(proc, 3, num, out transLineMomentOrPointX);
			num = SZXCArimAPI.LoadD(proc, 4, num, out transLineMomentOrPointY);
			num = SZXCArimAPI.LoadD(proc, 5, num, out transLineMomentOrPointZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HDualQuaternion[] PoseToDualQuat(HPose[] pose)
		{
			HTuple hTuple = HData.ConcatArray(pose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2080);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			SZXCArimAPI.PostCall(expr_13, num);
			return HDualQuaternion.SplitArray(data);
		}

		public void PoseToDualQuat(HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2080);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ScrewToDualQuat(string screwFormat, HTuple axisDirectionX, HTuple axisDirectionY, HTuple axisDirectionZ, HTuple axisMomentOrPointX, HTuple axisMomentOrPointY, HTuple axisMomentOrPointZ, HTuple rotation, HTuple translation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2086);
			SZXCArimAPI.StoreS(proc, 0, screwFormat);
			SZXCArimAPI.Store(proc, 1, axisDirectionX);
			SZXCArimAPI.Store(proc, 2, axisDirectionY);
			SZXCArimAPI.Store(proc, 3, axisDirectionZ);
			SZXCArimAPI.Store(proc, 4, axisMomentOrPointX);
			SZXCArimAPI.Store(proc, 5, axisMomentOrPointY);
			SZXCArimAPI.Store(proc, 6, axisMomentOrPointZ);
			SZXCArimAPI.Store(proc, 7, rotation);
			SZXCArimAPI.Store(proc, 8, translation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(axisDirectionX);
			SZXCArimAPI.UnpinTuple(axisDirectionY);
			SZXCArimAPI.UnpinTuple(axisDirectionZ);
			SZXCArimAPI.UnpinTuple(axisMomentOrPointX);
			SZXCArimAPI.UnpinTuple(axisMomentOrPointY);
			SZXCArimAPI.UnpinTuple(axisMomentOrPointZ);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(translation);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ScrewToDualQuat(string screwFormat, double axisDirectionX, double axisDirectionY, double axisDirectionZ, double axisMomentOrPointX, double axisMomentOrPointY, double axisMomentOrPointZ, double rotation, double translation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2086);
			SZXCArimAPI.StoreS(proc, 0, screwFormat);
			SZXCArimAPI.StoreD(proc, 1, axisDirectionX);
			SZXCArimAPI.StoreD(proc, 2, axisDirectionY);
			SZXCArimAPI.StoreD(proc, 3, axisDirectionZ);
			SZXCArimAPI.StoreD(proc, 4, axisMomentOrPointX);
			SZXCArimAPI.StoreD(proc, 5, axisMomentOrPointY);
			SZXCArimAPI.StoreD(proc, 6, axisMomentOrPointZ);
			SZXCArimAPI.StoreD(proc, 7, rotation);
			SZXCArimAPI.StoreD(proc, 8, translation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSerializedItem SerializeDualQuat()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2092);
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
