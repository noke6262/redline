using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Args;

public class ApiResponseEventArgs
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	public HttpResponseMessage ResponseMessage
	{
		[CompilerGenerated]
		get
		{
			return (HttpResponseMessage)object_0;
		}
		[CompilerGenerated]
		internal set
		{
			object_0 = value;
		}
	}

	public ApiRequestEventArgs ApiRequestEventArgs
	{
		[CompilerGenerated]
		get
		{
			return (ApiRequestEventArgs)object_1;
		}
		[CompilerGenerated]
		internal set
		{
			object_1 = value;
		}
	}
}
