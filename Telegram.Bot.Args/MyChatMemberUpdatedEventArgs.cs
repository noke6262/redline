using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class MyChatMemberUpdatedEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public ChatMemberUpdated MyChatMemberUpdated
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

	internal MyChatMemberUpdatedEventArgs(Update update)
	{
		MyChatMemberUpdated = update.MyChatMemberUpdated;
	}

	internal MyChatMemberUpdatedEventArgs(ChatMemberUpdated myChatMemberUpdated)
	{
		MyChatMemberUpdated = myChatMemberUpdated;
	}

	public static implicit operator MyChatMemberUpdatedEventArgs(UpdateEventArgs e)
	{
		return new MyChatMemberUpdatedEventArgs(e.Update);
	}
}
