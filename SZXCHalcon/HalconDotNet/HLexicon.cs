using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HLexicon : HHandle
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HLexicon() : base(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HLexicon(IntPtr handle) : base(handle)
		{
			this.AssertSemType();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HLexicon(HHandle handle) : base(handle)
		{
			this.AssertSemType();
		}

		private void AssertSemType()
		{
			base.AssertSemType("lexicon");
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HLexicon obj)
		{
			obj = new HLexicon(HHandleBase.UNDEF);
			return obj.Load(proc, parIndex, err);
		}

		internal static int LoadNew(IntPtr proc, int parIndex, int err, out HLexicon[] obj)
		{
			HTuple hTuple;
			err = HTuple.LoadNew(proc, parIndex, err, out hTuple);
			obj = new HLexicon[hTuple.Length];
			for (int i = 0; i < hTuple.Length; i++)
			{
				obj[i] = new HLexicon(SZXCArimAPI.IsLegacyHandleMode() ? hTuple[i].IP : hTuple[i].H);
			}
			hTuple.Dispose();
			return err;
		}

		public HLexicon(string name, string fileName)
		{
			IntPtr proc = SZXCArimAPI.PreCall(670);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public HLexicon(string name, HTuple words)
		{
			IntPtr proc = SZXCArimAPI.PreCall(671);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.Store(proc, 1, words);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(words);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void ClearLexicon()
		{
			IntPtr proc = SZXCArimAPI.PreCall(666);
			base.Store(proc, 0);
			int procResult = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.PostCall(proc, procResult);
			GC.KeepAlive(this);
		}

		public string SuggestLexicon(string word, out int numCorrections)
		{
			IntPtr proc = SZXCArimAPI.PreCall(667);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, word);
			SZXCArimAPI.InitOCT(proc, 0);
			SZXCArimAPI.InitOCT(proc, 1);
			int num = SZXCArimAPI.CallProcedure(proc);
			string result;
			num = SZXCArimAPI.LoadS(proc, 0, num, out result);
			num = SZXCArimAPI.LoadI(proc, 1, num, out numCorrections);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public int LookupLexicon(string word)
		{
			IntPtr proc = SZXCArimAPI.PreCall(668);
			base.Store(proc, 0);
			SZXCArimAPI.StoreS(proc, 1, word);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			int result;
			num = SZXCArimAPI.LoadI(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public HTuple InspectLexicon()
		{
			IntPtr proc = SZXCArimAPI.PreCall(669);
			base.Store(proc, 0);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			HTuple result;
			num = HTuple.LoadNew(proc, 0, num, out result);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
			return result;
		}

		public void ImportLexicon(string name, string fileName)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(670);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.StoreS(proc, 1, fileName);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}

		public void CreateLexicon(string name, HTuple words)
		{
			this.Dispose();
			IntPtr proc = SZXCArimAPI.PreCall(671);
			SZXCArimAPI.StoreS(proc, 0, name);
			SZXCArimAPI.Store(proc, 1, words);
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			SZXCArimAPI.UnpinTuple(words);
			num = base.Load(proc, 0, num);
			SZXCArimAPI.PostCall(proc, num);
			GC.KeepAlive(this);
		}
	}
}
