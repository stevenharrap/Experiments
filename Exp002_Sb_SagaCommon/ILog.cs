using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_SagaCommon
{
    public interface ILog
    {
        int DeviceId { get; set; }

        int DeviceTripId { get; set; }

        DateTime Timestamp { get; set; }

        decimal Speed { get; set; }

        bool Ignition { get; set; }
    }
}
