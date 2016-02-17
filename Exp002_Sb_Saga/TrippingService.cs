using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automatonymous;
using MassTransit.Saga;

namespace Exp002_Sb_Saga
{
    public class TrippingService
    {
        private IBusControl busControl { get; set; }

        private BusHandle busHandle { get; set; }

        private TrippingStateMachine machine { get; set; }

        private InMemorySagaRepository<Trip> repository;

        public void Start()
        {
            this.machine = new TrippingStateMachine();
            this.repository = new InMemorySagaRepository<Trip>();

            this.busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
                x.ReceiveEndpoint(host, "tripping_state", e => 
                {
                    e.StateMachineSaga(this.machine, this.repository);
                });
            });
            this.busHandle = this.busControl.Start();
        }

        public void Stop()
        {
            this.busHandle.Stop();
        }
    }    
}
