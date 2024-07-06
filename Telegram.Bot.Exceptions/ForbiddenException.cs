using System;
using Telegram.Bot.Types;

namespace Telegram.Bot.Exceptions;

public abstract class ForbiddenException : ApiRequestException
{
	public const int ForbiddenErrorCode = 403;

	public const string ForbiddenErrorDescription = "";

	public override int Telegram_002EBot_002EExceptions_002EApiRequestException_002EErrorCode => 403;

	protected ForbiddenException(string message)
		: base(message, 403)
	{
	}

	protected ForbiddenException(string message, Exception innerException)
		: base(message, 403, innerException)
	{
	}

	protected ForbiddenException(string message, ResponseParameters parameters)
		: base(message, 403, parameters)
	{
	}

	protected ForbiddenException(string message, ResponseParameters parameters, Exception innerException)
		: base(message, 403, parameters, innerException)
	{
	}
}
