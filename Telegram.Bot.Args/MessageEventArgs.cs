using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Args;

public class MessageEventArgs : EventArgs
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

	internal MessageEventArgs(Update update)
	{
		Message = ((update.Type == UpdateType.EditedMessage) ? update.EditedMessage : update.Message);
	}

	internal MessageEventArgs(Message message)
	{
		Message = message;
	}

	public static implicit operator MessageEventArgs(UpdateEventArgs e)
	{
		return new MessageEventArgs(e.Update);
	}
}
