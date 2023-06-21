using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HOCRCnn : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRCnn() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRCnn(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRCnn(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("ocr_cnn");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRCnn obj)
		{
			obj = new HOCRCnn(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRCnn[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HOCRCnn[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HOCRCnn(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HOCRCnn(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2082);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassCnn();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRCnn(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeOcrClassCnn(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeOcrClassCnn();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HOCRCnn Deserialize(Stream stream)
		{
			HOCRCnn arg_0C_0 = new HOCRCnn();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeOcrClassCnn(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HOCRCnn Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeOcrClassCnn();
			HOCRCnn expr_0C = new HOCRCnn();
			expr_0C.DeserializeOcrClassCnn(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static void ClearOcrClassCnn(HOCRCnn[] OCRHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(OCRHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2046);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(OCRHandle);
		}

		public void ClearOcrClassCnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2046);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeOcrClassCnn(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2053);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HTuple DoOcrMultiClassCnn(HRegion character, HImage image, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2056);
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

		public string DoOcrMultiClassCnn(HRegion character, HImage image, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2056);
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

		public HTuple DoOcrSingleClassCnn(HRegion character, HImage image, HTuple num, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2057);
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

		public string DoOcrSingleClassCnn(HRegion character, HImage image, HTuple num, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2057);
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

		public HTuple DoOcrWordCnn(HRegion character, HImage image, string expression, int numAlternatives, int numCorrections, out HTuple confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2058);
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

		public string DoOcrWordCnn(HRegion character, HImage image, string expression, int numAlternatives, int numCorrections, out double confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2058);
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

		public HTuple GetParamsOcrClassCnn(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2072);
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

		public HTuple GetParamsOcrClassCnn(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2072);
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

		public HTuple QueryParamsOcrClassCnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2081);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadOcrClassCnn(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2082);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSerializedItem SerializeOcrClassCnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2093);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
