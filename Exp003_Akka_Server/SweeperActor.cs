using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    public class SweeperActor : ReceiveActor
    {
        public SweeperActor()
        {
            Receive<SweepFloor>(Sweeper =>
            {
                Console.WriteLine($"Sweeper is sweeping.");
                Task.Delay(new Random().Next(100, 3000));
                Console.WriteLine($"Sweeper is done.");

                Sender.Tell("Swept!");
            });
        }
    }
}
