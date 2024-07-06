using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Payments;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class Update
{
	[CompilerGenerated]
	private IntPtr intptr_0;

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
	private object a;

	[CompilerGenerated]
	private object b;

	[CompilerGenerated]
	private object c;

	[CompilerGenerated]
	private object d;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int Id
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
	public Message Message
	{
		[CompilerGenerated]
		get
		{
			return (Message)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Message EditedMessage
	{
		[CompilerGenerated]
		get
		{
			return (Message)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InlineQuery InlineQuery
	{
		[CompilerGenerated]
		get
		{
			return (InlineQuery)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChosenInlineResult ChosenInlineResult
	{
		[CompilerGenerated]
		get
		{
			return (ChosenInlineResult)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public CallbackQuery CallbackQuery
	{
		[CompilerGenerated]
		get
		{
			return (CallbackQuery)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Message ChannelPost
	{
		[CompilerGenerated]
		get
		{
			return (Message)object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Message EditedChannelPost
	{
		[CompilerGenerated]
		get
		{
			return (Message)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ShippingQuery ShippingQuery
	{
		[CompilerGenerated]
		get
		{
			return (ShippingQuery)object_7;
		}
		[CompilerGenerated]
		set
		{
			object_7 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PreCheckoutQuery PreCheckoutQuery
	{
		[CompilerGenerated]
		get
		{
			return (PreCheckoutQuery)object_8;
		}
		[CompilerGenerated]
		set
		{
			object_8 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Poll Poll
	{
		[CompilerGenerated]
		get
		{
			return (Poll)a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PollAnswer PollAnswer
	{
		[CompilerGenerated]
		get
		{
			return (PollAnswer)b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatMemberUpdated MyChatMemberUpdated
	{
		[CompilerGenerated]
		get
		{
			return (ChatMemberUpdated)c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ChatMemberUpdated ChatMemberUpdated
	{
		[CompilerGenerated]
		get
		{
			return (ChatMemberUpdated)d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	public UpdateType Type
	{
		get
		{
			if (Message != null)
			{
				return UpdateType.Message;
			}
			if (InlineQuery != null)
			{
				return UpdateType.InlineQuery;
			}
			if (ChosenInlineResult != null)
			{
				return UpdateType.ChosenInlineResult;
			}
			if (CallbackQuery == null)
			{
				if (EditedMessage != null)
				{
					return UpdateType.EditedMessage;
				}
				if (ChannelPost == null)
				{
					if (EditedChannelPost != null)
					{
						return UpdateType.EditedChannelPost;
					}
					if (ShippingQuery == null)
					{
						if (PreCheckoutQuery != null)
						{
							return UpdateType.PreCheckoutQuery;
						}
						if (Poll != null)
						{
							return UpdateType.Poll;
						}
						if (PollAnswer == null)
						{
							if (MyChatMemberUpdated == null)
							{
								if (ChatMemberUpdated == null)
								{
									return UpdateType.Unknown;
								}
								return UpdateType.ChatMemberUpdated;
							}
							return UpdateType.MyChatMemberUpdated;
						}
						return UpdateType.PollAnswer;
					}
					return UpdateType.ShippingQuery;
				}
				return UpdateType.ChannelPost;
			}
			return UpdateType.CallbackQuery;
		}
	}
}
