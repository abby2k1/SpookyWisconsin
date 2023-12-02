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
    public class utMember : utBase
    {
        List<Member> members = MemberManager.Load();
        List<Tier> tiers = TierManager.Load();
        List<NewsLetter> newsLetters = NewsLetterManager.Load();

        [TestMethod]
        public void InsertTest()
        {
            Member member = new Member
            {
                TierId = tiers.FirstOrDefault().Id,
                NewsLetterId = newsLetters.FirstOrDefault().Id,
                NewsLetterOpt = "WiscoNews",
                MemberOpt = "Freddy" 
            };
            int result = MemberManager.Insert(member, true);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void UpdateTest()
        {
            Member member = members.FirstOrDefault();
            member.NewsLetterOpt = "Test";

            Assert.IsTrue(MemberManager.Update(member, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Member member = members.FirstOrDefault();
            Assert.AreEqual(MemberManager.LoadById(member.Id).Id, member.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Member> member = members;
            int expected = 2;

            Assert.AreEqual(expected, member.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Member member = members.FirstOrDefault();
            Assert.IsTrue(MemberManager.Delete(member.Id, true) > 0);
        }
    }
}
