using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class InputMediaConverter : InputFileConverter
{
	public override bool CanConvert(Type objectType)
	{
		return typeof(InputMedia) == objectType;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		InputMedia inputMedia = (InputMedia)value;
		switch (inputMedia.FileType)
		{
		default:
			throw new NotSupportedException("File Type not supported");
		case FileType.Id:
		case FileType.Url:
			base.WriteJson(writer, value, serializer);
			break;
		case FileType.Stream:
			writer.WriteValue("attach://" + inputMedia.FileName);
			break;
		}
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		string text = Extensions.Value<string>((IEnumerable<JToken>)JToken.ReadFrom(reader));
		if (text != null && text.StartsWith("attach://"))
		{
			return new InputMedia(Stream.Null, text.Substring(9));
		}
		return new InputMedia(text);
	}
}
