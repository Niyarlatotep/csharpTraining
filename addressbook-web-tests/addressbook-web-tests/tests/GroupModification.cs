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
    public class GroupModificationTests : GroupTestBase
    {

        [SetUp]
        public void CreatingTestingDdataGroup()
        {
            app.Group.CreateGroupIfNoGroups(new GroupData("Group for Modifying"));
        }
        [Test]
        public void GroupModificationTest()
        {
            GroupData modifyGroup = new GroupData("Your", "Ivanov", "Footer111");
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Group.Modify(oldGroups[0], modifyGroup);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0] = modifyGroup;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }      
    }
}
