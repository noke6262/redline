using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class ApiResponse<TResult>
{
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool Ok { get; set; }

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public TResult Result { get; set; }

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Description { get; set; }

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int ErrorCode { get; set; }

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ResponseParameters Parameters { get; set; }
}
