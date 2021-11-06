using System;
using System.Collections.Generic;
using System.Linq;
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

            //app.Navigator.GoToMenuProjectsListsPage();
            List<ProjectData> oldProjects = app.Projects.GetProjectsList();
            app.Projects.Create(project);


            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectsNumber());

            List<ProjectData> newProjects = app.Projects.GetProjectsList();

            oldProjects.Add(new ProjectData(project.ProjectName){ Id = app.Projects.GetLastProject().ToString() });
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

    }
}
