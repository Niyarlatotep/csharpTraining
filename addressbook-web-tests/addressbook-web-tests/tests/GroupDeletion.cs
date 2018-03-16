using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeletionTests : AuthTestBase
    {
        [SetUp]
        public void CreatingTestingDdataGroup()
        {
            app.Group.CreateGroupIfNoGroups(new GroupData("Group for Deleting"));
        }
        [Test]
        public void GroupDeletionTest()
        {
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.DeleteFirst();
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
