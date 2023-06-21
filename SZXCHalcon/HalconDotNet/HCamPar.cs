using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HCamPar : HData, ISerializable, ICloneable
	{
		public HCamPar()
		{
		}

		public HCamPar(HTuple tuple) : base(tuple)
		{
		}

		internal HCamPar(HData data) : base(data)
		{
		}

		internal static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HCamPar obj)
		{
			HTuple t;
			err = HTuple.LoadNew(proc, parIndex, err, out t);
			obj = new HCamPar(new HData(t));
			return err;
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCamPar obj)
		{
			return HCamPar.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeCamPar();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HCamPar(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeCamPar(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeCamPar();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HCamPar Deserialize(Stream stream)
		{
			HCamPar arg_0C_0 = new HCamPar();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeCamPar(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HCamPar Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeCamPar();
			HCamPar expr_0C = new HCamPar();
			expr_0C.DeserializeCamPar(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HImage BinocularDistanceMs(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect2, HPose relPoseRect, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(346);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistanceMs(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect2, HPose relPoseRect, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(346);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistanceMg(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect2, HPose relPoseRect, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, HTuple MGParamName, HTuple MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(348);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(MGParamName);
			SZXCArimAPI.UnpinTuple(MGParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistanceMg(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect2, HPose relPoseRect, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, string MGParamName, string MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(348);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HHomMat2D RelPoseToFundamentalMatrix(HPose relPose, HTuple covRelPose, HCamPar camPar2, out HTuple covFMat)
		{
			IntPtr proc = SZXCArimAPI.PreCall(353);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, relPose);
			SZXCArimAPI.Store(proc, 1, covRelPose);
			SZXCArimAPI.Store(proc, 3, camPar2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(relPose);
			SZXCArimAPI.UnpinTuple(covRelPose);
			SZXCArimAPI.UnpinTuple(camPar2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covFMat);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose VectorToRelPose(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, HCamPar camPar2, string method, out HTuple covRelPose, out HTuple error, out HTuple x, out HTuple y, out HTuple z, out HTuple covXYZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(355);
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
			SZXCArimAPI.Store(proc, 11, camPar2);
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
			SZXCArimAPI.UnpinTuple(camPar2);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covRelPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out covXYZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose VectorToRelPose(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, HCamPar camPar2, string method, out HTuple covRelPose, out double error, out HTuple x, out HTuple y, out HTuple z, out HTuple covXYZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(355);
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
			SZXCArimAPI.Store(proc, 11, camPar2);
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
			SZXCArimAPI.UnpinTuple(camPar2);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covRelPose);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out covXYZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose MatchRelPoseRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HCamPar camPar2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out HTuple covRelPose, out HTuple error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(359);
			base.Store(proc, 4);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
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
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HPose MatchRelPoseRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HCamPar camPar2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out HTuple covRelPose, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(359);
			base.Store(proc, 4);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 0, rows1);
			SZXCArimAPI.Store(proc, 1, cols1);
			SZXCArimAPI.Store(proc, 2, rows2);
			SZXCArimAPI.Store(proc, 3, cols2);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(rows1);
			SZXCArimAPI.UnpinTuple(cols1);
			SZXCArimAPI.UnpinTuple(rows2);
			SZXCArimAPI.UnpinTuple(cols2);
			SZXCArimAPI.UnpinTuple(camPar2);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covRelPose);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HImage BinocularDistance(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect2, HPose relPoseRect, string method, int maskWidth, int maskHeight, HTuple textureThresh, int minDisparity, int maxDisparity, int numLevels, HTuple scoreThresh, HTuple filter, HTuple subDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(362);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
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
			base.UnpinTuple();
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
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistance(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect2, HPose relPoseRect, string method, int maskWidth, int maskHeight, double textureThresh, int minDisparity, int maxDisparity, int numLevels, double scoreThresh, string filter, string subDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(362);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public void IntersectLinesOfSight(HCamPar camParam2, HPose relPose, HTuple row1, HTuple col1, HTuple row2, HTuple col2, out HTuple x, out HTuple y, out HTuple z, out HTuple dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(364);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParam2);
			SZXCArimAPI.Store(proc, 2, relPose);
			SZXCArimAPI.Store(proc, 3, row1);
			SZXCArimAPI.Store(proc, 4, col1);
			SZXCArimAPI.Store(proc, 5, row2);
			SZXCArimAPI.Store(proc, 6, col2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam2);
			SZXCArimAPI.UnpinTuple(relPose);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(col1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(col2);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out dist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void IntersectLinesOfSight(HCamPar camParam2, HPose relPose, double row1, double col1, double row2, double col2, out double x, out double y, out double z, out double dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(364);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParam2);
			SZXCArimAPI.Store(proc, 2, relPose);
			SZXCArimAPI.StoreD(proc, 3, row1);
			SZXCArimAPI.StoreD(proc, 4, col1);
			SZXCArimAPI.StoreD(proc, 5, row2);
			SZXCArimAPI.StoreD(proc, 6, col2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam2);
			SZXCArimAPI.UnpinTuple(relPose);
			num = SZXCArimAPI.LoadD(proc, 0, num, out x);
			num = SZXCArimAPI.LoadD(proc, 1, num, out y);
			num = SZXCArimAPI.LoadD(proc, 2, num, out z);
			num = SZXCArimAPI.LoadD(proc, 3, num, out dist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage DisparityImageToXyz(HImage disparity, out HImage y, out HImage z, HCamPar camParamRect2, HPose relPoseRect)
		{
			IntPtr proc = SZXCArimAPI.PreCall(365);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, disparity);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out y);
			num = HImage.LoadNew(proc, 3, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(disparity);
			return result;
		}

		public void DisparityToPoint3d(HCamPar camParamRect2, HPose relPoseRect, HTuple row1, HTuple col1, HTuple disparity, out HTuple x, out HTuple y, out HTuple z)
		{
			IntPtr proc = SZXCArimAPI.PreCall(366);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.Store(proc, 3, row1);
			SZXCArimAPI.Store(proc, 4, col1);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(col1);
			SZXCArimAPI.UnpinTuple(disparity);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DisparityToPoint3d(HCamPar camParamRect2, HPose relPoseRect, double row1, double col1, double disparity, out double x, out double y, out double z)
		{
			IntPtr proc = SZXCArimAPI.PreCall(366);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreD(proc, 3, row1);
			SZXCArimAPI.StoreD(proc, 4, col1);
			SZXCArimAPI.StoreD(proc, 5, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			num = SZXCArimAPI.LoadD(proc, 0, num, out x);
			num = SZXCArimAPI.LoadD(proc, 1, num, out y);
			num = SZXCArimAPI.LoadD(proc, 2, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DisparityToDistance(HCamPar camParamRect2, HPose relPoseRect, HTuple disparity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(367);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.Store(proc, 3, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(disparity);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double DisparityToDistance(HCamPar camParamRect2, HPose relPoseRect, double disparity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(367);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreD(proc, 3, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DistanceToDisparity(HCamPar camParamRect2, HPose relPoseRect, HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(368);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.Store(proc, 3, distance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			SZXCArimAPI.UnpinTuple(distance);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double DistanceToDisparity(HCamPar camParamRect2, HPose relPoseRect, double distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(368);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 2, relPoseRect);
			SZXCArimAPI.StoreD(proc, 3, distance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenBinocularRectificationMap(out HImage map2, HCamPar camParam2, HPose relPose, double subSampling, string method, string mapType, out HCamPar camParamRect1, out HCamPar camParamRect2, out HPose camPoseRect1, out HPose camPoseRect2, out HPose relPoseRect)
		{
			IntPtr proc = SZXCArimAPI.PreCall(369);
			base.Store(proc, 0);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam2);
			SZXCArimAPI.UnpinTuple(relPose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out map2);
			num = HCamPar.LoadNew(proc, 0, num, out camParamRect1);
			num = HCamPar.LoadNew(proc, 1, num, out camParamRect2);
			num = HPose.LoadNew(proc, 2, num, out camPoseRect1);
			num = HPose.LoadNew(proc, 3, num, out camPoseRect2);
			num = HPose.LoadNew(proc, 4, num, out relPoseRect);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HCamPar BinocularCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow1, HTuple NCol1, HTuple NRow2, HTuple NCol2, HCamPar startCamParam2, HPose[] NStartPose1, HPose[] NStartPose2, HTuple estimateParams, out HCamPar camParam2, out HPose[] NFinalPose1, out HPose[] NFinalPose2, out HPose relPose, out HTuple errors)
		{
			HTuple hTuple = HData.ConcatArray(NStartPose1);
			HTuple hTuple2 = HData.ConcatArray(NStartPose2);
			IntPtr proc = SZXCArimAPI.PreCall(370);
			base.Store(proc, 7);
			SZXCArimAPI.Store(proc, 0, NX);
			SZXCArimAPI.Store(proc, 1, NY);
			SZXCArimAPI.Store(proc, 2, NZ);
			SZXCArimAPI.Store(proc, 3, NRow1);
			SZXCArimAPI.Store(proc, 4, NCol1);
			SZXCArimAPI.Store(proc, 5, NRow2);
			SZXCArimAPI.Store(proc, 6, NCol2);
			SZXCArimAPI.Store(proc, 8, startCamParam2);
			SZXCArimAPI.Store(proc, 9, hTuple);
			SZXCArimAPI.Store(proc, 10, hTuple2);
			SZXCArimAPI.Store(proc, 11, estimateParams);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(NX);
			SZXCArimAPI.UnpinTuple(NY);
			SZXCArimAPI.UnpinTuple(NZ);
			SZXCArimAPI.UnpinTuple(NRow1);
			SZXCArimAPI.UnpinTuple(NCol1);
			SZXCArimAPI.UnpinTuple(NRow2);
			SZXCArimAPI.UnpinTuple(NCol2);
			SZXCArimAPI.UnpinTuple(startCamParam2);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(estimateParams);
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			num = HCamPar.LoadNew(proc, 1, num, out camParam2);
			HTuple data;
			num = HTuple.LoadNew(proc, 2, num, out data);
			HTuple data2;
			num = HTuple.LoadNew(proc, 3, num, out data2);
			num = HPose.LoadNew(proc, 4, num, out relPose);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out errors);
			SZXCArimAPI.PostCall(proc, num);
			NFinalPose1 = HPose.SplitArray(data);
			NFinalPose2 = HPose.SplitArray(data2);
			GC.KeepAlive(this);
			return result;
		}

		public HCamPar BinocularCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow1, HTuple NCol1, HTuple NRow2, HTuple NCol2, HCamPar startCamParam2, HPose NStartPose1, HPose NStartPose2, HTuple estimateParams, out HCamPar camParam2, out HPose NFinalPose1, out HPose NFinalPose2, out HPose relPose, out double errors)
		{
			IntPtr proc = SZXCArimAPI.PreCall(370);
			base.Store(proc, 7);
			SZXCArimAPI.Store(proc, 0, NX);
			SZXCArimAPI.Store(proc, 1, NY);
			SZXCArimAPI.Store(proc, 2, NZ);
			SZXCArimAPI.Store(proc, 3, NRow1);
			SZXCArimAPI.Store(proc, 4, NCol1);
			SZXCArimAPI.Store(proc, 5, NRow2);
			SZXCArimAPI.Store(proc, 6, NCol2);
			SZXCArimAPI.Store(proc, 8, startCamParam2);
			SZXCArimAPI.Store(proc, 9, NStartPose1);
			SZXCArimAPI.Store(proc, 10, NStartPose2);
			SZXCArimAPI.Store(proc, 11, estimateParams);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(NX);
			SZXCArimAPI.UnpinTuple(NY);
			SZXCArimAPI.UnpinTuple(NZ);
			SZXCArimAPI.UnpinTuple(NRow1);
			SZXCArimAPI.UnpinTuple(NCol1);
			SZXCArimAPI.UnpinTuple(NRow2);
			SZXCArimAPI.UnpinTuple(NCol2);
			SZXCArimAPI.UnpinTuple(startCamParam2);
			SZXCArimAPI.UnpinTuple(NStartPose1);
			SZXCArimAPI.UnpinTuple(NStartPose2);
			SZXCArimAPI.UnpinTuple(estimateParams);
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			num = HCamPar.LoadNew(proc, 1, num, out camParam2);
			num = HPose.LoadNew(proc, 2, num, out NFinalPose1);
			num = HPose.LoadNew(proc, 3, num, out NFinalPose2);
			num = HPose.LoadNew(proc, 4, num, out relPose);
			num = SZXCArimAPI.LoadD(proc, 5, num, out errors);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose[] FindCalibDescriptorModel(HImage image, HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, HTuple minScore, int numMatches, HTuple scoreType, out HTuple score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(948);
			base.Store(proc, 7);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.Store(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.Store(proc, 8, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
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
			HPose[] arg_DC_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(modelID);
			return arg_DC_0;
		}

		public HPose FindCalibDescriptorModel(HImage image, HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, double minScore, int numMatches, string scoreType, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(948);
			base.Store(proc, 7);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, modelID);
			SZXCArimAPI.Store(proc, 1, detectorParamName);
			SZXCArimAPI.Store(proc, 2, detectorParamValue);
			SZXCArimAPI.Store(proc, 3, descriptorParamName);
			SZXCArimAPI.Store(proc, 4, descriptorParamValue);
			SZXCArimAPI.StoreD(proc, 5, minScore);
			SZXCArimAPI.StoreI(proc, 6, numMatches);
			SZXCArimAPI.StoreS(proc, 8, scoreType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(modelID);
			return result;
		}

		public HDescriptorModel CreateCalibDescriptorModel(HImage template, HPose referencePose, string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(952);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 1, referencePose);
			SZXCArimAPI.StoreS(proc, 2, detectorType);
			SZXCArimAPI.Store(proc, 3, detectorParamName);
			SZXCArimAPI.Store(proc, 4, detectorParamValue);
			SZXCArimAPI.Store(proc, 5, descriptorParamName);
			SZXCArimAPI.Store(proc, 6, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 7, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			HDescriptorModel result;
			num = HDescriptorModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModelXld(HXLDCont contours, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contours);
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
			base.UnpinTuple();
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
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModelXld(HXLDCont contours, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contours);
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
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(referencePose);
			SZXCArimAPI.UnpinTuple(angleStart);
			SZXCArimAPI.UnpinTuple(angleExtent);
			SZXCArimAPI.UnpinTuple(scaleRMax);
			SZXCArimAPI.UnpinTuple(scaleCMax);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModel(HImage template, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, template);
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
			base.UnpinTuple();
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
			GC.KeepAlive(template);
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModel(HImage template, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, template);
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
			base.UnpinTuple();
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
			GC.KeepAlive(template);
			return result;
		}

		public HXLDCont ProjectShapeModel3d(HShapeModel3D shapeModel3DID, HPose pose, string hiddenSurfaceRemoval, HTuple minFaceAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1055);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, shapeModel3DID);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
			SZXCArimAPI.Store(proc, 4, minFaceAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(minFaceAngle);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(shapeModel3DID);
			return result;
		}

		public HXLDCont ProjectShapeModel3d(HShapeModel3D shapeModel3DID, HPose pose, string hiddenSurfaceRemoval, double minFaceAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1055);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, shapeModel3DID);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
			SZXCArimAPI.StoreD(proc, 4, minFaceAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(shapeModel3DID);
			return result;
		}

		public HShapeModel3D CreateShapeModel3d(HObjectModel3D objectModel3D, double refRotX, double refRotY, double refRotZ, string orderOfRotation, double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, double camRollMin, double camRollMax, double distMin, double distMax, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1059);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, refRotX);
			SZXCArimAPI.StoreD(proc, 3, refRotY);
			SZXCArimAPI.StoreD(proc, 4, refRotZ);
			SZXCArimAPI.StoreS(proc, 5, orderOfRotation);
			SZXCArimAPI.StoreD(proc, 6, longitudeMin);
			SZXCArimAPI.StoreD(proc, 7, longitudeMax);
			SZXCArimAPI.StoreD(proc, 8, latitudeMin);
			SZXCArimAPI.StoreD(proc, 9, latitudeMax);
			SZXCArimAPI.StoreD(proc, 10, camRollMin);
			SZXCArimAPI.StoreD(proc, 11, camRollMax);
			SZXCArimAPI.StoreD(proc, 12, distMin);
			SZXCArimAPI.StoreD(proc, 13, distMax);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HShapeModel3D result;
			num = HShapeModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HShapeModel3D CreateShapeModel3d(HObjectModel3D objectModel3D, double refRotX, double refRotY, double refRotZ, string orderOfRotation, double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, double camRollMin, double camRollMax, double distMin, double distMax, int minContrast, string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1059);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreD(proc, 2, refRotX);
			SZXCArimAPI.StoreD(proc, 3, refRotY);
			SZXCArimAPI.StoreD(proc, 4, refRotZ);
			SZXCArimAPI.StoreS(proc, 5, orderOfRotation);
			SZXCArimAPI.StoreD(proc, 6, longitudeMin);
			SZXCArimAPI.StoreD(proc, 7, longitudeMax);
			SZXCArimAPI.StoreD(proc, 8, latitudeMin);
			SZXCArimAPI.StoreD(proc, 9, latitudeMax);
			SZXCArimAPI.StoreD(proc, 10, camRollMin);
			SZXCArimAPI.StoreD(proc, 11, camRollMax);
			SZXCArimAPI.StoreD(proc, 12, distMin);
			SZXCArimAPI.StoreD(proc, 13, distMax);
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.StoreS(proc, 15, genParamName);
			SZXCArimAPI.StoreI(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HShapeModel3D result;
			num = HShapeModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D[] ReduceObjectModel3dByView(HRegion region, HObjectModel3D[] objectModel3D, HPose[] pose)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr proc = SZXCArimAPI.PreCall(1084);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 2, hTuple2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D ReduceObjectModel3dByView(HRegion region, HObjectModel3D objectModel3D, HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1084);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HImage RenderObjectModel3d(HObjectModel3D[] objectModel3D, HPose[] pose, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr proc = SZXCArimAPI.PreCall(1088);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.Store(proc, 2, hTuple2);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HImage RenderObjectModel3d(HObjectModel3D objectModel3D, HPose pose, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1088);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public void DispObjectModel3d(HWindow windowHandle, HObjectModel3D[] objectModel3D, HPose[] pose, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr proc = SZXCArimAPI.PreCall(1089);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 1, hTuple);
			SZXCArimAPI.Store(proc, 3, hTuple2);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			GC.KeepAlive(objectModel3D);
		}

		public void DispObjectModel3d(HWindow windowHandle, HObjectModel3D objectModel3D, HPose pose, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1089);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 3, pose);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			GC.KeepAlive(objectModel3D);
		}

		public HImage ObjectModel3dToXyz(out HImage y, out HImage z, HObjectModel3D[] objectModel3D, string type, HPose pose)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			IntPtr proc = SZXCArimAPI.PreCall(1092);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, hTuple);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.Store(proc, 3, pose);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(pose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out y);
			num = HImage.LoadNew(proc, 3, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HImage ObjectModel3dToXyz(out HImage y, out HImage z, HObjectModel3D objectModel3D, string type, HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1092);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.Store(proc, 3, pose);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out y);
			num = HImage.LoadNew(proc, 3, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HXLDCont ProjectObjectModel3d(HObjectModel3D objectModel3D, HPose pose, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1095);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HXLDCont ProjectObjectModel3d(HObjectModel3D objectModel3D, HPose pose, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1095);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 2, pose);
			SZXCArimAPI.StoreS(proc, 3, genParamName);
			SZXCArimAPI.StoreS(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public int AddScene3dCamera(HScene3D scene3D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1218);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, scene3D);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(scene3D);
			return result;
		}

		public HObjectModel3D[] SceneFlowCalib(HImage imageRect1T1, HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, HTuple smoothingFlow, HTuple smoothingDisparity, HTuple genParamName, HTuple genParamValue, HCamPar camParamRect2, HPose relPoseRect)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1481);
			base.Store(proc, 4);
			SZXCArimAPI.Store(proc, 1, imageRect1T1);
			SZXCArimAPI.Store(proc, 2, imageRect2T1);
			SZXCArimAPI.Store(proc, 3, imageRect1T2);
			SZXCArimAPI.Store(proc, 4, imageRect2T2);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.Store(proc, 0, smoothingFlow);
			SZXCArimAPI.Store(proc, 1, smoothingDisparity);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.Store(proc, 5, camParamRect2);
			SZXCArimAPI.Store(proc, 6, relPoseRect);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(smoothingFlow);
			SZXCArimAPI.UnpinTuple(smoothingDisparity);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1T1);
			GC.KeepAlive(imageRect2T1);
			GC.KeepAlive(imageRect1T2);
			GC.KeepAlive(imageRect2T2);
			GC.KeepAlive(disparity);
			return result;
		}

		public HObjectModel3D SceneFlowCalib(HImage imageRect1T1, HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, double smoothingFlow, double smoothingDisparity, string genParamName, string genParamValue, HCamPar camParamRect2, HPose relPoseRect)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1481);
			base.Store(proc, 4);
			SZXCArimAPI.Store(proc, 1, imageRect1T1);
			SZXCArimAPI.Store(proc, 2, imageRect2T1);
			SZXCArimAPI.Store(proc, 3, imageRect1T2);
			SZXCArimAPI.Store(proc, 4, imageRect2T2);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.StoreD(proc, 0, smoothingFlow);
			SZXCArimAPI.StoreD(proc, 1, smoothingDisparity);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.Store(proc, 5, camParamRect2);
			SZXCArimAPI.Store(proc, 6, relPoseRect);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(relPoseRect);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1T1);
			GC.KeepAlive(imageRect2T1);
			GC.KeepAlive(imageRect1T2);
			GC.KeepAlive(imageRect2T2);
			GC.KeepAlive(disparity);
			return result;
		}

		public HPose VectorToPose(HTuple worldX, HTuple worldY, HTuple worldZ, HTuple imageRow, HTuple imageColumn, string method, HTuple qualityType, out HTuple quality)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1902);
			base.Store(proc, 5);
			SZXCArimAPI.Store(proc, 0, worldX);
			SZXCArimAPI.Store(proc, 1, worldY);
			SZXCArimAPI.Store(proc, 2, worldZ);
			SZXCArimAPI.Store(proc, 3, imageRow);
			SZXCArimAPI.Store(proc, 4, imageColumn);
			SZXCArimAPI.StoreS(proc, 6, method);
			SZXCArimAPI.Store(proc, 7, qualityType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldX);
			SZXCArimAPI.UnpinTuple(worldY);
			SZXCArimAPI.UnpinTuple(worldZ);
			SZXCArimAPI.UnpinTuple(imageRow);
			SZXCArimAPI.UnpinTuple(imageColumn);
			SZXCArimAPI.UnpinTuple(qualityType);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out quality);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose VectorToPose(HTuple worldX, HTuple worldY, HTuple worldZ, HTuple imageRow, HTuple imageColumn, string method, string qualityType, out double quality)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1902);
			base.Store(proc, 5);
			SZXCArimAPI.Store(proc, 0, worldX);
			SZXCArimAPI.Store(proc, 1, worldY);
			SZXCArimAPI.Store(proc, 2, worldZ);
			SZXCArimAPI.Store(proc, 3, imageRow);
			SZXCArimAPI.Store(proc, 4, imageColumn);
			SZXCArimAPI.StoreS(proc, 6, method);
			SZXCArimAPI.StoreS(proc, 7, qualityType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldX);
			SZXCArimAPI.UnpinTuple(worldY);
			SZXCArimAPI.UnpinTuple(worldZ);
			SZXCArimAPI.UnpinTuple(imageRow);
			SZXCArimAPI.UnpinTuple(imageColumn);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out quality);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont RadialDistortionSelfCalibration(HXLDCont contours, int width, int height, double inlierThreshold, int randSeed, string distortionModel, string distortionCenter, double principalPointVar)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1904);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.StoreD(proc, 2, inlierThreshold);
			SZXCArimAPI.StoreI(proc, 3, randSeed);
			SZXCArimAPI.StoreS(proc, 4, distortionModel);
			SZXCArimAPI.StoreS(proc, 5, distortionCenter);
			SZXCArimAPI.StoreD(proc, 6, principalPointVar);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public HHomMat2D CamParToCamMat(out int imageWidth, out int imageHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1905);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out imageWidth);
			num = SZXCArimAPI.LoadI(proc, 2, num, out imageHeight);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CamMatToCamPar(HHomMat2D cameraMatrix, double kappa, int imageWidth, int imageHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1906);
			SZXCArimAPI.Store(proc, 0, cameraMatrix);
			SZXCArimAPI.StoreD(proc, 1, kappa);
			SZXCArimAPI.StoreI(proc, 2, imageWidth);
			SZXCArimAPI.StoreI(proc, 3, imageHeight);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraMatrix);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HPose[] GetRectanglePose(HXLD contour, HTuple width, HTuple height, string weightingMode, double clippingFactor, out HTuple covPose, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1908);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.Store(proc, 1, width);
			SZXCArimAPI.Store(proc, 2, height);
			SZXCArimAPI.StoreS(proc, 3, weightingMode);
			SZXCArimAPI.StoreD(proc, 4, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(width);
			SZXCArimAPI.UnpinTuple(height);
			HTuple data;
			num = HTuple.LoadNew(proc, 0, num, out data);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			HPose[] arg_AA_0 = HPose.SplitArray(data);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
			return arg_AA_0;
		}

		public HPose GetRectanglePose(HXLD contour, double width, double height, string weightingMode, double clippingFactor, out HTuple covPose, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1908);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.StoreD(proc, 1, width);
			SZXCArimAPI.StoreD(proc, 2, height);
			SZXCArimAPI.StoreS(proc, 3, weightingMode);
			SZXCArimAPI.StoreD(proc, 4, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
			return result;
		}

		public HTuple GetCirclePose(HXLD contour, HTuple radius, string outputType, out HTuple pose2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1909);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.Store(proc, 1, radius);
			SZXCArimAPI.StoreS(proc, 2, outputType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(radius);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out pose2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
			return result;
		}

		public HTuple GetCirclePose(HXLD contour, double radius, string outputType, out HTuple pose2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1909);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contour);
			SZXCArimAPI.StoreD(proc, 1, radius);
			SZXCArimAPI.StoreS(proc, 2, outputType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, num, out pose2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour);
			return result;
		}

		public HImage GenRadialDistortionMap(HCamPar camParamOut, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1912);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, camParamOut);
			SZXCArimAPI.StoreS(proc, 2, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamOut);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenImageToWorldPlaneMap(HPose worldPose, int widthIn, int heightIn, int widthMapped, int heightMapped, HTuple scale, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1913);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, widthIn);
			SZXCArimAPI.StoreI(proc, 3, heightIn);
			SZXCArimAPI.StoreI(proc, 4, widthMapped);
			SZXCArimAPI.StoreI(proc, 5, heightMapped);
			SZXCArimAPI.Store(proc, 6, scale);
			SZXCArimAPI.StoreS(proc, 7, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldPose);
			SZXCArimAPI.UnpinTuple(scale);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenImageToWorldPlaneMap(HPose worldPose, int widthIn, int heightIn, int widthMapped, int heightMapped, string scale, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1913);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, widthIn);
			SZXCArimAPI.StoreI(proc, 3, heightIn);
			SZXCArimAPI.StoreI(proc, 4, widthMapped);
			SZXCArimAPI.StoreI(proc, 5, heightMapped);
			SZXCArimAPI.StoreS(proc, 6, scale);
			SZXCArimAPI.StoreS(proc, 7, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldPose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ImageToWorldPlane(HImage image, HPose worldPose, int width, int height, HTuple scale, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1914);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.Store(proc, 4, scale);
			SZXCArimAPI.StoreS(proc, 5, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldPose);
			SZXCArimAPI.UnpinTuple(scale);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage ImageToWorldPlane(HImage image, HPose worldPose, int width, int height, string scale, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1914);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreS(proc, 4, scale);
			SZXCArimAPI.StoreS(proc, 5, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldPose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void ImagePointsToWorldPlane(HPose worldPose, HTuple rows, HTuple cols, HTuple scale, out HTuple x, out HTuple y)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1916);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.Store(proc, 2, rows);
			SZXCArimAPI.Store(proc, 3, cols);
			SZXCArimAPI.Store(proc, 4, scale);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldPose);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(cols);
			SZXCArimAPI.UnpinTuple(scale);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ImagePointsToWorldPlane(HPose worldPose, HTuple rows, HTuple cols, string scale, out HTuple x, out HTuple y)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1916);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.Store(proc, 2, rows);
			SZXCArimAPI.Store(proc, 3, cols);
			SZXCArimAPI.StoreS(proc, 4, scale);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(worldPose);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(cols);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HPose HandEyeCalibration(HTuple x, HTuple y, HTuple z, HTuple row, HTuple col, HTuple numPoints, HPose[] robotPoses, string method, HTuple qualityType, out HPose calibrationPose, out HTuple quality)
		{
			HTuple hTuple = HData.ConcatArray(robotPoses);
			IntPtr proc = SZXCArimAPI.PreCall(1918);
			base.Store(proc, 7);
			SZXCArimAPI.Store(proc, 0, x);
			SZXCArimAPI.Store(proc, 1, y);
			SZXCArimAPI.Store(proc, 2, z);
			SZXCArimAPI.Store(proc, 3, row);
			SZXCArimAPI.Store(proc, 4, col);
			SZXCArimAPI.Store(proc, 5, numPoints);
			SZXCArimAPI.Store(proc, 6, hTuple);
			SZXCArimAPI.StoreS(proc, 8, method);
			SZXCArimAPI.Store(proc, 9, qualityType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(numPoints);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(qualityType);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HPose.LoadNew(proc, 1, num, out calibrationPose);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out quality);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose HandEyeCalibration(HTuple x, HTuple y, HTuple z, HTuple row, HTuple col, HTuple numPoints, HPose[] robotPoses, string method, string qualityType, out HPose calibrationPose, out double quality)
		{
			HTuple hTuple = HData.ConcatArray(robotPoses);
			IntPtr proc = SZXCArimAPI.PreCall(1918);
			base.Store(proc, 7);
			SZXCArimAPI.Store(proc, 0, x);
			SZXCArimAPI.Store(proc, 1, y);
			SZXCArimAPI.Store(proc, 2, z);
			SZXCArimAPI.Store(proc, 3, row);
			SZXCArimAPI.Store(proc, 4, col);
			SZXCArimAPI.Store(proc, 5, numPoints);
			SZXCArimAPI.Store(proc, 6, hTuple);
			SZXCArimAPI.StoreS(proc, 8, method);
			SZXCArimAPI.StoreS(proc, 9, qualityType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(numPoints);
			SZXCArimAPI.UnpinTuple(hTuple);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			num = HPose.LoadNew(proc, 1, num, out calibrationPose);
			num = SZXCArimAPI.LoadD(proc, 2, num, out quality);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ChangeRadialDistortionContoursXld(HXLDCont contours, HCamPar camParamOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1922);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 1, camParamOut);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamOut);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public void ChangeRadialDistortionPoints(HTuple row, HTuple col, HCamPar camParamOut, out HTuple rowChanged, out HTuple colChanged)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1923);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, col);
			SZXCArimAPI.Store(proc, 3, camParamOut);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(camParamOut);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowChanged);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out colChanged);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage ChangeRadialDistortionImage(HImage image, HRegion region, HCamPar camParamOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1924);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, region);
			SZXCArimAPI.Store(proc, 1, camParamOut);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamOut);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(region);
			return result;
		}

		public HCamPar ChangeRadialDistortionCamPar(string mode, HTuple distortionCoeffs)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1925);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 2, distortionCoeffs);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(distortionCoeffs);
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HCamPar ChangeRadialDistortionCamPar(string mode, double distortionCoeffs)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1925);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 2, distortionCoeffs);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetLineOfSight(HTuple row, HTuple column, out HTuple PX, out HTuple PY, out HTuple PZ, out HTuple QX, out HTuple QY, out HTuple QZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1929);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out PX);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out PY);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out PZ);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out QX);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out QY);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out QZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void Project3dPoint(HTuple x, HTuple y, HTuple z, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1932);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 0, x);
			SZXCArimAPI.Store(proc, 1, y);
			SZXCArimAPI.Store(proc, 2, z);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HHomMat3D CamParPoseToHomMat3d(HPose pose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1933);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pose);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(pose);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeCamPar(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1936);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeCamPar()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1937);
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

		public void ReadCamPar(string camParFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1942);
			SZXCArimAPI.StoreS(proc, 0, camParFile);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteCamPar(string camParFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1943);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, camParFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage SimCaltab(string calPlateDescr, HPose calPlatePose, int grayBackground, int grayPlate, int grayMarks, double scaleFac)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1944);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
			SZXCArimAPI.Store(proc, 2, calPlatePose);
			SZXCArimAPI.StoreI(proc, 3, grayBackground);
			SZXCArimAPI.StoreI(proc, 4, grayPlate);
			SZXCArimAPI.StoreI(proc, 5, grayMarks);
			SZXCArimAPI.StoreD(proc, 6, scaleFac);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(calPlatePose);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DispCaltab(HWindow windowHandle, string calPlateDescr, HPose calPlatePose, double scaleFac)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1945);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 1, calPlateDescr);
			SZXCArimAPI.Store(proc, 3, calPlatePose);
			SZXCArimAPI.StoreD(proc, 4, scaleFac);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(calPlatePose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public HCamPar CameraCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow, HTuple NCol, HPose[] NStartPose, HTuple estimateParams, out HPose[] NFinalPose, out HTuple errors)
		{
			HTuple hTuple = HData.ConcatArray(NStartPose);
			IntPtr proc = SZXCArimAPI.PreCall(1946);
			base.Store(proc, 5);
			SZXCArimAPI.Store(proc, 0, NX);
			SZXCArimAPI.Store(proc, 1, NY);
			SZXCArimAPI.Store(proc, 2, NZ);
			SZXCArimAPI.Store(proc, 3, NRow);
			SZXCArimAPI.Store(proc, 4, NCol);
			SZXCArimAPI.Store(proc, 6, hTuple);
			SZXCArimAPI.Store(proc, 7, estimateParams);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(NX);
			SZXCArimAPI.UnpinTuple(NY);
			SZXCArimAPI.UnpinTuple(NZ);
			SZXCArimAPI.UnpinTuple(NRow);
			SZXCArimAPI.UnpinTuple(NCol);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(estimateParams);
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			HTuple data;
			num = HTuple.LoadNew(proc, 1, num, out data);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out errors);
			SZXCArimAPI.PostCall(proc, num);
			NFinalPose = HPose.SplitArray(data);
			GC.KeepAlive(this);
			return result;
		}

		public HCamPar CameraCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow, HTuple NCol, HPose NStartPose, HTuple estimateParams, out HPose NFinalPose, out double errors)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1946);
			base.Store(proc, 5);
			SZXCArimAPI.Store(proc, 0, NX);
			SZXCArimAPI.Store(proc, 1, NY);
			SZXCArimAPI.Store(proc, 2, NZ);
			SZXCArimAPI.Store(proc, 3, NRow);
			SZXCArimAPI.Store(proc, 4, NCol);
			SZXCArimAPI.Store(proc, 6, NStartPose);
			SZXCArimAPI.Store(proc, 7, estimateParams);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(NX);
			SZXCArimAPI.UnpinTuple(NY);
			SZXCArimAPI.UnpinTuple(NZ);
			SZXCArimAPI.UnpinTuple(NRow);
			SZXCArimAPI.UnpinTuple(NCol);
			SZXCArimAPI.UnpinTuple(NStartPose);
			SZXCArimAPI.UnpinTuple(estimateParams);
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			num = HPose.LoadNew(proc, 1, num, out NFinalPose);
			num = SZXCArimAPI.LoadD(proc, 2, num, out errors);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple FindMarksAndPose(HImage image, HRegion calPlateRegion, string calPlateDescr, int startThresh, int deltaThresh, int minThresh, double alpha, double minContLength, double maxDiamMarks, out HTuple CCoord, out HPose startPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1947);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, calPlateRegion);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
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
			base.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out CCoord);
			num = HPose.LoadNew(proc, 2, num, out startPose);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(calPlateRegion);
			return result;
		}

		public void SetCameraSetupCamParam(HCameraSetupModel cameraSetupModelID, HTuple cameraIdx, HTuple cameraType, HTuple cameraPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1957);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 0, cameraSetupModelID);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.Store(proc, 2, cameraType);
			SZXCArimAPI.Store(proc, 4, cameraPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraType);
			SZXCArimAPI.UnpinTuple(cameraPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(cameraSetupModelID);
		}

		public void SetCameraSetupCamParam(HCameraSetupModel cameraSetupModelID, HTuple cameraIdx, string cameraType, HTuple cameraPose)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1957);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 0, cameraSetupModelID);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, cameraType);
			SZXCArimAPI.Store(proc, 4, cameraPose);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraPose);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(cameraSetupModelID);
		}

		public void SetCalibDataCamParam(HCalibData calibDataID, HTuple cameraIdx, HTuple cameraType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1979);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 0, calibDataID);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.Store(proc, 2, cameraType);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraType);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(calibDataID);
		}

		public void SetCalibDataCamParam(HCalibData calibDataID, HTuple cameraIdx, string cameraType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1979);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 0, calibDataID);
			SZXCArimAPI.Store(proc, 1, cameraIdx);
			SZXCArimAPI.StoreS(proc, 2, cameraType);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(calibDataID);
		}
	}
}
