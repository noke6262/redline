using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Args;

public class ApiRequestEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	public string MethodName
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		internal set
		{
			object_0 = value;
		}
	}

	public HttpContent HttpContent
	{
		[CompilerGenerated]
		get
		{
			return (HttpContent)object_1;
		}
		[CompilerGenerated]
		internal set
		{
			object_1 = value;
		}
	}
}
