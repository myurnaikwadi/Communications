using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using KindleSpur.Models.Interfaces;
using KindleSpur.Models;
using KindleSpur.Data;
using KindleSpur.Models.Interfaces.Repository;

namespace KindleSpur.Services
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
