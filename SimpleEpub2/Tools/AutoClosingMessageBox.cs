using DevComponents.DotNetBar;
using System;
using System.Windows.Forms;

namespace SimpleEpub2.Tools
{
	internal class AutoClosingMessageBox
	{
		System.Threading.Timer _timeoutTimer;
		string _caption;

		public AutoClosingMessageBox(Form f, string text, string caption, int timeout)
		{
			_caption = caption;
			_timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
				null, timeout, System.Threading.Timeout.Infinite);
			MessageBoxEx.Show(f, text, caption);
		}

		public static void Show(Form f, string text, string caption, int timeout)
		{
			new AutoClosingMessageBox(f, text, caption, timeout);
		}

		void OnTimerElapsed(object state)
		{
			IntPtr mbWnd = FindWindow(null, _caption);
			if (mbWnd != IntPtr.Zero)
				SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
			_timeoutTimer.Dispose();
		}

		const int WM_CLOSE = 0x0010;
		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
	}
}
