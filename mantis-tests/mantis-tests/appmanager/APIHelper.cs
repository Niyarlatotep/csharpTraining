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
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projectsList = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible("administrator", "root");
            for (int i=0; i < projects.Length; i++)
            {
                Mantis.ProjectData currentProject = projects[i];
                projectsList.Add(new ProjectData(currentProject.name, currentProject.description) { Id = currentProject.id });
            }
            return projectsList;
        }

        public void AddNewProject(ProjectData project)
        {
            Mantis.ProjectData mantisProject = new Mantis.ProjectData()
            {
                name = project.Name,
                description = project.Description
            };           
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();

            client.mc_project_add("administrator", "root", mantisProject);
        }

        public void AddNewProjectIfNoProjects(ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible("administrator", "root");
            if (projects.Length == 0)
            {
                AddNewProject(project);
            }
        }
    }
}
