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
        List<NewsLetter> newsLetters = NewsLetterManager.Load();
        List<HauntedEvent> hauntedEvents = HauntedEventManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            NewsLetter newsLetter = new NewsLetter
            {
                HauntedEventId = hauntedEvents.FirstOrDefault().Id,
                Description = "Local Man Vanishes",
                Date = DateTime.Now
            };
            int result = NewsLetterManager.Insert(newsLetter, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            NewsLetter newsLetter = newsLetters.FirstOrDefault();
            newsLetter.Description = "Test";

            Assert.IsTrue(NewsLetterManager.Update(newsLetter, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            NewsLetter newsLetter = newsLetters.FirstOrDefault();
            Assert.AreEqual(NewsLetterManager.LoadById(newsLetter.Id).Id, newsLetter.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<NewsLetter> newsLetter = newsLetters;
            int expected = 3;

            Assert.AreEqual(expected, newsLetter.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            NewsLetter newsletter = newsLetters.FirstOrDefault();
            Assert.IsTrue(NewsLetterManager.Delete(newsletter.Id, true) > 0);    
        }
    }
}
