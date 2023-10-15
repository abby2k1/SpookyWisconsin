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
    public class utNewsLetter : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            NewsLetter newsLetter = new NewsLetter
            {
                HauntedEventId = HauntedEventManager.Load().FirstOrDefault().Id,
                Description = "Local Man Vanishes",
                Date = DateTime.Now
            };
            int result = NewsLetterManager.Insert(newsLetter, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            NewsLetter newsLetter = NewsLetterManager.Load().FirstOrDefault();
            newsLetter.Description = "Test";

            Assert.IsTrue(NewsLetterManager.Update(newsLetter, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            NewsLetter newsLetter = NewsLetterManager.Load().FirstOrDefault();
            Assert.AreEqual(NewsLetterManager.LoadById(newsLetter.Id).Id, newsLetter.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<NewsLetter> newsLetters = NewsLetterManager.Load();
            int expected = 3;

            Assert.AreEqual(expected, newsLetters.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            NewsLetter newsletter = NewsLetterManager.Load().FirstOrDefault();
            Assert.IsTrue(NewsLetterManager.Delete(newsletter.Id, true) > 0);    
        }
    }
}
