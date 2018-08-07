using System;

namespace MongoDB.Database.Models
{
    public interface IToken
    {
        string Hash { get; }
        DateTime ExpireDateTime { get; }
    }
}
