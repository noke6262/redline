using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class Audio : FileBase
{
	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private object object_4;

	[CompilerGenerated]
	private object object_5;

	[CompilerGenerated]
	private object object_6;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Duration
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Performer
	{
		[CompilerGenerated]
		get
		{
			return (string)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Title
	{
		[CompilerGenerated]
		get
		{
			return (string)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string FileName
	{
		[CompilerGenerated]
		get
		{
			return (string)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string MimeType
	{
		[CompilerGenerated]
		get
		{
			return (string)object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PhotoSize Thumb
	{
		[CompilerGenerated]
		get
		{
			return (PhotoSize)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}
}
