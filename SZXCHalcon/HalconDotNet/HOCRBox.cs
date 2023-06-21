using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HOCRBox : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRBox() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRBox(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRBox(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("ocr_box");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRBox obj)
		{
			obj = new HOCRBox(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRBox[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HOCRBox[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HOCRBox(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HOCRBox(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(712);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRBox(int widthPattern, int heightPattern, int interpolation, HTuple features, HTuple character)
		{
			IntPtr proc = SZXCArimAPI.PreCall(716);
			SZXCArimAPI.StoreI(proc, 0, widthPattern);
			SZXCArimAPI.StoreI(proc, 1, heightPattern);
			SZXCArimAPI.StoreI(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, character);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(character);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCRBox(int widthPattern, int heightPattern, int interpolation, string features, HTuple character)
		{
			IntPtr proc = SZXCArimAPI.PreCall(716);
			SZXCArimAPI.StoreI(proc, 0, widthPattern);
			SZXCArimAPI.StoreI(proc, 1, heightPattern);
			SZXCArimAPI.StoreI(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, character);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(character);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeOcr();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCRBox(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeOcr(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeOcr();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HOCRBox Deserialize(Stream stream)
		{
			HOCRBox arg_0C_0 = new HOCRBox();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeOcr(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HOCRBox Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeOcr();
			HOCRBox expr_0C = new HOCRBox();
			expr_0C.DeserializeOcr(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HSerializedItem SerializeOcr()
		{
			IntPtr proc = SZXCArimAPI.PreCall(709);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeOcr(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(710);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public void WriteOcr(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(711);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadOcr(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(712);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DoOcrSingle(HRegion character, HImage image, out HTuple confidences)
		{
			IntPtr proc = SZXCArimAPI.PreCall(713);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidences);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple DoOcrMulti(HRegion character, HImage image, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(714);
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

		public string DoOcrMulti(HRegion character, HImage image, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(714);
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

		public void InfoOcrClassBox(out int widthPattern, out int heightPattern, out int interpolation, out int widthMaxChar, out int heightMaxChar, out HTuple features, out HTuple characters)
		{
			IntPtr proc = SZXCArimAPI.PreCall(715);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out widthPattern);
			num = SZXCArimAPI.LoadI(proc, 1, num, out heightPattern);
			num = SZXCArimAPI.LoadI(proc, 2, num, out interpolation);
			num = SZXCArimAPI.LoadI(proc, 3, num, out widthMaxChar);
			num = SZXCArimAPI.LoadI(proc, 4, num, out heightMaxChar);
			num = HTuple.LoadNew(proc, 5, num, out features);
			num = HTuple.LoadNew(proc, 6, num, out characters);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassBox(int widthPattern, int heightPattern, int interpolation, HTuple features, HTuple character)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(716);
			SZXCArimAPI.StoreI(proc, 0, widthPattern);
			SZXCArimAPI.StoreI(proc, 1, heightPattern);
			SZXCArimAPI.StoreI(proc, 2, interpolation);
			SZXCArimAPI.Store(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, character);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(character);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcrClassBox(int widthPattern, int heightPattern, int interpolation, string features, HTuple character)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(716);
			SZXCArimAPI.StoreI(proc, 0, widthPattern);
			SZXCArimAPI.StoreI(proc, 1, heightPattern);
			SZXCArimAPI.StoreI(proc, 2, interpolation);
			SZXCArimAPI.StoreS(proc, 3, features);
			SZXCArimAPI.Store(proc, 4, character);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(character);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public double TraindOcrClassBox(HRegion character, HImage image, HTuple classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(717);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(classVal);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public double TraindOcrClassBox(HRegion character, HImage image, string classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(717);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public double TrainfOcrClassBox(HTuple trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(718);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingFile);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double TrainfOcrClassBox(string trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(718);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void OcrChangeChar(HTuple character)
		{
			IntPtr proc = SZXCArimAPI.PreCall(721);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(character);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CloseOcr()
		{
			IntPtr proc = SZXCArimAPI.PreCall(722);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple TestdOcrClassBox(HRegion character, HImage image, HTuple classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(725);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(classVal);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public double TestdOcrClassBox(HRegion character, HImage image, string classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(725);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple OcrGetFeatures(HImage character)
		{
			IntPtr proc = SZXCArimAPI.PreCall(727);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, character);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(character);
			return result;
		}
	}
}
