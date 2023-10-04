using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utNewsLetter
    {
        [TestMethod]
        public void InsertTest()
        {
            NewsLetter newsLetter = new NewsLetter
            {
                HauntedEventId = 1,
                Description = "Local Man Vanishes",
                Date = DateTime.Now
            };
            Assert.AreEqual(1, NewsLetterManager.Insert(newsLetter, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            NewsLetter newsLetter = NewsLetterManager.LoadById(1);
            newsLetter.Description = "Test";
            newsLetter.Date = DateTime.Now;
            newsLetter.HauntedEventId = 3;

            int results = NewsLetterManager.Update(newsLetter, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(5, NewsLetterManager.LoadById(5).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(6, NewsLetterManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, NewsLetterManager.Delete(1, true));
        }
    }
}
