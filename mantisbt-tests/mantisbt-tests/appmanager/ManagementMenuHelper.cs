using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper :HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void GoToControlTab()
        {
            driver.FindElement(By.XPath(".//span[contains( text(),'Управление')]")).Click();
        }

        public void GoToMenuProjectsListsPage()
        {
            driver.FindElement(By.Id("dropdown_projects_menu")).FindElement(By.CssSelector("a.dropdown-toggle")).Click();
        }

        public void GoToProjectsListsPage()
        {     
            driver.FindElement(By.XPath(".//a[contains( text(),'Управление проектами')]")).Click();
        }
    }
}
