using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDB.Database.Models
{
    public interface IUser
    {
        string Email { get; set; }
        Guid Id { get; set; }
        ObjectId InternalId { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        List<Post> Posts { get; set; }
    }
}