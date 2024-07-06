using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum MessageType
{
	[EnumMember(Value = "unknown")]
	Unknown,
	[EnumMember(Value = "text")]
	Text,
	[EnumMember(Value = "photo")]
	Photo,
	[EnumMember(Value = "audio")]
	Audio,
	[EnumMember(Value = "video")]
	Video,
	[EnumMember(Value = "voice")]
	Voice,
	[EnumMember(Value = "document")]
	Document,
	[EnumMember(Value = "sticker")]
	Sticker,
	[EnumMember(Value = "location")]
	Location,
	[EnumMember(Value = "contact")]
	Contact,
	[EnumMember(Value = "venue")]
	Venue,
	[EnumMember(Value = "game")]
	Game,
	[EnumMember(Value = "video_note")]
	VideoNote,
	[EnumMember(Value = "invoice")]
	Invoice,
	[EnumMember(Value = "successful_payment")]
	SuccessfulPayment,
	[EnumMember(Value = "proximity_alert_triggered")]
	ProximityAlertTriggered,
	[EnumMember(Value = "voice_chat_scheduled")]
	VoiceChatScheduled,
	[EnumMember(Value = "voice_chat_started")]
	VoiceChatStarted,
	[EnumMember(Value = "voice_chat_ended")]
	VoiceChatEnded,
	[EnumMember(Value = "voice_chat_participants_invited")]
	VoiceChatParticipantsInvited,
	[EnumMember(Value = "website_connected")]
	WebsiteConnected,
	[EnumMember(Value = "chat_members_added")]
	ChatMembersAdded,
	[EnumMember(Value = "chat_member_left")]
	ChatMemberLeft,
	[EnumMember(Value = "chat_title_changed")]
	ChatTitleChanged,
	[EnumMember(Value = "chat_photo_changed")]
	ChatPhotoChanged,
	[EnumMember(Value = "message_pinned")]
	MessagePinned,
	[EnumMember(Value = "chat_photo_deleted")]
	ChatPhotoDeleted,
	[EnumMember(Value = "group_created")]
	GroupCreated,
	[EnumMember(Value = "supergroup_created")]
	SupergroupCreated,
	[EnumMember(Value = "channel_created")]
	ChannelCreated,
	[EnumMember(Value = "message_auto_delete_timer_changed")]
	MessageAutoDeleteTimerChanged,
	[EnumMember(Value = "migrated_to_supergroup")]
	MigratedToSupergroup,
	[EnumMember(Value = "migrated_from_group")]
	MigratedFromGroup,
	[EnumMember(Value = "animation")]
	Animation,
	[EnumMember(Value = "poll")]
	Poll,
	[EnumMember(Value = "dice")]
	Dice
}
