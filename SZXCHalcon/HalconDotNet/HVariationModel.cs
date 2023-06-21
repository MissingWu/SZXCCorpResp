using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HVariationModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVariationModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVariationModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVariationModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("variation_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HVariationModel obj)
		{
			obj = new HVariationModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HVariationModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HVariationModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HVariationModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HVariationModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(83);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HVariationModel(int width, int height, string type, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(95);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.StoreS(proc, 2, type);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeVariationModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HVariationModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeVariationModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeVariationModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HVariationModel Deserialize(Stream stream)
		{
			HVariationModel arg_0C_0 = new HVariationModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeVariationModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HVariationModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeVariationModel();
			HVariationModel expr_0C = new HVariationModel();
			expr_0C.DeserializeVariationModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void DeserializeVariationModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(81);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeVariationModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(82);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadVariationModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(83);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteVariationModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(84);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage GetThreshImagesVariationModel(out HImage maxImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(85);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out maxImage);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GetVariationModel(out HImage varImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(86);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out varImage);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion CompareExtVariationModel(HImage image, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(87);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HRegion CompareVariationModel(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(88);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void PrepareDirectVariationModel(HImage refImage, HImage varImage, HTuple absThreshold, HTuple varThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(89);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, refImage);
			SZXCArimAPI.Store(proc, 2, varImage);
			SZXCArimAPI.Store(proc, 1, absThreshold);
			SZXCArimAPI.Store(proc, 2, varThreshold);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(absThreshold);
			SZXCArimAPI.UnpinTuple(varThreshold);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(refImage);
			GC.KeepAlive(varImage);
		}

		public void PrepareDirectVariationModel(HImage refImage, HImage varImage, double absThreshold, double varThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(89);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, refImage);
			SZXCArimAPI.Store(proc, 2, varImage);
			SZXCArimAPI.StoreD(proc, 1, absThreshold);
			SZXCArimAPI.StoreD(proc, 2, varThreshold);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(refImage);
			GC.KeepAlive(varImage);
		}

		public void PrepareVariationModel(HTuple absThreshold, HTuple varThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(90);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, absThreshold);
			SZXCArimAPI.Store(proc, 2, varThreshold);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(absThreshold);
			SZXCArimAPI.UnpinTuple(varThreshold);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void PrepareVariationModel(double absThreshold, double varThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(90);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, absThreshold);
			SZXCArimAPI.StoreD(proc, 2, varThreshold);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainVariationModel(HImage images)
		{
			IntPtr proc = SZXCArimAPI.PreCall(91);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, images);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(images);
		}

		public void ClearVariationModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(93);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearTrainDataVariationModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(94);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateVariationModel(int width, int height, string type, string mode)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(95);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.StoreS(proc, 2, type);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
