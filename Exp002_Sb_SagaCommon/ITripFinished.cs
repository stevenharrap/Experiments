using System;

namespace Exp002_Sb_SagaCommon
{
    public interface ITripFinished
    {
        Guid CorrelationId { get; set; }

        int DeviceId { get; }

        int DeviceTripId { get; }
    }
}
