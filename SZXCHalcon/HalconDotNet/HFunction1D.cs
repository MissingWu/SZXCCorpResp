using System;

namespace SZXCArimEngine
{
	public class HFunction1D : HData
	{
		public HFunction1D()
		{
		}

		internal HFunction1D(HData data) : base(data)
		{
		}

		internal static int LoadNew(IntPtr proc, int parIndex, HTupleType type, int err, out HFunction1D obj)
		{
			HTuple t;
			err = HTuple.LoadNew(proc, parIndex, err, out t);
			obj = new HFunction1D(new HData(t));
			return err;
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFunction1D obj)
		{
			return HFunction1D.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
		}

		public HFunction1D(HTuple YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1399);
			SZXCArimAPI.Store(proc, 0, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(YValues);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HFunction1D(double YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1399);
			SZXCArimAPI.StoreD(proc, 0, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HFunction1D(HTuple XValues, HTuple YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1400);
			SZXCArimAPI.Store(proc, 0, XValues);
			SZXCArimAPI.Store(proc, 1, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(XValues);
			SZXCArimAPI.UnpinTuple(YValues);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HFunction1D(double XValues, double YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1400);
			SZXCArimAPI.StoreD(proc, 0, XValues);
			SZXCArimAPI.StoreD(proc, 1, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public static HFunction1D operator +(HFunction1D function, double add)
		{
			return function.ScaleYFunct1d(1.0, add);
		}

		public static HFunction1D operator +(double add, HFunction1D function)
		{
			return function.ScaleYFunct1d(1.0, add);
		}

		public static HFunction1D operator -(HFunction1D function, double sub)
		{
			return function.ScaleYFunct1d(1.0, -sub);
		}

		public static HFunction1D operator -(HFunction1D function)
		{
			return function.NegateFunct1d();
		}

		public static HFunction1D operator *(HFunction1D function, double factor)
		{
			return function.ScaleYFunct1d(factor, 0.0);
		}

		public static HFunction1D operator *(double factor, HFunction1D function)
		{
			return function.ScaleYFunct1d(factor, 0.0);
		}

		public static HFunction1D operator /(HFunction1D function, double divisor)
		{
			return function.ScaleYFunct1d(1.0 / divisor, 0.0);
		}

		public static HFunction1D operator *(HFunction1D function1, HFunction1D function2)
		{
			return function1.ComposeFunct1d(function2, "constant");
		}

		public static HFunction1D operator !(HFunction1D function)
		{
			return function.InvertFunct1d();
		}

		public void GnuplotPlotFunct1d(HGnuplot gnuplotFileID)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1295);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, gnuplotFileID);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(gnuplotFileID);
		}

		public HFunction1D ComposeFunct1d(HFunction1D function2, string border)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1377);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, function2);
			SZXCArimAPI.StoreS(proc, 2, border);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(function2);
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D InvertFunct1d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1378);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D DerivateFunct1d(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1379);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void LocalMinMaxFunct1d(string mode, string interpolation, out HTuple min, out HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1380);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.StoreS(proc, 2, interpolation);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out min);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out max);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple ZeroCrossingsFunct1d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1381);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D ScaleYFunct1d(double mult, double add)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1382);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, mult);
			SZXCArimAPI.StoreD(proc, 2, add);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D NegateFunct1d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1383);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D AbsFunct1d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1384);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetYValueFunct1d(HTuple x, string border)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1385);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, x);
			SZXCArimAPI.StoreS(proc, 2, border);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(x);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double GetYValueFunct1d(double x, string border)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1385);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, x);
			SZXCArimAPI.StoreS(proc, 2, border);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetPairFunct1d(HTuple index, out HTuple x, out HTuple y)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1386);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(index);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out x);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out y);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetPairFunct1d(int index, out double x, out double y)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1386);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, index);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = SZXCArimAPI.LoadD(proc, 0, num, out x);
			num = SZXCArimAPI.LoadD(proc, 1, num, out y);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public int NumPointsFunct1d()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1387);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void YRangeFunct1d(out double YMin, out double YMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1388);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = SZXCArimAPI.LoadD(proc, 0, num, out YMin);
			num = SZXCArimAPI.LoadD(proc, 1, num, out YMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void XRangeFunct1d(out double XMin, out double XMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1389);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = SZXCArimAPI.LoadD(proc, 0, num, out XMin);
			num = SZXCArimAPI.LoadD(proc, 1, num, out XMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void Funct1dToPairs(out HTuple XValues, out HTuple YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1390);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			num = HTuple.LoadNew(proc, 0, num, out XValues);
			num = HTuple.LoadNew(proc, 1, num, out YValues);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HFunction1D SampleFunct1d(HTuple XMin, HTuple XMax, HTuple XDist, string border)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1391);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, XMin);
			SZXCArimAPI.Store(proc, 2, XMax);
			SZXCArimAPI.Store(proc, 3, XDist);
			SZXCArimAPI.StoreS(proc, 4, border);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(XMin);
			SZXCArimAPI.UnpinTuple(XMax);
			SZXCArimAPI.UnpinTuple(XDist);
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D SampleFunct1d(double XMin, double XMax, double XDist, string border)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1391);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, XMin);
			SZXCArimAPI.StoreD(proc, 2, XMax);
			SZXCArimAPI.StoreD(proc, 3, XDist);
			SZXCArimAPI.StoreS(proc, 4, border);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D TransformFunct1d(HTuple paramsVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1392);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, paramsVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(paramsVal);
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MatchFunct1dTrans(HFunction1D function2, string border, HTuple paramsConst, HTuple useParams, out double chiSquare, out HTuple covar)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1393);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, function2);
			SZXCArimAPI.StoreS(proc, 2, border);
			SZXCArimAPI.Store(proc, 3, paramsConst);
			SZXCArimAPI.Store(proc, 4, useParams);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(function2);
			SZXCArimAPI.UnpinTuple(paramsConst);
			SZXCArimAPI.UnpinTuple(useParams);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out chiSquare);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out covar);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DistanceFunct1d(HFunction1D function2, HTuple mode, HTuple sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1394);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, function2);
			SZXCArimAPI.Store(proc, 2, mode);
			SZXCArimAPI.Store(proc, 3, sigma);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(function2);
			SZXCArimAPI.UnpinTuple(mode);
			SZXCArimAPI.UnpinTuple(sigma);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DistanceFunct1d(HFunction1D function2, string mode, double sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1394);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, function2);
			SZXCArimAPI.StoreS(proc, 2, mode);
			SZXCArimAPI.StoreD(proc, 3, sigma);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.UnpinTuple(function2);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HFunction1D SmoothFunct1dGauss(double sigma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1395);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, sigma);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double IntegrateFunct1d(out HTuple negative)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1396);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out negative);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadFunct1d(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1397);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteFunct1d(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1398);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateFunct1dArray(HTuple YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1399);
			SZXCArimAPI.Store(proc, 0, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(YValues);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateFunct1dArray(double YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1399);
			SZXCArimAPI.StoreD(proc, 0, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateFunct1dPairs(HTuple XValues, HTuple YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1400);
			SZXCArimAPI.Store(proc, 0, XValues);
			SZXCArimAPI.Store(proc, 1, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(XValues);
			SZXCArimAPI.UnpinTuple(YValues);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateFunct1dPairs(double XValues, double YValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1400);
			SZXCArimAPI.StoreD(proc, 0, XValues);
			SZXCArimAPI.StoreD(proc, 1, YValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HFunction1D SmoothFunct1dMean(int smoothSize, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1401);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, smoothSize);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			base.UnpinTuple();
			HFunction1D result;
			num = HFunction1D.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
