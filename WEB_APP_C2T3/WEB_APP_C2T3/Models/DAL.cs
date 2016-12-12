using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_APP_C2T3.Models
{
    public class Dal : IDal
    {

        //Couche d'accès aux données
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }


        public void CreerEntreeGPS(int id_appareil, double _latitude, double _longitude)
        {
            bdd.GPS.Add(new EntreeGPS { appareil = bdd.Appareils.Find(id_appareil), latitude = _latitude, longitude = _longitude, date = DateTime.Now });
            bdd.SaveChanges();
        }



        public void CreerAlerte(string _message)
        {
            bdd.Alertes.Add(new Alerte { message = _message, date = DateTime.Now, resolu = false });
            bdd.SaveChanges();
        }


        public List<Alerte> ObtientToutesLesAlertes()
        {
            return bdd.Alertes.ToList();
        }



        public void ResoudreAlerte(int id)
        {
            Alerte alerteTrouve = bdd.Alertes.FirstOrDefault(alerte => alerte.Id == id);
            if (alerteTrouve != null)
            {
                alerteTrouve.resolu = true;

                bdd.SaveChanges();
            }
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public List<EntreeGPS> ObtientToutesLesEntreesGPS()
        {
            var gps = bdd.GPS.ToList();
            var appareils = bdd.Appareils.ToList();
            return gps;
        }

        public List<Appareil> obtientTousLesAppareils()
        {
            return bdd.Appareils.ToList();
        }


        public List<Utilisateur> obtientTousLesUtilisateurs()
        {
            return bdd.Utilisateurs.ToList();
        }

        public void creerAppareil(string _nom_appareil)
        {
            bdd.Appareils.Add(new Appareil { nom_appareil = _nom_appareil });
            bdd.SaveChanges();
        }

        public void supprimerAppareil(int id)
        {
            bdd.Database.ExecuteSqlCommand("delete from appareils where Id = " + id);
        }

        public void effacerAlertes()
        {
            bdd.Database.ExecuteSqlCommand("delete from alertes");
        }

        public void supprimerEntreeGps(int id)
        {
            System.Diagnostics.Debug.WriteLine("delete from EntreeGPS where id = " + id);
            bdd.Database.ExecuteSqlCommand("delete from EntreeGPS where Id = " + id);
        }

      public  void creerUtilisateur(string _username, string _password, string _nom, string _prenom, bool _administrateur)
        {
            string _salt = Utilisateur.getSalt();
            string pwd = Utilisateur.CreateSHAHash(_password, _salt);
            bdd.Utilisateurs.Add(new Utilisateur { username = _username,password = pwd, salt = _salt, prenom = _prenom, nom= _nom, administrateur = _administrateur});
            bdd.SaveChanges();
        }
    }

}