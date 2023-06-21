using System;

namespace SZXCArimEngine
{
	public class HDevProgram : IDisposable
	{
		private IntPtr program = IntPtr.Zero;

		private string name = "";

		private bool loaded;

		private HTuple varNamesIconic = new HTuple();

		private HTuple varNamesCtrl = new HTuple();

		private HTuple varDimsIconic = new HTuple();

		private HTuple varDimsCtrl = new HTuple();

		internal IntPtr Handle
		{
			get
			{
				return this.program;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public HDevProgram()
		{
			HDevProgram.HCkE(EngineAPI.CreateProgram(out this.program));
			GC.KeepAlive(this);
		}

		public HDevProgram(string fileName) : this()
		{
			this.LoadProgram(fileName);
		}

		public void LoadProgram(string fileName)
		{
			HDevProgram.HCkE(EngineAPI.LoadProgram(this.program, fileName));
			EngineAPI.GetProgramInfo(this.program, out this.name, out this.loaded, out this.varNamesIconic, out this.varNamesCtrl, out this.varDimsIconic, out this.varDimsCtrl);
			GC.KeepAlive(this);
		}

		public HDevProgramCall CreateCall()
		{
			return new HDevProgramCall(this);
		}

		public HDevProgramCall Execute()
		{
			HDevProgramCall hDevProgramCall = new HDevProgramCall(this);
			hDevProgramCall.Execute();
			return hDevProgramCall;
		}

		public bool IsLoaded()
		{
			return this.loaded;
		}

		public bool IsInitialized()
		{
			return this.program != IntPtr.Zero;
		}

		public HTuple GetIconicVarNames()
		{
			return this.varNamesIconic;
		}

		public HTuple GetCtrlVarNames()
		{
			return this.varNamesCtrl;
		}

		public HTuple GetIconicVarDimensions()
		{
			return this.varDimsIconic;
		}

		public HTuple GetCtrlVarDimensions()
		{
			return this.varDimsCtrl;
		}

		public int GetIconicVarCount()
		{
			return this.varNamesIconic.Length;
		}

		public int GetCtrlVarCount()
		{
			return this.varNamesCtrl.Length;
		}

		public string GetIconicVarName(int index)
		{
			if (index < 1 || index > this.varNamesIconic.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetIconicVarName");
			}
			return this.varNamesIconic.SArr[index - 1];
		}

		public string GetCtrlVarName(int index)
		{
			if (index < 1 || index > this.varNamesCtrl.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetCtrlVarName");
			}
			return this.varNamesCtrl.SArr[index - 1];
		}

		public int GetIconicVarDimension(int index)
		{
			if (index < 1 || index > this.varDimsIconic.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetIconicVarDimension");
			}
			return this.varDimsIconic[index - 1];
		}

		public int GetCtrlVarDimension(int index)
		{
			if (index < 1 || index > this.varDimsCtrl.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetCtrlVarDimension");
			}
			return this.varDimsCtrl[index - 1];
		}

		public HTuple GetUsedProcedureNames()
		{
			IntPtr intPtr;
			HDevProgram.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProgram.HCkE(EngineAPI.GetUsedProcedureNamesForProgram(this.program, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProgram.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public bool CompileUsedProcedures()
		{
			bool result;
			HDevProgram.HCkE(EngineAPI.CompileUsedProceduresForProgram(this.program, out result));
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetLocalProcedureNames()
		{
			IntPtr intPtr;
			HDevProgram.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProgram.HCkE(EngineAPI.GetLocalProcedureNames(this.program, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProgram.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		internal static void HCkE(int err)
		{
			EngineAPI.HCkE(err);
		}

		~HDevProgram()
		{
			try
			{
				this.Dispose();
			}
			catch (Exception)
			{
			}
		}

		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		public virtual void Dispose()
		{
			if (this.program != IntPtr.Zero)
			{
				EngineAPI.DestroyProgram(this.program);
				this.program = IntPtr.Zero;
				this.loaded = false;
			}
			GC.SuppressFinalize(this);
			GC.KeepAlive(this);
		}
	}
}
