using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HClassKnn : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassKnn() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassKnn(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassKnn(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("class_knn");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassKnn obj)
		{
			obj = new HClassKnn(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassKnn[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HClassKnn[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HClassKnn(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HClassKnn(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1809);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassKnn(HTuple numDim)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1816);
			SZXCArimAPI.Store(proc, 0, numDim);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numDim);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeClassKnn();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassKnn(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeClassKnn(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeClassKnn();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HClassKnn Deserialize(Stream stream)
		{
			HClassKnn arg_0C_0 = new HClassKnn();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeClassKnn(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HClassKnn Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeClassKnn();
			HClassKnn expr_0C = new HClassKnn();
			expr_0C.DeserializeClassKnn(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HRegion ClassifyImageClassKnn(HImage image, out HImage distanceImage, double rejectionThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(429);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, rejectionThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out distanceImage);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void AddSamplesImageClassKnn(HImage image, HRegion classRegions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(430);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, classRegions);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(classRegions);
		}

		public HClassTrainData GetClassTrainDataKnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1789);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HClassTrainData result;
			num = HClassTrainData.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AddClassTrainDataKnn(HClassTrainData classTrainDataHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1790);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, classTrainDataHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classTrainDataHandle);
		}

		public HTuple SelectFeatureSetKnn(HClassTrainData classTrainDataHandle, string selectionMethod, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1802);
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

		public HTuple SelectFeatureSetKnn(HClassTrainData classTrainDataHandle, string selectionMethod, string genParamName, double genParamValue, out HTuple score)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1802);
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

		public void ClearClassKnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1804);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int GetSampleNumClassKnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1805);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetSampleClassKnn(int indexSample, out HTuple classID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1806);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, indexSample);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out classID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeClassKnn(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1807);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeClassKnn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1808);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadClassKnn(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1809);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteClassKnn(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1810);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetParamsClassKnn(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1811);
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

		public void SetParamsClassKnn(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1812);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ClassifyClassKnn(HTuple features, out HTuple rating)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1813);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out rating);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void TrainClassKnn(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1814);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AddSampleClassKnn(HTuple features, HTuple classID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1815);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.Store(proc, 2, classID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(classID);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AddSampleClassKnn(double features, int classID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1815);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, features);
			SZXCArimAPI.StoreI(proc, 2, classID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateClassKnn(HTuple numDim)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1816);
			SZXCArimAPI.Store(proc, 0, numDim);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numDim);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HClassLUT CreateClassLutKnn(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1819);
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
	}
}
