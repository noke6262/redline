using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Args;

public class ChannelPostEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public Message Message
	{
		[CompilerGenerated]
		get
		{
			return (Message)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal ChannelPostEventArgs(Update update)
	{
		Message = ((update.Type == UpdateType.EditedChannelPost) ? update.EditedChannelPost : update.ChannelPost);
	}

	internal ChannelPostEventArgs(Message message)
	{
		Message = message;
	}

	public static implicit operator ChannelPostEventArgs(UpdateEventArgs e)
	{
		return new ChannelPostEventArgs(e.Update);
	}
}
