using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HHomMat2D : HData, ISerializable, ICloneable
	{
		private const int FIXEDSIZE = 9;

		public HHomMat2D(HTuple tuple) : base(tuple)
		{
		}

		internal HHomMat2D(HData data) : base(data)
		{
		}

		internal static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HHomMat2D obj)
		{
			HTuple t;
			err = HTuple.LoadNew(proc, parIndex, err, out t);
			obj = new HHomMat2D(new HData(t));
			return err;
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HHomMat2D obj)
		{
			return HHomMat2D.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
		}

		internal static HHomMat2D[] SplitArray(HTuple data)
		{
			int num = data.Length / 9;
			HHomMat2D[] array = new HHomMat2D[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new HHomMat2D(new HData(data.TupleSelectRange(i * 9, (i + 1) * 9 - 1)));
			}
			return array;
		}

		public HHomMat2D()
		{
			IntPtr proc = SZXCArimAPI.PreCall(288);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeHomMat2d();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HHomMat2D(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeHomMat2d(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeHomMat2d();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HHomMat2D Deserialize(Stream stream)
		{
			HHomMat2D arg_0C_0 = new HHomMat2D();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeHomMat2d(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HHomMat2D Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeHomMat2d();
			HHomMat2D expr_0C = new HHomMat2D();
			expr_0C.DeserializeHomMat2d(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void ReadWorldFile(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(22);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont ProjectiveTransContourXld(HXLDCont contours)
		{
			IntPtr proc = SZXCArimAPI.PreCall(47);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public HXLDPoly AffineTransPolygonXld(HXLDPoly polygons)
		{
			IntPtr proc = SZXCArimAPI.PreCall(48);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, polygons);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(polygons);
			return result;
		}

		public HXLDCont AffineTransContourXld(HXLDCont contours)
		{
			IntPtr proc = SZXCArimAPI.PreCall(49);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public void DeserializeHomMat2d(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(235);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeHomMat2d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(236);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HHomMat2D[] BundleAdjustMosaic(int numImages, int referenceImage, HTuple mappingSource, HTuple mappingDest, HHomMat2D[] homMatrices2D, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple numCorrespondences, string transformation, out HTuple rows, out HTuple cols, out HTuple error)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr expr_14 = SZXCArimAPI.PreCall(255);
			SZXCArimAPI.StoreI(expr_14, 0, numImages);
			SZXCArimAPI.StoreI(expr_14, 1, referenceImage);
			SZXCArimAPI.Store(expr_14, 2, mappingSource);
			SZXCArimAPI.Store(expr_14, 3, mappingDest);
			SZXCArimAPI.Store(expr_14, 4, hTuple);
			SZXCArimAPI.Store(expr_14, 5, rows1);
			SZXCArimAPI.Store(expr_14, 6, cols1);
			SZXCArimAPI.Store(expr_14, 7, rows2);
			SZXCArimAPI.Store(expr_14, 8, cols2);
			SZXCArimAPI.Store(expr_14, 9, numCorrespondences);
			SZXCArimAPI.StoreS(expr_14, 10, transformation);
			SZXCArimAPI.InitOCT(expr_14, 0);
			SZXCArimAPI.InitOCT(expr_14, 1);
			SZXCArimAPI.InitOCT(expr_14, 2);
			SZXCArimAPI.InitOCT(expr_14, 3);
			int num = SZXCArimAPI.CallProcedure(expr_14);
			SZXCArimAPI.UnpinTuple(mappingSource);
			SZXCArimAPI.UnpinTuple(mappingDest);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(numCorrespondences);
			HTuple data;
			num = HTuple.LoadNew(expr_14, 0, num, out data);
			num = HTuple.LoadNew(expr_14, 1, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(expr_14, 2, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(expr_14, 3, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(expr_14, num);
			return HHomMat2D.SplitArray(data);
		}

		public static HHomMat2D[] BundleAdjustMosaic(int numImages, int referenceImage, HTuple mappingSource, HTuple mappingDest, HHomMat2D[] homMatrices2D, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple numCorrespondences, string transformation, out HTuple rows, out HTuple cols, out double error)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr expr_14 = SZXCArimAPI.PreCall(255);
			SZXCArimAPI.StoreI(expr_14, 0, numImages);
			SZXCArimAPI.StoreI(expr_14, 1, referenceImage);
			SZXCArimAPI.Store(expr_14, 2, mappingSource);
			SZXCArimAPI.Store(expr_14, 3, mappingDest);
			SZXCArimAPI.Store(expr_14, 4, hTuple);
			SZXCArimAPI.Store(expr_14, 5, rows1);
			SZXCArimAPI.Store(expr_14, 6, cols1);
			SZXCArimAPI.Store(expr_14, 7, rows2);
			SZXCArimAPI.Store(expr_14, 8, cols2);
			SZXCArimAPI.Store(expr_14, 9, numCorrespondences);
			SZXCArimAPI.StoreS(expr_14, 10, transformation);
			SZXCArimAPI.InitOCT(expr_14, 0);
			SZXCArimAPI.InitOCT(expr_14, 1);
			SZXCArimAPI.InitOCT(expr_14, 2);
			SZXCArimAPI.InitOCT(expr_14, 3);
			int num = SZXCArimAPI.CallProcedure(expr_14);
			SZXCArimAPI.UnpinTuple(mappingSource);
			SZXCArimAPI.UnpinTuple(mappingDest);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(numCorrespondences);
			HTuple data;
			num = HTuple.LoadNew(expr_14, 0, num, out data);
			num = HTuple.LoadNew(expr_14, 1, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(expr_14, 2, HTupleType.DOUBLE, num, out cols);
			num = SZXCArimAPI.LoadD(expr_14, 3, num, out error);
			SZXCArimAPI.PostCall(expr_14, num);
			return HHomMat2D.SplitArray(data);
		}

		public HHomMat2D ProjMatchPointsDistortionRansacGuided(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, double kappaGuide, double distanceTolerance, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(256);
			base.Store(proc, 6);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreD(proc, 7, kappaGuide);
			SZXCArimAPI.StoreD(proc, 8, distanceTolerance);
			SZXCArimAPI.Store(proc, 9, matchThreshold);
			SZXCArimAPI.StoreS(proc, 10, estimationMethod);
			SZXCArimAPI.Store(proc, 11, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 12, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			SZXCArimAPI.UnpinTuple(distanceThreshold);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out kappa);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsDistortionRansacGuided(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, double kappaGuide, double distanceTolerance, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(256);
			base.Store(proc, 6);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreD(proc, 7, kappaGuide);
			SZXCArimAPI.StoreD(proc, 8, distanceTolerance);
			SZXCArimAPI.StoreI(proc, 9, matchThreshold);
			SZXCArimAPI.StoreS(proc, 10, estimationMethod);
			SZXCArimAPI.StoreD(proc, 11, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 12, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out kappa);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public double ProjMatchPointsDistortionRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(257);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.Store(proc, 10, rotation);
			SZXCArimAPI.Store(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.Store(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			SZXCArimAPI.UnpinTuple(distanceThreshold);
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public double ProjMatchPointsDistortionRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(257);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.StoreD(proc, 10, rotation);
			SZXCArimAPI.StoreI(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.StoreD(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsRansacGuided(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, double distanceTolerance, HTuple matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(258);
			base.Store(proc, 6);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreD(proc, 7, distanceTolerance);
			SZXCArimAPI.Store(proc, 8, matchThreshold);
			SZXCArimAPI.StoreS(proc, 9, estimationMethod);
			SZXCArimAPI.StoreD(proc, 10, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 11, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsRansacGuided(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, double distanceTolerance, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(258);
			base.Store(proc, 6);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreD(proc, 7, distanceTolerance);
			SZXCArimAPI.StoreI(proc, 8, matchThreshold);
			SZXCArimAPI.StoreS(proc, 9, estimationMethod);
			SZXCArimAPI.StoreD(proc, 10, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 11, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HTuple ProjMatchPointsRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(259);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.Store(proc, 10, rotation);
			SZXCArimAPI.Store(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.StoreD(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HTuple ProjMatchPointsRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(259);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.StoreD(proc, 10, rotation);
			SZXCArimAPI.StoreI(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.StoreD(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public double VectorToProjHomMat2dDistortion(HTuple points1Row, HTuple points1Col, HTuple points2Row, HTuple points2Col, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, int imageWidth, int imageHeight, string method, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(260);
			SZXCArimAPI.Store(proc, 0, points1Row);
			SZXCArimAPI.Store(proc, 1, points1Col);
			SZXCArimAPI.Store(proc, 2, points2Row);
			SZXCArimAPI.Store(proc, 3, points2Col);
			SZXCArimAPI.Store(proc, 4, covRR1);
			SZXCArimAPI.Store(proc, 5, covRC1);
			SZXCArimAPI.Store(proc, 6, covCC1);
			SZXCArimAPI.Store(proc, 7, covRR2);
			SZXCArimAPI.Store(proc, 8, covRC2);
			SZXCArimAPI.Store(proc, 9, covCC2);
			SZXCArimAPI.StoreI(proc, 10, imageWidth);
			SZXCArimAPI.StoreI(proc, 11, imageHeight);
			SZXCArimAPI.StoreS(proc, 12, method);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(points1Row);
			SZXCArimAPI.UnpinTuple(points1Col);
			SZXCArimAPI.UnpinTuple(points2Row);
			SZXCArimAPI.UnpinTuple(points2Col);
			SZXCArimAPI.UnpinTuple(covRR1);
			SZXCArimAPI.UnpinTuple(covRC1);
			SZXCArimAPI.UnpinTuple(covCC1);
			SZXCArimAPI.UnpinTuple(covRR2);
			SZXCArimAPI.UnpinTuple(covRC2);
			SZXCArimAPI.UnpinTuple(covCC2);
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void HomVectorToProjHomMat2d(HTuple px, HTuple py, HTuple pw, HTuple qx, HTuple qy, HTuple qw, string method)
		{
			IntPtr proc = SZXCArimAPI.PreCall(261);
			SZXCArimAPI.Store(proc, 0, px);
			SZXCArimAPI.Store(proc, 1, py);
			SZXCArimAPI.Store(proc, 2, pw);
			SZXCArimAPI.Store(proc, 3, qx);
			SZXCArimAPI.Store(proc, 4, qy);
			SZXCArimAPI.Store(proc, 5, qw);
			SZXCArimAPI.StoreS(proc, 6, method);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pw);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			SZXCArimAPI.UnpinTuple(qw);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple VectorToProjHomMat2d(HTuple px, HTuple py, HTuple qx, HTuple qy, string method, HTuple covXX1, HTuple covYY1, HTuple covXY1, HTuple covXX2, HTuple covYY2, HTuple covXY2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(262);
			SZXCArimAPI.Store(proc, 0, px);
			SZXCArimAPI.Store(proc, 1, py);
			SZXCArimAPI.Store(proc, 2, qx);
			SZXCArimAPI.Store(proc, 3, qy);
			SZXCArimAPI.StoreS(proc, 4, method);
			SZXCArimAPI.Store(proc, 5, covXX1);
			SZXCArimAPI.Store(proc, 6, covYY1);
			SZXCArimAPI.Store(proc, 7, covXY1);
			SZXCArimAPI.Store(proc, 8, covXX2);
			SZXCArimAPI.Store(proc, 9, covYY2);
			SZXCArimAPI.Store(proc, 10, covXY2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			SZXCArimAPI.UnpinTuple(covXX1);
			SZXCArimAPI.UnpinTuple(covYY1);
			SZXCArimAPI.UnpinTuple(covXY1);
			SZXCArimAPI.UnpinTuple(covXX2);
			SZXCArimAPI.UnpinTuple(covYY2);
			SZXCArimAPI.UnpinTuple(covXY2);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double HomMat2dToAffinePar(out double sy, out double phi, out double theta, out double tx, out double ty)
		{
			IntPtr proc = SZXCArimAPI.PreCall(263);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out sy);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out theta);
			num = SZXCArimAPI.LoadD(proc, 4, num, out tx);
			num = SZXCArimAPI.LoadD(proc, 5, num, out ty);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void VectorAngleToRigid(HTuple row1, HTuple column1, HTuple angle1, HTuple row2, HTuple column2, HTuple angle2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(264);
			SZXCArimAPI.Store(proc, 0, row1);
			SZXCArimAPI.Store(proc, 1, column1);
			SZXCArimAPI.Store(proc, 2, angle1);
			SZXCArimAPI.Store(proc, 3, row2);
			SZXCArimAPI.Store(proc, 4, column2);
			SZXCArimAPI.Store(proc, 5, angle2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(angle1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			SZXCArimAPI.UnpinTuple(angle2);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void VectorAngleToRigid(double row1, double column1, double angle1, double row2, double column2, double angle2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(264);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, angle1);
			SZXCArimAPI.StoreD(proc, 3, row2);
			SZXCArimAPI.StoreD(proc, 4, column2);
			SZXCArimAPI.StoreD(proc, 5, angle2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointLineToHomMat2d(string transformationType, HTuple px, HTuple py, HTuple l1x, HTuple l1y, HTuple l2x, HTuple l2y)
		{
			IntPtr proc = SZXCArimAPI.PreCall(265);
			SZXCArimAPI.StoreS(proc, 0, transformationType);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, l1x);
			SZXCArimAPI.Store(proc, 4, l1y);
			SZXCArimAPI.Store(proc, 5, l2x);
			SZXCArimAPI.Store(proc, 6, l2y);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(l1x);
			SZXCArimAPI.UnpinTuple(l1y);
			SZXCArimAPI.UnpinTuple(l2x);
			SZXCArimAPI.UnpinTuple(l2y);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void VectorToRigid(HTuple px, HTuple py, HTuple qx, HTuple qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(266);
			SZXCArimAPI.Store(proc, 0, px);
			SZXCArimAPI.Store(proc, 1, py);
			SZXCArimAPI.Store(proc, 2, qx);
			SZXCArimAPI.Store(proc, 3, qy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void VectorToSimilarity(HTuple px, HTuple py, HTuple qx, HTuple qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(267);
			SZXCArimAPI.Store(proc, 0, px);
			SZXCArimAPI.Store(proc, 1, py);
			SZXCArimAPI.Store(proc, 2, qx);
			SZXCArimAPI.Store(proc, 3, qy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void VectorToAniso(HTuple px, HTuple py, HTuple qx, HTuple qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(268);
			SZXCArimAPI.Store(proc, 0, px);
			SZXCArimAPI.Store(proc, 1, py);
			SZXCArimAPI.Store(proc, 2, qx);
			SZXCArimAPI.Store(proc, 3, qy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void VectorToHomMat2d(HTuple px, HTuple py, HTuple qx, HTuple qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(269);
			SZXCArimAPI.Store(proc, 0, px);
			SZXCArimAPI.Store(proc, 1, py);
			SZXCArimAPI.Store(proc, 2, qx);
			SZXCArimAPI.Store(proc, 3, qy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ProjectiveTransPixel(HTuple row, HTuple col, out HTuple rowTrans, out HTuple colTrans)
		{
			IntPtr proc = SZXCArimAPI.PreCall(270);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, col);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowTrans);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out colTrans);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ProjectiveTransPixel(double row, double col, out double rowTrans, out double colTrans)
		{
			IntPtr proc = SZXCArimAPI.PreCall(270);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, col);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = SZXCArimAPI.LoadD(proc, 0, num, out rowTrans);
			num = SZXCArimAPI.LoadD(proc, 1, num, out colTrans);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple ProjectiveTransPoint2d(HTuple px, HTuple py, HTuple pw, out HTuple qy, out HTuple qw)
		{
			IntPtr proc = SZXCArimAPI.PreCall(271);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, pw);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(pw);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out qy);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out qw);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double ProjectiveTransPoint2d(double px, double py, double pw, out double qy, out double qw)
		{
			IntPtr proc = SZXCArimAPI.PreCall(271);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.StoreD(proc, 3, pw);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out qy);
			num = SZXCArimAPI.LoadD(proc, 2, num, out qw);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AffineTransPixel(HTuple row, HTuple col, out HTuple rowTrans, out HTuple colTrans)
		{
			IntPtr proc = SZXCArimAPI.PreCall(272);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, col);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowTrans);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out colTrans);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void AffineTransPixel(double row, double col, out double rowTrans, out double colTrans)
		{
			IntPtr proc = SZXCArimAPI.PreCall(272);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, col);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = SZXCArimAPI.LoadD(proc, 0, num, out rowTrans);
			num = SZXCArimAPI.LoadD(proc, 1, num, out colTrans);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple AffineTransPoint2d(HTuple px, HTuple py, out HTuple qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(273);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out qy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double AffineTransPoint2d(double px, double py, out double qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(273);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out qy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double HomMat2dDeterminant()
		{
			IntPtr proc = SZXCArimAPI.PreCall(274);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dTranspose()
		{
			IntPtr proc = SZXCArimAPI.PreCall(275);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dInvert()
		{
			IntPtr proc = SZXCArimAPI.PreCall(276);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dCompose(HHomMat2D homMat2DRight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(277);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, homMat2DRight);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(homMat2DRight);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dReflectLocal(HTuple px, HTuple py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(278);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dReflectLocal(double px, double py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(278);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dReflect(HTuple px, HTuple py, HTuple qx, HTuple qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(279);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, px);
			SZXCArimAPI.Store(proc, 2, py);
			SZXCArimAPI.Store(proc, 3, qx);
			SZXCArimAPI.Store(proc, 4, qy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			SZXCArimAPI.UnpinTuple(qx);
			SZXCArimAPI.UnpinTuple(qy);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dReflect(double px, double py, double qx, double qy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(279);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, px);
			SZXCArimAPI.StoreD(proc, 2, py);
			SZXCArimAPI.StoreD(proc, 3, qx);
			SZXCArimAPI.StoreD(proc, 4, qy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dSlantLocal(HTuple theta, string axis)
		{
			IntPtr proc = SZXCArimAPI.PreCall(280);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, theta);
			SZXCArimAPI.StoreS(proc, 2, axis);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(theta);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dSlantLocal(double theta, string axis)
		{
			IntPtr proc = SZXCArimAPI.PreCall(280);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, theta);
			SZXCArimAPI.StoreS(proc, 2, axis);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dSlant(HTuple theta, string axis, HTuple px, HTuple py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(281);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, theta);
			SZXCArimAPI.StoreS(proc, 2, axis);
			SZXCArimAPI.Store(proc, 3, px);
			SZXCArimAPI.Store(proc, 4, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(theta);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dSlant(double theta, string axis, double px, double py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(281);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, theta);
			SZXCArimAPI.StoreS(proc, 2, axis);
			SZXCArimAPI.StoreD(proc, 3, px);
			SZXCArimAPI.StoreD(proc, 4, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dRotateLocal(HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(282);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, phi);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(phi);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dRotateLocal(double phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(282);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, phi);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dRotate(HTuple phi, HTuple px, HTuple py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(283);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, phi);
			SZXCArimAPI.Store(proc, 2, px);
			SZXCArimAPI.Store(proc, 3, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dRotate(double phi, double px, double py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(283);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, phi);
			SZXCArimAPI.StoreD(proc, 2, px);
			SZXCArimAPI.StoreD(proc, 3, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dScaleLocal(HTuple sx, HTuple sy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(284);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sx);
			SZXCArimAPI.Store(proc, 2, sy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(sx);
			SZXCArimAPI.UnpinTuple(sy);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dScaleLocal(double sx, double sy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(284);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, sx);
			SZXCArimAPI.StoreD(proc, 2, sy);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dScale(HTuple sx, HTuple sy, HTuple px, HTuple py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(285);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, sx);
			SZXCArimAPI.Store(proc, 2, sy);
			SZXCArimAPI.Store(proc, 3, px);
			SZXCArimAPI.Store(proc, 4, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(sx);
			SZXCArimAPI.UnpinTuple(sy);
			SZXCArimAPI.UnpinTuple(px);
			SZXCArimAPI.UnpinTuple(py);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dScale(double sx, double sy, double px, double py)
		{
			IntPtr proc = SZXCArimAPI.PreCall(285);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, sx);
			SZXCArimAPI.StoreD(proc, 2, sy);
			SZXCArimAPI.StoreD(proc, 3, px);
			SZXCArimAPI.StoreD(proc, 4, py);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dTranslateLocal(HTuple tx, HTuple ty)
		{
			IntPtr proc = SZXCArimAPI.PreCall(286);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, tx);
			SZXCArimAPI.Store(proc, 2, ty);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(tx);
			SZXCArimAPI.UnpinTuple(ty);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dTranslateLocal(double tx, double ty)
		{
			IntPtr proc = SZXCArimAPI.PreCall(286);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, tx);
			SZXCArimAPI.StoreD(proc, 2, ty);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dTranslate(HTuple tx, HTuple ty)
		{
			IntPtr proc = SZXCArimAPI.PreCall(287);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, tx);
			SZXCArimAPI.Store(proc, 2, ty);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(tx);
			SZXCArimAPI.UnpinTuple(ty);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D HomMat2dTranslate(double tx, double ty)
		{
			IntPtr proc = SZXCArimAPI.PreCall(287);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, tx);
			SZXCArimAPI.StoreD(proc, 2, ty);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void HomMat2dIdentity()
		{
			IntPtr proc = SZXCArimAPI.PreCall(288);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void Reconst3dFromFundamentalMatrix(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, HTuple covFMat, out HTuple x, out HTuple y, out HTuple z, out HTuple w, out HTuple covXYZW)
		{
			IntPtr proc = SZXCArimAPI.PreCall(350);
			base.Store(proc, 10);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, covRR1);
			SZXCArimAPI.Store(proc, 5, covRC1);
			SZXCArimAPI.Store(proc, 6, covCC1);
			SZXCArimAPI.Store(proc, 7, covRR2);
			SZXCArimAPI.Store(proc, 8, covRC2);
			SZXCArimAPI.Store(proc, 9, covCC2);
			SZXCArimAPI.Store(proc, 11, covFMat);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(covRR1);
			SZXCArimAPI.UnpinTuple(covRC1);
			SZXCArimAPI.UnpinTuple(covCC1);
			SZXCArimAPI.UnpinTuple(covRR2);
			SZXCArimAPI.UnpinTuple(covRC2);
			SZXCArimAPI.UnpinTuple(covCC2);
			SZXCArimAPI.UnpinTuple(covFMat);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out w);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out covXYZW);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void Reconst3dFromFundamentalMatrix(double rows1, double cols1, double rows2, double cols2, double covRR1, double covRC1, double covCC1, double covRR2, double covRC2, double covCC2, HTuple covFMat, out double x, out double y, out double z, out double w, out double covXYZW)
		{
			IntPtr proc = SZXCArimAPI.PreCall(350);
			base.Store(proc, 10);
			SZXCArimAPI.StoreD(proc, 0, rows1);
			SZXCArimAPI.StoreD(proc, 1, cols1);
			SZXCArimAPI.StoreD(proc, 2, rows2);
			SZXCArimAPI.StoreD(proc, 3, cols2);
			SZXCArimAPI.StoreD(proc, 4, covRR1);
			SZXCArimAPI.StoreD(proc, 5, covRC1);
			SZXCArimAPI.StoreD(proc, 6, covCC1);
			SZXCArimAPI.StoreD(proc, 7, covRR2);
			SZXCArimAPI.StoreD(proc, 8, covRC2);
			SZXCArimAPI.StoreD(proc, 9, covCC2);
			SZXCArimAPI.Store(proc, 11, covFMat);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(covFMat);
			num = SZXCArimAPI.LoadD(proc, 0, num, out x);
			num = SZXCArimAPI.LoadD(proc, 1, num, out y);
			num = SZXCArimAPI.LoadD(proc, 2, num, out z);
			num = SZXCArimAPI.LoadD(proc, 3, num, out w);
			num = SZXCArimAPI.LoadD(proc, 4, num, out covXYZW);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage GenBinocularProjRectification(out HImage map2, HTuple covFMat, int width1, int height1, int width2, int height2, HTuple subSampling, string mapping, out HTuple covFMatRect, out HHomMat2D h1, out HHomMat2D h2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(351);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, covFMat);
			SZXCArimAPI.StoreI(proc, 2, width1);
			SZXCArimAPI.StoreI(proc, 3, height1);
			SZXCArimAPI.StoreI(proc, 4, width2);
			SZXCArimAPI.StoreI(proc, 5, height2);
			SZXCArimAPI.Store(proc, 6, subSampling);
			SZXCArimAPI.StoreS(proc, 7, mapping);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(covFMat);
			SZXCArimAPI.UnpinTuple(subSampling);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out map2);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out covFMatRect);
			num = HHomMat2D.LoadNew(proc, 1, num, out h1);
			num = HHomMat2D.LoadNew(proc, 2, num, out h2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenBinocularProjRectification(out HImage map2, HTuple covFMat, int width1, int height1, int width2, int height2, int subSampling, string mapping, out HTuple covFMatRect, out HHomMat2D h1, out HHomMat2D h2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(351);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, covFMat);
			SZXCArimAPI.StoreI(proc, 2, width1);
			SZXCArimAPI.StoreI(proc, 3, height1);
			SZXCArimAPI.StoreI(proc, 4, width2);
			SZXCArimAPI.StoreI(proc, 5, height2);
			SZXCArimAPI.StoreI(proc, 6, subSampling);
			SZXCArimAPI.StoreS(proc, 7, mapping);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(covFMat);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out map2);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out covFMatRect);
			num = HHomMat2D.LoadNew(proc, 1, num, out h1);
			num = HHomMat2D.LoadNew(proc, 2, num, out h2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double VectorToFundamentalMatrixDistortion(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, int imageWidth, int imageHeight, string method, out double error, out HTuple x, out HTuple y, out HTuple z, out HTuple w)
		{
			IntPtr proc = SZXCArimAPI.PreCall(352);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, covRR1);
			SZXCArimAPI.Store(proc, 5, covRC1);
			SZXCArimAPI.Store(proc, 6, covCC1);
			SZXCArimAPI.Store(proc, 7, covRR2);
			SZXCArimAPI.Store(proc, 8, covRC2);
			SZXCArimAPI.Store(proc, 9, covCC2);
			SZXCArimAPI.StoreI(proc, 10, imageWidth);
			SZXCArimAPI.StoreI(proc, 11, imageHeight);
			SZXCArimAPI.StoreS(proc, 12, method);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(covRR1);
			SZXCArimAPI.UnpinTuple(covRC1);
			SZXCArimAPI.UnpinTuple(covCC1);
			SZXCArimAPI.UnpinTuple(covRR2);
			SZXCArimAPI.UnpinTuple(covRC2);
			SZXCArimAPI.UnpinTuple(covCC2);
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out w);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple RelPoseToFundamentalMatrix(HPose relPose, HTuple covRelPose, HCamPar camPar1, HCamPar camPar2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(353);
			SZXCArimAPI.Store(proc, 0, relPose);
			SZXCArimAPI.Store(proc, 1, covRelPose);
			SZXCArimAPI.Store(proc, 2, camPar1);
			SZXCArimAPI.Store(proc, 3, camPar2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(relPose);
			SZXCArimAPI.UnpinTuple(covRelPose);
			SZXCArimAPI.UnpinTuple(camPar1);
			SZXCArimAPI.UnpinTuple(camPar2);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D EssentialToFundamentalMatrix(HTuple covEMat, HHomMat2D camMat1, HHomMat2D camMat2, out HTuple covFMat)
		{
			IntPtr proc = SZXCArimAPI.PreCall(354);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, covEMat);
			SZXCArimAPI.Store(proc, 2, camMat1);
			SZXCArimAPI.Store(proc, 3, camMat2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(covEMat);
			SZXCArimAPI.UnpinTuple(camMat1);
			SZXCArimAPI.UnpinTuple(camMat2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covFMat);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D VectorToEssentialMatrix(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, HHomMat2D camMat2, string method, out HTuple covEMat, out HTuple error, out HTuple x, out HTuple y, out HTuple z, out HTuple covXYZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(356);
			base.Store(proc, 10);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, covRR1);
			SZXCArimAPI.Store(proc, 5, covRC1);
			SZXCArimAPI.Store(proc, 6, covCC1);
			SZXCArimAPI.Store(proc, 7, covRR2);
			SZXCArimAPI.Store(proc, 8, covRC2);
			SZXCArimAPI.Store(proc, 9, covCC2);
			SZXCArimAPI.Store(proc, 11, camMat2);
			SZXCArimAPI.StoreS(proc, 12, method);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(covRR1);
			SZXCArimAPI.UnpinTuple(covRC1);
			SZXCArimAPI.UnpinTuple(covCC1);
			SZXCArimAPI.UnpinTuple(covRR2);
			SZXCArimAPI.UnpinTuple(covRC2);
			SZXCArimAPI.UnpinTuple(covCC2);
			SZXCArimAPI.UnpinTuple(camMat2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covEMat);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out covXYZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D VectorToEssentialMatrix(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, HHomMat2D camMat2, string method, out HTuple covEMat, out double error, out HTuple x, out HTuple y, out HTuple z, out HTuple covXYZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(356);
			base.Store(proc, 10);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, covRR1);
			SZXCArimAPI.Store(proc, 5, covRC1);
			SZXCArimAPI.Store(proc, 6, covCC1);
			SZXCArimAPI.Store(proc, 7, covRR2);
			SZXCArimAPI.Store(proc, 8, covRC2);
			SZXCArimAPI.Store(proc, 9, covCC2);
			SZXCArimAPI.Store(proc, 11, camMat2);
			SZXCArimAPI.StoreS(proc, 12, method);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(covRR1);
			SZXCArimAPI.UnpinTuple(covRC1);
			SZXCArimAPI.UnpinTuple(covCC1);
			SZXCArimAPI.UnpinTuple(covRR2);
			SZXCArimAPI.UnpinTuple(covRC2);
			SZXCArimAPI.UnpinTuple(covCC2);
			SZXCArimAPI.UnpinTuple(camMat2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covEMat);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out covXYZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple VectorToFundamentalMatrix(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, string method, out double error, out HTuple x, out HTuple y, out HTuple z, out HTuple w, out HTuple covXYZW)
		{
			IntPtr proc = SZXCArimAPI.PreCall(357);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, covRR1);
			SZXCArimAPI.Store(proc, 5, covRC1);
			SZXCArimAPI.Store(proc, 6, covCC1);
			SZXCArimAPI.Store(proc, 7, covRR2);
			SZXCArimAPI.Store(proc, 8, covRC2);
			SZXCArimAPI.Store(proc, 9, covCC2);
			SZXCArimAPI.StoreS(proc, 10, method);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(covRR1);
			SZXCArimAPI.UnpinTuple(covRC1);
			SZXCArimAPI.UnpinTuple(covCC1);
			SZXCArimAPI.UnpinTuple(covRR2);
			SZXCArimAPI.UnpinTuple(covRC2);
			SZXCArimAPI.UnpinTuple(covCC2);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out w);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out covXYZW);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MatchFundamentalMatrixDistortionRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(358);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.Store(proc, 10, rotation);
			SZXCArimAPI.Store(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.Store(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			SZXCArimAPI.UnpinTuple(distanceThreshold);
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public double MatchFundamentalMatrixDistortionRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(358);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.StoreD(proc, 10, rotation);
			SZXCArimAPI.StoreI(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.StoreD(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D MatchEssentialMatrixRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HHomMat2D camMat2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out HTuple covEMat, out HTuple error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(360);
			base.Store(proc, 4);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 5, camMat2);
			SZXCArimAPI.StoreS(proc, 6, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 7, maskSize);
			SZXCArimAPI.StoreI(proc, 8, rowMove);
			SZXCArimAPI.StoreI(proc, 9, colMove);
			SZXCArimAPI.StoreI(proc, 10, rowTolerance);
			SZXCArimAPI.StoreI(proc, 11, colTolerance);
			SZXCArimAPI.Store(proc, 12, rotation);
			SZXCArimAPI.Store(proc, 13, matchThreshold);
			SZXCArimAPI.StoreS(proc, 14, estimationMethod);
			SZXCArimAPI.Store(proc, 15, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 16, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(camMat2);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			SZXCArimAPI.UnpinTuple(distanceThreshold);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covEMat);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D MatchEssentialMatrixRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HHomMat2D camMat2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple covEMat, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(360);
			base.Store(proc, 4);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 5, camMat2);
			SZXCArimAPI.StoreS(proc, 6, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 7, maskSize);
			SZXCArimAPI.StoreI(proc, 8, rowMove);
			SZXCArimAPI.StoreI(proc, 9, colMove);
			SZXCArimAPI.StoreI(proc, 10, rowTolerance);
			SZXCArimAPI.StoreI(proc, 11, colTolerance);
			SZXCArimAPI.StoreD(proc, 12, rotation);
			SZXCArimAPI.StoreI(proc, 13, matchThreshold);
			SZXCArimAPI.StoreS(proc, 14, estimationMethod);
			SZXCArimAPI.StoreD(proc, 15, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 16, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(camMat2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covEMat);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HTuple MatchFundamentalMatrixRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(361);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.Store(proc, 10, rotation);
			SZXCArimAPI.Store(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.Store(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			SZXCArimAPI.UnpinTuple(distanceThreshold);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HTuple MatchFundamentalMatrixRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(361);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.StoreI(proc, 6, rowMove);
			SZXCArimAPI.StoreI(proc, 7, colMove);
			SZXCArimAPI.StoreI(proc, 8, rowTolerance);
			SZXCArimAPI.StoreI(proc, 9, colTolerance);
			SZXCArimAPI.StoreD(proc, 10, rotation);
			SZXCArimAPI.StoreI(proc, 11, matchThreshold);
			SZXCArimAPI.StoreS(proc, 12, estimationMethod);
			SZXCArimAPI.StoreD(proc, 13, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 14, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HRegion ProjectiveTransRegion(HRegion regions, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(487);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HRegion AffineTransRegion(HRegion region, string interpolate)
		{
			IntPtr proc = SZXCArimAPI.PreCall(488);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.StoreS(proc, 1, interpolate);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage ProjectiveTransImageSize(HImage image, string interpolation, int width, int height, string transformDomain)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1620);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreS(proc, 4, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage ProjectiveTransImage(HImage image, string interpolation, string adaptImageSize, string transformDomain)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1621);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreS(proc, 2, adaptImageSize);
			SZXCArimAPI.StoreS(proc, 3, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage AffineTransImageSize(HImage image, string interpolation, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1622);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage AffineTransImage(HImage image, string interpolation, string adaptImageSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1623);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreS(proc, 2, adaptImageSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void VectorFieldToHomMat2d(HImage vectorField)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1631);
			SZXCArimAPI.Store(proc, 1, vectorField);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(vectorField);
		}

		public void CamParToCamMat(HCamPar cameraParam, out int imageWidth, out int imageHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1905);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			num = base.Load(proc, 0, num);
			num = SZXCArimAPI.LoadI(proc, 1, num, out imageWidth);
			num = SZXCArimAPI.LoadI(proc, 2, num, out imageHeight);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HCamPar CamMatToCamPar(double kappa, int imageWidth, int imageHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1906);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, kappa);
			SZXCArimAPI.StoreI(proc, 2, imageWidth);
			SZXCArimAPI.StoreI(proc, 3, imageHeight);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HHomMat2D[] StationaryCameraSelfCalibration(int numImages, int imageWidth, int imageHeight, int referenceImage, HTuple mappingSource, HTuple mappingDest, HHomMat2D[] homMatrices2D, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple numCorrespondences, string estimationMethod, HTuple cameraModel, string fixedCameraParams, out HTuple kappa, out HHomMat2D[] rotationMatrices, out HTuple x, out HTuple y, out HTuple z, out HTuple error)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr expr_16 = SZXCArimAPI.PreCall(1907);
			SZXCArimAPI.StoreI(expr_16, 0, numImages);
			SZXCArimAPI.StoreI(expr_16, 1, imageWidth);
			SZXCArimAPI.StoreI(expr_16, 2, imageHeight);
			SZXCArimAPI.StoreI(expr_16, 3, referenceImage);
			SZXCArimAPI.Store(expr_16, 4, mappingSource);
			SZXCArimAPI.Store(expr_16, 5, mappingDest);
			SZXCArimAPI.Store(expr_16, 6, hTuple);
			SZXCArimAPI.Store(expr_16, 7, rows1);
			SZXCArimAPI.Store(expr_16, 8, cols1);
			SZXCArimAPI.Store(expr_16, 9, rows2);
			SZXCArimAPI.Store(expr_16, 10, cols2);
			SZXCArimAPI.Store(expr_16, 11, numCorrespondences);
			SZXCArimAPI.StoreS(expr_16, 12, estimationMethod);
			SZXCArimAPI.Store(expr_16, 13, cameraModel);
			SZXCArimAPI.StoreS(expr_16, 14, fixedCameraParams);
			SZXCArimAPI.InitOCT(expr_16, 0);
			SZXCArimAPI.InitOCT(expr_16, 1);
			SZXCArimAPI.InitOCT(expr_16, 2);
			SZXCArimAPI.InitOCT(expr_16, 3);
			SZXCArimAPI.InitOCT(expr_16, 4);
			SZXCArimAPI.InitOCT(expr_16, 5);
			SZXCArimAPI.InitOCT(expr_16, 6);
			int num = SZXCArimAPI.CallProcedure(expr_16);
			SZXCArimAPI.UnpinTuple(mappingSource);
			SZXCArimAPI.UnpinTuple(mappingDest);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(numCorrespondences);
			SZXCArimAPI.UnpinTuple(cameraModel);
			HTuple data;
			num = HTuple.LoadNew(expr_16, 0, num, out data);
			num = HTuple.LoadNew(expr_16, 1, HTupleType.DOUBLE, num, out kappa);
			HTuple data2;
			num = HTuple.LoadNew(expr_16, 2, num, out data2);
			num = HTuple.LoadNew(expr_16, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(expr_16, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(expr_16, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(expr_16, 6, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(expr_16, num);
			rotationMatrices = HHomMat2D.SplitArray(data2);
			return HHomMat2D.SplitArray(data);
		}

		public static HHomMat2D[] StationaryCameraSelfCalibration(int numImages, int imageWidth, int imageHeight, int referenceImage, HTuple mappingSource, HTuple mappingDest, HHomMat2D[] homMatrices2D, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple numCorrespondences, string estimationMethod, HTuple cameraModel, string fixedCameraParams, out double kappa, out HHomMat2D[] rotationMatrices, out HTuple x, out HTuple y, out HTuple z, out double error)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr expr_16 = SZXCArimAPI.PreCall(1907);
			SZXCArimAPI.StoreI(expr_16, 0, numImages);
			SZXCArimAPI.StoreI(expr_16, 1, imageWidth);
			SZXCArimAPI.StoreI(expr_16, 2, imageHeight);
			SZXCArimAPI.StoreI(expr_16, 3, referenceImage);
			SZXCArimAPI.Store(expr_16, 4, mappingSource);
			SZXCArimAPI.Store(expr_16, 5, mappingDest);
			SZXCArimAPI.Store(expr_16, 6, hTuple);
			SZXCArimAPI.Store(expr_16, 7, rows1);
			SZXCArimAPI.Store(expr_16, 8, cols1);
			SZXCArimAPI.Store(expr_16, 9, rows2);
			SZXCArimAPI.Store(expr_16, 10, cols2);
			SZXCArimAPI.Store(expr_16, 11, numCorrespondences);
			SZXCArimAPI.StoreS(expr_16, 12, estimationMethod);
			SZXCArimAPI.Store(expr_16, 13, cameraModel);
			SZXCArimAPI.StoreS(expr_16, 14, fixedCameraParams);
			SZXCArimAPI.InitOCT(expr_16, 0);
			SZXCArimAPI.InitOCT(expr_16, 1);
			SZXCArimAPI.InitOCT(expr_16, 2);
			SZXCArimAPI.InitOCT(expr_16, 3);
			SZXCArimAPI.InitOCT(expr_16, 4);
			SZXCArimAPI.InitOCT(expr_16, 5);
			SZXCArimAPI.InitOCT(expr_16, 6);
			int num = SZXCArimAPI.CallProcedure(expr_16);
			SZXCArimAPI.UnpinTuple(mappingSource);
			SZXCArimAPI.UnpinTuple(mappingDest);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(numCorrespondences);
			SZXCArimAPI.UnpinTuple(cameraModel);
			HTuple data;
			num = HTuple.LoadNew(expr_16, 0, num, out data);
			num = SZXCArimAPI.LoadD(expr_16, 1, num, out kappa);
			HTuple data2;
			num = HTuple.LoadNew(expr_16, 2, num, out data2);
			num = HTuple.LoadNew(expr_16, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(expr_16, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(expr_16, 5, HTupleType.DOUBLE, num, out z);
			num = SZXCArimAPI.LoadD(expr_16, 6, num, out error);
			SZXCArimAPI.PostCall(expr_16, num);
			rotationMatrices = HHomMat2D.SplitArray(data2);
			return HHomMat2D.SplitArray(data);
		}
	}
}
