using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Program();
            var t = m.main();

            Task.WaitAll(new Task[] { t });
        }

        public async Task main()
        {
            var system = ActorSystem.Create("MySystem");

            //var greeter = system.ActorOf<GreetingActor>("greeter");
            //greeter.Tell(new Greet("World"));
            //var respnse = await greeter.Ask<string>(new Greet("World"));
            //Console.WriteLine($"RSP: {respnse}");

            var worker = system.ActorOf<WorkerActor>("worker");

            worker.Tell(new PayBill("Bobs Tyres", "000-696998", 100));
            worker.Tell(new SweepFloor("R005"));
            worker.Tell(new Greet("World???"));

            Console.ReadLine();

        }
    }
}
