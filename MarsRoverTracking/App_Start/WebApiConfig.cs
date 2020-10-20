using MarsRoverTracking.Business;
using MarsRoverTracking.Business.Interfaces;
using MarsRoverTracking.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MarsRoverTracking
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Unity configuration
            var container = new UnityContainer();
            container.RegisterType<IRoverBusiness, RoverBusiness>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            //this
            config.DependencyResolver = new UnityDependencyResolver(container);
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
