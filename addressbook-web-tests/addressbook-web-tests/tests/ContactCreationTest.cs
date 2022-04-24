using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBaseContacts
    {

        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            CreateNewContact();
            ContactData contact = new ContactData("Alex", "Ulesov");
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
        }       
    }
}