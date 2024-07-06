using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class InlineKeyboardMarkup : IReplyMarkup
{
	[CompilerGenerated]
	private readonly object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IEnumerable<IEnumerable<InlineKeyboardButton>> InlineKeyboard
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<IEnumerable<InlineKeyboardButton>>)object_0;
		}
	}

	public InlineKeyboardMarkup(InlineKeyboardButton inlineKeyboardButton)
		: this(new InlineKeyboardButton[1] { inlineKeyboardButton })
	{
	}

	public InlineKeyboardMarkup(IEnumerable<InlineKeyboardButton> inlineKeyboardRow)
	{
		object_0 = new IEnumerable<InlineKeyboardButton>[1] { inlineKeyboardRow };
	}

	[JsonConstructor]
	public InlineKeyboardMarkup(IEnumerable<IEnumerable<InlineKeyboardButton>> inlineKeyboard)
	{
		object_0 = inlineKeyboard;
	}

	public static InlineKeyboardMarkup Empty()
	{
		return new InlineKeyboardMarkup(new InlineKeyboardButton[0][]);
	}

	public static implicit operator InlineKeyboardMarkup(InlineKeyboardButton button)
	{
		if (button != null)
		{
			return new InlineKeyboardMarkup(button);
		}
		return null;
	}

	public static implicit operator InlineKeyboardMarkup(string buttonText)
	{
		if (buttonText != null)
		{
			return new InlineKeyboardMarkup(buttonText);
		}
		return null;
	}

	public static implicit operator InlineKeyboardMarkup(IEnumerable<InlineKeyboardButton>[] inlineKeyboard)
	{
		if (inlineKeyboard != null)
		{
			return new InlineKeyboardMarkup(inlineKeyboard);
		}
		return null;
	}

	public static implicit operator InlineKeyboardMarkup(InlineKeyboardButton[] inlineKeyboard)
	{
		if (inlineKeyboard != null)
		{
			return new InlineKeyboardMarkup(inlineKeyboard);
		}
		return null;
	}
}
