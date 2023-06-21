using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HColorTransLUT : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HColorTransLUT() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HColorTransLUT(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HColorTransLUT(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("color_trans_lut");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HColorTransLUT obj)
		{
			obj = new HColorTransLUT(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HColorTransLUT[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HColorTransLUT[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HColorTransLUT(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HColorTransLUT(string colorSpace, string transDirection, int numBits)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1579);
			SZXCArimAPI.StoreS(proc, 0, colorSpace);
			SZXCArimAPI.StoreS(proc, 1, transDirection);
			SZXCArimAPI.StoreI(proc, 2, numBits);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearColorTransLut()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1577);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HImage ApplyColorTransLut(HImage image1, HImage image2, HImage image3, out HImage imageResult2, out HImage imageResult3)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1578);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, image1);
			SZXCArimAPI.Store(proc, 2, image2);
			SZXCArimAPI.Store(proc, 3, image3);
			SZXCArimAPI.InitOCT(proc, 1);
			SZXCArimAPI.InitOCT(proc, 2);
			SZXCArimAPI.InitOCT(proc, 3);
			int num = SZXCArimAPI.CallProcedure(proc);
			HImage result;
			num = HImage.LoadNew(proc, 1, num, out result);
			num = HImage.LoadNew(proc, 2, num, out imageResult2);
			num = HImage.LoadNew(proc, 3, num, out imageResult3);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(image1);
			GC.KeepAlive(image2);
			GC.KeepAlive(image3);
			return result;
		}

		public void CreateColorTransLut(string colorSpace, string transDirection, int numBits)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1579);
			SZXCArimAPI.StoreS(proc, 0, colorSpace);
			SZXCArimAPI.StoreS(proc, 1, transDirection);
			SZXCArimAPI.StoreI(proc, 2, numBits);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
