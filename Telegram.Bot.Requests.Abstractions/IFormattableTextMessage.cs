using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Requests.Abstractions;

public interface IFormattableTextMessage
{
	ParseMode ParseMode { get; set; }

	MessageEntity[] Entities { get; set; }
}
