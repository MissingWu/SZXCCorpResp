using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HComponentModel : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentModel() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentModel(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentModel(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("component_model");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentModel obj)
		{
			obj = new HComponentModel(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentModel[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HComponentModel[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HComponentModel(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HComponentModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1002);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HComponentModel(HImage modelImage, HRegion componentRegions, HTuple variationRow, HTuple variationColumn, HTuple variationAngle, double angleStart, double angleExtent, HTuple contrastLowComp, HTuple contrastHighComp, HTuple minSizeComp, HTuple minContrastComp, HTuple minScoreComp, HTuple numLevelsComp, HTuple angleStepComp, string optimizationComp, HTuple metricComp, HTuple pregenerationComp, out HTuple rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1004);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, componentRegions);
			SZXCArimAPI.Store(proc, 0, variationRow);
			SZXCArimAPI.Store(proc, 1, variationColumn);
			SZXCArimAPI.Store(proc, 2, variationAngle);
			SZXCArimAPI.StoreD(proc, 3, angleStart);
			SZXCArimAPI.StoreD(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, contrastLowComp);
			SZXCArimAPI.Store(proc, 6, contrastHighComp);
			SZXCArimAPI.Store(proc, 7, minSizeComp);
			SZXCArimAPI.Store(proc, 8, minContrastComp);
			SZXCArimAPI.Store(proc, 9, minScoreComp);
			SZXCArimAPI.Store(proc, 10, numLevelsComp);
			SZXCArimAPI.Store(proc, 11, angleStepComp);
			SZXCArimAPI.StoreS(proc, 12, optimizationComp);
			SZXCArimAPI.Store(proc, 13, metricComp);
			SZXCArimAPI.Store(proc, 14, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(variationRow);
			SZXCArimAPI.UnpinTuple(variationColumn);
			SZXCArimAPI.UnpinTuple(variationAngle);
			SZXCArimAPI.UnpinTuple(contrastLowComp);
			SZXCArimAPI.UnpinTuple(contrastHighComp);
			SZXCArimAPI.UnpinTuple(minSizeComp);
			SZXCArimAPI.UnpinTuple(minContrastComp);
			SZXCArimAPI.UnpinTuple(minScoreComp);
			SZXCArimAPI.UnpinTuple(numLevelsComp);
			SZXCArimAPI.UnpinTuple(angleStepComp);
			SZXCArimAPI.UnpinTuple(metricComp);
			SZXCArimAPI.UnpinTuple(pregenerationComp);
			num = base.Load(proc, 0, num);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(componentRegions);
		}

		public HComponentModel(HImage modelImage, HRegion componentRegions, int variationRow, int variationColumn, double variationAngle, double angleStart, double angleExtent, int contrastLowComp, int contrastHighComp, int minSizeComp, int minContrastComp, double minScoreComp, int numLevelsComp, double angleStepComp, string optimizationComp, string metricComp, string pregenerationComp, out int rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1004);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, componentRegions);
			SZXCArimAPI.StoreI(proc, 0, variationRow);
			SZXCArimAPI.StoreI(proc, 1, variationColumn);
			SZXCArimAPI.StoreD(proc, 2, variationAngle);
			SZXCArimAPI.StoreD(proc, 3, angleStart);
			SZXCArimAPI.StoreD(proc, 4, angleExtent);
			SZXCArimAPI.StoreI(proc, 5, contrastLowComp);
			SZXCArimAPI.StoreI(proc, 6, contrastHighComp);
			SZXCArimAPI.StoreI(proc, 7, minSizeComp);
			SZXCArimAPI.StoreI(proc, 8, minContrastComp);
			SZXCArimAPI.StoreD(proc, 9, minScoreComp);
			SZXCArimAPI.StoreI(proc, 10, numLevelsComp);
			SZXCArimAPI.StoreD(proc, 11, angleStepComp);
			SZXCArimAPI.StoreS(proc, 12, optimizationComp);
			SZXCArimAPI.StoreS(proc, 13, metricComp);
			SZXCArimAPI.StoreS(proc, 14, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			num = SZXCArimAPI.LoadI(proc, 1, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(componentRegions);
		}

		public HComponentModel(HComponentTraining componentTrainingID, double angleStart, double angleExtent, HTuple minContrastComp, HTuple minScoreComp, HTuple numLevelsComp, HTuple angleStepComp, string optimizationComp, HTuple metricComp, HTuple pregenerationComp, out HTuple rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1005);
			SZXCArimAPI.Store(proc, 0, componentTrainingID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, minContrastComp);
			SZXCArimAPI.Store(proc, 4, minScoreComp);
			SZXCArimAPI.Store(proc, 5, numLevelsComp);
			SZXCArimAPI.Store(proc, 6, angleStepComp);
			SZXCArimAPI.StoreS(proc, 7, optimizationComp);
			SZXCArimAPI.Store(proc, 8, metricComp);
			SZXCArimAPI.Store(proc, 9, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minContrastComp);
			SZXCArimAPI.UnpinTuple(minScoreComp);
			SZXCArimAPI.UnpinTuple(numLevelsComp);
			SZXCArimAPI.UnpinTuple(angleStepComp);
			SZXCArimAPI.UnpinTuple(metricComp);
			SZXCArimAPI.UnpinTuple(pregenerationComp);
			num = base.Load(proc, 0, num);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(componentTrainingID);
		}

		public HComponentModel(HComponentTraining componentTrainingID, double angleStart, double angleExtent, int minContrastComp, double minScoreComp, int numLevelsComp, double angleStepComp, string optimizationComp, string metricComp, string pregenerationComp, out int rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1005);
			SZXCArimAPI.Store(proc, 0, componentTrainingID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreI(proc, 3, minContrastComp);
			SZXCArimAPI.StoreD(proc, 4, minScoreComp);
			SZXCArimAPI.StoreI(proc, 5, numLevelsComp);
			SZXCArimAPI.StoreD(proc, 6, angleStepComp);
			SZXCArimAPI.StoreS(proc, 7, optimizationComp);
			SZXCArimAPI.StoreS(proc, 8, metricComp);
			SZXCArimAPI.StoreS(proc, 9, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			num = SZXCArimAPI.LoadI(proc, 1, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(componentTrainingID);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeComponentModel();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentModel(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeComponentModel(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeComponentModel();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HComponentModel Deserialize(Stream stream)
		{
			HComponentModel arg_0C_0 = new HComponentModel();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeComponentModel(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HComponentModel Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeComponentModel();
			HComponentModel expr_0C = new HComponentModel();
			expr_0C.DeserializeComponentModel(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HRegion GetFoundComponentModel(HTuple modelStart, HTuple modelEnd, HTuple rowComp, HTuple columnComp, HTuple angleComp, HTuple scoreComp, HTuple modelComp, int modelMatch, string markOrientation, out HTuple rowCompInst, out HTuple columnCompInst, out HTuple angleCompInst, out HTuple scoreCompInst)
		{
			IntPtr proc = SZXCArimAPI.PreCall(994);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, modelStart);
			SZXCArimAPI.Store(proc, 2, modelEnd);
			SZXCArimAPI.Store(proc, 3, rowComp);
			SZXCArimAPI.Store(proc, 4, columnComp);
			SZXCArimAPI.Store(proc, 5, angleComp);
			SZXCArimAPI.Store(proc, 6, scoreComp);
			SZXCArimAPI.Store(proc, 7, modelComp);
			SZXCArimAPI.StoreI(proc, 8, modelMatch);
			SZXCArimAPI.StoreS(proc, 9, markOrientation);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(modelStart);
			SZXCArimAPI.UnpinTuple(modelEnd);
			SZXCArimAPI.UnpinTuple(rowComp);
			SZXCArimAPI.UnpinTuple(columnComp);
			SZXCArimAPI.UnpinTuple(angleComp);
			SZXCArimAPI.UnpinTuple(scoreComp);
			SZXCArimAPI.UnpinTuple(modelComp);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowCompInst);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnCompInst);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angleCompInst);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scoreCompInst);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetFoundComponentModel(int modelStart, int modelEnd, double rowComp, double columnComp, double angleComp, double scoreComp, int modelComp, int modelMatch, string markOrientation, out double rowCompInst, out double columnCompInst, out double angleCompInst, out double scoreCompInst)
		{
			IntPtr proc = SZXCArimAPI.PreCall(994);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, modelStart);
			SZXCArimAPI.StoreI(proc, 2, modelEnd);
			SZXCArimAPI.StoreD(proc, 3, rowComp);
			SZXCArimAPI.StoreD(proc, 4, columnComp);
			SZXCArimAPI.StoreD(proc, 5, angleComp);
			SZXCArimAPI.StoreD(proc, 6, scoreComp);
			SZXCArimAPI.StoreI(proc, 7, modelComp);
			SZXCArimAPI.StoreI(proc, 8, modelMatch);
			SZXCArimAPI.StoreS(proc, 9, markOrientation);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 0, num, out rowCompInst);
			num = SZXCArimAPI.LoadD(proc, 1, num, out columnCompInst);
			num = SZXCArimAPI.LoadD(proc, 2, num, out angleCompInst);
			num = SZXCArimAPI.LoadD(proc, 3, num, out scoreCompInst);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple FindComponentModel(HImage image, HTuple rootComponent, HTuple angleStartRoot, HTuple angleExtentRoot, double minScore, int numMatches, double maxOverlap, string ifRootNotFound, string ifComponentNotFound, string posePrediction, HTuple minScoreComp, HTuple subPixelComp, HTuple numLevelsComp, HTuple greedinessComp, out HTuple modelEnd, out HTuple score, out HTuple rowComp, out HTuple columnComp, out HTuple angleComp, out HTuple scoreComp, out HTuple modelComp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(995);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, rootComponent);
			SZXCArimAPI.Store(proc, 2, angleStartRoot);
			SZXCArimAPI.Store(proc, 3, angleExtentRoot);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreI(proc, 5, numMatches);
			SZXCArimAPI.StoreD(proc, 6, maxOverlap);
			SZXCArimAPI.StoreS(proc, 7, ifRootNotFound);
			SZXCArimAPI.StoreS(proc, 8, ifComponentNotFound);
			SZXCArimAPI.StoreS(proc, 9, posePrediction);
			SZXCArimAPI.Store(proc, 10, minScoreComp);
			SZXCArimAPI.Store(proc, 11, subPixelComp);
			SZXCArimAPI.Store(proc, 12, numLevelsComp);
			SZXCArimAPI.Store(proc, 13, greedinessComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rootComponent);
			SZXCArimAPI.UnpinTuple(angleStartRoot);
			SZXCArimAPI.UnpinTuple(angleExtentRoot);
			SZXCArimAPI.UnpinTuple(minScoreComp);
			SZXCArimAPI.UnpinTuple(subPixelComp);
			SZXCArimAPI.UnpinTuple(numLevelsComp);
			SZXCArimAPI.UnpinTuple(greedinessComp);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out modelEnd);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rowComp);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out columnComp);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out angleComp);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out scoreComp);
			num = HTuple.LoadNew(proc, 7, HTupleType.INTEGER, num, out modelComp);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public int FindComponentModel(HImage image, int rootComponent, double angleStartRoot, double angleExtentRoot, double minScore, int numMatches, double maxOverlap, string ifRootNotFound, string ifComponentNotFound, string posePrediction, double minScoreComp, string subPixelComp, int numLevelsComp, double greedinessComp, out int modelEnd, out double score, out double rowComp, out double columnComp, out double angleComp, out double scoreComp, out int modelComp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(995);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreI(proc, 1, rootComponent);
			SZXCArimAPI.StoreD(proc, 2, angleStartRoot);
			SZXCArimAPI.StoreD(proc, 3, angleExtentRoot);
			SZXCArimAPI.StoreD(proc, 4, minScore);
			SZXCArimAPI.StoreI(proc, 5, numMatches);
			SZXCArimAPI.StoreD(proc, 6, maxOverlap);
			SZXCArimAPI.StoreS(proc, 7, ifRootNotFound);
			SZXCArimAPI.StoreS(proc, 8, ifComponentNotFound);
			SZXCArimAPI.StoreS(proc, 9, posePrediction);
			SZXCArimAPI.StoreD(proc, 10, minScoreComp);
			SZXCArimAPI.StoreS(proc, 11, subPixelComp);
			SZXCArimAPI.StoreI(proc, 12, numLevelsComp);
			SZXCArimAPI.StoreD(proc, 13, greedinessComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out modelEnd);
			num = SZXCArimAPI.LoadD(proc, 2, num, out score);
			num = SZXCArimAPI.LoadD(proc, 3, num, out rowComp);
			num = SZXCArimAPI.LoadD(proc, 4, num, out columnComp);
			num = SZXCArimAPI.LoadD(proc, 5, num, out angleComp);
			num = SZXCArimAPI.LoadD(proc, 6, num, out scoreComp);
			num = SZXCArimAPI.LoadI(proc, 7, num, out modelComp);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void ClearComponentModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(997);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HRegion GetComponentModelTree(out HRegion relations, HTuple rootComponent, HTuple image, out HTuple startNode, out HTuple endNode, out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2, out HTuple angleStart, out HTuple angleExtent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(998);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, rootComponent);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
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
			SZXCArimAPI.UnpinTuple(rootComponent);
			SZXCArimAPI.UnpinTuple(image);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out relations);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out startNode);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out endNode);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out phi);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out length1);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out length2);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out angleStart);
			num = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, num, out angleExtent);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetComponentModelTree(out HRegion relations, int rootComponent, string image, out int startNode, out int endNode, out double row, out double column, out double phi, out double length1, out double length2, out double angleStart, out double angleExtent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(998);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, rootComponent);
			SZXCArimAPI.StoreS(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
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
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out relations);
			num = SZXCArimAPI.LoadI(proc, 0, num, out startNode);
			num = SZXCArimAPI.LoadI(proc, 1, num, out endNode);
			num = SZXCArimAPI.LoadD(proc, 2, num, out row);
			num = SZXCArimAPI.LoadD(proc, 3, num, out column);
			num = SZXCArimAPI.LoadD(proc, 4, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 5, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 6, num, out length2);
			num = SZXCArimAPI.LoadD(proc, 7, num, out angleStart);
			num = SZXCArimAPI.LoadD(proc, 8, num, out angleExtent);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetComponentModelParams(out HTuple rootRanking, out HShapeModel[] shapeModelIDs)
		{
			IntPtr proc = SZXCArimAPI.PreCall(999);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out rootRanking);
			num = HShapeModel.LoadNew(proc, 2, num, out shapeModelIDs);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetComponentModelParams(out int rootRanking, out HShapeModel shapeModelIDs)
		{
			IntPtr proc = SZXCArimAPI.PreCall(999);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out rootRanking);
			num = HShapeModel.LoadNew(proc, 2, num, out shapeModelIDs);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeComponentModel(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1000);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeComponentModel()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1001);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadComponentModel(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1002);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteComponentModel(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1003);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple CreateComponentModel(HImage modelImage, HRegion componentRegions, HTuple variationRow, HTuple variationColumn, HTuple variationAngle, double angleStart, double angleExtent, HTuple contrastLowComp, HTuple contrastHighComp, HTuple minSizeComp, HTuple minContrastComp, HTuple minScoreComp, HTuple numLevelsComp, HTuple angleStepComp, string optimizationComp, HTuple metricComp, HTuple pregenerationComp)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1004);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, componentRegions);
			SZXCArimAPI.Store(proc, 0, variationRow);
			SZXCArimAPI.Store(proc, 1, variationColumn);
			SZXCArimAPI.Store(proc, 2, variationAngle);
			SZXCArimAPI.StoreD(proc, 3, angleStart);
			SZXCArimAPI.StoreD(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, contrastLowComp);
			SZXCArimAPI.Store(proc, 6, contrastHighComp);
			SZXCArimAPI.Store(proc, 7, minSizeComp);
			SZXCArimAPI.Store(proc, 8, minContrastComp);
			SZXCArimAPI.Store(proc, 9, minScoreComp);
			SZXCArimAPI.Store(proc, 10, numLevelsComp);
			SZXCArimAPI.Store(proc, 11, angleStepComp);
			SZXCArimAPI.StoreS(proc, 12, optimizationComp);
			SZXCArimAPI.Store(proc, 13, metricComp);
			SZXCArimAPI.Store(proc, 14, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(variationRow);
			SZXCArimAPI.UnpinTuple(variationColumn);
			SZXCArimAPI.UnpinTuple(variationAngle);
			SZXCArimAPI.UnpinTuple(contrastLowComp);
			SZXCArimAPI.UnpinTuple(contrastHighComp);
			SZXCArimAPI.UnpinTuple(minSizeComp);
			SZXCArimAPI.UnpinTuple(minContrastComp);
			SZXCArimAPI.UnpinTuple(minScoreComp);
			SZXCArimAPI.UnpinTuple(numLevelsComp);
			SZXCArimAPI.UnpinTuple(angleStepComp);
			SZXCArimAPI.UnpinTuple(metricComp);
			SZXCArimAPI.UnpinTuple(pregenerationComp);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(componentRegions);
			return result;
		}

		public int CreateComponentModel(HImage modelImage, HRegion componentRegions, int variationRow, int variationColumn, double variationAngle, double angleStart, double angleExtent, int contrastLowComp, int contrastHighComp, int minSizeComp, int minContrastComp, double minScoreComp, int numLevelsComp, double angleStepComp, string optimizationComp, string metricComp, string pregenerationComp)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1004);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, componentRegions);
			SZXCArimAPI.StoreI(proc, 0, variationRow);
			SZXCArimAPI.StoreI(proc, 1, variationColumn);
			SZXCArimAPI.StoreD(proc, 2, variationAngle);
			SZXCArimAPI.StoreD(proc, 3, angleStart);
			SZXCArimAPI.StoreD(proc, 4, angleExtent);
			SZXCArimAPI.StoreI(proc, 5, contrastLowComp);
			SZXCArimAPI.StoreI(proc, 6, contrastHighComp);
			SZXCArimAPI.StoreI(proc, 7, minSizeComp);
			SZXCArimAPI.StoreI(proc, 8, minContrastComp);
			SZXCArimAPI.StoreD(proc, 9, minScoreComp);
			SZXCArimAPI.StoreI(proc, 10, numLevelsComp);
			SZXCArimAPI.StoreD(proc, 11, angleStepComp);
			SZXCArimAPI.StoreS(proc, 12, optimizationComp);
			SZXCArimAPI.StoreS(proc, 13, metricComp);
			SZXCArimAPI.StoreS(proc, 14, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			int result;
			num = SZXCArimAPI.LoadI(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(componentRegions);
			return result;
		}

		public HTuple CreateTrainedComponentModel(HComponentTraining componentTrainingID, double angleStart, double angleExtent, HTuple minContrastComp, HTuple minScoreComp, HTuple numLevelsComp, HTuple angleStepComp, string optimizationComp, HTuple metricComp, HTuple pregenerationComp)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1005);
			SZXCArimAPI.Store(proc, 0, componentTrainingID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, minContrastComp);
			SZXCArimAPI.Store(proc, 4, minScoreComp);
			SZXCArimAPI.Store(proc, 5, numLevelsComp);
			SZXCArimAPI.Store(proc, 6, angleStepComp);
			SZXCArimAPI.StoreS(proc, 7, optimizationComp);
			SZXCArimAPI.Store(proc, 8, metricComp);
			SZXCArimAPI.Store(proc, 9, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minContrastComp);
			SZXCArimAPI.UnpinTuple(minScoreComp);
			SZXCArimAPI.UnpinTuple(numLevelsComp);
			SZXCArimAPI.UnpinTuple(angleStepComp);
			SZXCArimAPI.UnpinTuple(metricComp);
			SZXCArimAPI.UnpinTuple(pregenerationComp);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(componentTrainingID);
			return result;
		}

		public int CreateTrainedComponentModel(HComponentTraining componentTrainingID, double angleStart, double angleExtent, int minContrastComp, double minScoreComp, int numLevelsComp, double angleStepComp, string optimizationComp, string metricComp, string pregenerationComp)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1005);
			SZXCArimAPI.Store(proc, 0, componentTrainingID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreI(proc, 3, minContrastComp);
			SZXCArimAPI.StoreD(proc, 4, minScoreComp);
			SZXCArimAPI.StoreI(proc, 5, numLevelsComp);
			SZXCArimAPI.StoreD(proc, 6, angleStepComp);
			SZXCArimAPI.StoreS(proc, 7, optimizationComp);
			SZXCArimAPI.StoreS(proc, 8, metricComp);
			SZXCArimAPI.StoreS(proc, 9, pregenerationComp);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			int result;
			num = SZXCArimAPI.LoadI(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(componentTrainingID);
			return result;
		}
	}
}
