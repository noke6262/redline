using System.IO;
using Newtonsoft.Json;
using Telegram.Bot.Converters;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Types;

[JsonConverter(typeof(InputMediaConverter))]
public class InputMedia : InputOnlineFile
{
	public InputMedia(Stream content, string fileName)
		: base(content, fileName)
	{
	}

	public InputMedia(string value)
		: base(value)
	{
	}

	public static implicit operator InputMedia(string value)
	{
		if (value != null)
		{
			return new InputMedia(value);
		}
		return null;
	}
}
