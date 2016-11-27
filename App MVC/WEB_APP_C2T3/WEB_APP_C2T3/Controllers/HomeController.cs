using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_APP_C2T3.Models;

namespace WEB_APP_C2T3.Controllers
{

    public class HomeController : Controller
    {
        public bool positionEnregistree = false;
       



public ActionResult Accueil()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerAlerte("Le serveur a pris feu");
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();
                getGps();
                ViewBag.nbAlertes = alertes.Count;

            }

            return View("Accueil");
        }

        
        public void EffacerAlertes()
        {
            using (IDal dal = new Dal())
            {

                dal.effacerAlertes();
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();
                getGps();
                ViewBag.nbAlertes = alertes.Count;
            }
          
        }




        public void EnvoyerAlerte()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerAlerte("Alerte générée depuis la vue");
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();
                getGps();
                ViewBag.nbAlertes = alertes.Count;
            }
          
        }

        [HttpPost]
        public void CreerEntreeGPS()
        {
            using (IDal dal = new Dal())
            {
                double latitude = Double.Parse(Request["lat"]);
                double longitude = Double.Parse(Request["long"]);
                string id = Request["id_appareil"];
                
                dal.CreerEntreeGPS(id, latitude, longitude);
                positionEnregistree = true;
                ViewBag.positionEnregistree = positionEnregistree;
                positionEnregistree = false;
                getGps(); 
            }
            
        }

        public void getGps() { 
             using (IDal dal = new Dal())
            {
            ViewBag.gps= dal.ObtientToutesLesEntreesGPS();
            }
        }

        [HttpPost]
        public void EnregistrerPosition()
        {
            using (IDal dal = new Dal())
            {

                double latitude = Double.Parse(Request["lat"]);
                double longitude = Double.Parse(Request["long"]);
                string id = Request["id_appareil"];
                Debug.WriteLine("My debug string here");
                dal.CreerEntreeGPS(id, latitude, longitude);
                positionEnregistree = true;
                ViewBag.positionEnregistree = positionEnregistree;
                positionEnregistree = false;
                getGps();
            }
          
        }

        [HttpPost]
        public void SupprimerEntreeGPS()
        {
            using (IDal dal = new Dal())
            {
                
                int id = int.Parse(Request["id_entree"]);
                System.Diagnostics.Debug.WriteLine("Suppression de l'enregistrement: " + id);
                dal.supprimerEntreeGps(id);
              
            }

        }



    }







}