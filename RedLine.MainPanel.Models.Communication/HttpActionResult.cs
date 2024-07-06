using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace RedLine.MainPanel.Models.Communication;

public class HttpActionResult : IHttpActionResult
{
	private readonly object object_0;

	private readonly HttpStatusCode httpStatusCode_0;

	public HttpActionResult(HttpStatusCode statusCode, string message)
	{
		httpStatusCode_0 = statusCode;
		object_0 = message;
	}

	public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
	{
		return Task.FromResult(new HttpResponseMessage(httpStatusCode_0)
		{
			Content = new StringContent((string)object_0)
		});
	}
}
