using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HClassTrainData : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassTrainData() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassTrainData(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassTrainData(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("class_train_data");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassTrainData obj)
		{
			obj = new HClassTrainData(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassTrainData[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HClassTrainData[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HClassTrainData(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HClassTrainData(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1781);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassTrainData(int numDim)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1798);
			SZXCArimAPI.StoreI(proc, 0, numDim);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeClassTrainData();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassTrainData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeClassTrainData(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeClassTrainData();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HClassTrainData Deserialize(Stream stream)
		{
			HClassTrainData arg_0C_0 = new HClassTrainData();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeClassTrainData(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HClassTrainData Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeClassTrainData();
			HClassTrainData expr_0C = new HClassTrainData();
			expr_0C.DeserializeClassTrainData(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void DeserializeClassTrainData(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1779);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeClassTrainData()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1780);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadClassTrainData(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1781);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteClassTrainData(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1782);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HClassTrainData SelectSubFeatureClassTrainData(HTuple subFeatureIndices)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1783);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, subFeatureIndices);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(subFeatureIndices);
			HClassTrainData result;
			num = HClassTrainData.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetFeatureLengthsClassTrainData(HTuple subFeatureLength, HTuple names)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1784);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, subFeatureLength);
			SZXCArimAPI.Store(proc, 2, names);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(subFeatureLength);
			SZXCArimAPI.UnpinTuple(names);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GetClassTrainDataGmm(HClassGmm GMMHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1785);
			SZXCArimAPI.Store(proc, 0, GMMHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(GMMHandle);
		}

		public void AddClassTrainDataGmm(HClassGmm GMMHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1786);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, GMMHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(GMMHandle);
		}

		public void GetClassTrainDataMlp(HClassMlp MLPHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1787);
			SZXCArimAPI.Store(proc, 0, MLPHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(MLPHandle);
		}

		public void AddClassTrainDataMlp(HClassMlp MLPHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1788);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, MLPHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(MLPHandle);
		}

		public void GetClassTrainDataKnn(HClassKnn KNNHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1789);
			SZXCArimAPI.Store(proc, 0, KNNHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(KNNHandle);
		}

		public void AddClassTrainDataKnn(HClassKnn KNNHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1790);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, KNNHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(KNNHandle);
		}

		public void GetClassTrainDataSvm(HClassSvm SVMHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1791);
			SZXCArimAPI.Store(proc, 0, SVMHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SVMHandle);
		}

		public void AddClassTrainDataSvm(HClassSvm SVMHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1792);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, SVMHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(SVMHandle);
		}

		public int GetSampleNumClassTrainData()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1793);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetSampleClassTrainData(int indexSample, out int classID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1794);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, indexSample);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out classID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ClearClassTrainData()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1796);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AddSampleClassTrainData(string order, HTuple features, HTuple classID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1797);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, order);
			SZXCArimAPI.Store(proc, 2, features);
			SZXCArimAPI.Store(proc, 3, classID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(classID);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateClassTrainData(int numDim)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1798);
			SZXCArimAPI.StoreI(proc, 0, numDim);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassMlp SelectFeatureSetMlp(string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1799);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HClassMlp result;
			num = HClassMlp.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HClassMlp SelectFeatureSetMlp(string selectionMethod, string genParamName, double genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1799);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassMlp result;
			num = HClassMlp.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HClassSvm SelectFeatureSetSvm(string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1800);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HClassSvm result;
			num = HClassSvm.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HClassSvm SelectFeatureSetSvm(string selectionMethod, string genParamName, double genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1800);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassSvm result;
			num = HClassSvm.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HClassGmm SelectFeatureSetGmm(string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1801);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HClassGmm result;
			num = HClassGmm.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HClassGmm SelectFeatureSetGmm(string selectionMethod, string genParamName, double genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1801);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassGmm result;
			num = HClassGmm.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HClassKnn SelectFeatureSetKnn(string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1802);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HClassKnn result;
			num = HClassKnn.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HClassKnn SelectFeatureSetKnn(string selectionMethod, string genParamName, double genParamValue, out HTuple selectedFeatureIndices, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1802);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassKnn result;
			num = HClassKnn.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out selectedFeatureIndices);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
