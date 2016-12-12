using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_APP_C2T3.Models
{

    public class BddContext : DbContext
    {
        public DbSet<Alerte> Alertes { get; set; }
        public DbSet<EntreeGPS> GPS { get; set; }
        public DbSet<Appareil> Appareils { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }

}
