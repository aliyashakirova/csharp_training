using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            :base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            //Thread.Sleep(10000);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
               // driver.FindElement(By.LinkText("Logout")).Click();
                //!!!
                //driver.Url = "http://localhost/mantisbt-2.25.2/logout_page.php";
                driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/logout_page.php");
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;

        }

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.CssSelector("span.user-info")).Text;
            return text;//.Substring(1, text.Length - 2);
        }
    }
}
