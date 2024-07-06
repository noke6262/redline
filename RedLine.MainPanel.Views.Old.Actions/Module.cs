using System;
using System.Runtime.CompilerServices;

namespace RedLine.MainPanel.Views.Old.Actions;

public class Module
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private uint uint_0;

	public string ModuleName
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public IntPtr BaseAddress
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

	public uint Size
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public Module(string moduleName, IntPtr baseAddress, uint size)
	{
		ModuleName = moduleName;
		BaseAddress = baseAddress;
		Size = size;
	}
}
