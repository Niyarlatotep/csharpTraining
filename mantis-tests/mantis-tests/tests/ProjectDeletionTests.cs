using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeletionTests : TestBase
    {
        [SetUp]
        public void CreatingTestingProjectData()
        {
            app.Project.CreateProjectIfNoProjects(new ProjectData(Guid.NewGuid().ToString(), "Description"));
        }

        [Test]
        public void ProjectDeletionTest()
        {            
            List<ProjectData> oldProjects = app.Project.GetProjectsList();
            app.Project.DeleteFirst();
            List<ProjectData> newProjects = app.Project.GetProjectsList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
            
        }
    }
}
