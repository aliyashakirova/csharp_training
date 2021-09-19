using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            //driver.FindElement(By.CssSelector("tr[name*='entry']>td>a[href*="+"'"+ lastcontact + "']")).Click();
            FillContactForm(newContactData);
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public void OpenLastCreatedContact(string lastcontact)
        {
            //driver.Navigate().GoToUrl("http://localhost/addressbook/edit.php?id=" + lastcontact);
            driver.FindElement(By.CssSelector("tr[name*='entry']>td>a[href*=" + "'edit.php?id=" + lastcontact + "']")).Click();
        }

        public int GetLastContactIndex(string lastContactId)
        {
            //driver.FindElement(By.XPath("(//input[@value=" + GetLastGroup() + "])")).
            var contacts = driver.FindElements(By.Name("selected[]"));
            List<int> contactids = new List<int>();
            int ind = 0;
            foreach (var contact in contacts)
            {
                if (contact.GetAttribute("value") == lastContactId)
                {
                    break;
                }
                ind = ind + 1;
            }
            return ind;
            //groupids.Add(Convert.ToInt32(group.GetAttribute("value")));
        }

        public string GetLastContact()
        {
            var contacts = driver.FindElements(By.Name("selected[]"));
            List<int> contactids = new List<int>();
            foreach (var contact in contacts)
                contactids.Add(Convert.ToInt32(contact.GetAttribute("value")));

            contactids.Sort();
            contactids.Reverse();

            return Convert.ToString(contactids[0]);
        }

        public ContactData GetContactData()
        {
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");


            return new ContactData(firstName, lastName);
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
            contactCache = null;
            return this;
        }
        public ContactHelper RemoveContact()
        {
            //acceptNextAlert = true;
            driver.FindElement(By.CssSelector("input[name='selected[]']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(10000);
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
        public int GetContactNumber()
        {
            return driver.FindElements(By.Name("selected[]")).Count;
        }

        private List<ContactData> contactCache = null;


        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name = 'entry']"));
                foreach (IWebElement element in elements)
                {

                    var firstName = element.FindElement(By.CssSelector("tr[name='entry']>td:nth-child(3)"));
                    var lastName = element.FindElement(By.CssSelector("tr[name='entry']>td:nth-child(2)"));


                    contactCache.Add(new ContactData(firstName.Text, lastName.Text)
                    {
                        Id = element.FindElement(By.CssSelector("input[name*='selected']")).GetAttribute("value")
                    });
                }


            }
            return new List<ContactData>(contactCache);
        }

       // public int GetLastContactIndex(string lastContactId)
       // {
      //      var contacts = driver.FindElements(By.Name("selected[]"));
      //      List<int> contactids = new List<int>();
       //     int ind = 0;
       //     foreach (var contact in contacts)
       //     {
       //         if (contact.GetAttribute("value") == lastContactId)
       //         {
       //             break;
       //         }
       //         ind = ind + 1;
       //     }
       //     return ind;
        //}

        //public string GetLastContact()
       // {
       //     var contacts = driver.FindElements(By.Name("selected[]"));
        //    List<int> contactids = new List<int>();
        //    foreach (var contact in contacts)
        //        contactids.Add(Convert.ToInt32(contact.GetAttribute("value")));
//
        //    contactids.Sort();
        //    contactids.Reverse();
//
        //    return Convert.ToString(contactids[0]);
       // }
    }
}
