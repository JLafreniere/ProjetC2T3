using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WEB_APP_C2T3.Models;

namespace WEB_APP_C2T3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());

            using (IDal dal = new Dal())
            {
                dal.CreerAlerte("Le serveur a pris feu");
                dal.creerAppareil("DÉFAUT");
                dal.creerUtilisateur("administrateur", "admin", "Lafrenière", "Jonathan", true);
                System.Diagnostics.Debug.WriteLine(dal.obtientTousLesUtilisateurs().Count);
            }
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
