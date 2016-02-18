using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_Saga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Tripping Saga Service---");

            var trippingService = new TrippingService();

            Console.WriteLine("Starting...");
            trippingService.Start();
            Console.WriteLine("done...");
            
            Console.ReadLine();

            Console.WriteLine("Stopping...");
            trippingService.Stop();
            Console.WriteLine("done...");

            Console.ReadLine();
        }
    }
}
