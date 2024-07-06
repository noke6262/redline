using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mscoree;

[ComImport]
[CompilerGenerated]
[InterfaceType(1)]
[TypeIdentifier]
[Guid("CB2F6722-AB3A-11D2-9C40-00C04FA30A3E")]
public interface ICorRuntimeHost
{
	void _VtblGap1_11();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void EnumDomains(out IntPtr hEnum);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void NextDomain([In] IntPtr hEnum, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CloseEnum([In] IntPtr hEnum);
}
