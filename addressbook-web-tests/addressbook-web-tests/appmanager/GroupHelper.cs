﻿using System;
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

        public List<GroupData> GetGroupList()
        {
            manager.Navigator.GoToGroupsPage();
            List <GroupData> groups = new List<GroupData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }


        public void Create(GroupData group) {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitCreation();
            ReturnToGroupsPage();
        }

        public void CreateGroupIfNoGroups(GroupData group) {
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

        public void ModifyFirstTo(GroupData newData) {
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
