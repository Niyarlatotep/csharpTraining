using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager)
            :base(manager)
        {
            this.baseURL = manager.BaseURL;
        }
        public void GoToManageProjects()
        {
            if (IsElementPresent(By.CssSelector("[value='Create New Project']")))
            {
                return;
            }
            driver.FindElement(By.CssSelector("[href*='manage_overview_page']")).Click();
            driver.FindElement(By.CssSelector("p .bracket-link:nth-child(2)")).Click();
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
