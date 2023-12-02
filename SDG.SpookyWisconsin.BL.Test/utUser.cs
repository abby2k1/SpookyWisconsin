using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDG.SpookyWisconsin.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Test
{
    public class utUser : utBase
    {
        List<User> users = UserManager.Load();

        [TestMethod]
        public void LoadTest()
        {
            List<User> user = users;
            Assert.IsTrue(user.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            User user = new User
            {
                Username = "Test",
                Password = "password"
            };
            int result = UserManager.Insert(user, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            //User user = new User { Username = "", Password = ""};
            // bool result = new UserManager(options).Login(User);
            //Assert.IsTrue(result)
        }

        [TestMethod]
        public void LoginFail()
        {
         /*   try
            {
                User user = new User { Username = "", Password = ""};
                new UserManager(options).Login(user);
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
         */
        }

    }
}
