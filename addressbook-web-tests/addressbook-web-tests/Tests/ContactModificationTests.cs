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
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void FirstContactModificationTest()
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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];
            app.Contacts.Modify(newContactData, oldData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactNumber());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Firstname = newContactData.Firstname;
            oldContacts[0].Lastname = newContactData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
            }
        }


        [Test]
        public void LastContactModificationTest()
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

            List<ContactData> oldContacts = ContactData.GetAll();
            var lastContactIndex = app.Contacts.GetLastContactIndex(app.Contacts.GetLastContact());
            ContactData oldContactData = oldContacts[lastContactIndex];
            app.Contacts.OpenContact(app.Contacts.GetLastContact());
            app.Contacts.Modify(newContactData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactNumber());

            List<ContactData> newContacts = ContactData.GetAll();
            lastContactIndex = app.Contacts.GetLastContactIndex(app.Contacts.GetLastContact());
            oldContacts[lastContactIndex].Firstname = newContactData.Firstname;
            oldContacts[lastContactIndex].Lastname = newContactData.Lastname;

            app.Navigator.GoToHomePage();
            app.Contacts.OpenContact(app.Contacts.GetLastContact());
            ContactData newContact = app.Contacts.GetContactData();
            Assert.AreEqual(newContactData.Firstname, newContact.Firstname);

            app.Navigator.GoToHomePage();
            oldContacts.Sort();
            newContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
            }
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



                List<ContactData> oldContacts = app.Contacts.GetContactList();
                var lastContactIndex = app.Contacts.GetLastContactIndex(app.Contacts.GetLastContact());
                ContactData oldContactData = oldContacts[lastContactIndex];
                app.Contacts.OpenContact(app.Contacts.GetLastContact());
                app.Contacts.Modify(newContactData);

                Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactNumber());

                List<ContactData> newContacts = app.Contacts.GetContactList();
                lastContactIndex = app.Contacts.GetLastContactIndex(app.Contacts.GetLastContact());
                oldContacts[lastContactIndex].Firstname = newContactData.Firstname;
                oldContacts[lastContactIndex].Lastname = newContactData.Lastname;

                app.Navigator.GoToHomePage();
                app.Contacts.OpenContact(app.Contacts.GetLastContact());
                ContactData newContact = app.Contacts.GetContactData();
                Assert.AreEqual(newContactData.Firstname, newContact.Firstname);
                Assert.AreEqual(newContactData.Lastname, newContact.Lastname);

                app.Navigator.GoToHomePage();
                oldContacts.Sort();
                newContacts.Sort();
                Assert.AreEqual(oldContacts, newContacts);


                foreach (ContactData contact in newContacts)
                {
                    if (contact.Id == oldContactData.Id)
                {
                    Assert.AreEqual(newContactData.Firstname, contact.Firstname);
                    Assert.AreEqual(newContactData.Lastname, contact.Lastname);
                }
                }
        }
    }
}
