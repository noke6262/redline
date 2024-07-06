using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests.Abstractions;

public interface IInlineReplyMarkupMessage : IReplyMarkupMessage<InlineKeyboardMarkup>
{
	new InlineKeyboardMarkup ReplyMarkup { get; set; }
}
