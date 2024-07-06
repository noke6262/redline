using System;
using System.Runtime.InteropServices;

namespace AntiCrack_DotNet;

internal class Structs
{
	public struct CONTEXT
	{
		public uint P1Home;

		public uint P2Home;

		public uint P3Home;

		public uint P4Home;

		public uint P5Home;

		public uint P6Home;

		public long ContextFlags;

		public uint Dr0;

		public uint Dr1;

		public uint Dr2;

		public uint Dr3;

		public uint Dr4;

		public uint Dr5;

		public uint Dr6;

		public uint Dr7;
	}

	public struct PROCESS_MITIGATION_BINARY_SIGNATURE_POLICY
	{
		public uint MicrosoftSignedOnly;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct SYSTEM_CODEINTEGRITY_INFORMATION
	{
		[FieldOffset(0)]
		public ulong Length;

		[FieldOffset(4)]
		public uint CodeIntegrityOptions;
	}

	public struct PROCESS_BASIC_INFORMATION
	{
		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal IntPtr intptr_2;

		internal IntPtr intptr_3;

		internal IntPtr intptr_4;

		internal IntPtr intptr_5;
	}

	public struct SYSTEM_KERNEL_DEBUGGER_INFORMATION
	{
		[MarshalAs(UnmanagedType.U1)]
		public bool KernelDebuggerEnabled;

		[MarshalAs(UnmanagedType.U1)]
		public bool KernelDebuggerNotPresent;
	}

	public struct UNICODE_STRING
	{
		public ushort Length;

		public ushort MaximumLength;

		public IntPtr Buffer;
	}

	public struct ANSI_STRING
	{
		public short Length;

		public short MaximumLength;

		public string Buffer;
	}
}
