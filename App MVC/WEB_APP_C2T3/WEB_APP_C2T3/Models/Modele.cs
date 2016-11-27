using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_APP_C2T3.Models
{



    public class Alerte
    {
        public int Id { get; set; }
        public virtual string message { get; set; }
        public virtual bool resolu { get; set; }
        public virtual DateTime date { get; set; }
    }

    public class EntreeGPS
    {
        public int Id { get; set; }
        public virtual string appareil { get; set; }
        public virtual double latitude { get; set; }
        public virtual double longitude { get; set; }
        public virtual DateTime date    { get; set; }
    }


    public class BddContext : DbContext
    {
        public DbSet<Alerte> Alertes { get; set; }
        public DbSet<EntreeGPS> GPS { get; set; }
    }

    public interface IDal : IDisposable
    {
        void CreerAlerte(string _message);
        void ResoudreAlerte(int id);
        List<Alerte> ObtientToutesLesAlertes();
        List<EntreeGPS> ObtientToutesLesEntreesGPS();
        void effacerAlertes();
        void CreerEntreeGPS(string id_appareil, double _latitude, double _longitude);
        void supprimerEntreeGps(int id);
    }


    public class Dal : IDal
    {
        private BddContext bdd;


        public void CreerEntreeGPS(string id_appareil, double _latitude, double _longitude)
        {
            bdd.GPS.Add(new EntreeGPS { appareil = id_appareil, latitude = _latitude, longitude = _longitude, date = DateTime.Now });
            bdd.SaveChanges();
        }

        public Dal()
        {
            bdd = new BddContext();
        }

        public void CreerAlerte(string _message)
        {
            bdd.Alertes.Add(new Alerte { message= _message, date = DateTime.Now, resolu = false });
            bdd.SaveChanges();
        }




        public List<Alerte> ObtientToutesLesAlertes()
        {
            return bdd.Alertes.ToList();
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
            return bdd.GPS.ToList();
        }
    }

}
