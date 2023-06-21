using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HClassGmm : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassGmm() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassGmm(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassGmm(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("class_gmm");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassGmm obj)
		{
			obj = new HClassGmm(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassGmm[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HClassGmm[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HClassGmm(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HClassGmm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1828);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassGmm(int numDim, int numClasses, HTuple numCenters, string covarType, string preprocessing, int numComponents, int randSeed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1840);
			SZXCArimAPI.StoreI(proc, 0, numDim);
			SZXCArimAPI.StoreI(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, numCenters);
			SZXCArimAPI.StoreS(proc, 3, covarType);
			SZXCArimAPI.StoreS(proc, 4, preprocessing);
			SZXCArimAPI.StoreI(proc, 5, numComponents);
			SZXCArimAPI.StoreI(proc, 6, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numCenters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassGmm(int numDim, int numClasses, int numCenters, string covarType, string preprocessing, int numComponents, int randSeed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1840);
			SZXCArimAPI.StoreI(proc, 0, numDim);
			SZXCArimAPI.StoreI(proc, 1, numClasses);
			SZXCArimAPI.StoreI(proc, 2, numCenters);
			SZXCArimAPI.StoreS(proc, 3, covarType);
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
			HSerializedItem expr_06 = this.SerializeClassGmm();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassGmm(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeClassGmm(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeClassGmm();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HClassGmm Deserialize(Stream stream)
		{
			HClassGmm arg_0C_0 = new HClassGmm();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeClassGmm(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HClassGmm Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeClassGmm();
			HClassGmm expr_0C = new HClassGmm();
			expr_0C.DeserializeClassGmm(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HRegion ClassifyImageClassGmm(HImage image, double rejectionThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(431);
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

		public void AddSamplesImageClassGmm(HImage image, HRegion classRegions, double randomize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(432);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, classRegions);
			SZXCArimAPI.StoreD(proc, 1, randomize);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(classRegions);
		}

		public HClassTrainData GetClassTrainDataGmm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1785);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassTrainData result;
			num = HClassTrainData.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AddClassTrainDataGmm(HClassTrainData classTrainDataHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1786);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, classTrainDataHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classTrainDataHandle);
		}

		public HTuple SelectFeatureSetGmm(HClassTrainData classTrainDataHandle, string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1801);
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

		public HTuple SelectFeatureSetGmm(HClassTrainData classTrainDataHandle, string selectionMethod, string genParamName, double genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1801);
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

		public HClassLUT CreateClassLutGmm(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1820);
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

		public static void ClearClassGmm(HClassGmm[] GMMHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(GMMHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1824);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(GMMHandle);
		}

		public void ClearClassGmm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1824);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ClearSamplesClassGmm(HClassGmm[] GMMHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(GMMHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1825);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(GMMHandle);
		}

		public void ClearSamplesClassGmm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1825);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeClassGmm(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1826);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeClassGmm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1827);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadClassGmm(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1828);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteClassGmm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1829);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadSamplesClassGmm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1830);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteSamplesClassGmm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1831);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ClassifyClassGmm(HTuple features, int num, out HTuple classProb, out HTuple density, out HTuple KSigmaProb)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1832);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.StoreI(proc, 2, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num2, out result);
			num2 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num2, out classProb);
			num2 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num2, out density);
			num2 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num2, out KSigmaProb);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EvaluateClassGmm(HTuple features, out double density, out double KSigmaProb)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1833);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out density);
			num = SZXCArimAPI.LoadD(proc, 2, num, out KSigmaProb);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TrainClassGmm(int maxIter, double threshold, string classPriors, double regularize, out HTuple iter)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1834);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, maxIter);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.StoreS(proc, 3, classPriors);
			SZXCArimAPI.StoreD(proc, 4, regularize);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out iter);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetPrepInfoClassGmm(string preprocessing, out HTuple cumInformationCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1835);
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

		public int GetSampleNumClassGmm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1836);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetSampleClassGmm(int numSample, out int classID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1837);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, numSample);
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

		public void AddSampleClassGmm(HTuple features, int classID, double randomize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1838);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.StoreI(proc, 2, classID);
			SZXCArimAPI.StoreD(proc, 3, randomize);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int GetParamsClassGmm(out int numClasses, out HTuple minCenters, out HTuple maxCenters, out string covarType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1839);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out numClasses);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out minCenters);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out maxCenters);
			num = SZXCArimAPI.LoadS(proc, 4, num, out covarType);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateClassGmm(int numDim, int numClasses, HTuple numCenters, string covarType, string preprocessing, int numComponents, int randSeed)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1840);
			SZXCArimAPI.StoreI(proc, 0, numDim);
			SZXCArimAPI.StoreI(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, numCenters);
			SZXCArimAPI.StoreS(proc, 3, covarType);
			SZXCArimAPI.StoreS(proc, 4, preprocessing);
			SZXCArimAPI.StoreI(proc, 5, numComponents);
			SZXCArimAPI.StoreI(proc, 6, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numCenters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateClassGmm(int numDim, int numClasses, int numCenters, string covarType, string preprocessing, int numComponents, int randSeed)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1840);
			SZXCArimAPI.StoreI(proc, 0, numDim);
			SZXCArimAPI.StoreI(proc, 1, numClasses);
			SZXCArimAPI.StoreI(proc, 2, numCenters);
			SZXCArimAPI.StoreS(proc, 3, covarType);
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
