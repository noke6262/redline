using System;

namespace Telegram.Bot.Exceptions;

internal class BadRequestExceptionInfo<T> : IApiExceptionInfo<T> where T : ApiRequestException
{
	public int ErrorCode => 400;

	public string ErrorMessageRegex { get; }

	public Type Type => typeof(T);

	public BadRequestExceptionInfo(string errorMessageRegex)
	{
		ErrorMessageRegex = errorMessageRegex;
	}
}
