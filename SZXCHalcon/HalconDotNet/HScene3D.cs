using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HScene3D : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HScene3D(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HScene3D(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("scene_3d");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HScene3D obj)
		{
			obj = new HScene3D(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HScene3D[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HScene3D[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HScene3D(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HScene3D()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1220);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetDisplayScene3dInfo(HWindow windowHandle, HTuple row, HTuple column, HTuple information)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1204);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.Store(proc, 4, information);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(information);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public int GetDisplayScene3dInfo(HWindow windowHandle, double row, double column, string information)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1204);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreD(proc, 2, row);
			SZXCArimAPI.StoreD(proc, 3, column);
			SZXCArimAPI.StoreS(proc, 4, information);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public void SetScene3dToWorldPose(HPose toWorldPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1205);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, toWorldPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(toWorldPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1206);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1206);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dLightParam(int lightIndex, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1207);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, lightIndex);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dLightParam(int lightIndex, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1207);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, lightIndex);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dInstancePose(HTuple instanceIndex, HPose[] pose)
		{
			HTuple hTuple = HData.ConcatArray(pose);
			IntPtr proc = SZXCArimAPI.PreCall(1208);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, instanceIndex);
			SZXCArimAPI.Store(proc, 2, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(instanceIndex);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dInstancePose(int instanceIndex, HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1208);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, instanceIndex);
			SZXCArimAPI.Store(proc, 2, pose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dInstanceParam(HTuple instanceIndex, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1209);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, instanceIndex);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(instanceIndex);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dInstanceParam(int instanceIndex, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1209);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, instanceIndex);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dCameraPose(int cameraIndex, HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1210);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIndex);
			SZXCArimAPI.Store(proc, 2, pose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage RenderScene3d(int cameraIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1211);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIndex);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void RemoveScene3dLight(int lightIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1212);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, lightIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveScene3dInstance(HTuple instanceIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1213);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, instanceIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(instanceIndex);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveScene3dInstance(int instanceIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1213);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, instanceIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveScene3dCamera(int cameraIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1214);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, cameraIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DisplayScene3d(HWindow windowHandle, HTuple cameraIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1215);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 2, cameraIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraIndex);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DisplayScene3d(HWindow windowHandle, string cameraIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1215);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 2, cameraIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public int AddScene3dLight(HTuple lightPosition, string lightKind)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1216);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, lightPosition);
			SZXCArimAPI.StoreS(proc, 2, lightKind);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(lightPosition);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddScene3dInstance(HObjectModel3D[] objectModel3D, HPose[] pose)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr proc = SZXCArimAPI.PreCall(1217);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, hTuple);
			SZXCArimAPI.Store(proc, 2, hTuple2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public int AddScene3dInstance(HObjectModel3D objectModel3D, HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1217);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public int AddScene3dCamera(HCamPar cameraParam)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1218);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, cameraParam);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void ClearScene3d(HScene3D[] scene3D)
		{
			HTuple hTuple = HHandleBase.ConcatArray(scene3D);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1219);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(scene3D);
		}

		public void ClearScene3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1219);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateScene3d()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1220);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public int AddScene3dLabel(HTuple text, HTuple referencePoint, HTuple position, HTuple relatesTo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2040);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, text);
			SZXCArimAPI.Store(proc, 2, referencePoint);
			SZXCArimAPI.Store(proc, 3, position);
			SZXCArimAPI.Store(proc, 4, relatesTo);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(text);
			SZXCArimAPI.UnpinTuple(referencePoint);
			SZXCArimAPI.UnpinTuple(position);
			SZXCArimAPI.UnpinTuple(relatesTo);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddScene3dLabel(string text, HTuple referencePoint, HTuple position, HTuple relatesTo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2040);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, text);
			SZXCArimAPI.Store(proc, 2, referencePoint);
			SZXCArimAPI.Store(proc, 3, position);
			SZXCArimAPI.Store(proc, 4, relatesTo);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(referencePoint);
			SZXCArimAPI.UnpinTuple(position);
			SZXCArimAPI.UnpinTuple(relatesTo);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void RemoveScene3dLabel(HTuple labelIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2041);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, labelIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(labelIndex);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void RemoveScene3dLabel(int labelIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2041);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, labelIndex);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dLabelParam(HTuple labelIndex, string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2042);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, labelIndex);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(labelIndex);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetScene3dLabelParam(int labelIndex, string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2042);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, labelIndex);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}
	}
}
