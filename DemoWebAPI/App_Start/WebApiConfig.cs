using FluentValidation.WebApi;
using RCMSWebAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Infrastructure;

namespace RCMSWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectResolver();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            // Add Custom validation filters  
            config.Filters.Add(new ValidateModelStateFilter());  
            FluentValidationModelValidatorProvider.Configure(config);  
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
