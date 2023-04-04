    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Online_NonBaoHiem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "admin",
                url: "admin/login",
                defaults: new { controller = "Login", action = "DangNhap" }
            );
            //  routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



        }
    }
}
