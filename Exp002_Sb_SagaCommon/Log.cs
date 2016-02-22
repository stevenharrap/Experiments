using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_SagaCommon
{
    public class Log : ILog
    {
        public int DeviceId { get; set; }

        public int DeviceTripId { get; set; }

        public bool Ignition { get; set; }

        public decimal Speed { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
