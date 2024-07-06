using System;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Args;

public class ReceiveGeneralErrorEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly object object_0;

	public Exception Exception
	{
		[CompilerGenerated]
		get
		{
			return (Exception)object_0;
		}
	}

	internal ReceiveGeneralErrorEventArgs(Exception exception)
	{
		object_0 = exception;
	}

	public static implicit operator ReceiveGeneralErrorEventArgs(Exception e)
	{
		return new ReceiveGeneralErrorEventArgs(e);
	}
}
