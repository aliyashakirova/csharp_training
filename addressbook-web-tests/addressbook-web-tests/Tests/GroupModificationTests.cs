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
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.IsGroupListEmpty())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "fff";
                app.Groups.Create(group);
            }
                GroupData newGroupData = new GroupData("zzz");
                newGroupData.Header = "ttt";
                newGroupData.Footer = "qqq";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(newGroupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void GroupModificationTestOnlyName()
        {
            if (app.Groups.IsGroupListEmpty())
            {
                GroupData group = new GroupData("aaa");
                group.Header = "ddd";
                group.Footer = "fff";
                app.Groups.Create(group);
            }
                GroupData newGroupData = new GroupData("zzz");
                newGroupData.Header = null;
                newGroupData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(newGroupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
