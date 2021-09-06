using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contacts.GetContactNumber() == 0)
            {
                ContactData contact = new ContactData("fn", "ln");
                contact.Company = "ccc";
                contact.Address = "aaa";
                app.Contacts.Create(contact);
            }
                app.Contacts.Remove();

        }
    }
}
