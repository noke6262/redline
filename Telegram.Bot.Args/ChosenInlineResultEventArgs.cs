using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class ChosenInlineResultEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public ChosenInlineResult ChosenInlineResult
	{
		[CompilerGenerated]
		get
		{
			return (ChosenInlineResult)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal ChosenInlineResultEventArgs(Update update)
	{
		ChosenInlineResult = update.ChosenInlineResult;
	}

	internal ChosenInlineResultEventArgs(ChosenInlineResult chosenInlineResult)
	{
		ChosenInlineResult = chosenInlineResult;
	}

	public static implicit operator ChosenInlineResultEventArgs(UpdateEventArgs e)
	{
		return new ChosenInlineResultEventArgs(e.Update);
	}
}
