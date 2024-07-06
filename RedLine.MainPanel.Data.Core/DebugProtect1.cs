using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Core;

public class DebugProtect1
{
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)] ref bool isDebuggerPresent);

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool IsDebuggerPresent();

	public static int PerformChecks()
	{
		if (smethod_0() == 1)
		{
			return 1;
		}
		if (smethod_1() == 1)
		{
			return 1;
		}
		if (smethod_2() != 1)
		{
			return 0;
		}
		return 1;
	}

	private static uint smethod_0()
	{
		if (Debugger.IsAttached)
		{
			return 1u;
		}
		return 0u;
	}

	private static uint smethod_1()
	{
		if (IsDebuggerPresent())
		{
			return 1u;
		}
		return 0u;
	}

	private static uint smethod_2()
	{
		bool isDebuggerPresent = false;
		if (CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent) && isDebuggerPresent)
		{
			return 1u;
		}
		return 0u;
	}
}
