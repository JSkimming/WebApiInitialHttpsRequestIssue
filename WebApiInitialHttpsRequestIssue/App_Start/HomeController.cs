using System.Web.Mvc;

namespace WebApiInitialHttpsRequestIssue.App_Start
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return Redirect("~/api/test");
        }
    }
}
