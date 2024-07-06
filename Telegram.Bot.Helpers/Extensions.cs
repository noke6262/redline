using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Helpers;

public static class Extensions
{
	private static readonly DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public static DateTime FromUnixTime(this long unixTime)
	{
		return dateTime_0.AddSeconds(unixTime);
	}

	public static long ToUnixTime(this DateTime dateTime)
	{
		if (dateTime == DateTime.MinValue)
		{
			return 0L;
		}
		double totalSeconds = (dateTime.ToUniversalTime() - dateTime_0).TotalSeconds;
		if (totalSeconds < 0.0)
		{
			throw new ArgumentOutOfRangeException("dateTime", "Unix epoch starts January 1st, 1970");
		}
		return Convert.ToInt64(totalSeconds);
	}

	internal static string smethod_0(this string value)
	{
		return string.Join(string.Empty, Encoding.UTF8.GetBytes(value).Select(Convert.ToChar));
	}

	internal static void smethod_1(this MultipartFormDataContent multipartContent, Stream content, string name, string fileName = null)
	{
		fileName = fileName ?? name;
		string value = ("form-data; name=\"" + name + "\"; filename=\"" + fileName + "\"").smethod_0();
		HttpContent content2 = new StreamContent(content)
		{
			Headers = 
			{
				{ "Content-Type", "application/octet-stream" },
				{ "Content-Disposition", value }
			}
		};
		multipartContent.Add(content2, name, fileName);
	}

	internal static void smethod_2(this MultipartFormDataContent multipartContent, params IInputMedia[] inputMedia)
	{
		foreach (IInputMedia inputMedia2 in inputMedia)
		{
			if (inputMedia2.Media.FileType == FileType.Stream)
			{
				multipartContent.smethod_1(inputMedia2.Media.Content, inputMedia2.Media.FileName);
			}
			InputMedia inputMedia3 = (inputMedia2 as IInputMediaThumb)?.Thumb;
			if (inputMedia3 != null && inputMedia3.FileType == FileType.Stream)
			{
				multipartContent.smethod_1(inputMedia3.Content, inputMedia3.FileName);
			}
		}
	}
}
