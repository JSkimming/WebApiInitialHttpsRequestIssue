using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiInitialHttpsRequestIssue
{
    public class TraceHttpClientHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            MvcApplication.LogFormat("{0} {1}", request.Method.Method, request.RequestUri);
            return base.SendAsync(request, cancellationToken);
        }
    }
}