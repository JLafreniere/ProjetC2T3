using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_APP_C2T3.Models;

namespace WEB_APP_C2T3.Controllers
{
    public class AlerteController : Controller
    {





        public void EffacerAlertes()
        {

           
            using (IDal dal = new Dal())
            {

                dal.effacerAlertes();
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();
                ViewBag.nbAlertes = alertes.Count;
                
            }

        }




        public void EnvoyerAlerte()
        {


            using (IDal dal = new Dal())
            {
                dal.CreerAlerte("Alerte générée depuis la vue");
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();
                ViewBag.nbAlertes = alertes.Count;
               
            }

        }



    }
}