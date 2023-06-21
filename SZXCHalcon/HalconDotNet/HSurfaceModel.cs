using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HSurfaceModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSurfaceModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSurfaceModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSurfaceModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("surface_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSurfaceModel obj)
		{
			obj = new HSurfaceModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSurfaceModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HSurfaceModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HSurfaceModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HSurfaceModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1039);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1044);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public HSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1044);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeSurfaceModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSurfaceModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeSurfaceModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeSurfaceModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HSurfaceModel Deserialize(Stream stream)
		{
			HSurfaceModel arg_0C_0 = new HSurfaceModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeSurfaceModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HSurfaceModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeSurfaceModel();
			HSurfaceModel expr_0C = new HSurfaceModel();
			expr_0C.DeserializeSurfaceModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static void ClearSurfaceModel(HSurfaceModel[] surfaceModelID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(surfaceModelID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1036);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(surfaceModelID);
		}

		public void ClearSurfaceModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1036);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeSurfaceModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1037);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeSurfaceModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1038);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadSurfaceModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1039);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteSurfaceModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1040);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HPose[] RefineSurfaceModelPose(HObjectModel3D objectModel3D, HPose[] initialPose, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			HTuple hTuple = HData.ConcatArray(initialPose);
			IntPtr proc = SZXCArimAPI.PreCall(1041);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, hTuple);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_C5_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return arg_C5_0;
		}

		public HPose RefineSurfaceModelPose(HObjectModel3D objectModel3D, HPose initialPose, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1041);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, initialPose);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(initialPose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HPose[] FindSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1042);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.Store(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_BE_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return arg_BE_0;
		}

		public HPose FindSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1042);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HTuple GetSurfaceModelParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1043);
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

		public HTuple GetSurfaceModelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1043);
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

		public void CreateSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1044);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public void CreateSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1044);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public HPose[] FindSurfaceModelImage(HImage image, HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2069);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.Store(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_CD_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(objectModel3D);
			return arg_CD_0;
		}

		public HPose FindSurfaceModelImage(HImage image, HObjectModel3D objectModel3D, double relSamplingDistance, double keyPointFraction, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2069);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HPose[] RefineSurfaceModelPoseImage(HImage image, HObjectModel3D objectModel3D, HPose[] initialPose, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			HTuple hTuple = HData.ConcatArray(initialPose);
			IntPtr proc = SZXCArimAPI.PreCall(2084);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, hTuple);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_D5_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(objectModel3D);
			return arg_D5_0;
		}

		public HPose RefineSurfaceModelPoseImage(HImage image, HObjectModel3D objectModel3D, HPose initialPose, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2084);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, initialPose);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(initialPose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public void SetSurfaceModelParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2097);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetSurfaceModelParam(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2097);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HPose[] FindBox3d(HObjectModel3D objectModel3DScene, HTuple sideLen1, HTuple sideLen2, HTuple sideLen3, HTuple minScore, HDict genParam, out HTuple score, out HObjectModel3D[] objectModel3DBox, out HDict boxInformation)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2181);
			SZXCArimAPI.Store(expr_0A, 0, objectModel3DScene);
			SZXCArimAPI.Store(expr_0A, 1, sideLen1);
			SZXCArimAPI.Store(expr_0A, 2, sideLen2);
			SZXCArimAPI.Store(expr_0A, 3, sideLen3);
			SZXCArimAPI.Store(expr_0A, 4, minScore);
			SZXCArimAPI.Store(expr_0A, 5, genParam);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(sideLen1);
			SZXCArimAPI.UnpinTuple(sideLen2);
			SZXCArimAPI.UnpinTuple(sideLen3);
			SZXCArimAPI.UnpinTuple(minScore);
			HTuple data;
			num = HTuple.LoadNew(expr_0A, 0, num, out data);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out score);
			num = HObjectModel3D.LoadNew(expr_0A, 2, num, out objectModel3DBox);
			num = HDict.LoadNew(expr_0A, 3, num, out boxInformation);
			SZXCArimAPI.PostCall(expr_0A, num);
			HPose[] arg_C2_0 = HPose.SplitArray(data);
			GC.KeepAlive(objectModel3DScene);
			GC.KeepAlive(genParam);
			return arg_C2_0;
		}

		public static HPose FindBox3d(HObjectModel3D objectModel3DScene, HTuple sideLen1, HTuple sideLen2, HTuple sideLen3, double minScore, HDict genParam, out HTuple score, out HObjectModel3D[] objectModel3DBox, out HDict boxInformation)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2181);
			SZXCArimAPI.Store(expr_0A, 0, objectModel3DScene);
			SZXCArimAPI.Store(expr_0A, 1, sideLen1);
			SZXCArimAPI.Store(expr_0A, 2, sideLen2);
			SZXCArimAPI.Store(expr_0A, 3, sideLen3);
			SZXCArimAPI.StoreD(expr_0A, 4, minScore);
			SZXCArimAPI.Store(expr_0A, 5, genParam);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(sideLen1);
			SZXCArimAPI.UnpinTuple(sideLen2);
			SZXCArimAPI.UnpinTuple(sideLen3);
			HPose result;
			num = HPose.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out score);
			num = HObjectModel3D.LoadNew(expr_0A, 2, num, out objectModel3DBox);
			num = HDict.LoadNew(expr_0A, 3, num, out boxInformation);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(objectModel3DScene);
			GC.KeepAlive(genParam);
			return result;
		}
	}
}
