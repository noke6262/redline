using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(/*Could not decode attribute arguments.*/)]
public abstract class InlineQueryResultBase
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private InlineQueryResultType inlineQueryResultType_0;

	[CompilerGenerated]
	private object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Id
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InlineQueryResultType Type
	{
		[CompilerGenerated]
		get
		{
			return inlineQueryResultType_0;
		}
		[CompilerGenerated]
		private set
		{
			inlineQueryResultType_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InlineKeyboardMarkup ReplyMarkup
	{
		[CompilerGenerated]
		get
		{
			return (InlineKeyboardMarkup)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	protected InlineQueryResultBase(InlineQueryResultType type)
	{
		Type = type;
	}

	protected InlineQueryResultBase(InlineQueryResultType type, string id)
		: this(type)
	{
		Id = id;
	}
}
