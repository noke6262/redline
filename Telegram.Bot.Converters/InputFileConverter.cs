using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Telegram.Bot.Converters;

internal class InputFileConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType.GetTypeInfo().IsSubclassOf(typeof(InputFileStream));
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		switch ((int)((IInputFile)value).FileType)
		{
		case 0:
			writer.WriteValue((object)null);
			break;
		case 1:
			if (value is InputTelegramFile inputTelegramFile)
			{
				writer.WriteValue(inputTelegramFile.FileId);
				break;
			}
			goto default;
		case 2:
			if (value is InputOnlineFile inputOnlineFile)
			{
				writer.WriteValue(inputOnlineFile.Url);
				break;
			}
			goto default;
		default:
			throw new NotSupportedException("File Type is not supported");
		}
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		string text = Extensions.Value<string>((IEnumerable<JToken>)JToken.ReadFrom(reader));
		if (text != null)
		{
			if (Uri.TryCreate(text, UriKind.Absolute, out var _))
			{
				return new InputOnlineFile(text);
			}
			return new InputTelegramFile(text);
		}
		return new InputFileStream(Stream.Null);
	}
}
