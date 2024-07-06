using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

public interface IInputMedia
{
	string Type { get; }

	InputMedia Media { get; }

	string Caption { get; }

	ParseMode ParseMode { get; }

	MessageEntity[] CaptionEntities { get; }
}
