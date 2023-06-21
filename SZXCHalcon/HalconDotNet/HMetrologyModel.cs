using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HMetrologyModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMetrologyModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMetrologyModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("metrology_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMetrologyModel obj)
		{
			obj = new HMetrologyModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMetrologyModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HMetrologyModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HMetrologyModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HMetrologyModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(798);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMetrologyModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(820);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeMetrologyModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMetrologyModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeMetrologyModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeMetrologyModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HMetrologyModel Deserialize(Stream stream)
		{
			HMetrologyModel arg_0C_0 = new HMetrologyModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeMetrologyModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HMetrologyModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeMetrologyModel();
			HMetrologyModel expr_0C = new HMetrologyModel();
			expr_0C.DeserializeMetrologyModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HXLDCont GetMetrologyObjectModelContour(HTuple index, double resolution)
		{
			IntPtr proc = SZXCArimAPI.PreCall(788);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.StoreD(proc, 2, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GetMetrologyObjectModelContour(int index, double resolution)
		{
			IntPtr proc = SZXCArimAPI.PreCall(788);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, index);
			SZXCArimAPI.StoreD(proc, 2, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GetMetrologyObjectResultContour(HTuple index, HTuple instance, double resolution)
		{
			IntPtr proc = SZXCArimAPI.PreCall(789);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, instance);
			SZXCArimAPI.StoreD(proc, 3, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(instance);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GetMetrologyObjectResultContour(int index, string instance, double resolution)
		{
			IntPtr proc = SZXCArimAPI.PreCall(789);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, index);
			SZXCArimAPI.StoreS(proc, 2, instance);
			SZXCArimAPI.StoreD(proc, 3, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AlignMetrologyModel(HTuple row, HTuple column, HTuple angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(790);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, angle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(angle);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AlignMetrologyModel(double row, double column, double angle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(790);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, angle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int AddMetrologyObjectGeneric(HTuple shape, HTuple shapeParam, HTuple measureLength1, HTuple measureLength2, HTuple measureSigma, HTuple measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(791);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, shape);
			SZXCArimAPI.Store(proc, 2, shapeParam);
			SZXCArimAPI.Store(proc, 3, measureLength1);
			SZXCArimAPI.Store(proc, 4, measureLength2);
			SZXCArimAPI.Store(proc, 5, measureSigma);
			SZXCArimAPI.Store(proc, 6, measureThreshold);
			SZXCArimAPI.Store(proc, 7, genParamName);
			SZXCArimAPI.Store(proc, 8, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(shape);
			SZXCArimAPI.UnpinTuple(shapeParam);
			SZXCArimAPI.UnpinTuple(measureLength1);
			SZXCArimAPI.UnpinTuple(measureLength2);
			SZXCArimAPI.UnpinTuple(measureSigma);
			SZXCArimAPI.UnpinTuple(measureThreshold);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectGeneric(string shape, HTuple shapeParam, double measureLength1, double measureLength2, double measureSigma, double measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(791);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, shape);
			SZXCArimAPI.Store(proc, 2, shapeParam);
			SZXCArimAPI.StoreD(proc, 3, measureLength1);
			SZXCArimAPI.StoreD(proc, 4, measureLength2);
			SZXCArimAPI.StoreD(proc, 5, measureSigma);
			SZXCArimAPI.StoreD(proc, 6, measureThreshold);
			SZXCArimAPI.Store(proc, 7, genParamName);
			SZXCArimAPI.Store(proc, 8, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(shapeParam);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMetrologyModelParam(string genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(792);
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

		public void SetMetrologyModelParam(string genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(793);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMetrologyModelParam(string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(793);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreS(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeMetrologyModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(794);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeMetrologyModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(795);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void TransformMetrologyObject(HTuple index, HTuple row, HTuple column, HTuple phi, HTuple mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(796);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.Store(proc, 4, phi);
			SZXCArimAPI.Store(proc, 5, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(mode);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TransformMetrologyObject(string index, double row, double column, double phi, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(796);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.StoreD(proc, 2, row);
			SZXCArimAPI.StoreD(proc, 3, column);
			SZXCArimAPI.StoreD(proc, 4, phi);
			SZXCArimAPI.StoreS(proc, 5, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteMetrologyModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(797);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadMetrologyModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(798);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public int CopyMetrologyModel(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(799);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CopyMetrologyModel(string index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(799);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple CopyMetrologyObject(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(800);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CopyMetrologyObject(string index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(800);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMetrologyObjectNumInstances(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(801);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetMetrologyObjectNumInstances(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(801);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMetrologyObjectResult(HTuple index, HTuple instance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(802);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, instance);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(instance);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMetrologyObjectResult(int index, string instance, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(802);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, index);
			SZXCArimAPI.StoreS(proc, 2, instance);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GetMetrologyObjectMeasures(HTuple index, string transition, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(803);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.StoreS(proc, 2, transition);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GetMetrologyObjectMeasures(string index, string transition, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(803);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.StoreS(proc, 2, transition);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ApplyMetrologyModel(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(804);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public HTuple GetMetrologyObjectIndices()
		{
			IntPtr proc = SZXCArimAPI.PreCall(805);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ResetMetrologyObjectFuzzyParam(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(806);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ResetMetrologyObjectFuzzyParam(string index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(806);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ResetMetrologyObjectParam(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(807);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ResetMetrologyObjectParam(string index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(807);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple GetMetrologyObjectFuzzyParam(HTuple index, HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(808);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMetrologyObjectFuzzyParam(string index, HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(808);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMetrologyObjectParam(HTuple index, HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(809);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetMetrologyObjectParam(string index, HTuple genParamName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(809);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SetMetrologyObjectFuzzyParam(HTuple index, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(810);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMetrologyObjectFuzzyParam(string index, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(810);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMetrologyObjectParam(HTuple index, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(811);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMetrologyObjectParam(string index, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(811);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public int AddMetrologyObjectRectangle2Measure(HTuple row, HTuple column, HTuple phi, HTuple length1, HTuple length2, HTuple measureLength1, HTuple measureLength2, HTuple measureSigma, HTuple measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(812);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, phi);
			SZXCArimAPI.Store(proc, 4, length1);
			SZXCArimAPI.Store(proc, 5, length2);
			SZXCArimAPI.Store(proc, 6, measureLength1);
			SZXCArimAPI.Store(proc, 7, measureLength2);
			SZXCArimAPI.Store(proc, 8, measureSigma);
			SZXCArimAPI.Store(proc, 9, measureThreshold);
			SZXCArimAPI.Store(proc, 10, genParamName);
			SZXCArimAPI.Store(proc, 11, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(length1);
			SZXCArimAPI.UnpinTuple(length2);
			SZXCArimAPI.UnpinTuple(measureLength1);
			SZXCArimAPI.UnpinTuple(measureLength2);
			SZXCArimAPI.UnpinTuple(measureSigma);
			SZXCArimAPI.UnpinTuple(measureThreshold);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectRectangle2Measure(double row, double column, double phi, double length1, double length2, double measureLength1, double measureLength2, double measureSigma, double measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(812);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, phi);
			SZXCArimAPI.StoreD(proc, 4, length1);
			SZXCArimAPI.StoreD(proc, 5, length2);
			SZXCArimAPI.StoreD(proc, 6, measureLength1);
			SZXCArimAPI.StoreD(proc, 7, measureLength2);
			SZXCArimAPI.StoreD(proc, 8, measureSigma);
			SZXCArimAPI.StoreD(proc, 9, measureThreshold);
			SZXCArimAPI.Store(proc, 10, genParamName);
			SZXCArimAPI.Store(proc, 11, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectLineMeasure(HTuple rowBegin, HTuple columnBegin, HTuple rowEnd, HTuple columnEnd, HTuple measureLength1, HTuple measureLength2, HTuple measureSigma, HTuple measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(813);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, rowBegin);
			SZXCArimAPI.Store(proc, 2, columnBegin);
			SZXCArimAPI.Store(proc, 3, rowEnd);
			SZXCArimAPI.Store(proc, 4, columnEnd);
			SZXCArimAPI.Store(proc, 5, measureLength1);
			SZXCArimAPI.Store(proc, 6, measureLength2);
			SZXCArimAPI.Store(proc, 7, measureSigma);
			SZXCArimAPI.Store(proc, 8, measureThreshold);
			SZXCArimAPI.Store(proc, 9, genParamName);
			SZXCArimAPI.Store(proc, 10, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowBegin);
			SZXCArimAPI.UnpinTuple(columnBegin);
			SZXCArimAPI.UnpinTuple(rowEnd);
			SZXCArimAPI.UnpinTuple(columnEnd);
			SZXCArimAPI.UnpinTuple(measureLength1);
			SZXCArimAPI.UnpinTuple(measureLength2);
			SZXCArimAPI.UnpinTuple(measureSigma);
			SZXCArimAPI.UnpinTuple(measureThreshold);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectLineMeasure(double rowBegin, double columnBegin, double rowEnd, double columnEnd, double measureLength1, double measureLength2, double measureSigma, double measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(813);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, rowBegin);
			SZXCArimAPI.StoreD(proc, 2, columnBegin);
			SZXCArimAPI.StoreD(proc, 3, rowEnd);
			SZXCArimAPI.StoreD(proc, 4, columnEnd);
			SZXCArimAPI.StoreD(proc, 5, measureLength1);
			SZXCArimAPI.StoreD(proc, 6, measureLength2);
			SZXCArimAPI.StoreD(proc, 7, measureSigma);
			SZXCArimAPI.StoreD(proc, 8, measureThreshold);
			SZXCArimAPI.Store(proc, 9, genParamName);
			SZXCArimAPI.Store(proc, 10, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectEllipseMeasure(HTuple row, HTuple column, HTuple phi, HTuple radius1, HTuple radius2, HTuple measureLength1, HTuple measureLength2, HTuple measureSigma, HTuple measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(814);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, phi);
			SZXCArimAPI.Store(proc, 4, radius1);
			SZXCArimAPI.Store(proc, 5, radius2);
			SZXCArimAPI.Store(proc, 6, measureLength1);
			SZXCArimAPI.Store(proc, 7, measureLength2);
			SZXCArimAPI.Store(proc, 8, measureSigma);
			SZXCArimAPI.Store(proc, 9, measureThreshold);
			SZXCArimAPI.Store(proc, 10, genParamName);
			SZXCArimAPI.Store(proc, 11, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(radius1);
			SZXCArimAPI.UnpinTuple(radius2);
			SZXCArimAPI.UnpinTuple(measureLength1);
			SZXCArimAPI.UnpinTuple(measureLength2);
			SZXCArimAPI.UnpinTuple(measureSigma);
			SZXCArimAPI.UnpinTuple(measureThreshold);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectEllipseMeasure(double row, double column, double phi, double radius1, double radius2, double measureLength1, double measureLength2, double measureSigma, double measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(814);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, phi);
			SZXCArimAPI.StoreD(proc, 4, radius1);
			SZXCArimAPI.StoreD(proc, 5, radius2);
			SZXCArimAPI.StoreD(proc, 6, measureLength1);
			SZXCArimAPI.StoreD(proc, 7, measureLength2);
			SZXCArimAPI.StoreD(proc, 8, measureSigma);
			SZXCArimAPI.StoreD(proc, 9, measureThreshold);
			SZXCArimAPI.Store(proc, 10, genParamName);
			SZXCArimAPI.Store(proc, 11, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectCircleMeasure(HTuple row, HTuple column, HTuple radius, HTuple measureLength1, HTuple measureLength2, HTuple measureSigma, HTuple measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(815);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.Store(proc, 3, radius);
			SZXCArimAPI.Store(proc, 4, measureLength1);
			SZXCArimAPI.Store(proc, 5, measureLength2);
			SZXCArimAPI.Store(proc, 6, measureSigma);
			SZXCArimAPI.Store(proc, 7, measureThreshold);
			SZXCArimAPI.Store(proc, 8, genParamName);
			SZXCArimAPI.Store(proc, 9, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(measureLength1);
			SZXCArimAPI.UnpinTuple(measureLength2);
			SZXCArimAPI.UnpinTuple(measureSigma);
			SZXCArimAPI.UnpinTuple(measureThreshold);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AddMetrologyObjectCircleMeasure(double row, double column, double radius, double measureLength1, double measureLength2, double measureSigma, double measureThreshold, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(815);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, radius);
			SZXCArimAPI.StoreD(proc, 4, measureLength1);
			SZXCArimAPI.StoreD(proc, 5, measureLength2);
			SZXCArimAPI.StoreD(proc, 6, measureSigma);
			SZXCArimAPI.StoreD(proc, 7, measureThreshold);
			SZXCArimAPI.Store(proc, 8, genParamName);
			SZXCArimAPI.Store(proc, 9, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ClearMetrologyModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(817);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearMetrologyObject(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(818);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ClearMetrologyObject(string index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(818);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, index);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetMetrologyModelImageSize(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(819);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateMetrologyModel()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(820);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
