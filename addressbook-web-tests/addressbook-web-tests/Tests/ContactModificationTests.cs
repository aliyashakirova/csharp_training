using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
            {
                if (app.Contacts.GetContactNumber() == 0)
                {
                ContactData contact = new ContactData("fn", "ln");
                contact.Company = "ccc";
                contact.Address = "aaa";
                app.Contacts.Create(contact);
                }
                ContactData newContactData = new ContactData("fn", "ln");
                newContactData.Company = "sdfsd";
                newContactData.Address = "sdfsd";
                app.Contacts.Modify(newContactData);
            }

        [Test]
        public void ContactModificationTestOnlyFirstNLastNames()
        {
            if (app.Contacts.GetContactNumber() == 0)
            {
                ContactData contact = new ContactData("fn", "ln");
                contact.Company = "ccc";
                contact.Address = "aaa";
                app.Contacts.Create(contact);
            }
                ContactData newContactData = new ContactData("aaa", "bbb");
                newContactData.Company = null;
                newContactData.Address = null;
                app.Contacts.Modify(newContactData);

        }
    }
}
