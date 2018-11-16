using Microsoft.VisualStudio.TestTools.UnitTesting;
using task7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void multTest()
        {
            Matrix a = new Matrix(new[,] { { 2, 2 }, { 2, 2 } });
            Matrix b = new Matrix(new[,] { { 1, 2 }, { 2, 1 } });

            int[,] result = new[,] { { 6, 6 }, { 6, 6 } };
            var actual = Matrix.mult(a, b);
            Assert.AreEqual(result.ToString(), actual.ToString());
        }
        [TestMethod()]
        public void addTest()
        {
            Matrix a = new Matrix(new[,] { { 2, 2 }, { 2, 2 } });
            Matrix b = new Matrix(new[,] { { 1, 2 }, { 2, 1 } });

            int[,] result = new[,] { { 3, 4 }, { 4, 3 } };
            var actual = Matrix.add(a, b);
            Assert.AreEqual(result.ToString(), actual.ToString());
        }
        [TestMethod()]
        public void diffTest()
        {
            Matrix a = new Matrix(new[,] { { 2, 2 }, { 2, 2 } });
            Matrix b = new Matrix(new[,] { { 1, 2 }, { 2, 1 } });

            int[,] result = new[,] { { 1, 0 }, { 0, 1 } };
            var actual = Matrix.diff(a, b);
            Assert.AreEqual(result.ToString(), actual.ToString());
        }
    }
}