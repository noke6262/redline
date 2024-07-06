using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class InlineKeyboardButton : IKeyboardButton
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
	private IntPtr intptr_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Text
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
	public string Url
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
	public LoginUrl LoginUrl
	{
		[CompilerGenerated]
		get
		{
			return (LoginUrl)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string CallbackData
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
	public string SwitchInlineQuery
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
	public string SwitchInlineQueryCurrentChat
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
	public CallbackGame CallbackGame
	{
		[CompilerGenerated]
		get
		{
			return (CallbackGame)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool Pay
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)(value ? 1 : 0);
		}
	}

	public static InlineKeyboardButton WithUrl(string text, string url)
	{
		return new InlineKeyboardButton
		{
			Text = text,
			Url = url
		};
	}

	public static InlineKeyboardButton WithLoginUrl(string text, LoginUrl loginUrl)
	{
		return new InlineKeyboardButton
		{
			Text = text,
			LoginUrl = loginUrl
		};
	}

	public static InlineKeyboardButton WithCallbackData(string textAndCallbackData)
	{
		return new InlineKeyboardButton
		{
			Text = textAndCallbackData,
			CallbackData = textAndCallbackData
		};
	}

	public static InlineKeyboardButton WithCallbackData(string text, string callbackData)
	{
		return new InlineKeyboardButton
		{
			Text = text,
			CallbackData = callbackData
		};
	}

	public static InlineKeyboardButton WithSwitchInlineQuery(string text, string query = "")
	{
		return new InlineKeyboardButton
		{
			Text = text,
			SwitchInlineQuery = query
		};
	}

	public static InlineKeyboardButton WithSwitchInlineQueryCurrentChat(string text, string query = "")
	{
		return new InlineKeyboardButton
		{
			Text = text,
			SwitchInlineQueryCurrentChat = query
		};
	}

	public static InlineKeyboardButton WithCallBackGame(string text, CallbackGame callbackGame = null)
	{
		return new InlineKeyboardButton
		{
			Text = text,
			CallbackGame = (callbackGame ?? new CallbackGame())
		};
	}

	public static InlineKeyboardButton WithPayment(string text)
	{
		return new InlineKeyboardButton
		{
			Text = text,
			Pay = true
		};
	}

	public static implicit operator InlineKeyboardButton(string textAndCallbackData)
	{
		if (textAndCallbackData != null)
		{
			return WithCallbackData(textAndCallbackData);
		}
		return null;
	}
}
