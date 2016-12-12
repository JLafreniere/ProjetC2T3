using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_APP_C2T3.Models;

namespace WEB_APP_C2T3.Controllers
{
    public class GPSController : Controller
    {

        public bool positionEnregistree = false;

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

        [HttpPost]
        public void CreerEntreeGPS()
        {
            using (IDal dal = new Dal())
            {
                
                double latitude = Double.Parse(Request["lat"]);
                double longitude = Double.Parse(Request["long"]);
                int id = int.Parse((Request["id_appareil"]));

                dal.CreerEntreeGPS(id, latitude, longitude);
                positionEnregistree = true;
                ViewBag.positionEnregistree = positionEnregistree;
                positionEnregistree = false;
                getGps();
                
                   
            }

        }

        public List<EntreeGPS> getGps()
        {
            using (IDal dal = new Dal())
            {
               return dal.ObtientToutesLesEntreesGPS();
            }
        }


        [HttpPost]
        public void EnregistrerPosition()
        {
            using (IDal dal = new Dal())
            {

                double latitude = Double.Parse(Request["lat"]);
                double longitude = Double.Parse(Request["long"]);
                int id = int.Parse(Request["id_appareil"]);
                dal.CreerEntreeGPS(id, latitude, longitude);
                positionEnregistree = true;
                ViewBag.positionEnregistree = positionEnregistree;
                positionEnregistree = false;
                getGps();
            }

        }




    }
}