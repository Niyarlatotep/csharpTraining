using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            :base(manager)
        {
        }

        internal void CreateGroupIfNotGroups(GroupData groupToCreate)
        {
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
            {
                Create(groupToCreate);
            }
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private List<GroupData> groupsCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupsCache == null)
            {
                groupsCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                List<GroupData> groups = new List<GroupData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupsCache.Add(new GroupData(element.Text));
                }               
            }
            return new List<GroupData>(groupsCache);
        }


        public void Create(GroupData group) {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitCreation();
            ReturnToGroupsPage();
        }

        public void CreateGroupIfNoGroups(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.CssSelector("form span:nth-child(5)")))
            {
                Create(group);
            }
        }
        public void DeleteFirst() {
            manager.Navigator.GoToGroupsPage();
            SelectFirstByCheckBox();
            DeleteGo();
        }

        public void Delete(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectCheckBoxById(group.Id);
            DeleteGo();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void ModifyFirstTo(GroupData newData) {
            manager.Navigator.GoToGroupsPage();          
            SelectFirstByCheckBox();
            OpenEditing();
            FillGroupForm(newData);
            Update();
        }

        public void Modify(GroupData toModify, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectCheckBoxById(toModify.Id);
            OpenEditing();
            FillGroupForm(newData);
            Update();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void OpenEditing() {
            driver.FindElement(By.CssSelector("[name='edit']")).Click();
        }

        public void Update()
        {
            driver.FindElement(By.CssSelector("[name='update']")).Click();
            groupsCache = null;
        }

        public void SelectFirstByCheckBox() {
            driver.FindElement(By.CssSelector("form span:nth-child(5) input")).Click();
        }

        public void SelectCheckBoxById(string id)
        {
            driver.FindElement(By.CssSelector($"input[value='{id}']")).Click();
        }

        public void DeleteGo() {
            driver.FindElement(By.CssSelector("[name='delete']")).Click();
            groupsCache = null;
        }

        public void SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupsCache = null;
        }

        public void FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
        }

        public void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("[name='new']")).Click();
        }
    }
}
