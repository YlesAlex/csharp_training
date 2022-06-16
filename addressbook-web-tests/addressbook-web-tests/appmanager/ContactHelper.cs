using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public bool acceptNextAlert = true;
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToAddContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }
        public ContactHelper ModifyContact(int p, ContactData newData)
        {
            manager.Navigator.GoToHomeContactPage();
            InitContactModification();
            FillContactForm(newData);
            UpdateContact();
            return this;
        }
        public ContactHelper RemoveContact(int p)
        {
            manager.Navigator.GoToHomeContactPage();
            SelectContact(p);
            DeleteContact();
            Confirm();

            return this;
        }
        
        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index + 2) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@src='icons/pencil.png'][1]")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper Confirm()
        {
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
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
        public bool IsContactCreate()
        {
            return IsElementPresent(By.Name("entry"));
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomeContactPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string firstname = cells[2].Text;
                    string lastname = cells[1].Text;
                    contactCache.Add(new ContactData(firstname, lastname)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHomeContactPage();
            return driver.FindElements(By.Name("entry")).Count;
        }
    }
}


