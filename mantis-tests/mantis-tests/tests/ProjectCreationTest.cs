using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData projectToCreate = new ProjectData(Guid.NewGuid().ToString(), "My first project");
            List<ProjectData> oldProjects = app.Project.GetProjectsList();
            app.Project.Create(projectToCreate);
            List<ProjectData> newProjects = app.Project.GetProjectsList();
            oldProjects.Add(projectToCreate);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
