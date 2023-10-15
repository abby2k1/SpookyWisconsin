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
        [TestMethod]
        public void InsertTest()
        {
            Member member = new Member
            {
                TierId = TierManager.Load().FirstOrDefault().Id,
                NewsLetterId = NewsLetterManager.Load().FirstOrDefault().Id,
                NewsLetterOpt = "WiscoNews",
                MemberOpt = "Freddy" 
            };
            int result = MemberManager.Insert(member, true);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void UpdateTest()
        {
            Member member = MemberManager.Load().FirstOrDefault();
            member.NewsLetterOpt = "Test";

            Assert.IsTrue(MemberManager.Update(member, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Member member = MemberManager.Load().FirstOrDefault();
            Assert.AreEqual(MemberManager.LoadById(member.Id).Id, member.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Member> members = MemberManager.Load();
            int expected = 2;

            Assert.AreEqual(expected, members.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Member member = MemberManager.Load().FirstOrDefault();
            Assert.IsTrue(MemberManager.Delete(member.Id, true) > 0);
        }
    }
}
