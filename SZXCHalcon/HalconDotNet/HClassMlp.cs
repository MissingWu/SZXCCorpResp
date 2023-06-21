using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HClassMlp : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassMlp() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassMlp(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassMlp(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("class_mlp");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassMlp obj)
		{
			obj = new HClassMlp(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassMlp[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HClassMlp[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HClassMlp(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HClassMlp(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1867);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassMlp(int numInput, int numHidden, int numOutput, string outputFunction, string preprocessing, int numComponents, int randSeed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1883);
			SZXCArimAPI.StoreI(proc, 0, numInput);
			SZXCArimAPI.StoreI(proc, 1, numHidden);
			SZXCArimAPI.StoreI(proc, 2, numOutput);
			SZXCArimAPI.StoreS(proc, 3, outputFunction);
			SZXCArimAPI.StoreS(proc, 4, preprocessing);
			SZXCArimAPI.StoreI(proc, 5, numComponents);
			SZXCArimAPI.StoreI(proc, 6, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeClassMlp();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassMlp(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeClassMlp(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeClassMlp();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HClassMlp Deserialize(Stream stream)
		{
			HClassMlp arg_0C_0 = new HClassMlp();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeClassMlp(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HClassMlp Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeClassMlp();
			HClassMlp expr_0C = new HClassMlp();
			expr_0C.DeserializeClassMlp(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HRegion ClassifyImageClassMlp(HImage image, double rejectionThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(435);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, rejectionThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void AddSamplesImageClassMlp(HImage image, HRegion classRegions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(436);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, classRegions);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(classRegions);
		}

		public HClassTrainData GetClassTrainDataMlp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1787);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassTrainData result;
			num = HClassTrainData.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AddClassTrainDataMlp(HClassTrainData classTrainDataHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1788);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, classTrainDataHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classTrainDataHandle);
		}

		public HTuple SelectFeatureSetMlp(HClassTrainData classTrainDataHandle, string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1799);
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

		public HTuple SelectFeatureSetMlp(HClassTrainData classTrainDataHandle, string selectionMethod, string genParamName, double genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1799);
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

		public HClassLUT CreateClassLutMlp(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1822);
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

		public static void ClearClassMlp(HClassMlp[] MLPHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(MLPHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1863);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(MLPHandle);
		}

		public void ClearClassMlp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1863);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ClearSamplesClassMlp(HClassMlp[] MLPHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(MLPHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1864);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(MLPHandle);
		}

		public void ClearSamplesClassMlp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1864);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeClassMlp(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1865);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeClassMlp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1866);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadClassMlp(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1867);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteClassMlp(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1868);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadSamplesClassMlp(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1869);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteSamplesClassMlp(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1870);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ClassifyClassMlp(HTuple features, HTuple num, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1871);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.Store(proc, 2, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(num);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num2, out result);
			num2 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			return result;
		}

		public int ClassifyClassMlp(HTuple features, HTuple num, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1871);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.Store(proc, 2, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(num);
			int result;
			num2 = SZXCArimAPI.LoadI(proc, 0, num2, out result);
			num2 = SZXCArimAPI.LoadD(proc, 1, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EvaluateClassMlp(HTuple features)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1872);
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

		public double TrainClassMlp(int maxIterations, double weightTolerance, double errorTolerance, out HTuple errorLog)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1873);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, maxIterations);
			SZXCArimAPI.StoreD(proc, 2, weightTolerance);
			SZXCArimAPI.StoreD(proc, 3, errorTolerance);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out errorLog);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetPrepInfoClassMlp(string preprocessing, out HTuple cumInformationCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1874);
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

		public int GetSampleNumClassMlp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1875);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetSampleClassMlp(int indexSample, out HTuple target)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1876);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, indexSample);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out target);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetRejectionParamsClassMlp(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1877);
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

		public HTuple GetRejectionParamsClassMlp(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1877);
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

		public void SetRejectionParamsClassMlp(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1878);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRejectionParamsClassMlp(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1878);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AddSampleClassMlp(HTuple features, HTuple target)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1879);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.Store(proc, 2, target);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(target);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AddSampleClassMlp(HTuple features, int target)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1879);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.StoreI(proc, 2, target);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetRegularizationParamsClassMlp(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1880);
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

		public void SetRegularizationParamsClassMlp(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1881);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRegularizationParamsClassMlp(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1881);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int GetParamsClassMlp(out int numHidden, out int numOutput, out string outputFunction, out string preprocessing, out int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1882);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out numHidden);
			num = SZXCArimAPI.LoadI(proc, 2, num, out numOutput);
			num = SZXCArimAPI.LoadS(proc, 3, num, out outputFunction);
			num = SZXCArimAPI.LoadS(proc, 4, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 5, num, out numComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateClassMlp(int numInput, int numHidden, int numOutput, string outputFunction, string preprocessing, int numComponents, int randSeed)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1883);
			SZXCArimAPI.StoreI(proc, 0, numInput);
			SZXCArimAPI.StoreI(proc, 1, numHidden);
			SZXCArimAPI.StoreI(proc, 2, numOutput);
			SZXCArimAPI.StoreS(proc, 3, outputFunction);
			SZXCArimAPI.StoreS(proc, 4, preprocessing);
			SZXCArimAPI.StoreI(proc, 5, numComponents);
			SZXCArimAPI.StoreI(proc, 6, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
