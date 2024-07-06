using System;

namespace Telegram.Bot.Exceptions;

internal interface IApiExceptionInfo<out T> where T : ApiRequestException
{
	int ErrorCode { get; }

	string ErrorMessageRegex { get; }

	Type Type { get; }
}
