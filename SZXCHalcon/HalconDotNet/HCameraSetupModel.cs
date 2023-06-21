using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HCameraSetupModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCameraSetupModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCameraSetupModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCameraSetupModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("camera_setup_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCameraSetupModel obj)
		{
			obj = new HCameraSetupModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCameraSetupModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HCameraSetupModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HCameraSetupModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HCameraSetupModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1954);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HCameraSetupModel(int numCameras)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1958);
			SZXCArimAPI.StoreI(proc, 0, numCameras);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeCameraSetupModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCameraSetupModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeCameraSetupModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeCameraSetupModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HCameraSetupModel Deserialize(Stream stream)
		{
			HCameraSetupModel arg_0C_0 = new HCameraSetupModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeCameraSetupModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HCameraSetupModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeCameraSetupModel();
			HCameraSetupModel expr_0C = new HCameraSetupModel();
			expr_0C.DeserializeCameraSetupModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HStereoModel CreateStereoModel(string method, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(527);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HStereoModel result;
			num = HStereoModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HStereoModel CreateStereoModel(string method, string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(527);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HStereoModel result;
			num = HStereoModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ClearCameraSetupModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1950);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HSerializedItem SerializeCameraSetupModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1951);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeCameraSetupModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1952);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public void WriteCameraSetupModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1953);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadCameraSetupModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1954);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetCameraSetupParam(HTuple cameraIdx, string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1955);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetCameraSetupParam(int cameraIdx, string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1955);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetCameraSetupParam(HTuple cameraIdx, string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1956);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCameraSetupParam(int cameraIdx, string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1956);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCameraSetupCamParam(HTuple cameraIdx, HTuple cameraType, HCamPar cameraParam, HTuple cameraPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1957);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.Store(proc, 2, cameraType);
			SZXCArimAPI.Store(proc, 3, cameraParam);
			SZXCArimAPI.Store(proc, 4, cameraPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraType);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(cameraPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCameraSetupCamParam(HTuple cameraIdx, string cameraType, HCamPar cameraParam, HTuple cameraPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1957);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, cameraType);
			SZXCArimAPI.Store(proc, 3, cameraParam);
			SZXCArimAPI.Store(proc, 4, cameraPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(cameraPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateCameraSetupModel(int numCameras)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1958);
			SZXCArimAPI.StoreI(proc, 0, numCameras);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
