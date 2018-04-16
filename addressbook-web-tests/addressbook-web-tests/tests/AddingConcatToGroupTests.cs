using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class AddingConcatToGroupTests : AuthTestBase
    {
        [SetUp]
        public void PresetTestingData()
        {
            app.Group.CreateGroupIfNoGroups(new GroupData("Group for Adding"));
            app.Contact.CreateContactIfNoContactsWithoutGroup(new ContactData("Contcat First Name", "ToDelete second Name"));            
        }
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contactWithoutGroup = ContactData.GetAll().Except(group.GetContacts()).First();

            app.Contact.AddContactToGroup(contactWithoutGroup, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contactWithoutGroup);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
