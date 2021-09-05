using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
            {
            ContactData newContactData = new ContactData("fn", "ln");
            newContactData.Company = "sdfsd";
            newContactData.Address = "sdfsd";
            app.Contacts.Modify(newContactData);
            }

        [Test]
        public void ContactModificationTestOnlyFirstNLastNames()
        {
            ContactData newContactData = new ContactData("aaa", "bbb");
            newContactData.Company = null;
            newContactData.Address = null;
            app.Contacts.Modify(newContactData);
        }
    }
}
