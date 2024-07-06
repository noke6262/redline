using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types.Enums;

[JsonConverter(typeof(StringEnumConverter), new object[] { true })]
public enum ChatAction
{
	[EnumMember(Value = "typing")]
	Typing,
	[EnumMember(Value = "upload_photo")]
	UploadPhoto,
	[EnumMember(Value = "record_video")]
	RecordVideo,
	[EnumMember(Value = "upload_video")]
	UploadVideo,
	[EnumMember(Value = "record_voice")]
	RecordVoice,
	[EnumMember(Value = "upload_voice")]
	UploadVoice,
	[EnumMember(Value = "upload_document")]
	UploadDocument,
	[EnumMember(Value = "find_location")]
	FindLocation,
	[EnumMember(Value = "record_video_note")]
	RecordVideoNote,
	[EnumMember(Value = "upload_video_note")]
	UploadVideoNote
}
