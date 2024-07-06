using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegram.Bot.Types.InlineQueryResults;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public abstract class InputMessageContentBase
{
}
