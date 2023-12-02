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
        List<Merch> merchs = MerchManager.Load();


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
            int result = MerchManager.Insert(merch, true);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void UpdateTest()
        {
            Merch merch = merchs.FirstOrDefault();
            merch.MerchName = "Test";

            Assert.IsTrue(MerchManager.Update(merch, true) > 0);    
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Merch merch = merchs.FirstOrDefault();
            Assert.AreEqual(MerchManager.LoadById(merch.Id).Id, merch.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Merch> merch = merchs;
            int expected = 3;

            Assert.AreEqual(expected, merch.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Merch merch = merchs.FirstOrDefault();
            Assert.IsTrue(MerchManager.Delete(merch.Id, true) > 0);
        }
    }
}
