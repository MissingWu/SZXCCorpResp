using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HSheetOfLightModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSheetOfLightModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSheetOfLightModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSheetOfLightModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("sheet_of_light_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSheetOfLightModel obj)
		{
			obj = new HSheetOfLightModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HSheetOfLightModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HSheetOfLightModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HSheetOfLightModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HSheetOfLightModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(374);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSheetOfLightModel(HRegion profileRegion, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(391);
			SZXCArimAPI.Store(proc, 1, profileRegion);
			SZXCArimAPI.Store(proc, 0, genParamName);
			SZXCArimAPI.Store(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(profileRegion);
		}

		public HSheetOfLightModel(HRegion profileRegion, string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(391);
			SZXCArimAPI.Store(proc, 1, profileRegion);
			SZXCArimAPI.StoreS(proc, 0, genParamName);
			SZXCArimAPI.StoreI(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(profileRegion);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeSheetOfLightModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HSheetOfLightModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeSheetOfLightModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeSheetOfLightModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HSheetOfLightModel Deserialize(Stream stream)
		{
			HSheetOfLightModel arg_0C_0 = new HSheetOfLightModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeSheetOfLightModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HSheetOfLightModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeSheetOfLightModel();
			HSheetOfLightModel expr_0C = new HSheetOfLightModel();
			expr_0C.DeserializeSheetOfLightModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void ReadSheetOfLightModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(374);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteSheetOfLightModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(375);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeSheetOfLightModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(376);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeSheetOfLightModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(377);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double CalibrateSheetOfLight()
		{
			IntPtr proc = SZXCArimAPI.PreCall(379);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObjectModel3D GetSheetOfLightResultObjectModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(380);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GetSheetOfLightResult(HTuple resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(381);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultName);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GetSheetOfLightResult(string resultName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(381);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ApplySheetOfLightCalibration(HImage disparity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(382);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, disparity);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(disparity);
		}

		public void SetProfileSheetOfLight(HImage profileDisparityImage, HTuple movementPoses)
		{
			IntPtr proc = SZXCArimAPI.PreCall(383);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, profileDisparityImage);
			SZXCArimAPI.Store(proc, 1, movementPoses);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(movementPoses);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(profileDisparityImage);
		}

		public void MeasureProfileSheetOfLight(HImage profileImage, HTuple movementPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(384);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, profileImage);
			SZXCArimAPI.Store(proc, 1, movementPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(movementPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(profileImage);
		}

		public void SetSheetOfLightParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(385);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetSheetOfLightParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(385);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetSheetOfLightParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(386);
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

		public HTuple QuerySheetOfLightParams(string queryName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(387);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, queryName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ResetSheetOfLightModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(388);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearSheetOfLightModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(390);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateSheetOfLightModel(HRegion profileRegion, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(391);
			SZXCArimAPI.Store(proc, 1, profileRegion);
			SZXCArimAPI.Store(proc, 0, genParamName);
			SZXCArimAPI.Store(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(profileRegion);
		}

		public void CreateSheetOfLightModel(HRegion profileRegion, string genParamName, int genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(391);
			SZXCArimAPI.Store(proc, 1, profileRegion);
			SZXCArimAPI.StoreS(proc, 0, genParamName);
			SZXCArimAPI.StoreI(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(profileRegion);
		}
	}
}
