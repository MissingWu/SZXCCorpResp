using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HOCRSvm : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRSvm() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRSvm(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRSvm(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("ocr_svm");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRSvm obj)
		{
			obj = new HOCRSvm(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRSvm[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HOCRSvm[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HOCRSvm(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HOCRSvm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(676);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRSvm(int widthCharacter, int heightCharacter, string interpolation, HTuple features, HTuple characters, string kernelType, double kernelParam, double nu, string mode, string preprocessing, int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(689);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreS(proc, 5, kernelType);
			SZXCArimAPI.StoreD(proc, 6, kernelParam);
			SZXCArimAPI.StoreD(proc, 7, nu);
			SZXCArimAPI.StoreS(proc, 8, mode);
			SZXCArimAPI.StoreS(proc, 9, preprocessing);
			SZXCArimAPI.StoreI(proc, 10, numComponents);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRSvm(int widthCharacter, int heightCharacter, string interpolation, string features, HTuple characters, string kernelType, double kernelParam, double nu, string mode, string preprocessing, int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(689);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreS(proc, 5, kernelType);
			SZXCArimAPI.StoreD(proc, 6, kernelParam);
			SZXCArimAPI.StoreD(proc, 7, nu);
			SZXCArimAPI.StoreS(proc, 8, mode);
			SZXCArimAPI.StoreS(proc, 9, preprocessing);
			SZXCArimAPI.StoreI(proc, 10, numComponents);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassSvm();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRSvm(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeOcrClassSvm(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassSvm();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HOCRSvm Deserialize(Stream stream)
		{
			HOCRSvm arg_0C_0 = new HOCRSvm();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeOcrClassSvm(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HOCRSvm Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeOcrClassSvm();
			HOCRSvm expr_0C = new HOCRSvm();
			expr_0C.DeserializeOcrClassSvm(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HTuple SelectFeatureSetTrainfSvmProtected(HTuple trainingFile, HTuple password, HTuple featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(663);
			SZXCArimAPI.Store(proc, 0, trainingFile);
			SZXCArimAPI.Store(proc, 1, password);
			SZXCArimAPI.Store(proc, 2, featureList);
			SZXCArimAPI.StoreS(proc, 3, selectionMethod);
			SZXCArimAPI.StoreI(proc, 4, width);
			SZXCArimAPI.StoreI(proc, 5, height);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(password);
			SZXCArimAPI.UnpinTuple(featureList);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple SelectFeatureSetTrainfSvmProtected(string trainingFile, string password, string featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(663);
			SZXCArimAPI.StoreS(proc, 0, trainingFile);
			SZXCArimAPI.StoreS(proc, 1, password);
			SZXCArimAPI.StoreS(proc, 2, featureList);
			SZXCArimAPI.StoreS(proc, 3, selectionMethod);
			SZXCArimAPI.StoreI(proc, 4, width);
			SZXCArimAPI.StoreI(proc, 5, height);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
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
			return result;
		}

		public HTuple SelectFeatureSetTrainfSvm(HTuple trainingFile, HTuple featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(664);
			SZXCArimAPI.Store(proc, 0, trainingFile);
			SZXCArimAPI.Store(proc, 1, featureList);
			SZXCArimAPI.StoreS(proc, 2, selectionMethod);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(featureList);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple SelectFeatureSetTrainfSvm(string trainingFile, string featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(664);
			SZXCArimAPI.StoreS(proc, 0, trainingFile);
			SZXCArimAPI.StoreS(proc, 1, featureList);
			SZXCArimAPI.StoreS(proc, 2, selectionMethod);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
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
			return result;
		}

		public static void ClearOcrClassSvm(HOCRSvm[] OCRHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(OCRHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(673);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(OCRHandle);
		}

		public void ClearOcrClassSvm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(673);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeOcrClassSvm(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(674);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeOcrClassSvm()
		{
			IntPtr proc = SZXCArimAPI.PreCall(675);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadOcrClassSvm(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(676);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteOcrClassSvm(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(677);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetFeaturesOcrClassSvm(HImage character, string transform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(678);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.StoreS(proc, 1, transform);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			return result;
		}

		public HTuple DoOcrWordSvm(HRegion character, HImage image, string expression, int numAlternatives, int numCorrections, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(679);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadS(proc, 1, num, out word);
			num = SZXCArimAPI.LoadD(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple DoOcrMultiClassSvm(HRegion character, HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(680);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple DoOcrSingleClassSvm(HRegion character, HImage image, HTuple num)
		{
			IntPtr proc = SZXCArimAPI.PreCall(681);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, num2, out result);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HOCRSvm ReduceOcrClassSvm(string method, int minRemainingSV, double maxError)
		{
			IntPtr proc = SZXCArimAPI.PreCall(682);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.StoreI(proc, 2, minRemainingSV);
			SZXCArimAPI.StoreD(proc, 3, maxError);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HOCRSvm result;
			num = HOCRSvm.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void TrainfOcrClassSvmProtected(HTuple trainingFile, HTuple password, double epsilon, HTuple trainMode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(683);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingFile);
			SZXCArimAPI.Store(proc, 2, password);
			SZXCArimAPI.StoreD(proc, 3, epsilon);
			SZXCArimAPI.Store(proc, 4, trainMode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(password);
			SZXCArimAPI.UnpinTuple(trainMode);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainfOcrClassSvmProtected(string trainingFile, string password, double epsilon, string trainMode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(683);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			SZXCArimAPI.StoreS(proc, 2, password);
			SZXCArimAPI.StoreD(proc, 3, epsilon);
			SZXCArimAPI.StoreS(proc, 4, trainMode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainfOcrClassSvm(HTuple trainingFile, double epsilon, HTuple trainMode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(684);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingFile);
			SZXCArimAPI.StoreD(proc, 2, epsilon);
			SZXCArimAPI.Store(proc, 3, trainMode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(trainMode);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainfOcrClassSvm(string trainingFile, double epsilon, string trainMode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(684);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			SZXCArimAPI.StoreD(proc, 2, epsilon);
			SZXCArimAPI.StoreS(proc, 3, trainMode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetPrepInfoOcrClassSvm(HTuple trainingFile, string preprocessing, out HTuple cumInformationCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(685);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingFile);
			SZXCArimAPI.StoreS(proc, 2, preprocessing);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out cumInformationCont);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetPrepInfoOcrClassSvm(string trainingFile, string preprocessing, out HTuple cumInformationCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(685);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			SZXCArimAPI.StoreS(proc, 2, preprocessing);
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

		public int GetSupportVectorNumOcrClassSvm(out HTuple numSVPerSVM)
		{
			IntPtr proc = SZXCArimAPI.PreCall(686);
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

		public double GetSupportVectorOcrClassSvm(HTuple indexSupportVector)
		{
			IntPtr proc = SZXCArimAPI.PreCall(687);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, indexSupportVector);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(indexSupportVector);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetParamsOcrClassSvm(out int widthCharacter, out int heightCharacter, out string interpolation, out HTuple features, out HTuple characters, out string kernelType, out double kernelParam, out double nu, out string mode, out string preprocessing, out int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(688);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			SZXCArimAPI.InitOCT(proc, 8);
			SZXCArimAPI.InitOCT(proc, 9);
			SZXCArimAPI.InitOCT(proc, 10);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out widthCharacter);
			num = SZXCArimAPI.LoadI(proc, 1, num, out heightCharacter);
			num = SZXCArimAPI.LoadS(proc, 2, num, out interpolation);
			num = HTuple.LoadNew(proc, 3, num, out features);
			num = HTuple.LoadNew(proc, 4, num, out characters);
			num = SZXCArimAPI.LoadS(proc, 5, num, out kernelType);
			num = SZXCArimAPI.LoadD(proc, 6, num, out kernelParam);
			num = SZXCArimAPI.LoadD(proc, 7, num, out nu);
			num = SZXCArimAPI.LoadS(proc, 8, num, out mode);
			num = SZXCArimAPI.LoadS(proc, 9, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 10, num, out numComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetParamsOcrClassSvm(out int widthCharacter, out int heightCharacter, out string interpolation, out string features, out HTuple characters, out string kernelType, out double kernelParam, out double nu, out string mode, out string preprocessing, out int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(688);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			SZXCArimAPI.InitOCT(proc, 8);
			SZXCArimAPI.InitOCT(proc, 9);
			SZXCArimAPI.InitOCT(proc, 10);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out widthCharacter);
			num = SZXCArimAPI.LoadI(proc, 1, num, out heightCharacter);
			num = SZXCArimAPI.LoadS(proc, 2, num, out interpolation);
			num = SZXCArimAPI.LoadS(proc, 3, num, out features);
			num = HTuple.LoadNew(proc, 4, num, out characters);
			num = SZXCArimAPI.LoadS(proc, 5, num, out kernelType);
			num = SZXCArimAPI.LoadD(proc, 6, num, out kernelParam);
			num = SZXCArimAPI.LoadD(proc, 7, num, out nu);
			num = SZXCArimAPI.LoadS(proc, 8, num, out mode);
			num = SZXCArimAPI.LoadS(proc, 9, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 10, num, out numComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassSvm(int widthCharacter, int heightCharacter, string interpolation, HTuple features, HTuple characters, string kernelType, double kernelParam, double nu, string mode, string preprocessing, int numComponents)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(689);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreS(proc, 5, kernelType);
			SZXCArimAPI.StoreD(proc, 6, kernelParam);
			SZXCArimAPI.StoreD(proc, 7, nu);
			SZXCArimAPI.StoreS(proc, 8, mode);
			SZXCArimAPI.StoreS(proc, 9, preprocessing);
			SZXCArimAPI.StoreI(proc, 10, numComponents);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassSvm(int widthCharacter, int heightCharacter, string interpolation, string features, HTuple characters, string kernelType, double kernelParam, double nu, string mode, string preprocessing, int numComponents)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(689);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreS(proc, 5, kernelType);
			SZXCArimAPI.StoreD(proc, 6, kernelParam);
			SZXCArimAPI.StoreD(proc, 7, nu);
			SZXCArimAPI.StoreS(proc, 8, mode);
			SZXCArimAPI.StoreS(proc, 9, preprocessing);
			SZXCArimAPI.StoreI(proc, 10, numComponents);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
