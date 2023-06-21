using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HDescriptorModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDescriptorModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDescriptorModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDescriptorModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("descriptor_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDescriptorModel obj)
		{
			obj = new HDescriptorModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDescriptorModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDescriptorModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDescriptorModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDescriptorModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(946);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDescriptorModel(HImage template, HCamPar camParam, HPose referencePose, string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(952);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreS(proc, 2, detectorType);
			SZXCArimAPI.Store(proc, 3, detectorParamName);
			SZXCArimAPI.Store(proc, 4, detectorParamValue);
			SZXCArimAPI.Store(proc, 5, descriptorParamName);
			SZXCArimAPI.Store(proc, 6, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 7, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HDescriptorModel(HImage template, string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(953);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreS(proc, 0, detectorType);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 5, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeDescriptorModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDescriptorModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeDescriptorModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeDescriptorModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HDescriptorModel Deserialize(Stream stream)
		{
			HDescriptorModel arg_0C_0 = new HDescriptorModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeDescriptorModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HDescriptorModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeDescriptorModel();
			HDescriptorModel expr_0C = new HDescriptorModel();
			expr_0C.DeserializeDescriptorModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static void ClearDescriptorModel(HDescriptorModel[] modelID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(943);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(modelID);
		}

		public void ClearDescriptorModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(943);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeDescriptorModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(944);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeDescriptorModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(945);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadDescriptorModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(946);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteDescriptorModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(947);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HPose[] FindCalibDescriptorModel(HImage image, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, HTuple minScore, int numMatches, HCamPar camParam, HTuple scoreType, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(948);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.Store(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 7, camParam);
			SZXCArimAPI.Store(proc, 8, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(scoreType);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_E0_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return arg_E0_0;
		}

		public HPose FindCalibDescriptorModel(HImage image, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, double minScore, int numMatches, HCamPar camParam, string scoreType, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(948);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreD(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 7, camParam);
			SZXCArimAPI.StoreS(proc, 8, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			SZXCArimAPI.UnpinTuple(camParam);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HHomMat2D[] FindUncalibDescriptorModel(HImage image, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, HTuple minScore, int numMatches, HTuple scoreType, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(949);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.Store(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 7, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(scoreType);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			HHomMat2D[] arg_C6_0 = HHomMat2D.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return arg_C6_0;
		}

		public HHomMat2D FindUncalibDescriptorModel(HImage image, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, double minScore, int numMatches, string scoreType, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(949);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreD(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.StoreS(proc, 7, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void GetDescriptorModelPoints(string set, HTuple subset, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(950);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, set);
			SZXCArimAPI.Store(proc, 2, subset);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(subset);
			num = HTuple.LoadNew(proc, 0, num, out row);
			num = HTuple.LoadNew(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetDescriptorModelPoints(string set, int subset, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(950);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, set);
			SZXCArimAPI.StoreI(proc, 2, subset);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, num, out row);
			num = HTuple.LoadNew(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public string GetDescriptorModelParams(out HTuple detectorParamName, out HTuple detectorParamValue, out HTuple descriptorParamName, out HTuple descriptorParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(951);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out detectorParamName);
			num = HTuple.LoadNew(proc, 2, num, out detectorParamValue);
			num = HTuple.LoadNew(proc, 3, num, out descriptorParamName);
			num = HTuple.LoadNew(proc, 4, num, out descriptorParamValue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateCalibDescriptorModel(HImage template, HCamPar camParam, HPose referencePose, string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(952);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreS(proc, 2, detectorType);
			SZXCArimAPI.Store(proc, 3, detectorParamName);
			SZXCArimAPI.Store(proc, 4, detectorParamValue);
			SZXCArimAPI.Store(proc, 5, descriptorParamName);
			SZXCArimAPI.Store(proc, 6, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 7, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateUncalibDescriptorModel(HImage template, string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(953);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreS(proc, 0, detectorType);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 5, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HTuple GetDescriptorModelResults(HTuple objectID, string resultNames)
		{
			IntPtr proc = SZXCArimAPI.PreCall(954);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectID);
			SZXCArimAPI.StoreS(proc, 2, resultNames);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectID);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetDescriptorModelResults(int objectID, string resultNames)
		{
			IntPtr proc = SZXCArimAPI.PreCall(954);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, objectID);
			SZXCArimAPI.StoreS(proc, 2, resultNames);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetDescriptorModelOrigin(out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(955);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, num, out row);
			num = HTuple.LoadNew(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetDescriptorModelOrigin(out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(955);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SetDescriptorModelOrigin(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(956);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDescriptorModelOrigin(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(956);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}
	}
}
