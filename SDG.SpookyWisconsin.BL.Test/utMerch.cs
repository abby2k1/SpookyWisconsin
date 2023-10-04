using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utMerch
    {
        [TestMethod]
        public void InsertTest()
        {
            Merch merch = new Merch
            {
                MerchName = "Wisco",
                InStkQty = 0,
                Description = "T-Shirt",
                Cost = 23
            };
            Assert.AreEqual(1, MerchManager.Insert(merch, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Merch merch = MerchManager.LoadById(1);
            merch.MerchName = "Test";
            merch.InStkQty = 2;
            merch.Description = "Test";
            merch.Cost = 30;

            int results = MerchManager.Update(merch, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(4, MerchManager.LoadById(4).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, MerchManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, MerchManager.Delete(1, true));
        }
    }
}
