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
                HauntedEventId = new HauntedEventManager(options).Load().FirstOrDefault().Id,
                Description = "Local Man Vanishes",
                Date = DateTime.Now
            };
            int result = new NewsLetterManager(options).Insert(newsLetter, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            NewsLetter newsLetter = new NewsLetterManager(options).Load().FirstOrDefault();
            newsLetter.Description = "Test";

            Assert.IsTrue(new NewsLetterManager(options).Update(newsLetter, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            NewsLetter newsLetter = new NewsLetterManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new NewsLetterManager(options).LoadById(newsLetter.Id).Id, newsLetter.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<NewsLetter> newsLetters = new NewsLetterManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, newsLetters.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            NewsLetter newsletter = new NewsLetterManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new NewsLetterManager(options).Delete(newsletter.Id, true) > 0);    
        }
    }
}
