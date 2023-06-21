using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HOCRMlp : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRMlp() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRMlp(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRMlp(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("ocr_mlp");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRMlp obj)
		{
			obj = new HOCRMlp(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRMlp[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HOCRMlp[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HOCRMlp(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HOCRMlp(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(694);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRMlp(int widthCharacter, int heightCharacter, string interpolation, HTuple features, HTuple characters, int numHidden, string preprocessing, int numComponents, int randSeed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(708);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreI(proc, 5, numHidden);
			SZXCArimAPI.StoreS(proc, 6, preprocessing);
			SZXCArimAPI.StoreI(proc, 7, numComponents);
			SZXCArimAPI.StoreI(proc, 8, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRMlp(int widthCharacter, int heightCharacter, string interpolation, string features, HTuple characters, int numHidden, string preprocessing, int numComponents, int randSeed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(708);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreI(proc, 5, numHidden);
			SZXCArimAPI.StoreS(proc, 6, preprocessing);
			SZXCArimAPI.StoreI(proc, 7, numComponents);
			SZXCArimAPI.StoreI(proc, 8, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassMlp();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRMlp(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeOcrClassMlp(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassMlp();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HOCRMlp Deserialize(Stream stream)
		{
			HOCRMlp arg_0C_0 = new HOCRMlp();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeOcrClassMlp(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HOCRMlp Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeOcrClassMlp();
			HOCRMlp expr_0C = new HOCRMlp();
			expr_0C.DeserializeOcrClassMlp(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HTuple SelectFeatureSetTrainfMlpProtected(HTuple trainingFile, HTuple password, HTuple featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(661);
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

		public HTuple SelectFeatureSetTrainfMlpProtected(string trainingFile, string password, string featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(661);
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

		public HTuple SelectFeatureSetTrainfMlp(HTuple trainingFile, HTuple featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(662);
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

		public HTuple SelectFeatureSetTrainfMlp(string trainingFile, string featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(662);
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

		public static void ClearOcrClassMlp(HOCRMlp[] OCRHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(OCRHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(691);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(OCRHandle);
		}

		public void ClearOcrClassMlp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(691);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeOcrClassMlp(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(692);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeOcrClassMlp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(693);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadOcrClassMlp(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(694);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteOcrClassMlp(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(695);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetFeaturesOcrClassMlp(HImage character, string transform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(696);
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

		public HTuple DoOcrWordMlp(HRegion character, HImage image, string expression, int numAlternatives, int numCorrections, out HTuple confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(697);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public string DoOcrWordMlp(HRegion character, HImage image, string expression, int numAlternatives, int numCorrections, out double confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(697);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple DoOcrMultiClassMlp(HRegion character, HImage image, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(698);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public string DoOcrMultiClassMlp(HRegion character, HImage image, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(698);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple DoOcrSingleClassMlp(HRegion character, HImage image, HTuple num, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(699);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, num2, out result);
			num2 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public string DoOcrSingleClassMlp(HRegion character, HImage image, HTuple num, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(699);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			string result;
			num2 = SZXCArimAPI.LoadS(proc, 0, num2, out result);
			num2 = SZXCArimAPI.LoadD(proc, 1, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public double TrainfOcrClassMlpProtected(HTuple trainingFile, HTuple password, int maxIterations, double weightTolerance, double errorTolerance, out HTuple errorLog)
		{
			IntPtr proc = SZXCArimAPI.PreCall(700);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingFile);
			SZXCArimAPI.Store(proc, 2, password);
			SZXCArimAPI.StoreI(proc, 3, maxIterations);
			SZXCArimAPI.StoreD(proc, 4, weightTolerance);
			SZXCArimAPI.StoreD(proc, 5, errorTolerance);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(password);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out errorLog);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double TrainfOcrClassMlpProtected(string trainingFile, string password, int maxIterations, double weightTolerance, double errorTolerance, out HTuple errorLog)
		{
			IntPtr proc = SZXCArimAPI.PreCall(700);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			SZXCArimAPI.StoreS(proc, 2, password);
			SZXCArimAPI.StoreI(proc, 3, maxIterations);
			SZXCArimAPI.StoreD(proc, 4, weightTolerance);
			SZXCArimAPI.StoreD(proc, 5, errorTolerance);
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

		public double TrainfOcrClassMlp(HTuple trainingFile, int maxIterations, double weightTolerance, double errorTolerance, out HTuple errorLog)
		{
			IntPtr proc = SZXCArimAPI.PreCall(701);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingFile);
			SZXCArimAPI.StoreI(proc, 2, maxIterations);
			SZXCArimAPI.StoreD(proc, 3, weightTolerance);
			SZXCArimAPI.StoreD(proc, 4, errorTolerance);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out errorLog);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double TrainfOcrClassMlp(string trainingFile, int maxIterations, double weightTolerance, double errorTolerance, out HTuple errorLog)
		{
			IntPtr proc = SZXCArimAPI.PreCall(701);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			SZXCArimAPI.StoreI(proc, 2, maxIterations);
			SZXCArimAPI.StoreD(proc, 3, weightTolerance);
			SZXCArimAPI.StoreD(proc, 4, errorTolerance);
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

		public HTuple GetPrepInfoOcrClassMlp(HTuple trainingFile, string preprocessing, out HTuple cumInformationCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(702);
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

		public HTuple GetPrepInfoOcrClassMlp(string trainingFile, string preprocessing, out HTuple cumInformationCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(702);
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

		public HTuple GetRejectionParamsOcrClassMlp(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(703);
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

		public string GetRejectionParamsOcrClassMlp(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(703);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetRejectionParamsOcrClassMlp(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(704);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRejectionParamsOcrClassMlp(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(704);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetRegularizationParamsOcrClassMlp(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(705);
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

		public void SetRegularizationParamsOcrClassMlp(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(706);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetRegularizationParamsOcrClassMlp(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(706);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GetParamsOcrClassMlp(out int widthCharacter, out int heightCharacter, out string interpolation, out HTuple features, out HTuple characters, out int numHidden, out string preprocessing, out int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(707);
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
			num = SZXCArimAPI.LoadI(proc, 0, num, out widthCharacter);
			num = SZXCArimAPI.LoadI(proc, 1, num, out heightCharacter);
			num = SZXCArimAPI.LoadS(proc, 2, num, out interpolation);
			num = HTuple.LoadNew(proc, 3, num, out features);
			num = HTuple.LoadNew(proc, 4, num, out characters);
			num = SZXCArimAPI.LoadI(proc, 5, num, out numHidden);
			num = SZXCArimAPI.LoadS(proc, 6, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 7, num, out numComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetParamsOcrClassMlp(out int widthCharacter, out int heightCharacter, out string interpolation, out string features, out HTuple characters, out int numHidden, out string preprocessing, out int numComponents)
		{
			IntPtr proc = SZXCArimAPI.PreCall(707);
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
			num = SZXCArimAPI.LoadI(proc, 0, num, out widthCharacter);
			num = SZXCArimAPI.LoadI(proc, 1, num, out heightCharacter);
			num = SZXCArimAPI.LoadS(proc, 2, num, out interpolation);
			num = SZXCArimAPI.LoadS(proc, 3, num, out features);
			num = HTuple.LoadNew(proc, 4, num, out characters);
			num = SZXCArimAPI.LoadI(proc, 5, num, out numHidden);
			num = SZXCArimAPI.LoadS(proc, 6, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 7, num, out numComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassMlp(int widthCharacter, int heightCharacter, string interpolation, HTuple features, HTuple characters, int numHidden, string preprocessing, int numComponents, int randSeed)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(708);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreI(proc, 5, numHidden);
			SZXCArimAPI.StoreS(proc, 6, preprocessing);
			SZXCArimAPI.StoreI(proc, 7, numComponents);
			SZXCArimAPI.StoreI(proc, 8, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassMlp(int widthCharacter, int heightCharacter, string interpolation, string features, HTuple characters, int numHidden, string preprocessing, int numComponents, int randSeed)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(708);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.StoreI(proc, 5, numHidden);
			SZXCArimAPI.StoreS(proc, 6, preprocessing);
			SZXCArimAPI.StoreI(proc, 7, numComponents);
			SZXCArimAPI.StoreI(proc, 8, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(characters);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
