using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Console.Out.Write(i);
            }
        }
    }
}
