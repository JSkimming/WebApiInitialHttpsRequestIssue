using System.Web.Mvc;

namespace WebApiInitialHttpsRequestIssue.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectPermanent("~/api/test");
        }
    }
}
