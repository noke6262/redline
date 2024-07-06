namespace Telegram.Bot.Exceptions;

public class InvalidUserIdException : InvalidParameterException
{
	public InvalidUserIdException(string message)
		: base("user_id", message)
	{
	}
}
