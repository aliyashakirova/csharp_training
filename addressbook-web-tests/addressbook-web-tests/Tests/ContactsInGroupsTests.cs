using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactsInGroupsTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            
            int numberOfGroups = GroupData.GetAll().Count();
            int numberOfContacts = ContactData.GetAll().Count();
            if (numberOfGroups == 0)
            {
                GroupData newGroup = new GroupData("name");
                newGroup.Header = "header";
                newGroup.Footer = "footer";
                app.Groups.Create(newGroup);
            }
            if (numberOfContacts == 0)
            {
                ContactData newContact = new ContactData("fn", "ln");
                newContact.Company = "ccc";
                newContact.Address = "aaa";
                app.Contacts.Create(newContact);
            }
            GroupData group = GroupData.GetAll()[0];
      
            List<ContactData> oldList = group.GetContacts();
            //ContactData contact = ContactData.GetAll().Except(oldList).First();
            List<ContactData> contactList = ContactData.GetAll();
            foreach (ContactData c in oldList)
            {
                contactList.Remove(c);
            }
            if (contactList.Count() == 0)
            {
                ContactData newContact = new ContactData("fn2", "ln2");
                newContact.Company = "ccc2";
                newContact.Address = "aaa2";
                app.Contacts.Create(newContact);
                contactList = ContactData.GetAll();
                foreach (ContactData c in oldList)
                {
                    contactList.Remove(c);
                }
            }
           
                ContactData contact = contactList[0];

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
        [Test]
        public void TestRemoveContactFromGroup()
        {

            int numberOfGroups = GroupData.GetAll().Count();
            int numberOfContacts = ContactData.GetAll().Count();
            if (numberOfGroups == 0)
            {
                GroupData newGroup = new GroupData("name");
                newGroup.Header = "header";
                newGroup.Footer = "footer";
                app.Groups.Create(newGroup);
            }
            if (numberOfContacts == 0)
            {
                ContactData newContact = new ContactData("fn", "ln");
                newContact.Company = "ccc";
                newContact.Address = "aaa";
                app.Contacts.Create(newContact);
            }
            ContactData contact = ContactData.GetAll()[0];
            GroupData group = GroupData.GetAll()[0];
            
            List<ContactData> oldList = group.GetContacts();
            int numberOfContactsInOldList = oldList.Count();
            if (numberOfContactsInOldList == 0)
            {
                app.Contacts.AddContactToGroup(contact, group);
            }
            contact = group.GetContacts()[0];

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
