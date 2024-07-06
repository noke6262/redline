using System;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Helpers;

internal sealed class UnmanagedPointer : IDisposable
{
	private IntPtr intptr_0;

	private AllocMethod allocMethod_0;

	internal UnmanagedPointer(IntPtr ptr, AllocMethod method)
	{
		allocMethod_0 = method;
		intptr_0 = ptr;
	}

	~UnmanagedPointer()
	{
		method_0(0u);
	}

	private void method_0(uint disposing)
	{
		if (intptr_0 != IntPtr.Zero)
		{
			if (allocMethod_0 == AllocMethod.HGlobal)
			{
				Marshal.FreeHGlobal(intptr_0);
			}
			else if (allocMethod_0 == AllocMethod.CoTaskMem)
			{
				Marshal.FreeCoTaskMem(intptr_0);
			}
			intptr_0 = IntPtr.Zero;
		}
		if (disposing != 0)
		{
			GC.SuppressFinalize(this);
		}
	}

	public void Dispose()
	{
		method_0(1u);
	}

	public static implicit operator IntPtr(UnmanagedPointer ptr)
	{
		return ptr.intptr_0;
	}
}
