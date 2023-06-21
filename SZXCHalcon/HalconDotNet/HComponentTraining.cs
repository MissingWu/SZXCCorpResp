using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HComponentTraining : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentTraining() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentTraining(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentTraining(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("component_training");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentTraining obj)
		{
			obj = new HComponentTraining(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentTraining[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HComponentTraining[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HComponentTraining(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HComponentTraining(HImage modelImage, HRegion initialComponents, HImage trainingImages, out HRegion modelComponents, HTuple contrastLow, HTuple contrastHigh, HTuple minSize, HTuple minScore, HTuple searchRowTol, HTuple searchColumnTol, HTuple searchAngleTol, string trainingEmphasis, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1017);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, initialComponents);
			SZXCArimAPI.Store(proc, 3, trainingImages);
			SZXCArimAPI.Store(proc, 0, contrastLow);
			SZXCArimAPI.Store(proc, 1, contrastHigh);
			SZXCArimAPI.Store(proc, 2, minSize);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.Store(proc, 4, searchRowTol);
			SZXCArimAPI.Store(proc, 5, searchColumnTol);
			SZXCArimAPI.Store(proc, 6, searchAngleTol);
			SZXCArimAPI.StoreS(proc, 7, trainingEmphasis);
			SZXCArimAPI.StoreS(proc, 8, ambiguityCriterion);
			SZXCArimAPI.StoreD(proc, 9, maxContourOverlap);
			SZXCArimAPI.StoreD(proc, 10, clusterThreshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(contrastLow);
			SZXCArimAPI.UnpinTuple(contrastHigh);
			SZXCArimAPI.UnpinTuple(minSize);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(searchRowTol);
			SZXCArimAPI.UnpinTuple(searchColumnTol);
			SZXCArimAPI.UnpinTuple(searchAngleTol);
			num = base.Load(proc, 0, num);
			num = HRegion.LoadNew(proc, 1, num, out modelComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(initialComponents);
			GC.KeepAlive(trainingImages);
		}

		public HComponentTraining(HImage modelImage, HRegion initialComponents, HImage trainingImages, out HRegion modelComponents, int contrastLow, int contrastHigh, int minSize, double minScore, int searchRowTol, int searchColumnTol, double searchAngleTol, string trainingEmphasis, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1017);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, initialComponents);
			SZXCArimAPI.Store(proc, 3, trainingImages);
			SZXCArimAPI.StoreI(proc, 0, contrastLow);
			SZXCArimAPI.StoreI(proc, 1, contrastHigh);
			SZXCArimAPI.StoreI(proc, 2, minSize);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, searchRowTol);
			SZXCArimAPI.StoreI(proc, 5, searchColumnTol);
			SZXCArimAPI.StoreD(proc, 6, searchAngleTol);
			SZXCArimAPI.StoreS(proc, 7, trainingEmphasis);
			SZXCArimAPI.StoreS(proc, 8, ambiguityCriterion);
			SZXCArimAPI.StoreD(proc, 9, maxContourOverlap);
			SZXCArimAPI.StoreD(proc, 10, clusterThreshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			num = HRegion.LoadNew(proc, 1, num, out modelComponents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(initialComponents);
			GC.KeepAlive(trainingImages);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeTrainingComponents();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HComponentTraining(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeTrainingComponents(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeTrainingComponents();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HComponentTraining Deserialize(Stream stream)
		{
			HComponentTraining arg_0C_0 = new HComponentTraining();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeTrainingComponents(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HComponentTraining Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeTrainingComponents();
			HComponentTraining expr_0C = new HComponentTraining();
			expr_0C.DeserializeTrainingComponents(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HComponentModel CreateTrainedComponentModel(double angleStart, double angleExtent, HTuple minContrastComp, HTuple minScoreComp, HTuple numLevelsComp, HTuple angleStepComp, string optimizationComp, HTuple metricComp, HTuple pregenerationComp, out HTuple rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1005);
			base.Store(proc, 0);
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
			HComponentModel result;
			num = HComponentModel.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HComponentModel CreateTrainedComponentModel(double angleStart, double angleExtent, int minContrastComp, double minScoreComp, int numLevelsComp, double angleStepComp, string optimizationComp, string metricComp, string pregenerationComp, out int rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1005);
			base.Store(proc, 0);
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
			HComponentModel result;
			num = HComponentModel.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ClearTrainingComponents()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1007);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HRegion GetComponentRelations(int referenceComponent, HTuple image, out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2, out HTuple angleStart, out HTuple angleExtent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1008);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, referenceComponent);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(image);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out length1);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out length2);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out angleStart);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out angleExtent);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetComponentRelations(int referenceComponent, string image, out double row, out double column, out double phi, out double length1, out double length2, out double angleStart, out double angleExtent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1008);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, referenceComponent);
			SZXCArimAPI.StoreS(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out length2);
			num = SZXCArimAPI.LoadD(proc, 5, num, out angleStart);
			num = SZXCArimAPI.LoadD(proc, 6, num, out angleExtent);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetTrainingComponents(HTuple components, HTuple image, string markOrientation, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1009);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, components);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 3, markOrientation);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(components);
			SZXCArimAPI.UnpinTuple(image);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetTrainingComponents(string components, string image, string markOrientation, out double row, out double column, out double angle, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1009);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, components);
			SZXCArimAPI.StoreS(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 3, markOrientation);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out angle);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ModifyComponentRelations(HTuple referenceComponent, HTuple toleranceComponent, HTuple positionTolerance, HTuple angleTolerance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1010);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, referenceComponent);
			SZXCArimAPI.Store(proc, 2, toleranceComponent);
			SZXCArimAPI.Store(proc, 3, positionTolerance);
			SZXCArimAPI.Store(proc, 4, angleTolerance);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(referenceComponent);
			SZXCArimAPI.UnpinTuple(toleranceComponent);
			SZXCArimAPI.UnpinTuple(positionTolerance);
			SZXCArimAPI.UnpinTuple(angleTolerance);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ModifyComponentRelations(string referenceComponent, string toleranceComponent, double positionTolerance, double angleTolerance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1010);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, referenceComponent);
			SZXCArimAPI.StoreS(proc, 2, toleranceComponent);
			SZXCArimAPI.StoreD(proc, 3, positionTolerance);
			SZXCArimAPI.StoreD(proc, 4, angleTolerance);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void DeserializeTrainingComponents(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1011);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeTrainingComponents()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1012);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadTrainingComponents(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1013);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteTrainingComponents(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1014);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HRegion ClusterModelComponents(HImage trainingImages, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1015);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, trainingImages);
			SZXCArimAPI.StoreS(proc, 1, ambiguityCriterion);
			SZXCArimAPI.StoreD(proc, 2, maxContourOverlap);
			SZXCArimAPI.StoreD(proc, 3, clusterThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(trainingImages);
			return result;
		}

		public HRegion InspectClusteredComponents(string ambiguityCriterion, double maxContourOverlap, double clusterThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1016);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, ambiguityCriterion);
			SZXCArimAPI.StoreD(proc, 2, maxContourOverlap);
			SZXCArimAPI.StoreD(proc, 3, clusterThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion TrainModelComponents(HImage modelImage, HRegion initialComponents, HImage trainingImages, HTuple contrastLow, HTuple contrastHigh, HTuple minSize, HTuple minScore, HTuple searchRowTol, HTuple searchColumnTol, HTuple searchAngleTol, string trainingEmphasis, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1017);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, initialComponents);
			SZXCArimAPI.Store(proc, 3, trainingImages);
			SZXCArimAPI.Store(proc, 0, contrastLow);
			SZXCArimAPI.Store(proc, 1, contrastHigh);
			SZXCArimAPI.Store(proc, 2, minSize);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.Store(proc, 4, searchRowTol);
			SZXCArimAPI.Store(proc, 5, searchColumnTol);
			SZXCArimAPI.Store(proc, 6, searchAngleTol);
			SZXCArimAPI.StoreS(proc, 7, trainingEmphasis);
			SZXCArimAPI.StoreS(proc, 8, ambiguityCriterion);
			SZXCArimAPI.StoreD(proc, 9, maxContourOverlap);
			SZXCArimAPI.StoreD(proc, 10, clusterThreshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(contrastLow);
			SZXCArimAPI.UnpinTuple(contrastHigh);
			SZXCArimAPI.UnpinTuple(minSize);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(searchRowTol);
			SZXCArimAPI.UnpinTuple(searchColumnTol);
			SZXCArimAPI.UnpinTuple(searchAngleTol);
			num = base.Load(proc, 0, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(initialComponents);
			GC.KeepAlive(trainingImages);
			return result;
		}

		public HRegion TrainModelComponents(HImage modelImage, HRegion initialComponents, HImage trainingImages, int contrastLow, int contrastHigh, int minSize, double minScore, int searchRowTol, int searchColumnTol, double searchAngleTol, string trainingEmphasis, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1017);
			SZXCArimAPI.Store(proc, 1, modelImage);
			SZXCArimAPI.Store(proc, 2, initialComponents);
			SZXCArimAPI.Store(proc, 3, trainingImages);
			SZXCArimAPI.StoreI(proc, 0, contrastLow);
			SZXCArimAPI.StoreI(proc, 1, contrastHigh);
			SZXCArimAPI.StoreI(proc, 2, minSize);
			SZXCArimAPI.StoreD(proc, 3, minScore);
			SZXCArimAPI.StoreI(proc, 4, searchRowTol);
			SZXCArimAPI.StoreI(proc, 5, searchColumnTol);
			SZXCArimAPI.StoreD(proc, 6, searchAngleTol);
			SZXCArimAPI.StoreS(proc, 7, trainingEmphasis);
			SZXCArimAPI.StoreS(proc, 8, ambiguityCriterion);
			SZXCArimAPI.StoreD(proc, 9, maxContourOverlap);
			SZXCArimAPI.StoreD(proc, 10, clusterThreshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelImage);
			GC.KeepAlive(initialComponents);
			GC.KeepAlive(trainingImages);
			return result;
		}
	}
}
