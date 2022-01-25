using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebRemotePBL4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "/Users/ListFolderName/id",
                url: "{Users}/{ListFolderName}",
                defaults: new { controller = "Users", action = "ListFolderName", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "/FileDetails/Details/id",
               url: "{FileDetails}/{Details}/{id}",
               defaults: new { controller = "FileDetails", action = "Details", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "/Folders/Details/id",
                url: "{Folders}/{Details}/{id}",
                defaults: new { controller = "Folders", action = "Details", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "/Users/Index",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Users", action = "Index", xid = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "/Folders/Index",
                url: "{Folders}/{Index}",
                defaults: new { controller = "Folders", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Index" , id = UrlParameter.Optional }
            );
        }
    }
}
