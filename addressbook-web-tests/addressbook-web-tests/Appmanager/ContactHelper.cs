using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager)
            :base(manager)
        {
        }

        public ContactHelper Modify(ContactData newContactData)
        {
            //driver.FindElement(By.XPath("//a[@href='edit.php?id=" + index + "']")).Click();
            driver.FindElement(By.CssSelector("tr[name*='entry']>td>a[href*='edit']")).Click();
            FillContactForm(newContactData);
            driver.FindElement(By.Name("update")).Click();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            //acceptNextAlert = true;
            driver.FindElement(By.CssSelector("input[name='selected[]']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            //driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        //public ContactHelper SelectContact(string index)
        //{
        //   driver.FindElement(By.Id(index)).Click();
        //    return this;
        //}

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public ContactHelper Remove()
        {
            //SelectContact(index);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }
    }
}
