using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    public class WorkerActor : ReceiveActor
    {
        public WorkerActor()
        {
            Receive<SweepFloor>(sweepFloor =>
            {
                Console.WriteLine($"Sweeping floor in room {sweepFloor.Room}.");

                //var sweeperManager = Context.ActorOf<SweeperActor>("SweeperManager");
                var sweeperManager = Context.ActorOf(Props.Create(() => new SweeperActor()), "SweeperManager");

                sweeperManager.Ask(new Sweeper(sweepFloor.Room));
                sweeperManager.Ask(new Sweeper(sweepFloor.Room));
                sweeperManager.Ask(new Sweeper(sweepFloor.Room));

            });

            Receive<PayBill>(payBill =>
            {
                Console.WriteLine($"Paying bill for customer {payBill.Customer}.");

            });
        }
    }
}
