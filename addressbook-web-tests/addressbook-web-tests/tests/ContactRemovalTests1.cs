using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToHomePage();
            if (!app.Contacts.IsContactCreate())
            {
                ContactData contact = new ContactData("Alex", "Xela");
                app.Contacts.CreateContact(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldData = oldContacts[0];

            app.Contacts.RemoveContact(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }               
    }
}

