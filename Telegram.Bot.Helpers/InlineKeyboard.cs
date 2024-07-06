using System.Collections.Generic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Helpers;

public class InlineKeyboard
{
	private object object_0;

	public InlineKeyboard()
	{
		object_0 = new List<InlineKeyboardButton[]>();
	}

	public void Add(string text, string callback)
	{
		Add(Callback(text, callback));
	}

	public void Add(string text)
	{
		Add(Callback(text));
	}

	public void AddUrl(string text, string url)
	{
		Add(Url(text, url));
	}

	public void AddPayment(string text)
	{
		Add(Payment(text));
	}

	public void AddQuery(string text, string query = "")
	{
		Add(Query(text, query));
	}

	public void AddQueryCurrentChat(string text, string query = "")
	{
		Add(QueryCurrentChat(text, query));
	}

	public void AddLoginUrl(string text, LoginUrl loginUrl)
	{
		Add(LoginUrl(text, loginUrl));
	}

	public void AddCallbackGame(string text, CallbackGame game = null)
	{
		Add(CallbackGame(text, game));
	}

	public void Add(params InlineKeyboardButton[] buttons)
	{
		((List<InlineKeyboardButton[]>)object_0).Add(buttons);
	}

	public InlineKeyboardButton Url(string text, string url)
	{
		return InlineKeyboardButton.WithUrl(text, url);
	}

	public InlineKeyboardButton Callback(string text, string callback)
	{
		return InlineKeyboardButton.WithCallbackData(text, callback);
	}

	public InlineKeyboardButton Callback(string text)
	{
		return InlineKeyboardButton.WithCallbackData(text, text);
	}

	public InlineKeyboardButton Payment(string text)
	{
		return InlineKeyboardButton.WithPayment(text);
	}

	public InlineKeyboardButton QueryCurrentChat(string text, string query = "")
	{
		return InlineKeyboardButton.WithSwitchInlineQueryCurrentChat(text, query);
	}

	public InlineKeyboardButton Query(string text, string query = "")
	{
		return InlineKeyboardButton.WithSwitchInlineQuery(text, query);
	}

	public InlineKeyboardButton LoginUrl(string text, LoginUrl loginUrl)
	{
		return InlineKeyboardButton.WithLoginUrl(text, loginUrl);
	}

	public InlineKeyboardButton CallbackGame(string text, CallbackGame game = null)
	{
		return InlineKeyboardButton.WithCallBackGame(text, game);
	}

	public InlineKeyboardMarkup Get()
	{
		return new InlineKeyboardMarkup(((List<InlineKeyboardButton[]>)object_0).ToArray());
	}

	public static implicit operator InlineKeyboardMarkup(InlineKeyboard inlineKeyboard)
	{
		return inlineKeyboard.Get();
	}
}
