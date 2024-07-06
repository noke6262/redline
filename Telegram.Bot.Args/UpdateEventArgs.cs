using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Args;

public class UpdateEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public Update Update
	{
		[CompilerGenerated]
		get
		{
			return (Update)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal UpdateEventArgs(Update update)
	{
		Update = update;
	}
}
