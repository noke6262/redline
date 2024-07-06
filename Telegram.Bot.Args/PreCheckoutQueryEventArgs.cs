using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;

namespace Telegram.Bot.Args;

public class PreCheckoutQueryEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public PreCheckoutQuery PreCheckoutQuery
	{
		[CompilerGenerated]
		get
		{
			return (PreCheckoutQuery)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal PreCheckoutQueryEventArgs(Update update)
	{
		PreCheckoutQuery = update.PreCheckoutQuery;
	}

	internal PreCheckoutQueryEventArgs(PreCheckoutQuery preCheckoutQuery)
	{
		PreCheckoutQuery = preCheckoutQuery;
	}

	public static implicit operator PreCheckoutQueryEventArgs(UpdateEventArgs e)
	{
		return new PreCheckoutQueryEventArgs(e.Update);
	}
}
