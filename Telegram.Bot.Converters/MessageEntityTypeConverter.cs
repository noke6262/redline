using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Converters;

internal class MessageEntityTypeConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		string text = ((MessageEntityType)value).smethod_1();
		writer.WriteValue(text);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		return Extensions.Value<string>((IEnumerable<JToken>)JToken.ReadFrom(reader)).smethod_0();
	}

	public override bool CanConvert(Type objectType)
	{
		return typeof(MessageEntityType) == objectType;
	}
}
