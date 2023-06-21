using System;
using System.Windows;
using System.Windows.Controls;

namespace SZXCArimEngine
{
	public abstract class HDisplayObjectWPF : FrameworkElement, IDisposable
	{
		protected bool disposed;

		protected HSmartWindowControlWPF ParentHSmartWindowControlWPF
		{
			get
			{
				return this.ParentItemsControl as HSmartWindowControlWPF;
			}
		}

		internal ItemsControl ParentItemsControl
		{
			get
			{
				return ItemsControl.ItemsControlFromItemContainer(this);
			}
		}

		public HDisplayObjectWPF()
		{
		}

		public abstract void Display(HWindow hWindow);

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				this.disposed = true;
			}
		}
	}
}
