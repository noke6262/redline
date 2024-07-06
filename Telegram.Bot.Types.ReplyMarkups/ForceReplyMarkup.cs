using Newtonsoft.Json;

namespace Telegram.Bot.Types.ReplyMarkups;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ForceReplyMarkup : ReplyMarkupBase
{
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool ForceReply => true;
}
