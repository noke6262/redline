using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types;

namespace Telegram.Bot.Converters;

internal class ChatIdConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		ChatId chatId = (ChatId)value;
		if (chatId.Username != null)
		{
			writer.WriteValue(chatId.Username);
		}
		else
		{
			writer.WriteValue(chatId.Identifier);
		}
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		return new ChatId(Extensions.Value<string>((IEnumerable<JToken>)JToken.ReadFrom(reader)));
	}

	public override bool CanConvert(Type objectType)
	{
		return typeof(ChatId) == objectType;
	}
}
