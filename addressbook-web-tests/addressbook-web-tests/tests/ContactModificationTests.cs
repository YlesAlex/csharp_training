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
    public class ContactModificationTests : TestBase
    {        
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("JON","SNOW");
            app.Contacts.ModifyContact(2, newData);
        }           
    }
}
