using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HDevDisposeHelper : IDisposable
	{
		protected List<IDisposable> mDisposables;

		public HDevDisposeHelper()
		{
			this.mDisposables = new List<IDisposable>();
		}

		public IDisposable Add(IDisposable disposable)
		{
			for (int i = 0; i < this.mDisposables.Count; i++)
			{
				if (this.mDisposables[i] == disposable)
				{
					return disposable;
				}
			}
			this.mDisposables.Add(disposable);
			return disposable;
		}

		public IDisposable Take(IDisposable disposable)
		{
			for (int i = 0; i < this.mDisposables.Count; i++)
			{
				if (this.mDisposables[i] == disposable)
				{
					this.mDisposables.RemoveAt(i);
					return disposable;
				}
			}
			return disposable;
		}

		void IDisposable.Dispose()
		{
			for (int i = 0; i < this.mDisposables.Count; i++)
			{
				this.mDisposables[i].Dispose();
			}
			this.mDisposables.Clear();
		}

		public HObjectVector Add(HObjectVector disposable)
		{
			return (HObjectVector)this.Add(disposable);
		}

		public HObjectVector Take(HObjectVector disposable)
		{
			return (HObjectVector)this.Take(disposable);
		}

		public HObject Add(HObject disposable)
		{
			return (HObject)this.Add(disposable);
		}

		public HObject Take(HObject disposable)
		{
			return (HObject)this.Take(disposable);
		}

		public HTupleVector Add(HTupleVector disposable)
		{
			return (HTupleVector)this.Add(disposable);
		}

		public HTupleVector Take(HTupleVector disposable)
		{
			return (HTupleVector)this.Take(disposable);
		}

		public HTuple Add(HTuple disposable)
		{
			return (HTuple)this.Add(disposable);
		}

		public HTuple Take(HTuple disposable)
		{
			return (HTuple)this.Take(disposable);
		}
	}
}
