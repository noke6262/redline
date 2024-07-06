using Telegram.Bot.Types;

namespace Telegram.Bot.Requests.Abstractions;

public interface IChatMessage
{
	ChatId ChatId { get; }
}
