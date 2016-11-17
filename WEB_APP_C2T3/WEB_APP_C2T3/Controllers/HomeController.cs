using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_APP_C2T3.Models;

namespace WEB_APP_C2T3.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Accueil()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerAlerte("Le serveur a pris feu");
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();

                ViewBag.nbAlertes = alertes.Count;

            }

            return View("Accueil");
        }

        
        public ActionResult EffacerAlertes()
        {
            using (IDal dal = new Dal())
            {

                dal.effacerAlertes();
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();

                ViewBag.nbAlertes = alertes.Count;
            }
            return View("Accueil");
        }




        public ActionResult EnvoyerAlerte()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerAlerte("Alerte générée depuis la vue");
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();

                ViewBag.nbAlertes = alertes.Count;
            }
            return View("Accueil");
        }

        [HttpPost]
        public ActionResult CreerEntreeGPS()
        {
            using (IDal dal = new Dal())
            {
                double latitude = Double.Parse(Request["lat"]);
                double longitude = Double.Parse(Request["long"]);
                string id = Request["id_appareil"];

                dal.CreerEntreeGPS(id, latitude, longitude);

            }
            return View("Accueil");
        }

    }

   





}