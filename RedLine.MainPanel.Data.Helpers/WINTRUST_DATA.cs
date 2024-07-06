using System;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Helpers;

internal struct WINTRUST_DATA : IDisposable
{
	public uint cbStruct;

	public IntPtr pPolicyCallbackData;

	public IntPtr pSIPCallbackData;

	public UiChoice dwUIChoice;

	public RevocationCheckFlags fdwRevocationChecks;

	public UnionChoice dwUnionChoice;

	public IntPtr pInfoStruct;

	public StateAction dwStateAction;

	public IntPtr hWVTStateData;

	private IntPtr intptr_0;

	public TrustProviderFlags dwProvFlags;

	public UIContext dwUIContext;

	public WINTRUST_DATA(WINTRUST_FILE_INFO fileInfo)
	{
		cbStruct = (uint)Marshal.SizeOf(typeof(WINTRUST_DATA));
		pInfoStruct = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WINTRUST_FILE_INFO)));
		Marshal.StructureToPtr(fileInfo, pInfoStruct, fDeleteOld: false);
		dwUnionChoice = UnionChoice.File;
		pPolicyCallbackData = IntPtr.Zero;
		pSIPCallbackData = IntPtr.Zero;
		dwUIChoice = UiChoice.NoUI;
		fdwRevocationChecks = RevocationCheckFlags.None;
		dwStateAction = StateAction.Ignore;
		hWVTStateData = IntPtr.Zero;
		intptr_0 = IntPtr.Zero;
		dwProvFlags = TrustProviderFlags.Safer;
		dwUIContext = UIContext.Execute;
	}

	public void Dispose()
	{
		method_0(1u);
	}

	private void method_0(uint disposing)
	{
		if (dwUnionChoice == UnionChoice.File)
		{
			WINTRUST_FILE_INFO structure = default(WINTRUST_FILE_INFO);
			Marshal.PtrToStructure(pInfoStruct, structure);
			structure.Dispose();
			Marshal.DestroyStructure(pInfoStruct, typeof(WINTRUST_FILE_INFO));
		}
		Marshal.FreeHGlobal(pInfoStruct);
	}
}
