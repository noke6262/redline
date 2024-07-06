using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types;

public interface IInputFile
{
	FileType FileType { get; }
}
