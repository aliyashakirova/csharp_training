using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
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
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactNumber());
            List<ContactData> newContacts = ContactData.GetAll();

            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);


            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
