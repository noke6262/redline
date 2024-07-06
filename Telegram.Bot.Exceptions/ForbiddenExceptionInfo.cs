using System;

namespace Telegram.Bot.Exceptions;

internal class ForbiddenExceptionInfo<T> : IApiExceptionInfo<T> where T : ApiRequestException
{
	public int ErrorCode => 403;

	public string ErrorMessageRegex { get; }

	public Type Type => typeof(T);

	public ForbiddenExceptionInfo(string errorMessageRegex)
	{
		ErrorMessageRegex = errorMessageRegex;
	}
}
