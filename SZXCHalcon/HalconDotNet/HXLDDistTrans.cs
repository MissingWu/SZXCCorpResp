using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HXLDDistTrans : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDDistTrans() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDDistTrans(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDDistTrans(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("xld_dist_trans");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDDistTrans obj)
		{
			obj = new HXLDDistTrans(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDDistTrans[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HXLDDistTrans[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HXLDDistTrans(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HXLDDistTrans(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1353);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDDistTrans(HXLDCont contour, string mode, HTuple maxDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1360);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, maxDistance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maxDistance);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
		}

		public HXLDDistTrans(HXLDCont contour, string mode, double maxDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1360);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, maxDistance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeDistanceTransformXld();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDDistTrans(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeDistanceTransformXld(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeDistanceTransformXld();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HXLDDistTrans Deserialize(Stream stream)
		{
			HXLDDistTrans arg_0C_0 = new HXLDDistTrans();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeDistanceTransformXld(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HXLDDistTrans Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeDistanceTransformXld();
			HXLDDistTrans expr_0C = new HXLDDistTrans();
			expr_0C.DeserializeDistanceTransformXld(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void ClearDistanceTransformXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1351);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HXLDCont ApplyDistanceTransformXld(HXLDCont contour)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1352);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
			return result;
		}

		public void ReadDistanceTransformXld(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1353);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DeserializeDistanceTransformXld(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1354);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeDistanceTransformXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1355);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WriteDistanceTransformXld(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1356);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDistanceTransformXldParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1357);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDistanceTransformXldParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1357);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetDistanceTransformXldParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1358);
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

		public HTuple GetDistanceTransformXldParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1358);
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

		public HXLDCont GetDistanceTransformXldContour()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1359);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreateDistanceTransformXld(HXLDCont contour, string mode, HTuple maxDistance)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1360);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, maxDistance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maxDistance);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
		}

		public void CreateDistanceTransformXld(HXLDCont contour, string mode, double maxDistance)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1360);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, maxDistance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
		}
	}
}
