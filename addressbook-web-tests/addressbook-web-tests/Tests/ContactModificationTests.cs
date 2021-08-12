using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
            {
            ContactData newContactData = new ContactData("fn", "ln");
            newContactData.Company = "sdfsd";
            newContactData.Address = "ewerr";
            app.Contacts.Modify("0", newContactData);
            }
    }
}
