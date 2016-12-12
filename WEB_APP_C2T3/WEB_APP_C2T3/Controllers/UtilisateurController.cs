using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_APP_C2T3.Models;

namespace WEB_APP_C2T3.Controllers
{
    public class UtilisateurController : Controller
    {
        [HttpPost]
        public ActionResult ConnecterUtilisateur()
        {



            string username = Request["Username"];
            string pwd = Request["Password"];

            using (IDal dal = new Dal())
            {
                List<Utilisateur> users = dal.obtientTousLesUtilisateurs();

                var utilisateur =
                (from u in users
                where u.username == username && Utilisateur.CreateSHAHash(pwd, u.salt) == u.password
                select u).FirstOrDefault();

                Session["user"] = true;
                Session["uid"] = utilisateur.Id;
                Session["AdminRights"] = utilisateur.administrateur;




                return RedirectToAction("Accueil", "Home");
            }
        }


        [HttpPost]
        public ActionResult DeconnecterUtilisateur()
        {


            Session["uid"] = 0;
            Session["AdminRights"] = false;
            return RedirectToAction("Accueil", "Home");
        }





        [HttpPost]
        public ActionResult creerUtilisateur()
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




            string _username = Request["username"].ToString();
            string _password = Request["password"].ToString();
            string _nom = Request["nom"].ToString();
            string _prenom = Request["prenom"].ToString();
            bool _AdminRights = false;

            if (Request["administrateur"].ToString() == "True")
                _AdminRights = true;
            else
                _AdminRights = false;
            using (IDal dal = new Dal())
            {
                dal.creerUtilisateur(_username, _password, _nom, _prenom, _AdminRights);
            }

            return RedirectToAction("Accueil", "Home");

        }

        




        public ActionResult creer()
        {
            try { 
            if (Session["AdminRights"].ToString() == "False" || Session["AdminRights"].ToString() == String.Empty)
            {
                return HttpNotFound();
            }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }

            return View("CreerUtilisateur");

        }


        public ActionResult Utilisateurs()
        {

            try
            {
                System.Diagnostics.Debug.WriteLine(Session["AdminRights"].ToString());
                if (Session["AdminRights"].ToString() == "False" || Session["AdminRights"].ToString() == String.Empty)
                {
                    
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }


            using (IDal dal = new Dal())
            {
                List<Utilisateur> users = dal.obtientTousLesUtilisateurs();
                return View("Utilisateurs", users);
            }
        }
    }

    
}