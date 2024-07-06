using System;

namespace RedLine.MainPanel.Data.Helpers;

public class MD5ChangedEventArgs : EventArgs
{
	public readonly byte[] NewData;

	public readonly string Value;

	public MD5ChangedEventArgs(byte[] data, string HashedValue)
	{
		byte[] array = new byte[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = data[i];
		}
		Value = HashedValue;
	}

	public MD5ChangedEventArgs(string data, string HashedValue)
	{
		byte[] array = new byte[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = (byte)data[i];
		}
		Value = HashedValue;
	}
}
