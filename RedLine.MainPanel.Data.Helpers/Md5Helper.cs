using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RedLine.MainPanel.Data.Helpers;

public static class Md5Helper
{
	public static string GetMd5Hash(string source)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.ASCII.GetBytes(source);
		return ByteArrayToHex(mD5CryptoServiceProvider.ComputeHash(bytes)).Replace("-", string.Empty).ToUpper();
	}

	public static string ByteArrayToHex(byte[] buffer)
	{
		StringBuilder stringBuilder = new StringBuilder(buffer.Length * 2);
		foreach (byte b in buffer)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}

	public static string GetSha256(byte[] buffer)
	{
		using MemoryStream stream = new MemoryStream(buffer);
		return GetSha256(stream);
	}

	public static string GetSha256(string content, Encoding encoding = null)
	{
		encoding = encoding ?? Encoding.UTF8;
		using MemoryStream stream = new MemoryStream(encoding.GetBytes(content));
		return GetSha256(stream);
	}

	public static string GetSha256(FileInfo file)
	{
		if (!file.Exists)
		{
			throw new FileNotFoundException("File not found.", file.FullName);
		}
		using FileStream stream = file.OpenRead();
		return GetSha256(stream);
	}

	public static string GetSha256(Stream stream)
	{
		if (stream != null && stream.Length != 0L)
		{
			using (SHA256 sHA = SHA256.Create())
			{
				return ByteArrayToHex(sHA.ComputeHash(stream));
			}
		}
		throw new ArgumentException("You must provide a valid stream.", "stream");
	}

	public static string GetSha1(byte[] buffer)
	{
		using MemoryStream stream = new MemoryStream(buffer);
		return GetSha1(stream);
	}

	public static string GetSha1(string content, Encoding encoding = null)
	{
		encoding = encoding ?? Encoding.UTF8;
		using MemoryStream stream = new MemoryStream(encoding.GetBytes(content));
		return GetSha1(stream);
	}

	public static string GetSha1(FileInfo file)
	{
		if (!file.Exists)
		{
			throw new FileNotFoundException("File not found.", file.FullName);
		}
		using FileStream stream = file.OpenRead();
		return GetSha1(stream);
	}

	public static string GetSha1(Stream stream)
	{
		if (stream != null && stream.Length != 0L)
		{
			using (SHA1 sHA = SHA1.Create())
			{
				return ByteArrayToHex(sHA.ComputeHash(stream));
			}
		}
		throw new ArgumentException("You must provide a valid stream.", "stream");
	}
}
internal class MD5Helper
{
	private MD5Helper()
	{
	}

	public static uint RotateLeft(uint uiNumber, ushort shift)
	{
		return (uiNumber >> 32 - shift) | (uiNumber << (int)shift);
	}

	public static uint ReverseByte(uint uiNumber)
	{
		return ((uiNumber & 0xFF) << 24) | (uiNumber >> 24) | ((uiNumber & 0xFF0000) >> 8) | ((uiNumber & 0xFF00) << 8);
	}
}
