using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HNCCModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HNCCModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HNCCModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HNCCModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("ncc_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HNCCModel obj)
		{
			obj = new HNCCModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HNCCModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HNCCModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HNCCModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HNCCModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(985);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HNCCModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(993);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, metric);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HNCCModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(993);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, metric);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeNccModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HNCCModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeNccModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeNccModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HNCCModel Deserialize(Stream stream)
		{
			HNCCModel arg_0C_0 = new HNCCModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeNccModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HNCCModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeNccModel();
			HNCCModel expr_0C = new HNCCModel();
			expr_0C.DeserializeNccModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void ClearNccModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(982);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeNccModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(983);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeNccModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(984);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadNccModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(985);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteNccModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(986);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static HTuple DetermineNccModelParams(HImage template, HTuple numLevels, double angleStart, double angleExtent, string metric, HTuple parameters, out HTuple parameterValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(987);
			SZXCArimAPI.Store(expr_0A, 1, template);
			SZXCArimAPI.Store(expr_0A, 0, numLevels);
			SZXCArimAPI.StoreD(expr_0A, 1, angleStart);
			SZXCArimAPI.StoreD(expr_0A, 2, angleExtent);
			SZXCArimAPI.StoreS(expr_0A, 3, metric);
			SZXCArimAPI.Store(expr_0A, 4, parameters);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(parameters);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out parameterValue);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(template);
			return result;
		}

		public static HTuple DetermineNccModelParams(HImage template, int numLevels, double angleStart, double angleExtent, string metric, string parameters, out HTuple parameterValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(987);
			SZXCArimAPI.Store(expr_0A, 1, template);
			SZXCArimAPI.StoreI(expr_0A, 0, numLevels);
			SZXCArimAPI.StoreD(expr_0A, 1, angleStart);
			SZXCArimAPI.StoreD(expr_0A, 2, angleExtent);
			SZXCArimAPI.StoreS(expr_0A, 3, metric);
			SZXCArimAPI.StoreS(expr_0A, 4, parameters);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out parameterValue);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(template);
			return result;
		}

		public int GetNccModelParams(out double angleStart, out double angleExtent, out double angleStep, out string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(988);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out angleStart);
			num = SZXCArimAPI.LoadD(proc, 2, num, out angleExtent);
			num = SZXCArimAPI.LoadD(proc, 3, num, out angleStep);
			num = SZXCArimAPI.LoadS(proc, 4, num, out metric);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetNccModelOrigin(out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(989);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SetNccModelOrigin(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(990);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void FindNccModel(HImage image, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, HTuple numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(991);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, numMatches);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.StoreS(proc, 6, subPixel);
			SZXCArimAPI.Store(proc, 7, numLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FindNccModel(HImage image, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(991);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, numMatches);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.StoreS(proc, 6, subPixel);
			SZXCArimAPI.StoreI(proc, 7, numLevels);
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

		public void SetNccModelParam(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(992);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateNccModel(HImage template, HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, string metric)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(993);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, metric);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateNccModel(HImage template, int numLevels, double angleStart, double angleExtent, double angleStep, string metric)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(993);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, metric);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public static void FindNccModels(HImage image, HNCCModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr expr_13 = SZXCArimAPI.PreCall(2068);
			SZXCArimAPI.Store(expr_13, 1, image);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, angleStart);
			SZXCArimAPI.Store(expr_13, 2, angleExtent);
			SZXCArimAPI.Store(expr_13, 3, minScore);
			SZXCArimAPI.Store(expr_13, 4, numMatches);
			SZXCArimAPI.Store(expr_13, 5, maxOverlap);
			SZXCArimAPI.Store(expr_13, 6, subPixel);
			SZXCArimAPI.Store(expr_13, 7, numLevels);
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
			num = HTuple.LoadNew(expr_13, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(expr_13, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(expr_13, 3, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(expr_13, 4, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(expr_13, num);
			GC.KeepAlive(image);
			GC.KeepAlive(modelIDs);
		}

		public void FindNccModels(HImage image, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2068);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, numMatches);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.StoreS(proc, 6, subPixel);
			SZXCArimAPI.StoreI(proc, 7, numLevels);
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

		public HRegion GetNccModelRegion()
		{
			IntPtr proc = SZXCArimAPI.PreCall(2071);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
