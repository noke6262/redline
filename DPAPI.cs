using System;
using System.Security.Cryptography;
using System.Text;

public static class DPAPI
{
	public static string Unprotect(string encryptedString, DataProtectionScope scope, string optionalEntropy = null)
	{
		return Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(encryptedString), (optionalEntropy != null) ? Encoding.UTF8.GetBytes(optionalEntropy) : null, scope));
	}

	public static string Protect(string stringToEncrypt, DataProtectionScope scope, string optionalEntropy = null)
	{
		return Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(stringToEncrypt), (optionalEntropy != null) ? Encoding.UTF8.GetBytes(optionalEntropy) : null, scope));
	}
}
