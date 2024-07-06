namespace Telegram.Bot.Types.InlineQueryResults.Abstractions;

public interface IThumbnailInlineQueryResult : IThumbnailUrlInlineQueryResult
{
	int ThumbWidth { get; set; }

	int ThumbHeight { get; set; }
}
