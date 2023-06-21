using System;

namespace SZXCArimEngine
{
	public class HDevProcedure : IDisposable
	{
		private IntPtr procedure = IntPtr.Zero;

		private string name = "";

		private string shortDescription = "";

		private bool loaded;

		private HTuple parNamesIconicInput = new HTuple();

		private HTuple parNamesIconicOutput = new HTuple();

		private HTuple parNamesCtrlInput = new HTuple();

		private HTuple parNamesCtrlOutput = new HTuple();

		private HTuple parDimensionsIconicInput = new HTuple();

		private HTuple parDimensionsIconicOutput = new HTuple();

		private HTuple parDimensionsCtrlInput = new HTuple();

		private HTuple parDimensionsCtrlOutput = new HTuple();

		internal IntPtr Handle
		{
			get
			{
				return this.procedure;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public string ShortDescription
		{
			get
			{
				return this.shortDescription;
			}
		}

		public HDevProcedure()
		{
			HDevProcedure.HCkE(EngineAPI.CreateProcedure(out this.procedure));
			GC.KeepAlive(this);
		}

		public HDevProcedure(string procedureName) : this()
		{
			this.LoadProcedure(procedureName);
		}

		public HDevProcedure(string programName, string procedureName) : this()
		{
			this.LoadProcedure(programName, procedureName);
		}

		public HDevProcedure(HDevProgram program, string procedureName) : this()
		{
			this.LoadProcedure(program, procedureName);
		}

		internal void UpdateProcedureInfo()
		{
			EngineAPI.GetProcedureInfo(this.procedure, out this.name, out this.shortDescription, out this.loaded, out this.parNamesIconicInput, out this.parNamesIconicOutput, out this.parNamesCtrlInput, out this.parNamesCtrlOutput, out this.parDimensionsIconicInput, out this.parDimensionsIconicOutput, out this.parDimensionsCtrlInput, out this.parDimensionsCtrlOutput);
			GC.KeepAlive(this);
		}

		public void LoadProcedure(string procedureName)
		{
			HDevProcedure.HCkE(EngineAPI.LoadProcedure(this.procedure, procedureName));
			GC.KeepAlive(this);
			this.UpdateProcedureInfo();
		}

		public void LoadProcedure(string programName, string procedureName)
		{
			HDevProcedure.HCkE(EngineAPI.LoadProcedure(this.procedure, programName, procedureName));
			GC.KeepAlive(this);
			this.UpdateProcedureInfo();
		}

		public void LoadProcedure(HDevProgram program, string procedureName)
		{
			if (program.Handle == IntPtr.Zero)
			{
				HDevEngineException.ThrowGeneric("Uninitialized program while creating a local procedure call");
			}
			HDevProcedure.HCkE(EngineAPI.LoadProcedure(this.procedure, program.Handle, procedureName));
			GC.KeepAlive(this);
			this.UpdateProcedureInfo();
		}

		public HDevProcedureCall CreateCall()
		{
			return new HDevProcedureCall(this);
		}

		public HDevProcedureCall Execute()
		{
			HDevProcedureCall hDevProcedureCall = new HDevProcedureCall(this);
			hDevProcedureCall.Execute();
			return hDevProcedureCall;
		}

		public bool IsLoaded()
		{
			return this.loaded;
		}

		public bool IsInitialized()
		{
			return this.procedure != IntPtr.Zero;
		}

		public HTuple GetInputIconicParamNames()
		{
			return this.parNamesIconicInput;
		}

		public HTuple GetOutputIconicParamNames()
		{
			return this.parNamesIconicOutput;
		}

		public HTuple GetInputCtrlParamNames()
		{
			return this.parNamesCtrlInput;
		}

		public HTuple GetOutputCtrlParamNames()
		{
			return this.parNamesCtrlOutput;
		}

		public HTuple GetInputIconicParamDimensions()
		{
			return this.parDimensionsIconicInput;
		}

		public HTuple GetOutputIconicParamDimensions()
		{
			return this.parDimensionsIconicOutput;
		}

		public HTuple GetInputCtrlParamDimensions()
		{
			return this.parDimensionsCtrlInput;
		}

		public HTuple GetOutputCtrlParamDimensions()
		{
			return this.parDimensionsCtrlOutput;
		}

		public int GetInputIconicParamCount()
		{
			return this.parNamesIconicInput.Length;
		}

		public int GetOutputIconicParamCount()
		{
			return this.parNamesIconicOutput.Length;
		}

		public int GetInputCtrlParamCount()
		{
			return this.parNamesCtrlInput.Length;
		}

		public int GetOutputCtrlParamCount()
		{
			return this.parNamesCtrlOutput.Length;
		}

		public string GetInputIconicParamName(int index)
		{
			if (index < 1 || index > this.parNamesIconicInput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetInputIconicParamName");
			}
			return this.parNamesIconicInput.SArr[index - 1];
		}

		public string GetOutputIconicParamName(int index)
		{
			if (index < 1 || index > this.parNamesIconicOutput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetOutputIconicParamName");
			}
			return this.parNamesIconicOutput.SArr[index - 1];
		}

		public string GetInputCtrlParamName(int index)
		{
			if (index < 1 || index > this.parNamesCtrlInput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetInputCtrlParamName");
			}
			return this.parNamesCtrlInput.SArr[index - 1];
		}

		public string GetOutputCtrlParamName(int index)
		{
			if (index < 1 || index > this.parNamesCtrlOutput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetOutputCtrlParamName");
			}
			return this.parNamesCtrlOutput.SArr[index - 1];
		}

		public int GetInputIconicParamDimension(int index)
		{
			if (index < 1 || index > this.parDimensionsIconicInput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetInputIconicParamDimension");
			}
			return this.parDimensionsIconicInput[index - 1];
		}

		public int GetOutputIconicParamDimension(int index)
		{
			if (index < 1 || index > this.parDimensionsIconicOutput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetOutputIconicParamDimension");
			}
			return this.parDimensionsIconicOutput[index - 1];
		}

		public int GetInputCtrlParamDimension(int index)
		{
			if (index < 1 || index > this.parDimensionsCtrlInput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetInputCtrlParamDimension");
			}
			return this.parDimensionsCtrlInput[index - 1];
		}

		public int GetOutputCtrlParamDimension(int index)
		{
			if (index < 1 || index > this.parDimensionsCtrlOutput.Length)
			{
				HDevEngineException.ThrowGeneric("Bad index for GetOutputCtrlParamDimension");
			}
			return this.parDimensionsCtrlOutput[index - 1];
		}

		public HTuple GetUsedProcedureNames()
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.GetUsedProcedureNamesForProcedure(this.procedure, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public bool CompileUsedProcedures()
		{
			bool result;
			HDevProcedure.HCkE(EngineAPI.CompileUsedProceduresForProcedure(this.procedure, out result));
			GC.KeepAlive(this);
			return result;
		}

		public HTuple GetInfo(string slot)
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.GetProcInfo(this.procedure, slot, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public HTuple GetParamInfo(string parName, string slot)
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.GetParamInfo(this.procedure, parName, slot, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public HTuple GetInputIconicParamInfo(int parIdx, string slot)
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.GetInputIconicParamInfo(this.procedure, parIdx, slot, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public HTuple GetOutputIconicParamInfo(int parIdx, string slot)
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.GetOutputIconicParamInfo(this.procedure, parIdx, slot, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public HTuple GetInputCtrlParamInfo(int parIdx, string slot)
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.GetInputCtrlParamInfo(this.procedure, parIdx, slot, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public HTuple GetOutputCtrlParamInfo(int parIdx, string slot)
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.GetOutputCtrlParamInfo(this.procedure, parIdx, slot, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public HTuple QueryInfo()
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.QueryInfo(this.procedure, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		public HTuple QueryParamInfo()
		{
			IntPtr intPtr;
			HDevProcedure.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			HDevProcedure.HCkE(EngineAPI.QueryParamInfo(this.procedure, intPtr));
			GC.KeepAlive(this);
			HTuple result = SZXCArimAPI.LoadTuple(intPtr);
			HDevProcedure.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			return result;
		}

		internal static void HCkE(int err)
		{
			EngineAPI.HCkE(err);
		}

		~HDevProcedure()
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
			if (this.procedure != IntPtr.Zero)
			{
				EngineAPI.DestroyProcedure(this.procedure);
				this.procedure = IntPtr.Zero;
				this.loaded = false;
			}
			GC.SuppressFinalize(this);
			GC.KeepAlive(this);
		}
	}
}
