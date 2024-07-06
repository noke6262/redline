using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types.Passport;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class EncryptedPassportElement
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

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

	[CompilerGenerated]
	private object object_7;

	[CompilerGenerated]
	private object object_8;

	[CompilerGenerated]
	private object object_9;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Type
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Hash
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Data
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
	public string PhoneNumber
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
	public string Email
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
	public PassportFile[] Files
	{
		[CompilerGenerated]
		get
		{
			return (PassportFile[])object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PassportFile FrontSide
	{
		[CompilerGenerated]
		get
		{
			return (PassportFile)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PassportFile ReverseSide
	{
		[CompilerGenerated]
		get
		{
			return (PassportFile)object_7;
		}
		[CompilerGenerated]
		set
		{
			object_7 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PassportFile Selfie
	{
		[CompilerGenerated]
		get
		{
			return (PassportFile)object_8;
		}
		[CompilerGenerated]
		set
		{
			object_8 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PassportFile[] Translation
	{
		[CompilerGenerated]
		get
		{
			return (PassportFile[])object_9;
		}
		[CompilerGenerated]
		set
		{
			object_9 = value;
		}
	}
}
