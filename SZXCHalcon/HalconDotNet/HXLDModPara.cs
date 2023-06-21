using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[Serializable]
	public class HXLDModPara : HXLD
	{
		public new HXLDModPara this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HXLDModPara() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDModPara(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDModPara(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDModPara(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
			SZXCArimAPI.AssertObjectClass(this.key, "xld_mod_para");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDModPara obj)
		{
			obj = new HXLDModPara(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		public HXLDPoly CombineRoadsXld(HXLDPoly edgePolygons, HXLDExtPara extParallels, HXLDPoly centerLines, HTuple maxAngleParallel, HTuple maxAngleColinear, HTuple maxDistanceParallel, HTuple maxDistanceColinear)
		{
			IntPtr proc = SZXCArimAPI.PreCall(37);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, edgePolygons);
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
			GC.KeepAlive(edgePolygons);
			GC.KeepAlive(extParallels);
			GC.KeepAlive(centerLines);
			return result;
		}

		public HXLDPoly CombineRoadsXld(HXLDPoly edgePolygons, HXLDExtPara extParallels, HXLDPoly centerLines, double maxAngleParallel, double maxAngleColinear, double maxDistanceParallel, double maxDistanceColinear)
		{
			IntPtr proc = SZXCArimAPI.PreCall(37);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, edgePolygons);
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
			GC.KeepAlive(edgePolygons);
			GC.KeepAlive(extParallels);
			GC.KeepAlive(centerLines);
			return result;
		}

		public HXLDModPara ObjDiff(HXLDModPara objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public new HXLDModPara CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDModPara ConcatObj(HXLDModPara objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public new HXLDModPara SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDModPara SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HXLDModPara objects2, HTuple epsilon)
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

		public int CompareObj(HXLDModPara objects2, double epsilon)
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

		public int TestEqualObj(HXLDModPara objects2)
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

		public HImage GenGridRectificationMap(HImage image, out HXLDModPara meshes, int gridSpacing, HTuple rotation, HTuple row, HTuple column, string mapType)
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
			num = HXLDModPara.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage GenGridRectificationMap(HImage image, out HXLDModPara meshes, int gridSpacing, string rotation, HTuple row, HTuple column, string mapType)
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
			num = HXLDModPara.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public new HXLDModPara SelectXldPoint(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDModPara SelectXldPoint(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDModPara SelectShapeXld(HTuple features, string operation, HTuple min, HTuple max)
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
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDModPara SelectShapeXld(string features, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1678);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDModPara ShapeTransXld(string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1689);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDModPara InsertObj(HXLDModPara objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public new HXLDModPara RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDModPara RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDModPara ReplaceObj(HXLDModPara objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HXLDModPara ReplaceObj(HXLDModPara objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDModPara result;
			num = HXLDModPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}
	}
}
