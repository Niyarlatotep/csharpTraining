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
    public class ContactModificationTests : AuthTestBase
    {
        [SetUp]
        public void CreatingTestingDdataContact()
        {
            app.Contact.CreateContactIfNoContacts(new ContactData("ToModify First Name", "ToModify second Name"));
        }
        [Test]
        public void ContactModificationTest()
        {
            app.Contact.ModifyTo(new ContactData("Petr", "Pupkin"));
        }
    }
}
