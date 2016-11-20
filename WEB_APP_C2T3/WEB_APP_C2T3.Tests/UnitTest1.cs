using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WEB_APP_C2T3.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace WEB_APP_C2T3.Tests
{
    [TestClass]
    public class DalTests
    {
        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());
        }


        [TestMethod]
        public void CreerRestaurant_AvecUnNouveauRestaurant_ObtientTousLesRestaurantsRenvoitBienLeRestaurant()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerAlerte("Le serveur a pris feu");
                List<Alerte> alertes = dal.ObtientToutesLesAlertes();

                Assert.IsNotNull(alertes);
                Assert.AreEqual(1, alertes.Count);
                Assert.AreEqual("Le serveur a pris feu", alertes[0].message);
                
            }
        }
    }
}
