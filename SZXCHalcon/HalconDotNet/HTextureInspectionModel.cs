using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HTextureInspectionModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextureInspectionModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextureInspectionModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextureInspectionModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("texture_inspection_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextureInspectionModel obj)
		{
			obj = new HTextureInspectionModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTextureInspectionModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HTextureInspectionModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HTextureInspectionModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HTextureInspectionModel(string modelType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2051);
			SZXCArimAPI.StoreS(proc, 0, modelType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeTextureInspectionModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTextureInspectionModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeTextureInspectionModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeTextureInspectionModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HTextureInspectionModel Deserialize(Stream stream)
		{
			HTextureInspectionModel arg_0C_0 = new HTextureInspectionModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeTextureInspectionModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HTextureInspectionModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeTextureInspectionModel();
			HTextureInspectionModel expr_0C = new HTextureInspectionModel();
			expr_0C.DeserializeTextureInspectionModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HTuple AddTextureInspectionModelImage(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2043);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HRegion ApplyTextureInspectionModel(HImage image, out HTextureInspectionResult textureInspectionResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2044);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTextureInspectionResult.LoadNew(proc, 0, num, out textureInspectionResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public static void ClearTextureInspectionModel(HTextureInspectionModel[] textureInspectionModel)
		{
			HTuple hTuple = HHandleBase.ConcatArray(textureInspectionModel);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2047);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(textureInspectionModel);
		}

		public void ClearTextureInspectionModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2047);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateTextureInspectionModel(string modelType)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2051);
			SZXCArimAPI.StoreS(proc, 0, modelType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DeserializeTextureInspectionModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2054);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HImage GetTextureInspectionModelImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2075);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetTextureInspectionModelParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2076);
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

		public HTuple GetTextureInspectionModelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2076);
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

		public void ReadTextureInspectionModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2083);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HTuple RemoveTextureInspectionModelImage(HTextureInspectionModel[] textureInspectionModel, HTuple indices)
		{
			HTuple hTuple = HHandleBase.ConcatArray(textureInspectionModel);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2085);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, indices);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(indices);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(textureInspectionModel);
			return result;
		}

		public HTuple RemoveTextureInspectionModelImage(HTuple indices)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2085);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, indices);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(indices);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HSerializedItem SerializeTextureInspectionModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2094);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetTextureInspectionModelParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2098);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetTextureInspectionModelParam(string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2098);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreI(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TrainTextureInspectionModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2099);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteTextureInspectionModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2100);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}
	}
}
