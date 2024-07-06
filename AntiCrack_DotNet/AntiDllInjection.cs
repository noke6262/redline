using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AntiCrack_DotNet;

internal class AntiDllInjection
{
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetModuleHandle(string lib);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetProcAddress(IntPtr ModuleHandle, string Function);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool WriteProcessMemory(IntPtr ProcHandle, IntPtr BaseAddress, byte[] Buffer, uint size, int NumOfBytes);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool SetProcessMitigationPolicy(int policy, ref Structs.PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY lpBuffer, int size);

	public static string PatchLoadLibraryA()
	{
		IntPtr procAddress = GetProcAddress(GetModuleHandle("kernelbase.dll"), "LoadLibraryA");
		byte[] buffer = new byte[3] { 194, 4, 0 };
		if (!WriteProcessMemory(Process.GetCurrentProcess().Handle, procAddress, buffer, 3u, 0))
		{
			return "Failed";
		}
		return "Success";
	}

	public static string PatchLoadLibraryW()
	{
		IntPtr procAddress = GetProcAddress(GetModuleHandle("kernelbase.dll"), "LoadLibraryW");
		byte[] buffer = new byte[3] { 194, 4, 0 };
		if (WriteProcessMemory(Process.GetCurrentProcess().Handle, procAddress, buffer, 3u, 0))
		{
			return "Success";
		}
		return "Failed";
	}

	public static string BinaryImageSignatureMitigationAntiDllInjection()
	{
		Structs.PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY lpBuffer = default(Structs.PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY);
		lpBuffer.MicrosoftSignedOnly = 1u;
		if (SetProcessMitigationPolicy(8, ref lpBuffer, Marshal.SizeOf(typeof(Structs.PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY))))
		{
			return "Success";
		}
		return "Failed";
	}
}
