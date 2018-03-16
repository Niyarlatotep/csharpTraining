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
    public class ContactDeletionTests : AuthTestBase
    {
        [SetUp]
        public void CreatingTestingDdataContact()
        {
            app.Contact.CreateContactIfNoContacts(new ContactData("ToDelete First Name", "ToDelete second Name"));
        }
        [Test]
        public void ContactDeletionTest()
        {
            app.Contact.Delete();
        }
    }
}
