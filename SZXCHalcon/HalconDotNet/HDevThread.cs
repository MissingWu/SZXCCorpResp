using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SZXCArimEngine
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HDevThread : IDisposable
	{
		public delegate void ProcCallback(HDevThread devThread);

		private IntPtr mThreadHandle;

		private bool mDirectCall;

		private HDevInputParam[] mParamsInput;

		private HDevOutputParam[] mParamsOutput;

		private GCHandle mSelfRef;

		private SZXCArimAPI.HDevThreadInternalCallback mInternalDelegate;

		private HDevThread.ProcCallback mExternalDelegate;

		internal IntPtr InternalCallback(IntPtr dummy)
		{
			if (this.mExternalDelegate != null)
			{
				this.mExternalDelegate(this);
			}
			return IntPtr.Zero;
		}

		internal static void HCkHLib(int err)
		{
			if (SZXCArimAPI.IsFailure(err))
			{
				throw new SZXCArimException(err, "");
			}
		}

		public HDevThread(HDevThreadContext context, HDevThread.ProcCallback proc, int numIn, int numOut)
		{
			HDevThread.HCkHLib(SZXCArimAPI.HXCreateHThread(context.Handle, out this.mThreadHandle));
			GC.KeepAlive(context);
			this.mParamsInput = new HDevInputParam[numIn];
			this.mParamsOutput = new HDevOutputParam[numOut];
			this.mInternalDelegate = new SZXCArimAPI.HDevThreadInternalCallback(this.InternalCallback);
			this.mExternalDelegate = proc;
			this.mSelfRef = GCHandle.Alloc(this);
		}

		public bool IsDirectCall()
		{
			return this.mDirectCall;
		}

		public void Start()
		{
			this.mDirectCall = false;
			IntPtr intPtr;
			HDevThread.HCkHLib(SZXCArimAPI.HXStartHThreadDotNet(this.mThreadHandle, this.mInternalDelegate, IntPtr.Zero, out intPtr));
		}

		public void ParStart(out HTuple parHandle)
		{
			this.mDirectCall = false;
			IntPtr ip;
			HDevThread.HCkHLib(SZXCArimAPI.HXStartHThreadDotNet(this.mThreadHandle, this.mInternalDelegate, IntPtr.Zero, out ip));
			parHandle = new HTuple(ip);
		}

		public void CallProc()
		{
			this.mDirectCall = true;
			HDevThread.HCkHLib(SZXCArimAPI.HXPrepareDirectCall(this.mThreadHandle));
			if (this.mExternalDelegate != null)
			{
				this.mExternalDelegate(this);
			}
		}

		public static void ParJoin(HTuple par_handle)
		{
			for (int i = 0; i < par_handle.Length; i++)
			{
				HDevThread.HCkHLib(SZXCArimAPI.HXJoinHThread(par_handle[i].IP));
			}
		}

		public void Exit()
		{
			HDevThread.HCkHLib(SZXCArimAPI.HXExitHThread(this.mThreadHandle));
			this.mSelfRef.Free();
		}

		public void Dispose()
		{
			for (int i = 0; i < this.mParamsInput.Length; i++)
			{
				this.mParamsInput[i].Dispose();
			}
			if (this.mThreadHandle != IntPtr.Zero)
			{
				this.mThreadHandle = IntPtr.Zero;
			}
		}

		public void SetInputIconicParamObject(int parIndex, HObject obj)
		{
			this.mParamsInput[parIndex] = new HDevInputParamObject(obj);
		}

		public void SetInputIconicParamVector(int parIndex, HObjectVector vector)
		{
			this.mParamsInput[parIndex] = new HDevInputParamVector(vector);
		}

		public void SetInputCtrlParamTuple(int parIndex, HTuple tuple)
		{
			this.mParamsInput[parIndex] = new HDevInputParamTuple(tuple);
		}

		public void SetInputCtrlParamVector(int parIndex, HTupleVector vector)
		{
			this.mParamsInput[parIndex] = new HDevInputParamVector(vector);
		}

		public HObject GetInputIconicParamObject(int parIndex)
		{
			return this.mParamsInput[parIndex].GetIconicParamObject();
		}

		public HObjectVector GetInputIconicParamVector(int parIndex)
		{
			return this.mParamsInput[parIndex].GetIconicParamVector();
		}

		public HTuple GetInputCtrlParamTuple(int parIndex)
		{
			return this.mParamsInput[parIndex].GetCtrlParamTuple();
		}

		public HTupleVector GetInputCtrlParamVector(int parIndex)
		{
			return this.mParamsInput[parIndex].GetCtrlParamVector();
		}

		public void BindOutputIconicParamObject(int parIndex, bool global, HObject obj)
		{
			this.mParamsOutput[parIndex] = new HDevOutputParamObject(obj, global);
		}

		public void BindOutputIconicParamVector(int parIndex, bool global, HObjectVector vector, HTuple index)
		{
			this.mParamsOutput[parIndex] = new HDevOutputParamVector(vector, index, global);
		}

		public void BindOutputIconicParamVector(int parIndex, bool global, HObjectVector vector)
		{
			this.BindOutputIconicParamVector(parIndex, global, vector, new HTuple());
		}

		public void BindOutputCtrlParamTuple(int parIndex, bool global, HTuple tuple)
		{
			this.mParamsOutput[parIndex] = new HDevOutputParamTuple(tuple, global);
		}

		public void BindOutputCtrlParamVector(int parIndex, bool global, HTupleVector vector, HTuple index)
		{
			this.mParamsOutput[parIndex] = new HDevOutputParamVector(vector, index, global);
		}

		public void BindOutputCtrlParamVector(int parIndex, bool global, HTupleVector vector)
		{
			this.BindOutputCtrlParamVector(parIndex, global, vector, new HTuple());
		}

		public void StoreOutputIconicParamObject(int parIndex, HObject obj)
		{
			HDevOutputParam hDevOutputParam = this.mParamsOutput[parIndex];
			using (HDevParamGuard hDevParamGuard = new HDevParamGuard(this.mThreadHandle, hDevOutputParam.IsGlobal()))
			{
				if (hDevParamGuard.IsAvailable())
				{
					hDevOutputParam.StoreIconicParamObject(obj);
				}
			}
		}

		public void StoreOutputIconicParamVector(int parIndex, HObjectVector vector)
		{
			HDevOutputParam hDevOutputParam = this.mParamsOutput[parIndex];
			using (HDevParamGuard hDevParamGuard = new HDevParamGuard(this.mThreadHandle, hDevOutputParam.IsGlobal()))
			{
				if (hDevParamGuard.IsAvailable())
				{
					hDevOutputParam.StoreIconicParamVector(vector);
				}
			}
		}

		public void StoreOutputCtrlParamTuple(int parIndex, HTuple tuple)
		{
			HDevOutputParam hDevOutputParam = this.mParamsOutput[parIndex];
			using (HDevParamGuard hDevParamGuard = new HDevParamGuard(this.mThreadHandle, hDevOutputParam.IsGlobal()))
			{
				if (hDevParamGuard.IsAvailable())
				{
					hDevOutputParam.StoreCtrlParamTuple(tuple);
				}
			}
		}

		public void StoreOutputCtrlParamVector(int parIndex, HTupleVector vector)
		{
			HDevOutputParam hDevOutputParam = this.mParamsOutput[parIndex];
			using (HDevParamGuard hDevParamGuard = new HDevParamGuard(this.mThreadHandle, hDevOutputParam.IsGlobal()))
			{
				if (hDevParamGuard.IsAvailable())
				{
					hDevOutputParam.StoreCtrlParamVector(vector);
				}
			}
		}
	}
}
