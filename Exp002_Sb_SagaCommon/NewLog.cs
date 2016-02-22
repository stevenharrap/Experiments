using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_SagaCommon
{
    public class NewLog : INewLog
    {
        public Guid CorrelationId { get; }

        public ILog Log { get; }

        public NewLog(Guid correlationId, ILog log)
        {
            this.CorrelationId = correlationId;
            this.Log = log;
        }
    }
}
