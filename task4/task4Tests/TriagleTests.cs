using Microsoft.VisualStudio.TestTools.UnitTesting;
using task4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4.Tests
{
    [TestClass()]
    public class TriagleTests
    {
        [TestMethod()]
        public void pTest()
        {
            Triagle t = new Triagle(4, 5, 6);
            uint a = 4;
            uint b = 5;
            uint c = 6;
            uint expected = a+b+c;
            uint actual = t.p();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void sTest()
        {
            Triagle t = new Triagle(4, 5, 6);
            double expected = 9.92;
            double actual = t.s();

            Assert.AreEqual(expected, actual);
        }
    }
}