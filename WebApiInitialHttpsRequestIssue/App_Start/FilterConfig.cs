using System.Web;
using System.Web.Mvc;

namespace WebApiInitialHttpsRequestIssue
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}