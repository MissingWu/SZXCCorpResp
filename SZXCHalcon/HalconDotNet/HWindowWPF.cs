using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Interop;

namespace SZXCArimEngine
{
	internal class HWindowWPF : HwndHost
	{
		private HWindowControlWPF parent;

		private HWindow window = new HWindow();

		private IntPtr hwndSZXCArim = IntPtr.Zero;

		private int width = 1;

		private int height = 1;

		private int lastMoveX;

		private int lastMoveY;

		private bool delayedInit;

		internal const int WS_CHILD = 1073741824;

		internal const int WS_VISIBLE = 268435456;

		internal const int LBS_NOTIFY = 1;

		internal const int HOST_ID = 2;

		internal const int LISTBOX_ID = 1;

		internal const int WS_VSCROLL = 2097152;

		internal const int WS_BORDER = 8388608;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HWInitEventHandler HWInitEvent;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HWButtonEventHandler HWButtonEvent;

		[method: CompilerGenerated]
		[CompilerGenerated]
		public event HWMouseEventHandler HWMouseEvent;

		public HWindow SZXCArimWindow
		{
			get
			{
				return this.window;
			}
		}

		public HWindowWPF(HWindowControlWPF parent)
		{
			this.parent = parent;
		}

		protected override HandleRef BuildWindowCore(HandleRef hwndParent)
		{
			this.width = (int)this.parent.Container.ActualWidth;
			this.height = (int)this.parent.Container.ActualHeight;
			if (this.width <= 0 || double.IsNaN((double)this.width))
			{
				this.delayedInit = true;
				this.width = 1;
			}
			if (this.height <= 0 || double.IsNaN((double)this.height))
			{
				this.delayedInit = true;
				this.height = 1;
			}
			base.Width = (double)this.width;
			base.Height = (double)this.height;
			IntPtr intPtr = HWindowWPF.CreateWindowEx(0, "static", "", 1342177280, 0, 0, this.width, this.height, hwndParent.Handle, (IntPtr)2, IntPtr.Zero, 0);
			try
			{
				HSystem.SetCheck("~father");
				this.window.OpenWindow(0, 0, this.width, this.height, intPtr, "visible", "");
				IntPtr intPtr2;
				this.hwndSZXCArim = this.window.GetOsWindowHandle(out intPtr2);
			}
			catch (HOperatorException ex)
			{
				int errorCode = ex.GetErrorCode();
				if (errorCode >= 5100 && errorCode < 5200)
				{
					throw ex;
				}
			}
			if (!this.delayedInit)
			{
				this.HWInitEvent();
			}
			return new HandleRef(this, intPtr);
		}

		protected override void DestroyWindowCore(HandleRef hwnd)
		{
			if (this.window.IsInitialized())
			{
				this.window.Dispose();
			}
			this.hwndSZXCArim = IntPtr.Zero;
			IntPtr handle = hwnd.Handle;
			if (handle != IntPtr.Zero)
			{
				HWindowWPF.DestroyWindow(handle);
			}
		}

		public void SetWindowExtents(int width, int height)
		{
			if (!this.window.IsInitialized())
			{
				return;
			}
			bool flag = true;
			if (width <= 0 || double.IsNaN((double)width))
			{
				flag = false;
				width = 1;
			}
			if (height <= 0 || double.IsNaN((double)height))
			{
				flag = false;
				height = 1;
			}
			if (this.width != width || this.height != height)
			{
				this.width = width;
				this.height = height;
				base.Width = (double)width;
				base.Height = (double)height;
				this.window.SetWindowExtents(0, 0, width, height);
			}
			if (this.delayedInit & flag)
			{
				this.delayedInit = false;
				this.HWInitEvent();
			}
		}

		[DllImport("user32.dll")]
		private static extern IntPtr SetFocus(IntPtr hWnd);

		public void SetNativeFocus()
		{
			if (this.window.IsInitialized() && this.hwndSZXCArim != IntPtr.Zero)
			{
				HWindowWPF.SetFocus(this.hwndSZXCArim);
			}
		}

		protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
		{
			IntPtr result = base.WndProc(hwnd, msg, wparam, lparam, ref handled);
			int num2;
			int x;
			int y;
			if (SZXCArimAPI.isPlatform64)
			{
				if (msg == 522)
				{
					long num = wparam.ToInt64() & (long)((long)-1);
					if (num > 2147483647L)
					{
						num |= -4294967296L;
					}
					num2 = (int)(num >> 16);
				}
				else
				{
					num2 = wparam.ToInt32();
				}
				x = (int)(lparam.ToInt64() & 65535L);
				y = (int)(lparam.ToInt64() >> 16);
			}
			else
			{
				num2 = wparam.ToInt32() >> 16;
				x = (lparam.ToInt32() & 65535);
				y = lparam.ToInt32() >> 16;
			}
			switch (msg)
			{
			case 512:
				if ((num2 & 1) != 0)
				{
					this.HWMouseEvent(x, y, new MouseButton?(MouseButton.Left), 0);
				}
				else if ((num2 & 16) != 0)
				{
					this.HWMouseEvent(x, y, new MouseButton?(MouseButton.Middle), 0);
				}
				else if ((num2 & 2) != 0)
				{
					this.HWMouseEvent(x, y, new MouseButton?(MouseButton.Right), 0);
				}
				else if ((num2 & 32) != 0)
				{
					this.HWMouseEvent(x, y, new MouseButton?(MouseButton.XButton1), 0);
				}
				else if ((num2 & 64) != 0)
				{
					this.HWMouseEvent(x, y, new MouseButton?(MouseButton.XButton2), 0);
				}
				else
				{
					this.HWMouseEvent(x, y, null, 0);
				}
				this.lastMoveX = x;
				this.lastMoveY = y;
				break;
			case 513:
				this.HWButtonEvent(x, y, MouseButton.Left, MouseButtonState.Pressed);
				break;
			case 514:
				this.HWButtonEvent(x, y, MouseButton.Left, MouseButtonState.Released);
				break;
			case 516:
				this.HWButtonEvent(x, y, MouseButton.Right, MouseButtonState.Pressed);
				break;
			case 517:
				this.HWButtonEvent(x, y, MouseButton.Right, MouseButtonState.Released);
				break;
			case 519:
				this.HWButtonEvent(x, y, MouseButton.Middle, MouseButtonState.Pressed);
				break;
			case 520:
				this.HWButtonEvent(x, y, MouseButton.Middle, MouseButtonState.Released);
				break;
			case 522:
				this.HWMouseEvent(this.lastMoveX, this.lastMoveY, null, num2);
				break;
			case 523:
				this.HWButtonEvent(x, y, ((num2 & 32) == 32) ? MouseButton.XButton1 : MouseButton.XButton2, MouseButtonState.Pressed);
				break;
			case 524:
				this.HWButtonEvent(x, y, ((num2 & 32) == 32) ? MouseButton.XButton1 : MouseButton.XButton2, MouseButtonState.Released);
				break;
			}
			return result;
		}

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		internal static extern IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, IntPtr hwndParent, IntPtr hMenu, IntPtr hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DestroyWindow(IntPtr hwnd);
	}
}
