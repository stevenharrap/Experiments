using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp002_Sb_Saga
{
    public interface ILog
    {
        int DeviceId { get; }

        int DeviceTripId { get; }

        DateTime Timestamp { get; }

        decimal Speed { get; }

        bool Ignition { get; }
    }
}
