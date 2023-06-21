using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HCalibData : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCalibData() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCalibData(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCalibData(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("calib_data");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCalibData obj)
		{
			obj = new HCalibData(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCalibData[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HCalibData[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HCalibData(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HCalibData(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1963);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HCalibData(string calibSetup, int numCameras, int numCalibObjects)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1980);
			SZXCArimAPI.StoreS(proc, 0, calibSetup);
			SZXCArimAPI.StoreI(proc, 1, numCameras);
			SZXCArimAPI.StoreI(proc, 2, numCalibObjects);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeCalibData();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCalibData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeCalibData(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeCalibData();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HCalibData Deserialize(Stream stream)
		{
			HCalibData arg_0C_0 = new HCalibData();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeCalibData(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HCalibData Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeCalibData();
			HCalibData expr_0C = new HCalibData();
			expr_0C.DeserializeCalibData(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void ClearCalibData()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1960);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeCalibData(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1961);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeCalibData()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1962);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadCalibData(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1963);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteCalibData(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1964);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple CalibrateHandEye()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1965);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double CalibrateCameras()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1966);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void RemoveCalibData(string itemType, HTuple itemIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1967);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, itemType);
			SZXCArimAPI.Store(proc, 2, itemIdx);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(itemIdx);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveCalibData(string itemType, int itemIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1967);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, itemType);
			SZXCArimAPI.StoreI(proc, 2, itemIdx);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCalibData(string itemType, HTuple itemIdx, string dataName, HTuple dataValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1968);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, itemType);
			SZXCArimAPI.Store(proc, 2, itemIdx);
			SZXCArimAPI.StoreS(proc, 3, dataName);
			SZXCArimAPI.Store(proc, 4, dataValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(itemIdx);
			SZXCArimAPI.UnpinTuple(dataValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCalibData(string itemType, int itemIdx, string dataName, string dataValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1968);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, itemType);
			SZXCArimAPI.StoreI(proc, 2, itemIdx);
			SZXCArimAPI.StoreS(proc, 3, dataName);
			SZXCArimAPI.StoreS(proc, 4, dataValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void FindCalibObject(HImage image, int cameraIdx, int calibObjIdx, int calibObjPoseIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1969);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreI(proc, 2, calibObjIdx);
			SZXCArimAPI.StoreI(proc, 3, calibObjPoseIdx);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void RemoveCalibDataObserv(int cameraIdx, int calibObjIdx, int calibObjPoseIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1970);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreI(proc, 2, calibObjIdx);
			SZXCArimAPI.StoreI(proc, 3, calibObjPoseIdx);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HXLDCont GetCalibDataObservContours(string contourName, int cameraIdx, int calibObjIdx, int calibObjPoseIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1971);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, contourName);
			SZXCArimAPI.StoreI(proc, 2, cameraIdx);
			SZXCArimAPI.StoreI(proc, 3, calibObjIdx);
			SZXCArimAPI.StoreI(proc, 4, calibObjPoseIdx);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose GetCalibDataObservPose(int cameraIdx, int calibObjIdx, int calibObjPoseIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1972);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreI(proc, 2, calibObjIdx);
			SZXCArimAPI.StoreI(proc, 3, calibObjPoseIdx);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetCalibDataObservPose(int cameraIdx, int calibObjIdx, int calibObjPoseIdx, HPose objInCameraPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1973);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreI(proc, 2, calibObjIdx);
			SZXCArimAPI.StoreI(proc, 3, calibObjPoseIdx);
			SZXCArimAPI.Store(proc, 4, objInCameraPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objInCameraPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GetCalibDataObservPoints(int cameraIdx, int calibObjIdx, int calibObjPoseIdx, out HTuple row, out HTuple column, out HTuple index, out HTuple pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1974);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreI(proc, 2, calibObjIdx);
			SZXCArimAPI.StoreI(proc, 3, calibObjPoseIdx);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, num, out row);
			num = HTuple.LoadNew(proc, 1, num, out column);
			num = HTuple.LoadNew(proc, 2, num, out index);
			num = HTuple.LoadNew(proc, 3, num, out pose);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SetCalibDataObservPoints(int cameraIdx, int calibObjIdx, int calibObjPoseIdx, HTuple row, HTuple column, HTuple index, HTuple pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1975);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIdx);
			SZXCArimAPI.StoreI(proc, 2, calibObjIdx);
			SZXCArimAPI.StoreI(proc, 3, calibObjPoseIdx);
			SZXCArimAPI.Store(proc, 4, row);
			SZXCArimAPI.Store(proc, 5, column);
			SZXCArimAPI.Store(proc, 6, index);
			SZXCArimAPI.Store(proc, 7, pose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple QueryCalibDataObservIndices(string itemType, int itemIdx, out HTuple index2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1976);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, itemType);
			SZXCArimAPI.StoreI(proc, 2, itemIdx);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out index2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetCalibData(string itemType, HTuple itemIdx, HTuple dataName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1977);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, itemType);
			SZXCArimAPI.Store(proc, 2, itemIdx);
			SZXCArimAPI.Store(proc, 3, dataName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(itemIdx);
			SZXCArimAPI.UnpinTuple(dataName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetCalibData(string itemType, int itemIdx, string dataName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1977);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, itemType);
			SZXCArimAPI.StoreI(proc, 2, itemIdx);
			SZXCArimAPI.StoreS(proc, 3, dataName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetCalibDataCalibObject(int calibObjIdx, HTuple calibObjDescr)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1978);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, calibObjIdx);
			SZXCArimAPI.Store(proc, 2, calibObjDescr);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(calibObjDescr);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCalibDataCalibObject(int calibObjIdx, double calibObjDescr)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1978);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, calibObjIdx);
			SZXCArimAPI.StoreD(proc, 2, calibObjDescr);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCalibDataCamParam(HTuple cameraIdx, HTuple cameraType, HCamPar cameraParam)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1979);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.Store(proc, 2, cameraType);
			SZXCArimAPI.Store(proc, 3, cameraParam);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraType);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetCalibDataCamParam(HTuple cameraIdx, string cameraType, HCamPar cameraParam)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1979);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, cameraType);
			SZXCArimAPI.Store(proc, 3, cameraParam);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateCalibData(string calibSetup, int numCameras, int numCalibObjects)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1980);
			SZXCArimAPI.StoreS(proc, 0, calibSetup);
			SZXCArimAPI.StoreI(proc, 1, numCameras);
			SZXCArimAPI.StoreI(proc, 2, numCalibObjects);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
