using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HPose : HData, ISerializable, ICloneable
	{
		private const int FIXEDSIZE = 7;

		public HPose()
		{
		}

		public HPose(HTuple tuple) : base(tuple)
		{
		}

		internal HPose(HData data) : base(data)
		{
		}

		internal static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HPose obj)
		{
			HTuple t;
			err = HTuple.LoadNew(proc, parIndex, err, out t);
			obj = new HPose(new HData(t));
			return err;
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HPose obj)
		{
			return HPose.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
		}

		internal static HPose[] SplitArray(HTuple data)
		{
			int num = data.Length / 7;
			HPose[] array = new HPose[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new HPose(new HData(data.TupleSelectRange(i * 7, (i + 1) * 7 - 1)));
			}
			return array;
		}

		public HPose(double transX, double transY, double transZ, double rotX, double rotY, double rotZ, string orderOfTransform, string orderOfRotation, string viewOfTransform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1921);
			SZXCArimAPI.StoreD(proc, 0, transX);
			SZXCArimAPI.StoreD(proc, 1, transY);
			SZXCArimAPI.StoreD(proc, 2, transZ);
			SZXCArimAPI.StoreD(proc, 3, rotX);
			SZXCArimAPI.StoreD(proc, 4, rotY);
			SZXCArimAPI.StoreD(proc, 5, rotZ);
			SZXCArimAPI.StoreS(proc, 6, orderOfTransform);
			SZXCArimAPI.StoreS(proc, 7, orderOfRotation);
			SZXCArimAPI.StoreS(proc, 8, viewOfTransform);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializePose();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HPose(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializePose(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializePose();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public static HPose Deserialize(Stream stream)
		{
			HPose arg_0C_0 = new HPose();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializePose(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public HPose Clone()
		{
			HSerializedItem hSerializedItem = this.SerializePose();
			HPose expr_0C = new HPose();
			expr_0C.DeserializePose(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static implicit operator HHomMat3D(HPose pose)
		{
			return pose.PoseToHomMat3d();
		}

		public static HPose PoseAverage(HPose[] poses, HTuple weights, string mode, HTuple sigmaT, HTuple sigmaR, out HTuple quality)
		{
			HTuple hTuple = HData.ConcatArray(poses);
			IntPtr expr_13 = SZXCArimAPI.PreCall(221);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, weights);
			SZXCArimAPI.StoreS(expr_13, 2, mode);
			SZXCArimAPI.Store(expr_13, 3, sigmaT);
			SZXCArimAPI.Store(expr_13, 4, sigmaR);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(weights);
			SZXCArimAPI.UnpinTuple(sigmaT);
			SZXCArimAPI.UnpinTuple(sigmaR);
			HPose result;
			num = HPose.LoadNew(expr_13, 0, num, out result);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out quality);
			SZXCArimAPI.PostCall(expr_13, num);
			return result;
		}

		public static HPose PoseAverage(HPose[] poses, HTuple weights, string mode, double sigmaT, double sigmaR, out HTuple quality)
		{
			HTuple hTuple = HData.ConcatArray(poses);
			IntPtr expr_13 = SZXCArimAPI.PreCall(221);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.Store(expr_13, 1, weights);
			SZXCArimAPI.StoreS(expr_13, 2, mode);
			SZXCArimAPI.StoreD(expr_13, 3, sigmaT);
			SZXCArimAPI.StoreD(expr_13, 4, sigmaR);
			SZXCArimAPI.InitOCT(expr_13, 0);
			SZXCArimAPI.InitOCT(expr_13, 1);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(weights);
			HPose result;
			num = HPose.LoadNew(expr_13, 0, num, out result);
			num = HTuple.LoadNew(expr_13, 1, HTupleType.DOUBLE, num, out quality);
			SZXCArimAPI.PostCall(expr_13, num);
			return result;
		}

		public static HPose[] PoseInvert(HPose[] pose)
		{
			HTuple hTuple = HData.ConcatArray(pose);
			IntPtr expr_13 = SZXCArimAPI.PreCall(227);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			SZXCArimAPI.InitOCT(expr_13, 0);
			int num = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			HTuple data;
			num = HTuple.LoadNew(expr_13, 0, num, out data);
			SZXCArimAPI.PostCall(expr_13, num);
			return HPose.SplitArray(data);
		}

		public HPose PoseInvert()
		{
			IntPtr proc = SZXCArimAPI.PreCall(227);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HPose[] PoseCompose(HPose[] poseLeft, HPose[] poseRight)
		{
			HTuple hTuple = HData.ConcatArray(poseLeft);
			HTuple hTuple2 = HData.ConcatArray(poseRight);
			IntPtr expr_20 = SZXCArimAPI.PreCall(228);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, hTuple2);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HTuple data;
			num = HTuple.LoadNew(expr_20, 0, num, out data);
			SZXCArimAPI.PostCall(expr_20, num);
			return HPose.SplitArray(data);
		}

		public HPose PoseCompose(HPose poseRight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(228);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, poseRight);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(poseRight);
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage BinocularDistanceMs(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(346);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
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
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
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

		public HImage BinocularDistanceMs(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, int minDisparity, int maxDisparity, int surfaceSmoothing, int edgeSmoothing, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(346);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
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
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HImage BinocularDistanceMg(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, HTuple MGParamName, HTuple MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(348);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
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
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
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

		public HImage BinocularDistanceMg(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, double grayConstancy, double gradientConstancy, double smoothness, double initialGuess, string calculateScore, string MGParamName, string MGParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(348);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
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
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public HHomMat2D RelPoseToFundamentalMatrix(HTuple covRelPose, HCamPar camPar1, HCamPar camPar2, out HTuple covFMat)
		{
			IntPtr proc = SZXCArimAPI.PreCall(353);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, covRelPose);
			SZXCArimAPI.Store(proc, 2, camPar1);
			SZXCArimAPI.Store(proc, 3, camPar2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(covRelPose);
			SZXCArimAPI.UnpinTuple(camPar1);
			SZXCArimAPI.UnpinTuple(camPar2);
			HHomMat2D result;
			num = HHomMat2D.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out covFMat);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple VectorToRelPose(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, HCamPar camPar1, HCamPar camPar2, string method, out HTuple error, out HTuple x, out HTuple y, out HTuple z, out HTuple covXYZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(355);
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
			SZXCArimAPI.Store(proc, 10, camPar1);
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
			SZXCArimAPI.UnpinTuple(camPar1);
			SZXCArimAPI.UnpinTuple(camPar2);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out covXYZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple VectorToRelPose(HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HTuple covRR1, HTuple covRC1, HTuple covCC1, HTuple covRR2, HTuple covRC2, HTuple covCC2, HCamPar camPar1, HCamPar camPar2, string method, out double error, out HTuple x, out HTuple y, out HTuple z, out HTuple covXYZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(355);
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
			SZXCArimAPI.Store(proc, 10, camPar1);
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
			SZXCArimAPI.UnpinTuple(camPar1);
			SZXCArimAPI.UnpinTuple(camPar2);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadD(proc, 2, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out z);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out covXYZ);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MatchRelPoseRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HCamPar camPar1, HCamPar camPar2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, HTuple rotation, HTuple matchThreshold, string estimationMethod, HTuple distanceThreshold, int randSeed, out HTuple error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(359);
			SZXCArimAPI.Store(proc, 1, image1);
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
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out error);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out points1);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out points2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			return result;
		}

		public HTuple MatchRelPoseRansac(HImage image1, HImage image2, HTuple rows1, HTuple cols1, HTuple rows2, HTuple cols2, HCamPar camPar1, HCamPar camPar2, string grayMatchMethod, int maskSize, int rowMove, int colMove, int rowTolerance, int colTolerance, double rotation, int matchThreshold, string estimationMethod, double distanceThreshold, int randSeed, out double error, out HTuple points1, out HTuple points2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(359);
			SZXCArimAPI.Store(proc, 1, image1);
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

		public HImage BinocularDistance(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, string method, int maskWidth, int maskHeight, HTuple textureThresh, int minDisparity, int maxDisparity, int numLevels, HTuple scoreThresh, HTuple filter, HTuple subDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(362);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
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
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
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

		public HImage BinocularDistance(HImage imageRect1, HImage imageRect2, out HImage score, HCamPar camParamRect1, HCamPar camParamRect2, string method, int maskWidth, int maskHeight, double textureThresh, int minDisparity, int maxDisparity, int numLevels, double scoreThresh, string filter, string subDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(362);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, imageRect1);
			SZXCArimAPI.Store(proc, 2, imageRect2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
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
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageRect1);
			GC.KeepAlive(imageRect2);
			return result;
		}

		public void IntersectLinesOfSight(HCamPar camParam1, HCamPar camParam2, HTuple row1, HTuple col1, HTuple row2, HTuple col2, out HTuple x, out HTuple y, out HTuple z, out HTuple dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(364);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParam1);
			SZXCArimAPI.Store(proc, 1, camParam2);
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
			SZXCArimAPI.UnpinTuple(camParam1);
			SZXCArimAPI.UnpinTuple(camParam2);
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

		public void IntersectLinesOfSight(HCamPar camParam1, HCamPar camParam2, double row1, double col1, double row2, double col2, out double x, out double y, out double z, out double dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(364);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParam1);
			SZXCArimAPI.Store(proc, 1, camParam2);
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
			SZXCArimAPI.UnpinTuple(camParam1);
			SZXCArimAPI.UnpinTuple(camParam2);
			num = SZXCArimAPI.LoadD(proc, 0, num, out x);
			num = SZXCArimAPI.LoadD(proc, 1, num, out y);
			num = SZXCArimAPI.LoadD(proc, 2, num, out z);
			num = SZXCArimAPI.LoadD(proc, 3, num, out dist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HImage DisparityImageToXyz(HImage disparity, out HImage y, out HImage z, HCamPar camParamRect1, HCamPar camParamRect2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(365);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, disparity);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out y);
			num = HImage.LoadNew(proc, 3, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(disparity);
			return result;
		}

		public void DisparityToPoint3d(HCamPar camParamRect1, HCamPar camParamRect2, HTuple row1, HTuple col1, HTuple disparity, out HTuple x, out HTuple y, out HTuple z)
		{
			IntPtr proc = SZXCArimAPI.PreCall(366);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 3, row1);
			SZXCArimAPI.Store(proc, 4, col1);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(col1);
			SZXCArimAPI.UnpinTuple(disparity);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DisparityToPoint3d(HCamPar camParamRect1, HCamPar camParamRect2, double row1, double col1, double disparity, out double x, out double y, out double z)
		{
			IntPtr proc = SZXCArimAPI.PreCall(366);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.StoreD(proc, 3, row1);
			SZXCArimAPI.StoreD(proc, 4, col1);
			SZXCArimAPI.StoreD(proc, 5, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			num = SZXCArimAPI.LoadD(proc, 0, num, out x);
			num = SZXCArimAPI.LoadD(proc, 1, num, out y);
			num = SZXCArimAPI.LoadD(proc, 2, num, out z);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DisparityToDistance(HCamPar camParamRect1, HCamPar camParamRect2, HTuple disparity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(367);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 3, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(disparity);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double DisparityToDistance(HCamPar camParamRect1, HCamPar camParamRect2, double disparity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(367);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.StoreD(proc, 3, disparity);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DistanceToDisparity(HCamPar camParamRect1, HCamPar camParamRect2, HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(368);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.Store(proc, 3, distance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			SZXCArimAPI.UnpinTuple(distance);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double DistanceToDisparity(HCamPar camParamRect1, HCamPar camParamRect2, double distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(368);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParamRect1);
			SZXCArimAPI.Store(proc, 1, camParamRect2);
			SZXCArimAPI.StoreD(proc, 3, distance);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenBinocularRectificationMap(out HImage map2, HCamPar camParam1, HCamPar camParam2, double subSampling, string method, string mapType, out HCamPar camParamRect1, out HCamPar camParamRect2, out HPose camPoseRect1, out HPose camPoseRect2, out HPose relPoseRect)
		{
			IntPtr proc = SZXCArimAPI.PreCall(369);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, camParam1);
			SZXCArimAPI.Store(proc, 1, camParam2);
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
			SZXCArimAPI.UnpinTuple(camParam1);
			SZXCArimAPI.UnpinTuple(camParam2);
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

		public static HCamPar BinocularCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow1, HTuple NCol1, HTuple NRow2, HTuple NCol2, HCamPar startCamParam1, HCamPar startCamParam2, HPose[] NStartPose1, HPose[] NStartPose2, HTuple estimateParams, out HCamPar camParam2, out HPose[] NFinalPose1, out HPose[] NFinalPose2, out HPose relPose, out HTuple errors)
		{
			HTuple hTuple = HData.ConcatArray(NStartPose1);
			HTuple hTuple2 = HData.ConcatArray(NStartPose2);
			IntPtr expr_22 = SZXCArimAPI.PreCall(370);
			SZXCArimAPI.Store(expr_22, 0, NX);
			SZXCArimAPI.Store(expr_22, 1, NY);
			SZXCArimAPI.Store(expr_22, 2, NZ);
			SZXCArimAPI.Store(expr_22, 3, NRow1);
			SZXCArimAPI.Store(expr_22, 4, NCol1);
			SZXCArimAPI.Store(expr_22, 5, NRow2);
			SZXCArimAPI.Store(expr_22, 6, NCol2);
			SZXCArimAPI.Store(expr_22, 7, startCamParam1);
			SZXCArimAPI.Store(expr_22, 8, startCamParam2);
			SZXCArimAPI.Store(expr_22, 9, hTuple);
			SZXCArimAPI.Store(expr_22, 10, hTuple2);
			SZXCArimAPI.Store(expr_22, 11, estimateParams);
			SZXCArimAPI.InitOCT(expr_22, 0);
			SZXCArimAPI.InitOCT(expr_22, 1);
			SZXCArimAPI.InitOCT(expr_22, 2);
			SZXCArimAPI.InitOCT(expr_22, 3);
			SZXCArimAPI.InitOCT(expr_22, 4);
			SZXCArimAPI.InitOCT(expr_22, 5);
			int num = SZXCArimAPI.CallProcedure(expr_22);
			SZXCArimAPI.UnpinTuple(NX);
			SZXCArimAPI.UnpinTuple(NY);
			SZXCArimAPI.UnpinTuple(NZ);
			SZXCArimAPI.UnpinTuple(NRow1);
			SZXCArimAPI.UnpinTuple(NCol1);
			SZXCArimAPI.UnpinTuple(NRow2);
			SZXCArimAPI.UnpinTuple(NCol2);
			SZXCArimAPI.UnpinTuple(startCamParam1);
			SZXCArimAPI.UnpinTuple(startCamParam2);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(estimateParams);
			HCamPar result;
			num = HCamPar.LoadNew(expr_22, 0, num, out result);
			num = HCamPar.LoadNew(expr_22, 1, num, out camParam2);
			HTuple data;
			num = HTuple.LoadNew(expr_22, 2, num, out data);
			HTuple data2;
			num = HTuple.LoadNew(expr_22, 3, num, out data2);
			num = HPose.LoadNew(expr_22, 4, num, out relPose);
			num = HTuple.LoadNew(expr_22, 5, HTupleType.DOUBLE, num, out errors);
			SZXCArimAPI.PostCall(expr_22, num);
			NFinalPose1 = HPose.SplitArray(data);
			NFinalPose2 = HPose.SplitArray(data2);
			return result;
		}

		public HCamPar BinocularCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow1, HTuple NCol1, HTuple NRow2, HTuple NCol2, HCamPar startCamParam1, HCamPar startCamParam2, HPose NStartPose2, HTuple estimateParams, out HCamPar camParam2, out HPose NFinalPose1, out HPose NFinalPose2, out HPose relPose, out double errors)
		{
			IntPtr proc = SZXCArimAPI.PreCall(370);
			base.Store(proc, 9);
			SZXCArimAPI.Store(proc, 0, NX);
			SZXCArimAPI.Store(proc, 1, NY);
			SZXCArimAPI.Store(proc, 2, NZ);
			SZXCArimAPI.Store(proc, 3, NRow1);
			SZXCArimAPI.Store(proc, 4, NCol1);
			SZXCArimAPI.Store(proc, 5, NRow2);
			SZXCArimAPI.Store(proc, 6, NCol2);
			SZXCArimAPI.Store(proc, 7, startCamParam1);
			SZXCArimAPI.Store(proc, 8, startCamParam2);
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
			SZXCArimAPI.UnpinTuple(startCamParam1);
			SZXCArimAPI.UnpinTuple(startCamParam2);
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

		public static HTuple FindCalibDescriptorModel(HImage image, HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, HTuple minScore, int numMatches, HCamPar camParam, HTuple scoreType, out HPose[] pose)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(948);
			SZXCArimAPI.Store(expr_0A, 1, image);
			SZXCArimAPI.Store(expr_0A, 0, modelID);
			SZXCArimAPI.Store(expr_0A, 1, detectorParamName);
			SZXCArimAPI.Store(expr_0A, 2, detectorParamValue);
			SZXCArimAPI.Store(expr_0A, 3, descriptorParamName);
			SZXCArimAPI.Store(expr_0A, 4, descriptorParamValue);
			SZXCArimAPI.Store(expr_0A, 5, minScore);
			SZXCArimAPI.StoreI(expr_0A, 6, numMatches);
			SZXCArimAPI.Store(expr_0A, 7, camParam);
			SZXCArimAPI.Store(expr_0A, 8, scoreType);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(detectorParamName);
			SZXCArimAPI.UnpinTuple(detectorParamValue);
			SZXCArimAPI.UnpinTuple(descriptorParamName);
			SZXCArimAPI.UnpinTuple(descriptorParamValue);
			SZXCArimAPI.UnpinTuple(minScore);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(scoreType);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 1, num, out result);
			HTuple data;
			num = HTuple.LoadNew(expr_0A, 0, num, out data);
			SZXCArimAPI.PostCall(expr_0A, num);
			pose = HPose.SplitArray(data);
			GC.KeepAlive(image);
			GC.KeepAlive(modelID);
			return result;
		}

		public double FindCalibDescriptorModel(HImage image, HDescriptorModel modelID, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, double minScore, int numMatches, HCamPar camParam, string scoreType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(948);
			SZXCArimAPI.Store(proc, 1, image);
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
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(modelID);
			return result;
		}

		public HDescriptorModel CreateCalibDescriptorModel(HImage template, HCamPar camParam, string detectorType, HTuple detectorParamName, HTuple detectorParamValue, HTuple descriptorParamName, HTuple descriptorParamValue, int seed)
		{
			IntPtr proc = SZXCArimAPI.PreCall(952);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
			SZXCArimAPI.StoreS(proc, 2, detectorType);
			SZXCArimAPI.Store(proc, 3, detectorParamName);
			SZXCArimAPI.Store(proc, 4, detectorParamValue);
			SZXCArimAPI.Store(proc, 5, descriptorParamName);
			SZXCArimAPI.Store(proc, 6, descriptorParamValue);
			SZXCArimAPI.StoreI(proc, 7, seed);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
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

		public HDeformableModel CreatePlanarCalibDeformableModelXld(HXLDCont contours, HCamPar camParam, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, camParam);
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
			SZXCArimAPI.UnpinTuple(camParam);
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

		public HDeformableModel CreatePlanarCalibDeformableModelXld(HXLDCont contours, HCamPar camParam, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, camParam);
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
			SZXCArimAPI.UnpinTuple(camParam);
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

		public HDeformableModel CreatePlanarCalibDeformableModel(HImage template, HCamPar camParam, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, HTuple contrast, HTuple minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
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
			SZXCArimAPI.UnpinTuple(camParam);
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

		public HDeformableModel CreatePlanarCalibDeformableModel(HImage template, HCamPar camParam, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, HTuple contrast, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(979);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.Store(proc, 0, camParam);
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
			SZXCArimAPI.UnpinTuple(camParam);
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

		public static HPose[] CreateCamPoseLookAtPoint(HTuple camPosX, HTuple camPosY, HTuple camPosZ, HTuple lookAtX, HTuple lookAtY, HTuple lookAtZ, HTuple refPlaneNormal, HTuple camRoll)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1045);
			SZXCArimAPI.Store(expr_0A, 0, camPosX);
			SZXCArimAPI.Store(expr_0A, 1, camPosY);
			SZXCArimAPI.Store(expr_0A, 2, camPosZ);
			SZXCArimAPI.Store(expr_0A, 3, lookAtX);
			SZXCArimAPI.Store(expr_0A, 4, lookAtY);
			SZXCArimAPI.Store(expr_0A, 5, lookAtZ);
			SZXCArimAPI.Store(expr_0A, 6, refPlaneNormal);
			SZXCArimAPI.Store(expr_0A, 7, camRoll);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(camPosX);
			SZXCArimAPI.UnpinTuple(camPosY);
			SZXCArimAPI.UnpinTuple(camPosZ);
			SZXCArimAPI.UnpinTuple(lookAtX);
			SZXCArimAPI.UnpinTuple(lookAtY);
			SZXCArimAPI.UnpinTuple(lookAtZ);
			SZXCArimAPI.UnpinTuple(refPlaneNormal);
			SZXCArimAPI.UnpinTuple(camRoll);
			HTuple data;
			num = HTuple.LoadNew(expr_0A, 0, num, out data);
			SZXCArimAPI.PostCall(expr_0A, num);
			return HPose.SplitArray(data);
		}

		public void CreateCamPoseLookAtPoint(double camPosX, double camPosY, double camPosZ, double lookAtX, double lookAtY, double lookAtZ, HTuple refPlaneNormal, double camRoll)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1045);
			SZXCArimAPI.StoreD(proc, 0, camPosX);
			SZXCArimAPI.StoreD(proc, 1, camPosY);
			SZXCArimAPI.StoreD(proc, 2, camPosZ);
			SZXCArimAPI.StoreD(proc, 3, lookAtX);
			SZXCArimAPI.StoreD(proc, 4, lookAtY);
			SZXCArimAPI.StoreD(proc, 5, lookAtZ);
			SZXCArimAPI.Store(proc, 6, refPlaneNormal);
			SZXCArimAPI.StoreD(proc, 7, camRoll);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(refPlaneNormal);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HPose TransPoseShapeModel3d(HShapeModel3D shapeModel3DID, string transformation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1054);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, shapeModel3DID);
			SZXCArimAPI.StoreS(proc, 2, transformation);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(shapeModel3DID);
			return result;
		}

		public HXLDCont ProjectShapeModel3d(HShapeModel3D shapeModel3DID, HCamPar camParam, string hiddenSurfaceRemoval, HTuple minFaceAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1055);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, shapeModel3DID);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
			SZXCArimAPI.Store(proc, 4, minFaceAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(minFaceAngle);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(shapeModel3DID);
			return result;
		}

		public HXLDCont ProjectShapeModel3d(HShapeModel3D shapeModel3DID, HCamPar camParam, string hiddenSurfaceRemoval, double minFaceAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1055);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, shapeModel3DID);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
			SZXCArimAPI.StoreD(proc, 4, minFaceAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(shapeModel3DID);
			return result;
		}

		public static HObjectModel3D[] ReduceObjectModel3dByView(HRegion region, HObjectModel3D[] objectModel3D, HCamPar camParam, HPose[] pose)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1084);
			SZXCArimAPI.Store(expr_20, 1, region);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, camParam);
			SZXCArimAPI.Store(expr_20, 2, hTuple2);
			SZXCArimAPI.InitOCT(expr_20, 0);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(hTuple2);
			HObjectModel3D[] result;
			num = HObjectModel3D.LoadNew(expr_20, 0, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(region);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D ReduceObjectModel3dByView(HRegion region, HObjectModel3D objectModel3D, HCamPar camParam)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1084);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, region);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
			HObjectModel3D result;
			num = HObjectModel3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public static HImage RenderObjectModel3d(HObjectModel3D[] objectModel3D, HCamPar camParam, HPose[] pose, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr expr_20 = SZXCArimAPI.PreCall(1088);
			SZXCArimAPI.Store(expr_20, 0, hTuple);
			SZXCArimAPI.Store(expr_20, 1, camParam);
			SZXCArimAPI.Store(expr_20, 2, hTuple2);
			SZXCArimAPI.Store(expr_20, 3, genParamName);
			SZXCArimAPI.Store(expr_20, 4, genParamValue);
			SZXCArimAPI.InitOCT(expr_20, 1);
			int num = SZXCArimAPI.CallProcedure(expr_20);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(expr_20, 1, num, out result);
			SZXCArimAPI.PostCall(expr_20, num);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HImage RenderObjectModel3d(HObjectModel3D objectModel3D, HCamPar camParam, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1088);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public static void DispObjectModel3d(HWindow windowHandle, HObjectModel3D[] objectModel3D, HCamPar camParam, HPose[] pose, HTuple genParamName, HTuple genParamValue)
		{
			HTuple hTuple = HHandleBase.ConcatArray(objectModel3D);
			HTuple hTuple2 = HData.ConcatArray(pose);
			IntPtr expr_1E = SZXCArimAPI.PreCall(1089);
			SZXCArimAPI.Store(expr_1E, 0, windowHandle);
			SZXCArimAPI.Store(expr_1E, 1, hTuple);
			SZXCArimAPI.Store(expr_1E, 2, camParam);
			SZXCArimAPI.Store(expr_1E, 3, hTuple2);
			SZXCArimAPI.Store(expr_1E, 4, genParamName);
			SZXCArimAPI.Store(expr_1E, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(expr_1E);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(hTuple2);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(expr_1E, procResult);
			GC.KeepAlive(windowHandle);
			GC.KeepAlive(objectModel3D);
		}

		public void DispObjectModel3d(HWindow windowHandle, HObjectModel3D objectModel3D, HCamPar camParam, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1089);
			base.Store(proc, 3);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.Store(proc, 1, objectModel3D);
			SZXCArimAPI.Store(proc, 2, camParam);
			SZXCArimAPI.Store(proc, 4, genParamName);
			SZXCArimAPI.Store(proc, 5, genParamValue);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			GC.KeepAlive(objectModel3D);
		}

		public HXLDCont ProjectObjectModel3d(HObjectModel3D objectModel3D, HCamPar camParam, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1095);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.Store(proc, 3, genParamName);
			SZXCArimAPI.Store(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HXLDCont ProjectObjectModel3d(HObjectModel3D objectModel3D, HCamPar camParam, string genParamName, string genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1095);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 0, objectModel3D);
			SZXCArimAPI.Store(proc, 1, camParam);
			SZXCArimAPI.StoreS(proc, 3, genParamName);
			SZXCArimAPI.StoreS(proc, 4, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParam);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectModel3D);
			return result;
		}

		public HObjectModel3D[] SceneFlowCalib(HImage imageRect1T1, HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, HTuple smoothingFlow, HTuple smoothingDisparity, HTuple genParamName, HTuple genParamValue, HCamPar camParamRect1, HCamPar camParamRect2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1481);
			base.Store(proc, 6);
			SZXCArimAPI.Store(proc, 1, imageRect1T1);
			SZXCArimAPI.Store(proc, 2, imageRect2T1);
			SZXCArimAPI.Store(proc, 3, imageRect1T2);
			SZXCArimAPI.Store(proc, 4, imageRect2T2);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.Store(proc, 0, smoothingFlow);
			SZXCArimAPI.Store(proc, 1, smoothingDisparity);
			SZXCArimAPI.Store(proc, 2, genParamName);
			SZXCArimAPI.Store(proc, 3, genParamValue);
			SZXCArimAPI.Store(proc, 4, camParamRect1);
			SZXCArimAPI.Store(proc, 5, camParamRect2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(smoothingFlow);
			SZXCArimAPI.UnpinTuple(smoothingDisparity);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
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

		public HObjectModel3D SceneFlowCalib(HImage imageRect1T1, HImage imageRect2T1, HImage imageRect1T2, HImage imageRect2T2, HImage disparity, double smoothingFlow, double smoothingDisparity, string genParamName, string genParamValue, HCamPar camParamRect1, HCamPar camParamRect2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1481);
			base.Store(proc, 6);
			SZXCArimAPI.Store(proc, 1, imageRect1T1);
			SZXCArimAPI.Store(proc, 2, imageRect2T1);
			SZXCArimAPI.Store(proc, 3, imageRect1T2);
			SZXCArimAPI.Store(proc, 4, imageRect2T2);
			SZXCArimAPI.Store(proc, 5, disparity);
			SZXCArimAPI.StoreD(proc, 0, smoothingFlow);
			SZXCArimAPI.StoreD(proc, 1, smoothingDisparity);
			SZXCArimAPI.StoreS(proc, 2, genParamName);
			SZXCArimAPI.StoreS(proc, 3, genParamValue);
			SZXCArimAPI.Store(proc, 4, camParamRect1);
			SZXCArimAPI.Store(proc, 5, camParamRect2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(camParamRect1);
			SZXCArimAPI.UnpinTuple(camParamRect2);
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

		public HTuple VectorToPose(HTuple worldX, HTuple worldY, HTuple worldZ, HTuple imageRow, HTuple imageColumn, HCamPar cameraParam, string method, HTuple qualityType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1902);
			SZXCArimAPI.Store(proc, 0, worldX);
			SZXCArimAPI.Store(proc, 1, worldY);
			SZXCArimAPI.Store(proc, 2, worldZ);
			SZXCArimAPI.Store(proc, 3, imageRow);
			SZXCArimAPI.Store(proc, 4, imageColumn);
			SZXCArimAPI.Store(proc, 5, cameraParam);
			SZXCArimAPI.StoreS(proc, 6, method);
			SZXCArimAPI.Store(proc, 7, qualityType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(worldX);
			SZXCArimAPI.UnpinTuple(worldY);
			SZXCArimAPI.UnpinTuple(worldZ);
			SZXCArimAPI.UnpinTuple(imageRow);
			SZXCArimAPI.UnpinTuple(imageColumn);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(qualityType);
			num = base.Load(proc, 0, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double VectorToPose(HTuple worldX, HTuple worldY, HTuple worldZ, HTuple imageRow, HTuple imageColumn, HCamPar cameraParam, string method, string qualityType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1902);
			SZXCArimAPI.Store(proc, 0, worldX);
			SZXCArimAPI.Store(proc, 1, worldY);
			SZXCArimAPI.Store(proc, 2, worldZ);
			SZXCArimAPI.Store(proc, 3, imageRow);
			SZXCArimAPI.Store(proc, 4, imageColumn);
			SZXCArimAPI.Store(proc, 5, cameraParam);
			SZXCArimAPI.StoreS(proc, 6, method);
			SZXCArimAPI.StoreS(proc, 7, qualityType);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(worldX);
			SZXCArimAPI.UnpinTuple(worldY);
			SZXCArimAPI.UnpinTuple(worldZ);
			SZXCArimAPI.UnpinTuple(imageRow);
			SZXCArimAPI.UnpinTuple(imageColumn);
			SZXCArimAPI.UnpinTuple(cameraParam);
			num = base.Load(proc, 0, num);
			double result;
			num = SZXCArimAPI.LoadD(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenImageToWorldPlaneMap(HCamPar cameraParam, int widthIn, int heightIn, int widthMapped, int heightMapped, HTuple scale, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1913);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.StoreI(proc, 2, widthIn);
			SZXCArimAPI.StoreI(proc, 3, heightIn);
			SZXCArimAPI.StoreI(proc, 4, widthMapped);
			SZXCArimAPI.StoreI(proc, 5, heightMapped);
			SZXCArimAPI.Store(proc, 6, scale);
			SZXCArimAPI.StoreS(proc, 7, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(scale);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage GenImageToWorldPlaneMap(HCamPar cameraParam, int widthIn, int heightIn, int widthMapped, int heightMapped, string scale, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1913);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.StoreI(proc, 2, widthIn);
			SZXCArimAPI.StoreI(proc, 3, heightIn);
			SZXCArimAPI.StoreI(proc, 4, widthMapped);
			SZXCArimAPI.StoreI(proc, 5, heightMapped);
			SZXCArimAPI.StoreS(proc, 6, scale);
			SZXCArimAPI.StoreS(proc, 7, mapType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ImageToWorldPlane(HImage image, HCamPar cameraParam, int width, int height, HTuple scale, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1914);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.Store(proc, 4, scale);
			SZXCArimAPI.StoreS(proc, 5, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(scale);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage ImageToWorldPlane(HImage image, HCamPar cameraParam, int width, int height, string scale, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1914);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.StoreI(proc, 2, width);
			SZXCArimAPI.StoreI(proc, 3, height);
			SZXCArimAPI.StoreS(proc, 4, scale);
			SZXCArimAPI.StoreS(proc, 5, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HXLDCont ContourToWorldPlaneXld(HXLDCont contours, HTuple cameraParam, HTuple scale)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1915);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 2, scale);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(scale);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public HXLDCont ContourToWorldPlaneXld(HXLDCont contours, HTuple cameraParam, string scale)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1915);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 1, contours);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.StoreS(proc, 2, scale);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours);
			return result;
		}

		public HPose SetOriginPose(double DX, double DY, double DZ)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1917);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, DX);
			SZXCArimAPI.StoreD(proc, 2, DY);
			SZXCArimAPI.StoreD(proc, 3, DZ);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HPose HandEyeCalibration(HTuple x, HTuple y, HTuple z, HTuple row, HTuple col, HTuple numPoints, HPose[] robotPoses, HCamPar cameraParam, string method, HTuple qualityType, out HPose calibrationPose, out HTuple quality)
		{
			HTuple hTuple = HData.ConcatArray(robotPoses);
			IntPtr expr_14 = SZXCArimAPI.PreCall(1918);
			SZXCArimAPI.Store(expr_14, 0, x);
			SZXCArimAPI.Store(expr_14, 1, y);
			SZXCArimAPI.Store(expr_14, 2, z);
			SZXCArimAPI.Store(expr_14, 3, row);
			SZXCArimAPI.Store(expr_14, 4, col);
			SZXCArimAPI.Store(expr_14, 5, numPoints);
			SZXCArimAPI.Store(expr_14, 6, hTuple);
			SZXCArimAPI.Store(expr_14, 7, cameraParam);
			SZXCArimAPI.StoreS(expr_14, 8, method);
			SZXCArimAPI.Store(expr_14, 9, qualityType);
			SZXCArimAPI.InitOCT(expr_14, 0);
			SZXCArimAPI.InitOCT(expr_14, 1);
			SZXCArimAPI.InitOCT(expr_14, 2);
			int num = SZXCArimAPI.CallProcedure(expr_14);
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(numPoints);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(qualityType);
			HPose result;
			num = HPose.LoadNew(expr_14, 0, num, out result);
			num = HPose.LoadNew(expr_14, 1, num, out calibrationPose);
			num = HTuple.LoadNew(expr_14, 2, HTupleType.DOUBLE, num, out quality);
			SZXCArimAPI.PostCall(expr_14, num);
			return result;
		}

		public static HPose HandEyeCalibration(HTuple x, HTuple y, HTuple z, HTuple row, HTuple col, HTuple numPoints, HPose[] robotPoses, HCamPar cameraParam, string method, string qualityType, out HPose calibrationPose, out double quality)
		{
			HTuple hTuple = HData.ConcatArray(robotPoses);
			IntPtr expr_14 = SZXCArimAPI.PreCall(1918);
			SZXCArimAPI.Store(expr_14, 0, x);
			SZXCArimAPI.Store(expr_14, 1, y);
			SZXCArimAPI.Store(expr_14, 2, z);
			SZXCArimAPI.Store(expr_14, 3, row);
			SZXCArimAPI.Store(expr_14, 4, col);
			SZXCArimAPI.Store(expr_14, 5, numPoints);
			SZXCArimAPI.Store(expr_14, 6, hTuple);
			SZXCArimAPI.Store(expr_14, 7, cameraParam);
			SZXCArimAPI.StoreS(expr_14, 8, method);
			SZXCArimAPI.StoreS(expr_14, 9, qualityType);
			SZXCArimAPI.InitOCT(expr_14, 0);
			SZXCArimAPI.InitOCT(expr_14, 1);
			SZXCArimAPI.InitOCT(expr_14, 2);
			int num = SZXCArimAPI.CallProcedure(expr_14);
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(numPoints);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(cameraParam);
			HPose result;
			num = HPose.LoadNew(expr_14, 0, num, out result);
			num = HPose.LoadNew(expr_14, 1, num, out calibrationPose);
			num = SZXCArimAPI.LoadD(expr_14, 2, num, out quality);
			SZXCArimAPI.PostCall(expr_14, num);
			return result;
		}

		public string GetPoseType(out string orderOfRotation, out string viewOfTransform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1919);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadS(proc, 1, num, out orderOfRotation);
			num = SZXCArimAPI.LoadS(proc, 2, num, out viewOfTransform);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HPose ConvertPoseType(string orderOfTransform, string orderOfRotation, string viewOfTransform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1920);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, orderOfTransform);
			SZXCArimAPI.StoreS(proc, 2, orderOfRotation);
			SZXCArimAPI.StoreS(proc, 3, viewOfTransform);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HPose result;
			num = HPose.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void CreatePose(double transX, double transY, double transZ, double rotX, double rotY, double rotZ, string orderOfTransform, string orderOfRotation, string viewOfTransform)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1921);
			SZXCArimAPI.StoreD(proc, 0, transX);
			SZXCArimAPI.StoreD(proc, 1, transY);
			SZXCArimAPI.StoreD(proc, 2, transZ);
			SZXCArimAPI.StoreD(proc, 3, rotX);
			SZXCArimAPI.StoreD(proc, 4, rotY);
			SZXCArimAPI.StoreD(proc, 5, rotZ);
			SZXCArimAPI.StoreS(proc, 6, orderOfTransform);
			SZXCArimAPI.StoreS(proc, 7, orderOfRotation);
			SZXCArimAPI.StoreS(proc, 8, viewOfTransform);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HHomMat3D CamParPoseToHomMat3d(HCamPar cameraParam)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1933);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HHomMat3D PoseToHomMat3d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1935);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HHomMat3D result;
			num = HHomMat3D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializePose(HSerializedItem serializedItemHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1938);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializePose()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1939);
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

		public void ReadPose(string poseFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1940);
			SZXCArimAPI.StoreS(proc, 0, poseFile);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WritePose(string poseFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1941);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, poseFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage SimCaltab(string calPlateDescr, HCamPar cameraParam, int grayBackground, int grayPlate, int grayMarks, double scaleFac)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1944);
			base.Store(proc, 2);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
			SZXCArimAPI.Store(proc, 1, cameraParam);
			SZXCArimAPI.StoreI(proc, 3, grayBackground);
			SZXCArimAPI.StoreI(proc, 4, grayPlate);
			SZXCArimAPI.StoreI(proc, 5, grayMarks);
			SZXCArimAPI.StoreD(proc, 6, scaleFac);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(cameraParam);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public static HCamPar CameraCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow, HTuple NCol, HCamPar startCamParam, HPose[] NStartPose, HTuple estimateParams, out HPose[] NFinalPose, out HTuple errors)
		{
			HTuple hTuple = HData.ConcatArray(NStartPose);
			IntPtr expr_16 = SZXCArimAPI.PreCall(1946);
			SZXCArimAPI.Store(expr_16, 0, NX);
			SZXCArimAPI.Store(expr_16, 1, NY);
			SZXCArimAPI.Store(expr_16, 2, NZ);
			SZXCArimAPI.Store(expr_16, 3, NRow);
			SZXCArimAPI.Store(expr_16, 4, NCol);
			SZXCArimAPI.Store(expr_16, 5, startCamParam);
			SZXCArimAPI.Store(expr_16, 6, hTuple);
			SZXCArimAPI.Store(expr_16, 7, estimateParams);
			SZXCArimAPI.InitOCT(expr_16, 0);
			SZXCArimAPI.InitOCT(expr_16, 1);
			SZXCArimAPI.InitOCT(expr_16, 2);
			int num = SZXCArimAPI.CallProcedure(expr_16);
			SZXCArimAPI.UnpinTuple(NX);
			SZXCArimAPI.UnpinTuple(NY);
			SZXCArimAPI.UnpinTuple(NZ);
			SZXCArimAPI.UnpinTuple(NRow);
			SZXCArimAPI.UnpinTuple(NCol);
			SZXCArimAPI.UnpinTuple(startCamParam);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.UnpinTuple(estimateParams);
			HCamPar result;
			num = HCamPar.LoadNew(expr_16, 0, num, out result);
			HTuple data;
			num = HTuple.LoadNew(expr_16, 1, num, out data);
			num = HTuple.LoadNew(expr_16, 2, HTupleType.DOUBLE, num, out errors);
			SZXCArimAPI.PostCall(expr_16, num);
			NFinalPose = HPose.SplitArray(data);
			return result;
		}

		public HCamPar CameraCalibration(HTuple NX, HTuple NY, HTuple NZ, HTuple NRow, HTuple NCol, HCamPar startCamParam, HTuple estimateParams, out HPose NFinalPose, out double errors)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1946);
			base.Store(proc, 6);
			SZXCArimAPI.Store(proc, 0, NX);
			SZXCArimAPI.Store(proc, 1, NY);
			SZXCArimAPI.Store(proc, 2, NZ);
			SZXCArimAPI.Store(proc, 3, NRow);
			SZXCArimAPI.Store(proc, 4, NCol);
			SZXCArimAPI.Store(proc, 5, startCamParam);
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
			SZXCArimAPI.UnpinTuple(startCamParam);
			SZXCArimAPI.UnpinTuple(estimateParams);
			HCamPar result;
			num = HCamPar.LoadNew(proc, 0, num, out result);
			num = HPose.LoadNew(proc, 1, num, out NFinalPose);
			num = SZXCArimAPI.LoadD(proc, 2, num, out errors);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple FindMarksAndPose(HImage image, HRegion calPlateRegion, string calPlateDescr, HCamPar startCamParam, int startThresh, int deltaThresh, int minThresh, double alpha, double minContLength, double maxDiamMarks, out HTuple CCoord)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1947);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 2, calPlateRegion);
			SZXCArimAPI.StoreS(proc, 0, calPlateDescr);
			SZXCArimAPI.Store(proc, 1, startCamParam);
			SZXCArimAPI.StoreI(proc, 2, startThresh);
			SZXCArimAPI.StoreI(proc, 3, deltaThresh);
			SZXCArimAPI.StoreI(proc, 4, minThresh);
			SZXCArimAPI.StoreD(proc, 5, alpha);
			SZXCArimAPI.StoreD(proc, 6, minContLength);
			SZXCArimAPI.StoreD(proc, 7, maxDiamMarks);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(startCamParam);
			num = base.Load(proc, 2, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out CCoord);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(calPlateRegion);
			return result;
		}

		public static void SetCameraSetupCamParam(HCameraSetupModel cameraSetupModelID, HTuple cameraIdx, HTuple cameraType, HCamPar cameraParam, HTuple cameraPose)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1957);
			SZXCArimAPI.Store(expr_0A, 0, cameraSetupModelID);
			SZXCArimAPI.Store(expr_0A, 1, cameraIdx);
			SZXCArimAPI.Store(expr_0A, 2, cameraType);
			SZXCArimAPI.Store(expr_0A, 3, cameraParam);
			SZXCArimAPI.Store(expr_0A, 4, cameraPose);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraType);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(cameraPose);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(cameraSetupModelID);
		}

		public static void SetCameraSetupCamParam(HCameraSetupModel cameraSetupModelID, HTuple cameraIdx, string cameraType, HCamPar cameraParam, HTuple cameraPose)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1957);
			SZXCArimAPI.Store(expr_0A, 0, cameraSetupModelID);
			SZXCArimAPI.Store(expr_0A, 1, cameraIdx);
			SZXCArimAPI.StoreS(expr_0A, 2, cameraType);
			SZXCArimAPI.Store(expr_0A, 3, cameraParam);
			SZXCArimAPI.Store(expr_0A, 4, cameraPose);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(cameraIdx);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(cameraPose);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(cameraSetupModelID);
		}
	}
}
