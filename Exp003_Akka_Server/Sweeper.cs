﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp003_Akka_Server
{
    public class Sweeper
    {
        public readonly string Room;

        public Sweeper(string room)
        {
            this.Room = room;
        }
    }
}
