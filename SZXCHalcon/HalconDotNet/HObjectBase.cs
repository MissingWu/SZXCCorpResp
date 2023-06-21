using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	public class HObjectBase : IDisposable
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static readonly IntPtr UNDEF = IntPtr.Zero;

		internal static readonly IntPtr UNDEF2 = new IntPtr(1);

		internal IntPtr key = HObjectBase.UNDEF;

		private bool suppressedFinalization;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Key
		{
			get
			{
				return this.key;
			}
		}

		internal HObjectBase() : this(HObjectBase.UNDEF, false)
		{
		}

		internal HObjectBase(IntPtr key, bool copy)
		{
			if (copy && key != HObjectBase.UNDEF && key != HObjectBase.UNDEF2)
			{
				this.key = SZXCArimAPI.CopyObject(key);
				return;
			}
			this.key = ((key == HObjectBase.UNDEF2) ? HObjectBase.UNDEF : key);
		}

		internal HObjectBase(HObjectBase obj) : this(obj.key, true)
		{
			GC.KeepAlive(obj);
		}

		public bool IsInitialized()
		{
			return this.key != HObjectBase.UNDEF;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr CopyKey()
		{
			IntPtr arg_11_0 = SZXCArimAPI.CopyObject(this.key);
			GC.KeepAlive(this);
			return arg_11_0;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TransferOwnership(HObjectBase source)
		{
			if (source == this)
			{
				return;
			}
			this.Dispose();
			if (source == null)
			{
				return;
			}
			this.key = source.key;
			source.key = HObjectBase.UNDEF;
			this.suppressedFinalization = false;
			GC.ReRegisterForFinalize(this);
		}

		~HObjectBase()
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
			if (this.key != HObjectBase.UNDEF)
			{
				SZXCArimAPI.ClearObject(this.key);
				this.key = HObjectBase.UNDEF;
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

		internal void Store(IntPtr proc, int parIndex)
		{
			SZXCArimAPI.HCkP(proc, SZXCArimAPI.SetInputObject(proc, parIndex, this.key));
		}

		internal int Load(IntPtr proc, int parIndex, int err)
		{
			if (this.key != HObjectBase.UNDEF)
			{
				throw new SZXCArimException("Undisposed object instance when loading output parameter");
			}
			if (SZXCArimAPI.IsFailure(err))
			{
				return err;
			}
			err = SZXCArimAPI.GetOutputObject(proc, parIndex, out this.key);
			if (this.suppressedFinalization)
			{
				this.suppressedFinalization = false;
				GC.ReRegisterForFinalize(this);
			}
			return err;
		}
	}
}
