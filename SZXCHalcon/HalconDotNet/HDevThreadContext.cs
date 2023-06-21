using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HDevThreadContext : IDisposable
	{
		private IntPtr mContextHandle;

		public IntPtr Handle
		{
			get
			{
				return this.mContextHandle;
			}
		}

		public HDevThreadContext()
		{
			HDevThread.HCkHLib(SZXCArimAPI.HXCreateHThreadContext(out this.mContextHandle));
		}

		public void Dispose()
		{
			if (this.mContextHandle != IntPtr.Zero)
			{
				HDevThread.HCkHLib(SZXCArimAPI.HXClearHThreadContext(this.mContextHandle));
				this.mContextHandle = IntPtr.Zero;
			}
		}
	}
}
