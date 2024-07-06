using System;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Helpers;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class WinTrustFileInfo
{
	private uint uint_0 = (uint)Marshal.SizeOf(typeof(WinTrustFileInfo));

	private IntPtr intptr_0;

	private IntPtr intptr_1 = IntPtr.Zero;

	private IntPtr intptr_2 = IntPtr.Zero;

	public WinTrustFileInfo(string _filePath)
	{
		intptr_0 = Marshal.StringToCoTaskMemAuto(_filePath);
	}

	public void Dispose()
	{
		if (intptr_0 != IntPtr.Zero)
		{
			Marshal.FreeCoTaskMem(intptr_0);
			intptr_0 = IntPtr.Zero;
		}
	}
}
