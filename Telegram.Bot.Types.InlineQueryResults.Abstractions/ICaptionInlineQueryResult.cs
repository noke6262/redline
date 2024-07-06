using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types.InlineQueryResults.Abstractions;

public interface ICaptionInlineQueryResult
{
	string Caption { get; set; }

	ParseMode ParseMode { get; set; }

	MessageEntity[] CaptionEntities { get; set; }
}
