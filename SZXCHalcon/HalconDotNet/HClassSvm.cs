using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HClassSvm : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassSvm() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassSvm(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassSvm(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("class_svm");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassSvm obj)
		{
			obj = new HClassSvm(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassSvm[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HClassSvm[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HClassSvm(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HClassSvm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1846);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassSvm(int numFeatures, string kernelType, double kernelParam, double nu, int numClasses, string mode, string preprocessing, int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1861);
			SZXCArimAPI.StoreI(proc, 0, numFeatures);
			SZXCArimAPI.StoreS(proc, 1, kernelType);
			SZXCArimAPI.StoreD(proc, 2, kernelParam);
			SZXCArimAPI.StoreD(proc, 3, nu);
			SZXCArimAPI.StoreI(proc, 4, numClasses);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreS(proc, 6, preprocessing);
			SZXCArimAPI.StoreI(proc, 7, numComponents);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeClassSvm();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassSvm(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeClassSvm(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeClassSvm();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HClassSvm Deserialize(Stream stream)
		{
			HClassSvm arg_0C_0 = new HClassSvm();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeClassSvm(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HClassSvm Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeClassSvm();
			HClassSvm expr_0C = new HClassSvm();
			expr_0C.DeserializeClassSvm(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HRegion ClassifyImageClassSvm(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(433);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void AddSamplesImageClassSvm(HImage image, HRegion classRegions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(434);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, classRegions);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(classRegions);
		}

		public HClassTrainData GetClassTrainDataSvm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1791);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassTrainData result;
			num = HClassTrainData.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AddClassTrainDataSvm(HClassTrainData classTrainDataHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1792);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, classTrainDataHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classTrainDataHandle);
		}

		public HTuple SelectFeatureSetSvm(HClassTrainData classTrainDataHandle, string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1800);
			SZXCArimAPI.Store(proc, 0, classTrainDataHandle);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(classTrainDataHandle);
			return result;
		}

		public HTuple SelectFeatureSetSvm(HClassTrainData classTrainDataHandle, string selectionMethod, string genParamName, double genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1800);
			SZXCArimAPI.Store(proc, 0, classTrainDataHandle);
			SZXCArimAPI.StoreS(proc, 1, selectionMethod);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(classTrainDataHandle);
			return result;
		}

		public HClassLUT CreateClassLutSvm(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1821);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HClassLUT result;
			num = HClassLUT.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void ClearClassSvm(HClassSvm[] SVMHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(SVMHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1842);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(SVMHandle);
		}

		public void ClearClassSvm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1842);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ClearSamplesClassSvm(HClassSvm[] SVMHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(SVMHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1843);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(SVMHandle);
		}

		public void ClearSamplesClassSvm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1843);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeClassSvm(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1844);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeClassSvm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1845);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadClassSvm(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1846);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteClassSvm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1847);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadSamplesClassSvm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1848);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteSamplesClassSvm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1849);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple EvaluateClassSvm(HTuple features)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1850);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ClassifyClassSvm(HTuple features, HTuple num)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1851);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.Store(proc, 2, num);
			SZXCArimAPI.InitOCT(proc, 0);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(num);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num2, out result);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			return result;
		}

		public HClassSvm ReduceClassSvm(string method, int minRemainingSV, double maxError)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1852);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.StoreI(proc, 2, minRemainingSV);
			SZXCArimAPI.StoreD(proc, 3, maxError);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassSvm result;
			num = HClassSvm.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void TrainClassSvm(double epsilon, HTuple trainMode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1853);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, epsilon);
			SZXCArimAPI.Store(proc, 2, trainMode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainMode);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainClassSvm(double epsilon, string trainMode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1853);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, epsilon);
			SZXCArimAPI.StoreS(proc, 2, trainMode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetPrepInfoClassSvm(string preprocessing, out HTuple cumInformationCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1854);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, preprocessing);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out cumInformationCont);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetSupportVectorNumClassSvm(out HTuple numSVPerSVM)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1855);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out numSVPerSVM);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetSupportVectorClassSvm(int indexSupportVector)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1856);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, indexSupportVector);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetSampleNumClassSvm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1857);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetSampleClassSvm(int indexSample, out int target)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1858);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, indexSample);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out target);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AddSampleClassSvm(HTuple features, HTuple classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1859);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.Store(proc, 2, classVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(classVal);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AddSampleClassSvm(HTuple features, int classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1859);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.StoreI(proc, 2, classVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int GetParamsClassSvm(out string kernelType, out double kernelParam, out double nu, out int numClasses, out string mode, out string preprocessing, out int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1860);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadS(proc, 1, num, out kernelType);
			num = SZXCArimAPI.LoadD(proc, 2, num, out kernelParam);
			num = SZXCArimAPI.LoadD(proc, 3, num, out nu);
			num = SZXCArimAPI.LoadI(proc, 4, num, out numClasses);
			num = SZXCArimAPI.LoadS(proc, 5, num, out mode);
			num = SZXCArimAPI.LoadS(proc, 6, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 7, num, out numComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateClassSvm(int numFeatures, string kernelType, double kernelParam, double nu, int numClasses, string mode, string preprocessing, int numComponents)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1861);
			SZXCArimAPI.StoreI(proc, 0, numFeatures);
			SZXCArimAPI.StoreS(proc, 1, kernelType);
			SZXCArimAPI.StoreD(proc, 2, kernelParam);
			SZXCArimAPI.StoreD(proc, 3, nu);
			SZXCArimAPI.StoreI(proc, 4, numClasses);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreS(proc, 6, preprocessing);
			SZXCArimAPI.StoreI(proc, 7, numComponents);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
