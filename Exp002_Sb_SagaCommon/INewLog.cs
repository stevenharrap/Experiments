namespace Exp002_Sb_SagaCommon
{
    using System;

    public interface INewLog
    {
        Guid CorrelationId { get; }

        ILog Log { get; }
    }
}
