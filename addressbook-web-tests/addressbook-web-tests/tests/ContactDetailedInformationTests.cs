﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailedInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactDetailsInformation()
        {
            ContactData fromEdit = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);




            Console.Out.Write(fromEdit.AllContactsInfo);

            Console.Out.Write(fromDetails.AllContactsInfo);


            Assert.AreEqual(fromEdit.AllContactsInfo, fromDetails.AllContactsInfo);
        }
    }
}