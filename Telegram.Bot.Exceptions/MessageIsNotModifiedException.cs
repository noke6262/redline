namespace Telegram.Bot.Exceptions;

public class MessageIsNotModifiedException : BadRequestException
{
	public MessageIsNotModifiedException(string message)
		: base(message)
	{
	}
}
