using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_SagaCommon
{
    public class TripStarted : ITripStarted
    {
        public Guid CorrelationId { get; }

        //public ILog Log { get; }

        //public TripStarted(Guid correlationId, ILog log)
        public TripStarted(Guid correlationId)
        {
            this.CorrelationId = correlationId;
            //this.Log = log;
        }
    }
}
