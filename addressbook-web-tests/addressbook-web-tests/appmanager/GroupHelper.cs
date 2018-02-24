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

        public void Delete(GroupData group) {
            manager.Navigator.GoToGroupsPage();
            SelectByCheckBox(group);
            DeleteGo();
        }

        public void Modify(GroupData groupToModify, GroupData newData) {
            manager.Navigator.GoToGroupsPage();
            SelectByCheckBox(groupToModify);
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

        public void SelectByCheckBox(GroupData group) {
            driver.FindElement(By.XPath($"//*[.='{group.Name}']/input")).Click();
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
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        public void InitGroupCreation()
        {
            driver.FindElement(By.CssSelector("[name='new']")).Click();
        }
    }
}
