using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class LoginTests :TestBase
    {
        [Test]

        public void ALoginWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();


            //action
            AccountData account = new AccountData("administrator", "root");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }


        [Test]

        public void BLoginWithInvalidCredentials()
        {
            //prepare
            app.Auth.Logout();


            //action
            AccountData account = new AccountData("admin", "12312");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }

    }
}
