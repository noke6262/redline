using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class PollEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public Poll Poll
	{
		[CompilerGenerated]
		get
		{
			return (Poll)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal PollEventArgs(Update update)
	{
		Poll = update.Poll;
	}

	internal PollEventArgs(Poll poll)
	{
		Poll = poll;
	}

	public static implicit operator PollEventArgs(UpdateEventArgs e)
	{
		return new PollEventArgs(e.Update);
	}
}
