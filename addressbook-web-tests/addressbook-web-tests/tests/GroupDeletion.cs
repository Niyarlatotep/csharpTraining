using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
            app.Group.Delete();
        }
    }
}
