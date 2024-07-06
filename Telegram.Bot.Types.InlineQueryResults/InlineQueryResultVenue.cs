using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class InlineQueryResultVenue : InlineQueryResultBase, IInputMessageContentResult, ILocationInlineQueryResult, IThumbnailInlineQueryResult, IThumbnailUrlInlineQueryResult, ITitleInlineQueryResult
{
	[CompilerGenerated]
	private float float_0;

	[CompilerGenerated]
	private float float_1;

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
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr a;

	[CompilerGenerated]
	private object b;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public float Latitude
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
	public float Longitude
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
	public string Address
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
	public string FoursquareId
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
	public string FoursquareType
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
	public string GooglePlaceId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string GooglePlaceType
	{
		[CompilerGenerated]
		get
		{
			return (string)object_7;
		}
		[CompilerGenerated]
		set
		{
			object_7 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string ThumbUrl
	{
		[CompilerGenerated]
		get
		{
			return (string)object_8;
		}
		[CompilerGenerated]
		set
		{
			object_8 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int ThumbWidth
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
	public int ThumbHeight
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)a;
		}
		[CompilerGenerated]
		set
		{
			a = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InputMessageContentBase InputMessageContent
	{
		[CompilerGenerated]
		get
		{
			return (InputMessageContentBase)b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	private InlineQueryResultVenue()
		: base(InlineQueryResultType.Venue)
	{
	}

	public InlineQueryResultVenue(string id, float latitude, float longitude, string title, string address)
		: base(InlineQueryResultType.Venue, id)
	{
		Latitude = latitude;
		Longitude = longitude;
		Title = title;
		Address = address;
	}
}
