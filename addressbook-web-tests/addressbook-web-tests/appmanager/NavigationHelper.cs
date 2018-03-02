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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager)
            :base(manager)
        {
            this.baseURL = manager.BaseURL;
        }
        public void GoToGroupsPage()
        {
            if (IsElementPresent(By.CssSelector("[action*='group'] [name='new']")))
            {
                return;
            }
            driver.FindElement(By.CssSelector("[href='group.php']")).Click();
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
