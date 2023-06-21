using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HHomMat3D : HData, ISerializable, ICloneable
	{
		private const int FIXEDSIZE = 12;

		public HHomMat3D(HTuple tuple) : base(tuple)
		{
		}

		internal HHomMat3D(HData data) : base(data)
		{
		}

		internal static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HHomMat3D obj)
		{
			HTuple t;
			err = HTuple.LoadNew(proc, parIndex, err, out t);
			obj = new HHomMat3D(new HData(t));
			return err;
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HHomMat3D obj)
		{
			return HHomMat3D.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
		}

		internal static HHomMat3D[] SplitArray(HTuple data)
		{
			int num = data.Length / 12;
			HHomMat3D[] array = new HHomMat3D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new HHomMat3D(new HData(data.TupleSelectRange(i * 12, (i + 1) * 12 - 1)));
			}
			return array;
		}

		public HHomMat3D()
		{
			IntPtr proc = SZXCArimAPI.PreCall(253);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeHomMat3d();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HHomMat3D(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeHomMat3d(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeHomMat3d();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HHomMat3D Deserialize(Stream stream)
		{
			HHomMat3D arg_0C_0 = new HHomMat3D();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeHomMat3d(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HHomMat3D Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeHomMat3d();
			HHomMat3D expr_0C = new HHomMat3D();
			expr_0C.DeserializeHomMat3d(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void DeserializeHomMat3d(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(233);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeHomMat3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(234);
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

		public HTuple ProjectiveTransHomPoint3d(HTuple px, HTuple py, HTuple pz, HTuple pw, out HTuple qy, out HTuple qz, out HTuple qw)
		{
			IntPtr proc = SZXCArimAPI.PreCall(239);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, pz);
			SZXCArimAPI.Store(proc, 4, pw);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			SZXCArimAPI.UnpinTuple(pw);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out qy);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out qz);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out qw);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double ProjectiveTransHomPoint3d(double px, double py, double pz, double pw, out double qy, out double qz, out double qw)
		{
			IntPtr proc = SZXCArimAPI.PreCall(239);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.StoreD(proc, 3, pz);
			SZXCArimAPI.StoreD(proc, 4, pw);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out qy);
			num = SZXCArimAPI.LoadD(proc, 2, num, out qz);
			num = SZXCArimAPI.LoadD(proc, 3, num, out qw);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ProjectiveTransPoint3d(HTuple px, HTuple py, HTuple pz, out HTuple qy, out HTuple qz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(240);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out qy);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out qz);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double ProjectiveTransPoint3d(double px, double py, double pz, out double qy, out double qz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(240);
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

		public HTuple AffineTransPoint3d(HTuple px, HTuple py, HTuple pz, out HTuple qy, out HTuple qz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(241);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out qy);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out qz);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double AffineTransPoint3d(double px, double py, double pz, out double qy, out double qz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(241);
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

		public void VectorToHomMat3d(string transformationType, HTuple px, HTuple py, HTuple pz, HTuple qx, HTuple qy, HTuple qz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(242);
			SZXCArimAPI.StoreS(proc, 0, transformationType);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, pz);
			SZXCArimAPI.Store(proc, 4, qx);
			SZXCArimAPI.Store(proc, 5, qy);
			SZXCArimAPI.Store(proc, 6, qz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			SZXCArimAPI.UnpinTuple(qz);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public double HomMat3dDeterminant()
		{
			IntPtr proc = SZXCArimAPI.PreCall(243);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dTranspose()
		{
			IntPtr proc = SZXCArimAPI.PreCall(244);
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

		public HHomMat3D HomMat3dInvert()
		{
			IntPtr proc = SZXCArimAPI.PreCall(245);
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

		public HHomMat3D HomMat3dCompose(HHomMat3D homMat3DRight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(246);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, homMat3DRight);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(homMat3DRight);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dRotateLocal(HTuple phi, HTuple axis)
		{
			IntPtr proc = SZXCArimAPI.PreCall(247);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, phi);
			SZXCArimAPI.Store(proc, 2, axis);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(axis);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dRotateLocal(double phi, string axis)
		{
			IntPtr proc = SZXCArimAPI.PreCall(247);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, phi);
			SZXCArimAPI.StoreS(proc, 2, axis);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dRotate(HTuple phi, HTuple axis, HTuple px, HTuple py, HTuple pz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(248);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, phi);
			SZXCArimAPI.Store(proc, 2, axis);
			SZXCArimAPI.Store(proc, 3, px);
			SZXCArimAPI.Store(proc, 4, py);
			SZXCArimAPI.Store(proc, 5, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(axis);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dRotate(double phi, string axis, double px, double py, double pz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(248);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, phi);
			SZXCArimAPI.StoreS(proc, 2, axis);
			SZXCArimAPI.StoreD(proc, 3, px);
			SZXCArimAPI.StoreD(proc, 4, py);
			SZXCArimAPI.StoreD(proc, 5, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dScaleLocal(HTuple sx, HTuple sy, HTuple sz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(249);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sx);
			SZXCArimAPI.Store(proc, 2, sy);
			SZXCArimAPI.Store(proc, 3, sz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(sx);
			SZXCArimAPI.UnpinTuple(sy);
			SZXCArimAPI.UnpinTuple(sz);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dScaleLocal(double sx, double sy, double sz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(249);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, sx);
			SZXCArimAPI.StoreD(proc, 2, sy);
			SZXCArimAPI.StoreD(proc, 3, sz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dScale(HTuple sx, HTuple sy, HTuple sz, HTuple px, HTuple py, HTuple pz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(250);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sx);
			SZXCArimAPI.Store(proc, 2, sy);
			SZXCArimAPI.Store(proc, 3, sz);
			SZXCArimAPI.Store(proc, 4, px);
			SZXCArimAPI.Store(proc, 5, py);
			SZXCArimAPI.Store(proc, 6, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(sx);
			SZXCArimAPI.UnpinTuple(sy);
			SZXCArimAPI.UnpinTuple(sz);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dScale(double sx, double sy, double sz, double px, double py, double pz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(250);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, sx);
			SZXCArimAPI.StoreD(proc, 2, sy);
			SZXCArimAPI.StoreD(proc, 3, sz);
			SZXCArimAPI.StoreD(proc, 4, px);
			SZXCArimAPI.StoreD(proc, 5, py);
			SZXCArimAPI.StoreD(proc, 6, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dTranslateLocal(HTuple tx, HTuple ty, HTuple tz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(251);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, tx);
			SZXCArimAPI.Store(proc, 2, ty);
			SZXCArimAPI.Store(proc, 3, tz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(tx);
			SZXCArimAPI.UnpinTuple(ty);
			SZXCArimAPI.UnpinTuple(tz);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dTranslateLocal(double tx, double ty, double tz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(251);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, tx);
			SZXCArimAPI.StoreD(proc, 2, ty);
			SZXCArimAPI.StoreD(proc, 3, tz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dTranslate(HTuple tx, HTuple ty, HTuple tz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(252);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, tx);
			SZXCArimAPI.Store(proc, 2, ty);
			SZXCArimAPI.Store(proc, 3, tz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(tx);
			SZXCArimAPI.UnpinTuple(ty);
			SZXCArimAPI.UnpinTuple(tz);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D HomMat3dTranslate(double tx, double ty, double tz)
		{
			IntPtr proc = SZXCArimAPI.PreCall(252);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, tx);
			SZXCArimAPI.StoreD(proc, 2, ty);
			SZXCArimAPI.StoreD(proc, 3, tz);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void HomMat3dIdentity()
		{
			IntPtr proc = SZXCArimAPI.PreCall(253);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HHomMat2D HomMat3dProject(HTuple principalPointRow, HTuple principalPointCol, HTuple focus)
		{
			IntPtr proc = SZXCArimAPI.PreCall(254);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, principalPointRow);
			SZXCArimAPI.Store(proc, 2, principalPointCol);
			SZXCArimAPI.Store(proc, 3, focus);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(principalPointRow);
			SZXCArimAPI.UnpinTuple(principalPointCol);
			SZXCArimAPI.UnpinTuple(focus);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat3dProject(double principalPointRow, double principalPointCol, double focus)
		{
			IntPtr proc = SZXCArimAPI.PreCall(254);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, principalPointRow);
			SZXCArimAPI.StoreD(proc, 2, principalPointCol);
			SZXCArimAPI.StoreD(proc, 3, focus);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ProjectHomPointHomMat3d(HTuple px, HTuple py, HTuple pz, HTuple pw, out HTuple qy, out HTuple qw)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1930);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, pz);
			SZXCArimAPI.Store(proc, 4, pw);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			SZXCArimAPI.UnpinTuple(pw);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out qy);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out qw);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double ProjectHomPointHomMat3d(double px, double py, double pz, double pw, out double qy, out double qw)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1930);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.StoreD(proc, 3, pz);
			SZXCArimAPI.StoreD(proc, 4, pw);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out qy);
			num = SZXCArimAPI.LoadD(proc, 2, num, out qw);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ProjectPointHomMat3d(HTuple px, HTuple py, HTuple pz, out HTuple qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1931);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pz);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out qy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double ProjectPointHomMat3d(double px, double py, double pz, out double qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1931);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.StoreD(proc, 3, pz);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out qy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose HomMat3dToPose()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1934);
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
	}
}
