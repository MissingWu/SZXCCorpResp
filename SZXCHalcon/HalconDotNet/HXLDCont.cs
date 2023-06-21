using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[Serializable]
	public class HXLDCont : HXLD
	{
		public new HXLDCont this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HXLDCont() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDCont(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDCont(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDCont(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
			SZXCArimAPI.AssertObjectClass(this.key, "xld_cont");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDCont obj)
		{
			obj = new HXLDCont(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		public HXLDCont(HRegion regions, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(70);
			SZXCArimAPI.Store(proc, 1, regions);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions);
		}

		public HXLDCont(HTuple row, HTuple col)
		{
			IntPtr proc = SZXCArimAPI.PreCall(72);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, col);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont UnionCotangentialContoursXld(double fitClippingLength, HTuple fitLength, double maxTangAngle, double maxDist, double maxDistPerp, double maxOverlap, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(0);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, fitClippingLength);
			SZXCArimAPI.Store(proc, 1, fitLength);
			SZXCArimAPI.StoreD(proc, 2, maxTangAngle);
			SZXCArimAPI.StoreD(proc, 3, maxDist);
			SZXCArimAPI.StoreD(proc, 4, maxDistPerp);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.StoreS(proc, 6, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fitLength);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont UnionCotangentialContoursXld(double fitClippingLength, double fitLength, double maxTangAngle, double maxDist, double maxDistPerp, double maxOverlap, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(0);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, fitClippingLength);
			SZXCArimAPI.StoreD(proc, 1, fitLength);
			SZXCArimAPI.StoreD(proc, 2, maxTangAngle);
			SZXCArimAPI.StoreD(proc, 3, maxDist);
			SZXCArimAPI.StoreD(proc, 4, maxDistPerp);
			SZXCArimAPI.StoreD(proc, 5, maxOverlap);
			SZXCArimAPI.StoreS(proc, 6, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont PolarTransContourXldInv(HTuple row, HTuple column, double angleStart, double angleEnd, HTuple radiusStart, HTuple radiusEnd, int widthIn, int heightIn, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.Store(proc, 4, radiusStart);
			SZXCArimAPI.Store(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, widthIn);
			SZXCArimAPI.StoreI(proc, 7, heightIn);
			SZXCArimAPI.StoreI(proc, 8, width);
			SZXCArimAPI.StoreI(proc, 9, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radiusStart);
			SZXCArimAPI.UnpinTuple(radiusEnd);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont PolarTransContourXldInv(double row, double column, double angleStart, double angleEnd, double radiusStart, double radiusEnd, int widthIn, int heightIn, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.StoreD(proc, 4, radiusStart);
			SZXCArimAPI.StoreD(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, widthIn);
			SZXCArimAPI.StoreI(proc, 7, heightIn);
			SZXCArimAPI.StoreI(proc, 8, width);
			SZXCArimAPI.StoreI(proc, 9, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont PolarTransContourXld(HTuple row, HTuple column, double angleStart, double angleEnd, HTuple radiusStart, HTuple radiusEnd, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.Store(proc, 4, radiusStart);
			SZXCArimAPI.Store(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radiusStart);
			SZXCArimAPI.UnpinTuple(radiusEnd);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont PolarTransContourXld(double row, double column, double angleStart, double angleEnd, double radiusStart, double radiusEnd, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, angleStart);
			SZXCArimAPI.StoreD(proc, 3, angleEnd);
			SZXCArimAPI.StoreD(proc, 4, radiusStart);
			SZXCArimAPI.StoreD(proc, 5, radiusEnd);
			SZXCArimAPI.StoreI(proc, 6, width);
			SZXCArimAPI.StoreI(proc, 7, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenContourNurbsXld(HTuple rows, HTuple cols, HTuple knots, HTuple weights, int degree, HTuple maxError, HTuple maxDistance)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(4);
			SZXCArimAPI.Store(proc, 0, rows);
			SZXCArimAPI.Store(proc, 1, cols);
			SZXCArimAPI.Store(proc, 2, knots);
			SZXCArimAPI.Store(proc, 3, weights);
			SZXCArimAPI.StoreI(proc, 4, degree);
			SZXCArimAPI.Store(proc, 5, maxError);
			SZXCArimAPI.Store(proc, 6, maxDistance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(cols);
			SZXCArimAPI.UnpinTuple(knots);
			SZXCArimAPI.UnpinTuple(weights);
			SZXCArimAPI.UnpinTuple(maxError);
			SZXCArimAPI.UnpinTuple(maxDistance);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenContourNurbsXld(HTuple rows, HTuple cols, string knots, string weights, int degree, double maxError, double maxDistance)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(4);
			SZXCArimAPI.Store(proc, 0, rows);
			SZXCArimAPI.Store(proc, 1, cols);
			SZXCArimAPI.StoreS(proc, 2, knots);
			SZXCArimAPI.StoreS(proc, 3, weights);
			SZXCArimAPI.StoreI(proc, 4, degree);
			SZXCArimAPI.StoreD(proc, 5, maxError);
			SZXCArimAPI.StoreD(proc, 6, maxDistance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(cols);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont Union2ClosedContoursXld(HXLDCont contours2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(6);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contours2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours2);
			return result;
		}

		public HXLDCont SymmDifferenceClosedContoursXld(HXLDCont contours2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(8);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contours2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours2);
			return result;
		}

		public HXLDCont DifferenceClosedContoursXld(HXLDCont sub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(10);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, sub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sub);
			return result;
		}

		public HXLDCont IntersectionClosedContoursXld(HXLDCont contours2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(12);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contours2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contours2);
			return result;
		}

		public HXLDCont UnionCocircularContoursXld(HTuple maxArcAngleDiff, HTuple maxArcOverlap, HTuple maxTangentAngle, HTuple maxDist, HTuple maxRadiusDiff, HTuple maxCenterDist, string mergeSmallContours, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(13);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, maxArcAngleDiff);
			SZXCArimAPI.Store(proc, 1, maxArcOverlap);
			SZXCArimAPI.Store(proc, 2, maxTangentAngle);
			SZXCArimAPI.Store(proc, 3, maxDist);
			SZXCArimAPI.Store(proc, 4, maxRadiusDiff);
			SZXCArimAPI.Store(proc, 5, maxCenterDist);
			SZXCArimAPI.StoreS(proc, 6, mergeSmallContours);
			SZXCArimAPI.StoreI(proc, 7, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maxArcAngleDiff);
			SZXCArimAPI.UnpinTuple(maxArcOverlap);
			SZXCArimAPI.UnpinTuple(maxTangentAngle);
			SZXCArimAPI.UnpinTuple(maxDist);
			SZXCArimAPI.UnpinTuple(maxRadiusDiff);
			SZXCArimAPI.UnpinTuple(maxCenterDist);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont UnionCocircularContoursXld(double maxArcAngleDiff, double maxArcOverlap, double maxTangentAngle, double maxDist, double maxRadiusDiff, double maxCenterDist, string mergeSmallContours, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(13);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maxArcAngleDiff);
			SZXCArimAPI.StoreD(proc, 1, maxArcOverlap);
			SZXCArimAPI.StoreD(proc, 2, maxTangentAngle);
			SZXCArimAPI.StoreD(proc, 3, maxDist);
			SZXCArimAPI.StoreD(proc, 4, maxRadiusDiff);
			SZXCArimAPI.StoreD(proc, 5, maxCenterDist);
			SZXCArimAPI.StoreS(proc, 6, mergeSmallContours);
			SZXCArimAPI.StoreI(proc, 7, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont CropContoursXld(HTuple row1, HTuple col1, HTuple row2, HTuple col2, string closeContours)
		{
			IntPtr proc = SZXCArimAPI.PreCall(14);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row1);
			SZXCArimAPI.Store(proc, 1, col1);
			SZXCArimAPI.Store(proc, 2, row2);
			SZXCArimAPI.Store(proc, 3, col2);
			SZXCArimAPI.StoreS(proc, 4, closeContours);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(col1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(col2);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont CropContoursXld(double row1, double col1, double row2, double col2, string closeContours)
		{
			IntPtr proc = SZXCArimAPI.PreCall(14);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, col1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, col2);
			SZXCArimAPI.StoreS(proc, 4, closeContours);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenCrossContourXld(HTuple row, HTuple col, HTuple size, double angle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(15);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, col);
			SZXCArimAPI.Store(proc, 2, size);
			SZXCArimAPI.StoreD(proc, 3, angle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(size);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCrossContourXld(double row, double col, double size, double angle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(15);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, col);
			SZXCArimAPI.StoreD(proc, 2, size);
			SZXCArimAPI.StoreD(proc, 3, angle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont SortContoursXld(string sortMode, string order, string rowOrCol)
		{
			IntPtr proc = SZXCArimAPI.PreCall(16);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, sortMode);
			SZXCArimAPI.StoreS(proc, 1, order);
			SZXCArimAPI.StoreS(proc, 2, rowOrCol);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont MergeContLineScanXld(HXLDCont prevConts, out HXLDCont prevMergedConts, int imageHeight, HTuple margin, string mergeBorder, int maxImagesCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(17);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, prevConts);
			SZXCArimAPI.StoreI(proc, 0, imageHeight);
			SZXCArimAPI.Store(proc, 1, margin);
			SZXCArimAPI.StoreS(proc, 2, mergeBorder);
			SZXCArimAPI.StoreI(proc, 3, maxImagesCont);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(margin);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HXLDCont.LoadNew(proc, 2, num, out prevMergedConts);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(prevConts);
			return result;
		}

		public HXLDCont MergeContLineScanXld(HXLDCont prevConts, out HXLDCont prevMergedConts, int imageHeight, double margin, string mergeBorder, int maxImagesCont)
		{
			IntPtr proc = SZXCArimAPI.PreCall(17);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, prevConts);
			SZXCArimAPI.StoreI(proc, 0, imageHeight);
			SZXCArimAPI.StoreD(proc, 1, margin);
			SZXCArimAPI.StoreS(proc, 2, mergeBorder);
			SZXCArimAPI.StoreI(proc, 3, maxImagesCont);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HXLDCont.LoadNew(proc, 2, num, out prevMergedConts);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(prevConts);
			return result;
		}

		public void ReadContourXldArcInfo(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(20);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteContourXldArcInfo(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(21);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HXLDCont GenParallelContourXld(string mode, HTuple distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(23);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, distance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(distance);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GenParallelContourXld(string mode, double distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(23);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, distance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenRectangle2ContourXld(HTuple row, HTuple column, HTuple phi, HTuple length1, HTuple length2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(24);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, phi);
			SZXCArimAPI.Store(proc, 3, length1);
			SZXCArimAPI.Store(proc, 4, length2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(length1);
			SZXCArimAPI.UnpinTuple(length2);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRectangle2ContourXld(double row, double column, double phi, double length1, double length2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(24);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, length1);
			SZXCArimAPI.StoreD(proc, 4, length2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DistRectangle2ContourPointsXld(int clippingEndPoints, double row, double column, double phi, double length1, double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(25);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, clippingEndPoints);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			SZXCArimAPI.StoreD(proc, 3, phi);
			SZXCArimAPI.StoreD(proc, 4, length1);
			SZXCArimAPI.StoreD(proc, 5, length2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void FitRectangle2ContourXld(string algorithm, int maxNumPoints, double maxClosureDist, int clippingEndPoints, int iterations, double clippingFactor, out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2, out HTuple pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(26);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreD(proc, 2, maxClosureDist);
			SZXCArimAPI.StoreI(proc, 3, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 4, iterations);
			SZXCArimAPI.StoreD(proc, 5, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out length1);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out length2);
			num = HTuple.LoadNew(proc, 5, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void FitRectangle2ContourXld(string algorithm, int maxNumPoints, double maxClosureDist, int clippingEndPoints, int iterations, double clippingFactor, out double row, out double column, out double phi, out double length1, out double length2, out string pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(26);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreD(proc, 2, maxClosureDist);
			SZXCArimAPI.StoreI(proc, 3, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 4, iterations);
			SZXCArimAPI.StoreD(proc, 5, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out length2);
			num = SZXCArimAPI.LoadS(proc, 5, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont SegmentContourAttribXld(HTuple attribute, string operation, HTuple min, HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(27);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, attribute);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.Store(proc, 2, min);
			SZXCArimAPI.Store(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(attribute);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont SegmentContourAttribXld(string attribute, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(27);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, attribute);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont SegmentContoursXld(string mode, int smoothCont, double maxLineDist1, double maxLineDist2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(28);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, smoothCont);
			SZXCArimAPI.StoreD(proc, 2, maxLineDist1);
			SZXCArimAPI.StoreD(proc, 3, maxLineDist2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void FitCircleContourXld(string algorithm, int maxNumPoints, double maxClosureDist, int clippingEndPoints, int iterations, double clippingFactor, out HTuple row, out HTuple column, out HTuple radius, out HTuple startPhi, out HTuple endPhi, out HTuple pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(29);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreD(proc, 2, maxClosureDist);
			SZXCArimAPI.StoreI(proc, 3, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 4, iterations);
			SZXCArimAPI.StoreD(proc, 5, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out radius);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out startPhi);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out endPhi);
			num = HTuple.LoadNew(proc, 5, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void FitCircleContourXld(string algorithm, int maxNumPoints, double maxClosureDist, int clippingEndPoints, int iterations, double clippingFactor, out double row, out double column, out double radius, out double startPhi, out double endPhi, out string pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(29);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreD(proc, 2, maxClosureDist);
			SZXCArimAPI.StoreI(proc, 3, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 4, iterations);
			SZXCArimAPI.StoreD(proc, 5, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out radius);
			num = SZXCArimAPI.LoadD(proc, 3, num, out startPhi);
			num = SZXCArimAPI.LoadD(proc, 4, num, out endPhi);
			num = SZXCArimAPI.LoadS(proc, 5, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void FitLineContourXld(string algorithm, int maxNumPoints, int clippingEndPoints, int iterations, double clippingFactor, out HTuple rowBegin, out HTuple colBegin, out HTuple rowEnd, out HTuple colEnd, out HTuple nr, out HTuple nc, out HTuple dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(30);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreI(proc, 2, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 3, iterations);
			SZXCArimAPI.StoreD(proc, 4, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rowBegin);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out colBegin);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out rowEnd);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out colEnd);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out nr);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out nc);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out dist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void FitLineContourXld(string algorithm, int maxNumPoints, int clippingEndPoints, int iterations, double clippingFactor, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd, out double nr, out double nc, out double dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(30);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreI(proc, 2, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 3, iterations);
			SZXCArimAPI.StoreD(proc, 4, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out rowBegin);
			num = SZXCArimAPI.LoadD(proc, 1, num, out colBegin);
			num = SZXCArimAPI.LoadD(proc, 2, num, out rowEnd);
			num = SZXCArimAPI.LoadD(proc, 3, num, out colEnd);
			num = SZXCArimAPI.LoadD(proc, 4, num, out nr);
			num = SZXCArimAPI.LoadD(proc, 5, num, out nc);
			num = SZXCArimAPI.LoadD(proc, 6, num, out dist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DistEllipseContourPointsXld(string distanceMode, int clippingEndPoints, double row, double column, double phi, double radius1, double radius2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(31);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, distanceMode);
			SZXCArimAPI.StoreI(proc, 1, clippingEndPoints);
			SZXCArimAPI.StoreD(proc, 2, row);
			SZXCArimAPI.StoreD(proc, 3, column);
			SZXCArimAPI.StoreD(proc, 4, phi);
			SZXCArimAPI.StoreD(proc, 5, radius1);
			SZXCArimAPI.StoreD(proc, 6, radius2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DistEllipseContourXld(string mode, int maxNumPoints, int clippingEndPoints, double row, double column, double phi, double radius1, double radius2, out HTuple minDist, out HTuple maxDist, out HTuple avgDist, out HTuple sigmaDist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(32);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreI(proc, 2, clippingEndPoints);
			SZXCArimAPI.StoreD(proc, 3, row);
			SZXCArimAPI.StoreD(proc, 4, column);
			SZXCArimAPI.StoreD(proc, 5, phi);
			SZXCArimAPI.StoreD(proc, 6, radius1);
			SZXCArimAPI.StoreD(proc, 7, radius2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out minDist);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out maxDist);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out avgDist);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out sigmaDist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DistEllipseContourXld(string mode, int maxNumPoints, int clippingEndPoints, double row, double column, double phi, double radius1, double radius2, out double minDist, out double maxDist, out double avgDist, out double sigmaDist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(32);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreI(proc, 2, clippingEndPoints);
			SZXCArimAPI.StoreD(proc, 3, row);
			SZXCArimAPI.StoreD(proc, 4, column);
			SZXCArimAPI.StoreD(proc, 5, phi);
			SZXCArimAPI.StoreD(proc, 6, radius1);
			SZXCArimAPI.StoreD(proc, 7, radius2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out minDist);
			num = SZXCArimAPI.LoadD(proc, 1, num, out maxDist);
			num = SZXCArimAPI.LoadD(proc, 2, num, out avgDist);
			num = SZXCArimAPI.LoadD(proc, 3, num, out sigmaDist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void FitEllipseContourXld(string algorithm, int maxNumPoints, double maxClosureDist, int clippingEndPoints, int vossTabSize, int iterations, double clippingFactor, out HTuple row, out HTuple column, out HTuple phi, out HTuple radius1, out HTuple radius2, out HTuple startPhi, out HTuple endPhi, out HTuple pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(33);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreD(proc, 2, maxClosureDist);
			SZXCArimAPI.StoreI(proc, 3, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 4, vossTabSize);
			SZXCArimAPI.StoreI(proc, 5, iterations);
			SZXCArimAPI.StoreD(proc, 6, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out radius1);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out radius2);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out startPhi);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out endPhi);
			num = HTuple.LoadNew(proc, 7, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void FitEllipseContourXld(string algorithm, int maxNumPoints, double maxClosureDist, int clippingEndPoints, int vossTabSize, int iterations, double clippingFactor, out double row, out double column, out double phi, out double radius1, out double radius2, out double startPhi, out double endPhi, out string pointOrder)
		{
			IntPtr proc = SZXCArimAPI.PreCall(33);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, algorithm);
			SZXCArimAPI.StoreI(proc, 1, maxNumPoints);
			SZXCArimAPI.StoreD(proc, 2, maxClosureDist);
			SZXCArimAPI.StoreI(proc, 3, clippingEndPoints);
			SZXCArimAPI.StoreI(proc, 4, vossTabSize);
			SZXCArimAPI.StoreI(proc, 5, iterations);
			SZXCArimAPI.StoreD(proc, 6, clippingFactor);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			SZXCArimAPI.InitOCT(proc, 6);
			SZXCArimAPI.InitOCT(proc, 7);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out radius1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out radius2);
			num = SZXCArimAPI.LoadD(proc, 5, num, out startPhi);
			num = SZXCArimAPI.LoadD(proc, 6, num, out endPhi);
			num = SZXCArimAPI.LoadS(proc, 7, num, out pointOrder);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCircleContourXld(HTuple row, HTuple column, HTuple radius, HTuple startPhi, HTuple endPhi, HTuple pointOrder, double resolution)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(34);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.Store(proc, 3, startPhi);
			SZXCArimAPI.Store(proc, 4, endPhi);
			SZXCArimAPI.Store(proc, 5, pointOrder);
			SZXCArimAPI.StoreD(proc, 6, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(startPhi);
			SZXCArimAPI.UnpinTuple(endPhi);
			SZXCArimAPI.UnpinTuple(pointOrder);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCircleContourXld(double row, double column, double radius, double startPhi, double endPhi, string pointOrder, double resolution)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(34);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, startPhi);
			SZXCArimAPI.StoreD(proc, 4, endPhi);
			SZXCArimAPI.StoreS(proc, 5, pointOrder);
			SZXCArimAPI.StoreD(proc, 6, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenEllipseContourXld(HTuple row, HTuple column, HTuple phi, HTuple radius1, HTuple radius2, HTuple startPhi, HTuple endPhi, HTuple pointOrder, double resolution)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(35);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, phi);
			SZXCArimAPI.Store(proc, 3, radius1);
			SZXCArimAPI.Store(proc, 4, radius2);
			SZXCArimAPI.Store(proc, 5, startPhi);
			SZXCArimAPI.Store(proc, 6, endPhi);
			SZXCArimAPI.Store(proc, 7, pointOrder);
			SZXCArimAPI.StoreD(proc, 8, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(radius1);
			SZXCArimAPI.UnpinTuple(radius2);
			SZXCArimAPI.UnpinTuple(startPhi);
			SZXCArimAPI.UnpinTuple(endPhi);
			SZXCArimAPI.UnpinTuple(pointOrder);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenEllipseContourXld(double row, double column, double phi, double radius1, double radius2, double startPhi, double endPhi, string pointOrder, double resolution)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(35);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, radius1);
			SZXCArimAPI.StoreD(proc, 4, radius2);
			SZXCArimAPI.StoreD(proc, 5, startPhi);
			SZXCArimAPI.StoreD(proc, 6, endPhi);
			SZXCArimAPI.StoreS(proc, 7, pointOrder);
			SZXCArimAPI.StoreD(proc, 8, resolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont AddNoiseWhiteContourXld(int numRegrPoints, double amp)
		{
			IntPtr proc = SZXCArimAPI.PreCall(36);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numRegrPoints);
			SZXCArimAPI.StoreD(proc, 1, amp);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPoly GenPolygonsXld(string type, HTuple alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(45);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.Store(proc, 1, alpha);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(alpha);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPoly GenPolygonsXld(string type, double alpha)
		{
			IntPtr proc = SZXCArimAPI.PreCall(45);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreD(proc, 1, alpha);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ProjectiveTransContourXld(HHomMat2D homMat2D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(47);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont AffineTransContourXld(HHomMat2D homMat2D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(49);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont CloseContoursXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(50);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ClipEndPointsContoursXld(string mode, HTuple length)
		{
			IntPtr proc = SZXCArimAPI.PreCall(51);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.Store(proc, 1, length);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(length);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ClipEndPointsContoursXld(string mode, double length)
		{
			IntPtr proc = SZXCArimAPI.PreCall(51);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreD(proc, 1, length);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ClipContoursXld(int row1, int column1, int row2, int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(52);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row1);
			SZXCArimAPI.StoreI(proc, 1, column1);
			SZXCArimAPI.StoreI(proc, 2, row2);
			SZXCArimAPI.StoreI(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont LocalMaxContoursXld(HImage image, HTuple minPercent, int minDiff, int distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(53);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, minPercent);
			SZXCArimAPI.StoreI(proc, 1, minDiff);
			SZXCArimAPI.StoreI(proc, 2, distance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(minPercent);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HXLDCont LocalMaxContoursXld(HImage image, int minPercent, int minDiff, int distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(53);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreI(proc, 0, minPercent);
			SZXCArimAPI.StoreI(proc, 1, minDiff);
			SZXCArimAPI.StoreI(proc, 2, distance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HXLDCont UnionStraightContoursHistoXld(out HXLDCont selectedContours, int refLineStartRow, int refLineStartColumn, int refLineEndRow, int refLineEndColumn, int width, int maxWidth, int filterSize, out HTuple histoValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(54);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, refLineStartRow);
			SZXCArimAPI.StoreI(proc, 1, refLineStartColumn);
			SZXCArimAPI.StoreI(proc, 2, refLineEndRow);
			SZXCArimAPI.StoreI(proc, 3, refLineEndColumn);
			SZXCArimAPI.StoreI(proc, 4, width);
			SZXCArimAPI.StoreI(proc, 5, maxWidth);
			SZXCArimAPI.StoreI(proc, 6, filterSize);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HXLDCont.LoadNew(proc, 2, num, out selectedContours);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out histoValues);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont UnionStraightContoursXld(double maxDist, double maxDiff, double percent, string mode, HTuple iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(55);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maxDist);
			SZXCArimAPI.StoreD(proc, 1, maxDiff);
			SZXCArimAPI.StoreD(proc, 2, percent);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.Store(proc, 4, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(iterations);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont UnionStraightContoursXld(double maxDist, double maxDiff, double percent, string mode, string iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(55);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maxDist);
			SZXCArimAPI.StoreD(proc, 1, maxDiff);
			SZXCArimAPI.StoreD(proc, 2, percent);
			SZXCArimAPI.StoreS(proc, 3, mode);
			SZXCArimAPI.StoreS(proc, 4, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont UnionCollinearContoursExtXld(double maxDistAbs, double maxDistRel, double maxShift, double maxAngle, double maxOverlap, double maxRegrError, double maxCosts, double weightDist, double weightShift, double weightAngle, double weightLink, double weightRegr, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(56);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maxDistAbs);
			SZXCArimAPI.StoreD(proc, 1, maxDistRel);
			SZXCArimAPI.StoreD(proc, 2, maxShift);
			SZXCArimAPI.StoreD(proc, 3, maxAngle);
			SZXCArimAPI.StoreD(proc, 4, maxOverlap);
			SZXCArimAPI.StoreD(proc, 5, maxRegrError);
			SZXCArimAPI.StoreD(proc, 6, maxCosts);
			SZXCArimAPI.StoreD(proc, 7, weightDist);
			SZXCArimAPI.StoreD(proc, 8, weightShift);
			SZXCArimAPI.StoreD(proc, 9, weightAngle);
			SZXCArimAPI.StoreD(proc, 10, weightLink);
			SZXCArimAPI.StoreD(proc, 11, weightRegr);
			SZXCArimAPI.StoreS(proc, 12, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont UnionCollinearContoursXld(double maxDistAbs, double maxDistRel, double maxShift, double maxAngle, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(57);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maxDistAbs);
			SZXCArimAPI.StoreD(proc, 1, maxDistRel);
			SZXCArimAPI.StoreD(proc, 2, maxShift);
			SZXCArimAPI.StoreD(proc, 3, maxAngle);
			SZXCArimAPI.StoreS(proc, 4, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont UnionAdjacentContoursXld(double maxDistAbs, double maxDistRel, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(58);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, maxDistAbs);
			SZXCArimAPI.StoreD(proc, 1, maxDistRel);
			SZXCArimAPI.StoreS(proc, 2, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont SelectContoursXld(string feature, double min1, double max1, double min2, double max2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(59);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, feature);
			SZXCArimAPI.StoreD(proc, 1, min1);
			SZXCArimAPI.StoreD(proc, 2, max1);
			SZXCArimAPI.StoreD(proc, 3, min2);
			SZXCArimAPI.StoreD(proc, 4, max2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetRegressParamsXld(out HTuple nx, out HTuple ny, out HTuple dist, out HTuple fpx, out HTuple fpy, out HTuple lpx, out HTuple lpy, out HTuple mean, out HTuple deviation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(60);
			base.Store(proc, 1);
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
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out nx);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out ny);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out dist);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out fpx);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out fpy);
			num = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, num, out lpx);
			num = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, num, out lpy);
			num = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, num, out mean);
			num = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, num, out deviation);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont RegressContoursXld(string mode, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(61);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetContourAngleXld(string angleMode, string calcMode, int lookaround)
		{
			IntPtr proc = SZXCArimAPI.PreCall(62);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, angleMode);
			SZXCArimAPI.StoreS(proc, 1, calcMode);
			SZXCArimAPI.StoreI(proc, 2, lookaround);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont SmoothContoursXld(int numRegrPoints)
		{
			IntPtr proc = SZXCArimAPI.PreCall(63);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numRegrPoints);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ContourPointNumXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(64);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryContourGlobalAttribsXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(65);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetContourGlobalAttribXld(HTuple name)
		{
			IntPtr proc = SZXCArimAPI.PreCall(66);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, name);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(name);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetContourGlobalAttribXld(string name)
		{
			IntPtr proc = SZXCArimAPI.PreCall(66);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple QueryContourAttribsXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(67);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetContourAttribXld(string name)
		{
			IntPtr proc = SZXCArimAPI.PreCall(68);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetContourXld(out HTuple row, out HTuple col)
		{
			IntPtr proc = SZXCArimAPI.PreCall(69);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out col);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenContourPolygonRoundedXld(HTuple row, HTuple col, HTuple radius, HTuple samplingInterval)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(71);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, col);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.Store(proc, 3, samplingInterval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(samplingInterval);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenContourPolygonRoundedXld(HTuple row, HTuple col, HTuple radius, double samplingInterval)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(71);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, col);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, samplingInterval);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			SZXCArimAPI.UnpinTuple(radius);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenContourPolygonXld(HTuple row, HTuple col)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(72);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, col);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(col);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont ObjDiff(HXLDCont objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public new HXLDCont CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ConcatObj(HXLDCont objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public new HXLDCont SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDCont SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HXLDCont objects2, HTuple epsilon)
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

		public int CompareObj(HXLDCont objects2, double epsilon)
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

		public int TestEqualObj(HXLDCont objects2)
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

		public HRegion GenRegionContourXld(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(597);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateAnisoShapeModelXld(HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleRMin, double scaleRMax, HTuple scaleRStep, double scaleCMin, double scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(935);
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
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleRStep);
			SZXCArimAPI.UnpinTuple(scaleCStep);
			SZXCArimAPI.UnpinTuple(optimization);
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateAnisoShapeModelXld(int numLevels, double angleStart, double angleExtent, double angleStep, double scaleRMin, double scaleRMax, double scaleRStep, double scaleCMin, double scaleCMax, double scaleCStep, string optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(935);
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
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateScaledShapeModelXld(HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, double scaleMin, double scaleMax, HTuple scaleStep, HTuple optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(936);
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
			SZXCArimAPI.StoreI(proc, 9, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(scaleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateScaledShapeModelXld(int numLevels, double angleStart, double angleExtent, double angleStep, double scaleMin, double scaleMax, double scaleStep, string optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(936);
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
			SZXCArimAPI.StoreI(proc, 9, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateShapeModelXld(HTuple numLevels, double angleStart, double angleExtent, HTuple angleStep, HTuple optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(937);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.Store(proc, 3, angleStep);
			SZXCArimAPI.Store(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevels);
			SZXCArimAPI.UnpinTuple(angleStep);
			SZXCArimAPI.UnpinTuple(optimization);
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HShapeModel CreateShapeModelXld(int numLevels, double angleStart, double angleExtent, double angleStep, string optimization, string metric, int minContrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(937);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, numLevels);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtent);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimization);
			SZXCArimAPI.StoreS(proc, 5, metric);
			SZXCArimAPI.StoreI(proc, 6, minContrast);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HShapeModel result;
			num = HShapeModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreateLocalDeformableModelXld(HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(975);
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
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
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
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreateLocalDeformableModelXld(int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(975);
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
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
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
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModelXld(HCamPar camParam, HPose referencePose, HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
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
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
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
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreatePlanarCalibDeformableModelXld(HCamPar camParam, HPose referencePose, int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(976);
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
			SZXCArimAPI.StoreI(proc, 14, minContrast);
			SZXCArimAPI.Store(proc, 15, genParamName);
			SZXCArimAPI.Store(proc, 16, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParam);
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
			return result;
		}

		public HDeformableModel CreatePlanarUncalibDeformableModelXld(HTuple numLevels, HTuple angleStart, HTuple angleExtent, HTuple angleStep, double scaleRMin, HTuple scaleRMax, HTuple scaleRStep, double scaleCMin, HTuple scaleCMax, HTuple scaleCStep, HTuple optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(977);
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
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
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
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HDeformableModel result;
			num = HDeformableModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HDeformableModel CreatePlanarUncalibDeformableModelXld(int numLevels, HTuple angleStart, HTuple angleExtent, double angleStep, double scaleRMin, HTuple scaleRMax, double scaleRStep, double scaleCMin, HTuple scaleCMax, double scaleCStep, string optimization, string metric, int minContrast, HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(977);
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
			SZXCArimAPI.StoreI(proc, 12, minContrast);
			SZXCArimAPI.Store(proc, 13, genParamName);
			SZXCArimAPI.Store(proc, 14, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
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
			return result;
		}

		public HImage GenGridRectificationMap(HImage image, out HXLDCont meshes, int gridSpacing, HTuple rotation, HTuple row, HTuple column, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1159);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, image);
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
			num = HXLDCont.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage GenGridRectificationMap(HImage image, out HXLDCont meshes, int gridSpacing, string rotation, HTuple row, HTuple column, string mapType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1159);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, image);
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
			num = HXLDCont.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void DrawNurbsInterpMod(HWindow windowHandle, string rotate, string move, string scale, string keepRatio, string edit, int degree, HTuple rowsIn, HTuple colsIn, HTuple tangentsIn, out HTuple controlRows, out HTuple controlCols, out HTuple knots, out HTuple rows, out HTuple cols, out HTuple tangents)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1318);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreS(proc, 5, edit);
			SZXCArimAPI.StoreI(proc, 6, degree);
			SZXCArimAPI.Store(proc, 7, rowsIn);
			SZXCArimAPI.Store(proc, 8, colsIn);
			SZXCArimAPI.Store(proc, 9, tangentsIn);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowsIn);
			SZXCArimAPI.UnpinTuple(colsIn);
			SZXCArimAPI.UnpinTuple(tangentsIn);
			num = base.Load(proc, 1, num);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out controlRows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out controlCols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out knots);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out tangents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DrawNurbsInterp(HWindow windowHandle, string rotate, string move, string scale, string keepRatio, int degree, out HTuple controlRows, out HTuple controlCols, out HTuple knots, out HTuple rows, out HTuple cols, out HTuple tangents)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1319);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreI(proc, 5, degree);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out controlRows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out controlCols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out knots);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out tangents);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DrawNurbsMod(HWindow windowHandle, string rotate, string move, string scale, string keepRatio, string edit, int degree, HTuple rowsIn, HTuple colsIn, HTuple weightsIn, out HTuple rows, out HTuple cols, out HTuple weights)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1320);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreS(proc, 5, edit);
			SZXCArimAPI.StoreI(proc, 6, degree);
			SZXCArimAPI.Store(proc, 7, rowsIn);
			SZXCArimAPI.Store(proc, 8, colsIn);
			SZXCArimAPI.Store(proc, 9, weightsIn);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowsIn);
			SZXCArimAPI.UnpinTuple(colsIn);
			SZXCArimAPI.UnpinTuple(weightsIn);
			num = base.Load(proc, 1, num);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out weights);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DrawNurbs(HWindow windowHandle, string rotate, string move, string scale, string keepRatio, int degree, out HTuple rows, out HTuple cols, out HTuple weights)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1321);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreI(proc, 5, degree);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out cols);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out weights);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public HXLDCont DrawXldMod(HWindow windowHandle, string rotate, string move, string scale, string keepRatio, string edit)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1322);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.StoreS(proc, 5, edit);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public void DrawXld(HWindow windowHandle, string rotate, string move, string scale, string keepRatio)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1323);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreS(proc, 1, rotate);
			SZXCArimAPI.StoreS(proc, 2, move);
			SZXCArimAPI.StoreS(proc, 3, scale);
			SZXCArimAPI.StoreS(proc, 4, keepRatio);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public HXLDCont DistanceContoursXld(HXLDCont contourTo, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1361);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contourTo);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contourTo);
			return result;
		}

		public HTuple DistanceCcMin(HXLDCont contour2, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1362);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contour2);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour2);
			return result;
		}

		public void DistanceCc(HXLDCont contour2, string mode, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1363);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contour2);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out distanceMin);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour2);
		}

		public void DistanceCc(HXLDCont contour2, string mode, out double distanceMin, out double distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1363);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contour2);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out distanceMin);
			num = SZXCArimAPI.LoadD(proc, 1, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour2);
		}

		public void DistanceSc(HTuple row1, HTuple column1, HTuple row2, HTuple column2, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1364);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row1);
			SZXCArimAPI.Store(proc, 1, column1);
			SZXCArimAPI.Store(proc, 2, row2);
			SZXCArimAPI.Store(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out distanceMin);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DistanceSc(double row1, double column1, double row2, double column2, out double distanceMin, out double distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1364);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out distanceMin);
			num = SZXCArimAPI.LoadD(proc, 1, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DistanceLc(HTuple row1, HTuple column1, HTuple row2, HTuple column2, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1365);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row1);
			SZXCArimAPI.Store(proc, 1, column1);
			SZXCArimAPI.Store(proc, 2, row2);
			SZXCArimAPI.Store(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row1);
			SZXCArimAPI.UnpinTuple(column1);
			SZXCArimAPI.UnpinTuple(row2);
			SZXCArimAPI.UnpinTuple(column2);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out distanceMin);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DistanceLc(double row1, double column1, double row2, double column2, out double distanceMin, out double distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1365);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out distanceMin);
			num = SZXCArimAPI.LoadD(proc, 1, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DistancePc(HTuple row, HTuple column, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1366);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out distanceMin);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DistancePc(double row, double column, out double distanceMin, out double distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1366);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out distanceMin);
			num = SZXCArimAPI.LoadD(proc, 1, num, out distanceMax);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple ReadContourXldDxf(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1636);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.Store(proc, 1, genParamName);
			SZXCArimAPI.Store(proc, 2, genParamValue);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			num = base.Load(proc, 1, num);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string ReadContourXldDxf(string fileName, string genParamName, double genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1636);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, genParamName);
			SZXCArimAPI.StoreD(proc, 2, genParamValue);
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

		public void WriteContourXldDxf(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1637);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public new HXLDCont SelectXldPoint(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDCont SelectXldPoint(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDCont SelectShapeXld(HTuple features, string operation, HTuple min, HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1678);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.Store(proc, 2, min);
			SZXCArimAPI.Store(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDCont SelectShapeXld(string features, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1678);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDCont ShapeTransXld(string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1689);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont RadialDistortionSelfCalibration(int width, int height, double inlierThreshold, int randSeed, string distortionModel, string distortionCenter, double principalPointVar, out HCamPar cameraParam)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1904);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.StoreD(proc, 2, inlierThreshold);
			SZXCArimAPI.StoreI(proc, 3, randSeed);
			SZXCArimAPI.StoreS(proc, 4, distortionModel);
			SZXCArimAPI.StoreS(proc, 5, distortionCenter);
			SZXCArimAPI.StoreD(proc, 6, principalPointVar);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			num = HCamPar.LoadNew(proc, 0, num, out cameraParam);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ContourToWorldPlaneXld(HTuple cameraParam, HPose worldPose, HTuple scale)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1915);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.Store(proc, 2, scale);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(worldPose);
			SZXCArimAPI.UnpinTuple(scale);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ContourToWorldPlaneXld(HTuple cameraParam, HPose worldPose, string scale)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1915);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, cameraParam);
			SZXCArimAPI.Store(proc, 1, worldPose);
			SZXCArimAPI.StoreS(proc, 2, scale);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(cameraParam);
			SZXCArimAPI.UnpinTuple(worldPose);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ChangeRadialDistortionContoursXld(HCamPar camParamIn, HCamPar camParamOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1922);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, camParamIn);
			SZXCArimAPI.Store(proc, 1, camParamOut);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(camParamIn);
			SZXCArimAPI.UnpinTuple(camParamOut);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DistanceCcMinPoints(HXLDCont contour2, string mode, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2111);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contour2);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out row1);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out column1);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out row2);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour2);
			return result;
		}

		public double DistanceCcMinPoints(HXLDCont contour2, string mode, out double row1, out double column1, out double row2, out double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2111);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, contour2);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out row1);
			num = SZXCArimAPI.LoadD(proc, 2, num, out column1);
			num = SZXCArimAPI.LoadD(proc, 3, num, out row2);
			num = SZXCArimAPI.LoadD(proc, 4, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(contour2);
			return result;
		}

		public HXLDCont InsertObj(HXLDCont objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public new HXLDCont RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDCont RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont ReplaceObj(HXLDCont objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HXLDCont ReplaceObj(HXLDCont objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}
	}
}
