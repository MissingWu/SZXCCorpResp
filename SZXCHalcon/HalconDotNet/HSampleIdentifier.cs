using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HSampleIdentifier : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSampleIdentifier() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSampleIdentifier(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSampleIdentifier(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("sample_identifier");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSampleIdentifier obj)
		{
			obj = new HSampleIdentifier(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSampleIdentifier[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HSampleIdentifier[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HSampleIdentifier(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HSampleIdentifier(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(901);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSampleIdentifier(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(915);
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

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeSampleIdentifier();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSampleIdentifier(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeSampleIdentifier(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeSampleIdentifier();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HSampleIdentifier Deserialize(Stream stream)
		{
			HSampleIdentifier arg_0C_0 = new HSampleIdentifier();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeSampleIdentifier(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HSampleIdentifier Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeSampleIdentifier();
			HSampleIdentifier expr_0C = new HSampleIdentifier();
			expr_0C.DeserializeSampleIdentifier(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void ClearSampleIdentifier()
		{
			IntPtr proc = SZXCArimAPI.PreCall(899);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeSampleIdentifier(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(900);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public void ReadSampleIdentifier(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(901);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSerializedItem SerializeSampleIdentifier()
		{
			IntPtr proc = SZXCArimAPI.PreCall(902);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WriteSampleIdentifier(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(903);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ApplySampleIdentifier(HImage image, int numResults, double ratingThreshold, HTuple genParamName, HTuple genParamValue, out HTuple rating)
		{
			IntPtr proc = SZXCArimAPI.PreCall(904);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 1, numResults);
			SZXCArimAPI.StoreD(proc, 2, ratingThreshold);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out rating);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public int ApplySampleIdentifier(HImage image, int numResults, double ratingThreshold, HTuple genParamName, HTuple genParamValue, out double rating)
		{
			IntPtr proc = SZXCArimAPI.PreCall(904);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 1, numResults);
			SZXCArimAPI.StoreD(proc, 2, ratingThreshold);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out rating);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple GetSampleIdentifierParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(905);
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

		public void SetSampleIdentifierParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(906);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetSampleIdentifierParam(string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(906);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetSampleIdentifierObjectInfo(HTuple objectIdx, HTuple infoName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(907);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, infoName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(infoName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetSampleIdentifierObjectInfo(int objectIdx, string infoName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(907);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.StoreS(proc, 2, infoName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetSampleIdentifierObjectInfo(HTuple objectIdx, string infoName, HTuple infoValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(908);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.StoreS(proc, 2, infoName);
			SZXCArimAPI.Store(proc, 3, infoValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(infoValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetSampleIdentifierObjectInfo(int objectIdx, string infoName, string infoValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(908);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.StoreS(proc, 2, infoName);
			SZXCArimAPI.StoreS(proc, 3, infoValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveSampleIdentifierTrainingData(HTuple objectIdx, HTuple objectSampleIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(909);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, objectSampleIdx);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(objectSampleIdx);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveSampleIdentifierTrainingData(int objectIdx, int objectSampleIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(909);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.StoreI(proc, 2, objectSampleIdx);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveSampleIdentifierPreparationData(HTuple objectIdx, HTuple objectSampleIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(910);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, objectSampleIdx);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(objectSampleIdx);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveSampleIdentifierPreparationData(int objectIdx, int objectSampleIdx)
		{
			IntPtr proc = SZXCArimAPI.PreCall(910);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.StoreI(proc, 2, objectSampleIdx);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainSampleIdentifier(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(911);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int AddSampleIdentifierTrainingData(HImage sampleImage, HTuple objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(912);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sampleImage);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleImage);
			return result;
		}

		public int AddSampleIdentifierTrainingData(HImage sampleImage, int objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(912);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sampleImage);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleImage);
			return result;
		}

		public void PrepareSampleIdentifier(string removePreparationData, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(913);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, removePreparationData);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int AddSampleIdentifierPreparationData(HImage sampleImage, HTuple objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(914);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sampleImage);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleImage);
			return result;
		}

		public int AddSampleIdentifierPreparationData(HImage sampleImage, int objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(914);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sampleImage);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleImage);
			return result;
		}

		public void CreateSampleIdentifier(HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(915);
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
	}
}
