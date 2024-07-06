using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Requests.Abstractions;

public interface IReplyMarkupMessage<TMarkup> where TMarkup : IReplyMarkup
{
	TMarkup ReplyMarkup { get; set; }
}
