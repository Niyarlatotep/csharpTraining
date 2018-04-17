using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletion : TestBase
    {
        [SetUp]
        public void CreatingTestingDdataGroup()
        {
            app.Groups.CreateGroupIfNoEnoughGroups(new GroupData("Group for Deleting"));
        }

        [Test]
        public void TestGroupDeletion()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.DeleteFirst();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
