using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class InlineQueryResultGame : InlineQueryResultBase
{
	[CompilerGenerated]
	private object object_2;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string GameShortName
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

	private InlineQueryResultGame()
		: base(InlineQueryResultType.Game)
	{
	}

	public InlineQueryResultGame(string id, string gameShortName)
		: base(InlineQueryResultType.Game, id)
	{
		GameShortName = gameShortName;
	}
}
