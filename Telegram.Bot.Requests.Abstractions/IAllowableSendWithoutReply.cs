namespace Telegram.Bot.Requests.Abstractions;

public interface IAllowableSendWithoutReply
{
	bool AllowSendingWithoutReply { get; set; }
}
