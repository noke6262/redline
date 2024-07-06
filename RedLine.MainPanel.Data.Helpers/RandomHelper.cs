using System;

namespace RedLine.MainPanel.Data.Helpers;

public static class RandomHelper
{
	public static Random Randomizer = new Random();

	public static readonly string Characters = "qwertyuiopasdfghjklzxcvbnm" + "qwertyuiopasdfghjklzxcvbnm".ToUpper();

	public static string RandomString(int length)
	{
		string text = string.Empty;
		for (int i = 0; i < length; i++)
		{
			text += Characters[Randomizer.Next(0, Characters.Length - 1)];
		}
		return text;
	}
}
