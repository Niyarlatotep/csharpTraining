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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            :base(manager)
        {
        }

        public void ModifyTo(ContactData newContactData) {
            manager.Navigator.OpenHomePage();
            OpenEditing();
            FillContactForm(newContactData);
            UpdateContact();
        }

        public void UpdateContact() {
            driver.FindElement(By.CssSelector("[name='update']")).Click();
        }

        public void OpenEditing() {
            driver.FindElement(By.CssSelector("tbody tr:nth-child(2) [href*='edit']")).Click();
        }

        public void Delete() {
            manager.Navigator.OpenHomePage();
            SelectFirstByCheckBox();
            DeleteAccept();
        }

        public void DeleteAccept() {
            driver.FindElement(By.CssSelector("[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public void SelectFirstByCheckBox() {
            driver.FindElement(By.CssSelector("tbody tr:nth-child(2) td:first-child")).Click();
        }

        public void Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitCreation();
        }
        public void FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
        }
        public void InitContactCreation()
        {
            driver.FindElement(By.CssSelector("[href='edit.php']")).Click();
        }
        public void SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
