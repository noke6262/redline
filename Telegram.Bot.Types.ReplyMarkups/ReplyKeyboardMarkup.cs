using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ReplyKeyboardMarkup : ReplyMarkupBase
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public IEnumerable<IEnumerable<KeyboardButton>> Keyboard
	{
		[CompilerGenerated]
		get
		{
			return (IEnumerable<IEnumerable<KeyboardButton>>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool ResizeKeyboard
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_1 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool OneTimeKeyboard
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_2 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)(value ? 1 : 0);
		}
	}

	public ReplyKeyboardMarkup()
	{
	}

	public ReplyKeyboardMarkup(KeyboardButton button)
		: this(new KeyboardButton[1] { button })
	{
	}

	public ReplyKeyboardMarkup(IEnumerable<KeyboardButton> keyboardRow, bool resizeKeyboard = false, bool oneTimeKeyboard = false)
		: this(new IEnumerable<KeyboardButton>[1] { keyboardRow }, resizeKeyboard, oneTimeKeyboard)
	{
	}

	public ReplyKeyboardMarkup(IEnumerable<IEnumerable<KeyboardButton>> keyboard, bool resizeKeyboard = false, bool oneTimeKeyboard = false)
	{
		Keyboard = keyboard;
		ResizeKeyboard = resizeKeyboard;
		OneTimeKeyboard = oneTimeKeyboard;
	}

	public static implicit operator ReplyKeyboardMarkup(string text)
	{
		if (text != null)
		{
			return new ReplyKeyboardMarkup(new KeyboardButton[1]
			{
				new KeyboardButton(text)
			});
		}
		return null;
	}

	public static implicit operator ReplyKeyboardMarkup(string[] texts)
	{
		return (texts == null) ? null : new string[1][] { texts };
	}

	public static implicit operator ReplyKeyboardMarkup(string[][] textsItems)
	{
		if (textsItems != null)
		{
			return new ReplyKeyboardMarkup(textsItems.Select((string[] texts) => texts.Select((string t) => new KeyboardButton(t))));
		}
		return null;
	}
}
