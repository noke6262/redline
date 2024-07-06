using System;
using System.Collections.Generic;

namespace Telegram.Bot.Types.Enums;

internal static class MessageEntityTypeExtensions
{
	private static readonly object object_0 = new Dictionary<string, MessageEntityType>
	{
		{
			"mention",
			MessageEntityType.Mention
		},
		{
			"hashtag",
			MessageEntityType.Hashtag
		},
		{
			"bot_command",
			MessageEntityType.BotCommand
		},
		{
			"url",
			MessageEntityType.Url
		},
		{
			"email",
			MessageEntityType.Email
		},
		{
			"bold",
			MessageEntityType.Bold
		},
		{
			"italic",
			MessageEntityType.Italic
		},
		{
			"code",
			MessageEntityType.Code
		},
		{
			"pre",
			MessageEntityType.Pre
		},
		{
			"text_link",
			MessageEntityType.TextLink
		},
		{
			"text_mention",
			MessageEntityType.TextMention
		},
		{
			"phone_number",
			MessageEntityType.PhoneNumber
		},
		{
			"cashtag",
			MessageEntityType.Cashtag
		},
		{
			"underline",
			MessageEntityType.Underline
		},
		{
			"strikethrough",
			MessageEntityType.Strikethrough
		}
	};

	private static readonly object object_1 = new Dictionary<MessageEntityType, string>
	{
		{
			MessageEntityType.Mention,
			"mention"
		},
		{
			MessageEntityType.Hashtag,
			"hashtag"
		},
		{
			MessageEntityType.BotCommand,
			"bot_command"
		},
		{
			MessageEntityType.Url,
			"url"
		},
		{
			MessageEntityType.Email,
			"email"
		},
		{
			MessageEntityType.Bold,
			"bold"
		},
		{
			MessageEntityType.Italic,
			"italic"
		},
		{
			MessageEntityType.Code,
			"code"
		},
		{
			MessageEntityType.Pre,
			"pre"
		},
		{
			MessageEntityType.TextLink,
			"text_link"
		},
		{
			MessageEntityType.TextMention,
			"text_mention"
		},
		{
			MessageEntityType.PhoneNumber,
			"phone_number"
		},
		{
			MessageEntityType.Cashtag,
			"cashtag"
		},
		{
			MessageEntityType.Unknown,
			"unknown"
		},
		{
			MessageEntityType.Underline,
			"underline"
		},
		{
			MessageEntityType.Strikethrough,
			"strikethrough"
		}
	};

	internal static MessageEntityType smethod_0(this string value)
	{
		if (!((IDictionary<string, MessageEntityType>)object_0).TryGetValue(value, out MessageEntityType value2))
		{
			return MessageEntityType.Unknown;
		}
		return value2;
	}

	internal static string smethod_1(this MessageEntityType value)
	{
		if (!((IDictionary<MessageEntityType, string>)object_1).TryGetValue(value, out string value2))
		{
			throw new NotSupportedException();
		}
		return value2;
	}
}
