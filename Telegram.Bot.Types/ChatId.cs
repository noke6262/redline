using Newtonsoft.Json;
using Telegram.Bot.Args;
using Telegram.Bot.Converters;

namespace Telegram.Bot.Types;

[JsonConverter(typeof(ChatIdConverter))]
public class ChatId
{
	public readonly long Identifier;

	public readonly string Username;

	public static int TelegramId => 777000;

	public static int AnonymousId => 1087968824;

	public ChatId(long identifier)
	{
		Identifier = identifier;
	}

	public ChatId(int chatId)
	{
		Identifier = chatId;
	}

	public ChatId(string username)
	{
		int result;
		long result2;
		if (username.Length > 1 && username.Substring(0, 1) == "@")
		{
			Username = username;
		}
		else if (int.TryParse(username, out result))
		{
			Identifier = result;
		}
		else if (long.TryParse(username, out result2))
		{
			Identifier = result2;
		}
	}

	public override bool Equals(object obj)
	{
		return ((string)this).Equals(obj);
	}

	public override int GetHashCode()
	{
		return ((string)this).GetHashCode();
	}

	public override string ToString()
	{
		return this;
	}

	public static implicit operator ChatId(long identifier)
	{
		return new ChatId(identifier);
	}

	public static implicit operator ChatId(int chatId)
	{
		return new ChatId(chatId);
	}

	public static implicit operator ChatId(string username)
	{
		return new ChatId(username);
	}

	public static implicit operator string(ChatId chatid)
	{
		return chatid.Username ?? chatid.Identifier.ToString();
	}

	public static implicit operator ChatId(Chat chat)
	{
		if (chat.Id == 0L)
		{
			return "@" + chat.Username;
		}
		return chat.Id;
	}

	public static implicit operator ChatId(MessageEventArgs message)
	{
		return message.Message.Chat.Id;
	}

	public static implicit operator ChatId(Message message)
	{
		return message.Chat.Id;
	}

	public static implicit operator ChatId(CallbackQueryEventArgs callback)
	{
		return callback.CallbackQuery.Message.Chat.Id;
	}

	public static implicit operator ChatId(CallbackQuery query)
	{
		return query.Message.Chat.Id;
	}
}
