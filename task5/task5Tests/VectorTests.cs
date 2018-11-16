using Microsoft.VisualStudio.TestTools.UnitTesting;
using task5;
using System.Collections.Generic;


namespace task5.Tests
{
    [TestClass()]
    public class VectorTests
    {
        [TestMethod()]
        public void sumTest()
        {
            Vector actual = new Vector(-1, 2, -2) + new Vector(2, 1, -1);
            Vector expected = new Vector(1, 3, -3);

            Assert.AreEqual(actual.ToString(),expected.ToString());
        }
        [TestMethod()]
        public void vecTest()
        {
            Vector actual = new Vector(-1, 2, -2) ^ new Vector(2, 1, -1);
            Vector expected = new Vector(0, -5, -5);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
    }
    [TestClass()]
    public class PolyTests
    {
        [TestMethod()]
        public void polySum()
        {
            var rawData = new Dictionary<char, double>();
            rawData.Add('x', 5);
            rawData.Add('y', 5);

            var expectedData = new Dictionary<char, double>();
            expectedData.Add('x', 10);
            expectedData.Add('y', 10);

            Poly actual = new Poly(rawData) + new Poly(rawData);
            Poly expected = new Poly(expectedData);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
        [TestMethod()]
        public void polyDiff()
        {
            var rawData = new Dictionary<char, double>();
            rawData.Add('x', 5);
            rawData.Add('y', 5);

            var expectedData = new Dictionary<char, double>();
            expectedData.Add('x', 0);
            expectedData.Add('y', 0);

            Poly actual = new Poly(rawData) - new Poly(rawData);
            Poly expected = new Poly(expectedData);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }
    }
}