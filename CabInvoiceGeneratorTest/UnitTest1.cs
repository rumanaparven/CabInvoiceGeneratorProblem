using CabInvoiceGeneratorProblem;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double totalFare = summary.GetTotalFare();
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            double expected = expectedSummary.GetTotalFare();
            Assert.AreEqual(expected, totalFare);
        }

        [Test]
        public void GivenMultipleRidesShouldReturnEnhancedInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenUserIDShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            
            invoiceGenerator.AddRides("RUMANA", rides);

            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("RUMANA");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenPremiumRidesShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMUIM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double totalFare = summary.GetTotalFare();
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0);
            double expected = expectedSummary.GetTotalFare();
            Assert.AreEqual(expected, totalFare);
        }

    }
}