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
            double total = 900;
            bool vipClient = false;
            bool name = true;

            if (total > 1000 || vipClient || total == 900 && name)
            {
                total = total * 0.9;
                Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
            else
            {
                Console.Out.Write("Скидки нет, общая сумма " + total);
            }
        }
    }
}
