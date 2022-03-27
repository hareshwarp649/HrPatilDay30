using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using EnhanceRide;
namespace EnhanceRdeTest3
{
    [TestClass]
    public class UnitTest1
    {
        public EnhanceRides cabInvoiceGenerator;
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new EnhanceRides();
        }

        // given distance in km and time in min should generate fair.
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

        //Invoice Generator should return total number of rides.
        [Test]
        public void AddMultipleRideToCheckTotaltNoOfRide()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(2, invoiceSummary.TotalNoOfRides);
        }
        //Invoice Generator should return total fair.
        [Test]
        public void AddMultipleRideToCheckTotalFair()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(160, invoiceSummary.TotalFair);
        }
        //Invoice Generator should return average fair.
        [Test]
        public void AddMultipleRideToCheckAvgFair()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(80, invoiceSummary.AvgFair);
        }
    }
}