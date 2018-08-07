using System;

namespace MongoDB.Database.Models
{
    public interface IPost
    {
        Guid Id { get; }
        string Title { get; }
        string Content { get; }
        DateTime CreationDate { get; }
    }
}
