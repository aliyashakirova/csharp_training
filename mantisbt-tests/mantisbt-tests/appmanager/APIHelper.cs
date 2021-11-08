using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper :HelperBase
    {
        //private string baseURL;

        public APIHelper(ApplicationManager manager) : base(manager) {}

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            mantisbt_tests.Mantis.MantisConnectPortTypeClient client = new mantisbt_tests.Mantis.MantisConnectPortTypeClient();
            mantisbt_tests.Mantis.IssueData issue = new mantisbt_tests.Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new mantisbt_tests.Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public void APICreateProject(AccountData account, ProjectData projectData)
        {
            mantisbt_tests.Mantis.MantisConnectPortTypeClient client = new mantisbt_tests.Mantis.MantisConnectPortTypeClient();
            mantisbt_tests.Mantis.ProjectData project = new mantisbt_tests.Mantis.ProjectData();
            project.name = projectData.ProjectName;
            client.mc_project_add(account.Name, account.Password, project);
        }

        public List<ProjectData> APIGetProjectsList(AccountData account)
        {
            mantisbt_tests.Mantis.MantisConnectPortTypeClient client = new mantisbt_tests.Mantis.MantisConnectPortTypeClient();
            //mantisbt_tests.Mantis.ProjectData project = new mantisbt_tests.Mantis.ProjectData();
            var  projectsListArr = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> projectsList = projectsListArr.Select(project => new ProjectData() { Id = project.id, Name = project.name }).ToList();
            return projectsList;

        }
    }
}
