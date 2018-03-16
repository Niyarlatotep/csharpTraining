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
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData testGroup = new GroupData("MyGroup", "groupHeader", "groupFooter");

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(testGroup);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(testGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);            
        }
    }
}
