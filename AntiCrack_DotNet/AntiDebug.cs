using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AntiCrack_DotNet;

internal class AntiDebug
{
	private static long long_0 = 65552L;

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetHandleInformation(IntPtr hObject, uint dwMask, uint dwFlags);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern bool NtClose(IntPtr Handle);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr CreateMutexA(IntPtr lpMutexAttributes, bool bInitialOwner, string lpName);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool IsDebuggerPresent();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(IntPtr Handle, ref bool CheckBool);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetModuleHandle(string lib);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetProcAddress(IntPtr ModuleHandle, string Function);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool WriteProcessMemory(SafeHandle ProcHandle, IntPtr BaseAddress, byte[] Buffer, uint size, int NumOfBytes);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint NtSetInformationThread(IntPtr ThreadHandle, uint ThreadInformationClass, IntPtr ThreadInformation, int ThreadInformationLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr OpenThread(uint DesiredAccess, bool InheritHandle, int ThreadId);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint GetTickCount();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern void OutputDebugStringA(string Text);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetCurrentThread();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool GetThreadContext(IntPtr hThread, ref Structs.CONTEXT Context);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint NtQueryInformationProcess(SafeHandle hProcess, uint ProcessInfoClass, out uint ProcessInfo, uint nSize, uint ReturnLength);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint NtQueryInformationProcess(SafeHandle hProcess, uint ProcessInfoClass, out IntPtr ProcessInfo, uint nSize, uint ReturnLength);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint NtQueryInformationProcess(SafeHandle hProcess, uint ProcessInfoClass, ref Structs.PROCESS_BASIC_INFORMATION ProcessInfo, uint nSize, uint ReturnLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern int QueryFullProcessImageNameA(SafeHandle hProcess, uint Flags, byte[] lpExeName, int[] lpdwSize);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", SetLastError = true)]
	private static extern int GetWindowTextLengthA(IntPtr HWND);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern int GetWindowTextA(IntPtr HWND, StringBuilder WindowText, int nMaxCount);

	public static bool NtCloseAntiDebug_InvalidHandle()
	{
		try
		{
			NtClose((IntPtr)19075618L);
			return false;
		}
		catch
		{
			return true;
		}
	}

	public static bool NtCloseAntiDebug_ProtectedHandle()
	{
		IntPtr intPtr = CreateMutexA(IntPtr.Zero, bInitialOwner: false, new Random().Next(0, 9999999).ToString());
		SetHandleInformation(intPtr, 2u, 2u);
		try
		{
			NtClose(intPtr);
			return false;
		}
		catch
		{
			return true;
		}
	}

	public static bool DebuggerIsAttached()
	{
		return Debugger.IsAttached;
	}

	public static bool IsDebuggerPresentCheck()
	{
		if (IsDebuggerPresent())
		{
			return true;
		}
		return false;
	}

	public static bool NtQueryInformationProcessCheck_ProcessDebugFlags()
	{
		uint ProcessInfo = 0u;
		NtQueryInformationProcess((SafeHandle)Process.GetCurrentProcess().SafeHandle, 31u, out ProcessInfo, 4u, 0u);
		if (ProcessInfo == 0)
		{
			return true;
		}
		return false;
	}

	public static bool NtQueryInformationProcessCheck_ProcessDebugPort()
	{
		uint ProcessInfo = 0u;
		uint nSize = 4u;
		if (Environment.Is64BitProcess)
		{
			nSize = 8u;
		}
		NtQueryInformationProcess((SafeHandle)Process.GetCurrentProcess().SafeHandle, 7u, out ProcessInfo, nSize, 0u);
		if (ProcessInfo != 0)
		{
			return true;
		}
		return false;
	}

	public static bool NtQueryInformationProcessCheck_ProcessDebugObjectHandle()
	{
		IntPtr ProcessInfo = IntPtr.Zero;
		uint nSize = 4u;
		if (Environment.Is64BitProcess)
		{
			nSize = 8u;
		}
		NtQueryInformationProcess((SafeHandle)Process.GetCurrentProcess().SafeHandle, 30u, out ProcessInfo, nSize, 0u);
		if (ProcessInfo != IntPtr.Zero)
		{
			return true;
		}
		return false;
	}

	public static string AntiDebugAttach()
	{
		IntPtr moduleHandle = GetModuleHandle("ntdll.dll");
		IntPtr procAddress = GetProcAddress(moduleHandle, "DbgUiRemoteBreakin");
		IntPtr procAddress2 = GetProcAddress(moduleHandle, "DbgBreakPoint");
		byte[] buffer = new byte[1] { 204 };
		byte[] buffer2 = new byte[1] { 195 };
		if (WriteProcessMemory(Process.GetCurrentProcess().SafeHandle, procAddress, buffer, 1u, 0) & WriteProcessMemory(Process.GetCurrentProcess().SafeHandle, procAddress2, buffer2, 1u, 0))
		{
			return "Success";
		}
		return "Failed";
	}

	public static bool FindWindowAntiDebug()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			string[] array = new string[10] { "x32dbg", "x64dbg", "windbg", "ollydbg", "dnspy", "immunity debugger", "hyperdbg", "cheat engine", "cheatengine", "ida" };
			foreach (string value in array)
			{
				if (process.MainWindowTitle.ToLower().Contains(value))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool GetForegroundWindowAntiDebug()
	{
		string[] array = new string[12]
		{
			"x32dbg", "x64dbg", "windbg", "ollydbg", "dnspy", "immunity debugger", "hyperdbg", "debug", "debugger", "cheat engine",
			"cheatengine", "ida"
		};
		IntPtr foregroundWindow = GetForegroundWindow();
		int windowTextLengthA = GetWindowTextLengthA(foregroundWindow);
		if (windowTextLengthA != 0)
		{
			StringBuilder stringBuilder = new StringBuilder(windowTextLengthA + 1);
			GetWindowTextA(foregroundWindow, stringBuilder, windowTextLengthA + 1);
			string[] array2 = array;
			foreach (string value in array2)
			{
				if (stringBuilder.ToString().ToLower().Contains(value))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static string HideThreadsAntiDebug()
	{
		try
		{
			bool flag = false;
			foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
			{
				IntPtr intPtr = OpenThread(32u, InheritHandle: false, thread.Id);
				if (intPtr != IntPtr.Zero)
				{
					uint num = NtSetInformationThread(intPtr, 17u, IntPtr.Zero, 0);
					NtClose(intPtr);
					if (num != 0)
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				return "Success";
			}
			return "Failed";
		}
		catch
		{
			return "Failed";
		}
	}

	public static bool GetTickCountAntiDebug()
	{
		uint tickCount = GetTickCount();
		return GetTickCount() - tickCount > 16;
	}

	public static bool OutputDebugStringAntiDebug()
	{
		OutputDebugStringA("just testing some stuff...");
		if (Marshal.GetLastWin32Error() == 0)
		{
			return true;
		}
		return false;
	}

	public static void OllyDbgFormatStringExploit()
	{
		OutputDebugStringA("%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s");
	}

	public static bool DebugBreakAntiDebug()
	{
		try
		{
			Debugger.Break();
			return false;
		}
		catch
		{
			return true;
		}
	}

	public static bool HardwareRegistersBreakpointsDetection()
	{
		Structs.CONTEXT Context = default(Structs.CONTEXT);
		Context.ContextFlags = long_0;
		if (!GetThreadContext(GetCurrentThread(), ref Context) || (Context.Dr1 == 0 && Context.Dr2 == 0 && Context.Dr3 == 0 && Context.Dr4 == 0 && Context.Dr5 == 0 && Context.Dr6 == 0 && Context.Dr7 == 0))
		{
			return false;
		}
		return true;
	}

	private static object smethod_0(object Path)
	{
		string text = null;
		for (int i = 0; i < ((string)Path).Length; i++)
		{
			char c = ((string)Path)[i];
			if (c != 0)
			{
				text += c;
			}
		}
		return text;
	}

	public static bool ParentProcessAntiDebug()
	{
		try
		{
			Structs.PROCESS_BASIC_INFORMATION ProcessInfo = default(Structs.PROCESS_BASIC_INFORMATION);
			if (NtQueryInformationProcess(Process.GetCurrentProcess().SafeHandle, 0u, ref ProcessInfo, (uint)Marshal.SizeOf(typeof(Structs.PROCESS_BASIC_INFORMATION)), 0u) == 0)
			{
				int num = ProcessInfo.intptr_5.ToInt32();
				if (num != 0)
				{
					byte[] array = new byte[256];
					int[] array2 = new int[256];
					array2[0] = 256;
					QueryFullProcessImageNameA(Process.GetProcessById(num).SafeHandle, 0u, array, array2);
					string fileName = Path.GetFileName((string)smethod_0(Encoding.UTF8.GetString(array)));
					string[] array3 = new string[2] { "explorer.exe", "cmd.exe" };
					foreach (string value in array3)
					{
						if (fileName.Equals(value))
						{
							return false;
						}
					}
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}
}
