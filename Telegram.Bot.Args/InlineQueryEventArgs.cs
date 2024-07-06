using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class InlineQueryEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public InlineQuery InlineQuery
	{
		[CompilerGenerated]
		get
		{
			return (InlineQuery)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal InlineQueryEventArgs(Update update)
	{
		InlineQuery = update.InlineQuery;
	}

	internal InlineQueryEventArgs(InlineQuery inlineQuery)
	{
		InlineQuery = inlineQuery;
	}

	public static implicit operator InlineQueryEventArgs(UpdateEventArgs e)
	{
		return new InlineQueryEventArgs(e.Update);
	}
}
