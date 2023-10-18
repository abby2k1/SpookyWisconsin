using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utTier : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            Tier tier = new Tier
            {
                TierName = "noob",
                TierLevel = 1
            };
            int result = new TierManager(options).Insert(tier, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tier tier = new TierManager(options).Load().FirstOrDefault();
            tier.TierName = "Test";

            Assert.IsTrue(new TierManager(options).Update(tier, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Tier tier = new TierManager(options).Load().FirstOrDefault();

            Assert.AreEqual(new TierManager(options).LoadById(tier.Id).Id, tier.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Tier> tierList = new TierManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, tierList.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Tier tier = new TierManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new TierManager(options).Delete(tier.Id, true) > 0);

        }
    }
}
