using System;

namespace Exp002_Sb_Saga
{
    public interface ITripExpired
    {
        int DeviceId { get; }

        int DeviceTripId { get; }

        DateTime Timestamp { get; }
    }
}
