using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class ChatMemberUpdatedEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public ChatMemberUpdated ChatMemberUpdated
	{
		[CompilerGenerated]
		get
		{
			return (ChatMemberUpdated)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal ChatMemberUpdatedEventArgs(Update update)
	{
		ChatMemberUpdated = update.ChatMemberUpdated;
	}

	internal ChatMemberUpdatedEventArgs(ChatMemberUpdated chatMemberUpdated)
	{
		ChatMemberUpdated = chatMemberUpdated;
	}

	public static implicit operator ChatMemberUpdatedEventArgs(UpdateEventArgs e)
	{
		return new ChatMemberUpdatedEventArgs(e.Update);
	}
}
