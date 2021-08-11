using NUnit.Framework;

using CabInvoiceGenerator1;

namespace CabInvoiceGeneratorTest1
{

    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        RideRepository rideRepository = new RideRepository();

        [SetUp]
        public void Setup()
        {
        }

        #region Normal ride type
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
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }

        [Test]
        public void GivenMultipleRideShouldReturnAverageFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5), new Ride(4.0, 10) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(3, 81.0);
            int numOfRides = summary.numberOfRides;
            double totalFare = summary.totalFare;
            double avgFare = summary.averageFare;
            int expectedNumOfRides = 3;
            double expectedTotalFare = 81;
            double expectedAvgFare = 27;
            Assert.AreEqual(expectedNumOfRides, numOfRides);
            Assert.AreEqual(expectedTotalFare, totalFare);
            Assert.AreEqual(expectedAvgFare, avgFare);
        }

        [Test]
        public void GivenUserIdShouldReturnListOfRides()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5), new Ride(4.0, 10) };
            rideRepository.AddRide("Ravina", rides);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rideRepository.getRides("Ravina"));
            InvoiceSummary expectedSummary = new InvoiceSummary(3, 81.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
        #endregion Normal ride type

        #region Permium ride type
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareForPermium()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummaryForPermium()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 70.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }

        [Test]
        public void GivenMultipleRideShouldReturnAverageFareForPermium()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 51.5);
            int numOfRides = summary.numberOfRides;
            double totalFare = summary.totalFare;
            double avgFare = summary.averageFare;
            int expectedNumOfRides = 2;
            double expectedTotalFare = 51.5;
            double expectedAvgFare = 25.75;
            Assert.AreEqual(expectedNumOfRides, numOfRides);
            Assert.AreEqual(expectedTotalFare, totalFare);
            Assert.AreEqual(expectedAvgFare, avgFare);
        }

        [Test]
        public void GivenUserIdShouldReturnListOfRidesForPermium()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            rideRepository.AddRide("Ravina", rides);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rideRepository.getRides("Ravina"));
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 81.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }
        #endregion Permium ride type



    }
}

