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
        [Test]
        public void TestDeletingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
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
