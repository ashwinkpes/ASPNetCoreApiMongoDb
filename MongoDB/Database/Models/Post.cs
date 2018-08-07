using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace MongoDB.Database.Models
{
    public class Post : IPost
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }

        [BsonIgnoreIfNull]
        public virtual User User { get; set; }
        
        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Utc, Representation = BsonType.String)]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public Post(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
