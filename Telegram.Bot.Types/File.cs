using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class File : FileBase
{
	[CompilerGenerated]
	private object object_2;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string FilePath
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
}
