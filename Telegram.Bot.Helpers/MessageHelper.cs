using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Telegram.Bot.Helpers;

public static class MessageHelper
{
	private const int int_0 = 4096;

	public static List<string> Split(string text)
	{
		List<string> list = new List<string>();
		if (Regex.Replace(text, "<[^>]*>", "").Length <= 4096)
		{
			list.Add(text);
			return list;
		}
		while (text.Length > 0)
		{
			if (text.Length > 4096)
			{
				string text2 = text.Substring(0, 4096);
				int num = text2.LastIndexOf("\n");
				if (num != -1)
				{
					list.Add(text2.Substring(0, num));
					text = text.Substring(num);
				}
				else
				{
					list.Add(text2);
					text = text.Substring(4096);
				}
				continue;
			}
			list.Add(text);
			break;
		}
		return list;
	}
}
