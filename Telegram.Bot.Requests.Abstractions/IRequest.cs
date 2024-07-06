using System.Net.Http;

namespace Telegram.Bot.Requests.Abstractions;

public interface IRequest<TResponse>
{
	HttpMethod Method { get; }

	string MethodName { get; }

	HttpContent ToHttpContent();
}
