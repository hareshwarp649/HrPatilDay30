using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PremiumBonusRide5;
using Assert = NUnit.Framework.Assert;

namespace TestProjectPreRide
{
    [TestClass]
    public class UnitTest1
    {
        public InvoiceR cabInvoiceGenerator;
        [SetUp]
      
        public void SetUp()
        {
            cabInvoiceGenerator = new InvoiceR();
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
            var invoiceSummary = cabInvoiceGenerator.GetInvoiceSummary("buddeps");
            Assert.AreEqual(2, invoiceSummary.TotalNoOfRides);
        }
        //Invoice Generator should return total fair.
        [Test]
        public void AddMultipleRideToCheckTotalFair()
        {
            cabInvoiceGenerator.AddRide("poonam", 2, 5);
            cabInvoiceGenerator.AddRide("poonam", 12, 15);
            var invoiceSummary = cabInvoiceGenerator.GetInvoiceSummary("poonam");
            Assert.AreEqual(160, invoiceSummary.TotalFair);
        }
        //Invoice Generator should return average fair.
        [Test]
        public void AddMultipleRideToCheckAvgfair()
        {
            cabInvoiceGenerator.AddRide("poonam567", 2, 5);
            cabInvoiceGenerator.AddRide("poonam567", 12, 15);
            var invoiceSummary = cabInvoiceGenerator.GetInvoiceSummary("poonam567");
            Assert.AreEqual(80, invoiceSummary.AvgFair);
        }

        // Caculate fare for normal and premium rides.
        [Test]
        public void AddMultipleRideForDifferentUser()
        {
            cabInvoiceGenerator.AddRide(new RType().Normal, "poonam123", 2, 5);
            cabInvoiceGenerator.AddRide(new RType().Normal, "poonam123", 12, 15);

            cabInvoiceGenerator.AddRide(new RType().Normal, "budde123", 12, 15);
            var invoiceSummary = cabInvoiceGenerator.GetInvoiceSummary("budde123");
            Assert.AreEqual(135, invoiceSummary.AvgFair);
        }
    }
}
  