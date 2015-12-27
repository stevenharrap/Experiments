namespace Exp001_Sb_Subscriber
{
    using Exp001_Sb_Contract;
    using MassTransit;
    using System;
    using System.Threading.Tasks;

    public class SomethingHappenedConsumer : IConsumer<ISomethingHappened>
    {
        public Task Consume(ConsumeContext<ISomethingHappened> context)
        {
            Console.WriteLine($"TXT: {context.Message.What} SENT: {context.Message.When} ({System.Threading.Thread.CurrentThread.ManagedThreadId})");
            return Task.FromResult(0);
        }
    }
}
