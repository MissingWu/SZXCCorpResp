using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HDeformableModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("deformable_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableModel obj)
		{
			obj = new HDeformableModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HDeformableModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HDeformableModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HDeformableModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(965);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HDeformableModel(HXLDCont contours, HCamPar camParam, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.Store(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.Store(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.Store(proc, 11, scaleCStep);
			SZXCArimAPI.Store(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HDeformableModel(HXLDCont contours, HCamPar camParam, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreI(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.StoreD(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.StoreD(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.StoreD(proc, 11, scaleCStep);
			SZXCArimAPI.StoreS(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HDeformableModel(HXLDCont contours, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(977);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HDeformableModel(HXLDCont contours, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(977);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HDeformableModel(HImage template, HCamPar camParam, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.Store(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.Store(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.Store(proc, 11, scaleCStep);
			SZXCArimAPI.Store(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.Store(proc, 14, contrast);
			SZXCArimAPI.Store(proc, 15, minContrast);
			SZXCArimAPI.Store(proc, 16, genParamName);
			SZXCArimAPI.Store(proc, 17, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HDeformableModel(HImage template, HCamPar camParam, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreI(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.StoreD(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.StoreD(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.StoreD(proc, 11, scaleCStep);
			SZXCArimAPI.StoreS(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.Store(proc, 14, contrast);
			SZXCArimAPI.StoreI(proc, 15, minContrast);
			SZXCArimAPI.Store(proc, 16, genParamName);
			SZXCArimAPI.Store(proc, 17, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HDeformableModel(HImage template, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(980);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.Store(proc, 13, minContrast);
			SZXCArimAPI.Store(proc, 14, genParamName);
			SZXCArimAPI.Store(proc, 15, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HDeformableModel(HImage template, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(980);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.StoreI(proc, 13, minContrast);
			SZXCArimAPI.Store(proc, 14, genParamName);
			SZXCArimAPI.Store(proc, 15, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeDeformableModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HDeformableModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeDeformableModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeDeformableModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HDeformableModel Deserialize(Stream stream)
		{
			HDeformableModel arg_0C_0 = new HDeformableModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeDeformableModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HDeformableModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeDeformableModel();
			HDeformableModel expr_0C = new HDeformableModel();
			expr_0C.DeserializeDeformableModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void GetDeformableModelOrigin(out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(957);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SetDeformableModelOrigin(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(958);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetDeformableModelParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(959);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetDeformableModelParams(HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(960);
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

		public HTuple GetDeformableModelParams(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(960);
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

		public HXLDCont GetDeformableModelContours(int level)
		{
			IntPtr proc = SZXCArimAPI.PreCall(961);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, level);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeDeformableModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(963);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeDeformableModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(964);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadDeformableModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(965);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteDeformableModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(966);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void ClearDeformableModel(HDeformableModel[] modelID)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelID);
			IntPtr expr_13 = SZXCArimAPI.PreCall(968);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(modelID);
		}

		public void ClearDeformableModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(968);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage FindLocalDeformableModel(HImage image, out HImage vectorField, out HXLDCont deformedContours, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, int numLevels, double greediness, HTuple resultType, HTuple genParamName, HTuple genParamValue, out HTuple score, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(969);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleRMin);
			SZXCArimAPI.StoreD(proc, 4, scaleRMax);
			SZXCArimAPI.StoreD(proc, 5, scaleCMin);
			SZXCArimAPI.StoreD(proc, 6, scaleCMax);
			SZXCArimAPI.StoreD(proc, 7, minScore);
			SZXCArimAPI.StoreI(proc, 8, numMatches);
			SZXCArimAPI.StoreD(proc, 9, maxOverlap);
			SZXCArimAPI.StoreI(proc, 10, numLevels);
			SZXCArimAPI.StoreD(proc, 11, greediness);
			SZXCArimAPI.Store(proc, 12, resultType);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultType);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out vectorField);
			num = HXLDCont.LoadNew(proc, 3, num, out deformedContours);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HPose[] FindPlanarCalibDeformableModel(HImage image, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, HTuple numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple covPose, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(970);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleRMin);
			SZXCArimAPI.StoreD(proc, 4, scaleRMax);
			SZXCArimAPI.StoreD(proc, 5, scaleCMin);
			SZXCArimAPI.StoreD(proc, 6, scaleCMax);
			SZXCArimAPI.StoreD(proc, 7, minScore);
			SZXCArimAPI.StoreI(proc, 8, numMatches);
			SZXCArimAPI.StoreD(proc, 9, maxOverlap);
			SZXCArimAPI.Store(proc, 10, numLevels);
			SZXCArimAPI.StoreD(proc, 11, greediness);
			SZXCArimAPI.Store(proc, 12, genParamName);
			SZXCArimAPI.Store(proc, 13, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_103_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return arg_103_0;
		}

		public HPose FindPlanarCalibDeformableModel(HImage image, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, int numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple covPose, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(970);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleRMin);
			SZXCArimAPI.StoreD(proc, 4, scaleRMax);
			SZXCArimAPI.StoreD(proc, 5, scaleCMin);
			SZXCArimAPI.StoreD(proc, 6, scaleCMax);
			SZXCArimAPI.StoreD(proc, 7, minScore);
			SZXCArimAPI.StoreI(proc, 8, numMatches);
			SZXCArimAPI.StoreD(proc, 9, maxOverlap);
			SZXCArimAPI.StoreI(proc, 10, numLevels);
			SZXCArimAPI.StoreD(proc, 11, greediness);
			SZXCArimAPI.Store(proc, 12, genParamName);
			SZXCArimAPI.Store(proc, 13, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HHomMat2D[] FindPlanarUncalibDeformableModel(HImage image, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, HTuple numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(971);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleRMin);
			SZXCArimAPI.StoreD(proc, 4, scaleRMax);
			SZXCArimAPI.StoreD(proc, 5, scaleCMin);
			SZXCArimAPI.StoreD(proc, 6, scaleCMax);
			SZXCArimAPI.StoreD(proc, 7, minScore);
			SZXCArimAPI.StoreI(proc, 8, numMatches);
			SZXCArimAPI.StoreD(proc, 9, maxOverlap);
			SZXCArimAPI.Store(proc, 10, numLevels);
			SZXCArimAPI.StoreD(proc, 11, greediness);
			SZXCArimAPI.Store(proc, 12, genParamName);
			SZXCArimAPI.Store(proc, 13, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			HHomMat2D[] arg_EF_0 = HHomMat2D.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return arg_EF_0;
		}

		public HHomMat2D FindPlanarUncalibDeformableModel(HImage image, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, int numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(971);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleRMin);
			SZXCArimAPI.StoreD(proc, 4, scaleRMax);
			SZXCArimAPI.StoreD(proc, 5, scaleCMin);
			SZXCArimAPI.StoreD(proc, 6, scaleCMax);
			SZXCArimAPI.StoreD(proc, 7, minScore);
			SZXCArimAPI.StoreI(proc, 8, numMatches);
			SZXCArimAPI.StoreD(proc, 9, maxOverlap);
			SZXCArimAPI.StoreI(proc, 10, numLevels);
			SZXCArimAPI.StoreD(proc, 11, greediness);
			SZXCArimAPI.Store(proc, 12, genParamName);
			SZXCArimAPI.Store(proc, 13, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void SetLocalDeformableModelMetric(HImage image, HImage vectorField, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(972);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, vectorField);
			SZXCArimAPI.StoreS(proc, 1, metric);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(vectorField);
		}

		public void SetPlanarCalibDeformableModelMetric(HImage image, HPose pose, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(973);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, pose);
			SZXCArimAPI.StoreS(proc, 2, metric);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void SetPlanarUncalibDeformableModelMetric(HImage image, HHomMat2D homMat2D, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(974);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, homMat2D);
			SZXCArimAPI.StoreS(proc, 2, metric);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void CreateLocalDeformableModelXld(HXLDCont contours, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(975);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateLocalDeformableModelXld(HXLDCont contours, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(975);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreatePlanarCalibDeformableModelXld(HXLDCont contours, HCamPar camParam, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(976);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.Store(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.Store(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.Store(proc, 11, scaleCStep);
			SZXCArimAPI.Store(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreatePlanarCalibDeformableModelXld(HXLDCont contours, HCamPar camParam, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(976);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreI(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.StoreD(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.StoreD(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.StoreD(proc, 11, scaleCStep);
			SZXCArimAPI.StoreS(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreatePlanarUncalibDeformableModelXld(HXLDCont contours, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(977);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreatePlanarUncalibDeformableModelXld(HXLDCont contours, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(977);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateLocalDeformableModel(HImage template, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(978);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.Store(proc, 13, minContrast);
			SZXCArimAPI.Store(proc, 14, genParamName);
			SZXCArimAPI.Store(proc, 15, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateLocalDeformableModel(HImage template, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(978);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.StoreI(proc, 13, minContrast);
			SZXCArimAPI.Store(proc, 14, genParamName);
			SZXCArimAPI.Store(proc, 15, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreatePlanarCalibDeformableModel(HImage template, HCamPar camParam, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(979);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.Store(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.Store(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.Store(proc, 11, scaleCStep);
			SZXCArimAPI.Store(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.Store(proc, 14, contrast);
			SZXCArimAPI.Store(proc, 15, minContrast);
			SZXCArimAPI.Store(proc, 16, genParamName);
			SZXCArimAPI.Store(proc, 17, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreatePlanarCalibDeformableModel(HImage template, HCamPar camParam, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(979);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreI(proc, 2, numLevels);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.StoreD(proc, 5, angleStep);
			SZXCArimAPI.StoreD(proc, 6, scaleRMin);
			SZXCArimAPI.Store(proc, 7, scaleRMax);
			SZXCArimAPI.StoreD(proc, 8, scaleRStep);
			SZXCArimAPI.StoreD(proc, 9, scaleCMin);
			SZXCArimAPI.Store(proc, 10, scaleCMax);
			SZXCArimAPI.StoreD(proc, 11, scaleCStep);
			SZXCArimAPI.StoreS(proc, 12, optimization);
			SZXCArimAPI.StoreS(proc, 13, metric);
			SZXCArimAPI.Store(proc, 14, contrast);
			SZXCArimAPI.StoreI(proc, 15, minContrast);
			SZXCArimAPI.Store(proc, 16, genParamName);
			SZXCArimAPI.Store(proc, 17, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreatePlanarUncalibDeformableModel(HImage template, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(980);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.Store(proc, 13, minContrast);
			SZXCArimAPI.Store(proc, 14, genParamName);
			SZXCArimAPI.Store(proc, 15, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreatePlanarUncalibDeformableModel(HImage template, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(980);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.Store(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.Store(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.StoreI(proc, 13, minContrast);
			SZXCArimAPI.Store(proc, 14, genParamName);
			SZXCArimAPI.Store(proc, 15, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}
	}
}
