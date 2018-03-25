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
    public class TestContactDetailedInformation : AuthTestBase
    {
        [Test]
        public void TestDetailedInformation()
        {
            ContactData fromEditForm = app.Contact.GetFirstContactInformationFromEditForm();
            ContactData fromDetailed = app.Contact.GetFirstContactDetailedInformation();

            Console.WriteLine(fromEditForm.DetailedInformation);
            Console.WriteLine(fromDetailed.DetailedInformation);
            Assert.AreEqual(fromEditForm.DetailedInformation, fromDetailed.DetailedInformation);
        }
    }
}
