using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HClassBox : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassBox(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassBox(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("class_box");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassBox obj)
		{
			obj = new HClassBox(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HClassBox[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HClassBox[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HClassBox(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HClassBox()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1895);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeClassBox();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HClassBox(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeClassBox(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeClassBox();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HClassBox Deserialize(Stream stream)
		{
			HClassBox arg_0C_0 = new HClassBox();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeClassBox(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HClassBox Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeClassBox();
			HClassBox expr_0C = new HClassBox();
			expr_0C.DeserializeClassBox(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void LearnNdimBox(HRegion foreground, HRegion background, HImage multiChannelImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(438);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, foreground);
			SZXCArimAPI.Store(proc, 2, background);
			SZXCArimAPI.Store(proc, 3, multiChannelImage);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(foreground);
			GC.KeepAlive(background);
			GC.KeepAlive(multiChannelImage);
		}

		public HRegion ClassNdimBox(HImage multiChannelImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(439);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, multiChannelImage);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(multiChannelImage);
			return result;
		}

		public void DeserializeClassBox(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1884);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, serializedItemHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeClassBox()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1885);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WriteClassBox(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1886);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetClassBoxParam(string flag, HTuple value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1887);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, flag);
			SZXCArimAPI.Store(proc, 2, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(value);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetClassBoxParam(string flag, double value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1887);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, flag);
			SZXCArimAPI.StoreD(proc, 2, value);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadClassBox(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1889);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void LearnSampsetBox(HFeatureSet sampKey, string outfile, int NSamples, double stopError, int errorN)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1890);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sampKey);
			SZXCArimAPI.StoreS(proc, 2, outfile);
			SZXCArimAPI.StoreI(proc, 3, NSamples);
			SZXCArimAPI.StoreD(proc, 4, stopError);
			SZXCArimAPI.StoreI(proc, 5, errorN);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(sampKey);
		}

		public void LearnClassBox(HTuple features, int classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1891);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, features);
			SZXCArimAPI.StoreI(proc, 2, classVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetClassBoxParam(string flag)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1892);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, flag);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CloseClassBox()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1894);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateClassBox()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1895);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DescriptClassBox(int dimensions, out HTuple boxIdx, out HTuple boxLowerBound, out HTuple boxHigherBound, out HTuple boxNumSamplesTrain, out HTuple boxNumSamplesWrong)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1896);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, dimensions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out boxIdx);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out boxLowerBound);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out boxHigherBound);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out boxNumSamplesTrain);
			num = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, num, out boxNumSamplesWrong);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int DescriptClassBox(int dimensions, out int boxIdx, out int boxLowerBound, out int boxHigherBound, out int boxNumSamplesTrain, out int boxNumSamplesWrong)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1896);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, dimensions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out boxIdx);
			num = SZXCArimAPI.LoadI(proc, 2, num, out boxLowerBound);
			num = SZXCArimAPI.LoadI(proc, 3, num, out boxHigherBound);
			num = SZXCArimAPI.LoadI(proc, 4, num, out boxNumSamplesTrain);
			num = SZXCArimAPI.LoadI(proc, 5, num, out boxNumSamplesWrong);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double TestSampsetBox(HFeatureSet sampKey)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1897);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sampKey);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampKey);
			return result;
		}

		public int EnquireRejectClassBox(HTuple featureList)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1898);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, featureList);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(featureList);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int EnquireClassBox(HTuple featureList)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1899);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, featureList);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(featureList);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
