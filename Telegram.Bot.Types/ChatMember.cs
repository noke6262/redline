using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ChatMember
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private ChatMemberStatus chatMemberStatus_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private DateTime? nullable_0;

	[CompilerGenerated]
	private bool? nullable_1;

	[CompilerGenerated]
	private bool? nullable_2;

	[CompilerGenerated]
	private bool? nullable_3;

	[CompilerGenerated]
	private bool? nullable_4;

	[CompilerGenerated]
	private bool? nullable_5;

	[CompilerGenerated]
	private bool? a;

	[CompilerGenerated]
	private bool? b;

	[CompilerGenerated]
	private bool? c;

	[CompilerGenerated]
	private bool? d;

	[CompilerGenerated]
	private bool? e;

	[CompilerGenerated]
	private bool? f;

	[CompilerGenerated]
	private bool? nullable_6;

	[CompilerGenerated]
	private bool? nullable_7;

	[CompilerGenerated]
	private bool? nullable_8;

	[CompilerGenerated]
	private bool? nullable_9;

	[CompilerGenerated]
	private bool? nullable_10;

	[CompilerGenerated]
	private bool? nullable_11;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public User User
	{
		[CompilerGenerated]
		get
		{
			return (User)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatMemberStatus Status
	{
		[CompilerGenerated]
		get
		{
			return chatMemberStatus_0;
		}
		[CompilerGenerated]
		set
		{
			chatMemberStatus_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string CustomTitle
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
	public bool IsAnonymous
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public DateTime? UntilDate
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanBeEdited
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanManageChat
	{
		[CompilerGenerated]
		get
		{
			return nullable_2;
		}
		[CompilerGenerated]
		set
		{
			nullable_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanChangeInfo
	{
		[CompilerGenerated]
		get
		{
			return nullable_3;
		}
		[CompilerGenerated]
		set
		{
			nullable_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanPostMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_4;
		}
		[CompilerGenerated]
		set
		{
			nullable_4 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanEditMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_5;
		}
		[CompilerGenerated]
		set
		{
			nullable_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanDeleteMessages
	{
		[CompilerGenerated]
		get
		{
			return a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanManageVoiceChats
	{
		[CompilerGenerated]
		get
		{
			return b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanInviteUsers
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
	public bool? CanRestrictMembers
	{
		[CompilerGenerated]
		get
		{
			return d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanPinMessages
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
	public bool? CanPromoteMembers
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
	public bool? IsMember
	{
		[CompilerGenerated]
		get
		{
			return nullable_6;
		}
		[CompilerGenerated]
		set
		{
			nullable_6 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanSendMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_7;
		}
		[CompilerGenerated]
		set
		{
			nullable_7 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanSendMediaMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_8;
		}
		[CompilerGenerated]
		set
		{
			nullable_8 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanSendPolls
	{
		[CompilerGenerated]
		get
		{
			return nullable_9;
		}
		[CompilerGenerated]
		set
		{
			nullable_9 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanSendOtherMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_10;
		}
		[CompilerGenerated]
		set
		{
			nullable_10 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanAddWebPagePreviews
	{
		[CompilerGenerated]
		get
		{
			return nullable_11;
		}
		[CompilerGenerated]
		set
		{
			nullable_11 = value;
		}
	}
}
