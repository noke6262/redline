using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Helpers;

public static class TextFormat
{
	public static string TagReplace(string text)
	{
		text = text.Replace("&", "&amp;");
		text = text.Replace("<", "&lt;");
		text = text.Replace(">", "&gt;");
		text = text.Replace("\"", "&quot;");
		return text;
	}

	public static string InlineUser(ChatId id, string text)
	{
		text = text.Replace("&", "&amp;");
		text = text.Replace("<", "&lt;");
		text = text.Replace(">", "&gt;");
		text = text.Replace("\"", "&quot;");
		return "<a href=\"tg://user?id=" + id.Identifier + "\">" + text + "</a>";
	}

	public static string InlineUrl(string url, string text)
	{
		text = text.Replace("&", "&amp;");
		text = text.Replace("<", "&lt;");
		text = text.Replace(">", "&gt;");
		text = text.Replace("\"", "&quot;");
		url = url.Replace("&", "&amp;");
		url = url.Replace("<", "&lt;");
		url = url.Replace(">", "&gt;");
		url = url.Replace("\"", "&quot;");
		return "<a href=\"" + url + "\">" + text + "</a>";
	}

	public static string Bold(string text, bool replacetag = true)
	{
		if (replacetag)
		{
			text = text.Replace("&", "&amp;");
			text = text.Replace("<", "&lt;");
			text = text.Replace(">", "&gt;");
			text = text.Replace("\"", "&quot;");
		}
		return "<b>" + text + "</b>";
	}

	public static string Italic(string text, bool replacetag = true)
	{
		if (replacetag)
		{
			text = text.Replace("&", "&amp;");
			text = text.Replace("<", "&lt;");
			text = text.Replace(">", "&gt;");
			text = text.Replace("\"", "&quot;");
		}
		return "<i>" + text + "</i>";
	}

	public static string Mono(string text, bool replacetag = true)
	{
		if (replacetag)
		{
			text = text.Replace("&", "&amp;");
			text = text.Replace("<", "&lt;");
			text = text.Replace(">", "&gt;");
			text = text.Replace("\"", "&quot;");
		}
		return "<code>" + text + "</code>";
	}

	public static string Underline(string text, bool replacetag = true)
	{
		if (replacetag)
		{
			text = text.Replace("&", "&amp;");
			text = text.Replace("<", "&lt;");
			text = text.Replace(">", "&gt;");
			text = text.Replace("\"", "&quot;");
		}
		return "<u>" + text + "</u>";
	}

	public static string Strike(string text, bool replacetag = true)
	{
		if (replacetag)
		{
			text = text.Replace("&", "&amp;");
			text = text.Replace("<", "&lt;");
			text = text.Replace(">", "&gt;");
			text = text.Replace("\"", "&quot;");
		}
		return "<s>" + text + "</s>";
	}

	public static string GetMessageWithFormat(MessageEventArgs e)
	{
		string text = ((e.Message.Text != null) ? e.Message.Text : e.Message.Caption);
		if (text == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		MessageEntity[] array = ((e.Message.Entities != null) ? e.Message.Entities : e.Message.CaptionEntities);
		IEnumerable<string> source = ((e.Message.EntityValues != null) ? e.Message.EntityValues : e.Message.CaptionEntityValues);
		if ((e.Message.Text != null || e.Message.Caption != null) && array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				MessageEntity obj = array[i];
				int offset = obj.Offset;
				int length = obj.Length;
				MessageEntityType type = obj.Type;
				string url = obj.Url;
				User user = obj.User;
				string text2 = (string)smethod_0(source.ToArray()[i]);
				stringBuilder.Append((string)smethod_0(text.Substring(num, offset - num)));
				num = offset + length;
				if (type == MessageEntityType.Bold)
				{
					stringBuilder.Append(Bold(text2));
				}
				if (type == MessageEntityType.Code || type == MessageEntityType.Pre)
				{
					stringBuilder.Append(Mono(text2));
				}
				if (type == MessageEntityType.Italic)
				{
					stringBuilder.Append(Italic(text2));
				}
				if (type == MessageEntityType.Strikethrough)
				{
					stringBuilder.Append(Strike(text2));
				}
				if (type == MessageEntityType.Underline)
				{
					stringBuilder.Append(Underline(text2));
				}
				if (type == MessageEntityType.TextLink)
				{
					stringBuilder.Append(InlineUrl(url, text2));
				}
				if (type == MessageEntityType.TextMention)
				{
					stringBuilder.Append(InlineUser(user.Id, text2));
				}
				if (type == MessageEntityType.Mention)
				{
					stringBuilder.Append(text2);
				}
				if (type == MessageEntityType.Cashtag)
				{
					stringBuilder.Append(text2);
				}
				if (type == MessageEntityType.PhoneNumber)
				{
					stringBuilder.Append(text2);
				}
				if (type == MessageEntityType.Email)
				{
					stringBuilder.Append(text2);
				}
				if (type == MessageEntityType.BotCommand)
				{
					stringBuilder.Append(text2);
				}
				if (type == MessageEntityType.Url)
				{
					stringBuilder.Append(text2);
				}
				if (i == array.Length - 1)
				{
					stringBuilder.Append((string)smethod_0(text.Substring(num, text.Length - num)));
				}
			}
		}
		else
		{
			stringBuilder.Append((string)smethod_0(text));
		}
		return stringBuilder.ToString();
	}

	private static object smethod_0(object text)
	{
		text = ((string)text).Replace("&", "&amp;");
		text = ((string)text).Replace("<", "&lt;");
		text = ((string)text).Replace(">", "&gt;");
		text = ((string)text).Replace("\"", "&quot;");
		return text;
	}
}
