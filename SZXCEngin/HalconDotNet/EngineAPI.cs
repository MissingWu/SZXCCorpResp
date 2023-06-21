using System;
using System.Runtime.InteropServices;
using System.Security;

namespace SZXCArimEngine
{
	[SuppressUnmanagedCodeSecurity]
	public class EngineAPI
	{
		private const string EngineDLL = "mysql5engibdd";

		private const CallingConvention EngineCall = CallingConvention.Cdecl;

		public const int H_MSG_OK = 2;

		public const int H_MSG_TRUE = 2;

		public const int H_MSG_FALSE = 3;

		public const int H_MSG_VOID = 4;

		public const int H_MSG_FAIL = 5;

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateEngine")]
		public static extern int CreateEngine(out IntPtr engine);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyEngine")]
		public static extern int DestroyEngine(IntPtr engine);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetEngineAttribute")]
		public static extern int SetEngineAttribute(IntPtr engine, string name, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetEngineAttribute")]
		public static extern int GetEngineAttribute(IntPtr engine, string name, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenStartDebugServer")]
		public static extern int StartDebugServer(IntPtr engine);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenStopDebugServer")]
		public static extern int StopDebugServer(IntPtr engine);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int HCenSetProcedurePath(IntPtr engine, IntPtr path_utf8);

		public static int SetProcedurePath(IntPtr engine, string path)
		{
			IntPtr intPtr = SZXCArimAPI.ToHGlobalUtf8Encoding(path);
			int result = EngineAPI.HCenSetProcedurePath(engine, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int HCenAddProcedurePath(IntPtr engine, IntPtr path_utf8);

		public static int AddProcedurePath(IntPtr engine, string path)
		{
			IntPtr intPtr = SZXCArimAPI.ToHGlobalUtf8Encoding(path);
			int result = EngineAPI.HCenAddProcedurePath(engine, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetHDevOperatorImpl")]
		public static extern int SetHDevOperatorImpl(IntPtr engine, IntPtr implementation);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetProcedureNames")]
		public static extern int GetProcedureNames(IntPtr engine, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetLoadedProcedureNames")]
		public static extern int GetLoadedProcedureNames(IntPtr engine, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenUnloadProcedure")]
		public static extern int UnloadProcedure(IntPtr engine, string name);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenUnloadAllProcedures")]
		public static extern int UnloadAllProcedures(IntPtr engine);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalIconicVarNames")]
		public static extern int GetGlobalIconicVarNames(IntPtr engine, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalCtrlVarNames")]
		public static extern int GetGlobalCtrlVarNames(IntPtr engine, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalCtrlVarDimension")]
		public static extern int GetGlobalCtrlVarDimension(IntPtr engine, string name, out int dimension);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalIconicVarDimension")]
		public static extern int GetGlobalIconicVarDimension(IntPtr engine, string name, out int dimension);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalCtrlVarTuple")]
		public static extern int GetGlobalCtrlVarTuple(IntPtr engine, string name, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalCtrlVarVector")]
		public static extern int GetGlobalCtrlVarVector(IntPtr engine, string name, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalIconicVarObject")]
		public static extern int GetGlobalIconicVarObject(IntPtr engine, string name, out IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetGlobalIconicVarVector")]
		public static extern int GetGlobalIconicVarVector(IntPtr engine, string name, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetGlobalCtrlVarTuple")]
		public static extern int SetGlobalCtrlVarTuple(IntPtr engine, string name, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetGlobalCtrlVarVector")]
		public static extern int SetGlobalCtrlVarVector(IntPtr engine, string name, IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetGlobalIconicVarObject")]
		public static extern int SetGlobalIconicVarObject(IntPtr engine, string name, IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetGlobalIconicVarVector")]
		public static extern int SetGlobalIconicVarVector(IntPtr engine, string name, IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateProgram")]
		public static extern int CreateProgram(out IntPtr program);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyProgram")]
		public static extern int DestroyProgram(IntPtr program);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int HCenLoadProgram(IntPtr program, IntPtr fileName);

		public static int LoadProgram(IntPtr program, string fileName)
		{
			IntPtr intPtr = SZXCArimAPI.ToHGlobalUtf8Encoding(fileName);
			int result = EngineAPI.HCenLoadProgram(program, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern int HCenGetProgramInfo(IntPtr program, out IntPtr name, out bool loaded, IntPtr varNamesIconic, IntPtr varNamesCtrl, IntPtr varDimsIconic, IntPtr varDimsCtrl);

		public static void GetProgramInfo(IntPtr program, out string name, out bool loaded, out HTuple varNamesIconic, out HTuple varNamesCtrl, out HTuple varDimsIconic, out HTuple varDimsCtrl)
		{
			IntPtr intPtr;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			IntPtr intPtr2;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr2));
			IntPtr intPtr3;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr3));
			IntPtr intPtr4;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr4));
			IntPtr ptr;
			EngineAPI.HCkE(EngineAPI.HCenGetProgramInfo(program, out ptr, out loaded, intPtr, intPtr2, intPtr3, intPtr4));
			name = Marshal.PtrToStringAnsi(ptr);
			varNamesIconic = SZXCArimAPI.LoadTuple(intPtr);
			varNamesCtrl = SZXCArimAPI.LoadTuple(intPtr2);
			varDimsIconic = SZXCArimAPI.LoadTuple(intPtr3);
			varDimsCtrl = SZXCArimAPI.LoadTuple(intPtr4);
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr2));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr3));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr4));
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProgGetUsedProcedureNames")]
		public static extern int GetUsedProcedureNamesForProgram(IntPtr program, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProgGetLocalProcedureNames")]
		public static extern int GetLocalProcedureNames(IntPtr program, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProgCompileUsedProcedures")]
		public static extern int CompileUsedProceduresForProgram(IntPtr program, out bool ret);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateProgramCall")]
		public static extern int CreateProgramCall(IntPtr program, out IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyProgramCall")]
		public static extern int DestroyProgramCall(IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenExecuteProgramCall")]
		public static extern int ExecuteProgramCall(IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetWaitForDebugConnectionProgramCall")]
		public static extern int SetWaitForDebugConnectionProgramCall(IntPtr call, bool wait_once);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenResetProgramCall")]
		public static extern int ResetProgramCall(IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetCtrlVarTupleIndex")]
		public static extern int GetCtrlVarTuple(IntPtr call, int index, out IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetCtrlVarVectorIndex")]
		public static extern int GetCtrlVarVector(IntPtr call, int index, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetCtrlVarTupleName")]
		public static extern int GetCtrlVarTuple(IntPtr call, string name, out IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetCtrlVarVectorName")]
		public static extern int GetCtrlVarVector(IntPtr call, string name, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetIconicVarObjectIndex")]
		public static extern int GetIconicVarObject(IntPtr call, int index, out IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetIconicVarVectorIndex")]
		public static extern int GetIconicVarVector(IntPtr call, int index, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetIconicVarObjectName")]
		public static extern int GetIconicVarObject(IntPtr call, string name, out IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetIconicVarVectorName")]
		public static extern int GetIconicVarVector(IntPtr call, string name, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateProcedure")]
		public static extern int CreateProcedure(out IntPtr procedure);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyProcedure")]
		public static extern int DestroyProcedure(IntPtr procedure);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenLoadProcedure")]
		public static extern int LoadProcedure(IntPtr procedure, string procedureName);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int HCenLoadProcedureProgramName(IntPtr procedure, IntPtr programName, string procedureName);

		public static int LoadProcedure(IntPtr procedure, string programName, string procedureName)
		{
			IntPtr intPtr = SZXCArimAPI.ToHGlobalUtf8Encoding(programName);
			int result = EngineAPI.HCenLoadProcedureProgramName(procedure, intPtr, procedureName);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenLoadProcedureProgram")]
		public static extern int LoadProcedure(IntPtr procedure, IntPtr program, string procedureName);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern int HCenGetProcedureInfo(IntPtr procedure, out IntPtr name, out IntPtr shortDescription, out bool loaded, IntPtr parNamesIconicInput, IntPtr parNamesIconicOutput, IntPtr parNamesCtrlInput, IntPtr parNamesCtrlOutput, IntPtr parDimsIconicInput, IntPtr parDimsIconicOutput, IntPtr parDimsCtrlInput, IntPtr parDimsCtrlOutput);

		public static void GetProcedureInfo(IntPtr procedure, out string name, out string shortDescription, out bool loaded, out HTuple parNamesIconicInput, out HTuple parNamesIconicOutput, out HTuple parNamesCtrlInput, out HTuple parNamesCtrlOutput, out HTuple parDimsIconicInput, out HTuple parDimsIconicOutput, out HTuple parDimsCtrlInput, out HTuple parDimsCtrlOutput)
		{
			IntPtr intPtr;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
			IntPtr intPtr2;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr2));
			IntPtr intPtr3;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr3));
			IntPtr intPtr4;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr4));
			IntPtr intPtr5;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr5));
			IntPtr intPtr6;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr6));
			IntPtr intPtr7;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr7));
			IntPtr intPtr8;
			EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr8));
			IntPtr halcon;
			IntPtr halcon2;
			EngineAPI.HCkE(EngineAPI.HCenGetProcedureInfo(procedure, out halcon, out halcon2, out loaded, intPtr, intPtr2, intPtr3, intPtr4, intPtr5, intPtr6, intPtr7, intPtr8));
			name = SZXCArimAPI.FromSZXCArimEncoding(halcon, true);
			shortDescription = SZXCArimAPI.FromSZXCArimEncoding(halcon2, true);
			parNamesIconicInput = SZXCArimAPI.LoadTuple(intPtr);
			parNamesIconicOutput = SZXCArimAPI.LoadTuple(intPtr2);
			parNamesCtrlInput = SZXCArimAPI.LoadTuple(intPtr3);
			parNamesCtrlOutput = SZXCArimAPI.LoadTuple(intPtr4);
			parDimsIconicInput = SZXCArimAPI.LoadTuple(intPtr5);
			parDimsIconicOutput = SZXCArimAPI.LoadTuple(intPtr6);
			parDimsCtrlInput = SZXCArimAPI.LoadTuple(intPtr7);
			parDimsCtrlOutput = SZXCArimAPI.LoadTuple(intPtr8);
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr2));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr3));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr4));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr5));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr6));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr7));
			EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr8));
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcGetUsedProcedureNames")]
		public static extern int GetUsedProcedureNamesForProcedure(IntPtr procedure, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcCompileUsedProcedures")]
		public static extern int CompileUsedProceduresForProcedure(IntPtr procedure, out bool ret);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcGetInfo")]
		public static extern int GetProcInfo(IntPtr procedure, string slot, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcGetParamInfo")]
		public static extern int GetParamInfo(IntPtr procedure, string parName, string slot, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcGetInputIconicParamInfo")]
		public static extern int GetInputIconicParamInfo(IntPtr procedure, int parIdx, string slot, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcGetOutputIconicParamInfo")]
		public static extern int GetOutputIconicParamInfo(IntPtr procedure, int parIdx, string slot, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcGetInputCtrlParamInfo")]
		public static extern int GetInputCtrlParamInfo(IntPtr procedure, int parIdx, string slot, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcGetOutputCtrlParamInfo")]
		public static extern int GetOutputCtrlParamInfo(IntPtr procedure, int parIdx, string slot, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcQueryInfo")]
		public static extern int QueryInfo(IntPtr procedure, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenProcQueryParamInfo")]
		public static extern int QueryParamInfo(IntPtr procedure, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateProcedureCall")]
		public static extern int CreateProcedureCall(IntPtr program, out IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyProcedureCall")]
		public static extern int DestroyProcedureCall(IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenExecuteProcedureCall")]
		public static extern int ExecuteProcedureCall(IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetWaitForDebugConnectionProcedureCall")]
		public static extern int SetWaitForDebugConnectionProcedureCall(IntPtr call, bool wait_once);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenResetProcedureCall")]
		public static extern int ResetProcedureCall(IntPtr call);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputCtrlParamTupleIndex")]
		public static extern int SetInputCtrlParamTuple(IntPtr call, int index, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputCtrlParamTupleName")]
		public static extern int SetInputCtrlParamTuple(IntPtr call, string name, IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputCtrlParamVectorIndex")]
		public static extern int SetInputCtrlParamVector(IntPtr call, int index, IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputCtrlParamVectorName")]
		public static extern int SetInputCtrlParamVector(IntPtr call, string name, IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputIconicParamObjectIndex")]
		public static extern int SetInputIconicParamObject(IntPtr call, int index, IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputIconicParamObjectName")]
		public static extern int SetInputIconicParamObject(IntPtr call, string name, IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputIconicParamVectorIndex")]
		public static extern int SetInputIconicParamVector(IntPtr call, int index, IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetInputIconicParamVectorName")]
		public static extern int SetInputIconicParamVector(IntPtr call, string name, IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputCtrlParamTupleIndex")]
		public static extern int GetOutputCtrlParamTuple(IntPtr call, int index, out IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputCtrlParamTupleName")]
		public static extern int GetOutputCtrlParamTuple(IntPtr call, string name, out IntPtr tuple);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputCtrlParamVectorIndex")]
		public static extern int GetOutputCtrlParamVector(IntPtr call, int index, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputCtrlParamVectorName")]
		public static extern int GetOutputCtrlParamVector(IntPtr call, string name, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputIconicParamObjectIndex")]
		public static extern int GetOutputIconicParamObject(IntPtr call, int index, out IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputIconicParamObjectName")]
		public static extern int GetOutputIconicParamObject(IntPtr call, string name, out IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputIconicParamVectorIndex")]
		public static extern int GetOutputIconicParamVector(IntPtr call, int index, out IntPtr vector);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetOutputIconicParamVectorName")]
		public static extern int GetOutputIconicParamVector(IntPtr call, string name, out IntPtr vector);

		public static int CreateObjectVector(HObjectVector inVector, out IntPtr vectorHandle)
		{
			int dimension = inVector.Dimension;
			IntPtr intPtr;
			EngineAPI.HCkE(EngineAPI.CreateObjectVector(dimension, out intPtr));
			EngineAPI.HCkE(EngineAPI.StoreObjectVector(inVector, intPtr));
			GC.KeepAlive(inVector);
			vectorHandle = intPtr;
			return 2;
		}

		public static int StoreObjectVector(HObjectVector inVector, IntPtr vectorHandle)
		{
			int dimension = inVector.Dimension;
			int length = inVector.Length;
			if (dimension == 1)
			{
				for (int i = length - 1; i >= 0; i--)
				{
					EngineAPI.HCkE(EngineAPI.SetObjectVectorObject(vectorHandle, i, inVector[i].O.Key));
				}
			}
			else
			{
				for (int j = length - 1; j >= 0; j--)
				{
					IntPtr intPtr;
					EngineAPI.HCkE(EngineAPI.CreateObjectVector(inVector[j], out intPtr));
					EngineAPI.HCkE(EngineAPI.SetObjectVectorVector(vectorHandle, j, intPtr));
					EngineAPI.HCkE(EngineAPI.DestroyObjectVector(intPtr));
				}
			}
			GC.KeepAlive(inVector);
			return 2;
		}

		public static HObjectVector GetAndDestroyObjectVector(IntPtr vectorHandle)
		{
			int dimension;
			EngineAPI.HCkE(EngineAPI.GetObjectVectorDimension(vectorHandle, out dimension));
			HObjectVector hObjectVector = new HObjectVector(dimension);
			EngineAPI.HCkE(EngineAPI.LoadObjectVector(hObjectVector, vectorHandle));
			EngineAPI.HCkE(EngineAPI.DestroyObjectVector(vectorHandle));
			return hObjectVector;
		}

		public static int LoadObjectVector(HObjectVector outVector, IntPtr vectorHandle)
		{
			int num;
			EngineAPI.HCkE(EngineAPI.GetObjectVectorDimension(vectorHandle, out num));
			int num2;
			EngineAPI.HCkE(EngineAPI.GetObjectVectorLength(vectorHandle, out num2));
			if (num == 1)
			{
				for (int i = num2 - 1; i >= 0; i--)
				{
					IntPtr key;
					EngineAPI.HCkE(EngineAPI.GetObjectVectorObject(vectorHandle, i, out key));
					outVector[i].O = new HObject(key, false);
				}
			}
			else
			{
				for (int j = num2 - 1; j >= 0; j--)
				{
					IntPtr intPtr;
					EngineAPI.HCkE(EngineAPI.GetObjectVectorVector(vectorHandle, j, out intPtr));
					EngineAPI.HCkE(EngineAPI.LoadObjectVector(outVector[j], intPtr));
					EngineAPI.HCkE(EngineAPI.DestroyObjectVector(intPtr));
				}
			}
			return 2;
		}

		public static int CreateTupleVector(HTupleVector inVector, out IntPtr vectorHandle)
		{
			int dimension = inVector.Dimension;
			IntPtr intPtr;
			EngineAPI.HCkE(EngineAPI.CreateTupleVector(dimension, out intPtr));
			EngineAPI.HCkE(EngineAPI.StoreTupleVector(inVector, intPtr));
			GC.KeepAlive(inVector);
			vectorHandle = intPtr;
			return 2;
		}

		public static int StoreTupleVector(HTupleVector inVector, IntPtr vectorHandle)
		{
			int dimension = inVector.Dimension;
			int length = inVector.Length;
			if (dimension == 1)
			{
				for (int i = length - 1; i >= 0; i--)
				{
					IntPtr intPtr;
					EngineAPI.HCkE(SZXCArimAPI.CreateTuple(out intPtr));
					SZXCArimAPI.StoreTuple(intPtr, inVector[i].T);
					EngineAPI.HCkE(EngineAPI.SetTupleVectorTuple(vectorHandle, i, intPtr));
					EngineAPI.HCkE(SZXCArimAPI.DestroyTuple(intPtr));
				}
			}
			else
			{
				for (int j = length - 1; j >= 0; j--)
				{
					IntPtr intPtr2;
					EngineAPI.HCkE(EngineAPI.CreateTupleVector(inVector[j], out intPtr2));
					EngineAPI.HCkE(EngineAPI.SetTupleVectorVector(vectorHandle, j, intPtr2));
					EngineAPI.HCkE(EngineAPI.DestroyTupleVector(intPtr2));
				}
			}
			GC.KeepAlive(inVector);
			return 2;
		}

		public static HTupleVector GetAndDestroyTupleVector(IntPtr vectorHandle)
		{
			int dimension;
			EngineAPI.HCkE(EngineAPI.GetTupleVectorDimension(vectorHandle, out dimension));
			HTupleVector hTupleVector = new HTupleVector(dimension);
			EngineAPI.HCkE(EngineAPI.LoadTupleVector(hTupleVector, vectorHandle));
			EngineAPI.HCkE(EngineAPI.DestroyTupleVector(vectorHandle));
			return hTupleVector;
		}

		public static int LoadTupleVector(HTupleVector outVector, IntPtr vectorHandle)
		{
			int num;
			EngineAPI.HCkE(EngineAPI.GetTupleVectorDimension(vectorHandle, out num));
			int num2;
			EngineAPI.HCkE(EngineAPI.GetTupleVectorLength(vectorHandle, out num2));
			if (num == 1)
			{
				for (int i = num2 - 1; i >= 0; i--)
				{
					IntPtr tupleHandle;
					EngineAPI.HCkE(EngineAPI.GetTupleVectorTuple(vectorHandle, i, out tupleHandle));
					outVector[i].T = SZXCArimAPI.LoadTuple(tupleHandle);
				}
			}
			else
			{
				for (int j = num2 - 1; j >= 0; j--)
				{
					IntPtr intPtr;
					EngineAPI.HCkE(EngineAPI.GetTupleVectorVector(vectorHandle, j, out intPtr));
					EngineAPI.HCkE(EngineAPI.LoadTupleVector(outVector[j], intPtr));
					EngineAPI.HCkE(EngineAPI.DestroyTupleVector(intPtr));
				}
			}
			return 2;
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateTupleVector")]
		public static extern int CreateTupleVector(int dimension, out IntPtr vector_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyTupleVector")]
		public static extern int DestroyTupleVector(IntPtr vector_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetTupleVectorDimension")]
		public static extern int GetTupleVectorDimension(IntPtr vector_handle, out int dimension);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetTupleVectorLength")]
		public static extern int GetTupleVectorLength(IntPtr vector_handle, out int length);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetTupleVectorElementVector")]
		public static extern int SetTupleVectorVector(IntPtr vector_handle, int index, IntPtr element_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetTupleVectorElementTuple")]
		public static extern int SetTupleVectorTuple(IntPtr vector_handle, int index, IntPtr element_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetTupleVectorElementVector")]
		public static extern int GetTupleVectorVector(IntPtr vector_handle, int index, out IntPtr element_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetTupleVectorElementTuple")]
		public static extern int GetTupleVectorTuple(IntPtr vector_handle, int index, out IntPtr element_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateObjectVector")]
		public static extern int CreateObjectVector(int dimension, out IntPtr vector_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyObjectVector")]
		public static extern int DestroyObjectVector(IntPtr vector_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetObjectVectorDimension")]
		public static extern int GetObjectVectorDimension(IntPtr vector_handle, out int dimension);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetObjectVectorLength")]
		public static extern int GetObjectVectorLength(IntPtr vector_handle, out int length);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetObjectVectorElementVector")]
		public static extern int SetObjectVectorVector(IntPtr vector_handle, int index, IntPtr sub_vector_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenSetObjectVectorElementObject")]
		public static extern int SetObjectVectorObject(IntPtr vector_handle, int index, IntPtr key);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetObjectVectorElementVector")]
		public static extern int GetObjectVectorVector(IntPtr vector_handle, int index, out IntPtr sub_vector_handle);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenGetObjectVectorElementObject")]
		public static extern int GetObjectVectorObject(IntPtr vector_handle, int index, out IntPtr key);

		public static void AssertObjectClass(IntPtr key, string assertClass, string procedureName)
		{
			if (key != HObjectBase.UNDEF)
			{
				HObject hObject = new HObject(key);
				HTuple objClass = hObject.GetObjClass();
				hObject.Dispose();
				if (objClass.Length > 0)
				{
					string s = objClass.S;
					if (!s.StartsWith(assertClass))
					{
						HDevEngineException.ThrowGeneric(string.Concat(new string[]
						{
							"Output object type mismatch (excepted ",
							assertClass,
							", got ",
							s,
							")"
						}), procedureName);
					}
				}
			}
		}

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenCreateImplementation")]
		internal static extern int CreateImplementation(out IntPtr implementation, DevOpenWindowDelegate delegateDevOpenWindow, DevCloseWindowDelegate delegateDevCloseWindow, DevSetWindowDelegate delegateDevSetWindow, DevGetWindowDelegate delegateDevGetWindow, DevSetWindowExtentsDelegate delegateDevSetWindowExtents, DevSetPartDelegate delegateDevSetPart, DevClearWindowDelegate delegateDevClearWindow, DevDisplayDelegate delegateDevDisplay, DevDispTextDelegate delegateDevDispText, DevSetDrawDelegate delegateDevSetDraw, DevSetContourStyleDelegate delegateDevSetContourStyle, DevSetShapeDelegate delegateDevSetShape, DevSetColoredDelegate delegateDevSetColored, DevSetColorDelegate delegateDevSetColor, DevSetLutDelegate delegateDevSetLut, DevSetPaintDelegate delegateDevSetPaint, DevSetLineWidthDelegate delegateDevSetLineWidth);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "HCenDestroyImplementation")]
		public static extern int DestroyImplementation(IntPtr implementation);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern int HCenGetLastException(out int category, out IntPtr message, out IntPtr procedureName, out IntPtr lineText, out int lineNumber, out IntPtr userData);

		[DllImport(EngineDLL, CallingConvention = CallingConvention.Cdecl)]
		public static extern void HCenReleaseLastException();

		public static int GetLastException(out int category, out string message, out string procedureName, out string lineText, out int lineNumber, out HTuple userData)
		{
			IntPtr ptr;
			IntPtr ptr2;
			IntPtr ptr3;
			IntPtr tupleHandle;
			int result = EngineAPI.HCenGetLastException(out category, out ptr, out ptr2, out ptr3, out lineNumber, out tupleHandle);
			try
			{
				message = Marshal.PtrToStringAnsi(ptr);
				procedureName = Marshal.PtrToStringAnsi(ptr2);
				lineText = Marshal.PtrToStringAnsi(ptr3);
				userData = SZXCArimAPI.LoadTuple(tupleHandle);
			}
			catch
			{
				message = "Error handling exception";
				procedureName = "";
				lineText = "";
				userData = new HTuple();
			}
			EngineAPI.HCenReleaseLastException();
			return result;
		}

		public static void HCkE(int err)
		{
			if (err == -1 || (err != 2 && err != 2))
			{
				HDevEngineException.ThrowLastException(err);
			}
		}
	}
}
