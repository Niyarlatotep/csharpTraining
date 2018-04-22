using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeletionTestsAPI : TestBase
    {
        [Test]
        public void ProjectCreationTestAPI()
        {
            ProjectData projectToCreate = new ProjectData(Guid.NewGuid().ToString(), "My first project");
            List<ProjectData> oldProjects = app.API.GetProjectsList();
            app.Project.Create(projectToCreate);
            List<ProjectData> newProjects = app.API.GetProjectsList();
            oldProjects.Add(projectToCreate);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
