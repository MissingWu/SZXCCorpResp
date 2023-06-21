using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HOCRKnn : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRKnn() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRKnn(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRKnn(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("ocr_knn");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRKnn obj)
		{
			obj = new HOCRKnn(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRKnn[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HOCRKnn[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HOCRKnn(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HOCRKnn(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(650);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRKnn(int widthCharacter, int heightCharacter, string interpolation, HTuple features, HTuple characters, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(654);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(characters);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRKnn(int widthCharacter, int heightCharacter, string interpolation, string features, HTuple characters, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(654);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(characters);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassKnn();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRKnn(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeOcrClassKnn(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassKnn();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HOCRKnn Deserialize(Stream stream)
		{
			HOCRKnn arg_0C_0 = new HOCRKnn();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeOcrClassKnn(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HOCRKnn Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeOcrClassKnn();
			HOCRKnn expr_0C = new HOCRKnn();
			expr_0C.DeserializeOcrClassKnn(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HTuple DoOcrWordKnn(HRegion character, HImage image, string expression, int numAlternatives, int numCorrections, out HTuple confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(647);
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

		public string DoOcrWordKnn(HRegion character, HImage image, string expression, int numAlternatives, int numCorrections, out double confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(647);
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

		public void DeserializeOcrClassKnn(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(648);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeOcrClassKnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(649);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadOcrClassKnn(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(650);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteOcrClassKnn(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(651);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearOcrClassKnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(653);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassKnn(int widthCharacter, int heightCharacter, string interpolation, HTuple features, HTuple characters, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(654);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(characters);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassKnn(int widthCharacter, int heightCharacter, string interpolation, string features, HTuple characters, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(654);
			SZXCArimAPI.StoreI(proc, 0, widthCharacter);
			SZXCArimAPI.StoreI(proc, 1, heightCharacter);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, characters);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(characters);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void TrainfOcrClassKnn(HTuple trainingFile, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(655);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingFile);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainfOcrClassKnn(string trainingFile, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(655);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetFeaturesOcrClassKnn(HImage character, string transform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(656);
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

		public void GetParamsOcrClassKnn(out int widthCharacter, out int heightCharacter, out string interpolation, out HTuple features, out HTuple characters, out string preprocessing, out int numTrees)
		{
			IntPtr proc = SZXCArimAPI.PreCall(657);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out widthCharacter);
			num = SZXCArimAPI.LoadI(proc, 1, num, out heightCharacter);
			num = SZXCArimAPI.LoadS(proc, 2, num, out interpolation);
			num = HTuple.LoadNew(proc, 3, num, out features);
			num = HTuple.LoadNew(proc, 4, num, out characters);
			num = SZXCArimAPI.LoadS(proc, 5, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 6, num, out numTrees);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetParamsOcrClassKnn(out int widthCharacter, out int heightCharacter, out string interpolation, out string features, out HTuple characters, out string preprocessing, out int numTrees)
		{
			IntPtr proc = SZXCArimAPI.PreCall(657);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out widthCharacter);
			num = SZXCArimAPI.LoadI(proc, 1, num, out heightCharacter);
			num = SZXCArimAPI.LoadS(proc, 2, num, out interpolation);
			num = SZXCArimAPI.LoadS(proc, 3, num, out features);
			num = HTuple.LoadNew(proc, 4, num, out characters);
			num = SZXCArimAPI.LoadS(proc, 5, num, out preprocessing);
			num = SZXCArimAPI.LoadI(proc, 6, num, out numTrees);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DoOcrMultiClassKnn(HRegion character, HImage image, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(658);
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

		public string DoOcrMultiClassKnn(HRegion character, HImage image, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(658);
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

		public HTuple DoOcrSingleClassKnn(HRegion character, HImage image, HTuple numClasses, HTuple numNeighbors, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(659);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, numNeighbors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numClasses);
			SZXCArimAPI.UnpinTuple(numNeighbors);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public string DoOcrSingleClassKnn(HRegion character, HImage image, HTuple numClasses, HTuple numNeighbors, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(659);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, numNeighbors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numClasses);
			SZXCArimAPI.UnpinTuple(numNeighbors);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple SelectFeatureSetTrainfKnn(HTuple trainingFile, HTuple featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(660);
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

		public HTuple SelectFeatureSetTrainfKnn(string trainingFile, string featureList, string selectionMethod, int width, int height, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(660);
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
	}
}
