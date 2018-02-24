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
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void GroupDeletionTest()
        {
            app.Group.Delete(new GroupData("MyGroup", "Ivanov", "Footer"));
        }
    }
}
