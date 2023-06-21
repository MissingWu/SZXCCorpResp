using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace SZXCArimEngine
{
	[SuppressUnmanagedCodeSecurity]
	public class SZXCArimAPI
	{
		public delegate int HFramegrabberCallback(IntPtr handle, IntPtr userContext, IntPtr context);

		public delegate void HProgressBarCallback(IntPtr id, string operatorName, double progress, string message);

		public delegate void HLowLevelErrorCallback(string err);

		public delegate void HClearProcCallBack(IntPtr ptr);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public delegate IntPtr HDevThreadInternalCallback(IntPtr devThread);

		private const string SZXCArimDLL = "SZXCArim";

		private const CallingConvention SZXCArimCall = CallingConvention.Cdecl;

		public static readonly bool isPlatform64 = IntPtr.Size > 4;

		public static readonly bool isWindows = SZXCArimAPI.testWindows();

		internal const int H_MSG_OK = 2;

		internal const int H_MSG_TRUE = 2;

		internal const int H_MSG_FALSE = 3;

		internal const int H_MSG_VOID = 4;

		internal const int H_MSG_FAIL = 5;

		private SZXCArimAPI()
		{
		}

		private static bool testWindows()
		{
			int platform = (int)Environment.OSVersion.Platform;
			return platform != 4 && platform != 128;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIDoLicenseError")]
		public static extern void DoLicenseError(bool state);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIUseSpinLock")]
		public static extern void UseSpinLock(bool state);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIStartUpThreadPool")]
		public static extern void StartUpThreadPool(bool state);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLICancelDraw")]
		public static extern void CancelDraw();

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIIsUTF8Encoding")]
		private static extern bool IsUTF8Encoding();

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIGetSerializedSize(IntPtr ptr, out ulong size);

		internal static int GetSerializedSize(byte[] header, out ulong size)
		{
			GCHandle gCHandle = GCHandle.Alloc(header, GCHandleType.Pinned);
			int arg_1C_0 = SZXCArimAPI.HLIGetSerializedSize(gCHandle.AddrOfPinnedObject(), out size);
			gCHandle.Free();
			return arg_1C_0;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLILock")]
		internal static extern void Lock();

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIUnlock")]
		internal static extern void Unlock();

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXCreateHThreadContext(out IntPtr context);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXClearHThreadContext(IntPtr context);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXCreateHThread(IntPtr contextHandle, out IntPtr threadHandle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXClearHThread(IntPtr threadHandle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXExitHThread(IntPtr threadHandle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXStartHThreadDotNet(IntPtr threadHandle, SZXCArimAPI.HDevThreadInternalCallback proc, IntPtr data, out IntPtr threadId);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXPrepareDirectCall(IntPtr threadHandle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXJoinHThread(IntPtr threadId);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXThreadLockLocalVar(IntPtr threadHandle, out IntPtr referenceCount);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXThreadUnlockLocalVar(IntPtr threadHandle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXThreadLockGlobalVar(IntPtr threadHandle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HXThreadUnlockGlobalVar(IntPtr threadHandle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLICreateProcedure")]
		private static extern int CreateProcedure(int procIndex, out IntPtr proc);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLICallProcedure")]
		public static extern int CallProcedure(IntPtr proc);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIDestroyProcedure")]
		public static extern int DestroyProcedure(IntPtr proc, int procResult);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr HLIGetLogicalName(IntPtr proc);

		internal static string GetLogicalName(IntPtr proc)
		{
			return Marshal.PtrToStringAnsi(SZXCArimAPI.HLIGetLogicalName(proc));
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLILogicalName")]
		private static extern IntPtr HLIGetLogicalName(int procIndex);

		internal static string GetLogicalName(int procIndex)
		{
			return Marshal.PtrToStringAnsi(SZXCArimAPI.HLIGetLogicalName(procIndex));
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetProcIndex")]
		private static extern int GetProcIndex(IntPtr proc);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIGetErrorMessage(int err, IntPtr buffer);

		internal static string GetErrorMessage(int err)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(1024);
			SZXCArimAPI.HLIGetErrorMessage(err, intPtr);
			string arg_20_0 = SZXCArimAPI.FromSZXCArimEncoding(intPtr, false);
			Marshal.FreeHGlobal(intPtr);
			return arg_20_0;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IntPtr PreCall(int procIndex)
		{
			IntPtr result;
			int num = SZXCArimAPI.CreateProcedure(procIndex, out result);
			if (num != 2)
			{
				HOperatorException.throwInfo(num, "Could not create a new operator instance for id " + procIndex);
			}
			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void PostCall(IntPtr proc, int procResult)
		{
			try
			{
				int procIndex = SZXCArimAPI.GetProcIndex(proc);
			    SZXCArimAPI.HLIClearAllIOCT(proc); int err = 0;
			
				 err = SZXCArimAPI.DestroyProcedure(proc, procResult);
		
			if (procIndex >= 0)
			{
				HOperatorException.throwOperator(err, procIndex);
				HOperatorException.throwOperator(procResult, procIndex);
				return;
			}
			HOperatorException.throwOperator(err, "Unknown");
			HOperatorException.throwOperator(procResult, "Unknown");

			}
			catch { }
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetInputObject")]
		internal static extern int SetInputObject(IntPtr proc, int parIndex, IntPtr key);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetOutputObject")]
		internal static extern int GetOutputObject(IntPtr proc, int parIndex, out IntPtr key);

		internal static void ClearObject(IntPtr key)
		{
			IntPtr expr_0A = SZXCArimAPI.PreCall(585);
			SZXCArimAPI.HCkP(expr_0A, SZXCArimAPI.SetInputObject(expr_0A, 1, key));
			int procResult = SZXCArimAPI.CallProcedure(expr_0A);
			SZXCArimAPI.PostCall(expr_0A, procResult);
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLICopyObject(IntPtr keyIn, out IntPtr keyOut);

		internal static IntPtr CopyObject(IntPtr key)
		{
			IntPtr proc = SZXCArimAPI.PreCall(583);
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetInputObject(proc, 1, key));
			SZXCArimAPI.StoreI(proc, 0, 1);
			SZXCArimAPI.StoreI(proc, 1, -1);
			int num = SZXCArimAPI.CallProcedure(proc);
			if (!SZXCArimAPI.IsFailure(num))
			{
				num = SZXCArimAPI.GetOutputObject(proc, 1, out key);
			}
			SZXCArimAPI.PostCall(proc, num);
			return key;
		}

		internal static string GetObjClass(IntPtr key)
		{
			HTuple hTuple = "object";
			IntPtr proc = SZXCArimAPI.PreCall(594);
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetInputObject(proc, 1, key));
			SZXCArimAPI.InitOCT(proc, 0);
			int num = SZXCArimAPI.CallProcedure(proc);
			if (!SZXCArimAPI.IsFailure(num))
			{
				num = HTuple.LoadNew(proc, 0, num, out hTuple);
			}
			SZXCArimAPI.PostCall(proc, num);
			if (hTuple.Length <= 0)
			{
				return "any";
			}
			return hTuple.S;
		}

		internal static void AssertObjectClass(IntPtr key, string assertClass)
		{
			if (key != HObjectBase.UNDEF)
			{
				string objClass = SZXCArimAPI.GetObjClass(key);
				if (!objClass.StartsWith(assertClass) && objClass != "any")
				{
					throw new SZXCArimException(string.Concat(new string[]
					{
						"Iconic object type mismatch (expected ",
						assertClass,
						", got ",
						objClass,
						")"
					}));
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLICreateTuple")]
		public static extern int CreateTuple(out IntPtr tuple);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIInitOCT")]
		public static extern int InitOCT(IntPtr proc, int parIndex);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		public static extern int HLIClearAllIOCT(IntPtr proc);

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIDestroyTuple")]
		public static extern int DestroyTuple(IntPtr tuple);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StoreTuple(IntPtr tupleHandle, HTuple tuple)
		{
			HTupleType type = (tuple.Type == HTupleType.LONG) ? HTupleType.INTEGER : tuple.Type;
			SZXCArimAPI.HCkH(SZXCArimAPI.CreateElementsOfType(tupleHandle, tuple.Length, type));
			HTupleType type2 = tuple.Type;
			if (type2 <= HTupleType.MIXED)
			{
				switch (type2)
				{
				case HTupleType.INTEGER:
					SZXCArimAPI.HCkH(SZXCArimAPI.SetIArr(tupleHandle, tuple.IArr));
					return;
				case HTupleType.DOUBLE:
					SZXCArimAPI.HCkH(SZXCArimAPI.SetDArr(tupleHandle, tuple.DArr));
					return;
				case (HTupleType)3:
					break;
				case HTupleType.STRING:
				{
					string[] sArr = tuple.SArr;
					for (int i = 0; i < tuple.Length; i++)
					{
						SZXCArimAPI.HCkH(SZXCArimAPI.SetS(tupleHandle, i, sArr[i], true));
					}
					return;
				}
				default:
				{
					if (type2 != HTupleType.MIXED)
					{
						return;
					}
					object[] oArr = tuple.data.OArr;
					for (int j = 0; j < tuple.Length; j++)
					{
						int objectType = HTupleImplementation.GetObjectType(oArr[j]);
						switch (objectType)
						{
						case 1:
							SZXCArimAPI.HCkH(SZXCArimAPI.SetI(tupleHandle, j, (int)oArr[j]));
							break;
						case 2:
							SZXCArimAPI.HCkH(SZXCArimAPI.SetD(tupleHandle, j, (double)oArr[j]));
							break;
						case 3:
							break;
						case 4:
							SZXCArimAPI.HCkH(SZXCArimAPI.SetS(tupleHandle, j, (string)oArr[j], true));
							break;
						default:
							if (objectType != 16)
							{
								if (objectType == 129)
								{
									SZXCArimAPI.HCkH(SZXCArimAPI.SetL(tupleHandle, j, (long)oArr[j]));
								}
							}
							else
							{
								SZXCArimAPI.HCkH(SZXCArimAPI.SetH(tupleHandle, j, (HHandle)oArr[j]));
							}
							break;
						}
					}
					break;
				}
				}
				return;
			}
			if (type2 == HTupleType.HANDLE)
			{
				HHandle[] hArr = tuple.HArr;
				for (int k = 0; k < tuple.Length; k++)
				{
					SZXCArimAPI.HCkH(SZXCArimAPI.SetH(tupleHandle, k, hArr[k]));
				}
				return;
			}
			if (type2 != HTupleType.LONG)
			{
				return;
			}
			SZXCArimAPI.HCkH(SZXCArimAPI.SetLArr(tupleHandle, tuple.LArr));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HTuple LoadTuple(IntPtr tupleHandle)
		{
			HTupleImplementation data;
			HTupleImplementation.LoadData(tupleHandle, HTupleType.MIXED, out data, true);
			return new HTuple(data);
		}

		private static void HCkH(int err)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				throw new HOperatorException(err);
			}
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetInputTuple")]
		internal static extern int GetInputTuple(IntPtr proc, int parIndex, out IntPtr tuple);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLICreateElementsOfType")]
		internal static extern int CreateElementsOfType(IntPtr tuple, int length, HTupleType type);

		internal static int CreateInputTuple(IntPtr proc, int parIndex, int length, HTupleType type, out IntPtr tuple)
		{
			int inputTuple = SZXCArimAPI.GetInputTuple(proc, parIndex, out tuple);
			if (!SZXCArimAPI.IsFailure(inputTuple))
			{
				return SZXCArimAPI.CreateElementsOfType(tuple, length, type);
			}
			return inputTuple;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetOutputTuple")]
		internal static extern int GetOutputTuple(IntPtr proc, int parIndex, bool handleType, out IntPtr tuple);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetTupleLength")]
		internal static extern int GetTupleLength(IntPtr tuple, out int length);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetTupleTypeScanElem")]
		internal static extern int GetTupleTypeScanElem(IntPtr tuple, out int type);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetElementType")]
		internal static extern int GetElementType(IntPtr tuple, int index, out HTupleType type);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetI")]
		internal static extern int SetI(IntPtr tuple, int index, int intValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetL")]
		internal static extern int SetL(IntPtr tuple, int index, long longValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetD")]
		internal static extern int SetD(IntPtr tuple, int index, double doubleValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HLISetS(IntPtr tuple, int index, IntPtr stringValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetH")]
		internal static extern int SetH(IntPtr tuple, int index, IntPtr handleValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLICopyHandle(IntPtr handle, out IntPtr handleCopy);

		internal static IntPtr CopyHandle(IntPtr handle)
		{
			IntPtr result;
			SZXCArimAPI.HCkH(SZXCArimAPI.HLICopyHandle(handle, out result));
			return result;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIClearHandle")]
		internal static extern int ClearHandle(IntPtr handle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIAcquireExternalOwnership(IntPtr handle, out IntPtr handleLong);

		internal static IntPtr AcquireExternalOwnership(IntPtr handle)
		{
			IntPtr result;
			SZXCArimAPI.HCkH(SZXCArimAPI.HLIAcquireExternalOwnership(handle, out result));
			return result;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIReleaseExternalOwnership")]
		internal static extern int ReleaseExternalOwnership(IntPtr handle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIHandleToHlong(IntPtr handle, out IntPtr handleLong);

		internal static IntPtr HandleToHlong(IntPtr handle)
		{
			IntPtr result;
			SZXCArimAPI.HCkH(SZXCArimAPI.HLIHandleToHlong(handle, out result));
			return result;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIHandleIsValid(IntPtr handle, out bool is_valid);

		internal static bool HandleIsValid(IntPtr handle)
		{
			bool result;
			SZXCArimAPI.HCkH(SZXCArimAPI.HLIHandleIsValid(handle, out result));
			return result;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIHGetGV_LegacyHandleMode(out bool is_valid);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool IsLegacyHandleMode()
		{
			bool result;
			SZXCArimAPI.HCkH(SZXCArimAPI.HLIHGetGV_LegacyHandleMode(out result));
			return result;
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIGetHandleSemType(IntPtr handle, out IntPtr sem_type);

		internal static string GetHandleSemType(IntPtr handle)
		{
			IntPtr SZXCArim;
			SZXCArimAPI.HCkH(SZXCArimAPI.HLIGetHandleSemType(handle, out SZXCArim));
			return SZXCArimAPI.FromSZXCArimEncoding(SZXCArim, false);
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLITestEqualHandle")]
		internal static extern bool TestEqualHandle(IntPtr handle1, IntPtr handle);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IntPtr ToSZXCArimHGlobalEncoding(string dotnet, bool force_utf8)
		{
			if (!force_utf8 && !SZXCArimAPI.IsUTF8Encoding())
			{
				return Marshal.StringToHGlobalAnsi(dotnet);
			}
			return SZXCArimAPI.ToHGlobalUtf8Encoding(dotnet);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static IntPtr ToHGlobalUtf8Encoding(string dotnet)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(dotnet);
			int num = Marshal.SizeOf(bytes.GetType().GetElementType()) * bytes.Length;
			IntPtr intPtr = Marshal.AllocHGlobal(num + 1);
			Marshal.Copy(bytes, 0, intPtr, bytes.Length);
			Marshal.WriteByte(intPtr, num, 0);
			return intPtr;
		}

		internal static int SetS(IntPtr tuple, int index, string dotnet_string, bool force_utf8)
		{
			IntPtr intPtr = SZXCArimAPI.ToSZXCArimHGlobalEncoding(dotnet_string, force_utf8);
			int arg_16_0 = SZXCArimAPI.HLISetS(tuple, index, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return arg_16_0;
		}

		internal static int SetIP(IntPtr tuple, int index, IntPtr intPtrValue)
		{
			int result;
			if (SZXCArimAPI.isPlatform64)
			{
				result = SZXCArimAPI.SetL(tuple, index, intPtrValue.ToInt64());
			}
			else
			{
				result = SZXCArimAPI.SetI(tuple, index, intPtrValue.ToInt32());
			}
			return result;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StoreI(IntPtr proc, int parIndex, int intValue)
		{
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateInputTuple(proc, parIndex, 1, HTupleType.INTEGER, out tuple));
			SZXCArimAPI.SetI(tuple, 0, intValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StoreL(IntPtr proc, int parIndex, long longValue)
		{
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateInputTuple(proc, parIndex, 1, HTupleType.INTEGER, out tuple));
			SZXCArimAPI.SetL(tuple, 0, longValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StoreD(IntPtr proc, int parIndex, double doubleValue)
		{
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateInputTuple(proc, parIndex, 1, HTupleType.DOUBLE, out tuple));
			SZXCArimAPI.SetD(tuple, 0, doubleValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StoreS(IntPtr proc, int parIndex, string stringValue)
		{
			if (stringValue == null)
			{
				stringValue = "";
			}
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateInputTuple(proc, parIndex, 1, HTupleType.STRING, out tuple));
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetS(tuple, 0, stringValue, false));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StoreH(IntPtr proc, int parIndex, IntPtr handleValue)
		{
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateInputTuple(proc, parIndex, 1, HTupleType.HANDLE, out tuple));
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetH(tuple, 0, handleValue));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void StoreIP(IntPtr proc, int parIndex, IntPtr intPtrValue)
		{
			IntPtr tuple;
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.CreateInputTuple(proc, parIndex, 1, HTupleType.INTEGER, out tuple));
			SZXCArimAPI.SetIP(tuple, 0, intPtrValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Store(IntPtr proc, int parIndex, HTuple tupleValue)
		{
			if (tupleValue == null)
			{
				tupleValue = new HTuple();
			}
			tupleValue.Store(proc, parIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Store(IntPtr proc, int parIndex, HHandle handleValue)
		{
			if (handleValue == null)
			{
				handleValue = new HHandle();
			}
			handleValue.Store(proc, parIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Store(IntPtr proc, int parIndex, HObjectBase objectValue)
		{
			if (objectValue == null)
			{
				objectValue = new HObjectBase();
			}
			objectValue.Store(proc, parIndex);
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetIArr")]
		internal static extern int SetIArr(IntPtr tuple, int[] intArray);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetIArrPtr")]
		internal static extern int SetIArrPtr(IntPtr tuple, int[] intArray, int length);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetLArr")]
		internal static extern int SetLArr(IntPtr tuple, long[] longArray);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetLArrPtr")]
		internal static extern int SetLArrPtr(IntPtr tuple, long[] longArray, int length);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetDArr")]
		internal static extern int SetDArr(IntPtr tuple, double[] doubleArray);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLISetDArrPtr")]
		internal static extern int SetDArrPtr(IntPtr tuple, double[] doubleArray, int length);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetI")]
		internal static extern int GetI(IntPtr tuple, int index, out int intValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetL")]
		internal static extern int GetL(IntPtr tuple, int index, out long longValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HLIGetH(IntPtr tuple, int index, out IntPtr longValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetD")]
		internal static extern int GetD(IntPtr tuple, int index, out double doubleValue);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		private static extern int HLIGetS(IntPtr tuple, int index, out IntPtr stringPtr);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static string FromSZXCArimEncoding(IntPtr SZXCArim, bool force_utf8)
		{
			if (force_utf8 || SZXCArimAPI.IsUTF8Encoding())
			{
				int num = 0;
				while (Marshal.ReadByte(SZXCArim, num) != 0)
				{
					num++;
				}
				byte[] array = new byte[num];
				Marshal.Copy(SZXCArim, array, 0, array.Length);
				return Encoding.UTF8.GetString(array);
			}
			return Marshal.PtrToStringAnsi(SZXCArim);
		}

		internal static int GetS(IntPtr tuple, int index, out string stringValue, bool force_utf8)
		{
			stringValue = string.Empty;
			IntPtr SZXCArim;
			int num = SZXCArimAPI.HLIGetS(tuple, index, out SZXCArim);
			if (num != 2)
			{
				return num;
			}
			stringValue = SZXCArimAPI.FromSZXCArimEncoding(SZXCArim, force_utf8);
			if (stringValue == null)
			{
				stringValue = "";
				return 5;
			}
			return 2;
		}

		internal static int GetH(IntPtr tuple, int index, out HHandle handle)
		{
			IntPtr handle2;
			int arg_11_0 = SZXCArimAPI.HLIGetH(tuple, index, out handle2);
			handle = new HHandle(handle2);
			return arg_11_0;
		}

		internal static int GetIP(IntPtr tuple, int index, out IntPtr intPtrValue)
		{
			int result;
			if (SZXCArimAPI.isPlatform64)
			{
				long value;
				result = SZXCArimAPI.GetL(tuple, index, out value);
				intPtrValue = new IntPtr(value);
			}
			else
			{
				int value2;
				result = SZXCArimAPI.GetI(tuple, index, out value2);
				intPtrValue = new IntPtr(value2);
			}
			return result;
		}

		private static int HCkSingle(IntPtr tuple, HTupleType expectedType)
		{
			int num = 0;
			if (tuple != IntPtr.Zero)
			{
				SZXCArimAPI.GetTupleLength(tuple, out num);
			}
			if (num <= 0)
			{
				return 7001;
			}
			HTupleType hTupleType;
			SZXCArimAPI.GetElementType(tuple, 0, out hTupleType);
			if (hTupleType != expectedType)
			{
				return 7002;
			}
			return 2;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadI(IntPtr proc, int parIndex, int err, out int intValue)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				intValue = -1;
				return err;
			}
			IntPtr zero = IntPtr.Zero;
			SZXCArimAPI.GetOutputTuple(proc, parIndex, false, out zero);
			err = SZXCArimAPI.HCkSingle(zero, HTupleType.INTEGER);
			if (err == 2)
			{
				return SZXCArimAPI.GetI(zero, 0, out intValue);
			}
			err = SZXCArimAPI.HCkSingle(zero, HTupleType.DOUBLE);
			if (err != 2)
			{
				intValue = -1;
				return err;
			}
			double num = -1.0;
			err = SZXCArimAPI.GetD(zero, 0, out num);
			intValue = (int)num;
			return err;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadL(IntPtr proc, int parIndex, int err, out long longValue)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				longValue = -1L;
				return err;
			}
			IntPtr zero = IntPtr.Zero;
			SZXCArimAPI.GetOutputTuple(proc, parIndex, false, out zero);
			err = SZXCArimAPI.HCkSingle(zero, HTupleType.INTEGER);
			if (err == 2)
			{
				return SZXCArimAPI.GetL(zero, 0, out longValue);
			}
			err = SZXCArimAPI.HCkSingle(zero, HTupleType.DOUBLE);
			if (err != 2)
			{
				longValue = -1L;
				return err;
			}
			double num = -1.0;
			err = SZXCArimAPI.GetD(zero, 0, out num);
			longValue = (long)num;
			return err;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadD(IntPtr proc, int parIndex, int err, out double doubleValue)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				doubleValue = -1.0;
				return err;
			}
			IntPtr zero = IntPtr.Zero;
			SZXCArimAPI.GetOutputTuple(proc, parIndex, false, out zero);
			err = SZXCArimAPI.HCkSingle(zero, HTupleType.DOUBLE);
			if (err == 2)
			{
				return SZXCArimAPI.GetD(zero, 0, out doubleValue);
			}
			err = SZXCArimAPI.HCkSingle(zero, HTupleType.INTEGER);
			if (err != 2)
			{
				doubleValue = -1.0;
				return err;
			}
			int num = -1;
			err = SZXCArimAPI.GetI(zero, 0, out num);
			doubleValue = (double)num;
			return err;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadS(IntPtr proc, int parIndex, int err, out string stringValue)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				stringValue = "";
				return err;
			}
			IntPtr zero = IntPtr.Zero;
			SZXCArimAPI.GetOutputTuple(proc, parIndex, false, out zero);
			err = SZXCArimAPI.HCkSingle(zero, HTupleType.STRING);
			if (err != 2)
			{
				stringValue = "";
				return err;
			}
			return SZXCArimAPI.GetS(zero, 0, out stringValue, false);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadIP(IntPtr proc, int parIndex, int err, out IntPtr intPtrValue)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				intPtrValue = IntPtr.Zero;
				return err;
			}
			IntPtr tuple;
			SZXCArimAPI.GetOutputTuple(proc, parIndex, false, out tuple);
			err = SZXCArimAPI.HCkSingle(tuple, HTupleType.INTEGER);
			if (err != 2)
			{
				intPtrValue = IntPtr.Zero;
				return err;
			}
			return SZXCArimAPI.GetIP(tuple, 0, out intPtrValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int LoadH(IntPtr proc, int parIndex, int err, out HHandle handleValue)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				handleValue = new HHandle();
				return err;
			}
			IntPtr tuple;
			SZXCArimAPI.GetOutputTuple(proc, parIndex, true, out tuple);
			err = SZXCArimAPI.HCkSingle(tuple, HTupleType.HANDLE);
			if (err != 2)
			{
				handleValue = new HHandle();
				return err;
			}
			return SZXCArimAPI.GetH(tuple, 0, out handleValue);
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetIArr")]
		internal static extern int GetIArr(IntPtr tuple, [Out] int[] intArray);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetLArr")]
		internal static extern int GetLArr(IntPtr tuple, [Out] long[] longArray);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl, EntryPoint = "HLIGetDArr")]
		internal static extern int GetDArr(IntPtr tuple, [Out] double[] doubleArray);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void UnpinTuple(HTuple tuple)
		{
			if (tuple != null)
			{
				tuple.UnpinTuple();
			}
		}

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HWindowStackPush(IntPtr win_handle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HWindowStackPop();

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HWindowStackGetActive(out IntPtr win_handle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HWindowStackSetActive(IntPtr win_handle);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HWindowStackIsOpen(out bool is_open);

		[DllImport("SZXCArim", CallingConvention = CallingConvention.Cdecl)]
		internal static extern int HWindowStackCloseAll();

		internal static bool IsError(int err)
		{
			return err >= 1000;
		}

		internal static bool IsFailure(int err)
		{
			return err != 2 && err != 2;
		}

		internal static void HCkP(IntPtr proc, int err)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				SZXCArimAPI.PostCall(proc, err);
			}
		}
	}
}
