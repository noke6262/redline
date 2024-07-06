using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Exceptions;

namespace Telegram.Bot.Args;

public class ReceiveErrorEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public ApiRequestException ApiRequestException
	{
		[CompilerGenerated]
		get
		{
			return (ApiRequestException)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal ReceiveErrorEventArgs(ApiRequestException apiRequestException)
	{
		ApiRequestException = apiRequestException;
	}

	public static implicit operator ReceiveErrorEventArgs(ApiRequestException e)
	{
		return new ReceiveErrorEventArgs(e);
	}
}
