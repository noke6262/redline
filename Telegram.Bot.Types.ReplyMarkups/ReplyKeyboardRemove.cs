using Newtonsoft.Json;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ReplyKeyboardRemove : ReplyMarkupBase
{
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool RemoveKeyboard => true;
}
