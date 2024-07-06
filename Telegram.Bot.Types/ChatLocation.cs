using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ChatLocation
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Location Location
	{
		[CompilerGenerated]
		get
		{
			return (Location)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Address
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
