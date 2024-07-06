using System;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Helpers;

internal struct WINTRUST_FILE_INFO : IDisposable
{
	public uint cbStruct;

	[MarshalAs(UnmanagedType.LPTStr)]
	public string pcwszFilePath;

	public IntPtr hFile;

	public IntPtr pgKnownSubject;

	public WINTRUST_FILE_INFO(string fileName, Guid subject)
	{
		cbStruct = (uint)Marshal.SizeOf(typeof(WINTRUST_FILE_INFO));
		pcwszFilePath = fileName;
		if (subject != Guid.Empty)
		{
			pgKnownSubject = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Guid)));
			Marshal.StructureToPtr(subject, pgKnownSubject, fDeleteOld: true);
		}
		else
		{
			pgKnownSubject = IntPtr.Zero;
		}
		hFile = IntPtr.Zero;
	}

	public void Dispose()
	{
		method_0(1u);
	}

	private void method_0(uint disposing)
	{
		if (pgKnownSubject != IntPtr.Zero)
		{
			Marshal.DestroyStructure(pgKnownSubject, typeof(Guid));
			Marshal.FreeHGlobal(pgKnownSubject);
		}
	}
}
