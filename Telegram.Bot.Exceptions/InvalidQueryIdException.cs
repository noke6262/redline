using System;

namespace Telegram.Bot.Exceptions;

[Obsolete("Description message for this error has changed and this exception type will never be thrown!")]
public class InvalidQueryIdException : InvalidParameterException
{
	public InvalidQueryIdException(string message)
		: base("inline_query_id", message)
	{
	}
}
