using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Models.Files;

public class AssemblyResource
{
	[CompilerGenerated]
	private ResourceType resourceType_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	private IntPtr intptr_2;

	public IntPtr Pointer => intptr_2;

	public ResourceType Type
	{
		[CompilerGenerated]
		get
		{
			return resourceType_0;
		}
		[CompilerGenerated]
		set
		{
			resourceType_0 = value;
		}
	}

	public IntPtr Size
	{
		[CompilerGenerated]
		get
		{
			return intptr_0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = value;
		}
	}

	public IntPtr Name
	{
		[CompilerGenerated]
		get
		{
			return intptr_1;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = value;
		}
	}

	public AssemblyResource(IntPtr ptr)
	{
		intptr_2 = ptr;
	}

	public string GetName()
	{
		return Marshal.PtrToStringUni(Name);
	}

	public int GetSize()
	{
		if (IntPtr.Size * 8 == 64)
		{
			return (int)(Size.ToInt64() << 32 >> 32);
		}
		return Size.ToInt32();
	}
}
