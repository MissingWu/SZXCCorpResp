using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HFile : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFile() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFile(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HFile(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("file");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFile obj)
		{
			obj = new HFile(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFile[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HFile[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HFile(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HFile(string fileName, HTuple fileType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1659);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.Store(proc, 1, fileType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fileType);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HFile(string fileName, string fileType)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1659);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, fileType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenFile(string fileName, HTuple fileType)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1659);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.Store(proc, 1, fileType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(fileType);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void OpenFile(string fileName, string fileType)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(1659);
			SZXCArimAPI.StoreS(proc, 0, fileName);
			SZXCArimAPI.StoreS(proc, 1, fileType);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void FwriteString(HTuple stringVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1660);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, stringVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(stringVal);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public void FwriteString(string stringVal)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1660);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, stringVal);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string FreadLine(out int isEOF)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1661);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out isEOF);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string FreadString(out int isEOF)
		{
			IntPtr proc = SZXCArimAPI.PreCall(1662);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out isEOF);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public string FreadChar()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1663);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void FnewLine()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1664);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public static void CloseFile(HFile[] fileHandle)
		{
			HTuple hTuple = HHandleBase.ConcatArray(fileHandle);
			IntPtr expr_13 = SZXCArimAPI.PreCall(1665);
			SZXCArimAPI.Store(expr_13, 0, hTuple);
			int procResult = SZXCArimAPI.CallProcedure(expr_13);
			SZXCArimAPI.UnpinTuple(hTuple);
			SZXCArimAPI.PostCall(expr_13, procResult);
			GC.KeepAlive(fileHandle);
		}

		public void CloseFile()
		{
			IntPtr proc = SZXCArimAPI.PreCall(1665);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public HTuple FreadBytes(int numberOfBytes, out int isEOF)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2182);
			base.Store(proc, 0);
			SZXCArimAPI.StoreI(proc, 1, numberOfBytes);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out isEOF);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int FwriteBytes(HTuple dataToWrite)
		{
			IntPtr proc = SZXCArimAPI.PreCall(2183);
			base.Store(proc, 0);
			SZXCArimAPI.Store(proc, 1, dataToWrite);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(dataToWrite);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}
	}
}
