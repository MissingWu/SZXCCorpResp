using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HDlModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("dl_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlModel obj)
		{
			obj = new HDlModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDlModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDlModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDlModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDlModel(string backbone, int numClasses, HDict DLModelDetectionParam)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2150);
			SZXCArimAPI.StoreS(proc, 0, backbone);
			SZXCArimAPI.StoreI(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, DLModelDetectionParam);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(DLModelDetectionParam);
		}

		public HDlModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2163);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeDlModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDlModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeDlModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeDlModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HDlModel Deserialize(Stream stream)
		{
			HDlModel arg_0C_0 = new HDlModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeDlModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HDlModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeDlModel();
			HDlModel expr_0C = new HDlModel();
			expr_0C.DeserializeDlModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HDict[] ApplyDlModel(HDict[] DLSampleBatch, HTuple outputs)
		{
			HTuple hTuple = HHandleBase.ConcatArray(DLSampleBatch);
			IntPtr proc = SZXCArimAPI.PreCall(2146);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hTuple);
			SZXCArimAPI.Store(proc, 2, outputs);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(outputs);
			HDict[] result;
			num = HDict.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(DLSampleBatch);
			return result;
		}

		public static void ClearDlModel(HDlModel[] DLModelHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(DLModelHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2147);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(DLModelHandle);
		}

		public void ClearDlModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2147);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateDlModelDetection(string backbone, int numClasses, HDict DLModelDetectionParam)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2150);
			SZXCArimAPI.StoreS(proc, 0, backbone);
			SZXCArimAPI.StoreI(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, DLModelDetectionParam);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(DLModelDetectionParam);
		}

		public void DeserializeDlModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2151);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HTuple GetDlModelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2156);
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

		public void ReadDlModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2163);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSerializedItem SerializeDlModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2168);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetDlModelParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2171);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDlModelParam(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2171);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HDict TrainDlModelBatch(HDict DLSampleBatch)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2172);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, DLSampleBatch);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HDict result;
			num = HDict.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(DLSampleBatch);
			return result;
		}

		public void WriteDlModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2174);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HDict[] GenDlModelHeatmap(HDict[] DLSample, string heatmapMethod, HTuple targetClasses, HDict genParam)
		{
			HTuple hTuple = HHandleBase.ConcatArray(DLSample);
			IntPtr proc = SZXCArimAPI.PreCall(2184);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hTuple);
			SZXCArimAPI.StoreS(proc, 2, heatmapMethod);
			SZXCArimAPI.Store(proc, 3, targetClasses);
			SZXCArimAPI.Store(proc, 4, genParam);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(targetClasses);
			HDict[] result;
			num = HDict.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(DLSample);
			GC.KeepAlive(genParam);
			return result;
		}

		public HDict TrainDlModelAnomalyDataset(HDict[] DLSamples, HDict DLTrainParam)
		{
			HTuple hTuple = HHandleBase.ConcatArray(DLSamples);
			IntPtr proc = SZXCArimAPI.PreCall(2189);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hTuple);
			SZXCArimAPI.Store(proc, 2, DLTrainParam);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			HDict result;
			num = HDict.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(DLSamples);
			GC.KeepAlive(DLTrainParam);
			return result;
		}
	}
}
