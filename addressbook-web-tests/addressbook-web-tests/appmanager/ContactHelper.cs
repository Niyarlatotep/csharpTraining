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

        internal ContactData GetFirstContactInformationFromEditForm()
        {

            manager.Navigator.OpenHomePage();
            OpenEditingFirst();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,

                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        internal ContactData GetFirstContactInformationFromTable()
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.CssSelector("tbody tr:nth-child(2) td"));
           
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        internal ContactData GetFirstContactDetailedInformation()
        {
            manager.Navigator.OpenHomePage();
            OpenDetailedInfoFirst();

            string detailedInformation = driver.FindElement(By.CssSelector("#content")).Text;
            return new ContactData()
            {
                DetailedInformation = detailedInformation
            };
        }

        public void ModifyFirstTo(ContactData newContactData) {
            manager.Navigator.OpenHomePage();            
            OpenEditingFirst();
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

        public void OpenEditingFirst() {
            driver.FindElement(By.CssSelector("tbody tr:nth-child(2) [href*='edit']")).Click();
        }

        public void OpenDetailedInfoFirst()
        {
            driver.FindElement(By.CssSelector("tbody tr:nth-child(2) [alt='Details']")).Click();
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
