using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HTemplate : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTemplate() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTemplate(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTemplate(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("template");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTemplate obj)
		{
			obj = new HTemplate(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTemplate[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HTemplate[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HTemplate(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HTemplate(HImage template, int numLevel, double angleStart, double angleExtend, double angleStep, string optimize, string grayValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1488);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevel);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtend);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimize);
			SZXCArimAPI.StoreS(proc, 5, grayValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HTemplate(HImage template, int firstError, int numLevel, string optimize, string grayValues)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1489);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, firstError);
			SZXCArimAPI.StoreI(proc, 1, numLevel);
			SZXCArimAPI.StoreS(proc, 2, optimize);
			SZXCArimAPI.StoreS(proc, 3, grayValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HTemplate(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1493);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeTemplate();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HTemplate(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeTemplate(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeTemplate();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HTemplate Deserialize(Stream stream)
		{
			HTemplate arg_0C_0 = new HTemplate();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeTemplate(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HTemplate Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeTemplate();
			HTemplate expr_0C = new HTemplate();
			expr_0C.DeserializeTemplate(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public void CreateTemplateRot(HImage template, int numLevel, double angleStart, double angleExtend, double angleStep, string optimize, string grayValues)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1488);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, numLevel);
			SZXCArimAPI.StoreD(proc, 1, angleStart);
			SZXCArimAPI.StoreD(proc, 2, angleExtend);
			SZXCArimAPI.StoreD(proc, 3, angleStep);
			SZXCArimAPI.StoreS(proc, 4, optimize);
			SZXCArimAPI.StoreS(proc, 5, grayValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public void CreateTemplate(HImage template, int firstError, int numLevel, string optimize, string grayValues)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1489);
			SZXCArimAPI.Store(proc, 1, template);
			SZXCArimAPI.StoreI(proc, 0, firstError);
			SZXCArimAPI.StoreI(proc, 1, numLevel);
			SZXCArimAPI.StoreS(proc, 2, optimize);
			SZXCArimAPI.StoreS(proc, 3, grayValues);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(template);
		}

		public HSerializedItem SerializeTemplate()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1490);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void DeserializeTemplate(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1491);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public void WriteTemplate(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1492);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void ReadTemplate(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1493);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearTemplate()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1495);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetOffsetTemplate(int grayOffset)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1496);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, grayOffset);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void SetReferenceTemplate(double row, double column)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1497);
			base.Store(proc, 0);
			SZXCArimAPI.StoreD(proc, 1, row);
			SZXCArimAPI.StoreD(proc, 2, column);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void AdaptTemplate(HImage image)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1498);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
		}

		public HRegion FastMatchMg(HImage image, double maxError, HTuple numLevel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1499);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.Store(proc, 2, numLevel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(numLevel);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public HRegion FastMatchMg(HImage image, double maxError, int numLevel)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1499);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.StoreI(proc, 2, numLevel);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void BestMatchPreMg(HImage imagePyramid, double maxError, string subPixel, int numLevels, HTuple whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1500);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imagePyramid);
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
			GC.KeepAlive(imagePyramid);
		}

		public void BestMatchPreMg(HImage imagePyramid, double maxError, string subPixel, int numLevels, int whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1500);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, imagePyramid);
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
			GC.KeepAlive(imagePyramid);
		}

		public void BestMatchMg(HImage image, double maxError, string subPixel, int numLevels, HTuple whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1501);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}

		public void BestMatchMg(HImage image, double maxError, string subPixel, int numLevels, int whichLevels, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1501);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}

		public HRegion FastMatch(HImage image, double maxError)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1502);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
			SZXCArimAPI.StoreD(proc, 1, maxError);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HRegion result;
			num = HRegion.LoadNew(proc, 1, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image);
			return result;
		}

		public void BestMatchRotMg(HImage image, double angleStart, double angleExtend, double maxError, string subPixel, int numLevels, out HTuple row, out HTuple column, out HTuple angle, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1503);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}

		public void BestMatchRotMg(HImage image, double angleStart, double angleExtend, double maxError, string subPixel, int numLevels, out double row, out double column, out double angle, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1503);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}

		public void BestMatchRot(HImage image, double angleStart, double angleExtend, double maxError, string subPixel, out HTuple row, out HTuple column, out HTuple angle, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1504);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}

		public void BestMatchRot(HImage image, double angleStart, double angleExtend, double maxError, string subPixel, out double row, out double column, out double angle, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1504);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}

		public void BestMatch(HImage image, double maxError, string subPixel, out HTuple row, out HTuple column, out HTuple error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1505);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}

		public void BestMatch(HImage image, double maxError, string subPixel, out double row, out double column, out double error)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1505);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image);
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
			GC.KeepAlive(image);
		}
	}
}
