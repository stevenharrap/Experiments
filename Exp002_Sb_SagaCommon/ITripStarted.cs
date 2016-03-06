namespace Exp002_Sb_SagaCommon
{
    using System;

    public interface ITripStarted
    {
        Guid CorrelationId { get; }

        //ILog Log { get; }
    }
}
