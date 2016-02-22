using Automatonymous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_Saga
{
    public class TripState : SagaStateMachineInstance
    {
        public TripState(Guid correlationId)
        {
            this.CorrelationId = correlationId;
        }

        public int State { get; set; }

        public Guid CorrelationId { get; set; }

        public int DeviceId { get; set; }

        public int DeviceTripId { get; set; }

        public decimal AvgSpeed { get; set; }
    }
}
