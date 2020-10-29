using System;

namespace CabInvoiceGeneratorProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMUIM);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine("Fare : " + fare);
        }
    }
}
