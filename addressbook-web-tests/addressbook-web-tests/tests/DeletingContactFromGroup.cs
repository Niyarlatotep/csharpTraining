using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class DeletingContactFromGroup : AuthTestBase
    {
        [SetUp]
        public void PresetTestingData()
        {
            app.Group.CreateGroupIfNoGroups(new GroupData("Group for Adding"));
            app.Contact.CreateContactIfNoContacts(new ContactData("ToDelete First Name", "ToDelete second Name"));            
            app.Contact.AddContactToGroupIfNoConatctsWithGroup();
        }

        [Test]
        public void TestDeletingContactFromGroup()
        {
            GroupData group = GroupData.GetGroupWithContacts()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contactToDelete = ContactData.GetAll().Intersect(group.GetContacts()).First();

            app.Contact.DeleteContactFromGroup(contactToDelete, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactToDelete);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
