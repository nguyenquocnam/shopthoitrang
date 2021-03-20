using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shopthucung
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "chitet",
                url: "Chi-Tiet-San-Pham/{MaPL}/{MaSp}",
                defaults: new { controller = "Home", action = "chitiet"}
            );
            routes.MapRoute(
                name: "listTinTuc",
                url: "{Controller}/Tin-Tuc",
                defaults: new { controller = "Home", action = "listTinTuc" }
            );
            routes.MapRoute(
                name: "List San Pham",
                url: "{Controller}/danh-sach-san-pham/{MaLoaiSP}/{MaPL}/{Page}",
                defaults: new { controller = "Home", action = "listsp",MaPL = UrlParameter.Optional,Page = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "chi tiet tin tuc",
                url: "{Controller}/Tin-Tuc/{MaBaiViet}",
                defaults: new { controller = "Home", action = "chiTietTinTuc" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
