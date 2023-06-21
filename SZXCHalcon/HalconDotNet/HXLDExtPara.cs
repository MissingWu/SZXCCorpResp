using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[Serializable]
	public class HXLDExtPara : HXLD
	{
		public new HXLDExtPara this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HXLDExtPara() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDExtPara(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDExtPara(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HXLDExtPara(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
			SZXCArimAPI.AssertObjectClass(this.key, "xld_ext_para");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDExtPara obj)
		{
			obj = new HXLDExtPara(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		public HXLDPoly MaxParallelsXld()
		{
			IntPtr proc = SZXCArimAPI.PreCall(38);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDPoly result;
			num = HXLDPoly.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDExtPara ObjDiff(HXLDExtPara objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public new HXLDExtPara CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDExtPara ConcatObj(HXLDExtPara objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public new HXLDExtPara SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDExtPara SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HXLDExtPara objects2, HTuple epsilon)
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

		public int CompareObj(HXLDExtPara objects2, double epsilon)
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

		public int TestEqualObj(HXLDExtPara objects2)
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

		public HImage GenGridRectificationMap(HImage image, out HXLDExtPara meshes, int gridSpacing, HTuple rotation, HTuple row, HTuple column, string mapType)
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
			num = HXLDExtPara.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage GenGridRectificationMap(HImage image, out HXLDExtPara meshes, int gridSpacing, string rotation, HTuple row, HTuple column, string mapType)
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
			num = HXLDExtPara.LoadNew(proc, 2, num, out meshes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public new HXLDExtPara SelectXldPoint(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDExtPara SelectXldPoint(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1676);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDExtPara SelectShapeXld(HTuple features, string operation, HTuple min, HTuple max)
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
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDExtPara SelectShapeXld(string features, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1678);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDExtPara ShapeTransXld(string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1689);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDExtPara InsertObj(HXLDExtPara objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public new HXLDExtPara RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HXLDExtPara RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDExtPara ReplaceObj(HXLDExtPara objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HXLDExtPara ReplaceObj(HXLDExtPara objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDExtPara result;
			num = HXLDExtPara.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}
	}
}
