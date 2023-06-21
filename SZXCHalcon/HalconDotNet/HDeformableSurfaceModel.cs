using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HDeformableSurfaceModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableSurfaceModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableSurfaceModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableSurfaceModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("deformable_surface_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableSurfaceModel obj)
		{
			obj = new HDeformableSurfaceModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableSurfaceModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDeformableSurfaceModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDeformableSurfaceModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDeformableSurfaceModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1024);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1031);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public HDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1031);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeDeformableSurfaceModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableSurfaceModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeDeformableSurfaceModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeDeformableSurfaceModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HDeformableSurfaceModel Deserialize(Stream stream)
		{
			HDeformableSurfaceModel arg_0C_0 = new HDeformableSurfaceModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeDeformableSurfaceModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HDeformableSurfaceModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeDeformableSurfaceModel();
			HDeformableSurfaceModel expr_0C = new HDeformableSurfaceModel();
			expr_0C.DeserializeDeformableSurfaceModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static void ClearDeformableSurfaceModel(HDeformableSurfaceModel[] deformableSurfaceModel)
		{
			HTuple hTuple = HHandleBase.ConcatArray(deformableSurfaceModel);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1021);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(deformableSurfaceModel);
		}

		public void ClearDeformableSurfaceModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1021);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeDeformableSurfaceModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1022);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeDeformableSurfaceModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1023);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadDeformableSurfaceModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1024);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteDeformableSurfaceModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1025);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple RefineDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, HObjectModel3D initialDeformationObjectModel3D, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1026);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.Store(proc, 3, initialDeformationObjectModel3D);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, num, out deformableSurfaceMatchingResult);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			GC.KeepAlive(initialDeformationObjectModel3D);
			return result;
		}

		public double RefineDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, HObjectModel3D initialDeformationObjectModel3D, string genParamName, string genParamValue, out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1026);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.Store(proc, 3, initialDeformationObjectModel3D);
			SZXCArimAPI.StoreS(proc, 4, genParamName);
			SZXCArimAPI.StoreS(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, num, out deformableSurfaceMatchingResult);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			GC.KeepAlive(initialDeformationObjectModel3D);
			return result;
		}

		public HTuple FindDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, HTuple minScore, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1027);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, num, out deformableSurfaceMatchingResult);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public double FindDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, double minScore, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1027);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, num, out deformableSurfaceMatchingResult);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HTuple GetDeformableSurfaceModelParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1028);
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

		public HTuple GetDeformableSurfaceModelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1028);
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

		public HTuple AddDeformableSurfaceModelReferencePoint(HTuple referencePointX, HTuple referencePointY, HTuple referencePointZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1029);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, referencePointX);
			SZXCArimAPI.Store(proc, 2, referencePointY);
			SZXCArimAPI.Store(proc, 3, referencePointZ);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(referencePointX);
			SZXCArimAPI.UnpinTuple(referencePointY);
			SZXCArimAPI.UnpinTuple(referencePointZ);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddDeformableSurfaceModelReferencePoint(double referencePointX, double referencePointY, double referencePointZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1029);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, referencePointX);
			SZXCArimAPI.StoreD(proc, 2, referencePointY);
			SZXCArimAPI.StoreD(proc, 3, referencePointZ);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AddDeformableSurfaceModelSample(HObjectModel3D[] objectModel3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr proc = SZXCArimAPI.PreCall(1030);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public void AddDeformableSurfaceModelSample(HObjectModel3D objectModel3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1030);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public void CreateDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1031);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}

		public void CreateDeformableSurfaceModel(HObjectModel3D objectModel3D, double relSamplingDistance, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1031);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
		}
	}
}
