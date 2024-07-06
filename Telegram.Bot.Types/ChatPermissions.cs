using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ChatPermissions
{
	[CompilerGenerated]
	private bool? nullable_0;

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
	private bool? nullable_6;

	[CompilerGenerated]
	private bool? nullable_7;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanSendMessages
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
	public bool? CanSendMediaMessages
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
	public bool? CanSendPolls
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
	public bool? CanSendOtherMessages
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
	public bool? CanAddWebPagePreviews
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
	public bool? CanChangeInfo
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
	public bool? CanInviteUsers
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
	public bool? CanPinMessages
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
}
