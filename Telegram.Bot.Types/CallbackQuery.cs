using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class CallbackQuery
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private object object_4;

	[CompilerGenerated]
	private object object_5;

	[CompilerGenerated]
	private object object_6;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Id
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
	public User From
	{
		[CompilerGenerated]
		get
		{
			return (User)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Message Message
	{
		[CompilerGenerated]
		get
		{
			return (Message)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string InlineMessageId
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
	public string ChatInstance
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
	public string Data
	{
		[CompilerGenerated]
		get
		{
			return (string)object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string GameShortName
	{
		[CompilerGenerated]
		get
		{
			return (string)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	public bool IsGameQuery => GameShortName != null;

	public static implicit operator string(CallbackQuery e)
	{
		return e.Id;
	}
}
