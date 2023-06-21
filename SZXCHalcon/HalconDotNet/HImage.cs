using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HImage : HObject, ISerializable, ICloneable
	{
		public new HImage this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HImage() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HImage(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HImage(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HImage(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
			SZXCArimAPI.AssertObjectClass(this.key, "image");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HImage obj)
		{
			obj = new HImage(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		public HImage(string type, int width, int height, IntPtr pixelPointer)
		{
			IntPtr proc = SZXCArimAPI.PreCall(606);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.StoreIP(proc, 3, pixelPointer);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage(string type, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(607);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage(HTuple fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1658);
			SZXCArimAPI.Store(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fileName);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1658);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeImage();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HImage(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeImage(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeImage();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HImage Deserialize(Stream stream)
		{
			HImage arg_0C_0 = new HImage();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeImage(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HImage Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeImage();
			HImage expr_0C = new HImage();
			expr_0C.DeserializeImage(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static HImage operator -(HImage image)
		{
			return image.InvertImage();
		}

		public static HImage operator +(HImage image1, HImage image2)
		{
			return image1.AddImage(image2, 1.0, 0.0);
		}

		public static HImage operator -(HImage image1, HImage image2)
		{
			return image1.SubImage(image2, 1.0, 0.0);
		}

		public static HImage operator *(HImage image1, HImage image2)
		{
			return image1.MultImage(image2, 1.0, 0.0);
		}

		public static HImage operator +(HImage image, double add)
		{
			return image.ScaleImage(1.0, add);
		}

		public static HImage operator +(double add, HImage image)
		{
			return image.ScaleImage(1.0, add);
		}

		public static HImage operator -(HImage image, double sub)
		{
			return image.ScaleImage(1.0, -sub);
		}

		public static HImage operator *(HImage image, double mult)
		{
			return image.ScaleImage(mult, 0.0);
		}

		public static HImage operator *(double mult, HImage image)
		{
			return image.ScaleImage(mult, 0.0);
		}

		public static HImage operator /(HImage image, double div)
		{
			return image.ScaleImage(1.0 / div, 0.0);
		}

		public static HRegion operator >=(HImage image1, HImage image2)
		{
			return image1.DynThreshold(image2, 0.0, "light");
		}

		public static HRegion operator <=(HImage image1, HImage image2)
		{
			return image1.DynThreshold(image2, 0.0, "dark");
		}

		public static HRegion operator >=(HImage image, double threshold)
		{
			return image.Threshold(threshold, 1.7976931348623157E+308);
		}

		public static HRegion operator <=(HImage image, double threshold)
		{
			return image.Threshold(-1.7976931348623157E+308, threshold);
		}

		public static HRegion operator >=(double threshold, HImage image)
		{
			return image.Threshold(-1.7976931348623157E+308, threshold);
		}

		public static HRegion operator <=(double threshold, HImage image)
		{
			return image.Threshold(threshold, 1.7976931348623157E+308);
		}

		public static HImage operator &(HImage image, HRegion region)
		{
			return image.ReduceDomain(region);
		}

		public static implicit operator HRegion(HImage image)
		{
			return image.GetDomain();
		}

		public HImage WienerFilterNi(HImage psf, HRegion noiseRegion, int maskWidth, int maskHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(75);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, psf);
			SZXCArimAPI.Store(proc, 3, noiseRegion);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(psf);
			GC.KeepAlive(noiseRegion);
			return result;
		}

		public HImage WienerFilter(HImage psf, HImage filteredImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(76);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, psf);
			SZXCArimAPI.Store(proc, 3, filteredImage);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(psf);
			GC.KeepAlive(filteredImage);
			return result;
		}

		public void GenPsfMotion(int PSFwidth, int PSFheight, double blurring, int angle, int type)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(77);
			SZXCArimAPI.StoreI(proc, 0, PSFwidth);
			SZXCArimAPI.StoreI(proc, 1, PSFheight);
			SZXCArimAPI.StoreD(proc, 2, blurring);
			SZXCArimAPI.StoreI(proc, 3, angle);
			SZXCArimAPI.StoreI(proc, 4, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage SimulateMotion(double blurring, int angle, int type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(78);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, blurring);
			SZXCArimAPI.StoreI(proc, 1, angle);
			SZXCArimAPI.StoreI(proc, 2, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenPsfDefocus(int PSFwidth, int PSFheight, double blurring)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(79);
			SZXCArimAPI.StoreI(proc, 0, PSFwidth);
			SZXCArimAPI.StoreI(proc, 1, PSFheight);
			SZXCArimAPI.StoreD(proc, 2, blurring);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage SimulateDefocus(double blurring)
		{
			IntPtr proc = SZXCArimAPI.PreCall(80);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, blurring);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion CompareExtVariationModel(HVariationModel modelID, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(87);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
			return result;
		}

		public HRegion CompareVariationModel(HVariationModel modelID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(88);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
			return result;
		}

		public void TrainVariationModel(HVariationModel modelID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(91);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
		}

		public HHomMat2D ProjMatchPointsDistortionRansacGuided(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, HHomMat2D homMat2DGuide, double kappaGuide, double distanceTolerance, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(256);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.Store(proc, 6, homMat2DGuide);
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
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(homMat2DGuide);
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
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsDistortionRansacGuided(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, HHomMat2D homMat2DGuide, double kappaGuide, double distanceTolerance, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(256);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.Store(proc, 6, homMat2DGuide);
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
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(homMat2DGuide);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out kappa);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsDistortionRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(257);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out kappa);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsDistortionRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(257);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out kappa);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsRansacGuided(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, HHomMat2D homMat2DGuide, double distanceTolerance, HTuple matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(258);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.Store(proc, 6, homMat2DGuide);
			SZXCArimAPI.StoreD(proc, 7, distanceTolerance);
			SZXCArimAPI.Store(proc, 8, matchThreshold);
			SZXCArimAPI.StoreS(proc, 9, estimationMethod);
			SZXCArimAPI.StoreD(proc, 10, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 11, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(homMat2DGuide);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsRansacGuided(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, HHomMat2D homMat2DGuide, double distanceTolerance, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(258);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.StoreS(proc, 4, grayMatchMethod);
			SZXCArimAPI.StoreI(proc, 5, maskSize);
			SZXCArimAPI.Store(proc, 6, homMat2DGuide);
			SZXCArimAPI.StoreD(proc, 7, distanceTolerance);
			SZXCArimAPI.StoreI(proc, 8, matchThreshold);
			SZXCArimAPI.StoreS(proc, 9, estimationMethod);
			SZXCArimAPI.StoreD(proc, 10, distanceThreshold);
			SZXCArimAPI.StoreI(proc, 11, randSeed);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(homMat2DGuide);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(259);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D ProjMatchPointsRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(259);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public void ReceiveImage(HSocket socket)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(325);
			SZXCArimAPI.Store(proc, 0, socket);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public void SendImage(HSocket socket)
		{
			IntPtr proc = SZXCArimAPI.PreCall(326);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, socket);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public HImage BinocularDistanceMs(HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(346);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreI(proc, 3, minDisparity);
			SZXCArimAPI.StoreI(proc, 4, maxDisparity);
			SZXCArimAPI.StoreI(proc, 5, surfaceSmoothing);
			SZXCArimAPI.StoreI(proc, 6, edgeSmoothing);
			SZXCArimAPI.Store(proc, 7, genParamName);
			SZXCArimAPI.Store(proc, 8, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistanceMs(HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(346);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreI(proc, 3, minDisparity);
			SZXCArimAPI.StoreI(proc, 4, maxDisparity);
			SZXCArimAPI.StoreI(proc, 5, surfaceSmoothing);
			SZXCArimAPI.StoreI(proc, 6, edgeSmoothing);
			SZXCArimAPI.StoreS(proc, 7, genParamName);
			SZXCArimAPI.StoreS(proc, 8, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDisparityMs(HImage imageRect2, out HImage score, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(347);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.StoreI(proc, 0, minDisparity);
			SZXCArimAPI.StoreI(proc, 1, maxDisparity);
			SZXCArimAPI.StoreI(proc, 2, surfaceSmoothing);
			SZXCArimAPI.StoreI(proc, 3, edgeSmoothing);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDisparityMs(HImage imageRect2, out HImage score, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(347);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.StoreI(proc, 0, minDisparity);
			SZXCArimAPI.StoreI(proc, 1, maxDisparity);
			SZXCArimAPI.StoreI(proc, 2, surfaceSmoothing);
			SZXCArimAPI.StoreI(proc, 3, edgeSmoothing);
			SZXCArimAPI.StoreS(proc, 4, genParamName);
			SZXCArimAPI.StoreS(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistanceMg(HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, HTuple MGParamName, HTuple MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(348);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreD(proc, 3, grayConstancy);
			SZXCArimAPI.StoreD(proc, 4, gradientConstancy);
			SZXCArimAPI.StoreD(proc, 5, smoothness);
			SZXCArimAPI.StoreD(proc, 6, initialGuess);
			SZXCArimAPI.StoreS(proc, 7, calculateScore);
			SZXCArimAPI.Store(proc, 8, MGParamName);
			SZXCArimAPI.Store(proc, 9, MGParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(MGParamName);
			SZXCArimAPI.UnpinTuple(MGParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistanceMg(HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, string MGParamName, string MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(348);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreD(proc, 3, grayConstancy);
			SZXCArimAPI.StoreD(proc, 4, gradientConstancy);
			SZXCArimAPI.StoreD(proc, 5, smoothness);
			SZXCArimAPI.StoreD(proc, 6, initialGuess);
			SZXCArimAPI.StoreS(proc, 7, calculateScore);
			SZXCArimAPI.StoreS(proc, 8, MGParamName);
			SZXCArimAPI.StoreS(proc, 9, MGParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDisparityMg(HImage imageRect2, out HImage score, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, HTuple MGParamName, HTuple MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(349);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.StoreD(proc, 0, grayConstancy);
			SZXCArimAPI.StoreD(proc, 1, gradientConstancy);
			SZXCArimAPI.StoreD(proc, 2, smoothness);
			SZXCArimAPI.StoreD(proc, 3, initialGuess);
			SZXCArimAPI.StoreS(proc, 4, calculateScore);
			SZXCArimAPI.Store(proc, 5, MGParamName);
			SZXCArimAPI.Store(proc, 6, MGParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(MGParamName);
			SZXCArimAPI.UnpinTuple(MGParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDisparityMg(HImage imageRect2, out HImage score, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, string MGParamName, string MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(349);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.StoreD(proc, 0, grayConstancy);
			SZXCArimAPI.StoreD(proc, 1, gradientConstancy);
			SZXCArimAPI.StoreD(proc, 2, smoothness);
			SZXCArimAPI.StoreD(proc, 3, initialGuess);
			SZXCArimAPI.StoreS(proc, 4, calculateScore);
			SZXCArimAPI.StoreS(proc, 5, MGParamName);
			SZXCArimAPI.StoreS(proc, 6, MGParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage GenBinocularProjRectification(HHomMat2D FMatrix, HTuple covFMat, int width1, int height1, int width2, int height2, HTuple subSampling, string mapping, out HTuple covFMatRect, out HHomMat2D h1, out HHomMat2D h2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(351);
			SZXCArimAPI.Store(proc, 0, FMatrix);
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
			SZXCArimAPI.UnpinTuple(FMatrix);
			SZXCArimAPI.UnpinTuple(covFMat);
			SZXCArimAPI.UnpinTuple(subSampling);
			num = base.Load(proc, 1, num);
			HImage result;
			num = HImage.LoadNew(proc, 2, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out covFMatRect);
			num = HHomMat2D.LoadNew(proc, 1, num, out h1);
			num = HHomMat2D.LoadNew(proc, 2, num, out h2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenBinocularProjRectification(HHomMat2D FMatrix, HTuple covFMat, int width1, int height1, int width2, int height2, int subSampling, string mapping, out HTuple covFMatRect, out HHomMat2D h1, out HHomMat2D h2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(351);
			SZXCArimAPI.Store(proc, 0, FMatrix);
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
			SZXCArimAPI.UnpinTuple(FMatrix);
			SZXCArimAPI.UnpinTuple(covFMat);
			num = base.Load(proc, 1, num);
			HImage result;
			num = HImage.LoadNew(proc, 2, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out covFMatRect);
			num = HHomMat2D.LoadNew(proc, 1, num, out h1);
			num = HHomMat2D.LoadNew(proc, 2, num, out h2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D MatchFundamentalMatrixDistortionRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(358);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out kappa);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D MatchFundamentalMatrixDistortionRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double kappa, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(358);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out kappa);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HPose MatchRelPoseRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HCamPar camPar1, HCamPar camPar2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out HTuple covRelPose, out HTuple error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(359);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, camPar1);
			SZXCArimAPI.Store(proc, 5, camPar2);
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
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(camPar1);
			SZXCArimAPI.UnpinTuple(camPar2);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(matchThreshold);
			SZXCArimAPI.UnpinTuple(distanceThreshold);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covRelPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HPose MatchRelPoseRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HCamPar camPar1, HCamPar camPar2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple covRelPose, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(359);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, camPar1);
			SZXCArimAPI.Store(proc, 5, camPar2);
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
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(camPar1);
			SZXCArimAPI.UnpinTuple(camPar2);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covRelPose);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D MatchEssentialMatrixRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HHomMat2D camMat1, HHomMat2D camMat2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out HTuple covEMat, out HTuple error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(360);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, camMat1);
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
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(camMat1);
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
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D MatchEssentialMatrixRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HHomMat2D camMat1, HHomMat2D camMat2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple covEMat, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(360);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
			SZXCArimAPI.Store(proc, 4, camMat1);
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
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(camMat1);
			SZXCArimAPI.UnpinTuple(camMat2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covEMat);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D MatchFundamentalMatrixRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out HTuple covFMat, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(361);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covFMat);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HHomMat2D MatchFundamentalMatrixRansac(HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple covFMat, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(361);
			base.Store(proc, 1);
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
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covFMat);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage BinocularDistance(HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect, string method, int maskWidth, int maskHeight, HTuple textureThresh, int minDisparity, int maxDisparity, int numLevels, HTuple scoreThresh, HTuple filter, HTuple subDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(362);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreS(proc, 3, method);
			SZXCArimAPI.StoreI(proc, 4, maskWidth);
			SZXCArimAPI.StoreI(proc, 5, maskHeight);
			SZXCArimAPI.Store(proc, 6, textureThresh);
			SZXCArimAPI.StoreI(proc, 7, minDisparity);
			SZXCArimAPI.StoreI(proc, 8, maxDisparity);
			SZXCArimAPI.StoreI(proc, 9, numLevels);
			SZXCArimAPI.Store(proc, 10, scoreThresh);
			SZXCArimAPI.Store(proc, 11, filter);
			SZXCArimAPI.Store(proc, 12, subDistance);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(textureThresh);
			SZXCArimAPI.UnpinTuple(scoreThresh);
			SZXCArimAPI.UnpinTuple(filter);
			SZXCArimAPI.UnpinTuple(subDistance);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistance(HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect, string method, int maskWidth, int maskHeight, double textureThresh, int minDisparity, int maxDisparity, int numLevels, double scoreThresh, string filter, string subDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(362);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreS(proc, 3, method);
			SZXCArimAPI.StoreI(proc, 4, maskWidth);
			SZXCArimAPI.StoreI(proc, 5, maskHeight);
			SZXCArimAPI.StoreD(proc, 6, textureThresh);
			SZXCArimAPI.StoreI(proc, 7, minDisparity);
			SZXCArimAPI.StoreI(proc, 8, maxDisparity);
			SZXCArimAPI.StoreI(proc, 9, numLevels);
			SZXCArimAPI.StoreD(proc, 10, scoreThresh);
			SZXCArimAPI.StoreS(proc, 11, filter);
			SZXCArimAPI.StoreS(proc, 12, subDistance);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDisparity(HImage imageRect2, out HImage score, string method, int maskWidth, int maskHeight, HTuple textureThresh, int minDisparity, int maxDisparity, int numLevels, HTuple scoreThresh, HTuple filter, string subDisparity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(363);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.StoreI(proc, 2, maskHeight);
			SZXCArimAPI.Store(proc, 3, textureThresh);
			SZXCArimAPI.StoreI(proc, 4, minDisparity);
			SZXCArimAPI.StoreI(proc, 5, maxDisparity);
			SZXCArimAPI.StoreI(proc, 6, numLevels);
			SZXCArimAPI.Store(proc, 7, scoreThresh);
			SZXCArimAPI.Store(proc, 8, filter);
			SZXCArimAPI.StoreS(proc, 9, subDisparity);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(textureThresh);
			SZXCArimAPI.UnpinTuple(scoreThresh);
			SZXCArimAPI.UnpinTuple(filter);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDisparity(HImage imageRect2, out HImage score, string method, int maskWidth, int maskHeight, double textureThresh, int minDisparity, int maxDisparity, int numLevels, double scoreThresh, string filter, string subDisparity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(363);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.StoreI(proc, 2, maskHeight);
			SZXCArimAPI.StoreD(proc, 3, textureThresh);
			SZXCArimAPI.StoreI(proc, 4, minDisparity);
			SZXCArimAPI.StoreI(proc, 5, maxDisparity);
			SZXCArimAPI.StoreI(proc, 6, numLevels);
			SZXCArimAPI.StoreD(proc, 7, scoreThresh);
			SZXCArimAPI.StoreS(proc, 8, filter);
			SZXCArimAPI.StoreS(proc, 9, subDisparity);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage DisparityImageToXyz(out HImage y, out HImage z, HCamPar camParamRect1, HCamPar camParamRect2, HPose relPoseRect)
		{
			IntPtr proc = SZXCArimAPI.PreCall(365);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out y);
			num = HImage.LoadNew(proc, 3, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenBinocularRectificationMap(HCamPar camParam1, HCamPar camParam2, HPose relPose, double subSampling, string method, string mapType, out HCamPar camParamRect1, out HCamPar camParamRect2, out HPose camPoseRect1, out HPose camPoseRect2, out HPose relPoseRect)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(369);
			SZXCArimAPI.Store(proc, 0, camParam1);
			SZXCArimAPI.Store(proc, 1, camParam2);
			SZXCArimAPI.Store(proc, 2, relPose);
			SZXCArimAPI.StoreD(proc, 3, subSampling);
			SZXCArimAPI.StoreS(proc, 4, method);
			SZXCArimAPI.StoreS(proc, 5, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam1);
			SZXCArimAPI.UnpinTuple(camParam2);
			SZXCArimAPI.UnpinTuple(relPose);
			num = base.Load(proc, 1, num);
			HImage result;
			num = HImage.LoadNew(proc, 2, num, out result);
			num = HCamPar.LoadNew(proc, 0, num, out camParamRect1);
			num = HCamPar.LoadNew(proc, 1, num, out camParamRect2);
			num = HPose.LoadNew(proc, 2, num, out camPoseRect1);
			num = HPose.LoadNew(proc, 3, num, out camPoseRect2);
			num = HPose.LoadNew(proc, 4, num, out relPoseRect);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetSheetOfLightResult(HSheetOfLightModel sheetOfLightModelID, HTuple resultName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(381);
			SZXCArimAPI.Store(proc, 0, sheetOfLightModelID);
			SZXCArimAPI.Store(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultName);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sheetOfLightModelID);
		}

		public void GetSheetOfLightResult(HSheetOfLightModel sheetOfLightModelID, string resultName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(381);
			SZXCArimAPI.Store(proc, 0, sheetOfLightModelID);
			SZXCArimAPI.StoreS(proc, 1, resultName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sheetOfLightModelID);
		}

		public void ApplySheetOfLightCalibration(HSheetOfLightModel sheetOfLightModelID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(382);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sheetOfLightModelID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(sheetOfLightModelID);
		}

		public void SetProfileSheetOfLight(HSheetOfLightModel sheetOfLightModelID, HTuple movementPoses)
		{
			IntPtr proc = SZXCArimAPI.PreCall(383);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sheetOfLightModelID);
			SZXCArimAPI.Store(proc, 1, movementPoses);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(movementPoses);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(sheetOfLightModelID);
		}

		public void MeasureProfileSheetOfLight(HSheetOfLightModel sheetOfLightModelID, HTuple movementPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(384);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sheetOfLightModelID);
			SZXCArimAPI.Store(proc, 1, movementPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(movementPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(sheetOfLightModelID);
		}

		public HImage ShadeHeightField(HTuple slant, HTuple tilt, HTuple albedo, HTuple ambient, string shadows)
		{
			IntPtr proc = SZXCArimAPI.PreCall(392);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, slant);
			SZXCArimAPI.Store(proc, 1, tilt);
			SZXCArimAPI.Store(proc, 2, albedo);
			SZXCArimAPI.Store(proc, 3, ambient);
			SZXCArimAPI.StoreS(proc, 4, shadows);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(slant);
			SZXCArimAPI.UnpinTuple(tilt);
			SZXCArimAPI.UnpinTuple(albedo);
			SZXCArimAPI.UnpinTuple(ambient);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ShadeHeightField(double slant, double tilt, double albedo, double ambient, string shadows)
		{
			IntPtr proc = SZXCArimAPI.PreCall(392);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, slant);
			SZXCArimAPI.StoreD(proc, 1, tilt);
			SZXCArimAPI.StoreD(proc, 2, albedo);
			SZXCArimAPI.StoreD(proc, 3, ambient);
			SZXCArimAPI.StoreS(proc, 4, shadows);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EstimateAlAm(out HTuple ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(393);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out ambient);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double EstimateAlAm(out double ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(393);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out ambient);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EstimateSlAlZc(out HTuple albedo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(394);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out albedo);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double EstimateSlAlZc(out double albedo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(394);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out albedo);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EstimateSlAlLr(out HTuple albedo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(395);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out albedo);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double EstimateSlAlLr(out double albedo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(395);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out albedo);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EstimateTiltZc()
		{
			IntPtr proc = SZXCArimAPI.PreCall(396);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EstimateTiltLr()
		{
			IntPtr proc = SZXCArimAPI.PreCall(397);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ReconstructHeightFieldFromGradient(string reconstructionMethod, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(398);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, reconstructionMethod);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PhotometricStereo(out HImage gradient, out HImage albedo, HTuple slants, HTuple tilts, HTuple resultType, string reconstructionMethod, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(399);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, slants);
			SZXCArimAPI.Store(proc, 1, tilts);
			SZXCArimAPI.Store(proc, 2, resultType);
			SZXCArimAPI.StoreS(proc, 3, reconstructionMethod);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(slants);
			SZXCArimAPI.UnpinTuple(tilts);
			SZXCArimAPI.UnpinTuple(resultType);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out gradient);
			num = HImage.LoadNew(proc, 3, num, out albedo);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SfsPentland(HTuple slant, HTuple tilt, HTuple albedo, HTuple ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(400);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, slant);
			SZXCArimAPI.Store(proc, 1, tilt);
			SZXCArimAPI.Store(proc, 2, albedo);
			SZXCArimAPI.Store(proc, 3, ambient);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(slant);
			SZXCArimAPI.UnpinTuple(tilt);
			SZXCArimAPI.UnpinTuple(albedo);
			SZXCArimAPI.UnpinTuple(ambient);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SfsPentland(double slant, double tilt, double albedo, double ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(400);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, slant);
			SZXCArimAPI.StoreD(proc, 1, tilt);
			SZXCArimAPI.StoreD(proc, 2, albedo);
			SZXCArimAPI.StoreD(proc, 3, ambient);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SfsOrigLr(HTuple slant, HTuple tilt, HTuple albedo, HTuple ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(401);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, slant);
			SZXCArimAPI.Store(proc, 1, tilt);
			SZXCArimAPI.Store(proc, 2, albedo);
			SZXCArimAPI.Store(proc, 3, ambient);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(slant);
			SZXCArimAPI.UnpinTuple(tilt);
			SZXCArimAPI.UnpinTuple(albedo);
			SZXCArimAPI.UnpinTuple(ambient);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SfsOrigLr(double slant, double tilt, double albedo, double ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(401);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, slant);
			SZXCArimAPI.StoreD(proc, 1, tilt);
			SZXCArimAPI.StoreD(proc, 2, albedo);
			SZXCArimAPI.StoreD(proc, 3, ambient);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SfsModLr(HTuple slant, HTuple tilt, HTuple albedo, HTuple ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(402);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, slant);
			SZXCArimAPI.Store(proc, 1, tilt);
			SZXCArimAPI.Store(proc, 2, albedo);
			SZXCArimAPI.Store(proc, 3, ambient);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(slant);
			SZXCArimAPI.UnpinTuple(tilt);
			SZXCArimAPI.UnpinTuple(albedo);
			SZXCArimAPI.UnpinTuple(ambient);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SfsModLr(double slant, double tilt, double albedo, double ambient)
		{
			IntPtr proc = SZXCArimAPI.PreCall(402);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, slant);
			SZXCArimAPI.StoreD(proc, 1, tilt);
			SZXCArimAPI.StoreD(proc, 2, albedo);
			SZXCArimAPI.StoreD(proc, 3, ambient);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTextResult FindText(HTextModel textModel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(417);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, textModel);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTextResult result;
			num = HTextResult.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(textModel);
			return result;
		}

		public HRegion ClassifyImageClassLut(HClassLUT classLUTHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(428);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, classLUTHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(classLUTHandle);
			return result;
		}

		public HRegion ClassifyImageClassKnn(out HImage distanceImage, HClassKnn KNNHandle, double rejectionThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(429);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, KNNHandle);
			SZXCArimAPI.StoreD(proc, 1, rejectionThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out distanceImage);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(KNNHandle);
			return result;
		}

		public void AddSamplesImageClassKnn(HRegion classRegions, HClassKnn KNNHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(430);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, classRegions);
			SZXCArimAPI.Store(proc, 0, KNNHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classRegions);
			GC.KeepAlive(KNNHandle);
		}

		public HRegion ClassifyImageClassGmm(HClassGmm GMMHandle, double rejectionThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(431);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, GMMHandle);
			SZXCArimAPI.StoreD(proc, 1, rejectionThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(GMMHandle);
			return result;
		}

		public void AddSamplesImageClassGmm(HRegion classRegions, HClassGmm GMMHandle, double randomize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(432);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, classRegions);
			SZXCArimAPI.Store(proc, 0, GMMHandle);
			SZXCArimAPI.StoreD(proc, 1, randomize);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classRegions);
			GC.KeepAlive(GMMHandle);
		}

		public HRegion ClassifyImageClassSvm(HClassSvm SVMHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(433);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, SVMHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SVMHandle);
			return result;
		}

		public void AddSamplesImageClassSvm(HRegion classRegions, HClassSvm SVMHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(434);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, classRegions);
			SZXCArimAPI.Store(proc, 0, SVMHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classRegions);
			GC.KeepAlive(SVMHandle);
		}

		public HRegion ClassifyImageClassMlp(HClassMlp MLPHandle, double rejectionThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(435);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, MLPHandle);
			SZXCArimAPI.StoreD(proc, 1, rejectionThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(MLPHandle);
			return result;
		}

		public void AddSamplesImageClassMlp(HRegion classRegions, HClassMlp MLPHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(436);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, classRegions);
			SZXCArimAPI.Store(proc, 0, MLPHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classRegions);
			GC.KeepAlive(MLPHandle);
		}

		public HTuple LearnNdimNorm(HRegion foreground, HRegion background, string metric, HTuple distance, HTuple minNumberPercent, out HTuple center, out double quality)
		{
			IntPtr proc = SZXCArimAPI.PreCall(437);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 1, foreground);
			SZXCArimAPI.Store(proc, 2, background);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.Store(proc, 1, distance);
			SZXCArimAPI.Store(proc, 2, minNumberPercent);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(distance);
			SZXCArimAPI.UnpinTuple(minNumberPercent);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out center);
			num = SZXCArimAPI.LoadD(proc, 2, num, out quality);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(foreground);
			GC.KeepAlive(background);
			return result;
		}

		public HTuple LearnNdimNorm(HRegion foreground, HRegion background, string metric, double distance, double minNumberPercent, out HTuple center, out double quality)
		{
			IntPtr proc = SZXCArimAPI.PreCall(437);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 1, foreground);
			SZXCArimAPI.Store(proc, 2, background);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.StoreD(proc, 1, distance);
			SZXCArimAPI.StoreD(proc, 2, minNumberPercent);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out center);
			num = SZXCArimAPI.LoadD(proc, 2, num, out quality);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(foreground);
			GC.KeepAlive(background);
			return result;
		}

		public void LearnNdimBox(HRegion foreground, HRegion background, HClassBox classifHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(438);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 1, foreground);
			SZXCArimAPI.Store(proc, 2, background);
			SZXCArimAPI.Store(proc, 0, classifHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(foreground);
			GC.KeepAlive(background);
			GC.KeepAlive(classifHandle);
		}

		public HRegion ClassNdimBox(HClassBox classifHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(439);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, classifHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(classifHandle);
			return result;
		}

		public HRegion ClassNdimNorm(string metric, string singleMultiple, HTuple radius, HTuple center)
		{
			IntPtr proc = SZXCArimAPI.PreCall(440);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.StoreS(proc, 1, singleMultiple);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.Store(proc, 3, center);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(center);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ClassNdimNorm(string metric, string singleMultiple, double radius, double center)
		{
			IntPtr proc = SZXCArimAPI.PreCall(440);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.StoreS(proc, 1, singleMultiple);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, center);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Class2dimSup(HImage imageRow, HRegion featureSpace)
		{
			IntPtr proc = SZXCArimAPI.PreCall(441);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRow);
			SZXCArimAPI.Store(proc, 3, featureSpace);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRow);
			GC.KeepAlive(featureSpace);
			return result;
		}

		public HRegion Class2dimUnsup(HImage image2, int threshold, int numClasses)
		{
			IntPtr proc = SZXCArimAPI.PreCall(442);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.StoreI(proc, 0, threshold);
			SZXCArimAPI.StoreI(proc, 1, numClasses);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HRegion CheckDifference(HImage pattern, string mode, int diffLowerBound, int diffUpperBound, int grayOffset, int addRow, int addCol)
		{
			IntPtr proc = SZXCArimAPI.PreCall(443);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, pattern);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, diffLowerBound);
			SZXCArimAPI.StoreI(proc, 2, diffUpperBound);
			SZXCArimAPI.StoreI(proc, 3, grayOffset);
			SZXCArimAPI.StoreI(proc, 4, addRow);
			SZXCArimAPI.StoreI(proc, 5, addCol);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(pattern);
			return result;
		}

		public HRegion CharThreshold(HRegion histoRegion, double sigma, HTuple percent, out HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(444);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, histoRegion);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.Store(proc, 1, percent);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(percent);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out threshold);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(histoRegion);
			return result;
		}

		public HRegion CharThreshold(HRegion histoRegion, double sigma, double percent, out int threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(444);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, histoRegion);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, percent);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadI(proc, 0, num, out threshold);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(histoRegion);
			return result;
		}

		public HRegion LabelToRegion()
		{
			IntPtr proc = SZXCArimAPI.PreCall(445);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage NonmaxSuppressionAmp(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(446);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage NonmaxSuppressionDir(HImage imgDir, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(447);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imgDir);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imgDir);
			return result;
		}

		public HRegion HysteresisThreshold(HTuple low, HTuple high, int maxLength)
		{
			IntPtr proc = SZXCArimAPI.PreCall(448);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, low);
			SZXCArimAPI.Store(proc, 1, high);
			SZXCArimAPI.StoreI(proc, 2, maxLength);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(low);
			SZXCArimAPI.UnpinTuple(high);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion HysteresisThreshold(int low, int high, int maxLength)
		{
			IntPtr proc = SZXCArimAPI.PreCall(448);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, low);
			SZXCArimAPI.StoreI(proc, 1, high);
			SZXCArimAPI.StoreI(proc, 2, maxLength);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion BinaryThreshold(string method, string lightDark, out HTuple usedThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(449);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreS(proc, 1, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, num, out usedThreshold);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion BinaryThreshold(string method, string lightDark, out int usedThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(449);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreS(proc, 1, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadI(proc, 0, num, out usedThreshold);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion LocalThreshold(string method, string lightDark, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(450);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreS(proc, 1, lightDark);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion LocalThreshold(string method, string lightDark, string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(450);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreS(proc, 1, lightDark);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreI(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion VarThreshold(int maskWidth, int maskHeight, HTuple stdDevScale, HTuple absThreshold, string lightDark)
		{
			IntPtr proc = SZXCArimAPI.PreCall(451);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.Store(proc, 2, stdDevScale);
			SZXCArimAPI.Store(proc, 3, absThreshold);
			SZXCArimAPI.StoreS(proc, 4, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(stdDevScale);
			SZXCArimAPI.UnpinTuple(absThreshold);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion VarThreshold(int maskWidth, int maskHeight, double stdDevScale, double absThreshold, string lightDark)
		{
			IntPtr proc = SZXCArimAPI.PreCall(451);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreD(proc, 2, stdDevScale);
			SZXCArimAPI.StoreD(proc, 3, absThreshold);
			SZXCArimAPI.StoreS(proc, 4, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion DynThreshold(HImage thresholdImage, HTuple offset, string lightDark)
		{
			IntPtr proc = SZXCArimAPI.PreCall(452);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, thresholdImage);
			SZXCArimAPI.Store(proc, 0, offset);
			SZXCArimAPI.StoreS(proc, 1, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(offset);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(thresholdImage);
			return result;
		}

		public HRegion DynThreshold(HImage thresholdImage, double offset, string lightDark)
		{
			IntPtr proc = SZXCArimAPI.PreCall(452);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, thresholdImage);
			SZXCArimAPI.StoreD(proc, 0, offset);
			SZXCArimAPI.StoreS(proc, 1, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(thresholdImage);
			return result;
		}

		public HRegion Threshold(HTuple minGray, HTuple maxGray)
		{
			IntPtr proc = SZXCArimAPI.PreCall(453);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, minGray);
			SZXCArimAPI.Store(proc, 1, maxGray);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minGray);
			SZXCArimAPI.UnpinTuple(maxGray);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Threshold(double minGray, double maxGray)
		{
			IntPtr proc = SZXCArimAPI.PreCall(453);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, minGray);
			SZXCArimAPI.StoreD(proc, 1, maxGray);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ThresholdSubPix(HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(454);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(threshold);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ThresholdSubPix(double threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(454);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion RegiongrowingN(string metric, HTuple minTolerance, HTuple maxTolerance, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(455);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.Store(proc, 1, minTolerance);
			SZXCArimAPI.Store(proc, 2, maxTolerance);
			SZXCArimAPI.StoreI(proc, 3, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minTolerance);
			SZXCArimAPI.UnpinTuple(maxTolerance);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion RegiongrowingN(string metric, double minTolerance, double maxTolerance, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(455);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.StoreD(proc, 1, minTolerance);
			SZXCArimAPI.StoreD(proc, 2, maxTolerance);
			SZXCArimAPI.StoreI(proc, 3, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Regiongrowing(int rasterHeight, int rasterWidth, HTuple tolerance, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(456);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, rasterHeight);
			SZXCArimAPI.StoreI(proc, 1, rasterWidth);
			SZXCArimAPI.Store(proc, 2, tolerance);
			SZXCArimAPI.StoreI(proc, 3, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(tolerance);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Regiongrowing(int rasterHeight, int rasterWidth, double tolerance, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(456);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, rasterHeight);
			SZXCArimAPI.StoreI(proc, 1, rasterWidth);
			SZXCArimAPI.StoreD(proc, 2, tolerance);
			SZXCArimAPI.StoreI(proc, 3, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion RegiongrowingMean(HTuple startRows, HTuple startColumns, double tolerance, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(457);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, startRows);
			SZXCArimAPI.Store(proc, 1, startColumns);
			SZXCArimAPI.StoreD(proc, 2, tolerance);
			SZXCArimAPI.StoreI(proc, 3, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(startRows);
			SZXCArimAPI.UnpinTuple(startColumns);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion RegiongrowingMean(int startRows, int startColumns, double tolerance, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(457);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, startRows);
			SZXCArimAPI.StoreI(proc, 1, startColumns);
			SZXCArimAPI.StoreD(proc, 2, tolerance);
			SZXCArimAPI.StoreI(proc, 3, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Pouring(string mode, int minGray, int maxGray)
		{
			IntPtr proc = SZXCArimAPI.PreCall(458);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, minGray);
			SZXCArimAPI.StoreI(proc, 2, maxGray);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion WatershedsThreshold(HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(459);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(threshold);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion WatershedsThreshold(int threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(459);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Watersheds(out HRegion watersheds)
		{
			IntPtr proc = SZXCArimAPI.PreCall(460);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out watersheds);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ZeroCrossing()
		{
			IntPtr proc = SZXCArimAPI.PreCall(461);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ZeroCrossingSubPix()
		{
			IntPtr proc = SZXCArimAPI.PreCall(462);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion DualThreshold(int minSize, double minGray, double threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(463);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, minSize);
			SZXCArimAPI.StoreD(proc, 1, minGray);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ExpandLine(int coordinate, string expandType, string rowColumn, HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(464);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, coordinate);
			SZXCArimAPI.StoreS(proc, 1, expandType);
			SZXCArimAPI.StoreS(proc, 2, rowColumn);
			SZXCArimAPI.Store(proc, 3, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(threshold);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ExpandLine(int coordinate, string expandType, string rowColumn, double threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(464);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, coordinate);
			SZXCArimAPI.StoreS(proc, 1, expandType);
			SZXCArimAPI.StoreS(proc, 2, rowColumn);
			SZXCArimAPI.StoreD(proc, 3, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion LocalMin()
		{
			IntPtr proc = SZXCArimAPI.PreCall(465);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Lowlands()
		{
			IntPtr proc = SZXCArimAPI.PreCall(466);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion LowlandsCenter()
		{
			IntPtr proc = SZXCArimAPI.PreCall(467);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion LocalMax()
		{
			IntPtr proc = SZXCArimAPI.PreCall(468);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Plateaus()
		{
			IntPtr proc = SZXCArimAPI.PreCall(469);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion PlateausCenter()
		{
			IntPtr proc = SZXCArimAPI.PreCall(470);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion AutoThreshold(HTuple sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(472);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sigma);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sigma);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion AutoThreshold(double sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(472);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion BinThreshold()
		{
			IntPtr proc = SZXCArimAPI.PreCall(473);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion FastThreshold(HTuple minGray, HTuple maxGray, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(474);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, minGray);
			SZXCArimAPI.Store(proc, 1, maxGray);
			SZXCArimAPI.StoreI(proc, 2, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minGray);
			SZXCArimAPI.UnpinTuple(maxGray);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion FastThreshold(double minGray, double maxGray, int minSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(474);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, minGray);
			SZXCArimAPI.StoreD(proc, 1, maxGray);
			SZXCArimAPI.StoreI(proc, 2, minSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ExpandGray(HRegion regions, HRegion forbiddenArea, HTuple iterations, string mode, HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(509);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 3, forbiddenArea);
			SZXCArimAPI.Store(proc, 0, iterations);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.Store(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(iterations);
			SZXCArimAPI.UnpinTuple(threshold);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ExpandGray(HRegion regions, HRegion forbiddenArea, string iterations, string mode, int threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(509);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 3, forbiddenArea);
			SZXCArimAPI.StoreS(proc, 0, iterations);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.StoreI(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ExpandGrayRef(HRegion regions, HRegion forbiddenArea, HTuple iterations, string mode, HTuple refGray, HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(510);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 3, forbiddenArea);
			SZXCArimAPI.Store(proc, 0, iterations);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.Store(proc, 2, refGray);
			SZXCArimAPI.Store(proc, 3, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(iterations);
			SZXCArimAPI.UnpinTuple(refGray);
			SZXCArimAPI.UnpinTuple(threshold);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ExpandGrayRef(HRegion regions, HRegion forbiddenArea, string iterations, string mode, int refGray, int threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(510);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 3, forbiddenArea);
			SZXCArimAPI.StoreS(proc, 0, iterations);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.StoreI(proc, 2, refGray);
			SZXCArimAPI.StoreI(proc, 3, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HImage ObjDiff(HImage objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public void SetGrayval(HTuple row, HTuple column, HTuple grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(574);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, grayval);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(grayval);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetGrayval(int row, int column, double grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(574);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, grayval);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage PaintXld(HXLD XLD, HTuple grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(575);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, XLD);
			SZXCArimAPI.Store(proc, 0, grayval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayval);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(XLD);
			return result;
		}

		public HImage PaintXld(HXLD XLD, double grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(575);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, XLD);
			SZXCArimAPI.StoreD(proc, 0, grayval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(XLD);
			return result;
		}

		public HImage PaintRegion(HRegion region, HTuple grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(576);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.Store(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayval);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage PaintRegion(HRegion region, double grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(576);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.StoreD(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public void OverpaintRegion(HRegion region, HTuple grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(577);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.Store(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayval);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
		}

		public void OverpaintRegion(HRegion region, double grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(577);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreD(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
		}

		public HImage GenImageProto(HTuple grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(578);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, grayval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayval);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenImageProto(double grayval)
		{
			IntPtr proc = SZXCArimAPI.PreCall(578);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, grayval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PaintGray(HImage imageDestination)
		{
			IntPtr proc = SZXCArimAPI.PreCall(579);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageDestination);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageDestination);
			return result;
		}

		public void OverpaintGray(HImage imageSource)
		{
			IntPtr proc = SZXCArimAPI.PreCall(580);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageSource);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(imageSource);
		}

		public new HImage CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ConcatObj(HImage objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public HImage CopyImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(586);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HImage SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HImage SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HImage objects2, HTuple epsilon)
		{
			IntPtr proc = SZXCArimAPI.PreCall(588);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.Store(proc, 0, epsilon);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(epsilon);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public int CompareObj(HImage objects2, double epsilon)
		{
			IntPtr proc = SZXCArimAPI.PreCall(588);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.StoreD(proc, 0, epsilon);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public int TestEqualObj(HImage objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(591);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public void GenImageInterleaved(IntPtr pixelPointer, string colorFormat, int originalWidth, int originalHeight, int alignment, string type, int imageWidth, int imageHeight, int startRow, int startColumn, int bitsPerChannel, int bitShift)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(595);
			SZXCArimAPI.StoreIP(proc, 0, pixelPointer);
			SZXCArimAPI.StoreS(proc, 1, colorFormat);
			SZXCArimAPI.StoreI(proc, 2, originalWidth);
			SZXCArimAPI.StoreI(proc, 3, originalHeight);
			SZXCArimAPI.StoreI(proc, 4, alignment);
			SZXCArimAPI.StoreS(proc, 5, type);
			SZXCArimAPI.StoreI(proc, 6, imageWidth);
			SZXCArimAPI.StoreI(proc, 7, imageHeight);
			SZXCArimAPI.StoreI(proc, 8, startRow);
			SZXCArimAPI.StoreI(proc, 9, startColumn);
			SZXCArimAPI.StoreI(proc, 10, bitsPerChannel);
			SZXCArimAPI.StoreI(proc, 11, bitShift);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImage3(string type, int width, int height, IntPtr pixelPointerRed, IntPtr pixelPointerGreen, IntPtr pixelPointerBlue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(605);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.StoreIP(proc, 3, pixelPointerRed);
			SZXCArimAPI.StoreIP(proc, 4, pixelPointerGreen);
			SZXCArimAPI.StoreIP(proc, 5, pixelPointerBlue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImage1(string type, int width, int height, IntPtr pixelPointer)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(606);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.StoreIP(proc, 3, pixelPointer);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImageConst(string type, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(607);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImageGrayRamp(double alpha, double beta, double mean, int row, int column, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(619);
			SZXCArimAPI.StoreD(proc, 0, alpha);
			SZXCArimAPI.StoreD(proc, 1, beta);
			SZXCArimAPI.StoreD(proc, 2, mean);
			SZXCArimAPI.StoreI(proc, 3, row);
			SZXCArimAPI.StoreI(proc, 4, column);
			SZXCArimAPI.StoreI(proc, 5, width);
			SZXCArimAPI.StoreI(proc, 6, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImage3Extern(string type, int width, int height, IntPtr pointerRed, IntPtr pointerGreen, IntPtr pointerBlue, IntPtr clearProc)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(620);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.StoreIP(proc, 3, pointerRed);
			SZXCArimAPI.StoreIP(proc, 4, pointerGreen);
			SZXCArimAPI.StoreIP(proc, 5, pointerBlue);
			SZXCArimAPI.StoreIP(proc, 6, clearProc);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImage1Extern(string type, int width, int height, IntPtr pixelPointer, IntPtr clearProc)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(621);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.StoreIP(proc, 3, pixelPointer);
			SZXCArimAPI.StoreIP(proc, 4, clearProc);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImage1Rect(IntPtr pixelPointer, int width, int height, int verticalPitch, int horizontalBitPitch, int bitsPerPixel, string doCopy, IntPtr clearProc)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(622);
			SZXCArimAPI.StoreIP(proc, 0, pixelPointer);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.StoreI(proc, 3, verticalPitch);
			SZXCArimAPI.StoreI(proc, 4, horizontalBitPitch);
			SZXCArimAPI.StoreI(proc, 5, bitsPerPixel);
			SZXCArimAPI.StoreS(proc, 6, doCopy);
			SZXCArimAPI.StoreIP(proc, 7, clearProc);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public IntPtr GetImagePointer1Rect(out int width, out int height, out int verticalPitch, out int horizontalBitPitch, out int bitsPerPixel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(623);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			IntPtr result;
			num = SZXCArimAPI.LoadIP(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out width);
			num = SZXCArimAPI.LoadI(proc, 2, num, out height);
			num = SZXCArimAPI.LoadI(proc, 3, num, out verticalPitch);
			num = SZXCArimAPI.LoadI(proc, 4, num, out horizontalBitPitch);
			num = SZXCArimAPI.LoadI(proc, 5, num, out bitsPerPixel);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetImagePointer3(out HTuple pointerRed, out HTuple pointerGreen, out HTuple pointerBlue, out HTuple type, out HTuple width, out HTuple height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(624);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out pointerRed);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out pointerGreen);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out pointerBlue);
			num = HTuple.LoadNew(proc, 3, num, out type);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out width);
			num = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetImagePointer3(out IntPtr pointerRed, out IntPtr pointerGreen, out IntPtr pointerBlue, out string type, out int width, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(624);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadIP(proc, 0, num, out pointerRed);
			num = SZXCArimAPI.LoadIP(proc, 1, num, out pointerGreen);
			num = SZXCArimAPI.LoadIP(proc, 2, num, out pointerBlue);
			num = SZXCArimAPI.LoadS(proc, 3, num, out type);
			num = SZXCArimAPI.LoadI(proc, 4, num, out width);
			num = SZXCArimAPI.LoadI(proc, 5, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetImagePointer1(out HTuple type, out HTuple width, out HTuple height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(625);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out type);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out width);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public IntPtr GetImagePointer1(out string type, out int width, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(625);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			IntPtr result;
			num = SZXCArimAPI.LoadIP(proc, 0, num, out result);
			num = SZXCArimAPI.LoadS(proc, 1, num, out type);
			num = SZXCArimAPI.LoadI(proc, 2, num, out width);
			num = SZXCArimAPI.LoadI(proc, 3, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetImageType()
		{
			IntPtr proc = SZXCArimAPI.PreCall(626);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetImageSize(out HTuple width, out HTuple height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(627);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out width);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetImageSize(out int width, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(627);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out width);
			num = SZXCArimAPI.LoadI(proc, 1, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public int GetImageTime(out int second, out int minute, out int hour, out int day, out int YDay, out int month, out int year)
		{
			IntPtr proc = SZXCArimAPI.PreCall(628);
			base.Store(proc, 1);
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
			num = SZXCArimAPI.LoadI(proc, 1, num, out second);
			num = SZXCArimAPI.LoadI(proc, 2, num, out minute);
			num = SZXCArimAPI.LoadI(proc, 3, num, out hour);
			num = SZXCArimAPI.LoadI(proc, 4, num, out day);
			num = SZXCArimAPI.LoadI(proc, 5, num, out YDay);
			num = SZXCArimAPI.LoadI(proc, 6, num, out month);
			num = SZXCArimAPI.LoadI(proc, 7, num, out year);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetGrayvalInterpolated(HTuple row, HTuple column, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(629);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetGrayvalInterpolated(double row, double column, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(629);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetGrayval(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(630);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetGrayval(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(630);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DoOcvSimple(HOCV OCVHandle, HTuple patternName, string adaptPos, string adaptSize, string adaptAngle, string adaptGray, double threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(638);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, OCVHandle);
			SZXCArimAPI.Store(proc, 1, patternName);
			SZXCArimAPI.StoreS(proc, 2, adaptPos);
			SZXCArimAPI.StoreS(proc, 3, adaptSize);
			SZXCArimAPI.StoreS(proc, 4, adaptAngle);
			SZXCArimAPI.StoreS(proc, 5, adaptGray);
			SZXCArimAPI.StoreD(proc, 6, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(patternName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(OCVHandle);
			return result;
		}

		public double DoOcvSimple(HOCV OCVHandle, string patternName, string adaptPos, string adaptSize, string adaptAngle, string adaptGray, double threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(638);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, OCVHandle);
			SZXCArimAPI.StoreS(proc, 1, patternName);
			SZXCArimAPI.StoreS(proc, 2, adaptPos);
			SZXCArimAPI.StoreS(proc, 3, adaptSize);
			SZXCArimAPI.StoreS(proc, 4, adaptAngle);
			SZXCArimAPI.StoreS(proc, 5, adaptGray);
			SZXCArimAPI.StoreD(proc, 6, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(OCVHandle);
			return result;
		}

		public void TraindOcvProj(HOCV OCVHandle, HTuple name, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(639);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, OCVHandle);
			SZXCArimAPI.Store(proc, 1, name);
			SZXCArimAPI.StoreS(proc, 2, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(name);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(OCVHandle);
		}

		public void TraindOcvProj(HOCV OCVHandle, string name, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(639);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, OCVHandle);
			SZXCArimAPI.StoreS(proc, 1, name);
			SZXCArimAPI.StoreS(proc, 2, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(OCVHandle);
		}

		public HTuple GetFeaturesOcrClassKnn(HOCRKnn OCRHandle, string transform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(656);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, transform);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple GetFeaturesOcrClassSvm(HOCRSvm OCRHandle, string transform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(678);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, transform);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple GetFeaturesOcrClassMlp(HOCRMlp OCRHandle, string transform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(696);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, transform);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HImage CropDomainRel(int top, int left, int bottom, int right)
		{
			IntPtr proc = SZXCArimAPI.PreCall(726);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, top);
			SZXCArimAPI.StoreI(proc, 1, left);
			SZXCArimAPI.StoreI(proc, 2, bottom);
			SZXCArimAPI.StoreI(proc, 3, right);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple OcrGetFeatures(HOCRBox ocrHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(727);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public void WriteOcrTrainfImage(HTuple classVal, string trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(729);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, classVal);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(classVal);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteOcrTrainfImage(string classVal, string trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(729);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, classVal);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple ReadOcrTrainfSelect(HTuple trainingFile, HTuple searchNames)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(733);
			SZXCArimAPI.Store(proc, 0, trainingFile);
			SZXCArimAPI.Store(proc, 1, searchNames);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(searchNames);
			num = base.Load(proc, 1, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string ReadOcrTrainfSelect(string trainingFile, string searchNames)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(733);
			SZXCArimAPI.StoreS(proc, 0, trainingFile);
			SZXCArimAPI.StoreS(proc, 1, searchNames);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ReadOcrTrainf(HTuple trainingFile)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(734);
			SZXCArimAPI.Store(proc, 0, trainingFile);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(trainingFile);
			num = base.Load(proc, 1, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ReadOcrTrainf(string trainingFile)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(734);
			SZXCArimAPI.StoreS(proc, 0, trainingFile);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayBothat(HImage SE)
		{
			IntPtr proc = SZXCArimAPI.PreCall(780);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, SE);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SE);
			return result;
		}

		public HImage GrayTophat(HImage SE)
		{
			IntPtr proc = SZXCArimAPI.PreCall(781);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, SE);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SE);
			return result;
		}

		public HImage GrayClosing(HImage SE)
		{
			IntPtr proc = SZXCArimAPI.PreCall(782);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, SE);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SE);
			return result;
		}

		public HImage GrayOpening(HImage SE)
		{
			IntPtr proc = SZXCArimAPI.PreCall(783);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, SE);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SE);
			return result;
		}

		public HImage GrayDilation(HImage SE)
		{
			IntPtr proc = SZXCArimAPI.PreCall(784);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, SE);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SE);
			return result;
		}

		public HImage GrayErosion(HImage SE)
		{
			IntPtr proc = SZXCArimAPI.PreCall(785);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, SE);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(SE);
			return result;
		}

		public void ReadGraySe(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(786);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenDiscSe(string type, int width, int height, HTuple smax)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(787);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.Store(proc, 3, smax);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(smax);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenDiscSe(string type, int width, int height, double smax)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(787);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.StoreD(proc, 3, smax);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void MeasureThresh(HMeasure measureHandle, double sigma, double threshold, string select, out HTuple rowThresh, out HTuple columnThresh, out HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(825);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, measureHandle);
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
			GC.KeepAlive(measureHandle);
		}

		public HTuple MeasureProjection(HMeasure measureHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(828);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, measureHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(measureHandle);
			return result;
		}

		public void FuzzyMeasurePairing(HMeasure measureHandle, double sigma, double ampThresh, double fuzzyThresh, string transition, string pairing, int numPairs, out HTuple rowEdgeFirst, out HTuple columnEdgeFirst, out HTuple amplitudeFirst, out HTuple rowEdgeSecond, out HTuple columnEdgeSecond, out HTuple amplitudeSecond, out HTuple rowPairCenter, out HTuple columnPairCenter, out HTuple fuzzyScore, out HTuple intraDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(832);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, measureHandle);
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
			GC.KeepAlive(measureHandle);
		}

		public void FuzzyMeasurePairs(HMeasure measureHandle, double sigma, double ampThresh, double fuzzyThresh, string transition, out HTuple rowEdgeFirst, out HTuple columnEdgeFirst, out HTuple amplitudeFirst, out HTuple rowEdgeSecond, out HTuple columnEdgeSecond, out HTuple amplitudeSecond, out HTuple rowEdgeCenter, out HTuple columnEdgeCenter, out HTuple fuzzyScore, out HTuple intraDistance, out HTuple interDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(833);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, measureHandle);
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
			GC.KeepAlive(measureHandle);
		}

		public void FuzzyMeasurePos(HMeasure measureHandle, double sigma, double ampThresh, double fuzzyThresh, string transition, out HTuple rowEdge, out HTuple columnEdge, out HTuple amplitude, out HTuple fuzzyScore, out HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(834);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, measureHandle);
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
			GC.KeepAlive(measureHandle);
		}

		public void MeasurePairs(HMeasure measureHandle, double sigma, double threshold, string transition, string select, out HTuple rowEdgeFirst, out HTuple columnEdgeFirst, out HTuple amplitudeFirst, out HTuple rowEdgeSecond, out HTuple columnEdgeSecond, out HTuple amplitudeSecond, out HTuple intraDistance, out HTuple interDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(835);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, measureHandle);
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
			GC.KeepAlive(measureHandle);
		}

		public void MeasurePos(HMeasure measureHandle, double sigma, double threshold, string transition, string select, out HTuple rowEdge, out HTuple columnEdge, out HTuple amplitude, out HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(836);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, measureHandle);
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
			GC.KeepAlive(measureHandle);
		}

		public HTuple ApplySampleIdentifier(HSampleIdentifier sampleIdentifier, int numResults, double ratingThreshold, HTuple genParamName, HTuple genParamValue, out HTuple rating)
		{
			IntPtr proc = SZXCArimAPI.PreCall(904);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sampleIdentifier);
			SZXCArimAPI.StoreI(proc, 1, numResults);
			SZXCArimAPI.StoreD(proc, 2, ratingThreshold);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out rating);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleIdentifier);
			return result;
		}

		public int ApplySampleIdentifier(HSampleIdentifier sampleIdentifier, int numResults, double ratingThreshold, HTuple genParamName, HTuple genParamValue, out double rating)
		{
			IntPtr proc = SZXCArimAPI.PreCall(904);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sampleIdentifier);
			SZXCArimAPI.StoreI(proc, 1, numResults);
			SZXCArimAPI.StoreD(proc, 2, ratingThreshold);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out rating);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleIdentifier);
			return result;
		}

		public int AddSampleIdentifierTrainingData(HSampleIdentifier sampleIdentifier, HTuple objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(912);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sampleIdentifier);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleIdentifier);
			return result;
		}

		public int AddSampleIdentifierTrainingData(HSampleIdentifier sampleIdentifier, int objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(912);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sampleIdentifier);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleIdentifier);
			return result;
		}

		public int AddSampleIdentifierPreparationData(HSampleIdentifier sampleIdentifier, HTuple objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(914);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sampleIdentifier);
			SZXCArimAPI.Store(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(objectIdx);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleIdentifier);
			return result;
		}

		public int AddSampleIdentifierPreparationData(HSampleIdentifier sampleIdentifier, int objectIdx, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(914);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sampleIdentifier);
			SZXCArimAPI.StoreI(proc, 1, objectIdx);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sampleIdentifier);
			return result;
		}

		public HTuple DetermineShapeModelParams(HTuple numLevels, double angleStart, double angleExtent, HTuple scaleMin, HTuple scaleMax, string optimization, string metric, HTuple contrast, HTuple minContrast, HTuple parameters, out HTuple parameterValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(923);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, scaleMin);
			SZXCArimAPI.Store(proc, 4, scaleMax);
			SZXCArimAPI.StoreS(proc, 5, optimization);
			SZXCArimAPI.StoreS(proc, 6, metric);
			SZXCArimAPI.Store(proc, 7, contrast);
			SZXCArimAPI.Store(proc, 8, minContrast);
			SZXCArimAPI.Store(proc, 9, parameters);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(scaleMin);
			SZXCArimAPI.UnpinTuple(scaleMax);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(parameters);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out parameterValue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DetermineShapeModelParams(int numLevels, double angleStart, double angleExtent, double scaleMin, double scaleMax, string optimization, string metric, int contrast, int minContrast, string parameters, out HTuple parameterValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(923);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleMin);
			SZXCArimAPI.StoreD(proc, 4, scaleMax);
			SZXCArimAPI.StoreS(proc, 5, optimization);
			SZXCArimAPI.StoreS(proc, 6, metric);
			SZXCArimAPI.StoreI(proc, 7, contrast);
			SZXCArimAPI.StoreI(proc, 8, minContrast);
			SZXCArimAPI.StoreS(proc, 9, parameters);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out parameterValue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void FindAnisoShapeModels(HShapeModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple scaleRMin, HTuple scaleRMax, HTuple scaleCMin, HTuple scaleCMax, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, HTuple greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr proc = SZXCArimAPI.PreCall(927);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, scaleRMin);
			SZXCArimAPI.Store(proc, 4, scaleRMax);
			SZXCArimAPI.Store(proc, 5, scaleCMin);
			SZXCArimAPI.Store(proc, 6, scaleCMax);
			SZXCArimAPI.Store(proc, 7, minScore);
			SZXCArimAPI.Store(proc, 8, numMatches);
			SZXCArimAPI.Store(proc, 9, maxOverlap);
			SZXCArimAPI.Store(proc, 10, subPixel);
			SZXCArimAPI.Store(proc, 11, numLevels);
			SZXCArimAPI.Store(proc, 12, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
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
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scaleR);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out scaleC);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelIDs);
		}

		public void FindAnisoShapeModels(HShapeModel modelIDs, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(927);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelIDs);
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
			GC.KeepAlive(modelIDs);
		}

		public void FindScaledShapeModels(HShapeModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple scaleMin, HTuple scaleMax, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, HTuple greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr proc = SZXCArimAPI.PreCall(928);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, scaleMin);
			SZXCArimAPI.Store(proc, 4, scaleMax);
			SZXCArimAPI.Store(proc, 5, minScore);
			SZXCArimAPI.Store(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 7, maxOverlap);
			SZXCArimAPI.Store(proc, 8, subPixel);
			SZXCArimAPI.Store(proc, 9, numLevels);
			SZXCArimAPI.Store(proc, 10, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
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
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out scale);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelIDs);
		}

		public void FindScaledShapeModels(HShapeModel modelIDs, double angleStart, double angleExtent, double scaleMin, double scaleMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(928);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelIDs);
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
			GC.KeepAlive(modelIDs);
		}

		public void FindShapeModels(HShapeModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, HTuple greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr proc = SZXCArimAPI.PreCall(929);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.Store(proc, 4, numMatches);
			SZXCArimAPI.Store(proc, 5, maxOverlap);
			SZXCArimAPI.Store(proc, 6, subPixel);
			SZXCArimAPI.Store(proc, 7, numLevels);
			SZXCArimAPI.Store(proc, 8, greediness);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(numMatches);
			SZXCArimAPI.UnpinTuple(maxOverlap);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(greediness);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelIDs);
		}

		public void FindShapeModels(HShapeModel modelIDs, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(929);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelIDs);
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
			GC.KeepAlive(modelIDs);
		}

		public void FindAnisoShapeModel(HShapeModel modelID, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, HTuple minScore, int numMatches, double maxOverlap, HTuple subPixel, HTuple numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(930);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public void FindAnisoShapeModel(HShapeModel modelID, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scaleR, out HTuple scaleC, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(930);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public void FindScaledShapeModel(HShapeModel modelID, double angleStart, double angleExtent, double scaleMin, double scaleMax, HTuple minScore, int numMatches, double maxOverlap, HTuple subPixel, HTuple numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(931);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public void FindScaledShapeModel(HShapeModel modelID, double angleStart, double angleExtent, double scaleMin, double scaleMax, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(931);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public void FindShapeModel(HShapeModel modelID, double angleStart, double angleExtent, HTuple minScore, int numMatches, double maxOverlap, HTuple subPixel, HTuple numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(932);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public void FindShapeModel(HShapeModel modelID, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, double greediness, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(932);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public void SetShapeModelMetric(HShapeModel modelID, HHomMat2D homMat2D, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(933);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, homMat2D);
			SZXCArimAPI.StoreS(proc, 2, metric);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
		}

		public static void SetShapeModelParam(HShapeModel modelID, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(934);
			SZXCArimAPI.Store(expr_0A, 0, modelID);
			SZXCArimAPI.Store(expr_0A, 1, genParamName);
			SZXCArimAPI.Store(expr_0A, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(modelID);
		}

		public HShapeModel CreateAnisoShapeModel(HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleRMin, double scaleRMax, HTuple scaleRStep, double scaleCMin, double scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(938);
			base.Store(proc, 1);
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
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateAnisoShapeModel(int numLevels, double angleStart, double angleExtent, double angleStep, double scaleRMin, double scaleRMax, double scaleRStep, double scaleCMin, double scaleCMax, double scaleCStep, string optimization, string metric, int contrast, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(938);
			base.Store(proc, 1);
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
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateScaledShapeModel(HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleMin, double scaleMax, HTuple scaleStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(939);
			base.Store(proc, 1);
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
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateScaledShapeModel(int numLevels, double angleStart, double angleExtent, double angleStep, double scaleMin, double scaleMax, double scaleStep, string optimization, string metric, int contrast, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(939);
			base.Store(proc, 1);
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
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateShapeModel(HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(940);
			base.Store(proc, 1);
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
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateShapeModel(int numLevels, double angleStart, double angleExtent, double angleStep, string optimization, string metric, int contrast, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(940);
			base.Store(proc, 1);
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
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage InspectShapeModel(out HRegion modelRegions, int numLevels, HTuple contrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(941);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.Store(proc, 1, contrast);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(contrast);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out modelRegions);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage InspectShapeModel(out HRegion modelRegions, int numLevels, int contrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(941);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreI(proc, 1, contrast);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out modelRegions);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] FindCalibDescriptorModel(HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, HTuple minScore, int numMatches, HCamPar camParam, HTuple scoreType, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(948);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.Store(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 7, camParam);
			SZXCArimAPI.Store(proc, 8, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(scoreType);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_E0_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
			return arg_E0_0;
		}

		public HPose FindCalibDescriptorModel(HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, double minScore, int numMatches, HCamPar camParam, string scoreType, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(948);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreD(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 7, camParam);
			SZXCArimAPI.StoreS(proc, 8, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			SZXCArimAPI.UnpinTuple(camParam);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
			return result;
		}

		public HHomMat2D[] FindUncalibDescriptorModel(HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, HTuple minScore, int numMatches, HTuple scoreType, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(949);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.Store(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 7, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(scoreType);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			HHomMat2D[] arg_C6_0 = HHomMat2D.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
			return arg_C6_0;
		}

		public HHomMat2D FindUncalibDescriptorModel(HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, double minScore, int numMatches, string scoreType, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(949);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreD(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.StoreS(proc, 7, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
			return result;
		}

		public HDescriptorModel CreateCalibDescriptorModel(HCamPar camParam, HPose referencePose, string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(952);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreS(proc, 2, detectorType);
			SZXCArimAPI.Store(proc, 3, detectorParamName);
			SZXCArimAPI.Store(proc, 4, detectorParamValue);
			SZXCArimAPI.Store(proc, 5, descriptorParamName);
			SZXCArimAPI.Store(proc, 6, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 7, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			HDescriptorModel result;
			num = HDescriptorModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDescriptorModel CreateUncalibDescriptorModel(string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(953);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, detectorType);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 5, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			HDescriptorModel result;
			num = HDescriptorModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DetermineDeformableModelParams(HTuple numLevels, double angleStart, double angleExtent, HTuple scaleMin, HTuple scaleMax, string optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue, HTuple parameters, out HTuple parameterValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(962);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, scaleMin);
			SZXCArimAPI.Store(proc, 4, scaleMax);
			SZXCArimAPI.StoreS(proc, 5, optimization);
			SZXCArimAPI.StoreS(proc, 6, metric);
			SZXCArimAPI.Store(proc, 7, contrast);
			SZXCArimAPI.Store(proc, 8, minContrast);
			SZXCArimAPI.Store(proc, 9, genParamName);
			SZXCArimAPI.Store(proc, 10, genParamValue);
			SZXCArimAPI.Store(proc, 11, parameters);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(scaleMin);
			SZXCArimAPI.UnpinTuple(scaleMax);
			SZXCArimAPI.UnpinTuple(contrast);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.UnpinTuple(parameters);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out parameterValue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DetermineDeformableModelParams(int numLevels, double angleStart, double angleExtent, double scaleMin, double scaleMax, string optimization, string metric, int contrast, int minContrast, HTuple genParamName, HTuple genParamValue, string parameters, out HTuple parameterValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(962);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, scaleMin);
			SZXCArimAPI.StoreD(proc, 4, scaleMax);
			SZXCArimAPI.StoreS(proc, 5, optimization);
			SZXCArimAPI.StoreS(proc, 6, metric);
			SZXCArimAPI.StoreI(proc, 7, contrast);
			SZXCArimAPI.StoreI(proc, 8, minContrast);
			SZXCArimAPI.Store(proc, 9, genParamName);
			SZXCArimAPI.Store(proc, 10, genParamValue);
			SZXCArimAPI.StoreS(proc, 11, parameters);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out parameterValue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage FindLocalDeformableModel(out HImage vectorField, out HXLDCont deformedContours, HDeformableModel modelID, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, int numLevels, double greediness, HTuple resultType, HTuple genParamName, HTuple genParamValue, out HTuple score, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(969);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
			return result;
		}

		public HPose[] FindPlanarCalibDeformableModel(HDeformableModel modelID, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, HTuple numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple covPose, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(970);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
			return arg_103_0;
		}

		public HPose FindPlanarCalibDeformableModel(HDeformableModel modelID, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, int numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple covPose, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(970);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
			return result;
		}

		public HHomMat2D[] FindPlanarUncalibDeformableModel(HDeformableModel modelID, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, HTuple numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(971);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
			return arg_EF_0;
		}

		public HHomMat2D FindPlanarUncalibDeformableModel(HDeformableModel modelID, double angleStart, double angleExtent, double scaleRMin, double scaleRMax, double scaleCMin, double scaleCMax, double minScore, int numMatches, double maxOverlap, int numLevels, double greediness, HTuple genParamName, HTuple genParamValue, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(971);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
			return result;
		}

		public void SetLocalDeformableModelMetric(HImage vectorField, HDeformableModel modelID, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(972);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, vectorField);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.StoreS(proc, 1, metric);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(vectorField);
			GC.KeepAlive(modelID);
		}

		public void SetPlanarCalibDeformableModelMetric(HDeformableModel modelID, HPose pose, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(973);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, pose);
			SZXCArimAPI.StoreS(proc, 2, metric);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
		}

		public void SetPlanarUncalibDeformableModelMetric(HDeformableModel modelID, HHomMat2D homMat2D, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(974);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, homMat2D);
			SZXCArimAPI.StoreS(proc, 2, metric);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(modelID);
		}

		public HDeformableModel CreateLocalDeformableModel(HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(978);
			base.Store(proc, 1);
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
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreateLocalDeformableModel(int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(978);
			base.Store(proc, 1);
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
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModel(HCamPar camParam, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			base.Store(proc, 1);
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
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModel(HCamPar camParam, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			base.Store(proc, 1);
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
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreatePlanarUncalibDeformableModel(HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(980);
			base.Store(proc, 1);
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
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreatePlanarUncalibDeformableModel(int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(980);
			base.Store(proc, 1);
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
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void FindNccModel(HNCCModel modelID, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, HTuple numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(991);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public void FindNccModel(HNCCModel modelID, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(991);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelID);
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
			GC.KeepAlive(modelID);
		}

		public static void SetNccModelParam(HNCCModel modelID, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(992);
			SZXCArimAPI.Store(expr_0A, 0, modelID);
			SZXCArimAPI.Store(expr_0A, 1, genParamName);
			SZXCArimAPI.Store(expr_0A, 2, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(modelID);
		}

		public HNCCModel CreateNccModel(HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(993);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, metric);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			HNCCModel result;
			num = HNCCModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HNCCModel CreateNccModel(int numLevels, double angleStart, double angleExtent, double angleStep, string metric)
		{
			IntPtr proc = SZXCArimAPI.PreCall(993);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, metric);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HNCCModel result;
			num = HNCCModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple FindComponentModel(HComponentModel componentModelID, HTuple rootComponent, HTuple angleStartRoot, HTuple angleExtentRoot, double minScore, int numMatches, double maxOverlap, string ifRootNotFound, string ifComponentNotFound, string posePrediction, HTuple minScoreComp, HTuple subPixelComp, HTuple numLevelsComp, HTuple greedinessComp, out HTuple modelEnd, out HTuple score, out HTuple rowComp, out HTuple columnComp, out HTuple angleComp, out HTuple scoreComp, out HTuple modelComp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(995);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, componentModelID);
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
			GC.KeepAlive(componentModelID);
			return result;
		}

		public int FindComponentModel(HComponentModel componentModelID, int rootComponent, double angleStartRoot, double angleExtentRoot, double minScore, int numMatches, double maxOverlap, string ifRootNotFound, string ifComponentNotFound, string posePrediction, double minScoreComp, string subPixelComp, int numLevelsComp, double greedinessComp, out int modelEnd, out double score, out double rowComp, out double columnComp, out double angleComp, out double scoreComp, out int modelComp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(995);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, componentModelID);
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
			GC.KeepAlive(componentModelID);
			return result;
		}

		public HComponentModel CreateComponentModel(HRegion componentRegions, HTuple variationRow, HTuple variationColumn, HTuple variationAngle, double angleStart, double angleExtent, HTuple contrastLowComp, HTuple contrastHighComp, HTuple minSizeComp, HTuple minContrastComp, HTuple minScoreComp, HTuple numLevelsComp, HTuple angleStepComp, string optimizationComp, HTuple metricComp, HTuple pregenerationComp, out HTuple rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1004);
			base.Store(proc, 1);
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
			HComponentModel result;
			num = HComponentModel.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(componentRegions);
			return result;
		}

		public HComponentModel CreateComponentModel(HRegion componentRegions, int variationRow, int variationColumn, double variationAngle, double angleStart, double angleExtent, int contrastLowComp, int contrastHighComp, int minSizeComp, int minContrastComp, double minScoreComp, int numLevelsComp, double angleStepComp, string optimizationComp, string metricComp, string pregenerationComp, out int rootRanking)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1004);
			base.Store(proc, 1);
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
			HComponentModel result;
			num = HComponentModel.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out rootRanking);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(componentRegions);
			return result;
		}

		public HRegion ClusterModelComponents(HComponentTraining componentTrainingID, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1015);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, componentTrainingID);
			SZXCArimAPI.StoreS(proc, 1, ambiguityCriterion);
			SZXCArimAPI.StoreD(proc, 2, maxContourOverlap);
			SZXCArimAPI.StoreD(proc, 3, clusterThreshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(componentTrainingID);
			return result;
		}

		public HRegion TrainModelComponents(HRegion initialComponents, HImage trainingImages, HTuple contrastLow, HTuple contrastHigh, HTuple minSize, HTuple minScore, HTuple searchRowTol, HTuple searchColumnTol, HTuple searchAngleTol, string trainingEmphasis, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold, out HComponentTraining componentTrainingID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1017);
			base.Store(proc, 1);
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
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(contrastLow);
			SZXCArimAPI.UnpinTuple(contrastHigh);
			SZXCArimAPI.UnpinTuple(minSize);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(searchRowTol);
			SZXCArimAPI.UnpinTuple(searchColumnTol);
			SZXCArimAPI.UnpinTuple(searchAngleTol);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HComponentTraining.LoadNew(proc, 0, num, out componentTrainingID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(initialComponents);
			GC.KeepAlive(trainingImages);
			return result;
		}

		public HRegion TrainModelComponents(HRegion initialComponents, HImage trainingImages, int contrastLow, int contrastHigh, int minSize, double minScore, int searchRowTol, int searchColumnTol, double searchAngleTol, string trainingEmphasis, string ambiguityCriterion, double maxContourOverlap, double clusterThreshold, out HComponentTraining componentTrainingID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1017);
			base.Store(proc, 1);
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
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HComponentTraining.LoadNew(proc, 0, num, out componentTrainingID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(initialComponents);
			GC.KeepAlive(trainingImages);
			return result;
		}

		public HRegion GenInitialComponents(HTuple contrastLow, HTuple contrastHigh, HTuple minSize, string mode, HTuple genericName, HTuple genericValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1018);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, contrastLow);
			SZXCArimAPI.Store(proc, 1, contrastHigh);
			SZXCArimAPI.Store(proc, 2, minSize);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.Store(proc, 4, genericName);
			SZXCArimAPI.Store(proc, 5, genericValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(contrastLow);
			SZXCArimAPI.UnpinTuple(contrastHigh);
			SZXCArimAPI.UnpinTuple(minSize);
			SZXCArimAPI.UnpinTuple(genericName);
			SZXCArimAPI.UnpinTuple(genericValue);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GenInitialComponents(int contrastLow, int contrastHigh, int minSize, string mode, string genericName, double genericValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1018);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, contrastLow);
			SZXCArimAPI.StoreI(proc, 1, contrastHigh);
			SZXCArimAPI.StoreI(proc, 2, minSize);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.StoreS(proc, 4, genericName);
			SZXCArimAPI.StoreD(proc, 5, genericValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] FindShapeModel3d(HShapeModel3D shapeModel3DID, double minScore, double greediness, HTuple numLevels, HTuple genParamName, HTuple genParamValue, out HTuple covPose, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1058);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, shapeModel3DID);
			SZXCArimAPI.StoreD(proc, 1, minScore);
			SZXCArimAPI.StoreD(proc, 2, greediness);
			SZXCArimAPI.Store(proc, 3, numLevels);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
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
			HPose[] arg_B6_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(shapeModel3DID);
			return arg_B6_0;
		}

		public HImage ChannelsToImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1119);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ImageToChannels()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1120);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Compose7(HImage image2, HImage image3, HImage image4, HImage image5, HImage image6, HImage image7)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 3, image3);
			SZXCArimAPI.Store(proc, 4, image4);
			SZXCArimAPI.Store(proc, 5, image5);
			SZXCArimAPI.Store(proc, 6, image6);
			SZXCArimAPI.Store(proc, 7, image7);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			GC.KeepAlive(image3);
			GC.KeepAlive(image4);
			GC.KeepAlive(image5);
			GC.KeepAlive(image6);
			GC.KeepAlive(image7);
			return result;
		}

		public HImage Compose6(HImage image2, HImage image3, HImage image4, HImage image5, HImage image6)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1122);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 3, image3);
			SZXCArimAPI.Store(proc, 4, image4);
			SZXCArimAPI.Store(proc, 5, image5);
			SZXCArimAPI.Store(proc, 6, image6);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			GC.KeepAlive(image3);
			GC.KeepAlive(image4);
			GC.KeepAlive(image5);
			GC.KeepAlive(image6);
			return result;
		}

		public HImage Compose5(HImage image2, HImage image3, HImage image4, HImage image5)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1123);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 3, image3);
			SZXCArimAPI.Store(proc, 4, image4);
			SZXCArimAPI.Store(proc, 5, image5);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			GC.KeepAlive(image3);
			GC.KeepAlive(image4);
			GC.KeepAlive(image5);
			return result;
		}

		public HImage Compose4(HImage image2, HImage image3, HImage image4)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 3, image3);
			SZXCArimAPI.Store(proc, 4, image4);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			GC.KeepAlive(image3);
			GC.KeepAlive(image4);
			return result;
		}

		public HImage Compose3(HImage image2, HImage image3)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 3, image3);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			GC.KeepAlive(image3);
			return result;
		}

		public HImage Compose2(HImage image2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1126);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage Decompose7(out HImage image2, out HImage image3, out HImage image4, out HImage image5, out HImage image6, out HImage image7)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1127);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out image2);
			num = HImage.LoadNew(proc, 3, num, out image3);
			num = HImage.LoadNew(proc, 4, num, out image4);
			num = HImage.LoadNew(proc, 5, num, out image5);
			num = HImage.LoadNew(proc, 6, num, out image6);
			num = HImage.LoadNew(proc, 7, num, out image7);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Decompose6(out HImage image2, out HImage image3, out HImage image4, out HImage image5, out HImage image6)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1128);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out image2);
			num = HImage.LoadNew(proc, 3, num, out image3);
			num = HImage.LoadNew(proc, 4, num, out image4);
			num = HImage.LoadNew(proc, 5, num, out image5);
			num = HImage.LoadNew(proc, 6, num, out image6);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Decompose5(out HImage image2, out HImage image3, out HImage image4, out HImage image5)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1129);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out image2);
			num = HImage.LoadNew(proc, 3, num, out image3);
			num = HImage.LoadNew(proc, 4, num, out image4);
			num = HImage.LoadNew(proc, 5, num, out image5);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Decompose4(out HImage image2, out HImage image3, out HImage image4)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1130);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out image2);
			num = HImage.LoadNew(proc, 3, num, out image3);
			num = HImage.LoadNew(proc, 4, num, out image4);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Decompose3(out HImage image2, out HImage image3)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1131);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out image2);
			num = HImage.LoadNew(proc, 3, num, out image3);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Decompose2(out HImage image2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1132);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out image2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple CountChannels()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1133);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AppendChannel(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1134);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage AccessChannel(int channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1135);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, channel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage TileImagesOffset(HTuple offsetRow, HTuple offsetCol, HTuple row1, HTuple col1, HTuple row2, HTuple col2, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1136);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, offsetRow);
			SZXCArimAPI.Store(proc, 1, offsetCol);
			SZXCArimAPI.Store(proc, 2, row1);
			SZXCArimAPI.Store(proc, 3, col1);
			SZXCArimAPI.Store(proc, 4, row2);
			SZXCArimAPI.Store(proc, 5, col2);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(offsetRow);
			SZXCArimAPI.UnpinTuple(offsetCol);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(col1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(col2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage TileImagesOffset(int offsetRow, int offsetCol, int row1, int col1, int row2, int col2, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1136);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, offsetRow);
			SZXCArimAPI.StoreI(proc, 1, offsetCol);
			SZXCArimAPI.StoreI(proc, 2, row1);
			SZXCArimAPI.StoreI(proc, 3, col1);
			SZXCArimAPI.StoreI(proc, 4, row2);
			SZXCArimAPI.StoreI(proc, 5, col2);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage TileImages(int numColumns, string tileOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1137);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numColumns);
			SZXCArimAPI.StoreS(proc, 1, tileOrder);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage TileChannels(int numColumns, string tileOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1138);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numColumns);
			SZXCArimAPI.StoreS(proc, 1, tileOrder);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage CropDomain()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1139);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage CropRectangle1(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1140);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row1);
			SZXCArimAPI.Store(proc, 1, column1);
			SZXCArimAPI.Store(proc, 2, row2);
			SZXCArimAPI.Store(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage CropRectangle1(int row1, int column1, int row2, int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1140);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row1);
			SZXCArimAPI.StoreI(proc, 1, column1);
			SZXCArimAPI.StoreI(proc, 2, row2);
			SZXCArimAPI.StoreI(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage CropPart(HTuple row, HTuple column, HTuple width, HTuple height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1141);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, width);
			SZXCArimAPI.Store(proc, 3, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(width);
			SZXCArimAPI.UnpinTuple(height);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage CropPart(int row, int column, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1141);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ChangeFormat(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1142);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ChangeDomain(HRegion newDomain)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1143);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, newDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(newDomain);
			return result;
		}

		public HImage Rectangle1Domain(int row1, int column1, int row2, int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1145);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row1);
			SZXCArimAPI.StoreI(proc, 1, column1);
			SZXCArimAPI.StoreI(proc, 2, row2);
			SZXCArimAPI.StoreI(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ReduceDomain(HRegion region)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1146);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage FullDomain()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1147);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GetDomain()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1148);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage HoughLinesDir(out HRegion lines, int directionUncertainty, int angleResolution, string smoothing, int filterSize, int threshold, int angleGap, int distGap, string genLines, out HTuple angle, out HTuple dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1151);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, directionUncertainty);
			SZXCArimAPI.StoreI(proc, 1, angleResolution);
			SZXCArimAPI.StoreS(proc, 2, smoothing);
			SZXCArimAPI.StoreI(proc, 3, filterSize);
			SZXCArimAPI.StoreI(proc, 4, threshold);
			SZXCArimAPI.StoreI(proc, 5, angleGap);
			SZXCArimAPI.StoreI(proc, 6, distGap);
			SZXCArimAPI.StoreS(proc, 7, genLines);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out lines);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out dist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage HoughLineTransDir(int directionUncertainty, int angleResolution)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1152);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, directionUncertainty);
			SZXCArimAPI.StoreI(proc, 1, angleResolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion FindRectificationGrid(HTuple minContrast, HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1156);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, minContrast);
			SZXCArimAPI.Store(proc, 1, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minContrast);
			SZXCArimAPI.UnpinTuple(radius);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion FindRectificationGrid(double minContrast, double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1156);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, minContrast);
			SZXCArimAPI.StoreD(proc, 1, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD ConnectGridPoints(HTuple row, HTuple column, HTuple sigma, HTuple maxDist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1158);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, sigma);
			SZXCArimAPI.Store(proc, 3, maxDist);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(sigma);
			SZXCArimAPI.UnpinTuple(maxDist);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLD ConnectGridPoints(HTuple row, HTuple column, int sigma, double maxDist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1158);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, sigma);
			SZXCArimAPI.StoreD(proc, 3, maxDist);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HXLD result;
			num = HXLD.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenGridRectificationMap(HXLD connectingLines, out HXLD meshes, int gridSpacing, HTuple rotation, HTuple row, HTuple column, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1159);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, connectingLines);
			SZXCArimAPI.StoreI(proc, 0, gridSpacing);
			SZXCArimAPI.Store(proc, 1, rotation);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.StoreS(proc, 4, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rotation);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLD.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(connectingLines);
			return result;
		}

		public HImage GenGridRectificationMap(HXLD connectingLines, out HXLD meshes, int gridSpacing, string rotation, HTuple row, HTuple column, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1159);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, connectingLines);
			SZXCArimAPI.StoreI(proc, 0, gridSpacing);
			SZXCArimAPI.StoreS(proc, 1, rotation);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.StoreS(proc, 4, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLD.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(connectingLines);
			return result;
		}

		public void UnprojectCoordinates(HWindow windowHandle, HTuple row, HTuple column, out int imageRow, out int imageColumn, out HTuple height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1168);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 1, row);
			SZXCArimAPI.Store(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			num = SZXCArimAPI.LoadI(proc, 0, num, out imageRow);
			num = SZXCArimAPI.LoadI(proc, 1, num, out imageColumn);
			num = HTuple.LoadNew(proc, 2, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void UnprojectCoordinates(HWindow windowHandle, double row, double column, out int imageRow, out int imageColumn, out int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1168);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out imageRow);
			num = SZXCArimAPI.LoadI(proc, 1, num, out imageColumn);
			num = SZXCArimAPI.LoadI(proc, 2, num, out height);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DumpWindowImage(HWindow windowHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1184);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DispImage(HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1268);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DispChannel(HWindow windowHandle, HTuple channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1269);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 1, channel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(channel);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DispChannel(HWindow windowHandle, int channel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1269);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreI(proc, 1, channel);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DispColor(HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1270);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void GnuplotPlotImage(HGnuplot gnuplotFileID, int samplesX, int samplesY, HTuple viewRotX, HTuple viewRotZ, string hidden3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1297);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, gnuplotFileID);
			SZXCArimAPI.StoreI(proc, 1, samplesX);
			SZXCArimAPI.StoreI(proc, 2, samplesY);
			SZXCArimAPI.Store(proc, 3, viewRotX);
			SZXCArimAPI.Store(proc, 4, viewRotZ);
			SZXCArimAPI.StoreS(proc, 5, hidden3D);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(viewRotX);
			SZXCArimAPI.UnpinTuple(viewRotZ);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(gnuplotFileID);
		}

		public void GnuplotPlotImage(HGnuplot gnuplotFileID, int samplesX, int samplesY, double viewRotX, double viewRotZ, string hidden3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1297);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, gnuplotFileID);
			SZXCArimAPI.StoreI(proc, 1, samplesX);
			SZXCArimAPI.StoreI(proc, 2, samplesY);
			SZXCArimAPI.StoreD(proc, 3, viewRotX);
			SZXCArimAPI.StoreD(proc, 4, viewRotZ);
			SZXCArimAPI.StoreS(proc, 5, hidden3D);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(gnuplotFileID);
		}

		public HImage TextureLaws(string filterTypes, int shift, int filterSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1402);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterTypes);
			SZXCArimAPI.StoreI(proc, 1, shift);
			SZXCArimAPI.StoreI(proc, 2, filterSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DeviationImage(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1403);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EntropyImage(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1404);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage IsotropicDiffusion(double sigma, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1405);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AnisotropicDiffusion(string mode, double contrast, double theta, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1406);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, contrast);
			SZXCArimAPI.StoreD(proc, 2, theta);
			SZXCArimAPI.StoreI(proc, 3, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SmoothImage(string filter, double alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1407);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SigmaImage(int maskHeight, int maskWidth, int sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1408);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskHeight);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.StoreI(proc, 2, sigma);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MidrangeImage(HRegion mask, HTuple margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1409);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, mask);
			SZXCArimAPI.Store(proc, 0, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(margin);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(mask);
			return result;
		}

		public HImage MidrangeImage(HRegion mask, string margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1409);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, mask);
			SZXCArimAPI.StoreS(proc, 0, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(mask);
			return result;
		}

		public HImage TrimmedMean(HRegion mask, int number, HTuple margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1410);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, mask);
			SZXCArimAPI.StoreI(proc, 0, number);
			SZXCArimAPI.Store(proc, 1, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(margin);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(mask);
			return result;
		}

		public HImage TrimmedMean(HRegion mask, int number, string margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1410);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, mask);
			SZXCArimAPI.StoreI(proc, 0, number);
			SZXCArimAPI.StoreS(proc, 1, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(mask);
			return result;
		}

		public HImage MedianSeparate(int maskWidth, int maskHeight, HTuple margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1411);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.Store(proc, 2, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(margin);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MedianSeparate(int maskWidth, int maskHeight, string margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1411);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreS(proc, 2, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MedianRect(int maskWidth, int maskHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1412);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MedianImage(string maskType, int radius, HTuple margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1413);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, maskType);
			SZXCArimAPI.StoreI(proc, 1, radius);
			SZXCArimAPI.Store(proc, 2, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(margin);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MedianImage(string maskType, int radius, string margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1413);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, maskType);
			SZXCArimAPI.StoreI(proc, 1, radius);
			SZXCArimAPI.StoreS(proc, 2, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MedianWeighted(string maskType, int maskSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1414);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, maskType);
			SZXCArimAPI.StoreI(proc, 1, maskSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RankRect(int maskWidth, int maskHeight, int rank)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1415);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreI(proc, 2, rank);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RankImage(HRegion mask, int rank, HTuple margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1416);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, mask);
			SZXCArimAPI.StoreI(proc, 0, rank);
			SZXCArimAPI.Store(proc, 1, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(margin);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(mask);
			return result;
		}

		public HImage RankImage(HRegion mask, int rank, string margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1416);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, mask);
			SZXCArimAPI.StoreI(proc, 0, rank);
			SZXCArimAPI.StoreS(proc, 1, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(mask);
			return result;
		}

		public HImage DualRank(string maskType, int radius, int modePercent, HTuple margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1417);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, maskType);
			SZXCArimAPI.StoreI(proc, 1, radius);
			SZXCArimAPI.StoreI(proc, 2, modePercent);
			SZXCArimAPI.Store(proc, 3, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(margin);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DualRank(string maskType, int radius, int modePercent, string margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1417);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, maskType);
			SZXCArimAPI.StoreI(proc, 1, radius);
			SZXCArimAPI.StoreI(proc, 2, modePercent);
			SZXCArimAPI.StoreS(proc, 3, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MeanImage(int maskWidth, int maskHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1418);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BinomialFilter(int maskWidth, int maskHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1420);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GaussImage(int size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1421);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, size);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GaussFilter(int size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1422);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, size);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EliminateMinMax(int maskWidth, int maskHeight, double gap, int mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1423);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreD(proc, 2, gap);
			SZXCArimAPI.StoreI(proc, 3, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage FillInterlace(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1424);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RankN(int rankIndex)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1425);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, rankIndex);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MeanN()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1426);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EliminateSp(int maskWidth, int maskHeight, int minThresh, int maxThresh)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1427);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreI(proc, 2, minThresh);
			SZXCArimAPI.StoreI(proc, 3, maxThresh);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MeanSp(int maskWidth, int maskHeight, int minThresh, int maxThresh)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1428);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreI(proc, 2, minThresh);
			SZXCArimAPI.StoreI(proc, 3, maxThresh);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void PointsSojka(int maskSize, HTuple sigmaW, HTuple sigmaD, HTuple minGrad, HTuple minApparentness, double minAngle, string subpix, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1429);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskSize);
			SZXCArimAPI.Store(proc, 1, sigmaW);
			SZXCArimAPI.Store(proc, 2, sigmaD);
			SZXCArimAPI.Store(proc, 3, minGrad);
			SZXCArimAPI.Store(proc, 4, minApparentness);
			SZXCArimAPI.StoreD(proc, 5, minAngle);
			SZXCArimAPI.StoreS(proc, 6, subpix);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sigmaW);
			SZXCArimAPI.UnpinTuple(sigmaD);
			SZXCArimAPI.UnpinTuple(minGrad);
			SZXCArimAPI.UnpinTuple(minApparentness);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsSojka(int maskSize, double sigmaW, double sigmaD, double minGrad, double minApparentness, double minAngle, string subpix, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1429);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskSize);
			SZXCArimAPI.StoreD(proc, 1, sigmaW);
			SZXCArimAPI.StoreD(proc, 2, sigmaD);
			SZXCArimAPI.StoreD(proc, 3, minGrad);
			SZXCArimAPI.StoreD(proc, 4, minApparentness);
			SZXCArimAPI.StoreD(proc, 5, minAngle);
			SZXCArimAPI.StoreS(proc, 6, subpix);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage DotsImage(int diameter, string filterType, int pixelShift)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1430);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, diameter);
			SZXCArimAPI.StoreS(proc, 1, filterType);
			SZXCArimAPI.StoreI(proc, 2, pixelShift);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void LocalMinSubPix(string filter, double sigma, double threshold, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1431);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void LocalMaxSubPix(string filter, double sigma, double threshold, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1432);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SaddlePointsSubPix(string filter, double sigma, double threshold, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1433);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CriticalPointsSubPix(string filter, double sigma, double threshold, out HTuple rowMin, out HTuple columnMin, out HTuple rowMax, out HTuple columnMax, out HTuple rowSaddle, out HTuple columnSaddle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1434);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowMin);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnMin);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out rowMax);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out columnMax);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out rowSaddle);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out columnSaddle);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsHarris(double sigmaGrad, double sigmaSmooth, double alpha, HTuple threshold, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1435);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigmaGrad);
			SZXCArimAPI.StoreD(proc, 1, sigmaSmooth);
			SZXCArimAPI.StoreD(proc, 2, alpha);
			SZXCArimAPI.Store(proc, 3, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(threshold);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsHarris(double sigmaGrad, double sigmaSmooth, double alpha, double threshold, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1435);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigmaGrad);
			SZXCArimAPI.StoreD(proc, 1, sigmaSmooth);
			SZXCArimAPI.StoreD(proc, 2, alpha);
			SZXCArimAPI.StoreD(proc, 3, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsHarrisBinomial(int maskSizeGrad, int maskSizeSmooth, double alpha, HTuple threshold, string subpix, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1436);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskSizeGrad);
			SZXCArimAPI.StoreI(proc, 1, maskSizeSmooth);
			SZXCArimAPI.StoreD(proc, 2, alpha);
			SZXCArimAPI.Store(proc, 3, threshold);
			SZXCArimAPI.StoreS(proc, 4, subpix);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(threshold);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsHarrisBinomial(int maskSizeGrad, int maskSizeSmooth, double alpha, double threshold, string subpix, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1436);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskSizeGrad);
			SZXCArimAPI.StoreI(proc, 1, maskSizeSmooth);
			SZXCArimAPI.StoreD(proc, 2, alpha);
			SZXCArimAPI.StoreD(proc, 3, threshold);
			SZXCArimAPI.StoreS(proc, 4, subpix);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsLepetit(int radius, int checkNeighbor, int minCheckNeighborDiff, int minScore, string subpix, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1437);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, radius);
			SZXCArimAPI.StoreI(proc, 1, checkNeighbor);
			SZXCArimAPI.StoreI(proc, 2, minCheckNeighborDiff);
			SZXCArimAPI.StoreI(proc, 3, minScore);
			SZXCArimAPI.StoreS(proc, 4, subpix);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, num, out row);
			num = HTuple.LoadNew(proc, 1, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsFoerstner(HTuple sigmaGrad, HTuple sigmaInt, HTuple sigmaPoints, HTuple threshInhom, double threshShape, string smoothing, string eliminateDoublets, out HTuple rowJunctions, out HTuple columnJunctions, out HTuple coRRJunctions, out HTuple coRCJunctions, out HTuple coCCJunctions, out HTuple rowArea, out HTuple columnArea, out HTuple coRRArea, out HTuple coRCArea, out HTuple coCCArea)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1438);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sigmaGrad);
			SZXCArimAPI.Store(proc, 1, sigmaInt);
			SZXCArimAPI.Store(proc, 2, sigmaPoints);
			SZXCArimAPI.Store(proc, 3, threshInhom);
			SZXCArimAPI.StoreD(proc, 4, threshShape);
			SZXCArimAPI.StoreS(proc, 5, smoothing);
			SZXCArimAPI.StoreS(proc, 6, eliminateDoublets);
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
			SZXCArimAPI.UnpinTuple(sigmaGrad);
			SZXCArimAPI.UnpinTuple(sigmaInt);
			SZXCArimAPI.UnpinTuple(sigmaPoints);
			SZXCArimAPI.UnpinTuple(threshInhom);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowJunctions);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnJunctions);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out coRRJunctions);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out coRCJunctions);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out coCCJunctions);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out rowArea);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out columnArea);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out coRRArea);
			num = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, num, out coRCArea);
			num = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, num, out coCCArea);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void PointsFoerstner(double sigmaGrad, double sigmaInt, double sigmaPoints, double threshInhom, double threshShape, string smoothing, string eliminateDoublets, out HTuple rowJunctions, out HTuple columnJunctions, out HTuple coRRJunctions, out HTuple coRCJunctions, out HTuple coCCJunctions, out HTuple rowArea, out HTuple columnArea, out HTuple coRRArea, out HTuple coRCArea, out HTuple coCCArea)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1438);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigmaGrad);
			SZXCArimAPI.StoreD(proc, 1, sigmaInt);
			SZXCArimAPI.StoreD(proc, 2, sigmaPoints);
			SZXCArimAPI.StoreD(proc, 3, threshInhom);
			SZXCArimAPI.StoreD(proc, 4, threshShape);
			SZXCArimAPI.StoreS(proc, 5, smoothing);
			SZXCArimAPI.StoreS(proc, 6, eliminateDoublets);
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
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowJunctions);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out columnJunctions);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out coRRJunctions);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out coRCJunctions);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out coCCJunctions);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out rowArea);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out columnArea);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out coRRArea);
			num = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, num, out coRCArea);
			num = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, num, out coCCArea);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple EstimateNoise(string method, HTuple percent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1439);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.Store(proc, 1, percent);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(percent);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double EstimateNoise(string method, double percent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1439);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreD(proc, 1, percent);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple NoiseDistributionMean(HRegion constRegion, int filterSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1440);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, constRegion);
			SZXCArimAPI.StoreI(proc, 0, filterSize);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(constRegion);
			return result;
		}

		public HImage AddNoiseWhite(double amp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1441);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, amp);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AddNoiseDistribution(HTuple distribution)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1442);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, distribution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(distribution);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DeviationN()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1445);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage InpaintingTexture(HRegion region, int maskSize, int searchSize, double anisotropy, string postIteration, double smoothness)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1446);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreI(proc, 0, maskSize);
			SZXCArimAPI.StoreI(proc, 1, searchSize);
			SZXCArimAPI.StoreD(proc, 2, anisotropy);
			SZXCArimAPI.StoreS(proc, 3, postIteration);
			SZXCArimAPI.StoreD(proc, 4, smoothness);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage InpaintingCt(HRegion region, double epsilon, double kappa, double sigma, double rho, HTuple channelCoefficients)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1447);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreD(proc, 0, epsilon);
			SZXCArimAPI.StoreD(proc, 1, kappa);
			SZXCArimAPI.StoreD(proc, 2, sigma);
			SZXCArimAPI.StoreD(proc, 3, rho);
			SZXCArimAPI.Store(proc, 4, channelCoefficients);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(channelCoefficients);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage InpaintingCt(HRegion region, double epsilon, double kappa, double sigma, double rho, double channelCoefficients)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1447);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreD(proc, 0, epsilon);
			SZXCArimAPI.StoreD(proc, 1, kappa);
			SZXCArimAPI.StoreD(proc, 2, sigma);
			SZXCArimAPI.StoreD(proc, 3, rho);
			SZXCArimAPI.StoreD(proc, 4, channelCoefficients);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage InpaintingMcf(HRegion region, double sigma, double theta, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1448);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, theta);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage InpaintingCed(HRegion region, double sigma, double rho, double theta, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1449);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, rho);
			SZXCArimAPI.StoreD(proc, 2, theta);
			SZXCArimAPI.StoreI(proc, 3, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage InpaintingAniso(HRegion region, string mode, double contrast, double theta, int iterations, double rho)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1450);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, contrast);
			SZXCArimAPI.StoreD(proc, 2, theta);
			SZXCArimAPI.StoreI(proc, 3, iterations);
			SZXCArimAPI.StoreD(proc, 4, rho);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage HarmonicInterpolation(HRegion region, double precision)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1451);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.StoreD(proc, 0, precision);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HImage ExpandDomainGray(int expansionRange)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1452);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, expansionRange);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage TopographicSketch()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1453);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage LinearTransColor(HTuple transMat)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1454);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, transMat);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(transMat);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GenPrincipalCompTrans(out HTuple transInv, out HTuple mean, out HTuple cov, out HTuple infoPerComp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1455);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out transInv);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out mean);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out cov);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out infoPerComp);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PrincipalComp(out HTuple infoPerComp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1456);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out infoPerComp);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple FuzzyEntropy(HRegion regions, int apar, int cpar)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1457);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreI(proc, 0, apar);
			SZXCArimAPI.StoreI(proc, 1, cpar);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple FuzzyPerimeter(HRegion regions, int apar, int cpar)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1458);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreI(proc, 0, apar);
			SZXCArimAPI.StoreI(proc, 1, cpar);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HImage GrayClosingShape(HTuple maskHeight, HTuple maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1459);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, maskHeight);
			SZXCArimAPI.Store(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maskHeight);
			SZXCArimAPI.UnpinTuple(maskWidth);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayClosingShape(double maskHeight, double maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1459);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maskHeight);
			SZXCArimAPI.StoreD(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayOpeningShape(HTuple maskHeight, HTuple maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1460);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, maskHeight);
			SZXCArimAPI.Store(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maskHeight);
			SZXCArimAPI.UnpinTuple(maskWidth);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayOpeningShape(double maskHeight, double maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1460);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maskHeight);
			SZXCArimAPI.StoreD(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayErosionShape(HTuple maskHeight, HTuple maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1461);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, maskHeight);
			SZXCArimAPI.Store(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maskHeight);
			SZXCArimAPI.UnpinTuple(maskWidth);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayErosionShape(double maskHeight, double maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1461);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maskHeight);
			SZXCArimAPI.StoreD(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayDilationShape(HTuple maskHeight, HTuple maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1462);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, maskHeight);
			SZXCArimAPI.Store(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maskHeight);
			SZXCArimAPI.UnpinTuple(maskWidth);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayDilationShape(double maskHeight, double maskWidth, string maskShape)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1462);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maskHeight);
			SZXCArimAPI.StoreD(proc, 1, maskWidth);
			SZXCArimAPI.StoreS(proc, 2, maskShape);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayRangeRect(int maskHeight, int maskWidth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1463);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskHeight);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayClosingRect(int maskHeight, int maskWidth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1464);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskHeight);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayOpeningRect(int maskHeight, int maskWidth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1465);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskHeight);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayErosionRect(int maskHeight, int maskWidth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1466);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskHeight);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GrayDilationRect(int maskHeight, int maskWidth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1467);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskHeight);
			SZXCArimAPI.StoreI(proc, 1, maskWidth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GraySkeleton()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1468);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage LutTrans(HTuple lut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1469);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, lut);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(lut);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ConvolImage(HTuple filterMask, HTuple margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1470);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, filterMask);
			SZXCArimAPI.Store(proc, 1, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(filterMask);
			SZXCArimAPI.UnpinTuple(margin);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ConvolImage(string filterMask, string margin)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1470);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterMask);
			SZXCArimAPI.StoreS(proc, 1, margin);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ConvertImageType(string newType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1471);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, newType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RealToVectorField(HImage col, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1472);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, col);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(col);
			return result;
		}

		public HImage VectorFieldToReal(out HImage col)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1473);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out col);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RealToComplex(HImage imageImaginary)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1474);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageImaginary);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageImaginary);
			return result;
		}

		public HImage ComplexToReal(out HImage imageImaginary)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1475);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageImaginary);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RegionToMean(HRegion regions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1476);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HImage GrayInside()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1477);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Symmetry(int maskSize, double direction, double exponent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1478);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskSize);
			SZXCArimAPI.StoreD(proc, 1, direction);
			SZXCArimAPI.StoreD(proc, 2, exponent);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SelectGrayvaluesFromChannels(HImage indexImage)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1479);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, indexImage);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(indexImage);
			return result;
		}

		public HImage DepthFromFocus(out HImage confidence, HTuple filter, HTuple selection)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1480);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, filter);
			SZXCArimAPI.Store(proc, 1, selection);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(filter);
			SZXCArimAPI.UnpinTuple(selection);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DepthFromFocus(out HImage confidence, string filter, string selection)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1480);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreS(proc, 1, selection);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SceneFlowUncalib(HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, out HImage disparityChange, HTuple smoothingFlow, HTuple smoothingDisparity, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1482);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2T1);
			SZXCArimAPI.Store(proc, 3, imageRect1T2);
			SZXCArimAPI.Store(proc, 4, imageRect2T2);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.Store(proc, 0, smoothingFlow);
			SZXCArimAPI.Store(proc, 1, smoothingDisparity);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(smoothingFlow);
			SZXCArimAPI.UnpinTuple(smoothingDisparity);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out disparityChange);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2T1);
			GC.KeepAlive(imageRect1T2);
			GC.KeepAlive(imageRect2T2);
			GC.KeepAlive(disparity);
			return result;
		}

		public HImage SceneFlowUncalib(HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, out HImage disparityChange, double smoothingFlow, double smoothingDisparity, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1482);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageRect2T1);
			SZXCArimAPI.Store(proc, 3, imageRect1T2);
			SZXCArimAPI.Store(proc, 4, imageRect2T2);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.StoreD(proc, 0, smoothingFlow);
			SZXCArimAPI.StoreD(proc, 1, smoothingDisparity);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out disparityChange);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect2T1);
			GC.KeepAlive(imageRect1T2);
			GC.KeepAlive(imageRect2T2);
			GC.KeepAlive(disparity);
			return result;
		}

		public HImage UnwarpImageVectorField(HImage vectorField)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1483);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, vectorField);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(vectorField);
			return result;
		}

		public HImage DerivateVectorField(HTuple sigma, string component)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1484);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sigma);
			SZXCArimAPI.StoreS(proc, 1, component);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sigma);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DerivateVectorField(double sigma, string component)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1484);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreS(proc, 1, component);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage VectorFieldLength(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1485);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage OpticalFlowMg(HImage imageT2, string algorithm, double smoothingSigma, double integrationSigma, double flowSmoothness, double gradientConstancy, HTuple MGParamName, HTuple MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1486);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageT2);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreD(proc, 1, smoothingSigma);
			SZXCArimAPI.StoreD(proc, 2, integrationSigma);
			SZXCArimAPI.StoreD(proc, 3, flowSmoothness);
			SZXCArimAPI.StoreD(proc, 4, gradientConstancy);
			SZXCArimAPI.Store(proc, 5, MGParamName);
			SZXCArimAPI.Store(proc, 6, MGParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(MGParamName);
			SZXCArimAPI.UnpinTuple(MGParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageT2);
			return result;
		}

		public HImage OpticalFlowMg(HImage imageT2, string algorithm, double smoothingSigma, double integrationSigma, double flowSmoothness, double gradientConstancy, string MGParamName, string MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1486);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageT2);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreD(proc, 1, smoothingSigma);
			SZXCArimAPI.StoreD(proc, 2, integrationSigma);
			SZXCArimAPI.StoreD(proc, 3, flowSmoothness);
			SZXCArimAPI.StoreD(proc, 4, gradientConstancy);
			SZXCArimAPI.StoreS(proc, 5, MGParamName);
			SZXCArimAPI.StoreS(proc, 6, MGParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageT2);
			return result;
		}

		public HImage ExhaustiveMatchMg(HImage imageTemplate, string mode, int level, int threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1487);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageTemplate);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, level);
			SZXCArimAPI.StoreI(proc, 2, threshold);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageTemplate);
			return result;
		}

		public HTemplate CreateTemplateRot(int numLevel, double angleStart, double angleExtend, double angleStep, string optimize, string grayValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1488);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numLevel);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtend);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimize);
			SZXCArimAPI.StoreS(proc, 5, grayValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTemplate result;
			num = HTemplate.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTemplate CreateTemplate(int firstError, int numLevel, string optimize, string grayValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1489);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, firstError);
			SZXCArimAPI.StoreI(proc, 1, numLevel);
			SZXCArimAPI.StoreS(proc, 2, optimize);
			SZXCArimAPI.StoreS(proc, 3, grayValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTemplate result;
			num = HTemplate.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void AdaptTemplate(HTemplate templateID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1498);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public HRegion FastMatchMg(HTemplate templateID, double maxError, HTuple numLevel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1499);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.Store(proc, 2, numLevel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevel);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
			return result;
		}

		public HRegion FastMatchMg(HTemplate templateID, double maxError, int numLevel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1499);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreI(proc, 2, numLevel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
			return result;
		}

		public void BestMatchPreMg(HTemplate templateID, double maxError, string subPixel, int numLevels, HTuple whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1500);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreS(proc, 2, subPixel);
			SZXCArimAPI.StoreI(proc, 3, numLevels);
			SZXCArimAPI.Store(proc, 4, whichLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(whichLevels);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatchPreMg(HTemplate templateID, double maxError, string subPixel, int numLevels, int whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1500);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreS(proc, 2, subPixel);
			SZXCArimAPI.StoreI(proc, 3, numLevels);
			SZXCArimAPI.StoreI(proc, 4, whichLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatchMg(HTemplate templateID, double maxError, string subPixel, int numLevels, HTuple whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1501);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreS(proc, 2, subPixel);
			SZXCArimAPI.StoreI(proc, 3, numLevels);
			SZXCArimAPI.Store(proc, 4, whichLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(whichLevels);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatchMg(HTemplate templateID, double maxError, string subPixel, int numLevels, int whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1501);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreS(proc, 2, subPixel);
			SZXCArimAPI.StoreI(proc, 3, numLevels);
			SZXCArimAPI.StoreI(proc, 4, whichLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public HRegion FastMatch(HTemplate templateID, double maxError)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1502);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
			return result;
		}

		public void BestMatchRotMg(HTemplate templateID, double angleStart, double angleExtend, double maxError, string subPixel, int numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1503);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtend);
			SZXCArimAPI.StoreD(proc, 3, maxError);
			SZXCArimAPI.StoreS(proc, 4, subPixel);
			SZXCArimAPI.StoreI(proc, 5, numLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatchRotMg(HTemplate templateID, double angleStart, double angleExtend, double maxError, string subPixel, int numLevels, out double row, out double column, out double angle, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1503);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtend);
			SZXCArimAPI.StoreD(proc, 3, maxError);
			SZXCArimAPI.StoreS(proc, 4, subPixel);
			SZXCArimAPI.StoreI(proc, 5, numLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out angle);
			num = SZXCArimAPI.LoadD(proc, 3, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatchRot(HTemplate templateID, double angleStart, double angleExtend, double maxError, string subPixel, out HTuple row, out HTuple column, out HTuple angle, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1504);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtend);
			SZXCArimAPI.StoreD(proc, 3, maxError);
			SZXCArimAPI.StoreS(proc, 4, subPixel);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatchRot(HTemplate templateID, double angleStart, double angleExtend, double maxError, string subPixel, out double row, out double column, out double angle, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1504);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtend);
			SZXCArimAPI.StoreD(proc, 3, maxError);
			SZXCArimAPI.StoreS(proc, 4, subPixel);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out angle);
			num = SZXCArimAPI.LoadD(proc, 3, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatch(HTemplate templateID, double maxError, string subPixel, out HTuple row, out HTuple column, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1505);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreS(proc, 2, subPixel);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public void BestMatch(HTemplate templateID, double maxError, string subPixel, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1505);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, templateID);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreS(proc, 2, subPixel);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(templateID);
		}

		public HImage ExhaustiveMatch(HRegion regionOfInterest, HImage imageTemplate, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1506);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regionOfInterest);
			SZXCArimAPI.Store(proc, 3, imageTemplate);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regionOfInterest);
			GC.KeepAlive(imageTemplate);
			return result;
		}

		public HImage CornerResponse(int size, double weight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1507);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, size);
			SZXCArimAPI.StoreD(proc, 1, weight);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenGaussPyramid(string mode, double scale)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1508);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, scale);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Monotony()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1509);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BandpassImage(string filterType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1510);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont LinesColor(HTuple sigma, HTuple low, HTuple high, string extractWidth, string completeJunctions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1511);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sigma);
			SZXCArimAPI.Store(proc, 1, low);
			SZXCArimAPI.Store(proc, 2, high);
			SZXCArimAPI.StoreS(proc, 3, extractWidth);
			SZXCArimAPI.StoreS(proc, 4, completeJunctions);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sigma);
			SZXCArimAPI.UnpinTuple(low);
			SZXCArimAPI.UnpinTuple(high);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont LinesColor(double sigma, double low, double high, string extractWidth, string completeJunctions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1511);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, low);
			SZXCArimAPI.StoreD(proc, 2, high);
			SZXCArimAPI.StoreS(proc, 3, extractWidth);
			SZXCArimAPI.StoreS(proc, 4, completeJunctions);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont LinesGauss(HTuple sigma, HTuple low, HTuple high, string lightDark, string extractWidth, string lineModel, string completeJunctions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1512);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sigma);
			SZXCArimAPI.Store(proc, 1, low);
			SZXCArimAPI.Store(proc, 2, high);
			SZXCArimAPI.StoreS(proc, 3, lightDark);
			SZXCArimAPI.StoreS(proc, 4, extractWidth);
			SZXCArimAPI.StoreS(proc, 5, lineModel);
			SZXCArimAPI.StoreS(proc, 6, completeJunctions);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sigma);
			SZXCArimAPI.UnpinTuple(low);
			SZXCArimAPI.UnpinTuple(high);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont LinesGauss(double sigma, double low, double high, string lightDark, string extractWidth, string lineModel, string completeJunctions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1512);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, low);
			SZXCArimAPI.StoreD(proc, 2, high);
			SZXCArimAPI.StoreS(proc, 3, lightDark);
			SZXCArimAPI.StoreS(proc, 4, extractWidth);
			SZXCArimAPI.StoreS(proc, 5, lineModel);
			SZXCArimAPI.StoreS(proc, 6, completeJunctions);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont LinesFacet(int maskSize, HTuple low, HTuple high, string lightDark)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1513);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskSize);
			SZXCArimAPI.Store(proc, 1, low);
			SZXCArimAPI.Store(proc, 2, high);
			SZXCArimAPI.StoreS(proc, 3, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(low);
			SZXCArimAPI.UnpinTuple(high);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont LinesFacet(int maskSize, double low, double high, string lightDark)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1513);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskSize);
			SZXCArimAPI.StoreD(proc, 1, low);
			SZXCArimAPI.StoreD(proc, 2, high);
			SZXCArimAPI.StoreS(proc, 3, lightDark);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenFilterMask(HTuple filterMask, double scale, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1514);
			SZXCArimAPI.Store(proc, 0, filterMask);
			SZXCArimAPI.StoreD(proc, 1, scale);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(filterMask);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenFilterMask(string filterMask, double scale, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1514);
			SZXCArimAPI.StoreS(proc, 0, filterMask);
			SZXCArimAPI.StoreD(proc, 1, scale);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenMeanFilter(string maskShape, double diameter1, double diameter2, double phi, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1515);
			SZXCArimAPI.StoreS(proc, 0, maskShape);
			SZXCArimAPI.StoreD(proc, 1, diameter1);
			SZXCArimAPI.StoreD(proc, 2, diameter2);
			SZXCArimAPI.StoreD(proc, 3, phi);
			SZXCArimAPI.StoreS(proc, 4, norm);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenGaussFilter(double sigma1, double sigma2, double phi, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1516);
			SZXCArimAPI.StoreD(proc, 0, sigma1);
			SZXCArimAPI.StoreD(proc, 1, sigma2);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreS(proc, 3, norm);
			SZXCArimAPI.StoreS(proc, 4, mode);
			SZXCArimAPI.StoreI(proc, 5, width);
			SZXCArimAPI.StoreI(proc, 6, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenDerivativeFilter(string derivative, int exponent, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1517);
			SZXCArimAPI.StoreS(proc, 0, derivative);
			SZXCArimAPI.StoreI(proc, 1, exponent);
			SZXCArimAPI.StoreS(proc, 2, norm);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.StoreI(proc, 4, width);
			SZXCArimAPI.StoreI(proc, 5, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenStdBandpass(double frequency, double sigma, string type, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1518);
			SZXCArimAPI.StoreD(proc, 0, frequency);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.StoreS(proc, 2, type);
			SZXCArimAPI.StoreS(proc, 3, norm);
			SZXCArimAPI.StoreS(proc, 4, mode);
			SZXCArimAPI.StoreI(proc, 5, width);
			SZXCArimAPI.StoreI(proc, 6, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenSinBandpass(double frequency, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1519);
			SZXCArimAPI.StoreD(proc, 0, frequency);
			SZXCArimAPI.StoreS(proc, 1, norm);
			SZXCArimAPI.StoreS(proc, 2, mode);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenBandfilter(double minFrequency, double maxFrequency, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1520);
			SZXCArimAPI.StoreD(proc, 0, minFrequency);
			SZXCArimAPI.StoreD(proc, 1, maxFrequency);
			SZXCArimAPI.StoreS(proc, 2, norm);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.StoreI(proc, 4, width);
			SZXCArimAPI.StoreI(proc, 5, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenBandpass(double minFrequency, double maxFrequency, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1521);
			SZXCArimAPI.StoreD(proc, 0, minFrequency);
			SZXCArimAPI.StoreD(proc, 1, maxFrequency);
			SZXCArimAPI.StoreS(proc, 2, norm);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.StoreI(proc, 4, width);
			SZXCArimAPI.StoreI(proc, 5, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenLowpass(double frequency, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1522);
			SZXCArimAPI.StoreD(proc, 0, frequency);
			SZXCArimAPI.StoreS(proc, 1, norm);
			SZXCArimAPI.StoreS(proc, 2, mode);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenHighpass(double frequency, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1523);
			SZXCArimAPI.StoreD(proc, 0, frequency);
			SZXCArimAPI.StoreS(proc, 1, norm);
			SZXCArimAPI.StoreS(proc, 2, mode);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage PowerLn()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1524);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PowerReal()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1525);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PowerByte()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1526);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PhaseDeg()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1527);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PhaseRad()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1528);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EnergyGabor(HImage imageHilbert)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1529);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageHilbert);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageHilbert);
			return result;
		}

		public HImage ConvolGabor(HImage gaborFilter, out HImage imageResultHilbert)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1530);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, gaborFilter);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageResultHilbert);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(gaborFilter);
			return result;
		}

		public void GenGabor(double angle, double frequency, double bandwidth, double orientation, string norm, string mode, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1531);
			SZXCArimAPI.StoreD(proc, 0, angle);
			SZXCArimAPI.StoreD(proc, 1, frequency);
			SZXCArimAPI.StoreD(proc, 2, bandwidth);
			SZXCArimAPI.StoreD(proc, 3, orientation);
			SZXCArimAPI.StoreS(proc, 4, norm);
			SZXCArimAPI.StoreS(proc, 5, mode);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage PhaseCorrelationFft(HImage imageFFT2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1532);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageFFT2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageFFT2);
			return result;
		}

		public HImage CorrelationFft(HImage imageFFT2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1533);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageFFT2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageFFT2);
			return result;
		}

		public HImage ConvolFft(HImage imageFilter)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1534);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageFilter);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageFilter);
			return result;
		}

		public HImage RftGeneric(string direction, string norm, string resultType, int width)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1541);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, direction);
			SZXCArimAPI.StoreS(proc, 1, norm);
			SZXCArimAPI.StoreS(proc, 2, resultType);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage FftImageInv()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1542);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage FftImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1543);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage FftGeneric(string direction, int exponent, string norm, string mode, string resultType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1544);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, direction);
			SZXCArimAPI.StoreI(proc, 1, exponent);
			SZXCArimAPI.StoreS(proc, 2, norm);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.StoreS(proc, 4, resultType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ShockFilter(double theta, int iterations, string mode, double sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1545);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, theta);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.StoreS(proc, 2, mode);
			SZXCArimAPI.StoreD(proc, 3, sigma);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MeanCurvatureFlow(double sigma, double theta, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1546);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, theta);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage CoherenceEnhancingDiff(double sigma, double rho, double theta, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1547);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, rho);
			SZXCArimAPI.StoreD(proc, 2, theta);
			SZXCArimAPI.StoreI(proc, 3, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EquHistoImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1548);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Illuminate(int maskWidth, int maskHeight, double factor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1549);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreD(proc, 2, factor);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Emphasize(int maskWidth, int maskHeight, double factor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1550);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maskWidth);
			SZXCArimAPI.StoreI(proc, 1, maskHeight);
			SZXCArimAPI.StoreD(proc, 2, factor);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ScaleImageMax()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1551);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RobinsonDir(out HImage imageEdgeDir)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1552);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageEdgeDir);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RobinsonAmp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1553);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage KirschDir(out HImage imageEdgeDir)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1554);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageEdgeDir);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage KirschAmp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1555);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage FreiDir(out HImage imageEdgeDir)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1556);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageEdgeDir);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage FreiAmp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1557);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PrewittDir(out HImage imageEdgeDir)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1558);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageEdgeDir);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PrewittAmp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1559);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SobelAmp(string filterType, HTuple size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1560);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterType);
			SZXCArimAPI.Store(proc, 1, size);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(size);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SobelAmp(string filterType, int size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1560);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterType);
			SZXCArimAPI.StoreI(proc, 1, size);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SobelDir(out HImage edgeDirection, string filterType, HTuple size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1561);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterType);
			SZXCArimAPI.Store(proc, 1, size);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(size);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out edgeDirection);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SobelDir(out HImage edgeDirection, string filterType, int size)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1561);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterType);
			SZXCArimAPI.StoreI(proc, 1, size);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out edgeDirection);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Roberts(string filterType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1562);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filterType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Laplace(string resultType, HTuple maskSize, string filterMask)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1563);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, resultType);
			SZXCArimAPI.Store(proc, 1, maskSize);
			SZXCArimAPI.StoreS(proc, 2, filterMask);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maskSize);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Laplace(string resultType, int maskSize, string filterMask)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1563);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, resultType);
			SZXCArimAPI.StoreI(proc, 1, maskSize);
			SZXCArimAPI.StoreS(proc, 2, filterMask);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage HighpassImage(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1564);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont EdgesColorSubPix(string filter, double alpha, HTuple low, HTuple high)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1566);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.Store(proc, 2, low);
			SZXCArimAPI.Store(proc, 3, high);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(low);
			SZXCArimAPI.UnpinTuple(high);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont EdgesColorSubPix(string filter, double alpha, double low, double high)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1566);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.StoreD(proc, 2, low);
			SZXCArimAPI.StoreD(proc, 3, high);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EdgesColor(out HImage imaDir, string filter, double alpha, string NMS, int low, int high)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1567);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.StoreS(proc, 2, NMS);
			SZXCArimAPI.StoreI(proc, 3, low);
			SZXCArimAPI.StoreI(proc, 4, high);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imaDir);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont EdgesSubPix(string filter, double alpha, HTuple low, HTuple high)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1568);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.Store(proc, 2, low);
			SZXCArimAPI.Store(proc, 3, high);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(low);
			SZXCArimAPI.UnpinTuple(high);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont EdgesSubPix(string filter, double alpha, int low, int high)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1568);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.StoreI(proc, 2, low);
			SZXCArimAPI.StoreI(proc, 3, high);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EdgesImage(out HImage imaDir, string filter, double alpha, string NMS, HTuple low, HTuple high)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1569);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.StoreS(proc, 2, NMS);
			SZXCArimAPI.Store(proc, 3, low);
			SZXCArimAPI.Store(proc, 4, high);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(low);
			SZXCArimAPI.UnpinTuple(high);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imaDir);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage EdgesImage(out HImage imaDir, string filter, double alpha, string NMS, int low, int high)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1569);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, filter);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.StoreS(proc, 2, NMS);
			SZXCArimAPI.StoreI(proc, 3, low);
			SZXCArimAPI.StoreI(proc, 4, high);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imaDir);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DerivateGauss(HTuple sigma, string component)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1570);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sigma);
			SZXCArimAPI.StoreS(proc, 1, component);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sigma);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DerivateGauss(double sigma, string component)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1570);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreS(proc, 1, component);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage LaplaceOfGauss(HTuple sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1571);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, sigma);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sigma);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage LaplaceOfGauss(double sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1571);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DiffOfGauss(double sigma, double sigFactor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1572);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, sigma);
			SZXCArimAPI.StoreD(proc, 1, sigFactor);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DetectEdgeSegments(int sobelSize, int minAmplitude, int maxDistance, int minLength, out HTuple beginRow, out HTuple beginCol, out HTuple endRow, out HTuple endCol)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1575);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, sobelSize);
			SZXCArimAPI.StoreI(proc, 1, minAmplitude);
			SZXCArimAPI.StoreI(proc, 2, maxDistance);
			SZXCArimAPI.StoreI(proc, 3, minLength);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out beginRow);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out beginCol);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out endRow);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out endCol);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static void ClearColorTransLut(HColorTransLUT colorTransLUTHandle)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1577);
			SZXCArimAPI.Store(expr_0A, 0, colorTransLUTHandle);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(colorTransLUTHandle);
		}

		public HImage ApplyColorTransLut(HImage image2, HImage image3, out HImage imageResult2, out HImage imageResult3, HColorTransLUT colorTransLUTHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1578);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 3, image3);
			SZXCArimAPI.Store(proc, 0, colorTransLUTHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageResult2);
			num = HImage.LoadNew(proc, 3, num, out imageResult3);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			GC.KeepAlive(image3);
			GC.KeepAlive(colorTransLUTHandle);
			return result;
		}

		public static HColorTransLUT CreateColorTransLut(string colorSpace, string transDirection, int numBits)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1579);
			SZXCArimAPI.StoreS(expr_0A, 0, colorSpace);
			SZXCArimAPI.StoreS(expr_0A, 1, transDirection);
			SZXCArimAPI.StoreI(expr_0A, 2, numBits);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HColorTransLUT result;
			num = HColorTransLUT.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public HImage CfaToRgb(string CFAType, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1580);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, CFAType);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Rgb1ToGray()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1581);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Rgb3ToGray(HImage imageGreen, HImage imageBlue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1582);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageGreen);
			SZXCArimAPI.Store(proc, 3, imageBlue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageGreen);
			GC.KeepAlive(imageBlue);
			return result;
		}

		public HImage TransFromRgb(HImage imageGreen, HImage imageBlue, out HImage imageResult2, out HImage imageResult3, string colorSpace)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1583);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageGreen);
			SZXCArimAPI.Store(proc, 3, imageBlue);
			SZXCArimAPI.StoreS(proc, 0, colorSpace);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageResult2);
			num = HImage.LoadNew(proc, 3, num, out imageResult3);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageGreen);
			GC.KeepAlive(imageBlue);
			return result;
		}

		public HImage TransToRgb(HImage imageInput2, HImage imageInput3, out HImage imageGreen, out HImage imageBlue, string colorSpace)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageInput2);
			SZXCArimAPI.Store(proc, 3, imageInput3);
			SZXCArimAPI.StoreS(proc, 0, colorSpace);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageGreen);
			num = HImage.LoadNew(proc, 3, num, out imageBlue);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageInput2);
			GC.KeepAlive(imageInput3);
			return result;
		}

		public HImage BitMask(int bitMask)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1585);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, bitMask);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BitSlice(int bit)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1586);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, bit);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BitRshift(int shift)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, shift);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BitLshift(int shift)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1588);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, shift);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BitNot()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1589);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BitXor(HImage image2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1590);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage BitOr(HImage image2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1591);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage BitAnd(HImage image2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1592);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage GammaImage(double gamma, double offset, double threshold, HTuple maxGray, string encode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1593);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, gamma);
			SZXCArimAPI.StoreD(proc, 1, offset);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.Store(proc, 3, maxGray);
			SZXCArimAPI.StoreS(proc, 4, encode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maxGray);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GammaImage(double gamma, double offset, double threshold, double maxGray, string encode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1593);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, gamma);
			SZXCArimAPI.StoreD(proc, 1, offset);
			SZXCArimAPI.StoreD(proc, 2, threshold);
			SZXCArimAPI.StoreD(proc, 3, maxGray);
			SZXCArimAPI.StoreS(proc, 4, encode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PowImage(HTuple exponent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1594);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, exponent);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(exponent);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PowImage(double exponent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1594);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, exponent);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ExpImage(HTuple baseVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1595);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, baseVal);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(baseVal);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ExpImage(string baseVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1595);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, baseVal);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage LogImage(HTuple baseVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1596);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, baseVal);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(baseVal);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage LogImage(string baseVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1596);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, baseVal);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage Atan2Image(HImage imageX)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1597);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageX);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageX);
			return result;
		}

		public HImage AtanImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1598);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AcosImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1599);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AsinImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1600);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage TanImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1601);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage CosImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1602);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SinImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1603);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AbsDiffImage(HImage image2, HTuple mult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1604);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, mult);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mult);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage AbsDiffImage(HImage image2, double mult)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1604);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.StoreD(proc, 0, mult);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage SqrtImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1605);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SubImage(HImage imageSubtrahend, HTuple mult, HTuple add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1606);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageSubtrahend);
			SZXCArimAPI.Store(proc, 0, mult);
			SZXCArimAPI.Store(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mult);
			SZXCArimAPI.UnpinTuple(add);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageSubtrahend);
			return result;
		}

		public HImage SubImage(HImage imageSubtrahend, double mult, double add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1606);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageSubtrahend);
			SZXCArimAPI.StoreD(proc, 0, mult);
			SZXCArimAPI.StoreD(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageSubtrahend);
			return result;
		}

		public HImage ScaleImage(HTuple mult, HTuple add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1607);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, mult);
			SZXCArimAPI.Store(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mult);
			SZXCArimAPI.UnpinTuple(add);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ScaleImage(double mult, double add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1607);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, mult);
			SZXCArimAPI.StoreD(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DivImage(HImage image2, HTuple mult, HTuple add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1608);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, mult);
			SZXCArimAPI.Store(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mult);
			SZXCArimAPI.UnpinTuple(add);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage DivImage(HImage image2, double mult, double add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1608);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.StoreD(proc, 0, mult);
			SZXCArimAPI.StoreD(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage MultImage(HImage image2, HTuple mult, HTuple add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1609);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, mult);
			SZXCArimAPI.Store(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mult);
			SZXCArimAPI.UnpinTuple(add);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage MultImage(HImage image2, double mult, double add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1609);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.StoreD(proc, 0, mult);
			SZXCArimAPI.StoreD(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage AddImage(HImage image2, HTuple mult, HTuple add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1610);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, mult);
			SZXCArimAPI.Store(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mult);
			SZXCArimAPI.UnpinTuple(add);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage AddImage(HImage image2, double mult, double add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1610);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.StoreD(proc, 0, mult);
			SZXCArimAPI.StoreD(proc, 1, add);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage AbsImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1611);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MinImage(HImage image2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1612);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage MaxImage(HImage image2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1613);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage InvertImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1614);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AdjustMosaicImages(HTuple from, HTuple to, int referenceImage, HTuple homMatrices2D, string estimationMethod, HTuple estimateParameters, string OECFModel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1615);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, from);
			SZXCArimAPI.Store(proc, 1, to);
			SZXCArimAPI.StoreI(proc, 2, referenceImage);
			SZXCArimAPI.Store(proc, 3, homMatrices2D);
			SZXCArimAPI.StoreS(proc, 4, estimationMethod);
			SZXCArimAPI.Store(proc, 5, estimateParameters);
			SZXCArimAPI.StoreS(proc, 6, OECFModel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(from);
			SZXCArimAPI.UnpinTuple(to);
			SZXCArimAPI.UnpinTuple(homMatrices2D);
			SZXCArimAPI.UnpinTuple(estimateParameters);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AdjustMosaicImages(HTuple from, HTuple to, int referenceImage, HTuple homMatrices2D, string estimationMethod, string estimateParameters, string OECFModel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1615);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, from);
			SZXCArimAPI.Store(proc, 1, to);
			SZXCArimAPI.StoreI(proc, 2, referenceImage);
			SZXCArimAPI.Store(proc, 3, homMatrices2D);
			SZXCArimAPI.StoreS(proc, 4, estimationMethod);
			SZXCArimAPI.StoreS(proc, 5, estimateParameters);
			SZXCArimAPI.StoreS(proc, 6, OECFModel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(from);
			SZXCArimAPI.UnpinTuple(to);
			SZXCArimAPI.UnpinTuple(homMatrices2D);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenCubeMapMosaic(out HImage rear, out HImage left, out HImage right, out HImage top, out HImage bottom, HHomMat2D[] cameraMatrices, HHomMat2D[] rotationMatrices, int cubeMapDimension, HTuple stackingOrder, string interpolation)
		{
			HTuple hTuple = HData.ConcatArray(cameraMatrices);
			HTuple hTuple2 = HData.ConcatArray(rotationMatrices);
			IntPtr proc = SZXCArimAPI.PreCall(1616);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, hTuple2);
			SZXCArimAPI.StoreI(proc, 2, cubeMapDimension);
			SZXCArimAPI.Store(proc, 3, stackingOrder);
			SZXCArimAPI.StoreS(proc, 4, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(stackingOrder);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out rear);
			num = HImage.LoadNew(proc, 3, num, out left);
			num = HImage.LoadNew(proc, 4, num, out right);
			num = HImage.LoadNew(proc, 5, num, out top);
			num = HImage.LoadNew(proc, 6, num, out bottom);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenCubeMapMosaic(out HImage rear, out HImage left, out HImage right, out HImage top, out HImage bottom, HHomMat2D[] cameraMatrices, HHomMat2D[] rotationMatrices, int cubeMapDimension, string stackingOrder, string interpolation)
		{
			HTuple hTuple = HData.ConcatArray(cameraMatrices);
			HTuple hTuple2 = HData.ConcatArray(rotationMatrices);
			IntPtr proc = SZXCArimAPI.PreCall(1616);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, hTuple2);
			SZXCArimAPI.StoreI(proc, 2, cubeMapDimension);
			SZXCArimAPI.StoreS(proc, 3, stackingOrder);
			SZXCArimAPI.StoreS(proc, 4, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out rear);
			num = HImage.LoadNew(proc, 3, num, out left);
			num = HImage.LoadNew(proc, 4, num, out right);
			num = HImage.LoadNew(proc, 5, num, out top);
			num = HImage.LoadNew(proc, 6, num, out bottom);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenSphericalMosaic(HHomMat2D[] cameraMatrices, HHomMat2D[] rotationMatrices, HTuple latMin, HTuple latMax, HTuple longMin, HTuple longMax, HTuple latLongStep, HTuple stackingOrder, HTuple interpolation)
		{
			HTuple hTuple = HData.ConcatArray(cameraMatrices);
			HTuple hTuple2 = HData.ConcatArray(rotationMatrices);
			IntPtr proc = SZXCArimAPI.PreCall(1617);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, hTuple2);
			SZXCArimAPI.Store(proc, 2, latMin);
			SZXCArimAPI.Store(proc, 3, latMax);
			SZXCArimAPI.Store(proc, 4, longMin);
			SZXCArimAPI.Store(proc, 5, longMax);
			SZXCArimAPI.Store(proc, 6, latLongStep);
			SZXCArimAPI.Store(proc, 7, stackingOrder);
			SZXCArimAPI.Store(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(latMin);
			SZXCArimAPI.UnpinTuple(latMax);
			SZXCArimAPI.UnpinTuple(longMin);
			SZXCArimAPI.UnpinTuple(longMax);
			SZXCArimAPI.UnpinTuple(latLongStep);
			SZXCArimAPI.UnpinTuple(stackingOrder);
			SZXCArimAPI.UnpinTuple(interpolation);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenSphericalMosaic(HHomMat2D[] cameraMatrices, HHomMat2D[] rotationMatrices, double latMin, double latMax, double longMin, double longMax, double latLongStep, string stackingOrder, string interpolation)
		{
			HTuple hTuple = HData.ConcatArray(cameraMatrices);
			HTuple hTuple2 = HData.ConcatArray(rotationMatrices);
			IntPtr proc = SZXCArimAPI.PreCall(1617);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, hTuple2);
			SZXCArimAPI.StoreD(proc, 2, latMin);
			SZXCArimAPI.StoreD(proc, 3, latMax);
			SZXCArimAPI.StoreD(proc, 4, longMin);
			SZXCArimAPI.StoreD(proc, 5, longMax);
			SZXCArimAPI.StoreD(proc, 6, latLongStep);
			SZXCArimAPI.StoreS(proc, 7, stackingOrder);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenBundleAdjustedMosaic(HHomMat2D[] homMatrices2D, HTuple stackingOrder, string transformDomain, out HHomMat2D transMat2D)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr proc = SZXCArimAPI.PreCall(1618);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, stackingOrder);
			SZXCArimAPI.StoreS(proc, 2, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(stackingOrder);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HHomMat2D.LoadNew(proc, 0, num, out transMat2D);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenBundleAdjustedMosaic(HHomMat2D[] homMatrices2D, string stackingOrder, string transformDomain, out HHomMat2D transMat2D)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr proc = SZXCArimAPI.PreCall(1618);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.StoreS(proc, 1, stackingOrder);
			SZXCArimAPI.StoreS(proc, 2, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HHomMat2D.LoadNew(proc, 0, num, out transMat2D);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenProjectiveMosaic(int startImage, HTuple mappingSource, HTuple mappingDest, HHomMat2D[] homMatrices2D, HTuple stackingOrder, string transformDomain, out HHomMat2D[] mosaicMatrices2D)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr proc = SZXCArimAPI.PreCall(1619);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, startImage);
			SZXCArimAPI.Store(proc, 1, mappingSource);
			SZXCArimAPI.Store(proc, 2, mappingDest);
			SZXCArimAPI.Store(proc, 3, hTuple);
			SZXCArimAPI.Store(proc, 4, stackingOrder);
			SZXCArimAPI.StoreS(proc, 5, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mappingSource);
			SZXCArimAPI.UnpinTuple(mappingDest);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(stackingOrder);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			mosaicMatrices2D = HHomMat2D.SplitArray(data);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenProjectiveMosaic(int startImage, HTuple mappingSource, HTuple mappingDest, HHomMat2D[] homMatrices2D, string stackingOrder, string transformDomain, out HHomMat2D[] mosaicMatrices2D)
		{
			HTuple hTuple = HData.ConcatArray(homMatrices2D);
			IntPtr proc = SZXCArimAPI.PreCall(1619);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, startImage);
			SZXCArimAPI.Store(proc, 1, mappingSource);
			SZXCArimAPI.Store(proc, 2, mappingDest);
			SZXCArimAPI.Store(proc, 3, hTuple);
			SZXCArimAPI.StoreS(proc, 4, stackingOrder);
			SZXCArimAPI.StoreS(proc, 5, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(mappingSource);
			SZXCArimAPI.UnpinTuple(mappingDest);
			SZXCArimAPI.UnpinTuple(hTuple);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			mosaicMatrices2D = HHomMat2D.SplitArray(data);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ProjectiveTransImageSize(HHomMat2D homMat2D, string interpolation, int width, int height, string transformDomain)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1620);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreS(proc, 4, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ProjectiveTransImage(HHomMat2D homMat2D, string interpolation, string adaptImageSize, string transformDomain)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1621);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreS(proc, 2, adaptImageSize);
			SZXCArimAPI.StoreS(proc, 3, transformDomain);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AffineTransImageSize(HHomMat2D homMat2D, string interpolation, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1622);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage AffineTransImage(HHomMat2D homMat2D, string interpolation, string adaptImageSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1623);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.StoreS(proc, 2, adaptImageSize);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ZoomImageFactor(double scaleWidth, double scaleHeight, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1624);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, scaleWidth);
			SZXCArimAPI.StoreD(proc, 1, scaleHeight);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ZoomImageSize(int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1625);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MirrorImage(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1626);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RotateImage(HTuple phi, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1627);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, phi);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(phi);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RotateImage(double phi, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1627);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, phi);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PolarTransImageInv(HTuple row, HTuple column, double angleStart, double angleEnd, HTuple radiusStart, HTuple radiusEnd, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1628);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.Store(proc, 4, radiusStart);
			SZXCArimAPI.Store(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radiusStart);
			SZXCArimAPI.UnpinTuple(radiusEnd);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PolarTransImageInv(double row, double column, double angleStart, double angleEnd, double radiusStart, double radiusEnd, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1628);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.StoreD(proc, 4, radiusStart);
			SZXCArimAPI.StoreD(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PolarTransImageExt(HTuple row, HTuple column, double angleStart, double angleEnd, HTuple radiusStart, HTuple radiusEnd, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1629);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.Store(proc, 4, radiusStart);
			SZXCArimAPI.Store(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radiusStart);
			SZXCArimAPI.UnpinTuple(radiusEnd);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PolarTransImageExt(double row, double column, double angleStart, double angleEnd, double radiusStart, double radiusEnd, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1629);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.StoreD(proc, 4, radiusStart);
			SZXCArimAPI.StoreD(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.StoreS(proc, 8, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage PolarTransImage(int row, int column, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1630);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat2D VectorFieldToHomMat2d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1631);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeImage(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1650);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeImage()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1651);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WriteImage(string format, HTuple fillColor, HTuple fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1655);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, format);
			SZXCArimAPI.Store(proc, 1, fillColor);
			SZXCArimAPI.Store(proc, 2, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fillColor);
			SZXCArimAPI.UnpinTuple(fileName);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void WriteImage(string format, int fillColor, string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1655);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, format);
			SZXCArimAPI.StoreI(proc, 1, fillColor);
			SZXCArimAPI.StoreS(proc, 2, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadSequence(int headerSize, int sourceWidth, int sourceHeight, int startRow, int startColumn, int destWidth, int destHeight, string pixelType, string bitOrder, string byteOrder, string pad, int index, string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1656);
			SZXCArimAPI.StoreI(proc, 0, headerSize);
			SZXCArimAPI.StoreI(proc, 1, sourceWidth);
			SZXCArimAPI.StoreI(proc, 2, sourceHeight);
			SZXCArimAPI.StoreI(proc, 3, startRow);
			SZXCArimAPI.StoreI(proc, 4, startColumn);
			SZXCArimAPI.StoreI(proc, 5, destWidth);
			SZXCArimAPI.StoreI(proc, 6, destHeight);
			SZXCArimAPI.StoreS(proc, 7, pixelType);
			SZXCArimAPI.StoreS(proc, 8, bitOrder);
			SZXCArimAPI.StoreS(proc, 9, byteOrder);
			SZXCArimAPI.StoreS(proc, 10, pad);
			SZXCArimAPI.StoreI(proc, 11, index);
			SZXCArimAPI.StoreS(proc, 12, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ReadImage(HTuple fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1658);
			SZXCArimAPI.Store(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fileName);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ReadImage(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1658);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetGrayvalContourXld(HXLDCont contour, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1668);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contour);
			SZXCArimAPI.StoreS(proc, 0, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
			return result;
		}

		public HTuple FitSurfaceFirstOrder(HRegion regions, string algorithm, int iterations, double clippingFactor, out HTuple beta, out HTuple gamma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1743);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.StoreD(proc, 2, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out beta);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out gamma);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double FitSurfaceFirstOrder(HRegion regions, string algorithm, int iterations, double clippingFactor, out double beta, out double gamma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1743);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.StoreD(proc, 2, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out beta);
			num = SZXCArimAPI.LoadD(proc, 2, num, out gamma);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple FitSurfaceSecondOrder(HRegion regions, string algorithm, int iterations, double clippingFactor, out HTuple beta, out HTuple gamma, out HTuple delta, out HTuple epsilon, out HTuple zeta)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1744);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.StoreD(proc, 2, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out beta);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out gamma);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out delta);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out epsilon);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out zeta);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double FitSurfaceSecondOrder(HRegion regions, string algorithm, int iterations, double clippingFactor, out double beta, out double gamma, out double delta, out double epsilon, out double zeta)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1744);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.StoreD(proc, 2, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out beta);
			num = SZXCArimAPI.LoadD(proc, 2, num, out gamma);
			num = SZXCArimAPI.LoadD(proc, 3, num, out delta);
			num = SZXCArimAPI.LoadD(proc, 4, num, out epsilon);
			num = SZXCArimAPI.LoadD(proc, 5, num, out zeta);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public void GenImageSurfaceSecondOrder(string type, double alpha, double beta, double gamma, double delta, double epsilon, double zeta, double row, double column, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1745);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.StoreD(proc, 2, beta);
			SZXCArimAPI.StoreD(proc, 3, gamma);
			SZXCArimAPI.StoreD(proc, 4, delta);
			SZXCArimAPI.StoreD(proc, 5, epsilon);
			SZXCArimAPI.StoreD(proc, 6, zeta);
			SZXCArimAPI.StoreD(proc, 7, row);
			SZXCArimAPI.StoreD(proc, 8, column);
			SZXCArimAPI.StoreI(proc, 9, width);
			SZXCArimAPI.StoreI(proc, 10, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImageSurfaceFirstOrder(string type, double alpha, double beta, double gamma, double row, double column, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1746);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.StoreD(proc, 2, beta);
			SZXCArimAPI.StoreD(proc, 3, gamma);
			SZXCArimAPI.StoreD(proc, 4, row);
			SZXCArimAPI.StoreD(proc, 5, column);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void MinMaxGray(HRegion regions, HTuple percent, out HTuple min, out HTuple max, out HTuple range)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1751);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 0, percent);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(percent);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out min);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out max);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out range);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
		}

		public void MinMaxGray(HRegion regions, double percent, out double min, out double max, out double range)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1751);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreD(proc, 0, percent);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out min);
			num = SZXCArimAPI.LoadD(proc, 1, num, out max);
			num = SZXCArimAPI.LoadD(proc, 2, num, out range);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
		}

		public HTuple Intensity(HRegion regions, out HTuple deviation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1752);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out deviation);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double Intensity(HRegion regions, out double deviation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1752);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out deviation);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple GrayHistoRange(HRegion regions, HTuple min, HTuple max, int numBins, out double binSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1753);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 0, min);
			SZXCArimAPI.Store(proc, 1, max);
			SZXCArimAPI.StoreI(proc, 2, numBins);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out binSize);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public int GrayHistoRange(HRegion regions, double min, double max, int numBins, out double binSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1753);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreD(proc, 0, min);
			SZXCArimAPI.StoreD(proc, 1, max);
			SZXCArimAPI.StoreI(proc, 2, numBins);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out binSize);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HImage Histo2dim(HRegion regions, HImage imageRow)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1754);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 3, imageRow);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			GC.KeepAlive(imageRow);
			return result;
		}

		public HTuple GrayHistoAbs(HRegion regions, HTuple quantization)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1755);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.Store(proc, 0, quantization);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(quantization);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple GrayHistoAbs(HRegion regions, double quantization)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1755);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreD(proc, 0, quantization);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple GrayHisto(HRegion regions, out HTuple relativeHisto)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1756);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out relativeHisto);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple EntropyGray(HRegion regions, out HTuple anisotropy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1757);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out anisotropy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double EntropyGray(HRegion regions, out double anisotropy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1757);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out anisotropy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double CoocFeatureMatrix(out double correlation, out double homogeneity, out double contrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1758);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out correlation);
			num = SZXCArimAPI.LoadD(proc, 2, num, out homogeneity);
			num = SZXCArimAPI.LoadD(proc, 3, num, out contrast);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple CoocFeatureImage(HRegion regions, int ldGray, HTuple direction, out HTuple correlation, out HTuple homogeneity, out HTuple contrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1759);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreI(proc, 0, ldGray);
			SZXCArimAPI.Store(proc, 1, direction);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(direction);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out correlation);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out homogeneity);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out contrast);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double CoocFeatureImage(HRegion regions, int ldGray, int direction, out double correlation, out double homogeneity, out double contrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1759);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreI(proc, 0, ldGray);
			SZXCArimAPI.StoreI(proc, 1, direction);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out correlation);
			num = SZXCArimAPI.LoadD(proc, 2, num, out homogeneity);
			num = SZXCArimAPI.LoadD(proc, 3, num, out contrast);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HImage GenCoocMatrix(HRegion regions, int ldGray, int direction)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1760);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreI(proc, 0, ldGray);
			SZXCArimAPI.StoreI(proc, 1, direction);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public void MomentsGrayPlane(HRegion regions, out HTuple MRow, out HTuple MCol, out HTuple alpha, out HTuple beta, out HTuple mean)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1761);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out MRow);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out MCol);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out alpha);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out beta);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out mean);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
		}

		public void MomentsGrayPlane(HRegion regions, out double MRow, out double MCol, out double alpha, out double beta, out double mean)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1761);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out MRow);
			num = SZXCArimAPI.LoadD(proc, 1, num, out MCol);
			num = SZXCArimAPI.LoadD(proc, 2, num, out alpha);
			num = SZXCArimAPI.LoadD(proc, 3, num, out beta);
			num = SZXCArimAPI.LoadD(proc, 4, num, out mean);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
		}

		public HTuple PlaneDeviation(HRegion regions)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1762);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple EllipticAxisGray(HRegion regions, out HTuple rb, out HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1763);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out rb);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double EllipticAxisGray(HRegion regions, out double rb, out double phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1763);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out rb);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple AreaCenterGray(HRegion regions, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1764);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public double AreaCenterGray(HRegion regions, out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1764);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out row);
			num = SZXCArimAPI.LoadD(proc, 2, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
			return result;
		}

		public HTuple GrayProjections(HRegion region, string mode, out HTuple vertProjection)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1765);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out vertProjection);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public HXLDCont FindDataCode2d(HDataCode2D dataCodeHandle, HTuple genParamName, HTuple genParamValue, out HTuple resultHandles, out HTuple decodedDataStrings)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1768);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, dataCodeHandle);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out resultHandles);
			num = HTuple.LoadNew(proc, 1, num, out decodedDataStrings);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(dataCodeHandle);
			return result;
		}

		public HXLDCont FindDataCode2d(HDataCode2D dataCodeHandle, string genParamName, int genParamValue, out int resultHandles, out string decodedDataStrings)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1768);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, dataCodeHandle);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreI(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadI(proc, 0, num, out resultHandles);
			num = SZXCArimAPI.LoadS(proc, 1, num, out decodedDataStrings);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(dataCodeHandle);
			return result;
		}

		public HImage ConvertMapType(string newType, HTuple imageWidth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1901);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, newType);
			SZXCArimAPI.Store(proc, 1, imageWidth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(imageWidth);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ConvertMapType(string newType, int imageWidth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1901);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, newType);
			SZXCArimAPI.StoreI(proc, 1, imageWidth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HPose VectorToPose(HTuple worldX, HTuple worldY, HTuple worldZ, HTuple imageRow, HTuple imageColumn, HCamPar cameraParam, string method, HTuple qualityType, out HTuple quality)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1902);
			SZXCArimAPI.Store(expr_0A, 0, worldX);
			SZXCArimAPI.Store(expr_0A, 1, worldY);
			SZXCArimAPI.Store(expr_0A, 2, worldZ);
			SZXCArimAPI.Store(expr_0A, 3, imageRow);
			SZXCArimAPI.Store(expr_0A, 4, imageColumn);
			SZXCArimAPI.Store(expr_0A, 5, cameraParam);
			SZXCArimAPI.StoreS(expr_0A, 6, method);
			SZXCArimAPI.Store(expr_0A, 7, qualityType);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(worldX);
			SZXCArimAPI.UnpinTuple(worldY);
			SZXCArimAPI.UnpinTuple(worldZ);
			SZXCArimAPI.UnpinTuple(imageRow);
			SZXCArimAPI.UnpinTuple(imageColumn);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(qualityType);
			HPose result;
			num = HPose.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, num, out quality);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HPose VectorToPose(HTuple worldX, HTuple worldY, HTuple worldZ, HTuple imageRow, HTuple imageColumn, HCamPar cameraParam, string method, string qualityType, out double quality)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1902);
			SZXCArimAPI.Store(expr_0A, 0, worldX);
			SZXCArimAPI.Store(expr_0A, 1, worldY);
			SZXCArimAPI.Store(expr_0A, 2, worldZ);
			SZXCArimAPI.Store(expr_0A, 3, imageRow);
			SZXCArimAPI.Store(expr_0A, 4, imageColumn);
			SZXCArimAPI.Store(expr_0A, 5, cameraParam);
			SZXCArimAPI.StoreS(expr_0A, 6, method);
			SZXCArimAPI.StoreS(expr_0A, 7, qualityType);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(worldX);
			SZXCArimAPI.UnpinTuple(worldY);
			SZXCArimAPI.UnpinTuple(worldZ);
			SZXCArimAPI.UnpinTuple(imageRow);
			SZXCArimAPI.UnpinTuple(imageColumn);
			SZXCArimAPI.UnpinTuple(cameraParam);
			HPose result;
			num = HPose.LoadNew(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out quality);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HPose ProjHomMat2dToPose(HHomMat2D homography, HHomMat2D cameraMatrix, string method)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1903);
			SZXCArimAPI.Store(expr_0A, 0, homography);
			SZXCArimAPI.Store(expr_0A, 1, cameraMatrix);
			SZXCArimAPI.StoreS(expr_0A, 2, method);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(homography);
			SZXCArimAPI.UnpinTuple(cameraMatrix);
			HPose result;
			num = HPose.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public HTuple RadiometricSelfCalibration(HTuple exposureRatios, string features, string functionType, double smoothness, int polynomialDegree)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1910);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, exposureRatios);
			SZXCArimAPI.StoreS(proc, 1, features);
			SZXCArimAPI.StoreS(proc, 2, functionType);
			SZXCArimAPI.StoreD(proc, 3, smoothness);
			SZXCArimAPI.StoreI(proc, 4, polynomialDegree);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(exposureRatios);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple RadiometricSelfCalibration(double exposureRatios, string features, string functionType, double smoothness, int polynomialDegree)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1910);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, exposureRatios);
			SZXCArimAPI.StoreS(proc, 1, features);
			SZXCArimAPI.StoreS(proc, 2, functionType);
			SZXCArimAPI.StoreD(proc, 3, smoothness);
			SZXCArimAPI.StoreI(proc, 4, polynomialDegree);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage MapImage(HImage map)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1911);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, map);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(map);
			return result;
		}

		public void GenRadialDistortionMap(HCamPar camParamIn, HCamPar camParamOut, string mapType)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1912);
			SZXCArimAPI.Store(proc, 0, camParamIn);
			SZXCArimAPI.Store(proc, 1, camParamOut);
			SZXCArimAPI.StoreS(proc, 2, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamIn);
			SZXCArimAPI.UnpinTuple(camParamOut);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImageToWorldPlaneMap(HCamPar cameraParam, HPose worldPose, int widthIn, int heightIn, int widthMapped, int heightMapped, HTuple scale, string mapType)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1913);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, widthIn);
			SZXCArimAPI.StoreI(proc, 3, heightIn);
			SZXCArimAPI.StoreI(proc, 4, widthMapped);
			SZXCArimAPI.StoreI(proc, 5, heightMapped);
			SZXCArimAPI.Store(proc, 6, scale);
			SZXCArimAPI.StoreS(proc, 7, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(worldPose);
			SZXCArimAPI.UnpinTuple(scale);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenImageToWorldPlaneMap(HCamPar cameraParam, HPose worldPose, int widthIn, int heightIn, int widthMapped, int heightMapped, string scale, string mapType)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1913);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, widthIn);
			SZXCArimAPI.StoreI(proc, 3, heightIn);
			SZXCArimAPI.StoreI(proc, 4, widthMapped);
			SZXCArimAPI.StoreI(proc, 5, heightMapped);
			SZXCArimAPI.StoreS(proc, 6, scale);
			SZXCArimAPI.StoreS(proc, 7, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(worldPose);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage ImageToWorldPlane(HCamPar cameraParam, HPose worldPose, int width, int height, HTuple scale, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1914);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.Store(proc, 4, scale);
			SZXCArimAPI.StoreS(proc, 5, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(worldPose);
			SZXCArimAPI.UnpinTuple(scale);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ImageToWorldPlane(HCamPar cameraParam, HPose worldPose, int width, int height, string scale, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1914);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreS(proc, 4, scale);
			SZXCArimAPI.StoreS(proc, 5, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(worldPose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ChangeRadialDistortionImage(HRegion region, HCamPar camParamIn, HCamPar camParamOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1924);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.Store(proc, 0, camParamIn);
			SZXCArimAPI.Store(proc, 1, camParamOut);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamIn);
			SZXCArimAPI.UnpinTuple(camParamOut);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			return result;
		}

		public void SimCaltab(string calPlateDescr, HCamPar cameraParam, HPose calPlatePose, int grayBackground, int grayPlate, int grayMarks, double scaleFac)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1944);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
			SZXCArimAPI.Store(proc, 1, cameraParam);
			SZXCArimAPI.Store(proc, 2, calPlatePose);
			SZXCArimAPI.StoreI(proc, 3, grayBackground);
			SZXCArimAPI.StoreI(proc, 4, grayPlate);
			SZXCArimAPI.StoreI(proc, 5, grayMarks);
			SZXCArimAPI.StoreD(proc, 6, scaleFac);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(calPlatePose);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple FindMarksAndPose(HRegion calPlateRegion, string calPlateDescr, HCamPar startCamParam, int startThresh, int deltaThresh, int minThresh, double alpha, double minContLength, double maxDiamMarks, out HTuple CCoord, out HPose startPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1947);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, calPlateRegion);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
			SZXCArimAPI.Store(proc, 1, startCamParam);
			SZXCArimAPI.StoreI(proc, 2, startThresh);
			SZXCArimAPI.StoreI(proc, 3, deltaThresh);
			SZXCArimAPI.StoreI(proc, 4, minThresh);
			SZXCArimAPI.StoreD(proc, 5, alpha);
			SZXCArimAPI.StoreD(proc, 6, minContLength);
			SZXCArimAPI.StoreD(proc, 7, maxDiamMarks);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(startCamParam);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out CCoord);
			num = HPose.LoadNew(proc, 2, num, out startPose);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(calPlateRegion);
			return result;
		}

		public HRegion FindCaltab(string calPlateDescr, HTuple sizeGauss, HTuple markThresh, int minDiamMarks)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1948);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
			SZXCArimAPI.Store(proc, 1, sizeGauss);
			SZXCArimAPI.Store(proc, 2, markThresh);
			SZXCArimAPI.StoreI(proc, 3, minDiamMarks);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(sizeGauss);
			SZXCArimAPI.UnpinTuple(markThresh);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion FindCaltab(string calPlateDescr, int sizeGauss, int markThresh, int minDiamMarks)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1948);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
			SZXCArimAPI.StoreI(proc, 1, sizeGauss);
			SZXCArimAPI.StoreI(proc, 2, markThresh);
			SZXCArimAPI.StoreI(proc, 3, minDiamMarks);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DecodeBarCodeRectangle2(HBarCode barCodeHandle, HTuple codeType, HTuple row, HTuple column, HTuple phi, HTuple length1, HTuple length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1992);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, barCodeHandle);
			SZXCArimAPI.Store(proc, 1, codeType);
			SZXCArimAPI.Store(proc, 2, row);
			SZXCArimAPI.Store(proc, 3, column);
			SZXCArimAPI.Store(proc, 4, phi);
			SZXCArimAPI.Store(proc, 5, length1);
			SZXCArimAPI.Store(proc, 6, length2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(codeType);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(length1);
			SZXCArimAPI.UnpinTuple(length2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(barCodeHandle);
			return result;
		}

		public string DecodeBarCodeRectangle2(HBarCode barCodeHandle, string codeType, double row, double column, double phi, double length1, double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1992);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, barCodeHandle);
			SZXCArimAPI.StoreS(proc, 1, codeType);
			SZXCArimAPI.StoreD(proc, 2, row);
			SZXCArimAPI.StoreD(proc, 3, column);
			SZXCArimAPI.StoreD(proc, 4, phi);
			SZXCArimAPI.StoreD(proc, 5, length1);
			SZXCArimAPI.StoreD(proc, 6, length2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(barCodeHandle);
			return result;
		}

		public HRegion FindBarCode(HBarCode barCodeHandle, HTuple codeType, out HTuple decodedDataStrings)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1993);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, barCodeHandle);
			SZXCArimAPI.Store(proc, 1, codeType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(codeType);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, num, out decodedDataStrings);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(barCodeHandle);
			return result;
		}

		public HRegion FindBarCode(HBarCode barCodeHandle, string codeType, out string decodedDataStrings)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1993);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, barCodeHandle);
			SZXCArimAPI.StoreS(proc, 1, codeType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadS(proc, 0, num, out decodedDataStrings);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(barCodeHandle);
			return result;
		}

		public void GiveBgEsti(HBgEsti bgEstiHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2003);
			SZXCArimAPI.Store(proc, 0, bgEstiHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(bgEstiHandle);
		}

		public void UpdateBgEsti(HRegion upDateRegion, HBgEsti bgEstiHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2004);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, upDateRegion);
			SZXCArimAPI.Store(proc, 0, bgEstiHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(upDateRegion);
			GC.KeepAlive(bgEstiHandle);
		}

		public HRegion RunBgEsti(HBgEsti bgEstiHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2005);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, bgEstiHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(bgEstiHandle);
			return result;
		}

		public HBgEsti CreateBgEsti(double syspar1, double syspar2, string gainMode, double gain1, double gain2, string adaptMode, double minDiff, int statNum, double confidenceC, double timeC)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2008);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, syspar1);
			SZXCArimAPI.StoreD(proc, 1, syspar2);
			SZXCArimAPI.StoreS(proc, 2, gainMode);
			SZXCArimAPI.StoreD(proc, 3, gain1);
			SZXCArimAPI.StoreD(proc, 4, gain2);
			SZXCArimAPI.StoreS(proc, 5, adaptMode);
			SZXCArimAPI.StoreD(proc, 6, minDiff);
			SZXCArimAPI.StoreI(proc, 7, statNum);
			SZXCArimAPI.StoreD(proc, 8, confidenceC);
			SZXCArimAPI.StoreD(proc, 9, timeC);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HBgEsti result;
			num = HBgEsti.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion GrabDataAsync(out HXLDCont contours, HFramegrabber acqHandle, double maxDelay, out HTuple data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2029);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 2, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public HRegion GrabDataAsync(out HXLDCont contours, HFramegrabber acqHandle, double maxDelay, out string data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2029);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 2, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = SZXCArimAPI.LoadS(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public HRegion GrabData(out HXLDCont contours, HFramegrabber acqHandle, out HTuple data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2030);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 2, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public HRegion GrabData(out HXLDCont contours, HFramegrabber acqHandle, out string data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2030);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 2, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = SZXCArimAPI.LoadS(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public void GrabImageAsync(HFramegrabber acqHandle, double maxDelay)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2031);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
		}

		public void GrabImage(HFramegrabber acqHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2033);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
		}

		public HTuple AddTextureInspectionModelImage(HTextureInspectionModel textureInspectionModel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2043);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, textureInspectionModel);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(textureInspectionModel);
			return result;
		}

		public HRegion ApplyTextureInspectionModel(HTextureInspectionModel textureInspectionModel, out HTextureInspectionResult textureInspectionResultID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2044);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, textureInspectionModel);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTextureInspectionResult.LoadNew(proc, 0, num, out textureInspectionResultID);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(textureInspectionModel);
			return result;
		}

		public HImage BilateralFilter(HImage imageJoint, double sigmaSpatial, double sigmaRange, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2045);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageJoint);
			SZXCArimAPI.StoreD(proc, 0, sigmaSpatial);
			SZXCArimAPI.StoreD(proc, 1, sigmaRange);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageJoint);
			return result;
		}

		public HImage BilateralFilter(HImage imageJoint, double sigmaSpatial, double sigmaRange, string genParamName, double genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2045);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageJoint);
			SZXCArimAPI.StoreD(proc, 0, sigmaSpatial);
			SZXCArimAPI.StoreD(proc, 1, sigmaRange);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreD(proc, 3, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageJoint);
			return result;
		}

		public void FindNccModels(HNCCModel[] modelIDs, HTuple angleStart, HTuple angleExtent, HTuple minScore, HTuple numMatches, HTuple maxOverlap, HTuple subPixel, HTuple numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			HTuple hTuple = HHandleBase.ConcatArray(modelIDs);
			IntPtr proc = SZXCArimAPI.PreCall(2068);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 1, angleStart);
			SZXCArimAPI.Store(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, minScore);
			SZXCArimAPI.Store(proc, 4, numMatches);
			SZXCArimAPI.Store(proc, 5, maxOverlap);
			SZXCArimAPI.Store(proc, 6, subPixel);
			SZXCArimAPI.Store(proc, 7, numLevels);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(numMatches);
			SZXCArimAPI.UnpinTuple(maxOverlap);
			SZXCArimAPI.UnpinTuple(subPixel);
			SZXCArimAPI.UnpinTuple(numLevels);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out angle);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out score);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out model);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modelIDs);
		}

		public void FindNccModels(HNCCModel modelIDs, double angleStart, double angleExtent, double minScore, int numMatches, double maxOverlap, string subPixel, int numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple score, out HTuple model)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2068);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, modelIDs);
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
			GC.KeepAlive(modelIDs);
		}

		public void GetTextureInspectionModelImage(HTextureInspectionModel textureInspectionModel)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2075);
			SZXCArimAPI.Store(proc, 0, textureInspectionModel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(textureInspectionModel);
		}

		public HImage GuidedFilter(HImage imageGuide, int radius, double amplitude)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2078);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageGuide);
			SZXCArimAPI.StoreI(proc, 0, radius);
			SZXCArimAPI.StoreD(proc, 1, amplitude);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageGuide);
			return result;
		}

		public HImage InterleaveChannels(string pixelFormat, HTuple rowBytes, int alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2079);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, pixelFormat);
			SZXCArimAPI.Store(proc, 1, rowBytes);
			SZXCArimAPI.StoreI(proc, 2, alpha);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowBytes);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage InterleaveChannels(string pixelFormat, string rowBytes, int alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2079);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, pixelFormat);
			SZXCArimAPI.StoreS(proc, 1, rowBytes);
			SZXCArimAPI.StoreI(proc, 2, alpha);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SegmentImageMser(out HRegion MSERLight, string polarity, HTuple minArea, HTuple maxArea, HTuple delta, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2087);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, polarity);
			SZXCArimAPI.Store(proc, 1, minArea);
			SZXCArimAPI.Store(proc, 2, maxArea);
			SZXCArimAPI.Store(proc, 3, delta);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minArea);
			SZXCArimAPI.UnpinTuple(maxArea);
			SZXCArimAPI.UnpinTuple(delta);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out MSERLight);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SegmentImageMser(out HRegion MSERLight, string polarity, int minArea, int maxArea, int delta, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2087);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, polarity);
			SZXCArimAPI.StoreI(proc, 1, minArea);
			SZXCArimAPI.StoreI(proc, 2, maxArea);
			SZXCArimAPI.StoreI(proc, 3, delta);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out MSERLight);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static void TrainTextureInspectionModel(HTextureInspectionModel textureInspectionModel)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2099);
			SZXCArimAPI.Store(expr_0A, 0, textureInspectionModel);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(textureInspectionModel);
		}

		public HImage UncalibratedPhotometricStereo(out HImage gradient, out HImage albedo, HTuple resultType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2101);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, resultType);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(resultType);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out gradient);
			num = HImage.LoadNew(proc, 3, num, out albedo);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage InsertObj(HImage objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public new HImage RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HImage RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ReplaceObj(HImage objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HImage ReplaceObj(HImage objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public static HRegion GetShapeModelClutter(HShapeModel modelID, HTuple genParamName, out HTuple genParamValue, out HHomMat2D homMat2D, out int clutterContrast)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2178);
			SZXCArimAPI.Store(expr_0A, 0, modelID);
			SZXCArimAPI.Store(expr_0A, 1, genParamName);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(genParamName);
			HRegion result;
			num = HRegion.LoadNew(expr_0A, 1, num, out result);
			num = HTuple.LoadNew(expr_0A, 0, num, out genParamValue);
			num = HHomMat2D.LoadNew(expr_0A, 1, num, out homMat2D);
			num = SZXCArimAPI.LoadI(expr_0A, 2, num, out clutterContrast);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(modelID);
			return result;
		}

		public static HRegion GetShapeModelClutter(HShapeModel modelID, string genParamName, out string genParamValue, out HHomMat2D homMat2D, out int clutterContrast)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2178);
			SZXCArimAPI.Store(expr_0A, 0, modelID);
			SZXCArimAPI.StoreS(expr_0A, 1, genParamName);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HRegion result;
			num = HRegion.LoadNew(expr_0A, 1, num, out result);
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out genParamValue);
			num = HHomMat2D.LoadNew(expr_0A, 1, num, out homMat2D);
			num = SZXCArimAPI.LoadI(expr_0A, 2, num, out clutterContrast);
			SZXCArimAPI.PostCall(expr_0A, num);
			GC.KeepAlive(modelID);
			return result;
		}

		public static void SetShapeModelClutter(HRegion clutterRegion, HShapeModel modelID, HHomMat2D homMat2D, int clutterContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2180);
			SZXCArimAPI.Store(expr_0A, 1, clutterRegion);
			SZXCArimAPI.Store(expr_0A, 0, modelID);
			SZXCArimAPI.Store(expr_0A, 1, homMat2D);
			SZXCArimAPI.StoreI(expr_0A, 2, clutterContrast);
			SZXCArimAPI.Store(expr_0A, 3, genParamName);
			SZXCArimAPI.Store(expr_0A, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(homMat2D);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(clutterRegion);
			GC.KeepAlive(modelID);
		}

		public static void SetShapeModelClutter(HRegion clutterRegion, HShapeModel modelID, HHomMat2D homMat2D, int clutterContrast, string genParamName, double genParamValue)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2180);
			SZXCArimAPI.Store(expr_0A, 1, clutterRegion);
			SZXCArimAPI.Store(expr_0A, 0, modelID);
			SZXCArimAPI.Store(expr_0A, 1, homMat2D);
			SZXCArimAPI.StoreI(expr_0A, 2, clutterContrast);
			SZXCArimAPI.StoreS(expr_0A, 3, genParamName);
			SZXCArimAPI.StoreD(expr_0A, 4, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(homMat2D);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(clutterRegion);
			GC.KeepAlive(modelID);
		}

		public static HTuple ReadImageMetadata(string format, HTuple tagName, string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2185);
			SZXCArimAPI.StoreS(expr_0A, 0, format);
			SZXCArimAPI.Store(expr_0A, 1, tagName);
			SZXCArimAPI.StoreS(expr_0A, 2, fileName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(tagName);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public HRegion WatershedsMarker(HRegion markers)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2190);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, markers);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(markers);
			return result;
		}

		public static void WriteImageMetadata(string format, HTuple tagName, HTuple tagValue, string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2191);
			SZXCArimAPI.StoreS(expr_0A, 0, format);
			SZXCArimAPI.Store(expr_0A, 1, tagName);
			SZXCArimAPI.Store(expr_0A, 2, tagValue);
			SZXCArimAPI.StoreS(expr_0A, 3, fileName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(tagName);
			SZXCArimAPI.UnpinTuple(tagValue);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}
	}
}
