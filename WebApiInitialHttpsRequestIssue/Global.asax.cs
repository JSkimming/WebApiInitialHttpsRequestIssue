using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Elmah;

namespace WebApiInitialHttpsRequestIssue
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static void LogInternal(string message, int lineNumber, string memberName, string filePath)
        {
            ErrorLog errorLog;
            try
            {
                errorLog = ErrorLog.GetDefault(HttpContext.Current);
            }
            catch (Exception)
            {
                return;
            }

            var fullMessage = string.Format("{0}({1}): [{2}] {3}", filePath, lineNumber, memberName, message);

            // This outputs to the debug window, which can then be used to double-click-go-to-source.
            Debug.WriteLine(fullMessage);

            var error = new Error(new Exception(fullMessage), HttpContext.Current)
            {
                Type = "log"
            };

            errorLog.Log(error);
        }

        public static void Log(string message,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "")
        {
            LogInternal(message, lineNumber, memberName, filePath);
        }

        public static void LogFormat(string format, object arg0,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "")
        {
            LogInternal(string.Format(format, arg0), lineNumber, memberName, filePath);
        }

        public static void LogFormat(string format, object arg0, object arg1,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "")
        {
            LogInternal(string.Format(format, arg0, arg1), lineNumber, memberName, filePath);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}