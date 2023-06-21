using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HStereoModel : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HStereoModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HStereoModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HStereoModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("stereo_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HStereoModel obj)
		{
			obj = new HStereoModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HStereoModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HStereoModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HStereoModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HStereoModel(HCameraSetupModel cameraSetupModelID, string method, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(527);
			SZXCArimAPI.Store(proc, 0, cameraSetupModelID);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(cameraSetupModelID);
		}

		public HStereoModel(HCameraSetupModel cameraSetupModelID, string method, string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(527);
			SZXCArimAPI.Store(proc, 0, cameraSetupModelID);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(cameraSetupModelID);
		}

		public void ClearStereoModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(519);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReconstructPointsStereo(HTuple row, HTuple column, HTuple covIP, int cameraIdx, int pointIdx, out HTuple x, out HTuple y, out HTuple z, out HTuple covWP, out HTuple pointIdxOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(520);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, covIP);
			SZXCArimAPI.StoreI(proc, 4, cameraIdx);
			SZXCArimAPI.StoreI(proc, 5, pointIdx);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(covIP);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out covWP);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out pointIdxOut);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ReconstructPointsStereo(double row, double column, HTuple covIP, int cameraIdx, int pointIdx, out double x, out double y, out double z, out double covWP, out int pointIdxOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(520);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, covIP);
			SZXCArimAPI.StoreI(proc, 4, cameraIdx);
			SZXCArimAPI.StoreI(proc, 5, pointIdx);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(covIP);
			num = SZXCArimAPI.LoadD(proc, 0, num, out x);
			num = SZXCArimAPI.LoadD(proc, 1, num, out y);
			num = SZXCArimAPI.LoadD(proc, 2, num, out z);
			num = SZXCArimAPI.LoadD(proc, 3, num, out covWP);
			num = SZXCArimAPI.LoadI(proc, 4, num, out pointIdxOut);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HObjectModel3D ReconstructSurfaceStereo(HImage images)
		{
			IntPtr proc = SZXCArimAPI.PreCall(521);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, images);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(images);
			return result;
		}

		public HObject GetStereoModelObject(HTuple pairIndex, string objectName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(522);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pairIndex);
			SZXCArimAPI.StoreS(proc, 2, objectName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pairIndex);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObject GetStereoModelObject(int pairIndex, string objectName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(522);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, pairIndex);
			SZXCArimAPI.StoreS(proc, 2, objectName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObject result;
			num = HObject.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetStereoModelImagePairs(out HTuple to)
		{
			IntPtr proc = SZXCArimAPI.PreCall(523);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out to);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetStereoModelImagePairs(HTuple from, HTuple to)
		{
			IntPtr proc = SZXCArimAPI.PreCall(524);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, from);
			SZXCArimAPI.Store(proc, 2, to);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(from);
			SZXCArimAPI.UnpinTuple(to);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetStereoModelParam(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(525);
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

		public HTuple GetStereoModelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(525);
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

		public void SetStereoModelParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(526);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetStereoModelParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(526);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateStereoModel(HCameraSetupModel cameraSetupModelID, string method, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(527);
			SZXCArimAPI.Store(proc, 0, cameraSetupModelID);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(cameraSetupModelID);
		}

		public void CreateStereoModel(HCameraSetupModel cameraSetupModelID, string method, string genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(527);
			SZXCArimAPI.Store(proc, 0, cameraSetupModelID);
			SZXCArimAPI.StoreS(proc, 1, method);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(cameraSetupModelID);
		}

		public HObjectModel3D GetStereoModelObjectModel3d(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2074);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HObjectModel3D GetStereoModelObjectModel3d(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2074);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
