using System;
using MongoDB.Bson;

namespace MongoDB.Database.Models
{
    public interface IPost
    {
        string Content { get; set; }
        DateTime CreationDate { get; set; }
        Guid Id { get; set; }
        ObjectId InternalId { get; set; }
        string Title { get; set; }
        User User { get; set; }
    }
}