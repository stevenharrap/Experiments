using Exp001_Sb_Contract;
using MassTransit;
using System;

namespace Exp001_Sb_Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Log4NetLogger.Use();
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
              x.Host(new Uri("rabbitmq://localhost/"), h => { }));
            var busHandle = bus.Start();
            var text = "";

            while (text != "quit")
            {
                Console.WriteLine("Enter a message in the format X=text where X is A or B: ");

                var entered = Console.ReadLine();

                var message = new SomethingHappenedMessage()
                {
                    What = entered,
                    When = DateTime.Now
                };
                bus.Publish<ISomethingHappened>(message);
            }

            busHandle.Stop();
        }
    }
}
