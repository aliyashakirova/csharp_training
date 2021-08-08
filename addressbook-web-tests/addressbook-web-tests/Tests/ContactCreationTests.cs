﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("fn", "ln");
            contact.Company = "ccc";
            contact.Address = "aaa";
            app.Contacts.Create(contact);
        }


        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            app.Contacts.Create(contact);
        }
    }
}
