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
       
       



       public ActionResult Accueil()
       {
            using (IDal dal = new Dal())
            {
                
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();



                ViewBag.gps = dal.ObtientToutesLesEntreesGPS();


                ViewBag.nbAlertes = alertes.Count;
                ViewBag.appareils = dal.obtientTousLesAppareils();

            }

            return View("Accueil");
        }




    }







}