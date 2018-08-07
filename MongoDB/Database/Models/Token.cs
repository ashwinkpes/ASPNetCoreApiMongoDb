using System;

namespace MongoDB.Database.Models
{
    public class Token : IToken
    {
        public string Hash { get; }
        public DateTime ExpireDateTime { get; }

        public Token(string hash, DateTime expireDateTime)
        {
            Hash = hash;
            ExpireDateTime = expireDateTime;
        }

        public Token(byte[] bytes, DateTime expirationDateTime)
        {
            Hash = Convert.ToBase64String(bytes);
            ExpireDateTime = expirationDateTime;
        }
    }
}
