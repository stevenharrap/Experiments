namespace Exp001_Sb_Contract
{
    using System;

    public interface ISomethingHappened
    {
        string What { get; set; }

        DateTime When { get; set; }
    }
}
