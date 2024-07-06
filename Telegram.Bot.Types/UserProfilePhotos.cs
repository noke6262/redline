using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class UserProfilePhotos
{
	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int TotalCount
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PhotoSize[][] Photos
	{
		[CompilerGenerated]
		get
		{
			return (PhotoSize[][])object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}
}
