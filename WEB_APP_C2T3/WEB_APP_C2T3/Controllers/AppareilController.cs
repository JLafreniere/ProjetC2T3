using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_APP_C2T3.Models;

namespace WEB_APP_C2T3.Controllers
{

    public class AppareilController : Controller
    {

            



            public ActionResult Appareils()
            {
            try
            {
                if (Session["AdminRights"].ToString() == "False" || Session["AdminRights"].ToString() == String.Empty)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }


            using (IDal dal = new Dal())
                {
                    List<Appareil> appareils = dal.obtientTousLesAppareils();
                    ViewBag.appareils = dal.obtientTousLesAppareils();
                    return View("Appareils", dal.obtientTousLesAppareils());
                }
            }



            [HttpPost]
            public ActionResult creerAppareil()
            {
            try
            {
                if (Session["AdminRights"].ToString() == "False" || Session["AdminRights"].ToString() == String.Empty)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }


            using (IDal dal = new Dal())
                {
                    string nomAppareil = Request["nom_appareil"];
                    dal.creerAppareil(nomAppareil);

                    return View("Appareils", dal.obtientTousLesAppareils());
                }


            }


            public ActionResult ajouterAppareil()
            {
            try
            {
                if (Session["AdminRights"].ToString() == "False" || Session["AdminRights"].ToString() == String.Empty)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }


            using (IDal dal = new Dal())
                {
                    List<Appareil> appareils = dal.obtientTousLesAppareils();
                    ViewBag.appareils = dal.obtientTousLesAppareils();
                    return View("AjouterAppareil");
                }

            }


        [HttpPost]
        public void supprimerAppareil()
        {
            try
            {
                if (Session["AdminRights"].ToString() == "False" || Session["AdminRights"].ToString() == String.Empty)
                {
                    return ;
                }
            }
            catch (Exception)
            {
                return;
            }


            using (IDal dal = new Dal())
            {

                int id = int.Parse(Request["id_appareil"]);
                System.Diagnostics.Debug.WriteLine("Suppression de l'appareil: " + id);
                dal.supprimerAppareil(id);

            }

             

        }

       



    }
}