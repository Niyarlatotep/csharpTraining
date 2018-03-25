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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            :base(manager)
        {
        }

        private List<ContactData> contactsCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactsCache == null)
            {
                contactsCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    string lastName = element.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                    string fistName = element.FindElement(By.CssSelector("td:nth-child(3)")).Text;
                    contactsCache.Add(new ContactData(fistName, lastName));
                }
            }            
            return new List<ContactData>(contactsCache);
        }

        public void ModifyFirstTo(ContactData newContactData) {
            manager.Navigator.OpenHomePage();            
            OpenEditing();
            FillContactForm(newContactData);
            UpdateContact();
        }

        public void CreateContactIfNoContacts(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            if (!IsElementPresent(By.CssSelector("tbody tr:nth-child(2) [href*='edit']")))
            {
                Create(contact);
            }
        }

        public void UpdateContact(){
            driver.FindElement(By.CssSelector("[name='update']")).Click();
            contactsCache = null;
        }

        public void OpenEditing() {
            driver.FindElement(By.CssSelector("tbody tr:nth-child(2) [href*='edit']")).Click();
        }

        public void DeleteFirst() {
            manager.Navigator.OpenHomePage();
            SelectFirstByCheckBox();
            DeleteAccept();
        }

        public void DeleteAccept() {
            driver.FindElement(By.CssSelector("[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactsCache = null;
        }

        public void SelectFirstByCheckBox() {
            driver.FindElement(By.CssSelector("tbody tr:nth-child(2) td:first-child")).Click();
        }

        public void Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitCreation();
            contactsCache = null;
            manager.Navigator.OpenHomePage();
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
