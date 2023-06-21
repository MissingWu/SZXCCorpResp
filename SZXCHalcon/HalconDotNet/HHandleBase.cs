using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HHandleBase : IDisposable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static readonly IntPtr UNDEF = IntPtr.Zero;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static readonly HHandle HNULL = new HHandle();

		private IntPtr mHandle;

		private bool suppressedFinalization;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Handle
		{
			get
			{
				return this.mHandle;
			}
			set
			{
				this.SetHandleInternal(value, true);
				SZXCArimAPI.ReleaseExternalOwnership(value);
			}
		}

		internal HHandleBase() : this(HHandleBase.UNDEF)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal HHandleBase(IntPtr handle)
		{
			this.Handle = handle;
		}

		private void SetHandleInternal(IntPtr handle, bool copy)
		{
			this.ClearHandleInternal();
			if (this.suppressedFinalization)
			{
				this.suppressedFinalization = false;
				GC.ReRegisterForFinalize(this);
			}
			if (handle != HHandleBase.UNDEF)
			{
				this.mHandle = (copy ? SZXCArimAPI.CopyHandle(handle) : handle);
			}
		}

		internal HHandleBase(HHandleBase handle)
		{
			this.SetHandleInternal(handle, true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Detach()
		{
			SZXCArimAPI.AcquireExternalOwnership(this.mHandle);
		}

		public bool IsInitialized()
		{
			return SZXCArimAPI.HandleIsValid(this.mHandle);
		}

		~HHandleBase()
		{
			try
			{
				this.Dispose(false);
			}
			catch (Exception)
			{
			}
		}

		private void Dispose(bool disposing)
		{
			if (this.mHandle != HHandleBase.UNDEF)
			{
				this.ClearHandleInternal();
				this.mHandle = HHandleBase.UNDEF;
			}
			if (disposing)
			{
				GC.SuppressFinalize(this);
				this.suppressedFinalization = true;
			}
			GC.KeepAlive(this);
		}

		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		public virtual void Dispose()
		{
			this.Dispose(true);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InvalidateWithoutDispose()
		{
			this.Detach();
			this.Dispose();
		}

		internal void Store(IntPtr proc, int parIndex)
		{
			SZXCArimAPI.StoreH(proc, parIndex, this.mHandle);
		}

		internal int Load(IntPtr proc, int parIndex, int err)
		{
			if (this.mHandle != HHandleBase.UNDEF)
			{
				throw new SZXCArimException("Undisposed handle instance when loading output parameter");
			}
			if (SZXCArimAPI.IsFailure(err))
			{
				return err;
			}
			HHandle hHandle;
			err = SZXCArimAPI.LoadH(proc, parIndex, err, out hHandle);
			this.SetHandleInternal(hHandle.Handle, true);
			hHandle.Dispose();
			return err;
		}

		protected virtual void ClearHandleInternal()
		{
			if (this.mHandle != HHandleBase.UNDEF)
			{
				SZXCArimAPI.ClearHandle(this.mHandle);
				this.mHandle = HHandleBase.UNDEF;
			}
		}

		public override string ToString()
		{
			if (this.mHandle == HHandleBase.UNDEF)
			{
				return "";
			}
			return "H" + this.mHandle.ToInt64().ToString("X");
		}

		protected internal void AssertSemType(string sem_type)
		{
			if (!SZXCArimAPI.IsLegacyHandleMode() && this.mHandle != HHandleBase.UNDEF)
			{
				string handleSemType = SZXCArimAPI.GetHandleSemType(this.mHandle);
				if (!sem_type.Equals(handleSemType))
				{
					throw new SZXCArimException("Invalid handle instance passed");
				}
			}
			GC.KeepAlive(this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HTuple ConcatArray(HHandleBase[] handles)
		{
			return new HTuple(handles as HHandle[]);
		}

		public static implicit operator IntPtr(HHandleBase handle)
		{
			if (handle == null)
			{
				return HHandleBase.UNDEF;
			}
			return handle.mHandle;
		}
	}
}
