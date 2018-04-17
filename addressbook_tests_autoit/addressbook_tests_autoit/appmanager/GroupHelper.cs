

using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        internal void CreateGroupIfNoEnoughGroups(GroupData groupData)
        {
            if (GetGroupList().Count <= 1)
            {
                Add(groupData);
            }
        }

        public List<GroupData> GetGroupList()
        {
            OpenGroupsDialogue();
            List<GroupData> list = new List<GroupData>();
            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", ""
                );

            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, ""
                );

                list.Add(new GroupData(){ Name = item });
            }
            CloseGroupsDialogue();
            return list;
        }

        internal void DeleteFirst()
        {
            OpenGroupsDialogue();
            SelectFirstGroup();
            StartDeleting();
            ApproveDeletion();
        }

        private void ApproveDeletion()
        {
            aux.WinWait(DELGROUPWINTITLE);
            aux.ControlClick(DELGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        private void StartDeleting()
        {            
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        }

        private void SelectFirstGroup()
        {
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#", "");
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialogue()
        {            
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
    }
}