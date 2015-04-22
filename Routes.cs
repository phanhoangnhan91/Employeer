using Orchard.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Futurify.Training.Employees
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                //new RouteDescriptor {
                //    Priority = 1,
                //    Route = new Route(
                //        "Employees/{action}",
                //        new RouteValueDictionary {
                //            {"area", "Futurify.Training.Employees"},
                //            {"controller", "Employees"},
                //            {"action", "Index"}
                //        },
                //        new RouteValueDictionary(),
                //        new RouteValueDictionary {
                //            {"area", "Futurify.Training.Employees"}
                //        },
                //        new MvcRouteHandler())
                //},
                new RouteDescriptor {
                    Priority = 2,
                    Route = new Route(
                        "Employees/{action}/{id}",
                        new RouteValueDictionary {
                            {"area", "Futurify.Training.Employees"},
                            {"controller", "Employees"},
                            {"action", "Index"},
                            {"id", null}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Futurify.Training.Employees"}
                        },
                        new MvcRouteHandler())
                }
            };
        }
    }
}