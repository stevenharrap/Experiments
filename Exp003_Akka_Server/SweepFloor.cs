using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    public class SweepFloor
    {
        public readonly string Room;

        public SweepFloor(string inRoom)
        {
            this.Room = inRoom;
        }
    }
}
