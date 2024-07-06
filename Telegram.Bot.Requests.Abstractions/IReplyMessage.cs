namespace Telegram.Bot.Requests.Abstractions;

public interface IReplyMessage
{
	int ReplyToMessageId { get; set; }
}
