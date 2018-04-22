using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeletionTestsAPIHelper : TestBase
    {
        [SetUp]
        public void CreatingTestingProjectData()
        {
            app.API.AddNewProjectIfNoProjects(new ProjectData(Guid.NewGuid().ToString(), "Description"));
        }

        [Test]
        public void ProjectDeletionTestAPI()
        {
            List<ProjectData> oldProjects = app.API.GetProjectsList();
            app.Project.DeleteFirst();
            List<ProjectData> newProjects = app.API.GetProjectsList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);         
        }
    }
}
