using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utTier
    {
        [TestMethod]
        public void InsertTest()
        {
            Tier tier = new Tier
            {
                TierName = "noob",
                TierLevel = 1
            };
            Assert.AreEqual(1, TierManager.Insert(tier, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tier tier = TierManager.LoadById(2);
            tier.TierName = "Test";
            tier.TierLevel = 2;

            int results = TierManager.Update(tier, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(3, TierManager.LoadById(3).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, TierManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, TierManager.Delete(1, true));
        }
    }
}
