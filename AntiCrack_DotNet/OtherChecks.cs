using System.Runtime.InteropServices;

namespace AntiCrack_DotNet;

public class OtherChecks
{
	private static uint uint_0 = 103u;

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint NtQuerySystemInformation(uint SystemInformationClass, ref Structs.SYSTEM_CODEINTEGRITY_INFORMATION SystemInformation, uint SystemInformationLength, out uint ReturnLength);

	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint NtQuerySystemInformation(uint SystemInformationClass, ref Structs.SYSTEM_KERNEL_DEBUGGER_INFORMATION SystemInformation, uint SystemInformationLength, out uint ReturnLength);

	public static bool IsUnsignedDriversAllowed()
	{
		Structs.SYSTEM_CODEINTEGRITY_INFORMATION SystemInformation = default(Structs.SYSTEM_CODEINTEGRITY_INFORMATION);
		SystemInformation.Length = (uint)Marshal.SizeOf(typeof(Structs.SYSTEM_CODEINTEGRITY_INFORMATION));
		uint ReturnLength = 0u;
		NtQuerySystemInformation(uint_0, ref SystemInformation, (uint)Marshal.SizeOf(SystemInformation), out ReturnLength);
		if (ReturnLength != (uint)Marshal.SizeOf(SystemInformation) || (SystemInformation.CodeIntegrityOptions & 1) != 1)
		{
			return true;
		}
		return false;
	}

	public static bool IsTestSignedDriversAllowed()
	{
		Structs.SYSTEM_CODEINTEGRITY_INFORMATION SystemInformation = default(Structs.SYSTEM_CODEINTEGRITY_INFORMATION);
		SystemInformation.Length = (uint)Marshal.SizeOf(typeof(Structs.SYSTEM_CODEINTEGRITY_INFORMATION));
		uint ReturnLength = 0u;
		NtQuerySystemInformation(uint_0, ref SystemInformation, (uint)Marshal.SizeOf(SystemInformation), out ReturnLength);
		if (ReturnLength == (uint)Marshal.SizeOf(SystemInformation) && (SystemInformation.CodeIntegrityOptions & 2) == 2)
		{
			return true;
		}
		return false;
	}

	public static bool IsKernelDebuggingEnabled()
	{
		Structs.SYSTEM_KERNEL_DEBUGGER_INFORMATION SystemInformation = new Structs.SYSTEM_KERNEL_DEBUGGER_INFORMATION
		{
			KernelDebuggerEnabled = false,
			KernelDebuggerNotPresent = true
		};
		uint ReturnLength = 0u;
		NtQuerySystemInformation(35u, ref SystemInformation, (uint)Marshal.SizeOf(SystemInformation), out ReturnLength);
		if (ReturnLength == (uint)Marshal.SizeOf(SystemInformation) && (SystemInformation.KernelDebuggerEnabled || !SystemInformation.KernelDebuggerNotPresent))
		{
			return true;
		}
		return false;
	}
}
