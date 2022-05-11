﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {        
        [Test]

        public void GroupCreationTest()
        {
            GroupData group = new GroupData("qqq");
            group.Header = "www";
            group.Footer = "eee";
          
            app.Groups.CreateGroup(group);
        }
        [Test]

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.CreateGroup(group);
        }
    }
}