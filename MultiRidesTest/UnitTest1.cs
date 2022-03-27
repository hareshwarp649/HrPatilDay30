using Microsoft.VisualStudio.TestTools.UnitTesting;

using NUnit.Framework;
using MultipleRides2;
using Assert = NUnit.Framework.Assert;

namespace MultiRidesTest
{
    [TestClass]
    public class UnitTest1
    {
        
        public MultipleRide cabInvoiceGenerator;
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new MultipleRide();
        }

        // Step1- given distance in km and time in min should generate fair.
        [Test]
        public void Test1()
        {
            double fair = cabInvoiceGenerator.CalculateFair(2, 5);
            Assert.AreEqual(25, fair);
        }
        [Test]
        public void CheckMinimumFairAsFive()
        {
            double fair = cabInvoiceGenerator.CalculateFair(0, 0);
            Assert.AreEqual(5, fair);
        }

        // step2- for multiple ride generate aggregate fair
        [Test]
        public void CalAggFairAndMultipleRide()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            double fair = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(160, fair);
        }
    }
}