namespace Telegram.Bot.Types.InlineQueryResults.Abstractions;

public interface ILocationInlineQueryResult
{
	float Latitude { get; set; }

	float Longitude { get; set; }
}
