using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class KeyboardButtonPollType
{
	[CompilerGenerated]
	private object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Type
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
}
