using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HShapeModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("shape_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel obj)
		{
			obj = new HShapeModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HShapeModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HShapeModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HShapeModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(917);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HShapeModel(HXLDCont contours, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleRMin, double scaleRMax, HTuple scaleRStep, double scaleCMin, double scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(935);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HShapeModel(HXLDCont contours, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleRMin, double scaleRMax, double scaleRStep, double scaleCMin, double scaleCMax, double scaleCStep, string optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(935);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HShapeModel(HXLDCont contours, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleMin, double scaleMax, HTuple scaleStep, HTuple optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(936);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.Store(proc, 6, scaleStep);
			SZXCArimAPI.Store(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.StoreI(proc, 9, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HShapeModel(HXLDCont contours, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleMin, double scaleMax, double scaleStep, string optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(936);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.StoreD(proc, 6, scaleStep);
			SZXCArimAPI.StoreS(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.StoreI(proc, 9, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HShapeModel(HXLDCont contours, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, HTuple optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(937);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.Store(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HShapeModel(HXLDCont contours, int numLevels, double angleStart, double angleExtent, double angleStep, string optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(937);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public HShapeModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleRMin, double scaleRMax, HTuple scaleRStep, double scaleCMin, double scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(938);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.Store(proc, 13, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HShapeModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleRMin, double scaleRMax, double scaleRStep, double scaleCMin, double scaleCMax, double scaleCStep, string optimization, string metric, int contrast, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(938);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, contrast);
			SZXCArimAPI.StoreI(proc, 13, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HShapeModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleMin, double scaleMax, HTuple scaleStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(939);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.Store(proc, 6, scaleStep);
			SZXCArimAPI.Store(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.Store(proc, 9, contrast);
			SZXCArimAPI.Store(proc, 10, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HShapeModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleMin, double scaleMax, double scaleStep, string optimization, string metric, int contrast, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(939);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.StoreD(proc, 6, scaleStep);
			SZXCArimAPI.StoreS(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.StoreI(proc, 9, contrast);
			SZXCArimAPI.StoreI(proc, 10, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HShapeModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(940);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.Store(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.Store(proc, 6, contrast);
			SZXCArimAPI.Store(proc, 7, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HShapeModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, string optimization, string metric, int contrast, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(940);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, contrast);
			SZXCArimAPI.StoreI(proc, 7, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeShapeModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HShapeModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeShapeModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeShapeModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HShapeModel Deserialize(Stream stream)
		{
			HShapeModel arg_0C_0 = new HShapeModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeShapeModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HShapeModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeShapeModel();
			HShapeModel expr_0C = new HShapeModel();
			expr_0C.DeserializeShapeModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void DeserializeShapeModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(916);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public void ReadShapeModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(917);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HSerializedItem SerializeShapeModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(918);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WriteShapeModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(919);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearShapeModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(921);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HXLDCont GetShapeModelContours(int level)
		{
			IntPtr proc = SZXCArimAPI.PreCall(922);
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

		public int GetShapeModelParams(out double angleStart, out double angleExtent, out double angleStep, out HTuple scaleMin, out HTuple scaleMax, out HTuple scaleStep, out string metric, out int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(924);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			SZXCArimAPI.InitOCT(proc, 8);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out angleStart);
			num = SZXCArimAPI.LoadD(proc, 2, num, out angleExtent);
			num = SZXCArimAPI.LoadD(proc, 3, num, out angleStep);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out scaleMin);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out scaleMax);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out scaleStep);
			num = SZXCArimAPI.LoadS(proc, 7, num, out metric);
			num = SZXCArimAPI.LoadI(proc, 8, num, out minContrast);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int GetShapeModelParams(out double angleStart, out double angleExtent, out double angleStep, out double scaleMin, out double scaleMax, out double scaleStep, out string metric, out int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(924);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			SZXCArimAPI.InitOCT(proc, 8);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out angleStart);
			num = SZXCArimAPI.LoadD(proc, 2, num, out angleExtent);
			num = SZXCArimAPI.LoadD(proc, 3, num, out angleStep);
			num = SZXCArimAPI.LoadD(proc, 4, num, out scaleMin);
			num = SZXCArimAPI.LoadD(proc, 5, num, out scaleMax);
			num = SZXCArimAPI.LoadD(proc, 6, num, out scaleStep);
			num = SZXCArimAPI.LoadS(proc, 7, num, out metric);
			num = SZXCArimAPI.LoadI(proc, 8, num, out minContrast);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetShapeModelOrigin(out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(925);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SetShapeModelOrigin(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(926);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void FindAnisoShapeModels(HImage image, HShapeModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple scaleRMin, HTuple scaleRMax, HTuple scaleCMin, HTuple scaleCMax, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, HTuple greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr expr_13 = SZXCArimAPI.PreCall(927);
			SZXCArimAPI.Store(expr_13, 1, image);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, angleStart);
			SZXCArimAPI.Store(expr_13, 2, angleExtent);
			SZXCArimAPI.Store(expr_13, 3, scaleRMin);
			SZXCArimAPI.Store(expr_13, 4, scaleRMax);
			SZXCArimAPI.Store(expr_13, 5, scaleCMin);
			SZXCArimAPI.Store(expr_13, 6, scaleCMax);
			SZXCArimAPI.Store(expr_13, 7, minScore);
			SZXCArimAPI.Store(expr_13, 8, numMatches);
			SZXCArimAPI.Store(expr_13, 9, maxOverlap);
			SZXCArimAPI.Store(expr_13, 10, subPixel);
			SZXCArimAPI.Store(expr_13, 11, numLevels);
			SZXCArimAPI.Store(expr_13, 12, greediness);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			SZXCArimAPI.InitOCT(expr_13, 2);
			SZXCArimAPI.InitOCT(expr_13, 3);
			SZXCArimAPI.InitOCT(expr_13, 4);
			SZXCArimAPI.InitOCT(expr_13, 5);
			SZXCArimAPI.InitOCT(expr_13, 6);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMin);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMin);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(numMatches);
			SZXCArimAPI.UnpinTuple(maxOverlap);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(greediness);
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(expr_13, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(expr_13, 3, HTupleType.DOUBLE, num, out scaleR);
			num = HTuple.LoadNew(expr_13, 4, HTupleType.DOUBLE, num, out scaleC);
			num = HTuple.LoadNew(expr_13, 5, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(expr_13, 6, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(image);
			GC.KeepAlive(modelIDs);
		}

		public void FindAnisoShapeModels(HImage image, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(927);
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
			SZXCArimAPI.StoreS(proc, 10, subPixel);
			SZXCArimAPI.StoreI(proc, 11, numLevels);
			SZXCArimAPI.StoreD(proc, 12, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scaleR);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out scaleC);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public static void FindScaledShapeModels(HImage image, HShapeModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple scaleMin, HTuple scaleMax, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, HTuple greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr expr_13 = SZXCArimAPI.PreCall(928);
			SZXCArimAPI.Store(expr_13, 1, image);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, angleStart);
			SZXCArimAPI.Store(expr_13, 2, angleExtent);
			SZXCArimAPI.Store(expr_13, 3, scaleMin);
			SZXCArimAPI.Store(expr_13, 4, scaleMax);
			SZXCArimAPI.Store(expr_13, 5, minScore);
			SZXCArimAPI.Store(expr_13, 6, numMatches);
			SZXCArimAPI.Store(expr_13, 7, maxOverlap);
			SZXCArimAPI.Store(expr_13, 8, subPixel);
			SZXCArimAPI.Store(expr_13, 9, numLevels);
			SZXCArimAPI.Store(expr_13, 10, greediness);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			SZXCArimAPI.InitOCT(expr_13, 2);
			SZXCArimAPI.InitOCT(expr_13, 3);
			SZXCArimAPI.InitOCT(expr_13, 4);
			SZXCArimAPI.InitOCT(expr_13, 5);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleMin);
			SZXCArimAPI.UnpinTuple(scaleMax);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(numMatches);
			SZXCArimAPI.UnpinTuple(maxOverlap);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(greediness);
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(expr_13, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(expr_13, 3, HTupleType.DOUBLE, num, out scale);
			num = HTuple.LoadNew(expr_13, 4, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(expr_13, 5, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(image);
			GC.KeepAlive(modelIDs);
		}

		public void FindScaledShapeModels(HImage image, double angleStart, double angleExtent, double scaleMin, double scaleMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(928);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleMin);
			SZXCArimAPI.StoreD(proc, 4, scaleMax);
			SZXCArimAPI.StoreD(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.StoreD(proc, 7, maxOverlap);
			SZXCArimAPI.StoreS(proc, 8, subPixel);
			SZXCArimAPI.StoreI(proc, 9, numLevels);
			SZXCArimAPI.StoreD(proc, 10, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scale);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public static void FindShapeModels(HImage image, HShapeModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, HTuple greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr expr_13 = SZXCArimAPI.PreCall(929);
			SZXCArimAPI.Store(expr_13, 1, image);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, angleStart);
			SZXCArimAPI.Store(expr_13, 2, angleExtent);
			SZXCArimAPI.Store(expr_13, 3, minScore);
			SZXCArimAPI.Store(expr_13, 4, numMatches);
			SZXCArimAPI.Store(expr_13, 5, maxOverlap);
			SZXCArimAPI.Store(expr_13, 6, subPixel);
			SZXCArimAPI.Store(expr_13, 7, numLevels);
			SZXCArimAPI.Store(expr_13, 8, greediness);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			SZXCArimAPI.InitOCT(expr_13, 2);
			SZXCArimAPI.InitOCT(expr_13, 3);
			SZXCArimAPI.InitOCT(expr_13, 4);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(numMatches);
			SZXCArimAPI.UnpinTuple(maxOverlap);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(greediness);
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(expr_13, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(expr_13, 3, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(expr_13, 4, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(image);
			GC.KeepAlive(modelIDs);
		}

		public void FindShapeModels(HImage image, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(929);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, numMatches);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.StoreS(proc, 6, subPixel);
			SZXCArimAPI.StoreI(proc, 7, numLevels);
			SZXCArimAPI.StoreD(proc, 8, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FindAnisoShapeModel(HImage image, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, HTuple minScore, int numMatches, double maxOverlap, HTuple subPixel, HTuple numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(930);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleRMin);
			SZXCArimAPI.StoreD(proc, 4, scaleRMax);
			SZXCArimAPI.StoreD(proc, 5, scaleCMin);
			SZXCArimAPI.StoreD(proc, 6, scaleCMax);
			SZXCArimAPI.Store(proc, 7, minScore);
			SZXCArimAPI.StoreI(proc, 8, numMatches);
			SZXCArimAPI.StoreD(proc, 9, maxOverlap);
			SZXCArimAPI.Store(proc, 10, subPixel);
			SZXCArimAPI.Store(proc, 11, numLevels);
			SZXCArimAPI.StoreD(proc, 12, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scaleR);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out scaleC);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FindAnisoShapeModel(HImage image, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(930);
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
			SZXCArimAPI.StoreS(proc, 10, subPixel);
			SZXCArimAPI.StoreI(proc, 11, numLevels);
			SZXCArimAPI.StoreD(proc, 12, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scaleR);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out scaleC);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FindScaledShapeModel(HImage image, double angleStart, double angleExtent, double scaleMin, double scaleMax, HTuple minScore, int numMatches, double maxOverlap, HTuple subPixel, HTuple numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(931);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleMin);
			SZXCArimAPI.StoreD(proc, 4, scaleMax);
			SZXCArimAPI.Store(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.StoreD(proc, 7, maxOverlap);
			SZXCArimAPI.Store(proc, 8, subPixel);
			SZXCArimAPI.Store(proc, 9, numLevels);
			SZXCArimAPI.StoreD(proc, 10, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scale);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FindScaledShapeModel(HImage image, double angleStart, double angleExtent, double scaleMin, double scaleMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(931);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleMin);
			SZXCArimAPI.StoreD(proc, 4, scaleMax);
			SZXCArimAPI.StoreD(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.StoreD(proc, 7, maxOverlap);
			SZXCArimAPI.StoreS(proc, 8, subPixel);
			SZXCArimAPI.StoreI(proc, 9, numLevels);
			SZXCArimAPI.StoreD(proc, 10, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scale);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FindShapeModel(HImage image, double angleStart, double angleExtent, HTuple minScore, int numMatches, double maxOverlap, HTuple subPixel, HTuple numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(932);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, numMatches);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.Store(proc, 6, subPixel);
			SZXCArimAPI.Store(proc, 7, numLevels);
			SZXCArimAPI.StoreD(proc, 8, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FindShapeModel(HImage image, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(932);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, numMatches);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.StoreS(proc, 6, subPixel);
			SZXCArimAPI.StoreI(proc, 7, numLevels);
			SZXCArimAPI.StoreD(proc, 8, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void SetShapeModelMetric(HImage image, HHomMat2D homMat2D, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(933);
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

		public void SetShapeModelParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(934);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateAnisoShapeModelXld(HXLDCont contours, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleRMin, double scaleRMax, HTuple scaleRStep, double scaleCMin, double scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(935);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateAnisoShapeModelXld(HXLDCont contours, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleRMin, double scaleRMax, double scaleRStep, double scaleCMin, double scaleCMax, double scaleCStep, string optimization, string metric, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(935);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateScaledShapeModelXld(HXLDCont contours, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleMin, double scaleMax, HTuple scaleStep, HTuple optimization, string metric, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(936);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.Store(proc, 6, scaleStep);
			SZXCArimAPI.Store(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.StoreI(proc, 9, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateScaledShapeModelXld(HXLDCont contours, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleMin, double scaleMax, double scaleStep, string optimization, string metric, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(936);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.StoreD(proc, 6, scaleStep);
			SZXCArimAPI.StoreS(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.StoreI(proc, 9, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateShapeModelXld(HXLDCont contours, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, HTuple optimization, string metric, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(937);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.Store(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateShapeModelXld(HXLDCont contours, int numLevels, double angleStart, double angleExtent, double angleStep, string optimization, string metric, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(937);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
		}

		public void CreateAnisoShapeModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleRMin, double scaleRMax, HTuple scaleRStep, double scaleCMin, double scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(938);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.Store(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.Store(proc, 9, scaleCStep);
			SZXCArimAPI.Store(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.Store(proc, 12, contrast);
			SZXCArimAPI.Store(proc, 13, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateAnisoShapeModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleRMin, double scaleRMax, double scaleRStep, double scaleCMin, double scaleCMax, double scaleCStep, string optimization, string metric, int contrast, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(938);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleRMin);
			SZXCArimAPI.StoreD(proc, 5, scaleRMax);
			SZXCArimAPI.StoreD(proc, 6, scaleRStep);
			SZXCArimAPI.StoreD(proc, 7, scaleCMin);
			SZXCArimAPI.StoreD(proc, 8, scaleCMax);
			SZXCArimAPI.StoreD(proc, 9, scaleCStep);
			SZXCArimAPI.StoreS(proc, 10, optimization);
			SZXCArimAPI.StoreS(proc, 11, metric);
			SZXCArimAPI.StoreI(proc, 12, contrast);
			SZXCArimAPI.StoreI(proc, 13, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateScaledShapeModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleMin, double scaleMax, HTuple scaleStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(939);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.Store(proc, 6, scaleStep);
			SZXCArimAPI.Store(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.Store(proc, 9, contrast);
			SZXCArimAPI.Store(proc, 10, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateScaledShapeModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, double scaleMin, double scaleMax, double scaleStep, string optimization, string metric, int contrast, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(939);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreD(proc, 4, scaleMin);
			SZXCArimAPI.StoreD(proc, 5, scaleMax);
			SZXCArimAPI.StoreD(proc, 6, scaleStep);
			SZXCArimAPI.StoreS(proc, 7, optimization);
			SZXCArimAPI.StoreS(proc, 8, metric);
			SZXCArimAPI.StoreI(proc, 9, contrast);
			SZXCArimAPI.StoreI(proc, 10, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateShapeModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(940);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.Store(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.Store(proc, 6, contrast);
			SZXCArimAPI.Store(proc, 7, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateShapeModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, string optimization, string metric, int contrast, int minContrast)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(940);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, contrast);
			SZXCArimAPI.StoreI(proc, 7, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HRegion GetShapeModelClutter(HTuple genParamName, out HTuple genParamValue, out HHomMat2D homMat2D, out int clutterContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2178);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, num, out genParamValue);
			num = HHomMat2D.LoadNew(proc, 1, num, out homMat2D);
			num = SZXCArimAPI.LoadI(proc, 2, num, out clutterContrast);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetShapeModelClutter(string genParamName, out string genParamValue, out HHomMat2D homMat2D, out int clutterContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2178);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadS(proc, 0, num, out genParamValue);
			num = HHomMat2D.LoadNew(proc, 1, num, out homMat2D);
			num = SZXCArimAPI.LoadI(proc, 2, num, out clutterContrast);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetShapeModelClutter(HRegion clutterRegion, HHomMat2D homMat2D, int clutterContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2180);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, clutterRegion);
			SZXCArimAPI.Store(proc, 1, homMat2D);
			SZXCArimAPI.StoreI(proc, 2, clutterContrast);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(clutterRegion);
		}

		public void SetShapeModelClutter(HRegion clutterRegion, HHomMat2D homMat2D, int clutterContrast, string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2180);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, clutterRegion);
			SZXCArimAPI.Store(proc, 1, homMat2D);
			SZXCArimAPI.StoreI(proc, 2, clutterContrast);
			SZXCArimAPI.StoreS(proc, 3, genParamName);
			SZXCArimAPI.StoreD(proc, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(clutterRegion);
		}
	}
}
