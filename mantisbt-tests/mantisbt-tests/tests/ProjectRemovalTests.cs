using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            if (app.Projects.IsProjectsListEmpty())
            {
                ProjectData project = new ProjectData("testfdgdf");
                app.Projects.Create(project);
            }

            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            ProjectData toBeRemoved = oldProjects[0];
            app.Projects.Remove(toBeRemoved);
            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectsNumber());
            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }
        }
    }
}
