using Exp002_Sb_SagaCommon;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_SagaClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Tripping Saga Client---");

            var bus = Bus.Factory.CreateUsingRabbitMq(x => x.Host(new Uri("rabbitmq://localhost/"), h => { }));
            var busHandle = bus.Start();
            var text = string.Empty;

            while (text != "quit")
            {
                Console.WriteLine("Enter ?: ");

                var entered = Console.ReadLine();

                bus.Publish<ILogAdded>(new
                {
                    DeviceId = 5000,
                    DeviceTripId = 9,
                    Timestamp = DateTime.Now,
                    Speed = 85,
                    Ignition = true
                });
            }

            busHandle.Stop();
        }
    }
}
