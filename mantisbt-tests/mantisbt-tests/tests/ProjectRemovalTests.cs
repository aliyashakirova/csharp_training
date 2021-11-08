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
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            if (app.Projects.IsProjectsListEmpty())
            {
                ProjectData project = new ProjectData("testfdgdf");
                //app.Projects.Create(project);
                app.API.APICreateProject(account, project);
            }


            List<ProjectData> oldProjectsList = app.API.APIGetProjectsList(account);

            ProjectData toBeRemoved = oldProjectsList[0];
            app.Projects.Remove(toBeRemoved);
            Assert.AreEqual(oldProjectsList.Count - 1, app.Projects.GetProjectsNumber());

            List<ProjectData> newProjectsList = app.API.APIGetProjectsList(account);

            oldProjectsList.RemoveAt(0);
            Assert.AreEqual(oldProjectsList, newProjectsList);

            foreach (ProjectData project in newProjectsList)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }
        }
    }
}
