using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HObjectModel3D : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObjectModel3D(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObjectModel3D(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("object_model_3d");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HObjectModel3D obj)
		{
			obj = new HObjectModel3D(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HObjectModel3D[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HObjectModel3D[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HObjectModel3D(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HObjectModel3D()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1065);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HObjectModel3D(HTuple x, HTuple y, HTuple z)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1069);
			SZXCArimAPI.Store(proc, 0, x);
			SZXCArimAPI.Store(proc, 1, y);
			SZXCArimAPI.Store(proc, 2, z);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HObjectModel3D(double x, double y, double z)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1069);
			SZXCArimAPI.StoreD(proc, 0, x);
			SZXCArimAPI.StoreD(proc, 1, y);
			SZXCArimAPI.StoreD(proc, 2, z);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HObjectModel3D(HImage x, HImage y, HImage z)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1093);
			SZXCArimAPI.Store(proc, 1, x);
			SZXCArimAPI.Store(proc, 2, y);
			SZXCArimAPI.Store(proc, 3, z);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(x);
			GC.KeepAlive(y);
			GC.KeepAlive(z);
		}

		public HObjectModel3D(string fileName, HTuple scale, HTuple genParamName, HTuple genParamValue, out HTuple status)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1104);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.Store(proc, 1, scale);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(scale);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			num = HTuple.LoadNew(proc, 1, num, out status);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HObjectModel3D(string fileName, string scale, string genParamName, string genParamValue, out string status)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1104);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, scale);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			num = SZXCArimAPI.LoadS(proc, 1, num, out status);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeObjectModel3d();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HObjectModel3D(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeObjectModel3d(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeObjectModel3d();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HObjectModel3D Deserialize(Stream stream)
		{
			HObjectModel3D arg_0C_0 = new HObjectModel3D();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeObjectModel3d(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HObjectModel3D Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeObjectModel3d();
			HObjectModel3D expr_0C = new HObjectModel3D();
			expr_0C.DeserializeObjectModel3d(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void GetSheetOfLightResultObjectModel3d(HSheetOfLightModel sheetOfLightModelID)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(380);
			SZXCArimAPI.Store(proc, 0, sheetOfLightModelID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sheetOfLightModelID);
		}

		public static HObjectModel3D[] FitPrimitivesObjectModel3d(HObjectModel3D[] objectModel3D, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(411);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, genParamName);
			SZXCArimAPI.Store(expr_13, 2, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D FitPrimitivesObjectModel3d(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(411);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] SegmentObjectModel3d(HObjectModel3D[] objectModel3D, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(412);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, genParamName);
			SZXCArimAPI.Store(expr_13, 2, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D SegmentObjectModel3d(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(412);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] SurfaceNormalsObjectModel3d(HObjectModel3D[] objectModel3D, string method, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(515);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, method);
			SZXCArimAPI.Store(expr_13, 2, genParamName);
			SZXCArimAPI.Store(expr_13, 3, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D SurfaceNormalsObjectModel3d(string method, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(515);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] SmoothObjectModel3d(HObjectModel3D[] objectModel3D, string method, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(516);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, method);
			SZXCArimAPI.Store(expr_13, 2, genParamName);
			SZXCArimAPI.Store(expr_13, 3, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D SmoothObjectModel3d(string method, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(516);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] TriangulateObjectModel3d(HObjectModel3D[] objectModel3D, string method, HTuple genParamName, HTuple genParamValue, out HTuple information)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(517);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, method);
			SZXCArimAPI.Store(expr_13, 2, genParamName);
			SZXCArimAPI.Store(expr_13, 3, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			num = HTuple.LoadNew(expr_13, 1, num, out information);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D TriangulateObjectModel3d(string method, HTuple genParamName, HTuple genParamValue, out int information)
		{
			IntPtr proc = SZXCArimAPI.PreCall(517);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out information);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReconstructSurfaceStereo(HImage images, HStereoModel stereoModelID)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(521);
			SZXCArimAPI.Store(proc, 1, images);
			SZXCArimAPI.Store(proc, 0, stereoModelID);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(images);
			GC.KeepAlive(stereoModelID);
		}

		public HTuple RefineDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, double relSamplingDistance, HObjectModel3D initialDeformationObjectModel3D, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1026);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, deformableSurfaceModel);
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
			GC.KeepAlive(deformableSurfaceModel);
			GC.KeepAlive(initialDeformationObjectModel3D);
			return result;
		}

		public double RefineDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, double relSamplingDistance, HObjectModel3D initialDeformationObjectModel3D, string genParamName, string genParamValue, out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1026);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, deformableSurfaceModel);
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
			GC.KeepAlive(deformableSurfaceModel);
			GC.KeepAlive(initialDeformationObjectModel3D);
			return result;
		}

		public HTuple FindDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, double relSamplingDistance, HTuple minScore, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1027);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, deformableSurfaceModel);
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
			GC.KeepAlive(deformableSurfaceModel);
			return result;
		}

		public double FindDeformableSurfaceModel(HDeformableSurfaceModel deformableSurfaceModel, double relSamplingDistance, double minScore, HTuple genParamName, HTuple genParamValue, out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1027);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, deformableSurfaceModel);
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
			GC.KeepAlive(deformableSurfaceModel);
			return result;
		}

		public static void AddDeformableSurfaceModelSample(HDeformableSurfaceModel deformableSurfaceModel, HObjectModel3D[] objectModel3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1030);
			SZXCArimAPI.Store(expr_13, 0, deformableSurfaceModel);
			SZXCArimAPI.Store(expr_13, 1, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(deformableSurfaceModel);
			GC.KeepAlive(objectModel3D);
		}

		public void AddDeformableSurfaceModelSample(HDeformableSurfaceModel deformableSurfaceModel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1030);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, deformableSurfaceModel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(deformableSurfaceModel);
		}

		public HDeformableSurfaceModel CreateDeformableSurfaceModel(double relSamplingDistance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1031);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HDeformableSurfaceModel result;
			num = HDeformableSurfaceModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableSurfaceModel CreateDeformableSurfaceModel(double relSamplingDistance, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1031);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HDeformableSurfaceModel result;
			num = HDeformableSurfaceModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] RefineSurfaceModelPose(HSurfaceModel surfaceModelID, HPose[] initialPose, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			HTuple hTuple = HData.ConcatArray(initialPose);
			IntPtr proc = SZXCArimAPI.PreCall(1041);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 2, hTuple);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_C5_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(surfaceModelID);
			return arg_C5_0;
		}

		public HPose RefineSurfaceModelPose(HSurfaceModel surfaceModelID, HPose initialPose, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1041);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 2, initialPose);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(initialPose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(surfaceModelID);
			return result;
		}

		public HPose[] FindSurfaceModel(HSurfaceModel surfaceModelID, double relSamplingDistance, double keyPointFraction, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1042);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.Store(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_BE_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(surfaceModelID);
			return arg_BE_0;
		}

		public HPose FindSurfaceModel(HSurfaceModel surfaceModelID, double relSamplingDistance, double keyPointFraction, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1042);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(surfaceModelID);
			return result;
		}

		public HSurfaceModel CreateSurfaceModel(double relSamplingDistance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1044);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HSurfaceModel result;
			num = HSurfaceModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HSurfaceModel CreateSurfaceModel(double relSamplingDistance, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1044);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, relSamplingDistance);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSurfaceModel result;
			num = HSurfaceModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] SimplifyObjectModel3d(HObjectModel3D[] objectModel3D, string method, HTuple amount, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1060);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, method);
			SZXCArimAPI.Store(expr_13, 2, amount);
			SZXCArimAPI.Store(expr_13, 3, genParamName);
			SZXCArimAPI.Store(expr_13, 4, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(amount);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D SimplifyObjectModel3d(string method, double amount, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1060);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.StoreD(proc, 2, amount);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DistanceObjectModel3d(HObjectModel3D objectModel3DTo, HPose pose, HTuple maxDistance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1061);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3DTo);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.Store(proc, 3, maxDistance);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(maxDistance);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3DTo);
		}

		public void DistanceObjectModel3d(HObjectModel3D objectModel3DTo, HPose pose, double maxDistance, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1061);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3DTo);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.StoreD(proc, 3, maxDistance);
			SZXCArimAPI.StoreS(proc, 4, genParamName);
			SZXCArimAPI.StoreS(proc, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3DTo);
		}

		public static HObjectModel3D UnionObjectModel3d(HObjectModel3D[] objectModels3D, string method)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModels3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1062);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, method);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModels3D);
			return result;
		}

		public HObjectModel3D UnionObjectModel3d(string method)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1062);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetObjectModel3dAttribMod(HTuple attribName, string attachExtAttribTo, HTuple attribValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1063);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, attribName);
			SZXCArimAPI.StoreS(proc, 2, attachExtAttribTo);
			SZXCArimAPI.Store(proc, 3, attribValues);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attribName);
			SZXCArimAPI.UnpinTuple(attribValues);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetObjectModel3dAttribMod(string attribName, string attachExtAttribTo, double attribValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1063);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, attribName);
			SZXCArimAPI.StoreS(proc, 2, attachExtAttribTo);
			SZXCArimAPI.StoreD(proc, 3, attribValues);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HObjectModel3D SetObjectModel3dAttrib(HTuple attribName, string attachExtAttribTo, HTuple attribValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1064);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, attribName);
			SZXCArimAPI.StoreS(proc, 2, attachExtAttribTo);
			SZXCArimAPI.Store(proc, 3, attribValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attribName);
			SZXCArimAPI.UnpinTuple(attribValues);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObjectModel3D SetObjectModel3dAttrib(string attribName, string attachExtAttribTo, double attribValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1064);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, attribName);
			SZXCArimAPI.StoreS(proc, 2, attachExtAttribTo);
			SZXCArimAPI.StoreD(proc, 3, attribValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenEmptyObjectModel3d()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1065);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HObjectModel3D[] SampleObjectModel3d(HObjectModel3D[] objectModel3D, string method, HTuple sampleDistance, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1066);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, method);
			SZXCArimAPI.Store(expr_13, 2, sampleDistance);
			SZXCArimAPI.Store(expr_13, 3, genParamName);
			SZXCArimAPI.Store(expr_13, 4, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(sampleDistance);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D SampleObjectModel3d(string method, double sampleDistance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1066);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.StoreD(proc, 2, sampleDistance);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HHomMat3D[] RegisterObjectModel3dGlobal(HObjectModel3D[] objectModels3D, HHomMat3D[] homMats3D, HTuple from, HTuple to, HTuple genParamName, HTuple genParamValue, out HTuple scores)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModels3D);
			HTuple hTuple2 = HData.ConcatArray(homMats3D);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1067);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, hTuple2);
			SZXCArimAPI.Store(expr_20, 2, from);
			SZXCArimAPI.Store(expr_20, 3, to);
			SZXCArimAPI.Store(expr_20, 4, genParamName);
			SZXCArimAPI.Store(expr_20, 5, genParamValue);
			SZXCArimAPI.InitOCT(expr_20, 0);
			SZXCArimAPI.InitOCT(expr_20, 1);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(from);
			SZXCArimAPI.UnpinTuple(to);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(expr_20, 0, num, out data);
			num = HTuple.LoadNew(expr_20, 1, HTupleType.DOUBLE, num, out scores);
			SZXCArimAPI.PostCall(expr_20, num);
			HHomMat3D[] arg_B8_0 = HHomMat3D.SplitArray(data);
			GC.KeepAlive(objectModels3D);
			return arg_B8_0;
		}

		public HHomMat3D[] RegisterObjectModel3dGlobal(HHomMat3D[] homMats3D, string from, int to, HTuple genParamName, HTuple genParamValue, out HTuple scores)
		{
			HTuple hTuple = HData.ConcatArray(homMats3D);
			IntPtr proc = SZXCArimAPI.PreCall(1067);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hTuple);
			SZXCArimAPI.StoreS(proc, 2, from);
			SZXCArimAPI.StoreI(proc, 3, to);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out scores);
			SZXCArimAPI.PostCall(proc, num);
			HHomMat3D[] arg_9D_0 = HHomMat3D.SplitArray(data);
			GC.KeepAlive(this);
			return arg_9D_0;
		}

		public HPose RegisterObjectModel3dPair(HObjectModel3D objectModel3D2, string method, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1068);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D2);
			SZXCArimAPI.StoreS(proc, 2, method);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D2);
			return result;
		}

		public HPose RegisterObjectModel3dPair(HObjectModel3D objectModel3D2, string method, string genParamName, double genParamValue, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1068);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D2);
			SZXCArimAPI.StoreS(proc, 2, method);
			SZXCArimAPI.StoreS(proc, 3, genParamName);
			SZXCArimAPI.StoreD(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D2);
			return result;
		}

		public void GenObjectModel3dFromPoints(HTuple x, HTuple y, HTuple z)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1069);
			SZXCArimAPI.Store(proc, 0, x);
			SZXCArimAPI.Store(proc, 1, y);
			SZXCArimAPI.Store(proc, 2, z);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenObjectModel3dFromPoints(double x, double y, double z)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1069);
			SZXCArimAPI.StoreD(proc, 0, x);
			SZXCArimAPI.StoreD(proc, 1, y);
			SZXCArimAPI.StoreD(proc, 2, z);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HObjectModel3D[] GenBoxObjectModel3d(HPose[] pose, HTuple lengthX, HTuple lengthY, HTuple lengthZ)
		{
			HTuple hTuple = HData.ConcatArray(pose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1070);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, lengthX);
			SZXCArimAPI.Store(expr_13, 2, lengthY);
			SZXCArimAPI.Store(expr_13, 3, lengthZ);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(lengthX);
			SZXCArimAPI.UnpinTuple(lengthY);
			SZXCArimAPI.UnpinTuple(lengthZ);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			return result;
		}

		public void GenBoxObjectModel3d(HPose pose, double lengthX, double lengthY, double lengthZ)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1070);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.StoreD(proc, 1, lengthX);
			SZXCArimAPI.StoreD(proc, 2, lengthY);
			SZXCArimAPI.StoreD(proc, 3, lengthZ);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenPlaneObjectModel3d(HPose pose, HTuple XExtent, HTuple YExtent)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1071);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.Store(proc, 1, XExtent);
			SZXCArimAPI.Store(proc, 2, YExtent);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(XExtent);
			SZXCArimAPI.UnpinTuple(YExtent);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenPlaneObjectModel3d(HPose pose, double XExtent, double YExtent)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1071);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.StoreD(proc, 1, XExtent);
			SZXCArimAPI.StoreD(proc, 2, YExtent);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HObjectModel3D[] GenSphereObjectModel3dCenter(HTuple x, HTuple y, HTuple z, HTuple radius)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1072);
			SZXCArimAPI.Store(expr_0A, 0, x);
			SZXCArimAPI.Store(expr_0A, 1, y);
			SZXCArimAPI.Store(expr_0A, 2, z);
			SZXCArimAPI.Store(expr_0A, 3, radius);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			SZXCArimAPI.UnpinTuple(radius);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public void GenSphereObjectModel3dCenter(double x, double y, double z, double radius)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1072);
			SZXCArimAPI.StoreD(proc, 0, x);
			SZXCArimAPI.StoreD(proc, 1, y);
			SZXCArimAPI.StoreD(proc, 2, z);
			SZXCArimAPI.StoreD(proc, 3, radius);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HObjectModel3D[] GenSphereObjectModel3d(HPose[] pose, HTuple radius)
		{
			HTuple hTuple = HData.ConcatArray(pose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1073);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, radius);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(radius);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			return result;
		}

		public void GenSphereObjectModel3d(HPose pose, double radius)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1073);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.StoreD(proc, 1, radius);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HObjectModel3D[] GenCylinderObjectModel3d(HPose[] pose, HTuple radius, HTuple minExtent, HTuple maxExtent)
		{
			HTuple hTuple = HData.ConcatArray(pose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1074);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, radius);
			SZXCArimAPI.Store(expr_13, 2, minExtent);
			SZXCArimAPI.Store(expr_13, 3, maxExtent);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(minExtent);
			SZXCArimAPI.UnpinTuple(maxExtent);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			return result;
		}

		public void GenCylinderObjectModel3d(HPose pose, double radius, double minExtent, double maxExtent)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1074);
			SZXCArimAPI.Store(proc, 0, pose);
			SZXCArimAPI.StoreD(proc, 1, radius);
			SZXCArimAPI.StoreD(proc, 2, minExtent);
			SZXCArimAPI.StoreD(proc, 3, maxExtent);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HPose[] SmallestBoundingBoxObjectModel3d(HObjectModel3D[] objectModel3D, string type, out HTuple length1, out HTuple length2, out HTuple length3)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1075);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, type);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			SZXCArimAPI.InitOCT(expr_13, 2);
			SZXCArimAPI.InitOCT(expr_13, 3);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out length1);
			num = HTuple.LoadNew(expr_13, 2, HTupleType.DOUBLE, num, out length2);
			num = HTuple.LoadNew(expr_13, 3, HTupleType.DOUBLE, num, out length3);
			SZXCArimAPI.PostCall(expr_13, num);
			HPose[] arg_8F_0 = HPose.SplitArray(data);
			GC.KeepAlive(objectModel3D);
			return arg_8F_0;
		}

		public HPose SmallestBoundingBoxObjectModel3d(string type, out double length1, out double length2, out double length3)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1075);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out length2);
			num = SZXCArimAPI.LoadD(proc, 3, num, out length3);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple SmallestSphereObjectModel3d(HObjectModel3D[] objectModel3D, out HTuple radius)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1076);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out radius);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HTuple SmallestSphereObjectModel3d(out double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1076);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] IntersectPlaneObjectModel3d(HObjectModel3D[] objectModel3D, HPose[] plane)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(plane);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1077);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, hTuple2);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_20, 0, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D IntersectPlaneObjectModel3d(HPose plane)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1077);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, plane);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(plane);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] ConvexHullObjectModel3d(HObjectModel3D[] objectModel3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1078);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D ConvexHullObjectModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1078);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] SelectObjectModel3d(HObjectModel3D[] objectModel3D, HTuple feature, string operation, HTuple minValue, HTuple maxValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1079);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, feature);
			SZXCArimAPI.StoreS(expr_13, 2, operation);
			SZXCArimAPI.Store(expr_13, 3, minValue);
			SZXCArimAPI.Store(expr_13, 4, maxValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(feature);
			SZXCArimAPI.UnpinTuple(minValue);
			SZXCArimAPI.UnpinTuple(maxValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D SelectObjectModel3d(string feature, string operation, double minValue, double maxValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1079);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, feature);
			SZXCArimAPI.StoreS(proc, 2, operation);
			SZXCArimAPI.StoreD(proc, 3, minValue);
			SZXCArimAPI.StoreD(proc, 4, maxValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple AreaObjectModel3d(HObjectModel3D[] objectModel3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1080);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public double AreaObjectModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1080);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple MaxDiameterObjectModel3d(HObjectModel3D[] objectModel3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1081);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public double MaxDiameterObjectModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1081);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple MomentsObjectModel3d(HObjectModel3D[] objectModel3D, HTuple momentsToCalculate)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1082);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, momentsToCalculate);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(momentsToCalculate);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public double MomentsObjectModel3d(string momentsToCalculate)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1082);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, momentsToCalculate);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple VolumeObjectModel3dRelativeToPlane(HObjectModel3D[] objectModel3D, HPose[] plane, HTuple mode, HTuple useFaceOrientation)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(plane);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1083);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, hTuple2);
			SZXCArimAPI.Store(expr_20, 2, mode);
			SZXCArimAPI.Store(expr_20, 3, useFaceOrientation);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(mode);
			SZXCArimAPI.UnpinTuple(useFaceOrientation);
			HTuple result;
			num = HTuple.LoadNew(expr_20, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public double VolumeObjectModel3dRelativeToPlane(HPose plane, string mode, string useFaceOrientation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1083);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, plane);
			SZXCArimAPI.StoreS(proc, 2, mode);
			SZXCArimAPI.StoreS(proc, 3, useFaceOrientation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(plane);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] ReduceObjectModel3dByView(HRegion region, HObjectModel3D[] objectModel3D, HCamPar camParam, HPose[] pose)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1084);
			SZXCArimAPI.Store(expr_20, 1, region);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, camParam);
			SZXCArimAPI.Store(expr_20, 2, hTuple2);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_20, 0, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(region);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D ReduceObjectModel3dByView(HRegion region, HCamPar camParam, HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1084);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public static HObjectModel3D[] ConnectionObjectModel3d(HObjectModel3D[] objectModel3D, HTuple feature, HTuple value)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1085);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, feature);
			SZXCArimAPI.Store(expr_13, 2, value);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(feature);
			SZXCArimAPI.UnpinTuple(value);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D[] ConnectionObjectModel3d(string feature, double value)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1085);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, feature);
			SZXCArimAPI.StoreD(proc, 2, value);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] SelectPointsObjectModel3d(HObjectModel3D[] objectModel3D, HTuple attrib, HTuple minValue, HTuple maxValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1086);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, attrib);
			SZXCArimAPI.Store(expr_13, 2, minValue);
			SZXCArimAPI.Store(expr_13, 3, maxValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(attrib);
			SZXCArimAPI.UnpinTuple(minValue);
			SZXCArimAPI.UnpinTuple(maxValue);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D SelectPointsObjectModel3d(string attrib, double minValue, double maxValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1086);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, attrib);
			SZXCArimAPI.StoreD(proc, 2, minValue);
			SZXCArimAPI.StoreD(proc, 3, maxValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HTuple GetDispObjectModel3dInfo(HWindow windowHandle, HTuple row, HTuple column, HTuple information)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1087);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.Store(expr_0A, 1, row);
			SZXCArimAPI.Store(expr_0A, 2, column);
			SZXCArimAPI.Store(expr_0A, 3, information);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(information);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static int GetDispObjectModel3dInfo(HWindow windowHandle, double row, double column, string information)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1087);
			SZXCArimAPI.Store(expr_0A, 0, windowHandle);
			SZXCArimAPI.StoreD(expr_0A, 1, row);
			SZXCArimAPI.StoreD(expr_0A, 2, column);
			SZXCArimAPI.StoreS(expr_0A, 3, information);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			int result;
			num = SZXCArimAPI.LoadI(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public static HImage RenderObjectModel3d(HObjectModel3D[] objectModel3D, HCamPar camParam, HPose[] pose, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1088);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, camParam);
			SZXCArimAPI.Store(expr_20, 2, hTuple2);
			SZXCArimAPI.Store(expr_20, 3, genParamName);
			SZXCArimAPI.Store(expr_20, 4, genParamValue);
			SZXCArimAPI.InitOCT(expr_20, 1);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(expr_20, 1, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HImage RenderObjectModel3d(HCamPar camParam, HPose pose, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1088);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void DispObjectModel3d(HWindow windowHandle, HObjectModel3D[] objectModel3D, HCamPar camParam, HPose[] pose, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr expr_1E = SZXCArimAPI.PreCall(1089);
			SZXCArimAPI.Store(expr_1E, 0, windowHandle);
			SZXCArimAPI.Store(expr_1E, 1, hTuple);
			SZXCArimAPI.Store(expr_1E, 2, camParam);
			SZXCArimAPI.Store(expr_1E, 3, hTuple2);
			SZXCArimAPI.Store(expr_1E, 4, genParamName);
			SZXCArimAPI.Store(expr_1E, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_1E);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_1E, procResult);
			GC.KeepAlive(windowHandle);
			GC.KeepAlive(objectModel3D);
		}

		public void DispObjectModel3d(HWindow windowHandle, HCamPar camParam, HPose pose, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1089);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 2, camParam);
			SZXCArimAPI.Store(proc, 3, pose);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public HObjectModel3D CopyObjectModel3d(HTuple attributes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1090);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, attributes);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attributes);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObjectModel3D CopyObjectModel3d(string attributes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1090);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, attributes);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void PrepareObjectModel3d(HObjectModel3D[] objectModel3D, string purpose, string overwriteData, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1091);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, purpose);
			SZXCArimAPI.StoreS(expr_13, 2, overwriteData);
			SZXCArimAPI.Store(expr_13, 3, genParamName);
			SZXCArimAPI.Store(expr_13, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(objectModel3D);
		}

		public void PrepareObjectModel3d(string purpose, string overwriteData, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1091);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, purpose);
			SZXCArimAPI.StoreS(proc, 2, overwriteData);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HImage ObjectModel3dToXyz(out HImage y, out HImage z, HObjectModel3D[] objectModel3D, string type, HCamPar camParam, HPose pose)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1092);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.StoreS(expr_13, 1, type);
			SZXCArimAPI.Store(expr_13, 2, camParam);
			SZXCArimAPI.Store(expr_13, 3, pose);
			SZXCArimAPI.InitOCT(expr_13, 1);
			SZXCArimAPI.InitOCT(expr_13, 2);
			SZXCArimAPI.InitOCT(expr_13, 3);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			HImage result;
			num = HImage.LoadNew(expr_13, 1, num, out result);
			num = HImage.LoadNew(expr_13, 2, num, out y);
			num = HImage.LoadNew(expr_13, 3, num, out z);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HImage ObjectModel3dToXyz(out HImage y, out HImage z, string type, HCamPar camParam, HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1092);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.Store(proc, 2, camParam);
			SZXCArimAPI.Store(proc, 3, pose);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out y);
			num = HImage.LoadNew(proc, 3, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void XyzToObjectModel3d(HImage x, HImage y, HImage z)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1093);
			SZXCArimAPI.Store(proc, 1, x);
			SZXCArimAPI.Store(proc, 2, y);
			SZXCArimAPI.Store(proc, 3, z);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(x);
			GC.KeepAlive(y);
			GC.KeepAlive(z);
		}

		public static HTuple GetObjectModel3dParams(HObjectModel3D[] objectModel3D, HTuple genParamName)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1094);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, genParamName);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HTuple GetObjectModel3dParams(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1094);
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

		public HXLDCont ProjectObjectModel3d(HCamPar camParam, HPose pose, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1095);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ProjectObjectModel3d(HCamPar camParam, HPose pose, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1095);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.StoreS(proc, 3, genParamName);
			SZXCArimAPI.StoreS(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(pose);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] RigidTransObjectModel3d(HObjectModel3D[] objectModel3D, HPose[] pose)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1096);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, hTuple2);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_20, 0, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D RigidTransObjectModel3d(HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1096);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] ProjectiveTransObjectModel3d(HObjectModel3D[] objectModel3D, HHomMat3D homMat3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1097);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, homMat3D);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(homMat3D);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D ProjectiveTransObjectModel3d(HHomMat3D homMat3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1097);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, homMat3D);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat3D);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] AffineTransObjectModel3d(HObjectModel3D[] objectModel3D, HHomMat3D[] homMat3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(homMat3D);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1098);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, hTuple2);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_20, 0, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D AffineTransObjectModel3d(HHomMat3D homMat3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1098);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, homMat3D);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat3D);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void ClearObjectModel3d(HObjectModel3D[] objectModel3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1100);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(objectModel3D);
		}

		public void ClearObjectModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1100);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HSerializedItem SerializeObjectModel3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1101);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeObjectModel3d(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1102);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public void WriteObjectModel3d(string fileType, string fileName, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1103);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileType);
			SZXCArimAPI.StoreS(proc, 2, fileName);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteObjectModel3d(string fileType, string fileName, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1103);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileType);
			SZXCArimAPI.StoreS(proc, 2, fileName);
			SZXCArimAPI.StoreS(proc, 3, genParamName);
			SZXCArimAPI.StoreS(proc, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ReadObjectModel3d(string fileName, HTuple scale, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1104);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.Store(proc, 1, scale);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(scale);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string ReadObjectModel3d(string fileName, string scale, string genParamName, string genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1104);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, scale);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			string result;
			num = SZXCArimAPI.LoadS(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HObjectModel3D[] SceneFlowCalib(HImage imageRect1T1, HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, HTuple smoothingFlow, HTuple smoothingDisparity, HTuple genParamName, HTuple genParamValue, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1481);
			SZXCArimAPI.Store(expr_0A, 1, imageRect1T1);
			SZXCArimAPI.Store(expr_0A, 2, imageRect2T1);
			SZXCArimAPI.Store(expr_0A, 3, imageRect1T2);
			SZXCArimAPI.Store(expr_0A, 4, imageRect2T2);
			SZXCArimAPI.Store(expr_0A, 5, disparity);
			SZXCArimAPI.Store(expr_0A, 0, smoothingFlow);
			SZXCArimAPI.Store(expr_0A, 1, smoothingDisparity);
			SZXCArimAPI.Store(expr_0A, 2, genParamName);
			SZXCArimAPI.Store(expr_0A, 3, genParamValue);
			SZXCArimAPI.Store(expr_0A, 4, camParamRect1);
			SZXCArimAPI.Store(expr_0A, 5, camParamRect2);
			SZXCArimAPI.Store(expr_0A, 6, relPoseRect);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(smoothingFlow);
			SZXCArimAPI.UnpinTuple(smoothingDisparity);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(imageRect1T1);
			GC.KeepAlive(imageRect2T1);
			GC.KeepAlive(imageRect1T2);
			GC.KeepAlive(imageRect2T2);
			GC.KeepAlive(disparity);
			return result;
		}

		public void SceneFlowCalib(HImage imageRect1T1, HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, double smoothingFlow, double smoothingDisparity, string genParamName, string genParamValue, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1481);
			SZXCArimAPI.Store(proc, 1, imageRect1T1);
			SZXCArimAPI.Store(proc, 2, imageRect2T1);
			SZXCArimAPI.Store(proc, 3, imageRect1T2);
			SZXCArimAPI.Store(proc, 4, imageRect2T2);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.StoreD(proc, 0, smoothingFlow);
			SZXCArimAPI.StoreD(proc, 1, smoothingDisparity);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.Store(proc, 4, camParamRect1);
			SZXCArimAPI.Store(proc, 5, camParamRect2);
			SZXCArimAPI.Store(proc, 6, relPoseRect);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1T1);
			GC.KeepAlive(imageRect2T1);
			GC.KeepAlive(imageRect1T2);
			GC.KeepAlive(imageRect2T2);
			GC.KeepAlive(disparity);
		}

		public HObjectModel3D EdgesObjectModel3d(HTuple minAmplitude, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2067);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, minAmplitude);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minAmplitude);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObjectModel3D EdgesObjectModel3d(double minAmplitude, string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2067);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, minAmplitude);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] FindSurfaceModelImage(HImage image, HSurfaceModel surfaceModelID, double relSamplingDistance, double keyPointFraction, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2069);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.Store(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_CD_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			return arg_CD_0;
		}

		public HPose FindSurfaceModelImage(HImage image, HSurfaceModel surfaceModelID, double relSamplingDistance, double keyPointFraction, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2069);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.StoreD(proc, 2, relSamplingDistance);
			SZXCArimAPI.StoreD(proc, 3, keyPointFraction);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreS(proc, 5, returnResultHandle);
			SZXCArimAPI.Store(proc, 6, genParamName);
			SZXCArimAPI.Store(proc, 7, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			return result;
		}

		public HPose[] RefineSurfaceModelPoseImage(HImage image, HSurfaceModel surfaceModelID, HPose[] initialPose, HTuple minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult[] surfaceMatchingResultID)
		{
			HTuple hTuple = HData.ConcatArray(initialPose);
			IntPtr proc = SZXCArimAPI.PreCall(2084);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 2, hTuple);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_D5_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			return arg_D5_0;
		}

		public HPose RefineSurfaceModelPoseImage(HImage image, HSurfaceModel surfaceModelID, HPose initialPose, double minScore, string returnResultHandle, HTuple genParamName, HTuple genParamValue, out HTuple score, out HSurfaceMatchingResult surfaceMatchingResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2084);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, surfaceModelID);
			SZXCArimAPI.Store(proc, 2, initialPose);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, returnResultHandle);
			SZXCArimAPI.Store(proc, 5, genParamName);
			SZXCArimAPI.Store(proc, 6, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(initialPose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HSurfaceMatchingResult.LoadNew(proc, 2, num, out surfaceMatchingResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(surfaceModelID);
			return result;
		}

		public static HObjectModel3D FuseObjectModel3d(HObjectModel3D[] objectModel3D, HTuple boundingBox, HTuple resolution, HTuple surfaceTolerance, HTuple minThickness, HTuple smoothing, HTuple normalDirection, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2112);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, boundingBox);
			SZXCArimAPI.Store(expr_13, 2, resolution);
			SZXCArimAPI.Store(expr_13, 3, surfaceTolerance);
			SZXCArimAPI.Store(expr_13, 4, minThickness);
			SZXCArimAPI.Store(expr_13, 5, smoothing);
			SZXCArimAPI.Store(expr_13, 6, normalDirection);
			SZXCArimAPI.Store(expr_13, 7, genParamName);
			SZXCArimAPI.Store(expr_13, 8, genParamValue);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(boundingBox);
			SZXCArimAPI.UnpinTuple(resolution);
			SZXCArimAPI.UnpinTuple(surfaceTolerance);
			SZXCArimAPI.UnpinTuple(minThickness);
			SZXCArimAPI.UnpinTuple(smoothing);
			SZXCArimAPI.UnpinTuple(normalDirection);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(expr_13, 0, num, out result);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D FuseObjectModel3d(HTuple boundingBox, double resolution, double surfaceTolerance, double minThickness, double smoothing, string normalDirection, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2112);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, boundingBox);
			SZXCArimAPI.StoreD(proc, 2, resolution);
			SZXCArimAPI.StoreD(proc, 3, surfaceTolerance);
			SZXCArimAPI.StoreD(proc, 4, minThickness);
			SZXCArimAPI.StoreD(proc, 5, smoothing);
			SZXCArimAPI.StoreS(proc, 6, normalDirection);
			SZXCArimAPI.Store(proc, 7, genParamName);
			SZXCArimAPI.Store(proc, 8, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(boundingBox);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] FindBox3d(HTuple sideLen1, HTuple sideLen2, HTuple sideLen3, HTuple minScore, HDict genParam, out HTuple score, out HObjectModel3D[] objectModel3DBox, out HDict boxInformation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2181);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sideLen1);
			SZXCArimAPI.Store(proc, 2, sideLen2);
			SZXCArimAPI.Store(proc, 3, sideLen3);
			SZXCArimAPI.Store(proc, 4, minScore);
			SZXCArimAPI.Store(proc, 5, genParam);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sideLen1);
			SZXCArimAPI.UnpinTuple(sideLen2);
			SZXCArimAPI.UnpinTuple(sideLen3);
			SZXCArimAPI.UnpinTuple(minScore);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HObjectModel3D.LoadNew(proc, 2, num, out objectModel3DBox);
			num = HDict.LoadNew(proc, 3, num, out boxInformation);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_C4_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(genParam);
			return arg_C4_0;
		}

		public HPose FindBox3d(HTuple sideLen1, HTuple sideLen2, HTuple sideLen3, double minScore, HDict genParam, out HTuple score, out HObjectModel3D[] objectModel3DBox, out HDict boxInformation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2181);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sideLen1);
			SZXCArimAPI.Store(proc, 2, sideLen2);
			SZXCArimAPI.Store(proc, 3, sideLen3);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.Store(proc, 5, genParam);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sideLen1);
			SZXCArimAPI.UnpinTuple(sideLen2);
			SZXCArimAPI.UnpinTuple(sideLen3);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			num = HObjectModel3D.LoadNew(proc, 2, num, out objectModel3DBox);
			num = HDict.LoadNew(proc, 3, num, out boxInformation);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(genParam);
			return result;
		}

		public HObjectModel3D RemoveObjectModel3dAttrib(HTuple attributes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2187);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, attributes);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attributes);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObjectModel3D RemoveObjectModel3dAttrib(string attributes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2187);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, attributes);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void RemoveObjectModel3dAttribMod(HTuple attributes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2188);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, attributes);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attributes);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveObjectModel3dAttribMod(string attributes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2188);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, attributes);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}
	}
}
