using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class PollAnswerEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public PollAnswer PollAnswer
	{
		[CompilerGenerated]
		get
		{
			return (PollAnswer)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal PollAnswerEventArgs(Update update)
	{
		PollAnswer = update.PollAnswer;
	}

	internal PollAnswerEventArgs(PollAnswer pollAnswer)
	{
		PollAnswer = pollAnswer;
	}

	public static implicit operator PollAnswerEventArgs(UpdateEventArgs e)
	{
		return new PollAnswerEventArgs(e.Update);
	}
}
