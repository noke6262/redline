using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ChatMemberUpdated
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private object object_4;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Chat Chat
	{
		[CompilerGenerated]
		get
		{
			return (Chat)object_0;
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

	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public DateTime Date
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatMember OldChatMember
	{
		[CompilerGenerated]
		get
		{
			return (ChatMember)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatMember NewChatMember
	{
		[CompilerGenerated]
		get
		{
			return (ChatMember)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatInviteLink InviteLink
	{
		[CompilerGenerated]
		get
		{
			return (ChatInviteLink)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}
}
