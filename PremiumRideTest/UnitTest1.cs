using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PremiumRides5;

using Assert = NUnit.Framework.Assert;

namespace PremiumRideTest
{
    [TestClass]
    public class UnitTest1
    {

        public InvoiceRide cabInvoiceGenerator;
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new InvoiceRide();
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
            cabInvoiceGenerator.AddRide("buddeps", 2, 5);
            cabInvoiceGenerator.AddRide("buddeps", 12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("buddeps");
            Assert.AreEqual(2, invoiceSummary.TotalNoOfRides);
        }
        //Invoice Generator should return total fair.
        [Test]
        public void AddMultipleRideToCheckTotalFair()
        {
            cabInvoiceGenerator.AddRide("poonam", 2, 5);
            cabInvoiceGenerator.AddRide("poonam", 12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("poonam");
            Assert.AreEqual(160, invoiceSummary.TotalFair);
        }
        //Invoice Generator should return average fair.
        [Test]
        public void AddMultipleRideToCheckAvgfair()
        {
            cabInvoiceGenerator.AddRide("poonam567", 2, 5);
            cabInvoiceGenerator.AddRide("poonam567", 12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("poonam567");
            Assert.AreEqual(80, invoiceSummary.AvgFair);
        }

        // Caculate fare for normal and premium rides.
        [Test]
        public void AddMultipleRideForDifferentUser()
        {
            cabInvoiceGenerator.AddRide(new RideType().Normal, "poonam123", 2, 5);
            cabInvoiceGenerator.AddRide(new RideType().Normal, "poonam123", 12, 15);

            cabInvoiceGenerator.AddRide(new RideType().Normal, "budde123", 12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("budde123");
            Assert.AreEqual(135, invoiceSummary.AvgFair);
        }
    }
}