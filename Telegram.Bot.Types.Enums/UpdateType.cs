using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum UpdateType
{
	[EnumMember(Value = "unknown")]
	Unknown,
	[EnumMember(Value = "message")]
	Message,
	[EnumMember(Value = "inline_query")]
	InlineQuery,
	[EnumMember(Value = "chosen_inline_result")]
	ChosenInlineResult,
	[EnumMember(Value = "callback_query")]
	CallbackQuery,
	[EnumMember(Value = "edited_message")]
	EditedMessage,
	[EnumMember(Value = "channel_post")]
	ChannelPost,
	[EnumMember(Value = "edited_channel_post")]
	EditedChannelPost,
	[EnumMember(Value = "shipping_query")]
	ShippingQuery,
	[EnumMember(Value = "pre_checkout_query")]
	PreCheckoutQuery,
	[EnumMember(Value = "poll")]
	Poll,
	[EnumMember(Value = "poll_answer")]
	PollAnswer,
	[EnumMember(Value = "my_chat_member")]
	MyChatMemberUpdated,
	[EnumMember(Value = "chat_member")]
	ChatMemberUpdated
}
