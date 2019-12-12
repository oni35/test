using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace module1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "ProjetRef",
                url: "Projet/{projetRef}",
                defaults: new { controllers = "Employes", action = "ListEmploye" },
                constraints: new { projetRef = @"^[A-Z]{2}\d{5}$" }
                );

            routes.MapRoute(
                name: "NomEmploye",
                url: "Employe/{nom}",
                defaults: new { controllers = "Employes", action = "RechercheEmploye" }
                );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //Exemple d'ajout de route
            //routes.MapRoute(
            //    name: "MyRoute",
            //    url: "mapage/montruc",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
