﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        List<Tier> tiers = TierManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            Tier tier = new Tier
            {
                TierName = "noob",
                TierLevel = 1
            };
            int result = TierManager.Insert(tier, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Tier tier = tiers.FirstOrDefault();
            tier.TierName = "Test";

            Assert.IsTrue(TierManager.Update(tier, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Tier tier = tiers.FirstOrDefault();

            Assert.AreEqual(TierManager.LoadById(tier.Id).Id, tier.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Tier> tierList = tiers;
            int expected = 3;

            Assert.AreEqual(expected, tierList.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Tier tier = tiers.FirstOrDefault();
            Assert.IsTrue(TierManager.Delete(tier.Id, true) > 0);

        }
    }
}
