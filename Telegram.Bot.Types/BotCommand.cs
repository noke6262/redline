using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class BotCommand
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Command
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Description
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}
}
