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
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Group.Modify(new GroupData("MyGroup", "Ivanov", "Footer"),
               new GroupData("YourGroup", "Pertrof", "VrotMneNogy"));
        }
    }
}
