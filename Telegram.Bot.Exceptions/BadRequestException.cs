using System;
using Telegram.Bot.Types;

namespace Telegram.Bot.Exceptions;

public abstract class BadRequestException : ApiRequestException
{
	public const int BadRequestErrorCode = 400;

	public const string BadRequestErrorDescription = "";

	public override int Telegram_002EBot_002EExceptions_002EApiRequestException_002EErrorCode => 400;

	protected BadRequestException(string message)
		: base(message, 400)
	{
	}

	protected BadRequestException(string message, Exception innerException)
		: base(message, 400, innerException)
	{
	}

	protected BadRequestException(string message, ResponseParameters parameters)
		: base(message, 400, parameters)
	{
	}

	protected BadRequestException(string message, ResponseParameters parameters, Exception innerException)
		: base(message, 400, parameters, innerException)
	{
	}
}
