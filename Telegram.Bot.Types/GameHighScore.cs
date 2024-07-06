using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class GameHighScore
{
	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Position
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
	public User User
	{
		[CompilerGenerated]
		get
		{
			return (User)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Score
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_1;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)value;
		}
	}
}
