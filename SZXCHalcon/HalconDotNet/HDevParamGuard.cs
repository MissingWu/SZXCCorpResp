using System;

namespace SZXCArimEngine
{
	internal class HDevParamGuard : IDisposable
	{
		protected IntPtr mThreadHandle;

		protected bool mGlobal;

		protected int mReferenceCount;

		public HDevParamGuard(IntPtr threadHandle, bool global)
		{
			this.mThreadHandle = threadHandle;
			this.mGlobal = global;
			this.mReferenceCount = 0;
			if (this.mGlobal)
			{
				HDevThread.HCkHLib(SZXCArimAPI.HXThreadLockGlobalVar(this.mThreadHandle));
				return;
			}
			IntPtr intPtr;
			HDevThread.HCkHLib(SZXCArimAPI.HXThreadLockLocalVar(this.mThreadHandle, out intPtr));
			this.mReferenceCount = intPtr.ToInt32();
		}

		public bool IsAvailable()
		{
			return this.mGlobal || this.mReferenceCount > 1;
		}

		public void Dispose()
		{
			if (this.mGlobal)
			{
				HDevThread.HCkHLib(SZXCArimAPI.HXThreadUnlockGlobalVar(this.mThreadHandle));
				return;
			}
			HDevThread.HCkHLib(SZXCArimAPI.HXThreadUnlockLocalVar(this.mThreadHandle));
		}
	}
}
