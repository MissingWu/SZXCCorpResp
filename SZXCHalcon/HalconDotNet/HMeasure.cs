using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HMeasure : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMeasure() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMeasure(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMeasure(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("measure");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMeasure obj)
		{
			obj = new HMeasure(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMeasure[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HMeasure[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HMeasure(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HMeasure(HTuple centerRow, HTuple centerCol, HTuple radius, HTuple angleStart, HTuple angleExtent, HTuple annulusRadius, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(838);
			SZXCArimAPI.Store(proc, 0, centerRow);
			SZXCArimAPI.Store(proc, 1, centerCol);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, annulusRadius);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(centerRow);
			SZXCArimAPI.UnpinTuple(centerCol);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(annulusRadius);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMeasure(double centerRow, double centerCol, double radius, double angleStart, double angleExtent, double annulusRadius, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(838);
			SZXCArimAPI.StoreD(proc, 0, centerRow);
			SZXCArimAPI.StoreD(proc, 1, centerCol);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, angleStart);
			SZXCArimAPI.StoreD(proc, 4, angleExtent);
			SZXCArimAPI.StoreD(proc, 5, annulusRadius);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMeasure(HTuple row, HTuple column, HTuple phi, HTuple length1, HTuple length2, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(839);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, phi);
			SZXCArimAPI.Store(proc, 3, length1);
			SZXCArimAPI.Store(proc, 4, length2);
			SZXCArimAPI.StoreI(proc, 5, width);
			SZXCArimAPI.StoreI(proc, 6, height);
			SZXCArimAPI.StoreS(proc, 7, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(length1);
			SZXCArimAPI.UnpinTuple(length2);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HMeasure(double row, double column, double phi, double length1, double length2, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(839);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, length1);
			SZXCArimAPI.StoreD(proc, 4, length2);
			SZXCArimAPI.StoreI(proc, 5, width);
			SZXCArimAPI.StoreI(proc, 6, height);
			SZXCArimAPI.StoreS(proc, 7, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeMeasure();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HMeasure(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeMeasure(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeMeasure();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HMeasure Deserialize(Stream stream)
		{
			HMeasure arg_0C_0 = new HMeasure();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeMeasure(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HMeasure Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeMeasure();
			HMeasure expr_0C = new HMeasure();
			expr_0C.DeserializeMeasure(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HSerializedItem SerializeMeasure()
		{
			IntPtr proc = SZXCArimAPI.PreCall(821);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeMeasure(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(822);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public void WriteMeasure(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(823);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadMeasure(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(824);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void MeasureThresh(HImage image, double sigma, double threshold, string select, out HTuple rowThresh, out HTuple columnThresh, out HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(825);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.StoreS(proc, 3, select);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowThresh);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnThresh);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out distance);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void CloseMeasure()
		{
			IntPtr proc = SZXCArimAPI.PreCall(827);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple MeasureProjection(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(828);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void ResetFuzzyMeasure(string setType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(829);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, setType);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetFuzzyMeasureNormPair(HTuple pairSize, string setType, HFunction1D function)
		{
			IntPtr proc = SZXCArimAPI.PreCall(830);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pairSize);
			SZXCArimAPI.StoreS(proc, 2, setType);
			SZXCArimAPI.Store(proc, 3, function);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pairSize);
			SZXCArimAPI.UnpinTuple(function);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetFuzzyMeasureNormPair(double pairSize, string setType, HFunction1D function)
		{
			IntPtr proc = SZXCArimAPI.PreCall(830);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, pairSize);
			SZXCArimAPI.StoreS(proc, 2, setType);
			SZXCArimAPI.Store(proc, 3, function);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(function);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetFuzzyMeasure(string setType, HFunction1D function)
		{
			IntPtr proc = SZXCArimAPI.PreCall(831);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, setType);
			SZXCArimAPI.Store(proc, 2, function);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(function);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void FuzzyMeasurePairing(HImage image, double sigma, double ampThresh, double fuzzyThresh, string transition, string pairing, int numPairs, out HTuple rowEdgeFirst, out HTuple columnEdgeFirst, out HTuple amplitudeFirst, out HTuple rowEdgeSecond, out HTuple columnEdgeSecond, out HTuple amplitudeSecond, out HTuple rowPairCenter, out HTuple columnPairCenter, out HTuple fuzzyScore, out HTuple intraDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(832);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, ampThresh);
			SZXCArimAPI.StoreD(proc, 3, fuzzyThresh);
			SZXCArimAPI.StoreS(proc, 4, transition);
			SZXCArimAPI.StoreS(proc, 5, pairing);
			SZXCArimAPI.StoreI(proc, 6, numPairs);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			SZXCArimAPI.InitOCT(proc, 8);
			SZXCArimAPI.InitOCT(proc, 9);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowEdgeFirst);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnEdgeFirst);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out amplitudeFirst);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rowEdgeSecond);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out columnEdgeSecond);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out amplitudeSecond);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out rowPairCenter);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out columnPairCenter);
			num = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, num, out fuzzyScore);
			num = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, num, out intraDistance);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FuzzyMeasurePairs(HImage image, double sigma, double ampThresh, double fuzzyThresh, string transition, out HTuple rowEdgeFirst, out HTuple columnEdgeFirst, out HTuple amplitudeFirst, out HTuple rowEdgeSecond, out HTuple columnEdgeSecond, out HTuple amplitudeSecond, out HTuple rowEdgeCenter, out HTuple columnEdgeCenter, out HTuple fuzzyScore, out HTuple intraDistance, out HTuple interDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(833);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, ampThresh);
			SZXCArimAPI.StoreD(proc, 3, fuzzyThresh);
			SZXCArimAPI.StoreS(proc, 4, transition);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			SZXCArimAPI.InitOCT(proc, 8);
			SZXCArimAPI.InitOCT(proc, 9);
			SZXCArimAPI.InitOCT(proc, 10);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowEdgeFirst);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnEdgeFirst);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out amplitudeFirst);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rowEdgeSecond);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out columnEdgeSecond);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out amplitudeSecond);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out rowEdgeCenter);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out columnEdgeCenter);
			num = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, num, out fuzzyScore);
			num = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, num, out intraDistance);
			num = HTuple.LoadNew(proc, 10, HTupleType.DOUBLE, num, out interDistance);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void FuzzyMeasurePos(HImage image, double sigma, double ampThresh, double fuzzyThresh, string transition, out HTuple rowEdge, out HTuple columnEdge, out HTuple amplitude, out HTuple fuzzyScore, out HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(834);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, ampThresh);
			SZXCArimAPI.StoreD(proc, 3, fuzzyThresh);
			SZXCArimAPI.StoreS(proc, 4, transition);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowEdge);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnEdge);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out amplitude);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out fuzzyScore);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out distance);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void MeasurePairs(HImage image, double sigma, double threshold, string transition, string select, out HTuple rowEdgeFirst, out HTuple columnEdgeFirst, out HTuple amplitudeFirst, out HTuple rowEdgeSecond, out HTuple columnEdgeSecond, out HTuple amplitudeSecond, out HTuple intraDistance, out HTuple interDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(835);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.StoreS(proc, 3, transition);
			SZXCArimAPI.StoreS(proc, 4, select);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowEdgeFirst);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnEdgeFirst);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out amplitudeFirst);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rowEdgeSecond);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out columnEdgeSecond);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out amplitudeSecond);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out intraDistance);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out interDistance);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void MeasurePos(HImage image, double sigma, double threshold, string transition, string select, out HTuple rowEdge, out HTuple columnEdge, out HTuple amplitude, out HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(836);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.StoreS(proc, 3, transition);
			SZXCArimAPI.StoreS(proc, 4, select);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowEdge);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnEdge);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out amplitude);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out distance);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void TranslateMeasure(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(837);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void TranslateMeasure(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(837);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void GenMeasureArc(HTuple centerRow, HTuple centerCol, HTuple radius, HTuple angleStart, HTuple angleExtent, HTuple annulusRadius, int width, int height, string interpolation)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(838);
			SZXCArimAPI.Store(proc, 0, centerRow);
			SZXCArimAPI.Store(proc, 1, centerCol);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.Store(proc, 3, angleStart);
			SZXCArimAPI.Store(proc, 4, angleExtent);
			SZXCArimAPI.Store(proc, 5, annulusRadius);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(centerRow);
			SZXCArimAPI.UnpinTuple(centerCol);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(annulusRadius);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenMeasureArc(double centerRow, double centerCol, double radius, double angleStart, double angleExtent, double annulusRadius, int width, int height, string interpolation)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(838);
			SZXCArimAPI.StoreD(proc, 0, centerRow);
			SZXCArimAPI.StoreD(proc, 1, centerCol);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, angleStart);
			SZXCArimAPI.StoreD(proc, 4, angleExtent);
			SZXCArimAPI.StoreD(proc, 5, annulusRadius);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenMeasureRectangle2(HTuple row, HTuple column, HTuple phi, HTuple length1, HTuple length2, int width, int height, string interpolation)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(839);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, phi);
			SZXCArimAPI.Store(proc, 3, length1);
			SZXCArimAPI.Store(proc, 4, length2);
			SZXCArimAPI.StoreI(proc, 5, width);
			SZXCArimAPI.StoreI(proc, 6, height);
			SZXCArimAPI.StoreS(proc, 7, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(length1);
			SZXCArimAPI.UnpinTuple(length2);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenMeasureRectangle2(double row, double column, double phi, double length1, double length2, int width, int height, string interpolation)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(839);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, length1);
			SZXCArimAPI.StoreD(proc, 4, length2);
			SZXCArimAPI.StoreI(proc, 5, width);
			SZXCArimAPI.StoreI(proc, 6, height);
			SZXCArimAPI.StoreS(proc, 7, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
