using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests :AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 10000);
            ProjectData project = new ProjectData("name" + Convert.ToString(value));
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            List<ProjectData> oldProjectsList = app.API.APIGetProjectsList(account);

            app.Projects.Create(project);


            Assert.AreEqual(oldProjectsList.Count + 1, app.Projects.GetProjectsNumber());

            List<ProjectData> newProjectsList = app.API.APIGetProjectsList(account);

            oldProjectsList.Add(new ProjectData(project.ProjectName){ Id = app.Projects.GetLastProject().ToString() });
            oldProjectsList.Sort();
            newProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }

    }
}
