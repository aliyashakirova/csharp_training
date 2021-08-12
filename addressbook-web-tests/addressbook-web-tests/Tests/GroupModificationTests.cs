﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData = new GroupData("zzz");
            newGroupData.Header = "ttt";
            newGroupData.Footer = "qqq";
            app.Groups.Modify(1, newGroupData);
        }
    }
}