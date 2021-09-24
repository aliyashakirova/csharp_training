using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests :AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            //System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
            app.Navigator.GoToHomePage();
            app.Contacts.FillOutSearchCriteria("a");
            Assert.AreEqual(app.Contacts.GetNumberOfSearchResults(), app.Contacts.GetContactNumber());
        }
    }
}
