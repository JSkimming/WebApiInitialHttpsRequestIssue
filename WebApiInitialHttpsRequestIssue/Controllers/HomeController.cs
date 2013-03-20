using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApiInitialHttpsRequestIssue.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private static HttpClient GetClient(Uri requestUrl)
        {
            var baseUri =
                requestUrl.AbsoluteUri.Substring(0,
                                                 requestUrl.AbsoluteUri.LastIndexOf(requestUrl.PathAndQuery,
                                                                                    StringComparison.Ordinal));
            return new HttpClient(new TraceHttpClientHandler())
                {
                    BaseAddress = new Uri(baseUri),
                };
        }

        public ActionResult Index()
        {
            MvcApplication.LogFormat("Redirecting from '{0}'.", Request.Url);

            return RedirectPermanent("~/api/test");
        }

        public async Task<ActionResult> TestGet()
        {
            using (var client = GetClient(Request.Url))
            {
                HttpResponseMessage responseMessage = await client.GetAsync("api/test");

                string result = await responseMessage.Content.ReadAsStringAsync();

                return View((object)result);
            }
        }

        public async Task<ActionResult> TestPost()
        {
            using (var client = GetClient(Request.Url))
            {
                var content = new StringContent(string.Format("Here is some test data '{0}'.", Guid.NewGuid()));

                HttpResponseMessage responseMessage = await client.PostAsync("api/test", content);

                string result = await responseMessage.Content.ReadAsStringAsync();

                return View((object) result);
            }
        }
    }
}
