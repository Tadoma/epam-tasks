using Microsoft.VisualStudio.TestTools.UnitTesting;
using task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3.Tests
{
    [TestClass()]
    public class EuclideanTests
    {
        [TestMethod()]
        public void EucTest()
        {
            int x = 10;
            int y = 20;
            int z = 30;
            int expected = 10;
            int actual = Euclidean.calcExtended(x, y, z);

            Assert.AreEqual(expected, actual);
        }
    }
}