using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HFeatureSet : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFeatureSet() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFeatureSet(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFeatureSet(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("feature_set");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFeatureSet obj)
		{
			obj = new HFeatureSet(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFeatureSet[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HFeatureSet[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HFeatureSet(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HFeatureSet(string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1888);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ReadSampset(string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1888);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void LearnSampsetBox(HClassBox classifHandle, string outfile, int NSamples, double stopError, int errorN)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1890);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, classifHandle);
			SZXCArimAPI.StoreS(proc, 2, outfile);
			SZXCArimAPI.StoreI(proc, 3, NSamples);
			SZXCArimAPI.StoreD(proc, 4, stopError);
			SZXCArimAPI.StoreI(proc, 5, errorN);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
			GC.KeepAlive(classifHandle);
		}

		public void ClearSampset()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1893);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public double TestSampsetBox(HClassBox classifHandle)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1897);
			base.Store(proc, 1);
			SZXCArimAPI.Store(proc, 0, classifHandle);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			double result;
			num = SZXCArimAPI.LoadD(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			GC.KeepAlive(classifHandle);
			return result;
		}
	}
}
