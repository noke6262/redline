using System.Runtime.CompilerServices;

namespace Telegram.Bot.Exceptions;

public class InvalidParameterException : BadRequestException
{
	internal const string string_0 = "";

	[CompilerGenerated]
	private readonly object object_1;

	public string Parameter
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
	}

	public InvalidParameterException(string paramName, string message)
		: base(message)
	{
		object_1 = paramName;
	}

	public InvalidParameterException(string paramName)
		: base(paramName)
	{
		object_1 = paramName;
	}
}
