using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class Chat
{
	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private ChatType chatType_0;

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

	[CompilerGenerated]
	private object object_7;

	[CompilerGenerated]
	private object a;

	[CompilerGenerated]
	private object b;

	[CompilerGenerated]
	private int? c;

	[CompilerGenerated]
	private object d;

	[CompilerGenerated]
	private bool? e;

	[CompilerGenerated]
	private long f;

	[CompilerGenerated]
	private object object_8;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public long Id
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatType Type
	{
		[CompilerGenerated]
		get
		{
			return chatType_0;
		}
		[CompilerGenerated]
		set
		{
			chatType_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Title
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
	public string Username
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string FirstName
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
	public string LastName
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
	public ChatPhoto Photo
	{
		[CompilerGenerated]
		get
		{
			return (ChatPhoto)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Bio
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
	public string Description
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string InviteLink
	{
		[CompilerGenerated]
		get
		{
			return (string)object_7;
		}
		[CompilerGenerated]
		set
		{
			object_7 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Message PinnedMessage
	{
		[CompilerGenerated]
		get
		{
			return (Message)a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatPermissions Permissions
	{
		[CompilerGenerated]
		get
		{
			return (ChatPermissions)b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int? SlowModeDelay
	{
		[CompilerGenerated]
		get
		{
			return c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string StickerSetName
	{
		[CompilerGenerated]
		get
		{
			return (string)d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanSetStickerSet
	{
		[CompilerGenerated]
		get
		{
			return e;
		}
		[CompilerGenerated]
		set
		{
			e = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public long LinkedChatId
	{
		[CompilerGenerated]
		get
		{
			return f;
		}
		[CompilerGenerated]
		set
		{
			f = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatLocation Location
	{
		[CompilerGenerated]
		get
		{
			return (ChatLocation)object_8;
		}
		[CompilerGenerated]
		set
		{
			object_8 = value;
		}
	}
}
