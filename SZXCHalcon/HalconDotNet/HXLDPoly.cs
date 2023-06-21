using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[Serializable]
	public class HXLDPoly : HXLD
	{
		public new HXLDPoly this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HXLDPoly() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDPoly(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDPoly(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDPoly(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
			SZXCArimAPI.AssertObjectClass(this.key, "xld_poly");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDPoly obj)
		{
			obj = new HXLDPoly(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		public HXLDPoly Union2ClosedPolygonsXld(HXLDPoly polygons2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(5);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, polygons2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(polygons2);
			return result;
		}

		public HXLDPoly SymmDifferenceClosedPolygonsXld(HXLDPoly polygons2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(7);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, polygons2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(polygons2);
			return result;
		}

		public HXLDPoly DifferenceClosedPolygonsXld(HXLDPoly sub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(9);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, sub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sub);
			return result;
		}

		public HXLDPoly IntersectionClosedPolygonsXld(HXLDPoly polygons2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(11);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, polygons2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(polygons2);
			return result;
		}

		public void ReadPolygonXldArcInfo(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(18);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WritePolygonXldArcInfo(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(19);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HXLDPoly CombineRoadsXld(HXLDModPara modParallels, HXLDExtPara extParallels, HXLDPoly centerLines, HTuple maxAngleParallel, HTuple maxAngleColinear, HTuple maxDistanceParallel, HTuple maxDistanceColinear)
		{
			IntPtr proc = SZXCArimAPI.PreCall(37);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, modParallels);
			SZXCArimAPI.Store(proc, 3, extParallels);
			SZXCArimAPI.Store(proc, 4, centerLines);
			SZXCArimAPI.Store(proc, 0, maxAngleParallel);
			SZXCArimAPI.Store(proc, 1, maxAngleColinear);
			SZXCArimAPI.Store(proc, 2, maxDistanceParallel);
			SZXCArimAPI.Store(proc, 3, maxDistanceColinear);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(maxAngleParallel);
			SZXCArimAPI.UnpinTuple(maxAngleColinear);
			SZXCArimAPI.UnpinTuple(maxDistanceParallel);
			SZXCArimAPI.UnpinTuple(maxDistanceColinear);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modParallels);
			GC.KeepAlive(extParallels);
			GC.KeepAlive(centerLines);
			return result;
		}

		public HXLDPoly CombineRoadsXld(HXLDModPara modParallels, HXLDExtPara extParallels, HXLDPoly centerLines, double maxAngleParallel, double maxAngleColinear, double maxDistanceParallel, double maxDistanceColinear)
		{
			IntPtr proc = SZXCArimAPI.PreCall(37);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, modParallels);
			SZXCArimAPI.Store(proc, 3, extParallels);
			SZXCArimAPI.Store(proc, 4, centerLines);
			SZXCArimAPI.StoreD(proc, 0, maxAngleParallel);
			SZXCArimAPI.StoreD(proc, 1, maxAngleColinear);
			SZXCArimAPI.StoreD(proc, 2, maxDistanceParallel);
			SZXCArimAPI.StoreD(proc, 3, maxDistanceColinear);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(modParallels);
			GC.KeepAlive(extParallels);
			GC.KeepAlive(centerLines);
			return result;
		}

		public HXLDPara GenParallelsXld(HTuple len, HTuple dist, HTuple alpha, string merge)
		{
			IntPtr proc = SZXCArimAPI.PreCall(42);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, len);
			SZXCArimAPI.Store(proc, 1, dist);
			SZXCArimAPI.Store(proc, 2, alpha);
			SZXCArimAPI.StoreS(proc, 3, merge);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(len);
			SZXCArimAPI.UnpinTuple(dist);
			SZXCArimAPI.UnpinTuple(alpha);
			HXLDPara result;
			num = HXLDPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPara GenParallelsXld(double len, double dist, double alpha, string merge)
		{
			IntPtr proc = SZXCArimAPI.PreCall(42);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, len);
			SZXCArimAPI.StoreD(proc, 1, dist);
			SZXCArimAPI.StoreD(proc, 2, alpha);
			SZXCArimAPI.StoreS(proc, 3, merge);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPara result;
			num = HXLDPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetLinesXld(out HTuple beginRow, out HTuple beginCol, out HTuple endRow, out HTuple endCol, out HTuple length, out HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(43);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			SZXCArimAPI.InitOCT(proc, 5);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out beginRow);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out beginCol);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out endRow);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out endCol);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out length);
			num = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetPolygonXld(out HTuple row, out HTuple col, out HTuple length, out HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(44);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out col);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out length);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out phi);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HXLDCont SplitContoursXld(string mode, int weight, int smooth)
		{
			IntPtr proc = SZXCArimAPI.PreCall(46);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, weight);
			SZXCArimAPI.StoreI(proc, 2, smooth);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPoly AffineTransPolygonXld(HHomMat2D homMat2D)
		{
			IntPtr proc = SZXCArimAPI.PreCall(48);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPoly ObjDiff(HXLDPoly objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public new HXLDPoly CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPoly ConcatObj(HXLDPoly objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public new HXLDPoly SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDPoly SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HXLDPoly objects2, HTuple epsilon)
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

		public int CompareObj(HXLDPoly objects2, double epsilon)
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

		public int TestEqualObj(HXLDPoly objects2)
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

		public HRegion GenRegionPolygonXld(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(596);
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

		public HImage GenGridRectificationMap(HImage image, out HXLDPoly meshes, int gridSpacing, HTuple rotation, HTuple row, HTuple column, string mapType)
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
			num = HXLDPoly.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage GenGridRectificationMap(HImage image, out HXLDPoly meshes, int gridSpacing, string rotation, HTuple row, HTuple column, string mapType)
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
			num = HXLDPoly.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple ReadPolygonXldDxf(string fileName, HTuple genParamName, HTuple genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1634);
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

		public string ReadPolygonXldDxf(string fileName, string genParamName, double genParamValue)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1634);
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

		public void WritePolygonXldDxf(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1635);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public new HXLDPoly SelectXldPoint(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDPoly SelectXldPoint(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDPoly SelectShapeXld(HTuple features, string operation, HTuple min, HTuple max)
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
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDPoly SelectShapeXld(string features, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1678);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDPoly ShapeTransXld(string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1689);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPoly InsertObj(HXLDPoly objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public new HXLDPoly RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDPoly RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDPoly ReplaceObj(HXLDPoly objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HXLDPoly ReplaceObj(HXLDPoly objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}
	}
}
