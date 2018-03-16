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
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactToCreate = new ContactData("Ivan", "Ivanov");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Create(contactToCreate);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contactToCreate);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
