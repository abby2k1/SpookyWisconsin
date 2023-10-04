using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    [TestClass]
    public class utMember
    {
        [TestMethod]
        public void InsertTest()
        {
            Member member = new Member
            {
                TierId = 1,
                NewsLetterId = 2,
                NewsLetterOpt = "WiscoNews",
                MemberOpt = "Freddy" 
            };
            Assert.AreEqual(1, MemberManager.Insert(member, true));

        }

        [TestMethod]
        public void UpdateTest()
        {
            Member member = MemberManager.LoadById(1);
            member.TierId = 3;
            member.NewsLetterId = 1;
            member.NewsLetterOpt = "Test";
            member.MemberOpt = "Test";

            int results = MemberManager.Update(member, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Assert.AreEqual(4, MemberManager.LoadById(4).Id);
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, MemberManager.Load().Count);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(1, MemberManager.Delete(1, true));
        }
    }
}
