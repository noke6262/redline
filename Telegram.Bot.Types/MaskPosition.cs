using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class MaskPosition
{
	[CompilerGenerated]
	private MaskPositionPoint maskPositionPoint_0;

	[CompilerGenerated]
	private float float_0;

	[CompilerGenerated]
	private float float_1;

	[CompilerGenerated]
	private float float_2;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public MaskPositionPoint Point
	{
		[CompilerGenerated]
		get
		{
			return maskPositionPoint_0;
		}
		[CompilerGenerated]
		set
		{
			maskPositionPoint_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public float XShift
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public float YShift
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public float Scale
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}
}
