using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RedLine.MainPanel.Models.UI;

namespace RedLine.MainPanel.Data.Extensions;

public static class ControlExt
{
	private const int int_0 = 161;

	private const int int_1 = 2;

	private const int int_2 = 132;

	private const int int_3 = 131072;

	private const int int_4 = 1;

	private const int int_5 = 2;

	private const int int_6 = 8;

	private const int int_7 = 131072;

	private const int int_8 = 133;

	private const int int_9 = 28;

	[DllImport("dwmapi.dll")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

	[DllImport("dwmapi.dll")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

	[DllImport("dwmapi.dll")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool IsCompositionEnabled()
	{
		if (Environment.OSVersion.Version.Major < 6)
		{
			return false;
		}
		DwmIsCompositionEnabled(out var enabled);
		return enabled;
	}

	[DllImport("dwmapi.dll")]
	private static extern int DwmIsCompositionEnabled(out bool enabled);

	[DllImport("Gdi32.dll")]
	private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

	[DllImport("user32.dll")]
	private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	private static extern bool ReleaseCapture();

	public static void AllowDraggBy(this Control control, Control dragger)
	{
		dragger.MouseDown += delegate(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(control.Handle, 161, 2, 0);
			}
		};
	}

	public static void ApplyShadows(this Control control)
	{
		int attrValue = 2;
		DwmSetWindowAttribute(control.Handle, 2, ref attrValue, 4);
		MARGINS mARGINS = default(MARGINS);
		mARGINS.bottomHeight = 1;
		mARGINS.leftWidth = 0;
		mARGINS.rightWidth = 0;
		mARGINS.topHeight = 0;
		MARGINS pMarInset = mARGINS;
		DwmExtendFrameIntoClientArea(control.Handle, ref pMarInset);
	}
}
