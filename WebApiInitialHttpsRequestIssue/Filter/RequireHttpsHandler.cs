using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiInitialHttpsRequestIssue.Filter
{
    /// <summary>
    /// Handler to enforce requests are over HTTPS.
    /// </summary>
    public class RequireHttpsHandler : DelegatingHandler
    {
        /// <summary>
        /// Checks whether the request is over HTTPS and returns a <see cref="HttpStatusCode.Forbidden"/> response if it is not.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (string.Compare(request.RequestUri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) != 0)
            {
                var content =
                    string.Format("HTTPS is required. Scheme is '{0}', it must be '{1}', request Uri is '{2}'.",
                                  request.RequestUri.Scheme,
                                  Uri.UriSchemeHttps,
                                  request.RequestUri);

                MvcApplication.Log(content);

                return
                    Task.FromResult(new HttpResponseMessage(HttpStatusCode.Forbidden)
                        {
                            Content = new StringContent(content)
                        });
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
