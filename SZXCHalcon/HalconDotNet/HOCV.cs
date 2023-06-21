using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace SZXCArimEngine
{
	[Serializable]
	public class HOCV : HHandle, ISerializable, ICloneable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCV() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCV(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCV(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("ocv");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCV obj)
		{
			obj = new HOCV(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCV[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HOCV[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HOCV(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HOCV(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(642);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HOCV(HTuple patternNames)
		{
			IntPtr proc = SZXCArimAPI.PreCall(646);
			SZXCArimAPI.Store(proc, 0, patternNames);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(patternNames);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem expr_06 = this.SerializeOcv();
			byte[] value = expr_06;
			expr_06.Dispose();
			info.AddValue("data", value, typeof(byte[]));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HOCV(SerializationInfo info, StreamingContext context)
		{
			HSerializedItem hSerializedItem = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
			this.DeserializeOcv(hSerializedItem);
			hSerializedItem.Dispose();
		}

		public new void Serialize(Stream stream)
		{
			HSerializedItem expr_06 = this.SerializeOcv();
			expr_06.Serialize(stream);
			expr_06.Dispose();
		}

		public new static HOCV Deserialize(Stream stream)
		{
			HOCV arg_0C_0 = new HOCV();
			HSerializedItem hSerializedItem = HSerializedItem.Deserialize(stream);
			arg_0C_0.DeserializeOcv(hSerializedItem);
			hSerializedItem.Dispose();
			return arg_0C_0;
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}

		public new HOCV Clone()
		{
			HSerializedItem hSerializedItem = this.SerializeOcv();
			HOCV expr_0C = new HOCV();
			expr_0C.DeserializeOcv(hSerializedItem);
			hSerializedItem.Dispose();
			return expr_0C;
		}

		public HTuple DoOcvSimple(HImage pattern, HTuple patternName, string adaptPos, string adaptSize, string adaptAngle, string adaptGray, double threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(638);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pattern);
			SZXCArimAPI.Store(proc, 1, patternName);
			SZXCArimAPI.StoreS(proc, 2, adaptPos);
			SZXCArimAPI.StoreS(proc, 3, adaptSize);
			SZXCArimAPI.StoreS(proc, 4, adaptAngle);
			SZXCArimAPI.StoreS(proc, 5, adaptGray);
			SZXCArimAPI.StoreD(proc, 6, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(patternName);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(pattern);
			return result;
		}

		public double DoOcvSimple(HImage pattern, string patternName, string adaptPos, string adaptSize, string adaptAngle, string adaptGray, double threshold)
		{
			IntPtr proc = SZXCArimAPI.PreCall(638);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pattern);
			SZXCArimAPI.StoreS(proc, 1, patternName);
			SZXCArimAPI.StoreS(proc, 2, adaptPos);
			SZXCArimAPI.StoreS(proc, 3, adaptSize);
			SZXCArimAPI.StoreS(proc, 4, adaptAngle);
			SZXCArimAPI.StoreS(proc, 5, adaptGray);
			SZXCArimAPI.StoreD(proc, 6, threshold);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(pattern);
			return result;
		}

		public void TraindOcvProj(HImage pattern, HTuple name, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(639);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pattern);
			SZXCArimAPI.Store(proc, 1, name);
			SZXCArimAPI.StoreS(proc, 2, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(name);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(pattern);
		}

		public void TraindOcvProj(HImage pattern, string name, string mode)
		{
			IntPtr proc = SZXCArimAPI.PreCall(639);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, pattern);
			SZXCArimAPI.StoreS(proc, 1, name);
			SZXCArimAPI.StoreS(proc, 2, mode);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(pattern);
		}

		public void DeserializeOcv(HSerializedItem serializedItemHandle)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(640);
			SZXCArimAPI.Store(proc, 0, serializedItemHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(serializedItemHandle);
		}

		public HSerializedItem SerializeOcv()
		{
			IntPtr proc = SZXCArimAPI.PreCall(641);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HSerializedItem result;
			num = HSerializedItem.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ReadOcv(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(642);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void WriteOcv(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(643);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CloseOcv()
		{
			IntPtr proc = SZXCArimAPI.PreCall(645);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void CreateOcvProj(HTuple patternNames)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(646);
			SZXCArimAPI.Store(proc, 0, patternNames);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(patternNames);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateOcvProj(string patternNames)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(646);
			SZXCArimAPI.StoreS(proc, 0, patternNames);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
