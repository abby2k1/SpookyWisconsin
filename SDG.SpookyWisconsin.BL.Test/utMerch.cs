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
    public class utMerch : utBase
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
            int result = new MerchManager(options).Insert(merch, true);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void UpdateTest()
        {
            Merch merch = new MerchManager(options).Load().FirstOrDefault();
            merch.MerchName = "Test";

            Assert.IsTrue(new MerchManager(options).Update(merch, true) > 0);    
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Merch merch = new MerchManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new MerchManager(options).LoadById(merch.Id).Id, merch.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Merch> merches = new MerchManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, merches.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Merch merch = new MerchManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new MerchManager(options).Delete(merch.Id, true) > 0);
        }
    }
}
