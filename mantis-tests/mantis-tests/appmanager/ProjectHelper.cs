using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager)
            :base(manager)
        {
        }


        public List<ProjectData> GetProjectsList()
        {

            List<ProjectData>  projects = new List<ProjectData>();                                    

            manager.Navigator.GoToManageProjects();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//*[@value='Create New Project']/ancestor::tbody/*[@class][not(@class='row-category')]"));
            
            foreach (IWebElement element in elements)
            {
                string name = element.FindElement(By.CssSelector("[href*='manage_proj_edit_page']")).Text;
                string description = element.FindElement(By.CssSelector("td:nth-child(5)")).Text;                
                projects.Add(new ProjectData(name, description));
            }
            return projects;
        }        

        public void CreateProjectIfNoProjects(ProjectData project)
        {
            manager.Navigator.GoToManageProjects();
            if (GetProjectsList().Count == 0)
            {
                Create(project);
            }
        }      
       
        public void DeleteFirst() {
            manager.Navigator.GoToManageProjects();
            OpenFirstProject();
            DeleteProject();
        }

        private void DeleteProject()
        {
            driver.FindElement(By.CssSelector("[value='Delete Project']")).Click();
            driver.FindElement(By.CssSelector("[value='Delete Project']")).Click();
        }

        public void OpenFirstProject() {
            driver.FindElement(By.CssSelector("[href*='manage_proj_edit_page']")).Click();
        }
       
        public void Create(ProjectData project)
        {
            manager.Navigator.GoToManageProjects();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitCreation();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("[value='Create New Project']")).Count > 0);
        }
        public void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Description);
        }
        public void InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("[value='Create New Project']")).Click();
        }
        public void SubmitCreation()
        {
            driver.FindElement(By.CssSelector("[value='Add Project']")).Click();
        }              
    }
}
