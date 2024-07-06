using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum MaskPositionPoint
{
	[EnumMember(Value = "forehead")]
	Forehead,
	[EnumMember(Value = "eyes")]
	Eyes,
	[EnumMember(Value = "mouth")]
	Mouth,
	[EnumMember(Value = "chin")]
	Chin
}
