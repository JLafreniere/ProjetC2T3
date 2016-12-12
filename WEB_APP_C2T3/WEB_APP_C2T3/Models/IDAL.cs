using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_APP_C2T3.Models
{
    public interface IDal : IDisposable
    {

        //Interface définissant le contenu de la classe DAL (Data Access Layer)
        void CreerAlerte(string _message);
        void creerAppareil(string _nom_appareil);
        void CreerEntreeGPS(int id_appareil, double _latitude, double _longitude);
        void creerUtilisateur(string username, string password, string nom, string prenom,bool _administrateur);

        List<Alerte> ObtientToutesLesAlertes();
        List<Utilisateur> obtientTousLesUtilisateurs();
        List<EntreeGPS> ObtientToutesLesEntreesGPS();
        List<Appareil> obtientTousLesAppareils();


        void effacerAlertes();
        void supprimerAppareil(int id);
        void supprimerEntreeGps(int id);
        void ResoudreAlerte(int id);

    }
}
