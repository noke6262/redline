using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class InlineQueryResultCachedSticker : InlineQueryResultBase, IInputMessageContentResult
{
	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string StickerFileId
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
	public InputMessageContentBase InputMessageContent
	{
		[CompilerGenerated]
		get
		{
			return (InputMessageContentBase)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	private InlineQueryResultCachedSticker()
		: base(InlineQueryResultType.Sticker)
	{
	}

	public InlineQueryResultCachedSticker(string id, string stickerFileId)
		: base(InlineQueryResultType.Sticker, id)
	{
		StickerFileId = stickerFileId;
	}
}
