using System;

namespace CabInvoiceGenerator1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator");

            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double singleFare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Single Ride Fare : {singleFare}");
        }
    }
}
