using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APP_Presentation.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace APP_Presentation.Tests
{
    [TestClass]
    public class DalTests
    {
        private IDal dal;
        private BddContext bd;
        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(bd = new BddContext());
            
            dal = new Dal();
            Console.Out.WriteLine(dal.ToString());
        }

        [TestCleanup]
        public void ApresChaqueTest()
        {
            
        }


        [TestMethod]
        public void methodeTest1()
        {
            dal.CreerUtilisateur("John", "12345");
            
            List<Utilisateur> users = dal.ObtientTousLesUtilisateurs();
            Console.Out.WriteLine(users);
            Console.Out.WriteLine(users[0].Username);
            Console.Out.WriteLine(users.Count);
            Assert.IsNotNull(users);
        }


    }
}
