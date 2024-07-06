namespace Telegram.Bot.Exceptions;

public class InvalidStickerDimensionsException : InvalidParameterException
{
	public InvalidStickerDimensionsException(string message)
		: base("png_sticker", message)
	{
	}
}
