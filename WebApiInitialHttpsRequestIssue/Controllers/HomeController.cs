using System.Web.Mvc;

namespace WebApiInitialHttpsRequestIssue.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            MvcApplication.LogFormat("Redirecting from '{0}'.", Request.Url);

            return RedirectPermanent("~/api/test");
        }
    }
}
