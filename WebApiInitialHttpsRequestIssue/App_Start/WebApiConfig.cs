﻿using System.Web.Http;
using WebApiInitialHttpsRequestIssue.Filter;

namespace WebApiInitialHttpsRequestIssue
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new RequireHttpsHandler());
        }
    }
}
