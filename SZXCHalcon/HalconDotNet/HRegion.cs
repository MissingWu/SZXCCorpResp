using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HRegion : HObject, ISerializable, ICloneable
	{
		public new HRegion this[HTuple index]
		{
			get
			{
				return this.SelectObj(index);
			}
		}

		public HTuple Area
		{
			get
			{
				HTuple hTuple;
				HTuple hTuple2;
				return this.AreaCenter(out hTuple, out hTuple2);
			}
		}

		public HTuple Row
		{
			get
			{
				HTuple result;
				HTuple hTuple;
				this.AreaCenter(out result, out hTuple);
				return result;
			}
		}

		public HTuple Column
		{
			get
			{
				HTuple hTuple;
				HTuple result;
				this.AreaCenter(out hTuple, out result);
				return result;
			}
		}

		public HRegion() : base(HObjectBase.UNDEF, false)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HRegion(IntPtr key) : this(key, true)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HRegion(IntPtr key, bool copy) : base(key, copy)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HRegion(HObject obj) : base(obj)
		{
			this.AssertObjectClass();
			GC.KeepAlive(this);
		}

		private void AssertObjectClass()
		{
			SZXCArimAPI.AssertObjectClass(this.key, "region");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadNew(IntPtr proc, int parIndex, int err, out HRegion obj)
		{
			obj = new HRegion(HObjectBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		public HRegion(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(603);
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
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion(double row1, double column1, double row2, double column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(603);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion(HTuple row, HTuple column, HTuple phi, HTuple radius1, HTuple radius2, HTuple startAngle, HTuple endAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(608);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, phi);
			SZXCArimAPI.Store(proc, 3, radius1);
			SZXCArimAPI.Store(proc, 4, radius2);
			SZXCArimAPI.Store(proc, 5, startAngle);
			SZXCArimAPI.Store(proc, 6, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(radius1);
			SZXCArimAPI.UnpinTuple(radius2);
			SZXCArimAPI.UnpinTuple(startAngle);
			SZXCArimAPI.UnpinTuple(endAngle);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion(double row, double column, double phi, double radius1, double radius2, double startAngle, double endAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(608);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, radius1);
			SZXCArimAPI.StoreD(proc, 4, radius2);
			SZXCArimAPI.StoreD(proc, 5, startAngle);
			SZXCArimAPI.StoreD(proc, 6, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion(HTuple row, HTuple column, HTuple radius, HTuple startAngle, HTuple endAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(610);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.Store(proc, 3, startAngle);
			SZXCArimAPI.Store(proc, 4, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(startAngle);
			SZXCArimAPI.UnpinTuple(endAngle);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion(double row, double column, double radius, double startAngle, double endAngle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(610);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, startAngle);
			SZXCArimAPI.StoreD(proc, 4, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion(HTuple row, HTuple column, HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(611);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radius);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion(double row, double column, double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(611);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeRegion();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HRegion(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeRegion(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeRegion();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HRegion Deserialize(Stream stream)
		{
			HRegion arg_0C_0 = new HRegion();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeRegion(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HRegion Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeRegion();
			HRegion expr_0C = new HRegion();
			expr_0C.DeserializeRegion(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public static HRegion operator &(HRegion region1, HRegion region2)
		{
			return region1.Intersection(region2);
		}

		public static HRegion operator |(HRegion region1, HRegion region2)
		{
			return region1.Union2(region2);
		}

		public static HRegion operator /(HRegion region1, HRegion region2)
		{
			return region1.Difference(region2);
		}

		public static HRegion operator !(HRegion region)
		{
			return region.Complement();
		}

		public static HRegion operator &(HRegion region, HImage image)
		{
			return region.Intersection(image.GetDomain());
		}

		public static bool operator <=(HRegion region1, HRegion region2)
		{
			int arg_0E_0 = region1.CountObj();
			int num = region2.CountObj();
			return arg_0E_0 == 1 && num == 1 && (region1 / region2).Area == 0;
		}

		public static bool operator >=(HRegion region1, HRegion region2)
		{
			return region2 <= region1;
		}

		public static HRegion operator +(HRegion region1, HRegion region2)
		{
			return region1.MinkowskiAdd1(region2, 1);
		}

		public static HRegion operator -(HRegion region1, HRegion region2)
		{
			return region1.MinkowskiSub1(region2, 1);
		}

		public static HRegion operator +(HRegion region, double radius)
		{
			return region.DilationCircle(radius);
		}

		public static HRegion operator +(double radius, HRegion region)
		{
			return region.DilationCircle(radius);
		}

		public static HRegion operator -(HRegion region, double radius)
		{
			return region.ErosionCircle(radius);
		}

		public static HRegion operator +(HRegion region, Point p)
		{
			return region.MoveRegion(p.Y, p.X);
		}

		public static HRegion operator *(HRegion region, double factor)
		{
			return region.ZoomRegion(factor, factor);
		}

		public static HRegion operator *(double factor, HRegion region)
		{
			return region.ZoomRegion(factor, factor);
		}

		public static HRegion operator -(HRegion region)
		{
			return region.TransposeRegion(0, 0);
		}

		public static implicit operator HRegion(HXLDCont xld)
		{
			return xld.GenRegionContourXld("filled");
		}

		public static implicit operator HRegion(HXLDPoly xld)
		{
			return xld.GenRegionPolygonXld("filled");
		}

		public static implicit operator HXLDCont(HRegion region)
		{
			return region.GenContourRegionXld("border");
		}

		public HXLDCont GenContourRegionXld(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(70);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HXLDCont GenContoursSkeletonXld(int length, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(73);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, length);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HXLDCont result;
			num = HXLDCont.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReceiveRegion(HSocket socket)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(327);
			SZXCArimAPI.Store(proc, 0, socket);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public void SendRegion(HSocket socket)
		{
			IntPtr proc = SZXCArimAPI.PreCall(328);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, socket);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(socket);
		}

		public HSheetOfLightModel CreateSheetOfLightModel(HTuple genParamName, HTuple genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(391);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, genParamName);
			SZXCArimAPI.Store(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(genParamName);
			SZXCArimAPI.UnpinTuple(genParamValue);
			HSheetOfLightModel result;
			num = HSheetOfLightModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HSheetOfLightModel CreateSheetOfLightModel(string genParamName, int genParamValue)
		{
			IntPtr proc = SZXCArimAPI.PreCall(391);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, genParamName);
			SZXCArimAPI.StoreI(proc, 1, genParamValue);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSheetOfLightModel result;
			num = HSheetOfLightModel.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SelectCharacters(string dotPrint, string strokeWidth, HTuple charWidth, HTuple charHeight, string punctuation, string diacriticMarks, string partitionMethod, string partitionLines, string fragmentDistance, string connectFragments, int clutterSizeMax, string stopAfter)
		{
			IntPtr proc = SZXCArimAPI.PreCall(424);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, dotPrint);
			SZXCArimAPI.StoreS(proc, 1, strokeWidth);
			SZXCArimAPI.Store(proc, 2, charWidth);
			SZXCArimAPI.Store(proc, 3, charHeight);
			SZXCArimAPI.StoreS(proc, 4, punctuation);
			SZXCArimAPI.StoreS(proc, 5, diacriticMarks);
			SZXCArimAPI.StoreS(proc, 6, partitionMethod);
			SZXCArimAPI.StoreS(proc, 7, partitionLines);
			SZXCArimAPI.StoreS(proc, 8, fragmentDistance);
			SZXCArimAPI.StoreS(proc, 9, connectFragments);
			SZXCArimAPI.StoreI(proc, 10, clutterSizeMax);
			SZXCArimAPI.StoreS(proc, 11, stopAfter);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(charWidth);
			SZXCArimAPI.UnpinTuple(charHeight);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage SegmentCharacters(HImage image, out HRegion regionForeground, string method, string eliminateLines, string dotPrint, string strokeWidth, HTuple charWidth, HTuple charHeight, int thresholdOffset, int contrast, out HTuple usedThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(425);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreS(proc, 1, eliminateLines);
			SZXCArimAPI.StoreS(proc, 2, dotPrint);
			SZXCArimAPI.StoreS(proc, 3, strokeWidth);
			SZXCArimAPI.Store(proc, 4, charWidth);
			SZXCArimAPI.Store(proc, 5, charHeight);
			SZXCArimAPI.StoreI(proc, 6, thresholdOffset);
			SZXCArimAPI.StoreI(proc, 7, contrast);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(charWidth);
			SZXCArimAPI.UnpinTuple(charHeight);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out regionForeground);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out usedThreshold);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage SegmentCharacters(HImage image, out HRegion regionForeground, string method, string eliminateLines, string dotPrint, string strokeWidth, HTuple charWidth, HTuple charHeight, int thresholdOffset, int contrast, out int usedThreshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(425);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, method);
			SZXCArimAPI.StoreS(proc, 1, eliminateLines);
			SZXCArimAPI.StoreS(proc, 2, dotPrint);
			SZXCArimAPI.StoreS(proc, 3, strokeWidth);
			SZXCArimAPI.Store(proc, 4, charWidth);
			SZXCArimAPI.Store(proc, 5, charHeight);
			SZXCArimAPI.StoreI(proc, 6, thresholdOffset);
			SZXCArimAPI.StoreI(proc, 7, contrast);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(charWidth);
			SZXCArimAPI.UnpinTuple(charHeight);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out regionForeground);
			num = SZXCArimAPI.LoadI(proc, 0, num, out usedThreshold);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple TextLineSlant(HImage image, int charHeight, double slantFrom, double slantTo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(426);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreI(proc, 0, charHeight);
			SZXCArimAPI.StoreD(proc, 1, slantFrom);
			SZXCArimAPI.StoreD(proc, 2, slantTo);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple TextLineOrientation(HImage image, int charHeight, double orientationFrom, double orientationTo)
		{
			IntPtr proc = SZXCArimAPI.PreCall(427);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreI(proc, 0, charHeight);
			SZXCArimAPI.StoreD(proc, 1, orientationFrom);
			SZXCArimAPI.StoreD(proc, 2, orientationTo);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple LearnNdimNorm(HRegion background, HImage image, string metric, HTuple distance, HTuple minNumberPercent, out HTuple center, out double quality)
		{
			IntPtr proc = SZXCArimAPI.PreCall(437);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, background);
			SZXCArimAPI.Store(proc, 3, image);
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
			GC.KeepAlive(background);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple LearnNdimNorm(HRegion background, HImage image, string metric, double distance, double minNumberPercent, out HTuple center, out double quality)
		{
			IntPtr proc = SZXCArimAPI.PreCall(437);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, background);
			SZXCArimAPI.Store(proc, 3, image);
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
			GC.KeepAlive(background);
			GC.KeepAlive(image);
			return result;
		}

		public void LearnNdimBox(HRegion background, HImage multiChannelImage, HClassBox classifHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(438);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, background);
			SZXCArimAPI.Store(proc, 3, multiChannelImage);
			SZXCArimAPI.Store(proc, 0, classifHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(background);
			GC.KeepAlive(multiChannelImage);
			GC.KeepAlive(classifHandle);
		}

		public HRegion PolarTransRegionInv(HTuple row, HTuple column, double angleStart, double angleEnd, HTuple radiusStart, HTuple radiusEnd, int widthIn, int heightIn, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(475);
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
			SZXCArimAPI.StoreS(proc, 10, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radiusStart);
			SZXCArimAPI.UnpinTuple(radiusEnd);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion PolarTransRegionInv(double row, double column, double angleStart, double angleEnd, double radiusStart, double radiusEnd, int widthIn, int heightIn, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(475);
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
			SZXCArimAPI.StoreS(proc, 10, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion PolarTransRegion(HTuple row, HTuple column, double angleStart, double angleEnd, HTuple radiusStart, HTuple radiusEnd, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(476);
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
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion PolarTransRegion(double row, double column, double angleStart, double angleEnd, double radiusStart, double radiusEnd, int width, int height, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(476);
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
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion MergeRegionsLineScan(HRegion prevRegions, out HRegion prevMergedRegions, int imageHeight, string mergeBorder, int maxImagesRegion)
		{
			IntPtr proc = SZXCArimAPI.PreCall(477);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, prevRegions);
			SZXCArimAPI.StoreI(proc, 0, imageHeight);
			SZXCArimAPI.StoreS(proc, 1, mergeBorder);
			SZXCArimAPI.StoreI(proc, 2, maxImagesRegion);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out prevMergedRegions);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(prevRegions);
			return result;
		}

		public HRegion PartitionRectangle(double width, double height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(478);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, width);
			SZXCArimAPI.StoreD(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion PartitionDynamic(double distance, double percent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(479);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, distance);
			SZXCArimAPI.StoreD(proc, 1, percent);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RegionToLabel(string type, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(480);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, width);
			SZXCArimAPI.StoreI(proc, 2, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage RegionToBin(int foregroundGray, int backgroundGray, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(481);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, foregroundGray);
			SZXCArimAPI.StoreI(proc, 1, backgroundGray);
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

		public HRegion Union2(HRegion region2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(482);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region2);
			return result;
		}

		public HRegion Union1()
		{
			IntPtr proc = SZXCArimAPI.PreCall(483);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage ClosestPointTransform(out HImage closestPoints, string metric, string foreground, string closestPointMode, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(484);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.StoreS(proc, 1, foreground);
			SZXCArimAPI.StoreS(proc, 2, closestPointMode);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out closestPoints);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage DistanceTransform(string metric, string foreground, int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(485);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, metric);
			SZXCArimAPI.StoreS(proc, 1, foreground);
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

		public HRegion Skeleton()
		{
			IntPtr proc = SZXCArimAPI.PreCall(486);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ProjectiveTransRegion(HHomMat2D homMat2D, string interpolation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(487);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.StoreS(proc, 1, interpolation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion AffineTransRegion(HHomMat2D homMat2D, string interpolate)
		{
			IntPtr proc = SZXCArimAPI.PreCall(488);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, homMat2D);
			SZXCArimAPI.StoreS(proc, 1, interpolate);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(homMat2D);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion MirrorRegion(string mode, int widthHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(489);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.StoreI(proc, 1, widthHeight);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ZoomRegion(double scaleWidth, double scaleHeight)
		{
			IntPtr proc = SZXCArimAPI.PreCall(490);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, scaleWidth);
			SZXCArimAPI.StoreD(proc, 1, scaleHeight);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion MoveRegion(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(491);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion JunctionsSkeleton(out HRegion juncPoints)
		{
			IntPtr proc = SZXCArimAPI.PreCall(492);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HRegion.LoadNew(proc, 2, num, out juncPoints);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Intersection(HRegion region2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(493);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region2);
			return result;
		}

		public HRegion Interjacent(string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(494);
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

		public HRegion FillUp()
		{
			IntPtr proc = SZXCArimAPI.PreCall(495);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion FillUpShape(string feature, HTuple min, HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(496);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, feature);
			SZXCArimAPI.Store(proc, 1, min);
			SZXCArimAPI.Store(proc, 2, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion FillUpShape(string feature, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(496);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, feature);
			SZXCArimAPI.StoreD(proc, 1, min);
			SZXCArimAPI.StoreD(proc, 2, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ExpandRegion(HRegion forbiddenArea, HTuple iterations, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(497);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, forbiddenArea);
			SZXCArimAPI.Store(proc, 0, iterations);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(iterations);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ExpandRegion(HRegion forbiddenArea, int iterations, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(497);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, forbiddenArea);
			SZXCArimAPI.StoreI(proc, 0, iterations);
			SZXCArimAPI.StoreS(proc, 1, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ClipRegionRel(int top, int bottom, int left, int right)
		{
			IntPtr proc = SZXCArimAPI.PreCall(498);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, top);
			SZXCArimAPI.StoreI(proc, 1, bottom);
			SZXCArimAPI.StoreI(proc, 2, left);
			SZXCArimAPI.StoreI(proc, 3, right);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ClipRegion(int row1, int column1, int row2, int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(499);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row1);
			SZXCArimAPI.StoreI(proc, 1, column1);
			SZXCArimAPI.StoreI(proc, 2, row2);
			SZXCArimAPI.StoreI(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion RankRegion(int width, int height, int number)
		{
			IntPtr proc = SZXCArimAPI.PreCall(500);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.StoreI(proc, 2, number);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Connection()
		{
			IntPtr proc = SZXCArimAPI.PreCall(501);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SymmDifference(HRegion region2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(502);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region2);
			return result;
		}

		public HRegion Difference(HRegion sub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(503);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, sub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(sub);
			return result;
		}

		public HRegion Complement()
		{
			IntPtr proc = SZXCArimAPI.PreCall(504);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion BackgroundSeg()
		{
			IntPtr proc = SZXCArimAPI.PreCall(505);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion HammingChangeRegion(int width, int height, int distance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(506);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.StoreI(proc, 2, distance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion RemoveNoiseRegion(string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(507);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ShapeTrans(string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(508);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ExpandGray(HImage image, HRegion forbiddenArea, HTuple iterations, string mode, HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(509);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ExpandGray(HImage image, HRegion forbiddenArea, string iterations, string mode, int threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(509);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ExpandGrayRef(HImage image, HRegion forbiddenArea, HTuple iterations, string mode, HTuple refGray, HTuple threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(510);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public HRegion ExpandGrayRef(HImage image, HRegion forbiddenArea, string iterations, string mode, int refGray, int threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(510);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			GC.KeepAlive(forbiddenArea);
			return result;
		}

		public void SplitSkeletonLines(int maxDistance, out HTuple beginRow, out HTuple beginCol, out HTuple endRow, out HTuple endCol)
		{
			IntPtr proc = SZXCArimAPI.PreCall(511);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maxDistance);
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

		public HRegion SplitSkeletonRegion(int maxDistance)
		{
			IntPtr proc = SZXCArimAPI.PreCall(512);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, maxDistance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GenRegionHisto(HTuple histogram, int row, int column, int scale)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(513);
			SZXCArimAPI.Store(proc, 0, histogram);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.StoreI(proc, 3, scale);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(histogram);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion EliminateRuns(int elimShorter, int elimLonger)
		{
			IntPtr proc = SZXCArimAPI.PreCall(514);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, elimShorter);
			SZXCArimAPI.StoreI(proc, 1, elimLonger);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ObjDiff(HRegion objectsSub)
		{
			IntPtr proc = SZXCArimAPI.PreCall(573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsSub);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsSub);
			return result;
		}

		public HImage PaintRegion(HImage image, HTuple grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(576);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayval);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage PaintRegion(HImage image, double grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(576);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreD(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void OverpaintRegion(HImage image, HTuple grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(577);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.Store(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(grayval);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void OverpaintRegion(HImage image, double grayval, string type)
		{
			IntPtr proc = SZXCArimAPI.PreCall(577);
			base.Store(proc, 2);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 0, grayval);
			SZXCArimAPI.StoreS(proc, 1, type);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public new HRegion CopyObj(int index, int numObj)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.StoreI(proc, 1, numObj);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ConcatObj(HRegion objects2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(584);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objects2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objects2);
			return result;
		}

		public new HRegion SelectObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HRegion SelectObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(587);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int CompareObj(HRegion objects2, HTuple epsilon)
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

		public int CompareObj(HRegion objects2, double epsilon)
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

		public HTuple TestSubsetRegion(HRegion region2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(589);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, region2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(region2);
			return result;
		}

		public int TestEqualRegion(HRegion regions2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(590);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public int TestEqualObj(HRegion objects2)
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

		public void GenRegionPolygonFilled(HTuple rows, HTuple columns)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(598);
			SZXCArimAPI.Store(proc, 0, rows);
			SZXCArimAPI.Store(proc, 1, columns);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(columns);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionPolygon(HTuple rows, HTuple columns)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(599);
			SZXCArimAPI.Store(proc, 0, rows);
			SZXCArimAPI.Store(proc, 1, columns);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(columns);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionPoints(HTuple rows, HTuple columns)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(600);
			SZXCArimAPI.Store(proc, 0, rows);
			SZXCArimAPI.Store(proc, 1, columns);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rows);
			SZXCArimAPI.UnpinTuple(columns);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionPoints(int rows, int columns)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(600);
			SZXCArimAPI.StoreI(proc, 0, rows);
			SZXCArimAPI.StoreI(proc, 1, columns);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionRuns(HTuple row, HTuple columnBegin, HTuple columnEnd)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(601);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, columnBegin);
			SZXCArimAPI.Store(proc, 2, columnEnd);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(columnBegin);
			SZXCArimAPI.UnpinTuple(columnEnd);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionRuns(int row, int columnBegin, int columnEnd)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(601);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, columnBegin);
			SZXCArimAPI.StoreI(proc, 2, columnEnd);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRectangle2(HTuple row, HTuple column, HTuple phi, HTuple length1, HTuple length2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(602);
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

		public void GenRectangle2(double row, double column, double phi, double length1, double length2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(602);
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

		public void GenRectangle1(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(603);
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
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRectangle1(double row1, double column1, double row2, double column2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(603);
			SZXCArimAPI.StoreD(proc, 0, row1);
			SZXCArimAPI.StoreD(proc, 1, column1);
			SZXCArimAPI.StoreD(proc, 2, row2);
			SZXCArimAPI.StoreD(proc, 3, column2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRandomRegion(int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(604);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenEllipseSector(HTuple row, HTuple column, HTuple phi, HTuple radius1, HTuple radius2, HTuple startAngle, HTuple endAngle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(608);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, phi);
			SZXCArimAPI.Store(proc, 3, radius1);
			SZXCArimAPI.Store(proc, 4, radius2);
			SZXCArimAPI.Store(proc, 5, startAngle);
			SZXCArimAPI.Store(proc, 6, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(radius1);
			SZXCArimAPI.UnpinTuple(radius2);
			SZXCArimAPI.UnpinTuple(startAngle);
			SZXCArimAPI.UnpinTuple(endAngle);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenEllipseSector(double row, double column, double phi, double radius1, double radius2, double startAngle, double endAngle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(608);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, radius1);
			SZXCArimAPI.StoreD(proc, 4, radius2);
			SZXCArimAPI.StoreD(proc, 5, startAngle);
			SZXCArimAPI.StoreD(proc, 6, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenEllipse(HTuple row, HTuple column, HTuple phi, HTuple radius1, HTuple radius2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(609);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, phi);
			SZXCArimAPI.Store(proc, 3, radius1);
			SZXCArimAPI.Store(proc, 4, radius2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(phi);
			SZXCArimAPI.UnpinTuple(radius1);
			SZXCArimAPI.UnpinTuple(radius2);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenEllipse(double row, double column, double phi, double radius1, double radius2)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(609);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, phi);
			SZXCArimAPI.StoreD(proc, 3, radius1);
			SZXCArimAPI.StoreD(proc, 4, radius2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCircleSector(HTuple row, HTuple column, HTuple radius, HTuple startAngle, HTuple endAngle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(610);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.Store(proc, 3, startAngle);
			SZXCArimAPI.Store(proc, 4, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(startAngle);
			SZXCArimAPI.UnpinTuple(endAngle);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCircleSector(double row, double column, double radius, double startAngle, double endAngle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(610);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.StoreD(proc, 3, startAngle);
			SZXCArimAPI.StoreD(proc, 4, endAngle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCircle(HTuple row, HTuple column, HTuple radius)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(611);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.Store(proc, 2, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			SZXCArimAPI.UnpinTuple(radius);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCircle(double row, double column, double radius)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(611);
			SZXCArimAPI.StoreD(proc, 0, row);
			SZXCArimAPI.StoreD(proc, 1, column);
			SZXCArimAPI.StoreD(proc, 2, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenCheckerRegion(int widthRegion, int heightRegion, int widthPattern, int heightPattern)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(612);
			SZXCArimAPI.StoreI(proc, 0, widthRegion);
			SZXCArimAPI.StoreI(proc, 1, heightRegion);
			SZXCArimAPI.StoreI(proc, 2, widthPattern);
			SZXCArimAPI.StoreI(proc, 3, heightPattern);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenGridRegion(HTuple rowSteps, HTuple columnSteps, string type, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(613);
			SZXCArimAPI.Store(proc, 0, rowSteps);
			SZXCArimAPI.Store(proc, 1, columnSteps);
			SZXCArimAPI.StoreS(proc, 2, type);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(rowSteps);
			SZXCArimAPI.UnpinTuple(columnSteps);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenGridRegion(int rowSteps, int columnSteps, string type, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(613);
			SZXCArimAPI.StoreI(proc, 0, rowSteps);
			SZXCArimAPI.StoreI(proc, 1, columnSteps);
			SZXCArimAPI.StoreS(proc, 2, type);
			SZXCArimAPI.StoreI(proc, 3, width);
			SZXCArimAPI.StoreI(proc, 4, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRandomRegions(string type, HTuple widthMin, HTuple widthMax, HTuple heightMin, HTuple heightMax, HTuple phiMin, HTuple phiMax, int numRegions, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(614);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.Store(proc, 1, widthMin);
			SZXCArimAPI.Store(proc, 2, widthMax);
			SZXCArimAPI.Store(proc, 3, heightMin);
			SZXCArimAPI.Store(proc, 4, heightMax);
			SZXCArimAPI.Store(proc, 5, phiMin);
			SZXCArimAPI.Store(proc, 6, phiMax);
			SZXCArimAPI.StoreI(proc, 7, numRegions);
			SZXCArimAPI.StoreI(proc, 8, width);
			SZXCArimAPI.StoreI(proc, 9, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(widthMin);
			SZXCArimAPI.UnpinTuple(widthMax);
			SZXCArimAPI.UnpinTuple(heightMin);
			SZXCArimAPI.UnpinTuple(heightMax);
			SZXCArimAPI.UnpinTuple(phiMin);
			SZXCArimAPI.UnpinTuple(phiMax);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRandomRegions(string type, double widthMin, double widthMax, double heightMin, double heightMax, double phiMin, double phiMax, int numRegions, int width, int height)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(614);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreD(proc, 1, widthMin);
			SZXCArimAPI.StoreD(proc, 2, widthMax);
			SZXCArimAPI.StoreD(proc, 3, heightMin);
			SZXCArimAPI.StoreD(proc, 4, heightMax);
			SZXCArimAPI.StoreD(proc, 5, phiMin);
			SZXCArimAPI.StoreD(proc, 6, phiMax);
			SZXCArimAPI.StoreI(proc, 7, numRegions);
			SZXCArimAPI.StoreI(proc, 8, width);
			SZXCArimAPI.StoreI(proc, 9, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionHline(HTuple orientation, HTuple distance)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(615);
			SZXCArimAPI.Store(proc, 0, orientation);
			SZXCArimAPI.Store(proc, 1, distance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(orientation);
			SZXCArimAPI.UnpinTuple(distance);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionHline(double orientation, double distance)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(615);
			SZXCArimAPI.StoreD(proc, 0, orientation);
			SZXCArimAPI.StoreD(proc, 1, distance);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionLine(HTuple beginRow, HTuple beginCol, HTuple endRow, HTuple endCol)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(616);
			SZXCArimAPI.Store(proc, 0, beginRow);
			SZXCArimAPI.Store(proc, 1, beginCol);
			SZXCArimAPI.Store(proc, 2, endRow);
			SZXCArimAPI.Store(proc, 3, endCol);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(beginRow);
			SZXCArimAPI.UnpinTuple(beginCol);
			SZXCArimAPI.UnpinTuple(endRow);
			SZXCArimAPI.UnpinTuple(endCol);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenRegionLine(int beginRow, int beginCol, int endRow, int endCol)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(616);
			SZXCArimAPI.StoreI(proc, 0, beginRow);
			SZXCArimAPI.StoreI(proc, 1, beginCol);
			SZXCArimAPI.StoreI(proc, 2, endRow);
			SZXCArimAPI.StoreI(proc, 3, endCol);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GenEmptyRegion()
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(618);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple GetRegionThickness(out HTuple histogramm)
		{
			IntPtr proc = SZXCArimAPI.PreCall(631);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out histogramm);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetRegionPolygon(HTuple tolerance, out HTuple rows, out HTuple columns)
		{
			IntPtr proc = SZXCArimAPI.PreCall(632);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, tolerance);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(tolerance);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out columns);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetRegionPolygon(double tolerance, out HTuple rows, out HTuple columns)
		{
			IntPtr proc = SZXCArimAPI.PreCall(632);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, tolerance);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out columns);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetRegionPoints(out HTuple rows, out HTuple columns)
		{
			IntPtr proc = SZXCArimAPI.PreCall(633);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out columns);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetRegionContour(out HTuple rows, out HTuple columns)
		{
			IntPtr proc = SZXCArimAPI.PreCall(634);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out columns);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetRegionRuns(out HTuple row, out HTuple columnBegin, out HTuple columnEnd)
		{
			IntPtr proc = SZXCArimAPI.PreCall(635);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out columnBegin);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out columnEnd);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetRegionChain(out int row, out int column, out HTuple chain)
		{
			IntPtr proc = SZXCArimAPI.PreCall(636);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out chain);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void GetRegionConvex(out HTuple rows, out HTuple columns)
		{
			IntPtr proc = SZXCArimAPI.PreCall(637);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out rows);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out columns);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple DoOcrWordKnn(HImage image, HOCRKnn OCRHandle, string expression, int numAlternatives, int numCorrections, out HTuple confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(647);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrWordKnn(HImage image, HOCRKnn OCRHandle, string expression, int numAlternatives, int numCorrections, out double confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(647);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrMultiClassKnn(HImage image, HOCRKnn OCRHandle, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(658);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrMultiClassKnn(HImage image, HOCRKnn OCRHandle, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(658);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrSingleClassKnn(HImage image, HOCRKnn OCRHandle, HTuple numClasses, HTuple numNeighbors, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(659);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.Store(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, numNeighbors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numClasses);
			SZXCArimAPI.UnpinTuple(numNeighbors);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrSingleClassKnn(HImage image, HOCRKnn OCRHandle, HTuple numClasses, HTuple numNeighbors, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(659);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.Store(proc, 1, numClasses);
			SZXCArimAPI.Store(proc, 2, numNeighbors);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numClasses);
			SZXCArimAPI.UnpinTuple(numNeighbors);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrWordSvm(HImage image, HOCRSvm OCRHandle, string expression, int numAlternatives, int numCorrections, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(679);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = SZXCArimAPI.LoadS(proc, 1, num, out word);
			num = SZXCArimAPI.LoadD(proc, 2, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrMultiClassSvm(HImage image, HOCRSvm OCRHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(680);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrSingleClassSvm(HImage image, HOCRSvm OCRHandle, HTuple num)
		{
			IntPtr proc = SZXCArimAPI.PreCall(681);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, num2, out result);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrWordMlp(HImage image, HOCRMlp OCRHandle, string expression, int numAlternatives, int numCorrections, out HTuple confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(697);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrWordMlp(HImage image, HOCRMlp OCRHandle, string expression, int numAlternatives, int numCorrections, out double confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(697);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrMultiClassMlp(HImage image, HOCRMlp OCRHandle, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(698);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrMultiClassMlp(HImage image, HOCRMlp OCRHandle, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(698);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrSingleClassMlp(HImage image, HOCRMlp OCRHandle, HTuple num, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(699);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, num2, out result);
			num2 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrSingleClassMlp(HImage image, HOCRMlp OCRHandle, HTuple num, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(699);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			string result;
			num2 = SZXCArimAPI.LoadS(proc, 0, num2, out result);
			num2 = SZXCArimAPI.LoadD(proc, 1, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrSingle(HImage image, HOCRBox ocrHandle, out HTuple confidences)
		{
			IntPtr proc = SZXCArimAPI.PreCall(713);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidences);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public HTuple DoOcrMulti(HImage image, HOCRBox ocrHandle, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(714);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public string DoOcrMulti(HImage image, HOCRBox ocrHandle, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(714);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public double TraindOcrClassBox(HImage image, HOCRBox ocrHandle, HTuple classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(717);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.Store(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(classVal);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public double TraindOcrClassBox(HImage image, HOCRBox ocrHandle, string classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(717);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.StoreS(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public static void ProtectOcrTrainf(string trainingFile, HTuple password, string trainingFileProtected)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(719);
			SZXCArimAPI.StoreS(expr_0A, 0, trainingFile);
			SZXCArimAPI.Store(expr_0A, 1, password);
			SZXCArimAPI.StoreS(expr_0A, 2, trainingFileProtected);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.UnpinTuple(password);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public static void ProtectOcrTrainf(string trainingFile, string password, string trainingFileProtected)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(719);
			SZXCArimAPI.StoreS(expr_0A, 0, trainingFile);
			SZXCArimAPI.StoreS(expr_0A, 1, password);
			SZXCArimAPI.StoreS(expr_0A, 2, trainingFileProtected);
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		public void WriteOcrTrainf(HImage image, HTuple classVal, string trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(720);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, classVal);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(classVal);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void WriteOcrTrainf(HImage image, string classVal, string trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(720);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, classVal);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public HRegion SortRegion(string sortMode, string order, string rowOrCol)
		{
			IntPtr proc = SZXCArimAPI.PreCall(723);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, sortMode);
			SZXCArimAPI.StoreS(proc, 1, order);
			SZXCArimAPI.StoreS(proc, 2, rowOrCol);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple TestdOcrClassBox(HImage image, HOCRBox ocrHandle, HTuple classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(725);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.Store(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(classVal);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public double TestdOcrClassBox(HImage image, HOCRBox ocrHandle, string classVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(725);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, ocrHandle);
			SZXCArimAPI.StoreS(proc, 1, classVal);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(ocrHandle);
			return result;
		}

		public void AppendOcrTrainf(HImage image, HTuple classVal, string trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(730);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, classVal);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(classVal);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public void AppendOcrTrainf(HImage image, string classVal, string trainingFile)
		{
			IntPtr proc = SZXCArimAPI.PreCall(730);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, classVal);
			SZXCArimAPI.StoreS(proc, 1, trainingFile);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public HRegion Pruning(int length)
		{
			IntPtr proc = SZXCArimAPI.PreCall(735);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, length);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Boundary(string boundaryType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(736);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, boundaryType);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Fitting(HRegion structElements)
		{
			IntPtr proc = SZXCArimAPI.PreCall(737);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElements);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElements);
			return result;
		}

		public void GenStructElements(string type, int row, int column)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(738);
			SZXCArimAPI.StoreS(proc, 0, type);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion TransposeRegion(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(739);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ThinningSeq(string golayElement, HTuple iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(740);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.Store(proc, 1, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(iterations);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ThinningSeq(string golayElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(740);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ThinningGolay(string golayElement, int rotation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(741);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, rotation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Thinning(HRegion structElement1, HRegion structElement2, int row, int column, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(742);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement1);
			SZXCArimAPI.Store(proc, 3, structElement2);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement1);
			GC.KeepAlive(structElement2);
			return result;
		}

		public HRegion ThickeningSeq(string golayElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(743);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ThickeningGolay(string golayElement, int rotation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(744);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, rotation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Thickening(HRegion structElement1, HRegion structElement2, int row, int column, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(745);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement1);
			SZXCArimAPI.Store(proc, 3, structElement2);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement1);
			GC.KeepAlive(structElement2);
			return result;
		}

		public HRegion HitOrMissSeq(string golayElement)
		{
			IntPtr proc = SZXCArimAPI.PreCall(746);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion HitOrMissGolay(string golayElement, int rotation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(747);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, rotation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion HitOrMiss(HRegion structElement1, HRegion structElement2, int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(748);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement1);
			SZXCArimAPI.Store(proc, 3, structElement2);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement1);
			GC.KeepAlive(structElement2);
			return result;
		}

		public HRegion GolayElements(string golayElement, int rotation, int row, int column)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(749);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, rotation);
			SZXCArimAPI.StoreI(proc, 2, row);
			SZXCArimAPI.StoreI(proc, 3, column);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			HRegion result;
			num = HRegion.LoadNew(proc, 2, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion MorphSkiz(HTuple iterations1, HTuple iterations2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(750);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, iterations1);
			SZXCArimAPI.Store(proc, 1, iterations2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(iterations1);
			SZXCArimAPI.UnpinTuple(iterations2);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion MorphSkiz(int iterations1, int iterations2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(750);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, iterations1);
			SZXCArimAPI.StoreI(proc, 1, iterations2);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion MorphSkeleton()
		{
			IntPtr proc = SZXCArimAPI.PreCall(751);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion MorphHat(HRegion structElement)
		{
			IntPtr proc = SZXCArimAPI.PreCall(752);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion BottomHat(HRegion structElement)
		{
			IntPtr proc = SZXCArimAPI.PreCall(753);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion TopHat(HRegion structElement)
		{
			IntPtr proc = SZXCArimAPI.PreCall(754);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion MinkowskiSub2(HRegion structElement, int row, int column, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(755);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion MinkowskiSub1(HRegion structElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(756);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion MinkowskiAdd2(HRegion structElement, int row, int column, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(757);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion MinkowskiAdd1(HRegion structElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(758);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion ClosingRectangle1(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(759);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ClosingGolay(string golayElement, int rotation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(760);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, rotation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ClosingCircle(HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(761);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(radius);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ClosingCircle(double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(761);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Closing(HRegion structElement)
		{
			IntPtr proc = SZXCArimAPI.PreCall(762);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion OpeningSeg(HRegion structElement)
		{
			IntPtr proc = SZXCArimAPI.PreCall(763);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion OpeningGolay(string golayElement, int rotation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(764);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, rotation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion OpeningRectangle1(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(765);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion OpeningCircle(HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(766);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(radius);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion OpeningCircle(double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(766);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Opening(HRegion structElement)
		{
			IntPtr proc = SZXCArimAPI.PreCall(767);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion ErosionSeq(string golayElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(768);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ErosionGolay(string golayElement, int iterations, int rotation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(769);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.StoreI(proc, 2, rotation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ErosionRectangle1(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(770);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ErosionCircle(HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(771);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(radius);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ErosionCircle(double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(771);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Erosion2(HRegion structElement, int row, int column, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(772);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion Erosion1(HRegion structElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(773);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion DilationSeq(string golayElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(774);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion DilationGolay(string golayElement, int iterations, int rotation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(775);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, golayElement);
			SZXCArimAPI.StoreI(proc, 1, iterations);
			SZXCArimAPI.StoreI(proc, 2, rotation);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion DilationRectangle1(int width, int height)
		{
			IntPtr proc = SZXCArimAPI.PreCall(776);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, width);
			SZXCArimAPI.StoreI(proc, 1, height);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion DilationCircle(HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(777);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(radius);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion DilationCircle(double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(777);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion Dilation2(HRegion structElement, int row, int column, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(778);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.StoreI(proc, 2, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HRegion Dilation1(HRegion structElement, int iterations)
		{
			IntPtr proc = SZXCArimAPI.PreCall(779);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, structElement);
			SZXCArimAPI.StoreI(proc, 0, iterations);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(structElement);
			return result;
		}

		public HImage AddChannels(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1144);
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

		public HRegion HoughCircles(HTuple radius, HTuple percent, HTuple mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1149);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, radius);
			SZXCArimAPI.Store(proc, 1, percent);
			SZXCArimAPI.Store(proc, 2, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(radius);
			SZXCArimAPI.UnpinTuple(percent);
			SZXCArimAPI.UnpinTuple(mode);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion HoughCircles(int radius, int percent, int mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1149);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, radius);
			SZXCArimAPI.StoreI(proc, 1, percent);
			SZXCArimAPI.StoreI(proc, 2, mode);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage HoughCircleTrans(HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1150);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(radius);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage HoughCircleTrans(int radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1150);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, radius);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple HoughLines(int angleResolution, int threshold, int angleGap, int distGap, out HTuple dist)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1153);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, angleResolution);
			SZXCArimAPI.StoreI(proc, 1, threshold);
			SZXCArimAPI.StoreI(proc, 2, angleGap);
			SZXCArimAPI.StoreI(proc, 3, distGap);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out dist);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HImage HoughLineTrans(int angleResolution)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1154);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, angleResolution);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SelectMatchingLines(HTuple angleIn, HTuple distIn, int lineWidth, int thresh, out HTuple angleOut, out HTuple distOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1155);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, angleIn);
			SZXCArimAPI.Store(proc, 1, distIn);
			SZXCArimAPI.StoreI(proc, 2, lineWidth);
			SZXCArimAPI.StoreI(proc, 3, thresh);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(angleIn);
			SZXCArimAPI.UnpinTuple(distIn);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out angleOut);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out distOut);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SelectMatchingLines(double angleIn, double distIn, int lineWidth, int thresh, out double angleOut, out double distOut)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1155);
			base.Store(proc, 1);
			SZXCArimAPI.StoreD(proc, 0, angleIn);
			SZXCArimAPI.StoreD(proc, 1, distIn);
			SZXCArimAPI.StoreI(proc, 2, lineWidth);
			SZXCArimAPI.StoreI(proc, 3, thresh);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			num = SZXCArimAPI.LoadD(proc, 0, num, out angleOut);
			num = SZXCArimAPI.LoadD(proc, 1, num, out distOut);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void GetIcon(HWindow windowHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1260);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void SetIcon(HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1261);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DispRegion(HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1262);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public HRegion DragRegion3(HRegion maskRegion, HWindow windowHandle, int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1315);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, maskRegion);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(maskRegion);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public HRegion DragRegion2(HWindow windowHandle, int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1316);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public HRegion DragRegion1(HWindow windowHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1317);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
			return result;
		}

		public void DrawRegion(HWindow windowHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1336);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DrawPolygon(HWindow windowHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1337);
			SZXCArimAPI.Store(proc, 0, windowHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(windowHandle);
		}

		public void DistanceSr(HTuple row1, HTuple column1, HTuple row2, HTuple column2, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1367);
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

		public void DistanceSr(double row1, double column1, double row2, double column2, out double distanceMin, out double distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1367);
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

		public void DistanceLr(HTuple row1, HTuple column1, HTuple row2, HTuple column2, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1368);
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

		public void DistanceLr(double row1, double column1, double row2, double column2, out double distanceMin, out double distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1368);
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

		public void DistancePr(HTuple row, HTuple column, out HTuple distanceMin, out HTuple distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1369);
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

		public void DistancePr(double row, double column, out double distanceMin, out double distanceMax)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1369);
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

		public HTuple NoiseDistributionMean(HImage image, int filterSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1440);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreI(proc, 0, filterSize);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple FuzzyEntropy(HImage image, int apar, int cpar)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1457);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreI(proc, 0, apar);
			SZXCArimAPI.StoreI(proc, 1, cpar);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple FuzzyPerimeter(HImage image, int apar, int cpar)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1458);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreI(proc, 0, apar);
			SZXCArimAPI.StoreI(proc, 1, cpar);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage RegionToMean(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1476);
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

		public HRegion CloseEdgesLength(HImage gradient, int minAmplitude, int maxGapLength)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1573);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, gradient);
			SZXCArimAPI.StoreI(proc, 0, minAmplitude);
			SZXCArimAPI.StoreI(proc, 1, maxGapLength);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(gradient);
			return result;
		}

		public HRegion CloseEdges(HImage edgeImage, int minAmplitude)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1574);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, edgeImage);
			SZXCArimAPI.StoreI(proc, 0, minAmplitude);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(edgeImage);
			return result;
		}

		public void DeserializeRegion(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1652);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeRegion()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1653);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void WriteRegion(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1654);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadRegion(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1657);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 1, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple MomentsRegionCentralInvar(out HTuple PSI2, out HTuple PSI3, out HTuple PSI4)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1694);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out PSI2);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out PSI3);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out PSI4);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsRegionCentralInvar(out double PSI2, out double PSI3, out double PSI4)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1694);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out PSI2);
			num = SZXCArimAPI.LoadD(proc, 2, num, out PSI3);
			num = SZXCArimAPI.LoadD(proc, 3, num, out PSI4);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsRegionCentral(out HTuple i2, out HTuple i3, out HTuple i4)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1695);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out i2);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out i3);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out i4);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsRegionCentral(out double i2, out double i3, out double i4)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1695);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out i2);
			num = SZXCArimAPI.LoadD(proc, 2, num, out i3);
			num = SZXCArimAPI.LoadD(proc, 3, num, out i4);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsRegion3rdInvar(out HTuple m12, out HTuple m03, out HTuple m30)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1696);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out m12);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out m03);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out m30);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsRegion3rdInvar(out double m12, out double m03, out double m30)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1696);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out m12);
			num = SZXCArimAPI.LoadD(proc, 2, num, out m03);
			num = SZXCArimAPI.LoadD(proc, 3, num, out m30);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsRegion3rd(out HTuple m12, out HTuple m03, out HTuple m30)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1697);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out m12);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out m03);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out m30);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsRegion3rd(out double m12, out double m03, out double m30)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1697);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out m12);
			num = SZXCArimAPI.LoadD(proc, 2, num, out m03);
			num = SZXCArimAPI.LoadD(proc, 3, num, out m30);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void SmallestRectangle2(out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1698);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out phi);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out length1);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out length2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestRectangle2(out double row, out double column, out double phi, out double length1, out double length2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1698);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out phi);
			num = SZXCArimAPI.LoadD(proc, 3, num, out length1);
			num = SZXCArimAPI.LoadD(proc, 4, num, out length2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestRectangle1(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1699);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out row1);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out column1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out row2);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestRectangle1(out int row1, out int column1, out int row2, out int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1699);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadI(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadI(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestCircle(out HTuple row, out HTuple column, out HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1700);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void SmallestCircle(out double row, out double column, out double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1700);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HRegion SelectShapeProto(HRegion pattern, HTuple feature, HTuple min, HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1701);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, pattern);
			SZXCArimAPI.Store(proc, 0, feature);
			SZXCArimAPI.Store(proc, 1, min);
			SZXCArimAPI.Store(proc, 2, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(feature);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(pattern);
			return result;
		}

		public HRegion SelectShapeProto(HRegion pattern, string feature, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1701);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, pattern);
			SZXCArimAPI.StoreS(proc, 0, feature);
			SZXCArimAPI.StoreD(proc, 1, min);
			SZXCArimAPI.StoreD(proc, 2, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(pattern);
			return result;
		}

		public HTuple RegionFeatures(HTuple features)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1702);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, features);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double RegionFeatures(string features)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1702);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SelectShape(HTuple features, string operation, HTuple min, HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1703);
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
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SelectShape(string features, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1703);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple RunlengthFeatures(out HTuple KFactor, out HTuple LFactor, out HTuple meanLength, out HTuple bytes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1704);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out KFactor);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out LFactor);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out meanLength);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out bytes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int RunlengthFeatures(out double KFactor, out double LFactor, out double meanLength, out int bytes)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1704);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out KFactor);
			num = SZXCArimAPI.LoadD(proc, 2, num, out LFactor);
			num = SZXCArimAPI.LoadD(proc, 3, num, out meanLength);
			num = SZXCArimAPI.LoadI(proc, 4, num, out bytes);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple FindNeighbors(HRegion regions2, int maxDistance, out HTuple regionIndex2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1705);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.StoreI(proc, 0, maxDistance);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out regionIndex2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public HTuple MomentsRegion2ndRelInvar(out HTuple PHI2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1706);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out PHI2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsRegion2ndRelInvar(out double PHI2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1706);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out PHI2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsRegion2ndInvar(out HTuple m20, out HTuple m02)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1707);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out m20);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out m02);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsRegion2ndInvar(out double m20, out double m02)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1707);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out m20);
			num = SZXCArimAPI.LoadD(proc, 2, num, out m02);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple MomentsRegion2nd(out HTuple m20, out HTuple m02, out HTuple ia, out HTuple ib)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1708);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out m20);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out m02);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out ia);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out ib);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double MomentsRegion2nd(out double m20, out double m02, out double ia, out double ib)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1708);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out m20);
			num = SZXCArimAPI.LoadD(proc, 2, num, out m02);
			num = SZXCArimAPI.LoadD(proc, 3, num, out ia);
			num = SZXCArimAPI.LoadD(proc, 4, num, out ib);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple DistanceRrMin(HRegion regions2, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1709);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out row1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out column1);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out row2);
			num = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public double DistanceRrMin(HRegion regions2, out int row1, out int column1, out int row2, out int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1709);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out row1);
			num = SZXCArimAPI.LoadI(proc, 2, num, out column1);
			num = SZXCArimAPI.LoadI(proc, 3, num, out row2);
			num = SZXCArimAPI.LoadI(proc, 4, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public HTuple DistanceRrMinDil(HRegion regions2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1710);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public void DiameterRegion(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2, out HTuple diameter)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1711);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out row1);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out column1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out row2);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out column2);
			num = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, num, out diameter);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void DiameterRegion(out int row1, out int column1, out int row2, out int column2, out double diameter)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1711);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 4);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadI(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadI(proc, 3, num, out column2);
			num = SZXCArimAPI.LoadD(proc, 4, num, out diameter);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public int TestRegionPoint(HTuple row, HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1712);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, row);
			SZXCArimAPI.Store(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(row);
			SZXCArimAPI.UnpinTuple(column);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int TestRegionPoint(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1712);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetRegionIndex(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1713);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SelectRegionPoint(int row, int column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1714);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, row);
			SZXCArimAPI.StoreI(proc, 1, column);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion SelectShapeStd(string shape, double percent)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1715);
			base.Store(proc, 1);
			SZXCArimAPI.StoreS(proc, 0, shape);
			SZXCArimAPI.StoreD(proc, 1, percent);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple HammingDistanceNorm(HRegion regions2, HTuple norm, out HTuple similarity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1716);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.Store(proc, 0, norm);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(norm);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out similarity);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public int HammingDistanceNorm(HRegion regions2, string norm, out double similarity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1716);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.StoreS(proc, 0, norm);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out similarity);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public HTuple HammingDistance(HRegion regions2, out HTuple similarity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1717);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out similarity);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public int HammingDistance(HRegion regions2, out double similarity)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1717);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out similarity);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public HTuple Eccentricity(out HTuple bulkiness, out HTuple structureFactor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1718);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out bulkiness);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out structureFactor);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double Eccentricity(out double bulkiness, out double structureFactor)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1718);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out bulkiness);
			num = SZXCArimAPI.LoadD(proc, 2, num, out structureFactor);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EulerNumber()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1719);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple OrientationRegion()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1720);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple EllipticAxis(out HTuple rb, out HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1721);
			base.Store(proc, 1);
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
			return result;
		}

		public double EllipticAxis(out double rb, out double phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1721);
			base.Store(proc, 1);
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
			return result;
		}

		public HTuple SelectRegionSpatial(HRegion regions2, string direction, out HTuple regionIndex2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1722);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.StoreS(proc, 0, direction);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out regionIndex2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public HTuple SpatialRelation(HRegion regions2, int percent, out HTuple regionIndex2, out HTuple relation1, out HTuple relation2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1723);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, regions2);
			SZXCArimAPI.StoreI(proc, 0, percent);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out regionIndex2);
			num = HTuple.LoadNew(proc, 2, num, out relation1);
			num = HTuple.LoadNew(proc, 3, num, out relation2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(regions2);
			return result;
		}

		public HTuple Convexity()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1724);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple Contlength()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1725);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple ConnectAndHoles(out HTuple numHoles)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1726);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out numHoles);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int ConnectAndHoles(out int numHoles)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1726);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out numHoles);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple Rectangularity()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1727);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple Compactness()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1728);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple Circularity()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1729);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple AreaHoles()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1730);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple AreaCenter(out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1731);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int AreaCenter(out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1731);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out row);
			num = SZXCArimAPI.LoadD(proc, 2, num, out column);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple RunlengthDistribution(out HTuple background)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1732);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out background);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple Roundness(out HTuple sigma, out HTuple roundness, out HTuple sides)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1733);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out sigma);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out roundness);
			num = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, num, out sides);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public double Roundness(out double sigma, out double roundness, out double sides)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1733);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out sigma);
			num = SZXCArimAPI.LoadD(proc, 2, num, out roundness);
			num = SZXCArimAPI.LoadD(proc, 3, num, out sides);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void InnerRectangle1(out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1734);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out row1);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out column1);
			num = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, num, out row2);
			num = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void InnerRectangle1(out int row1, out int column1, out int row2, out int column2)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1734);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadI(proc, 0, num, out row1);
			num = SZXCArimAPI.LoadI(proc, 1, num, out column1);
			num = SZXCArimAPI.LoadI(proc, 2, num, out row2);
			num = SZXCArimAPI.LoadI(proc, 3, num, out column2);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void InnerCircle(out HTuple row, out HTuple column, out HTuple radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1735);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out row);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out column);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void InnerCircle(out double row, out double column, out double radius)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1735);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = SZXCArimAPI.LoadD(proc, 0, num, out row);
			num = SZXCArimAPI.LoadD(proc, 1, num, out column);
			num = SZXCArimAPI.LoadD(proc, 2, num, out radius);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HTuple FitSurfaceFirstOrder(HImage image, string algorithm, int iterations, double clippingFactor, out HTuple beta, out HTuple gamma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1743);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public double FitSurfaceFirstOrder(HImage image, string algorithm, int iterations, double clippingFactor, out double beta, out double gamma)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1743);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public HTuple FitSurfaceSecondOrder(HImage image, string algorithm, int iterations, double clippingFactor, out HTuple beta, out HTuple gamma, out HTuple delta, out HTuple epsilon, out HTuple zeta)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1744);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public double FitSurfaceSecondOrder(HImage image, string algorithm, int iterations, double clippingFactor, out double beta, out double gamma, out double delta, out double epsilon, out double zeta)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1744);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public HTuple ShapeHistoPoint(HImage image, string feature, int row, int column, out HTuple relativeHisto)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1747);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, feature);
			SZXCArimAPI.StoreI(proc, 1, row);
			SZXCArimAPI.StoreI(proc, 2, column);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out relativeHisto);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple ShapeHistoAll(HImage image, string feature, out HTuple relativeHisto)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1748);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, feature);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out relativeHisto);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple GrayFeatures(HImage image, HTuple features)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1749);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, features);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public double GrayFeatures(HImage image, string features)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1749);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HRegion SelectGray(HImage image, HTuple features, string operation, HTuple min, HTuple max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1750);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.Store(proc, 2, min);
			SZXCArimAPI.Store(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(features);
			SZXCArimAPI.UnpinTuple(min);
			SZXCArimAPI.UnpinTuple(max);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HRegion SelectGray(HImage image, string features, string operation, double min, double max)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1750);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, features);
			SZXCArimAPI.StoreS(proc, 1, operation);
			SZXCArimAPI.StoreD(proc, 2, min);
			SZXCArimAPI.StoreD(proc, 3, max);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void MinMaxGray(HImage image, HTuple percent, out HTuple min, out HTuple max, out HTuple range)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1751);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
		}

		public void MinMaxGray(HImage image, double percent, out double min, out double max, out double range)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1751);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
		}

		public HTuple Intensity(HImage image, out HTuple deviation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1752);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out deviation);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public double Intensity(HImage image, out double deviation)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1752);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out deviation);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple GrayHistoRange(HImage image, HTuple min, HTuple max, int numBins, out double binSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1753);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public int GrayHistoRange(HImage image, double min, double max, int numBins, out double binSize)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1753);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public HImage Histo2dim(HImage imageCol, HImage imageRow)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1754);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, imageCol);
			SZXCArimAPI.Store(proc, 3, imageRow);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(imageCol);
			GC.KeepAlive(imageRow);
			return result;
		}

		public HTuple GrayHistoAbs(HImage image, HTuple quantization)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1755);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, quantization);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(quantization);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple GrayHistoAbs(HImage image, double quantization)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1755);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreD(proc, 0, quantization);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple GrayHisto(HImage image, out HTuple relativeHisto)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1756);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out relativeHisto);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple EntropyGray(HImage image, out HTuple anisotropy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1757);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out anisotropy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public double EntropyGray(HImage image, out double anisotropy)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1757);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out anisotropy);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple CoocFeatureImage(HImage image, int ldGray, HTuple direction, out HTuple correlation, out HTuple homogeneity, out HTuple contrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1759);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public double CoocFeatureImage(HImage image, int ldGray, int direction, out double correlation, out double homogeneity, out double contrast)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1759);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public HImage GenCoocMatrix(HImage image, int ldGray, int direction)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1760);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreI(proc, 0, ldGray);
			SZXCArimAPI.StoreI(proc, 1, direction);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void MomentsGrayPlane(HImage image, out HTuple MRow, out HTuple MCol, out HTuple alpha, out HTuple beta, out HTuple mean)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1761);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
		}

		public void MomentsGrayPlane(HImage image, out double MRow, out double MCol, out double alpha, out double beta, out double mean)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1761);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
		}

		public HTuple PlaneDeviation(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1762);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HTuple EllipticAxisGray(HImage image, out HTuple rb, out HTuple phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1763);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public double EllipticAxisGray(HImage image, out double rb, out double phi)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1763);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public HTuple AreaCenterGray(HImage image, out HTuple row, out HTuple column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1764);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public double AreaCenterGray(HImage image, out double row, out double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1764);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
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
			GC.KeepAlive(image);
			return result;
		}

		public HTuple GrayProjections(HImage image, string mode, out HTuple vertProjection)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1765);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.StoreS(proc, 0, mode);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out vertProjection);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HImage GrabDataAsync(out HXLDCont contours, HFramegrabber acqHandle, double maxDelay, out HTuple data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2029);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 2, num);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public HImage GrabDataAsync(out HXLDCont contours, HFramegrabber acqHandle, double maxDelay, out string data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2029);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.StoreD(proc, 1, maxDelay);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 2, num);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = SZXCArimAPI.LoadS(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public HImage GrabData(out HXLDCont contours, HFramegrabber acqHandle, out HTuple data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2030);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 2, num);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = HTuple.LoadNew(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public HImage GrabData(out HXLDCont contours, HFramegrabber acqHandle, out string data)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(2030);
			SZXCArimAPI.Store(proc, 0, acqHandle);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 3);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 2, num);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HXLDCont.LoadNew(proc, 3, num, out contours);
			num = SZXCArimAPI.LoadS(proc, 0, num, out data);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(acqHandle);
			return result;
		}

		public HTuple DoOcrMultiClassCnn(HImage image, HOCRCnn OCRHandle, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2056);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrMultiClassCnn(HImage image, HOCRCnn OCRHandle, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2056);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrSingleClassCnn(HImage image, HOCRCnn OCRHandle, HTuple num, out HTuple confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2057);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			HTuple result;
			num2 = HTuple.LoadNew(proc, 0, num2, out result);
			num2 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrSingleClassCnn(HImage image, HOCRCnn OCRHandle, HTuple num, out double confidence)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2057);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.Store(proc, 1, num);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num2 = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(num);
			string result;
			num2 = SZXCArimAPI.LoadS(proc, 0, num2, out result);
			num2 = SZXCArimAPI.LoadD(proc, 1, num2, out confidence);
			SZXCArimAPI.PostCall(proc, num2);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple DoOcrWordCnn(HImage image, HOCRCnn OCRHandle, string expression, int numAlternatives, int numCorrections, out HTuple confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2058);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public string DoOcrWordCnn(HImage image, HOCRCnn OCRHandle, string expression, int numAlternatives, int numCorrections, out double confidence, out string word, out double score)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2058);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, image);
			SZXCArimAPI.Store(proc, 0, OCRHandle);
			SZXCArimAPI.StoreS(proc, 1, expression);
			SZXCArimAPI.StoreI(proc, 2, numAlternatives);
			SZXCArimAPI.StoreI(proc, 3, numCorrections);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadD(proc, 1, num, out confidence);
			num = SZXCArimAPI.LoadS(proc, 2, num, out word);
			num = SZXCArimAPI.LoadD(proc, 3, num, out score);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			GC.KeepAlive(OCRHandle);
			return result;
		}

		public HTuple HeightWidthRatio(out HTuple width, out HTuple ratio)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2119);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, num, out width);
			num = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, num, out ratio);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int HeightWidthRatio(out int width, out double ratio)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2119);
			base.Store(proc, 1);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out width);
			num = SZXCArimAPI.LoadD(proc, 2, num, out ratio);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion InsertObj(HRegion objectsInsert, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2121);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsInsert);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsInsert);
			return result;
		}

		public new HRegion RemoveObj(HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public new HRegion RemoveObj(int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2124);
			base.Store(proc, 1);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HRegion ReplaceObj(HRegion objectsReplace, HTuple index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.Store(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(index);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}

		public HRegion ReplaceObj(HRegion objectsReplace, int index)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2125);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 2, objectsReplace);
			SZXCArimAPI.StoreI(proc, 0, index);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(objectsReplace);
			return result;
		}
	}
}
