using Microsoft.VisualStudio.TestTools.UnitTesting;
using FareCalculate;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FareCalcuTest
{
    [TestClass]
    public class UnitTest1
    {

        public CalculateFare calculateFare;
        [SetUp]
        public void Setup()
        {
            calculateFare = new CalculateFare();
        }

        //given distance in km and time in min should generate fair.
        [Test]
        public void Test1()
        {
            double fair = calculateFare.CalculateFair(2, 5);
            NUnit.Framework.Assert.AreEqual(25, fair);
        }
        [Test]
        public void CheckMinimumFairAsFive()
        {
            double fair = calculateFare.CalculateFair(0, 0);
            Assert.AreEqual(5, fair);
        }
    }
}