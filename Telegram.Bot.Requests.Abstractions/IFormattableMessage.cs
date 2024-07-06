using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Requests.Abstractions;

public interface IFormattableMessage
{
	ParseMode ParseMode { get; set; }

	MessageEntity[] CaptionEntities { get; set; }
}
