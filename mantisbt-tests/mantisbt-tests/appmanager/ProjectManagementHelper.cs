using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper :HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }
        
        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Navigator.GoToControlTab();
            manager.Navigator.GoToProjectsListsPage();
            CreateNewProject();
            FillProjectForm(project);
            SubmitProjectCreation();
            return this;
        }

        public bool IsProjectsListEmpty()
        {
            return GetProjectsNumber() == 0;
        }

        public ProjectManagementHelper Remove(ProjectData project)
        {
            manager.Navigator.GoToControlTab();
            manager.Navigator.GoToProjectsListsPage();
            SelectProject(project.Id);
            RemoveProject();
            SubmitProjectRemoval();
            return this;
        }

        public ProjectManagementHelper SubmitProjectRemoval()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            return this;
        }

        public ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.CssSelector("input[value*='Удалить проект']")).Click();
            projectCache = null;

            return this;
        }

        public ProjectManagementHelper SelectProject(string id)
        {
            driver.FindElement(By.CssSelector("a[href='manage_proj_edit_page.php?project_id=" + id + "']")).Click();
            return this;
            //"input[type='submit']"
        }

        public int GetProjectsNumber()
        {
            return driver.FindElements(By.CssSelector("a.project-link")).Count - 1;
        }
        private List<ProjectData> projectCache = null;
        public List<ProjectData> GetProjectsList()
        {

            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                manager.Navigator.GoToMenuProjectsListsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("a.project-link"));
                int i = 0;
                foreach (IWebElement element in elements)
                {

                    var projectName = element.Text;

                    if (i != 0)
                    {
                        var found = element.GetAttribute("href").IndexOf("=");
                        projectCache.Add(new ProjectData(projectName)
                        {
                            Id = element.GetAttribute("href").Substring(found+1)
                        });
                    }
                    i++;
                }


            }
            return new List<ProjectData>(projectCache);
        }

        public string GetLastProject()
        {
            projectCache = null;
            var projects = driver.FindElements(By.CssSelector("a.project-link"));
            List<int> projectids = new List<int>();
            foreach (var project in projects)
            {
                var found = project.GetAttribute("href").IndexOf("=");
                projectids.Add(Convert.ToInt32(project.GetAttribute("href").Substring(found + 1)));
                //projectids.Add(project.Text);
            }   
            projectids.Sort();
            projectids.Reverse();

            return Convert.ToString(projectids[0]);
        }

        private ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            projectCache = null;
            return this;
            
        }

        private ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.ProjectName);
            projectCache = null;
            return this;
        }

        private ProjectManagementHelper CreateNewProject()
        {
            driver.FindElement(By.XPath(".//button[contains( text(),'Создать')]")).Click();
            projectCache = null;
            return this;

        }
    }
}