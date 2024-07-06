using System.Runtime.Serialization;
using Newtonsoft.Json;
using Telegram.Bot.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(MessageEntityTypeConverter))]
public enum MessageEntityType
{
	[EnumMember(Value = "mention")]
	Mention,
	[EnumMember(Value = "hashtag")]
	Hashtag,
	[EnumMember(Value = "bot_command")]
	BotCommand,
	[EnumMember(Value = "url")]
	Url,
	[EnumMember(Value = "email")]
	Email,
	[EnumMember(Value = "bold")]
	Bold,
	[EnumMember(Value = "italic")]
	Italic,
	[EnumMember(Value = "code")]
	Code,
	[EnumMember(Value = "pre")]
	Pre,
	[EnumMember(Value = "text_link")]
	TextLink,
	[EnumMember(Value = "text_mention")]
	TextMention,
	[EnumMember(Value = "phone_number")]
	PhoneNumber,
	[EnumMember(Value = "cashtag")]
	Cashtag,
	[EnumMember(Value = "unknown")]
	Unknown,
	[EnumMember(Value = "underline")]
	Underline,
	[EnumMember(Value = "strikethrough")]
	Strikethrough
}
