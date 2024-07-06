using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class AlbumInputMedia : IAlbumInputMedia, IInputMedia
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private ParseMode parseMode_0;

	[CompilerGenerated]
	private object object_3;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Type
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		protected set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InputMedia Media
	{
		[CompilerGenerated]
		get
		{
			return (InputMedia)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Caption
	{
		[CompilerGenerated]
		get
		{
			return (string)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ParseMode ParseMode
	{
		[CompilerGenerated]
		get
		{
			return parseMode_0;
		}
		[CompilerGenerated]
		set
		{
			parseMode_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public MessageEntity[] CaptionEntities
	{
		[CompilerGenerated]
		get
		{
			return (MessageEntity[])object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	public AlbumInputMedia()
	{
	}

	public static implicit operator AlbumInputMedia(InputMediaDocument document)
	{
		return new AlbumInputMedia
		{
			Type = document.Type,
			Media = document.Media,
			Caption = document.Caption,
			ParseMode = document.ParseMode,
			CaptionEntities = document.CaptionEntities
		};
	}

	public static implicit operator AlbumInputMedia(InputMediaVideo video)
	{
		return new AlbumInputMedia
		{
			Type = video.Type,
			Media = video.Media,
			Caption = video.Caption,
			ParseMode = video.ParseMode,
			CaptionEntities = video.CaptionEntities
		};
	}

	public static implicit operator AlbumInputMedia(InputMediaPhoto photo)
	{
		return new AlbumInputMedia
		{
			Type = photo.Type,
			Media = photo.Media,
			Caption = photo.Caption,
			ParseMode = photo.ParseMode,
			CaptionEntities = photo.CaptionEntities
		};
	}

	public static implicit operator AlbumInputMedia(InputMediaAudio audio)
	{
		return new AlbumInputMedia
		{
			Type = audio.Type,
			Media = audio.Media,
			Caption = audio.Caption,
			ParseMode = audio.ParseMode,
			CaptionEntities = audio.CaptionEntities
		};
	}

	public AlbumInputMedia(InputMediaDocument document)
	{
		Type = document.Type;
		Media = document.Media;
		Caption = document.Caption;
		ParseMode = document.ParseMode;
		CaptionEntities = document.CaptionEntities;
	}

	public AlbumInputMedia(InputMediaVideo video)
	{
		Type = video.Type;
		Media = video.Media;
		Caption = video.Caption;
		ParseMode = video.ParseMode;
		CaptionEntities = video.CaptionEntities;
	}

	public AlbumInputMedia(InputMediaPhoto photo)
	{
		Type = photo.Type;
		Media = photo.Media;
		Caption = photo.Caption;
		ParseMode = photo.ParseMode;
		CaptionEntities = photo.CaptionEntities;
	}

	public AlbumInputMedia(InputMediaAudio audio)
	{
		Type = audio.Type;
		Media = audio.Media;
		Caption = audio.Caption;
		ParseMode = audio.ParseMode;
		CaptionEntities = audio.CaptionEntities;
	}
}
