using Exp001_Sb_Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp001_Sb_Publisher
{
    class SomethingHappenedMessage : ISomethingHappened
    {
        public string What { get; set; }
        public DateTime When { get; set; }
    }
}
