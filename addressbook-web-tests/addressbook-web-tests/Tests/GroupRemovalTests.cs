using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.IsGroupListEmpty())
            {
                GroupData group = new GroupData("");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }
            app.Groups.Remove();
        }
    }
}
