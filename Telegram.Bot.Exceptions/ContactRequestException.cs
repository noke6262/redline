using System;

namespace Telegram.Bot.Exceptions;

[Obsolete("Description message for this error has changed and this exception type will never be thrown.")]
public class ContactRequestException : BadRequestException
{
	public ContactRequestException(string message)
		: base(message)
	{
	}
}
