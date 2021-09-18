using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("fn", "ln");
            contact.Company = "ccc";
            contact.Address = "aaa";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            //Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
            oldContacts.Add(new ContactData(contact.Firstname, contact.Lastname) { Id = app.Contacts.GetLastContact().ToString() });
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(new ContactData(contact.Firstname, contact.Lastname) { Id = app.Contacts.GetLastContact().ToString() });
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void BadNameContactCreationTest()
        {
            ContactData contact = new ContactData("a'", "b'");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(new ContactData(contact.Firstname, contact.Lastname) { Id = app.Contacts.GetLastContact().ToString() });
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
