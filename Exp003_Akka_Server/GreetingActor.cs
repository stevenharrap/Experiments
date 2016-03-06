using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Receive<Greet>(greet =>
            {
                Console.WriteLine($"Hello {greet.Who}");

                Sender.Tell("What is your name?");
            });
        }
    }
}
