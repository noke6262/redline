using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class InlineQueryResultVoice : InlineQueryResultBase, ICaptionInlineQueryResult, IInputMessageContentResult, ITitleInlineQueryResult
{
	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_4;

	[CompilerGenerated]
	private ParseMode parseMode_0;

	[CompilerGenerated]
	private object object_5;

	[CompilerGenerated]
	private object object_6;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string VoiceUrl
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
	public string Title
	{
		[CompilerGenerated]
		get
		{
			return (string)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int VoiceDuration
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Caption
	{
		[CompilerGenerated]
		get
		{
			return (string)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
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
			return (MessageEntity[])object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InputMessageContentBase InputMessageContent
	{
		[CompilerGenerated]
		get
		{
			return (InputMessageContentBase)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	public InlineQueryResultVoice()
		: base(InlineQueryResultType.Voice)
	{
	}

	public InlineQueryResultVoice(string id, string voiceUrl, string title)
		: base(InlineQueryResultType.Voice, id)
	{
		VoiceUrl = voiceUrl;
		Title = title;
	}
}
