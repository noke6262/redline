using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class VoiceChatScheduled
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public DateTime StartDate
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}
}
