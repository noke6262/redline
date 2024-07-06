using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class CallbackQueryEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly object object_0;

	public CallbackQuery CallbackQuery
	{
		[CompilerGenerated]
		get
		{
			return (CallbackQuery)object_0;
		}
	}

	internal CallbackQueryEventArgs(Update update)
	{
		object_0 = update.CallbackQuery;
	}

	internal CallbackQueryEventArgs(CallbackQuery callbackQuery)
	{
		object_0 = callbackQuery;
	}

	public static implicit operator CallbackQueryEventArgs(UpdateEventArgs e)
	{
		return new CallbackQueryEventArgs(e.Update);
	}

	public static implicit operator string(CallbackQueryEventArgs e)
	{
		return e.CallbackQuery.Id;
	}
}
