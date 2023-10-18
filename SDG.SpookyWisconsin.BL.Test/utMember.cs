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
                TierId = new TierManager(options).Load().FirstOrDefault().Id,
                NewsLetterId = new NewsLetterManager(options).Load().FirstOrDefault().Id,
                NewsLetterOpt = "WiscoNews",
                MemberOpt = "Freddy" 
            };
            int result = new MemberManager(options).Insert(member, true);
            Assert.IsTrue(result > 0);

        }

        [TestMethod]
        public void UpdateTest()
        {
            Member member = new MemberManager(options).Load().FirstOrDefault();
            member.NewsLetterOpt = "Test";

            Assert.IsTrue(new MemberManager(options).Update(member, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Member member = new MemberManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new MemberManager(options).LoadById(member.Id).Id, member.Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            List<Member> members = new MemberManager(options).Load();
            int expected = 2;

            Assert.AreEqual(expected, members.Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Member member = new MemberManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new MemberManager(options).Delete(member.Id, true) > 0);
        }
    }
}
