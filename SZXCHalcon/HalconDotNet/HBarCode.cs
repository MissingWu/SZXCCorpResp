using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HBarCode : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBarCode() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBarCode(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBarCode(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("barcode");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarCode obj)
		{
			obj = new HBarCode(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarCode[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HBarCode[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HBarCode(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HBarCode(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1988);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HBarCode(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2001);
			SZXCArimAPI.Store(proc, 0, genParamName);
			SZXCArimAPI.Store(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HBarCode(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2001);
			SZXCArimAPI.StoreS(proc, 0, genParamName);
			SZXCArimAPI.StoreD(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeBarCodeModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HBarCode(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeBarCodeModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeBarCodeModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HBarCode Deserialize(Stream stream)
		{
			HBarCode arg_0C_0 = new HBarCode();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeBarCodeModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HBarCode Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeBarCodeModel();
			HBarCode expr_0C = new HBarCode();
			expr_0C.DeserializeBarCodeModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void DeserializeBarCodeModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1986);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeBarCodeModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1987);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadBarCodeModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1988);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteBarCodeModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1989);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HObject GetBarCodeObject(HTuple candidateHandle, string objectName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1990);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, candidateHandle);
			SZXCArimAPI.StoreS(proc, 2, objectName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(candidateHandle);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject GetBarCodeObject(string candidateHandle, string objectName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1990);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, candidateHandle);
			SZXCArimAPI.StoreS(proc, 2, objectName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetBarCodeResult(HTuple candidateHandle, string resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1991);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, candidateHandle);
			SZXCArimAPI.StoreS(proc, 2, resultName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(candidateHandle);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetBarCodeResult(string candidateHandle, string resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1991);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, candidateHandle);
			SZXCArimAPI.StoreS(proc, 2, resultName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DecodeBarCodeRectangle2(HImage image, HTuple codeType, HTuple row, HTuple column, HTuple phi, HTuple length1, HTuple length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1992);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, codeType);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.Store(proc, 4, phi);
			SZXCArimAPI.Store(proc, 5, length1);
			SZXCArimAPI.Store(proc, 6, length2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(codeType);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(length1);
			SZXCArimAPI.UnpinTuple(length2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public string DecodeBarCodeRectangle2(HImage image, string codeType, double row, double column, double phi, double length1, double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1992);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreS(proc, 1, codeType);
			SZXCArimAPI.StoreD(proc, 2, row);
			SZXCArimAPI.StoreD(proc, 3, column);
			SZXCArimAPI.StoreD(proc, 4, phi);
			SZXCArimAPI.StoreD(proc, 5, length1);
			SZXCArimAPI.StoreD(proc, 6, length2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HRegion FindBarCode(HImage image, HTuple codeType, out HTuple decodedDataStrings)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1993);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, codeType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(codeType);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, num, out decodedDataStrings);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HRegion FindBarCode(HImage image, string codeType, out string decodedDataStrings)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1993);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreS(proc, 1, codeType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadS(proc, 0, num, out decodedDataStrings);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple QueryBarCodeParams(string properties)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1994);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, properties);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetBarCodeParamSpecific(HTuple codeTypes, HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1995);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, codeTypes);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(codeTypes);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetBarCodeParamSpecific(string codeTypes, string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1995);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, codeTypes);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetBarCodeParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1996);
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

		public HTuple GetBarCodeParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1996);
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

		public void SetBarCodeParamSpecific(HTuple codeTypes, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1997);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, codeTypes);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(codeTypes);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetBarCodeParamSpecific(string codeTypes, string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1997);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, codeTypes);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetBarCodeParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1998);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetBarCodeParam(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1998);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ClearBarCodeModel(HBarCode[] barCodeHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(barCodeHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2000);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(barCodeHandle);
		}

		public void ClearBarCodeModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2000);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateBarCodeModel(HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2001);
			SZXCArimAPI.Store(proc, 0, genParamName);
			SZXCArimAPI.Store(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateBarCodeModel(string genParamName, double genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2001);
			SZXCArimAPI.StoreS(proc, 0, genParamName);
			SZXCArimAPI.StoreD(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
