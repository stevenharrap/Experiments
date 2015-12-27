namespace Exp001_Sb_Subscriber
{
    using Exp001_Sb_Contract;
    using MassTransit;
    using System;
    using System.Collections.Concurrent;

    class Program
    {
        private BusHandle BusHandle { get; set; }

        public void Manage()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });

                x.ReceiveEndpoint(host, "MtPubSubExample_TestSubscriber", e =>
                  e.Consumer<SomethingHappenedConsumer>());
            });

            this.BusHandle = bus.Start();            
        }

        public void Halt()
        {
            this.BusHandle.Stop();
        }

        static void Main(string[] args)
        {
            var theProgram = new Program();

            theProgram.Manage();

            Console.ReadKey();

            theProgram.Halt();
        }
    }
}
