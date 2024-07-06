using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Helpers;

public class ReplyKeyboard
{
	private object object_0;

	public static ForceReplyMarkup Force => new ForceReplyMarkup();

	public static ReplyKeyboardRemove Remove => new ReplyKeyboardRemove();

	public ReplyKeyboard()
	{
		object_0 = new List<KeyboardButton[]>();
	}

	public void Add(params KeyboardButton[] button)
	{
		((List<KeyboardButton[]>)object_0).Add(button);
	}

	public void Add(string text)
	{
		Add(Button(text));
	}

	public void AddPhone(string text)
	{
		Add(Phone(text));
	}

	public void AddLocation(string text)
	{
		Add(Location(text));
	}

	public void AddPoll(string text, string type = null)
	{
		Add(Poll(text, type));
	}

	public ReplyKeyboardMarkup Get(bool ResizeKeyboard = true, bool Selective = true, bool OneTimeKeyboard = true)
	{
		return new ReplyKeyboardMarkup(((List<KeyboardButton[]>)object_0).ToArray(), ResizeKeyboard, OneTimeKeyboard)
		{
			Selective = Selective
		};
	}

	public KeyboardButton Button(string text)
	{
		return new KeyboardButton(text);
	}

	public KeyboardButton Phone(string text)
	{
		return KeyboardButton.WithRequestContact(text);
	}

	public KeyboardButton Location(string text)
	{
		return KeyboardButton.WithRequestLocation(text);
	}

	public KeyboardButton Poll(string text, string type = null)
	{
		return KeyboardButton.WithRequestPoll(text, type);
	}

	public static implicit operator ReplyKeyboardMarkup(ReplyKeyboard replyKeyboard)
	{
		return replyKeyboard.Get();
	}
}
