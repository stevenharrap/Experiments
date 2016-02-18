using System;

namespace Exp002_Sb_SagaCommon
{
    public interface ITripExpired
    {
        int DeviceId { get; }

        int DeviceTripId { get; }

        DateTime Timestamp { get; }
    }
}
