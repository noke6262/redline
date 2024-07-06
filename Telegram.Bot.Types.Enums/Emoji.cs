using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Emoji
{
	[EnumMember(Value = "\ud83c\udfb2")]
	Dice,
	[EnumMember(Value = "\ud83c\udfaf")]
	Darts,
	[EnumMember(Value = "\ud83c\udfc0")]
	Basketball,
	[EnumMember(Value = "⚽")]
	Football,
	[EnumMember(Value = "\ud83c\udfb0")]
	SlotMachine,
	[EnumMember(Value = "\ud83c\udfb3")]
	Bowling
}
