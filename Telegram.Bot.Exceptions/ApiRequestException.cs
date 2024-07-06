using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace Telegram.Bot.Exceptions;

public class ApiRequestException : Exception
{
	[CompilerGenerated]
	private readonly IntPtr intptr_0;

	[CompilerGenerated]
	private readonly object object_0;

	public virtual int Telegram_002EBot_002EExceptions_002EApiRequestException_002EErrorCode
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
	}

	public ResponseParameters Parameters
	{
		[CompilerGenerated]
		get
		{
			return (ResponseParameters)object_0;
		}
	}

	public ApiRequestException(string message)
		: base(message)
	{
	}

	public ApiRequestException(string message, int errorCode)
		: base(message)
	{
		intptr_0 = (IntPtr)errorCode;
	}

	public ApiRequestException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public ApiRequestException(string message, int errorCode, Exception innerException)
		: base(message, innerException)
	{
		intptr_0 = (IntPtr)errorCode;
	}

	public ApiRequestException(string message, int errorCode, ResponseParameters parameters)
		: base(message)
	{
		intptr_0 = (IntPtr)errorCode;
		object_0 = parameters;
	}

	public ApiRequestException(string message, int errorCode, ResponseParameters parameters, Exception innerException)
		: base(message, innerException)
	{
		intptr_0 = (IntPtr)errorCode;
		object_0 = parameters;
	}

	public static ApiRequestException FromApiResponse<T>(ApiResponse<T> apiResponse)
	{
		return ApiExceptionParser.Parse(apiResponse);
	}
}
