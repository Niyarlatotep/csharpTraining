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

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void Create(GroupData group) {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitCreation();
            ReturnToGroupsPage();
        }

        public void CreateGroupIfNoGroups(GroupData group) {
            if (!IsElementPresent(By.CssSelector("form span:nth-child(5)")))
            {
                Create(group);
            }
        }
        public void Delete() {
            manager.Navigator.GoToGroupsPage();
            SelectFirstByCheckBox();
            DeleteGo();
        }

        public void ModifyTo(GroupData newData) {
            manager.Navigator.GoToGroupsPage();          
            SelectFirstByCheckBox();
            OpenEditing();
            FillGroupForm(newData);
            Update();
        }

        public void OpenEditing() {
            driver.FindElement(By.CssSelector("[name='edit']")).Click();
        }

        public void Update()
        {
            driver.FindElement(By.CssSelector("[name='update']")).Click();
        }

        public void SelectFirstByCheckBox() {
            driver.FindElement(By.CssSelector("form span:nth-child(5) input")).Click();
        }

        public void DeleteGo() {
            driver.FindElement(By.CssSelector("[name='delete']")).Click();
        }

        public void SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
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
