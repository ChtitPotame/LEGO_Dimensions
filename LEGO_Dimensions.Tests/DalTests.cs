using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LEGO_Dimensions.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace LEGO_Dimensions.Tests
{
    [TestClass]
    public class DalTests
    {
        [TestInitialize]
        public void Init_AvantChaquetest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());
        }

        [TestMethod]
        public void CreerUnivers_AvecUnNouvelUnivers()
        {
            using(IDal dal = new Dal())
            {
                dal.CreerUnivers("LEGO : Le film");
                List<Univers> univers = dal.ObtientTousLesUnivers();

                Assert.IsNotNull(univers);
                Assert.AreEqual(1, univers.Count);
                Assert.AreEqual("LEGO : Le film", univers[0].Nom);
            }
        }

        [TestMethod]
        public void ModifierUnivers_CreerNouvelUniversEtChangerNom()
        {
            using (IDal dal = new Dal())
            {
                dal.CreerUnivers("LEGO : Le film");
                List<Univers> univers = dal.ObtientTousLesUnivers();
                int id = univers.First(u => u.Nom == "LEGO : Le film").Id;

                dal.ModifierUnivers(id, "Jurassic World");

                univers = dal.ObtientTousLesUnivers();
                Assert.IsNotNull(univers);
                Assert.AreEqual(1, univers.Count);
                Assert.AreEqual("Jurassic World", univers[0].Nom);
            }
        }
    }
}
