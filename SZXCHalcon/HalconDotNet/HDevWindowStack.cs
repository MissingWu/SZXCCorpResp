using System;
using System.ComponentModel;

namespace SZXCArimEngine
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HDevWindowStack : IDisposable
	{
		~HDevWindowStack()
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
			if (disposing)
			{
				GC.SuppressFinalize(this);
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

		public static void Push(HTuple win_handle)
		{
			int num;
			if (win_handle.Type == HTupleType.HANDLE)
			{
				HHandle expr_10 = win_handle.H;
				num = SZXCArimAPI.HWindowStackPush(expr_10.Handle);
				GC.KeepAlive(expr_10);
			}
			else
			{
				num = SZXCArimAPI.HWindowStackPush(win_handle.IP);
			}
			if (num != 2)
			{
				throw new SZXCArimException(num, "HDevWindowStack::Push");
			}
		}

		public static HTuple Pop()
		{
			IntPtr intPtr;
			int num = SZXCArimAPI.HWindowStackGetActive(out intPtr);
			if (num != 2)
			{
				throw new SZXCArimException(num, "HDevWindowStack::Pop");
			}
			HTuple result;
			if (SZXCArimAPI.IsLegacyHandleMode())
			{
				result = intPtr;
			}
			else
			{
				using (HHandle hHandle = new HHandle(intPtr))
				{
					result = new HTuple(hHandle);
				}
			}
			num = SZXCArimAPI.HWindowStackPop();
			if (num != 2)
			{
				throw new SZXCArimException(num, "HDevWindowStack::Pop");
			}
			return result;
		}

		public static HTuple GetActive()
		{
			IntPtr intPtr;
			int num = SZXCArimAPI.HWindowStackGetActive(out intPtr);
			if (num != 2)
			{
				throw new SZXCArimException(num, "HDevWindowStack::GetActive");
			}
			HTuple result;
			if (SZXCArimAPI.IsLegacyHandleMode())
			{
				result = intPtr;
			}
			else
			{
				using (HHandle hHandle = new HHandle(intPtr))
				{
					result = new HTuple(hHandle);
				}
			}
			return result;
		}

		public static void SetActive(HTuple win_handle)
		{
			int num;
			if (win_handle.Type == HTupleType.HANDLE)
			{
				HHandle expr_10 = win_handle.H;
				num = SZXCArimAPI.HWindowStackSetActive(expr_10.Handle);
				GC.KeepAlive(expr_10);
			}
			else
			{
				num = SZXCArimAPI.HWindowStackSetActive(win_handle.IP);
			}
			if (num != 2)
			{
				throw new SZXCArimException(num, "HDevWindowStack::SetActive");
			}
		}

		public static bool IsOpen()
		{
			bool result;
			int num = SZXCArimAPI.HWindowStackIsOpen(out result);
			if (num != 2)
			{
				throw new SZXCArimException(num, "HDevWindowStack::IsOpen");
			}
			return result;
		}

		public static void CloseAll()
		{
			int num = SZXCArimAPI.HWindowStackCloseAll();
			if (num != 2)
			{
				throw new SZXCArimException(num, "HDevWindowStack::CloseAll");
			}
		}
	}
}
