using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HShapeModel3D : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel3D() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel3D(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel3D(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("shape_model_3d");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel3D obj)
		{
			obj = new HShapeModel3D(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel3D[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HShapeModel3D[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HShapeModel3D(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HShapeModel3D(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1052);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HShapeModel3D(HObjectModel3D objectModel3D, HCamPar camParam, double refRotX, double refRotY, double refRotZ, string orderOfRotation, double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, double camRollMin, double camRollMax, double distMin, double distMax, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1059);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.StoreD(proc, 2, refRotX);
			SZXCArimAPI.StoreD(proc, 3, refRotY);
			SZXCArimAPI.StoreD(proc, 4, refRotZ);
			SZXCArimAPI.StoreS(proc, 5, orderOfRotation);
			SZXCArimAPI.StoreD(proc, 6, longitudeMin);
			SZXCArimAPI.StoreD(proc, 7, longitudeMax);
			SZXCArimAPI.StoreD(proc, 8, latitudeMin);
			SZXCArimAPI.StoreD(proc, 9, latitudeMax);
			SZXCArimAPI.StoreD(proc, 10, camRollMin);
			SZXCArimAPI.StoreD(proc, 11, camRollMax);
			SZXCArimAPI.StoreD(proc, 12, distMin);
			SZXCArimAPI.StoreD(proc, 13, distMax);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public HShapeModel3D(HObjectModel3D objectModel3D, HCamPar camParam, double refRotX, double refRotY, double refRotZ, string orderOfRotation, double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, double camRollMin, double camRollMax, double distMin, double distMax, int minContrast, string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1059);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.StoreD(proc, 2, refRotX);
			SZXCArimAPI.StoreD(proc, 3, refRotY);
			SZXCArimAPI.StoreD(proc, 4, refRotZ);
			SZXCArimAPI.StoreS(proc, 5, orderOfRotation);
			SZXCArimAPI.StoreD(proc, 6, longitudeMin);
			SZXCArimAPI.StoreD(proc, 7, longitudeMax);
			SZXCArimAPI.StoreD(proc, 8, latitudeMin);
			SZXCArimAPI.StoreD(proc, 9, latitudeMax);
			SZXCArimAPI.StoreD(proc, 10, camRollMin);
			SZXCArimAPI.StoreD(proc, 11, camRollMax);
			SZXCArimAPI.StoreD(proc, 12, distMin);
			SZXCArimAPI.StoreD(proc, 13, distMax);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.StoreS(proc, 15, genParamName);
			SZXCArimAPI.StoreI(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeShapeModel3d();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel3D(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeShapeModel3d(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeShapeModel3d();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HShapeModel3D Deserialize(Stream stream)
		{
			HShapeModel3D arg_0C_0 = new HShapeModel3D();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeShapeModel3d(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HShapeModel3D Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeShapeModel3d();
			HShapeModel3D expr_0C = new HShapeModel3D();
			expr_0C.DeserializeShapeModel3d(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static void ClearShapeModel3d(HShapeModel3D[] shapeModel3DID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(shapeModel3DID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1049);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(shapeModel3DID);
		}

		public void ClearShapeModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1049);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeShapeModel3d(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1050);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeShapeModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1051);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadShapeModel3d(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1052);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteShapeModel3d(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1053);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HPose TransPoseShapeModel3d(HPose poseIn, string transformation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1054);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, poseIn);
			SZXCArimAPI.StoreS(proc, 2, transformation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(poseIn);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ProjectShapeModel3d(HCamPar camParam, HPose pose, string hiddenSurfaceRemoval, HTuple minFaceAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1055);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
			SZXCArimAPI.Store(proc, 4, minFaceAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(minFaceAngle);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ProjectShapeModel3d(HCamPar camParam, HPose pose, string hiddenSurfaceRemoval, double minFaceAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1055);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
			SZXCArimAPI.StoreD(proc, 4, minFaceAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GetShapeModel3dContours(int level, int view, out HPose viewPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1056);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, level);
			SZXCArimAPI.StoreI(proc, 2, view);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HPose.LoadNew(proc, 0, num, out viewPose);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetShapeModel3dParams(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1057);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetShapeModel3dParams(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1057);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] FindShapeModel3d(HImage image, double minScore, double greediness, HTuple numLevels, HTuple genParamName, HTuple genParamValue, out HTuple covPose, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1058);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, minScore);
			SZXCArimAPI.StoreD(proc, 2, greediness);
			SZXCArimAPI.Store(proc, 3, numLevels);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_B6_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return arg_B6_0;
		}

		public void CreateShapeModel3d(HObjectModel3D objectModel3D, HCamPar camParam, double refRotX, double refRotY, double refRotZ, string orderOfRotation, double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, double camRollMin, double camRollMax, double distMin, double distMax, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1059);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.StoreD(proc, 2, refRotX);
			SZXCArimAPI.StoreD(proc, 3, refRotY);
			SZXCArimAPI.StoreD(proc, 4, refRotZ);
			SZXCArimAPI.StoreS(proc, 5, orderOfRotation);
			SZXCArimAPI.StoreD(proc, 6, longitudeMin);
			SZXCArimAPI.StoreD(proc, 7, longitudeMax);
			SZXCArimAPI.StoreD(proc, 8, latitudeMin);
			SZXCArimAPI.StoreD(proc, 9, latitudeMax);
			SZXCArimAPI.StoreD(proc, 10, camRollMin);
			SZXCArimAPI.StoreD(proc, 11, camRollMax);
			SZXCArimAPI.StoreD(proc, 12, distMin);
			SZXCArimAPI.StoreD(proc, 13, distMax);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public void CreateShapeModel3d(HObjectModel3D objectModel3D, HCamPar camParam, double refRotX, double refRotY, double refRotZ, string orderOfRotation, double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, double camRollMin, double camRollMax, double distMin, double distMax, int minContrast, string genParamName, int genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1059);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.StoreD(proc, 2, refRotX);
			SZXCArimAPI.StoreD(proc, 3, refRotY);
			SZXCArimAPI.StoreD(proc, 4, refRotZ);
			SZXCArimAPI.StoreS(proc, 5, orderOfRotation);
			SZXCArimAPI.StoreD(proc, 6, longitudeMin);
			SZXCArimAPI.StoreD(proc, 7, longitudeMax);
			SZXCArimAPI.StoreD(proc, 8, latitudeMin);
			SZXCArimAPI.StoreD(proc, 9, latitudeMax);
			SZXCArimAPI.StoreD(proc, 10, camRollMin);
			SZXCArimAPI.StoreD(proc, 11, camRollMax);
			SZXCArimAPI.StoreD(proc, 12, distMin);
			SZXCArimAPI.StoreD(proc, 13, distMax);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.StoreS(proc, 15, genParamName);
			SZXCArimAPI.StoreI(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}
	}
}
