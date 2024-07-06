using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum PollType
{
	[EnumMember(Value = "regular")]
	Regular,
	[EnumMember(Value = "quiz")]
	Quiz
}
