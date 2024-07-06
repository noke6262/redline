using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum InlineQueryResultType
{
	[EnumMember(Value = "unknown")]
	Unknown,
	[EnumMember(Value = "article")]
	Article,
	[EnumMember(Value = "photo")]
	Photo,
	[EnumMember(Value = "gif")]
	Gif,
	[EnumMember(Value = "mpeg4_gif")]
	Mpeg4Gif,
	[EnumMember(Value = "video")]
	Video,
	[EnumMember(Value = "audio")]
	Audio,
	[EnumMember(Value = "contact")]
	Contact,
	[EnumMember(Value = "document")]
	Document,
	[EnumMember(Value = "location")]
	Location,
	[EnumMember(Value = "venue")]
	Venue,
	[EnumMember(Value = "voice")]
	Voice,
	[EnumMember(Value = "game")]
	Game,
	[EnumMember(Value = "sticker")]
	Sticker
}
