using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    public class Greet
    {
        public string Who { get; private set; }

        public Greet(string who)
        {
            this.Who = who;
        }
    }
}
