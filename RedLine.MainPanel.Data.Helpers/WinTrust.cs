using System;
using System.Runtime.InteropServices;

namespace RedLine.MainPanel.Data.Helpers;

internal sealed class WinTrust
{
	private static readonly IntPtr intptr_0 = new IntPtr(-1);

	private const string string_0 = "";

	[DllImport("wintrust.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
	private static extern WinVerifyTrustResult WinVerifyTrust([In] IntPtr hwnd, [In][MarshalAs(UnmanagedType.LPStruct)] Guid pgActionID, [In] WinTrustData pWVTData);

	public static WinVerifyTrustResult VerifyEmbeddedSignature(string fileName)
	{
		WinTrustFileInfo winTrustFileInfo = new WinTrustFileInfo(fileName);
		WinTrustData winTrustData = new WinTrustData(winTrustFileInfo);
		WinVerifyTrustResult result = WinVerifyTrust(pgActionID: new Guid("{00AAC56B-CD44-11d0-8CC2-00C04FC295EE}"), hwnd: intptr_0, pWVTData: winTrustData);
		winTrustFileInfo.Dispose();
		winTrustData.Dispose();
		return result;
	}

	private WinTrust()
	{
	}
}
