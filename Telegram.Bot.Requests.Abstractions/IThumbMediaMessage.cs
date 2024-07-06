using Telegram.Bot.Types;

namespace Telegram.Bot.Requests.Abstractions;

public interface IThumbMediaMessage
{
	InputMedia Thumb { get; set; }
}
