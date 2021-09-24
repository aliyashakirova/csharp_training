using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationEdit()
        {
            ContactData fromTable = app.Contacts.GetContactInfoFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationInfo()
        {
            ContactData fromTable = app.Contacts.GetAllContactInfoFromTable(0);
            ContactData fromInfoPage= app.Contacts.GetContactInfoFromInfoPage(0);

            //verification
            Assert.AreEqual(fromTable, fromInfoPage);
            Assert.AreEqual(fromTable.AllContactInfo, fromInfoPage.AllContactInfo);


        }
    }
}
