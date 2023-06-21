using System;

namespace SZXCArimEngine
{
	public class HMisc
	{
		public static void WriteTuple(HTuple tuple, string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(219);
			SZXCArimAPI.Store(expr_0A, 0, tuple);
			SZXCArimAPI.StoreS(expr_0A, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(tuple);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple ReadTuple(string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(220);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void CloseAllSerials()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(312);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void CloseAllOcvs()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(644);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void CloseAllOcrs()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(724);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void ConcatOcrTrainf(HTuple singleFiles, string composedFile)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(728);
			SZXCArimAPI.Store(expr_0A, 0, singleFiles);
			SZXCArimAPI.StoreS(expr_0A, 1, composedFile);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(singleFiles);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void ConcatOcrTrainf(string singleFiles, string composedFile)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(728);
			SZXCArimAPI.StoreS(expr_0A, 0, singleFiles);
			SZXCArimAPI.StoreS(expr_0A, 1, composedFile);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple ReadOcrTrainfNamesProtected(HTuple trainingFile, HTuple password, out HTuple characterCount)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(731);
			SZXCArimAPI.Store(expr_0A, 0, trainingFile);
			SZXCArimAPI.Store(expr_0A, 1, password);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(trainingFile);
			SZXCArimAPI.UnpinTuple(password);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out characterCount);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string ReadOcrTrainfNamesProtected(string trainingFile, string password, out int characterCount)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(731);
			SZXCArimAPI.StoreS(expr_0A, 0, trainingFile);
			SZXCArimAPI.StoreS(expr_0A, 1, password);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadI(expr_0A, 1, num, out characterCount);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple ReadOcrTrainfNames(HTuple trainingFile, out HTuple characterCount)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(732);
			SZXCArimAPI.Store(expr_0A, 0, trainingFile);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(trainingFile);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out characterCount);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static string ReadOcrTrainfNames(string trainingFile, out int characterCount)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(732);
			SZXCArimAPI.StoreS(expr_0A, 0, trainingFile);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadI(expr_0A, 1, num, out characterCount);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void CloseAllMeasures()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(826);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void ConvertPoint3dSpherToCart(HTuple longitude, HTuple latitude, HTuple radius, string equatPlaneNormal, string zeroMeridian, out HTuple x, out HTuple y, out HTuple z)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1046);
			SZXCArimAPI.Store(expr_0A, 0, longitude);
			SZXCArimAPI.Store(expr_0A, 1, latitude);
			SZXCArimAPI.Store(expr_0A, 2, radius);
			SZXCArimAPI.StoreS(expr_0A, 3, equatPlaneNormal);
			SZXCArimAPI.StoreS(expr_0A, 4, zeroMeridian);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(longitude);
			SZXCArimAPI.UnpinTuple(latitude);
			SZXCArimAPI.UnpinTuple(radius);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out z);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void ConvertPoint3dSpherToCart(double longitude, double latitude, double radius, string equatPlaneNormal, string zeroMeridian, out double x, out double y, out double z)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1046);
			SZXCArimAPI.StoreD(expr_0A, 0, longitude);
			SZXCArimAPI.StoreD(expr_0A, 1, latitude);
			SZXCArimAPI.StoreD(expr_0A, 2, radius);
			SZXCArimAPI.StoreS(expr_0A, 3, equatPlaneNormal);
			SZXCArimAPI.StoreS(expr_0A, 4, zeroMeridian);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out x);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out y);
			num = SZXCArimAPI.LoadD(expr_0A, 2, num, out z);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static HTuple ConvertPoint3dCartToSpher(HTuple x, HTuple y, HTuple z, string equatPlaneNormal, string zeroMeridian, out HTuple latitude, out HTuple radius)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1047);
			SZXCArimAPI.Store(expr_0A, 0, x);
			SZXCArimAPI.Store(expr_0A, 1, y);
			SZXCArimAPI.Store(expr_0A, 2, z);
			SZXCArimAPI.StoreS(expr_0A, 3, equatPlaneNormal);
			SZXCArimAPI.StoreS(expr_0A, 4, zeroMeridian);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(x);
			SZXCArimAPI.UnpinTuple(y);
			SZXCArimAPI.UnpinTuple(z);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out latitude);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out radius);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static double ConvertPoint3dCartToSpher(double x, double y, double z, string equatPlaneNormal, string zeroMeridian, out double latitude, out double radius)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1047);
			SZXCArimAPI.StoreD(expr_0A, 0, x);
			SZXCArimAPI.StoreD(expr_0A, 1, y);
			SZXCArimAPI.StoreD(expr_0A, 2, z);
			SZXCArimAPI.StoreS(expr_0A, 3, equatPlaneNormal);
			SZXCArimAPI.StoreS(expr_0A, 4, zeroMeridian);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			double result;
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out result);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out latitude);
			num = SZXCArimAPI.LoadD(expr_0A, 2, num, out radius);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple ReadKalman(string fileName, out HTuple model, out HTuple measurement, out HTuple prediction)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1105);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out model);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out measurement);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.DOUBLE, num, out prediction);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple UpdateKalman(string fileName, HTuple dimensionIn, HTuple modelIn, HTuple measurementIn, out HTuple modelOut, out HTuple measurementOut)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1106);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.Store(expr_0A, 1, dimensionIn);
			SZXCArimAPI.Store(expr_0A, 2, modelIn);
			SZXCArimAPI.Store(expr_0A, 3, measurementIn);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(dimensionIn);
			SZXCArimAPI.UnpinTuple(modelIn);
			SZXCArimAPI.UnpinTuple(measurementIn);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out modelOut);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out measurementOut);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple FilterKalman(HTuple dimension, HTuple model, HTuple measurement, HTuple predictionIn, out HTuple estimate)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1107);
			SZXCArimAPI.Store(expr_0A, 0, dimension);
			SZXCArimAPI.Store(expr_0A, 1, model);
			SZXCArimAPI.Store(expr_0A, 2, measurement);
			SZXCArimAPI.Store(expr_0A, 3, predictionIn);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(dimension);
			SZXCArimAPI.UnpinTuple(model);
			SZXCArimAPI.UnpinTuple(measurement);
			SZXCArimAPI.UnpinTuple(predictionIn);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out estimate);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void CreateRectificationGrid(double width, int numSquares, string gridFile)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1157);
			SZXCArimAPI.StoreD(expr_0A, 0, width);
			SZXCArimAPI.StoreI(expr_0A, 1, numSquares);
			SZXCArimAPI.StoreS(expr_0A, 2, gridFile);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HImage GenArbitraryDistortionMap(int gridSpacing, HTuple row, HTuple column, int gridWidth, int imageWidth, int imageHeight, string mapType)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1160);
			SZXCArimAPI.StoreI(expr_0A, 0, gridSpacing);
			SZXCArimAPI.Store(expr_0A, 1, row);
			SZXCArimAPI.Store(expr_0A, 2, column);
			SZXCArimAPI.StoreI(expr_0A, 3, gridWidth);
			SZXCArimAPI.StoreI(expr_0A, 4, imageWidth);
			SZXCArimAPI.StoreI(expr_0A, 5, imageHeight);
			SZXCArimAPI.StoreS(expr_0A, 6, mapType);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HImage result;
			num = HImage.LoadNew(expr_0A, 1, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void ProjectionPl(HTuple row, HTuple column, HTuple row1, HTuple column1, HTuple row2, HTuple column2, out HTuple rowProj, out HTuple colProj)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1338);
			SZXCArimAPI.Store(expr_0A, 0, row);
			SZXCArimAPI.Store(expr_0A, 1, column);
			SZXCArimAPI.Store(expr_0A, 2, row1);
			SZXCArimAPI.Store(expr_0A, 3, column1);
			SZXCArimAPI.Store(expr_0A, 4, row2);
			SZXCArimAPI.Store(expr_0A, 5, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out rowProj);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out colProj);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void ProjectionPl(double row, double column, double row1, double column1, double row2, double column2, out double rowProj, out double colProj)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1338);
			SZXCArimAPI.StoreD(expr_0A, 0, row);
			SZXCArimAPI.StoreD(expr_0A, 1, column);
			SZXCArimAPI.StoreD(expr_0A, 2, row1);
			SZXCArimAPI.StoreD(expr_0A, 3, column1);
			SZXCArimAPI.StoreD(expr_0A, 4, row2);
			SZXCArimAPI.StoreD(expr_0A, 5, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out rowProj);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out colProj);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void GetPointsEllipse(HTuple angle, double row, double column, double phi, double radius1, double radius2, out HTuple rowPoint, out HTuple colPoint)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1339);
			SZXCArimAPI.Store(expr_0A, 0, angle);
			SZXCArimAPI.StoreD(expr_0A, 1, row);
			SZXCArimAPI.StoreD(expr_0A, 2, column);
			SZXCArimAPI.StoreD(expr_0A, 3, phi);
			SZXCArimAPI.StoreD(expr_0A, 4, radius1);
			SZXCArimAPI.StoreD(expr_0A, 5, radius2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(angle);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out rowPoint);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out colPoint);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void GetPointsEllipse(double angle, double row, double column, double phi, double radius1, double radius2, out double rowPoint, out double colPoint)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1339);
			SZXCArimAPI.StoreD(expr_0A, 0, angle);
			SZXCArimAPI.StoreD(expr_0A, 1, row);
			SZXCArimAPI.StoreD(expr_0A, 2, column);
			SZXCArimAPI.StoreD(expr_0A, 3, phi);
			SZXCArimAPI.StoreD(expr_0A, 4, radius1);
			SZXCArimAPI.StoreD(expr_0A, 5, radius2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out rowPoint);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out colPoint);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void IntersectionLl(HTuple rowA1, HTuple columnA1, HTuple rowA2, HTuple columnA2, HTuple rowB1, HTuple columnB1, HTuple rowB2, HTuple columnB2, out HTuple row, out HTuple column, out HTuple isParallel)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1340);
			SZXCArimAPI.Store(expr_0A, 0, rowA1);
			SZXCArimAPI.Store(expr_0A, 1, columnA1);
			SZXCArimAPI.Store(expr_0A, 2, rowA2);
			SZXCArimAPI.Store(expr_0A, 3, columnA2);
			SZXCArimAPI.Store(expr_0A, 4, rowB1);
			SZXCArimAPI.Store(expr_0A, 5, columnB1);
			SZXCArimAPI.Store(expr_0A, 6, rowB2);
			SZXCArimAPI.Store(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowA1);
			SZXCArimAPI.UnpinTuple(columnA1);
			SZXCArimAPI.UnpinTuple(rowA2);
			SZXCArimAPI.UnpinTuple(columnA2);
			SZXCArimAPI.UnpinTuple(rowB1);
			SZXCArimAPI.UnpinTuple(columnB1);
			SZXCArimAPI.UnpinTuple(rowB2);
			SZXCArimAPI.UnpinTuple(columnB2);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.INTEGER, num, out isParallel);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void IntersectionLl(double rowA1, double columnA1, double rowA2, double columnA2, double rowB1, double columnB1, double rowB2, double columnB2, out double row, out double column, out int isParallel)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1340);
			SZXCArimAPI.StoreD(expr_0A, 0, rowA1);
			SZXCArimAPI.StoreD(expr_0A, 1, columnA1);
			SZXCArimAPI.StoreD(expr_0A, 2, rowA2);
			SZXCArimAPI.StoreD(expr_0A, 3, columnA2);
			SZXCArimAPI.StoreD(expr_0A, 4, rowB1);
			SZXCArimAPI.StoreD(expr_0A, 5, columnB1);
			SZXCArimAPI.StoreD(expr_0A, 6, rowB2);
			SZXCArimAPI.StoreD(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out row);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out column);
			num = SZXCArimAPI.LoadI(expr_0A, 2, num, out isParallel);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static HTuple AngleLx(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1370);
			SZXCArimAPI.Store(expr_0A, 0, row1);
			SZXCArimAPI.Store(expr_0A, 1, column1);
			SZXCArimAPI.Store(expr_0A, 2, row2);
			SZXCArimAPI.Store(expr_0A, 3, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static double AngleLx(double row1, double column1, double row2, double column2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1370);
			SZXCArimAPI.StoreD(expr_0A, 0, row1);
			SZXCArimAPI.StoreD(expr_0A, 1, column1);
			SZXCArimAPI.StoreD(expr_0A, 2, row2);
			SZXCArimAPI.StoreD(expr_0A, 3, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			double result;
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple AngleLl(HTuple rowA1, HTuple columnA1, HTuple rowA2, HTuple columnA2, HTuple rowB1, HTuple columnB1, HTuple rowB2, HTuple columnB2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1371);
			SZXCArimAPI.Store(expr_0A, 0, rowA1);
			SZXCArimAPI.Store(expr_0A, 1, columnA1);
			SZXCArimAPI.Store(expr_0A, 2, rowA2);
			SZXCArimAPI.Store(expr_0A, 3, columnA2);
			SZXCArimAPI.Store(expr_0A, 4, rowB1);
			SZXCArimAPI.Store(expr_0A, 5, columnB1);
			SZXCArimAPI.Store(expr_0A, 6, rowB2);
			SZXCArimAPI.Store(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowA1);
			SZXCArimAPI.UnpinTuple(columnA1);
			SZXCArimAPI.UnpinTuple(rowA2);
			SZXCArimAPI.UnpinTuple(columnA2);
			SZXCArimAPI.UnpinTuple(rowB1);
			SZXCArimAPI.UnpinTuple(columnB1);
			SZXCArimAPI.UnpinTuple(rowB2);
			SZXCArimAPI.UnpinTuple(columnB2);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static double AngleLl(double rowA1, double columnA1, double rowA2, double columnA2, double rowB1, double columnB1, double rowB2, double columnB2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1371);
			SZXCArimAPI.StoreD(expr_0A, 0, rowA1);
			SZXCArimAPI.StoreD(expr_0A, 1, columnA1);
			SZXCArimAPI.StoreD(expr_0A, 2, rowA2);
			SZXCArimAPI.StoreD(expr_0A, 3, columnA2);
			SZXCArimAPI.StoreD(expr_0A, 4, rowB1);
			SZXCArimAPI.StoreD(expr_0A, 5, columnB1);
			SZXCArimAPI.StoreD(expr_0A, 6, rowB2);
			SZXCArimAPI.StoreD(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			double result;
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void DistanceSl(HTuple rowA1, HTuple columnA1, HTuple rowA2, HTuple columnA2, HTuple rowB1, HTuple columnB1, HTuple rowB2, HTuple columnB2, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1372);
			SZXCArimAPI.Store(expr_0A, 0, rowA1);
			SZXCArimAPI.Store(expr_0A, 1, columnA1);
			SZXCArimAPI.Store(expr_0A, 2, rowA2);
			SZXCArimAPI.Store(expr_0A, 3, columnA2);
			SZXCArimAPI.Store(expr_0A, 4, rowB1);
			SZXCArimAPI.Store(expr_0A, 5, columnB1);
			SZXCArimAPI.Store(expr_0A, 6, rowB2);
			SZXCArimAPI.Store(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowA1);
			SZXCArimAPI.UnpinTuple(columnA1);
			SZXCArimAPI.UnpinTuple(rowA2);
			SZXCArimAPI.UnpinTuple(columnA2);
			SZXCArimAPI.UnpinTuple(rowB1);
			SZXCArimAPI.UnpinTuple(columnB1);
			SZXCArimAPI.UnpinTuple(rowB2);
			SZXCArimAPI.UnpinTuple(columnB2);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out distanceMin);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out distanceMax);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void DistanceSl(double rowA1, double columnA1, double rowA2, double columnA2, double rowB1, double columnB1, double rowB2, double columnB2, out double distanceMin, out double distanceMax)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1372);
			SZXCArimAPI.StoreD(expr_0A, 0, rowA1);
			SZXCArimAPI.StoreD(expr_0A, 1, columnA1);
			SZXCArimAPI.StoreD(expr_0A, 2, rowA2);
			SZXCArimAPI.StoreD(expr_0A, 3, columnA2);
			SZXCArimAPI.StoreD(expr_0A, 4, rowB1);
			SZXCArimAPI.StoreD(expr_0A, 5, columnB1);
			SZXCArimAPI.StoreD(expr_0A, 6, rowB2);
			SZXCArimAPI.StoreD(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out distanceMin);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out distanceMax);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void DistanceSs(HTuple rowA1, HTuple columnA1, HTuple rowA2, HTuple columnA2, HTuple rowB1, HTuple columnB1, HTuple rowB2, HTuple columnB2, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1373);
			SZXCArimAPI.Store(expr_0A, 0, rowA1);
			SZXCArimAPI.Store(expr_0A, 1, columnA1);
			SZXCArimAPI.Store(expr_0A, 2, rowA2);
			SZXCArimAPI.Store(expr_0A, 3, columnA2);
			SZXCArimAPI.Store(expr_0A, 4, rowB1);
			SZXCArimAPI.Store(expr_0A, 5, columnB1);
			SZXCArimAPI.Store(expr_0A, 6, rowB2);
			SZXCArimAPI.Store(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowA1);
			SZXCArimAPI.UnpinTuple(columnA1);
			SZXCArimAPI.UnpinTuple(rowA2);
			SZXCArimAPI.UnpinTuple(columnA2);
			SZXCArimAPI.UnpinTuple(rowB1);
			SZXCArimAPI.UnpinTuple(columnB1);
			SZXCArimAPI.UnpinTuple(rowB2);
			SZXCArimAPI.UnpinTuple(columnB2);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out distanceMin);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out distanceMax);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void DistanceSs(double rowA1, double columnA1, double rowA2, double columnA2, double rowB1, double columnB1, double rowB2, double columnB2, out double distanceMin, out double distanceMax)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1373);
			SZXCArimAPI.StoreD(expr_0A, 0, rowA1);
			SZXCArimAPI.StoreD(expr_0A, 1, columnA1);
			SZXCArimAPI.StoreD(expr_0A, 2, rowA2);
			SZXCArimAPI.StoreD(expr_0A, 3, columnA2);
			SZXCArimAPI.StoreD(expr_0A, 4, rowB1);
			SZXCArimAPI.StoreD(expr_0A, 5, columnB1);
			SZXCArimAPI.StoreD(expr_0A, 6, rowB2);
			SZXCArimAPI.StoreD(expr_0A, 7, columnB2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out distanceMin);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out distanceMax);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void DistancePs(HTuple row, HTuple column, HTuple row1, HTuple column1, HTuple row2, HTuple column2, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1374);
			SZXCArimAPI.Store(expr_0A, 0, row);
			SZXCArimAPI.Store(expr_0A, 1, column);
			SZXCArimAPI.Store(expr_0A, 2, row1);
			SZXCArimAPI.Store(expr_0A, 3, column1);
			SZXCArimAPI.Store(expr_0A, 4, row2);
			SZXCArimAPI.Store(expr_0A, 5, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out distanceMin);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out distanceMax);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void DistancePs(double row, double column, double row1, double column1, double row2, double column2, out double distanceMin, out double distanceMax)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1374);
			SZXCArimAPI.StoreD(expr_0A, 0, row);
			SZXCArimAPI.StoreD(expr_0A, 1, column);
			SZXCArimAPI.StoreD(expr_0A, 2, row1);
			SZXCArimAPI.StoreD(expr_0A, 3, column1);
			SZXCArimAPI.StoreD(expr_0A, 4, row2);
			SZXCArimAPI.StoreD(expr_0A, 5, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out distanceMin);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out distanceMax);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static HTuple DistancePl(HTuple row, HTuple column, HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1375);
			SZXCArimAPI.Store(expr_0A, 0, row);
			SZXCArimAPI.Store(expr_0A, 1, column);
			SZXCArimAPI.Store(expr_0A, 2, row1);
			SZXCArimAPI.Store(expr_0A, 3, column1);
			SZXCArimAPI.Store(expr_0A, 4, row2);
			SZXCArimAPI.Store(expr_0A, 5, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static double DistancePl(double row, double column, double row1, double column1, double row2, double column2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1375);
			SZXCArimAPI.StoreD(expr_0A, 0, row);
			SZXCArimAPI.StoreD(expr_0A, 1, column);
			SZXCArimAPI.StoreD(expr_0A, 2, row1);
			SZXCArimAPI.StoreD(expr_0A, 3, column1);
			SZXCArimAPI.StoreD(expr_0A, 4, row2);
			SZXCArimAPI.StoreD(expr_0A, 5, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			double result;
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple DistancePp(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1376);
			SZXCArimAPI.Store(expr_0A, 0, row1);
			SZXCArimAPI.Store(expr_0A, 1, column1);
			SZXCArimAPI.Store(expr_0A, 2, row2);
			SZXCArimAPI.Store(expr_0A, 3, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static double DistancePp(double row1, double column1, double row2, double column2)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1376);
			SZXCArimAPI.StoreD(expr_0A, 0, row1);
			SZXCArimAPI.StoreD(expr_0A, 1, column1);
			SZXCArimAPI.StoreD(expr_0A, 2, row2);
			SZXCArimAPI.StoreD(expr_0A, 3, column2);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			double result;
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static int InfoSmooth(string filter, double alpha, out HTuple coeffs)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1419);
			SZXCArimAPI.StoreS(expr_0A, 0, filter);
			SZXCArimAPI.StoreD(expr_0A, 1, alpha);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			int result;
			num = SZXCArimAPI.LoadI(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out coeffs);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple GaussDistribution(double sigma)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1443);
			SZXCArimAPI.StoreD(expr_0A, 0, sigma);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple SpDistribution(HTuple percentSalt, HTuple percentPepper)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1444);
			SZXCArimAPI.Store(expr_0A, 0, percentSalt);
			SZXCArimAPI.Store(expr_0A, 1, percentPepper);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(percentSalt);
			SZXCArimAPI.UnpinTuple(percentPepper);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple SpDistribution(double percentSalt, double percentPepper)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1444);
			SZXCArimAPI.StoreD(expr_0A, 0, percentSalt);
			SZXCArimAPI.StoreD(expr_0A, 1, percentPepper);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void DeserializeFftOptimizationData(HSerializedItem serializedItemHandle)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1535);
			SZXCArimAPI.Store(expr_0A, 0, serializedItemHandle);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
			GC.KeepAlive(serializedItemHandle);
		}

		public static HSerializedItem SerializeFftOptimizationData()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1536);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void ReadFftOptimizationData(string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1537);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void WriteFftOptimizationData(string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1538);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void OptimizeRftSpeed(int width, int height, string mode)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1539);
			SZXCArimAPI.StoreI(expr_0A, 0, width);
			SZXCArimAPI.StoreI(expr_0A, 1, height);
			SZXCArimAPI.StoreS(expr_0A, 2, mode);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void OptimizeFftSpeed(int width, int height, string mode)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1540);
			SZXCArimAPI.StoreI(expr_0A, 0, width);
			SZXCArimAPI.StoreI(expr_0A, 1, height);
			SZXCArimAPI.StoreS(expr_0A, 2, mode);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static int InfoEdges(string filter, string mode, double alpha, out HTuple coeffs)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1565);
			SZXCArimAPI.StoreS(expr_0A, 0, filter);
			SZXCArimAPI.StoreS(expr_0A, 1, mode);
			SZXCArimAPI.StoreD(expr_0A, 2, alpha);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			int result;
			num = SZXCArimAPI.LoadI(expr_0A, 0, num, out result);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out coeffs);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void CopyFile(string sourceFile, string destinationFile)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1638);
			SZXCArimAPI.StoreS(expr_0A, 0, sourceFile);
			SZXCArimAPI.StoreS(expr_0A, 1, destinationFile);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SetCurrentDir(string dirName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1639);
			SZXCArimAPI.StoreS(expr_0A, 0, dirName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static string GetCurrentDir()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1640);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			string result;
			num = SZXCArimAPI.LoadS(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void RemoveDir(string dirName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1641);
			SZXCArimAPI.StoreS(expr_0A, 0, dirName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void MakeDir(string dirName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1642);
			SZXCArimAPI.StoreS(expr_0A, 0, dirName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static HTuple ListFiles(string directory, HTuple options)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1643);
			SZXCArimAPI.StoreS(expr_0A, 0, directory);
			SZXCArimAPI.Store(expr_0A, 1, options);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(options);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static HTuple ListFiles(string directory, string options)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1643);
			SZXCArimAPI.StoreS(expr_0A, 0, directory);
			SZXCArimAPI.StoreS(expr_0A, 1, options);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void DeleteFile(string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1644);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static int FileExists(string fileName)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1645);
			SZXCArimAPI.StoreS(expr_0A, 0, fileName);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			int result;
			num = SZXCArimAPI.LoadI(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void CloseAllFiles()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1666);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void SelectLinesLongest(HTuple rowBeginIn, HTuple colBeginIn, HTuple rowEndIn, HTuple colEndIn, int num, out HTuple rowBeginOut, out HTuple colBeginOut, out HTuple rowEndOut, out HTuple colEndOut)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1736);
			SZXCArimAPI.Store(expr_0A, 0, rowBeginIn);
			SZXCArimAPI.Store(expr_0A, 1, colBeginIn);
			SZXCArimAPI.Store(expr_0A, 2, rowEndIn);
			SZXCArimAPI.Store(expr_0A, 3, colEndIn);
			SZXCArimAPI.StoreI(expr_0A, 4, num);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num2 = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowBeginIn);
			SZXCArimAPI.UnpinTuple(colBeginIn);
			SZXCArimAPI.UnpinTuple(rowEndIn);
			SZXCArimAPI.UnpinTuple(colEndIn);
			num2 = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num2, out rowBeginOut);
			num2 = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num2, out colBeginOut);
			num2 = HTuple.LoadNew(expr_0A, 2, HTupleType.INTEGER, num2, out rowEndOut);
			num2 = HTuple.LoadNew(expr_0A, 3, HTupleType.INTEGER, num2, out colEndOut);
			SZXCArimAPI.PostCall(expr_0A, num2);
		}

		public static void PartitionLines(HTuple rowBeginIn, HTuple colBeginIn, HTuple rowEndIn, HTuple colEndIn, HTuple feature, string operation, HTuple min, HTuple max, out HTuple rowBeginOut, out HTuple colBeginOut, out HTuple rowEndOut, out HTuple colEndOut, out HTuple failRowBOut, out HTuple failColBOut, out HTuple failRowEOut, out HTuple failColEOut)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1737);
			SZXCArimAPI.Store(expr_0A, 0, rowBeginIn);
			SZXCArimAPI.Store(expr_0A, 1, colBeginIn);
			SZXCArimAPI.Store(expr_0A, 2, rowEndIn);
			SZXCArimAPI.Store(expr_0A, 3, colEndIn);
			SZXCArimAPI.Store(expr_0A, 4, feature);
			SZXCArimAPI.StoreS(expr_0A, 5, operation);
			SZXCArimAPI.Store(expr_0A, 6, min);
			SZXCArimAPI.Store(expr_0A, 7, max);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			SZXCArimAPI.InitOCT(expr_0A, 4);
			SZXCArimAPI.InitOCT(expr_0A, 5);
			SZXCArimAPI.InitOCT(expr_0A, 6);
			SZXCArimAPI.InitOCT(expr_0A, 7);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowBeginIn);
			SZXCArimAPI.UnpinTuple(colBeginIn);
			SZXCArimAPI.UnpinTuple(rowEndIn);
			SZXCArimAPI.UnpinTuple(colEndIn);
			SZXCArimAPI.UnpinTuple(feature);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out rowBeginOut);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out colBeginOut);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.INTEGER, num, out rowEndOut);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.INTEGER, num, out colEndOut);
			num = HTuple.LoadNew(expr_0A, 4, HTupleType.INTEGER, num, out failRowBOut);
			num = HTuple.LoadNew(expr_0A, 5, HTupleType.INTEGER, num, out failColBOut);
			num = HTuple.LoadNew(expr_0A, 6, HTupleType.INTEGER, num, out failRowEOut);
			num = HTuple.LoadNew(expr_0A, 7, HTupleType.INTEGER, num, out failColEOut);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void PartitionLines(HTuple rowBeginIn, HTuple colBeginIn, HTuple rowEndIn, HTuple colEndIn, string feature, string operation, string min, string max, out HTuple rowBeginOut, out HTuple colBeginOut, out HTuple rowEndOut, out HTuple colEndOut, out HTuple failRowBOut, out HTuple failColBOut, out HTuple failRowEOut, out HTuple failColEOut)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1737);
			SZXCArimAPI.Store(expr_0A, 0, rowBeginIn);
			SZXCArimAPI.Store(expr_0A, 1, colBeginIn);
			SZXCArimAPI.Store(expr_0A, 2, rowEndIn);
			SZXCArimAPI.Store(expr_0A, 3, colEndIn);
			SZXCArimAPI.StoreS(expr_0A, 4, feature);
			SZXCArimAPI.StoreS(expr_0A, 5, operation);
			SZXCArimAPI.StoreS(expr_0A, 6, min);
			SZXCArimAPI.StoreS(expr_0A, 7, max);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			SZXCArimAPI.InitOCT(expr_0A, 4);
			SZXCArimAPI.InitOCT(expr_0A, 5);
			SZXCArimAPI.InitOCT(expr_0A, 6);
			SZXCArimAPI.InitOCT(expr_0A, 7);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowBeginIn);
			SZXCArimAPI.UnpinTuple(colBeginIn);
			SZXCArimAPI.UnpinTuple(rowEndIn);
			SZXCArimAPI.UnpinTuple(colEndIn);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out rowBeginOut);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out colBeginOut);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.INTEGER, num, out rowEndOut);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.INTEGER, num, out colEndOut);
			num = HTuple.LoadNew(expr_0A, 4, HTupleType.INTEGER, num, out failRowBOut);
			num = HTuple.LoadNew(expr_0A, 5, HTupleType.INTEGER, num, out failColBOut);
			num = HTuple.LoadNew(expr_0A, 6, HTupleType.INTEGER, num, out failRowEOut);
			num = HTuple.LoadNew(expr_0A, 7, HTupleType.INTEGER, num, out failColEOut);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void SelectLines(HTuple rowBeginIn, HTuple colBeginIn, HTuple rowEndIn, HTuple colEndIn, HTuple feature, string operation, HTuple min, HTuple max, out HTuple rowBeginOut, out HTuple colBeginOut, out HTuple rowEndOut, out HTuple colEndOut)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1738);
			SZXCArimAPI.Store(expr_0A, 0, rowBeginIn);
			SZXCArimAPI.Store(expr_0A, 1, colBeginIn);
			SZXCArimAPI.Store(expr_0A, 2, rowEndIn);
			SZXCArimAPI.Store(expr_0A, 3, colEndIn);
			SZXCArimAPI.Store(expr_0A, 4, feature);
			SZXCArimAPI.StoreS(expr_0A, 5, operation);
			SZXCArimAPI.Store(expr_0A, 6, min);
			SZXCArimAPI.Store(expr_0A, 7, max);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowBeginIn);
			SZXCArimAPI.UnpinTuple(colBeginIn);
			SZXCArimAPI.UnpinTuple(rowEndIn);
			SZXCArimAPI.UnpinTuple(colEndIn);
			SZXCArimAPI.UnpinTuple(feature);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out rowBeginOut);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out colBeginOut);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.INTEGER, num, out rowEndOut);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.INTEGER, num, out colEndOut);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void SelectLines(HTuple rowBeginIn, HTuple colBeginIn, HTuple rowEndIn, HTuple colEndIn, string feature, string operation, string min, string max, out HTuple rowBeginOut, out HTuple colBeginOut, out HTuple rowEndOut, out HTuple colEndOut)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1738);
			SZXCArimAPI.Store(expr_0A, 0, rowBeginIn);
			SZXCArimAPI.Store(expr_0A, 1, colBeginIn);
			SZXCArimAPI.Store(expr_0A, 2, rowEndIn);
			SZXCArimAPI.Store(expr_0A, 3, colEndIn);
			SZXCArimAPI.StoreS(expr_0A, 4, feature);
			SZXCArimAPI.StoreS(expr_0A, 5, operation);
			SZXCArimAPI.StoreS(expr_0A, 6, min);
			SZXCArimAPI.StoreS(expr_0A, 7, max);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowBeginIn);
			SZXCArimAPI.UnpinTuple(colBeginIn);
			SZXCArimAPI.UnpinTuple(rowEndIn);
			SZXCArimAPI.UnpinTuple(colEndIn);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out rowBeginOut);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out colBeginOut);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.INTEGER, num, out rowEndOut);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.INTEGER, num, out colEndOut);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void LinePosition(HTuple rowBegin, HTuple colBegin, HTuple rowEnd, HTuple colEnd, out HTuple rowCenter, out HTuple colCenter, out HTuple length, out HTuple phi)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1739);
			SZXCArimAPI.Store(expr_0A, 0, rowBegin);
			SZXCArimAPI.Store(expr_0A, 1, colBegin);
			SZXCArimAPI.Store(expr_0A, 2, rowEnd);
			SZXCArimAPI.Store(expr_0A, 3, colEnd);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowBegin);
			SZXCArimAPI.UnpinTuple(colBegin);
			SZXCArimAPI.UnpinTuple(rowEnd);
			SZXCArimAPI.UnpinTuple(colEnd);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out rowCenter);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out colCenter);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out length);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.DOUBLE, num, out phi);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void LinePosition(double rowBegin, double colBegin, double rowEnd, double colEnd, out double rowCenter, out double colCenter, out double length, out double phi)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1739);
			SZXCArimAPI.StoreD(expr_0A, 0, rowBegin);
			SZXCArimAPI.StoreD(expr_0A, 1, colBegin);
			SZXCArimAPI.StoreD(expr_0A, 2, rowEnd);
			SZXCArimAPI.StoreD(expr_0A, 3, colEnd);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out rowCenter);
			num = SZXCArimAPI.LoadD(expr_0A, 1, num, out colCenter);
			num = SZXCArimAPI.LoadD(expr_0A, 2, num, out length);
			num = SZXCArimAPI.LoadD(expr_0A, 3, num, out phi);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static HTuple LineOrientation(HTuple rowBegin, HTuple colBegin, HTuple rowEnd, HTuple colEnd)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1740);
			SZXCArimAPI.Store(expr_0A, 0, rowBegin);
			SZXCArimAPI.Store(expr_0A, 1, colBegin);
			SZXCArimAPI.Store(expr_0A, 2, rowEnd);
			SZXCArimAPI.Store(expr_0A, 3, colEnd);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(rowBegin);
			SZXCArimAPI.UnpinTuple(colBegin);
			SZXCArimAPI.UnpinTuple(rowEnd);
			SZXCArimAPI.UnpinTuple(colEnd);
			HTuple result;
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static double LineOrientation(double rowBegin, double colBegin, double rowEnd, double colEnd)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1740);
			SZXCArimAPI.StoreD(expr_0A, 0, rowBegin);
			SZXCArimAPI.StoreD(expr_0A, 1, colBegin);
			SZXCArimAPI.StoreD(expr_0A, 2, rowEnd);
			SZXCArimAPI.StoreD(expr_0A, 3, colEnd);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			double result;
			num = SZXCArimAPI.LoadD(expr_0A, 0, num, out result);
			SZXCArimAPI.PostCall(expr_0A, num);
			return result;
		}

		public static void ApproxChainSimple(HTuple row, HTuple column, out HTuple arcCenterRow, out HTuple arcCenterCol, out HTuple arcAngle, out HTuple arcBeginRow, out HTuple arcBeginCol, out HTuple lineBeginRow, out HTuple lineBeginCol, out HTuple lineEndRow, out HTuple lineEndCol, out HTuple order)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1741);
			SZXCArimAPI.Store(expr_0A, 0, row);
			SZXCArimAPI.Store(expr_0A, 1, column);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			SZXCArimAPI.InitOCT(expr_0A, 4);
			SZXCArimAPI.InitOCT(expr_0A, 5);
			SZXCArimAPI.InitOCT(expr_0A, 6);
			SZXCArimAPI.InitOCT(expr_0A, 7);
			SZXCArimAPI.InitOCT(expr_0A, 8);
			SZXCArimAPI.InitOCT(expr_0A, 9);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out arcCenterRow);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out arcCenterCol);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out arcAngle);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.INTEGER, num, out arcBeginRow);
			num = HTuple.LoadNew(expr_0A, 4, HTupleType.INTEGER, num, out arcBeginCol);
			num = HTuple.LoadNew(expr_0A, 5, HTupleType.INTEGER, num, out lineBeginRow);
			num = HTuple.LoadNew(expr_0A, 6, HTupleType.INTEGER, num, out lineBeginCol);
			num = HTuple.LoadNew(expr_0A, 7, HTupleType.INTEGER, num, out lineEndRow);
			num = HTuple.LoadNew(expr_0A, 8, HTupleType.INTEGER, num, out lineEndCol);
			num = HTuple.LoadNew(expr_0A, 9, HTupleType.INTEGER, num, out order);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void ApproxChain(HTuple row, HTuple column, double minWidthCoord, double maxWidthCoord, double threshStart, double threshEnd, double threshStep, double minWidthSmooth, double maxWidthSmooth, int minWidthCurve, int maxWidthCurve, double weight1, double weight2, double weight3, out HTuple arcCenterRow, out HTuple arcCenterCol, out HTuple arcAngle, out HTuple arcBeginRow, out HTuple arcBeginCol, out HTuple lineBeginRow, out HTuple lineBeginCol, out HTuple lineEndRow, out HTuple lineEndCol, out HTuple order)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1742);
			SZXCArimAPI.Store(expr_0A, 0, row);
			SZXCArimAPI.Store(expr_0A, 1, column);
			SZXCArimAPI.StoreD(expr_0A, 2, minWidthCoord);
			SZXCArimAPI.StoreD(expr_0A, 3, maxWidthCoord);
			SZXCArimAPI.StoreD(expr_0A, 4, threshStart);
			SZXCArimAPI.StoreD(expr_0A, 5, threshEnd);
			SZXCArimAPI.StoreD(expr_0A, 6, threshStep);
			SZXCArimAPI.StoreD(expr_0A, 7, minWidthSmooth);
			SZXCArimAPI.StoreD(expr_0A, 8, maxWidthSmooth);
			SZXCArimAPI.StoreI(expr_0A, 9, minWidthCurve);
			SZXCArimAPI.StoreI(expr_0A, 10, maxWidthCurve);
			SZXCArimAPI.StoreD(expr_0A, 11, weight1);
			SZXCArimAPI.StoreD(expr_0A, 12, weight2);
			SZXCArimAPI.StoreD(expr_0A, 13, weight3);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			SZXCArimAPI.InitOCT(expr_0A, 3);
			SZXCArimAPI.InitOCT(expr_0A, 4);
			SZXCArimAPI.InitOCT(expr_0A, 5);
			SZXCArimAPI.InitOCT(expr_0A, 6);
			SZXCArimAPI.InitOCT(expr_0A, 7);
			SZXCArimAPI.InitOCT(expr_0A, 8);
			SZXCArimAPI.InitOCT(expr_0A, 9);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.INTEGER, num, out arcCenterRow);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.INTEGER, num, out arcCenterCol);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out arcAngle);
			num = HTuple.LoadNew(expr_0A, 3, HTupleType.INTEGER, num, out arcBeginRow);
			num = HTuple.LoadNew(expr_0A, 4, HTupleType.INTEGER, num, out arcBeginCol);
			num = HTuple.LoadNew(expr_0A, 5, HTupleType.INTEGER, num, out lineBeginRow);
			num = HTuple.LoadNew(expr_0A, 6, HTupleType.INTEGER, num, out lineBeginCol);
			num = HTuple.LoadNew(expr_0A, 7, HTupleType.INTEGER, num, out lineEndRow);
			num = HTuple.LoadNew(expr_0A, 8, HTupleType.INTEGER, num, out lineEndCol);
			num = HTuple.LoadNew(expr_0A, 9, HTupleType.INTEGER, num, out order);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void CloseAllClassBox()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1900);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void GenCaltab(int XNum, int YNum, double markDist, double diameterRatio, string calPlateDescr, string calPlatePSFile)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1926);
			SZXCArimAPI.StoreI(expr_0A, 0, XNum);
			SZXCArimAPI.StoreI(expr_0A, 1, YNum);
			SZXCArimAPI.StoreD(expr_0A, 2, markDist);
			SZXCArimAPI.StoreD(expr_0A, 3, diameterRatio);
			SZXCArimAPI.StoreS(expr_0A, 4, calPlateDescr);
			SZXCArimAPI.StoreS(expr_0A, 5, calPlatePSFile);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void CreateCaltab(int numRows, int marksPerRow, double diameter, HTuple finderRow, HTuple finderColumn, string polarity, string calPlateDescr, string calPlatePSFile)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1927);
			SZXCArimAPI.StoreI(expr_0A, 0, numRows);
			SZXCArimAPI.StoreI(expr_0A, 1, marksPerRow);
			SZXCArimAPI.StoreD(expr_0A, 2, diameter);
			SZXCArimAPI.Store(expr_0A, 3, finderRow);
			SZXCArimAPI.Store(expr_0A, 4, finderColumn);
			SZXCArimAPI.StoreS(expr_0A, 5, polarity);
			SZXCArimAPI.StoreS(expr_0A, 6, calPlateDescr);
			SZXCArimAPI.StoreS(expr_0A, 7, calPlatePSFile);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(finderRow);
			SZXCArimAPI.UnpinTuple(finderColumn);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void CreateCaltab(int numRows, int marksPerRow, double diameter, int finderRow, int finderColumn, string polarity, string calPlateDescr, string calPlatePSFile)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1927);
			SZXCArimAPI.StoreI(expr_0A, 0, numRows);
			SZXCArimAPI.StoreI(expr_0A, 1, marksPerRow);
			SZXCArimAPI.StoreD(expr_0A, 2, diameter);
			SZXCArimAPI.StoreI(expr_0A, 3, finderRow);
			SZXCArimAPI.StoreI(expr_0A, 4, finderColumn);
			SZXCArimAPI.StoreS(expr_0A, 5, polarity);
			SZXCArimAPI.StoreS(expr_0A, 6, calPlateDescr);
			SZXCArimAPI.StoreS(expr_0A, 7, calPlatePSFile);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void CaltabPoints(string calPlateDescr, out HTuple x, out HTuple y, out HTuple z)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(1928);
			SZXCArimAPI.StoreS(expr_0A, 0, calPlateDescr);
			SZXCArimAPI.InitOCT(expr_0A, 0);
			SZXCArimAPI.InitOCT(expr_0A, 1);
			SZXCArimAPI.InitOCT(expr_0A, 2);
			int num = SZXCArimAPI.CallProcedure(expr_0A);
			num = HTuple.LoadNew(expr_0A, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(expr_0A, 1, HTupleType.DOUBLE, num, out y);
			num = HTuple.LoadNew(expr_0A, 2, HTupleType.DOUBLE, num, out z);
			SZXCArimAPI.PostCall(expr_0A, num);
		}

		public static void CloseAllBgEsti()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2009);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void CloseAllFramegrabbers()
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(2035);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}
	}
}
