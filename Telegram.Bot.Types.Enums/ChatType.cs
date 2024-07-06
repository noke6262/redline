using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum ChatType
{
	[EnumMember(Value = "private")]
	Private,
	[EnumMember(Value = "group")]
	Group,
	[EnumMember(Value = "channel")]
	Channel,
	[EnumMember(Value = "supergroup")]
	Supergroup
}
