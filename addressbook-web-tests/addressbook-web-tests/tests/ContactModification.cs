﻿using System;
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
    public class ContactModificationTests : ContactTestBase
    {
        [SetUp]
        public void CreatingTestingDdataContact()
        {
            app.Contact.CreateContactIfNoContacts(new ContactData("ToModify First Name", "ToModify second Name"));
        }
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactToModify = new ContactData("Petr", "Pupkin");
            

            List<ContactData> oldContact = ContactData.GetAll();

            app.Contact.Modify(oldContact[0], contactToModify);

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact[0] = contactToModify;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
