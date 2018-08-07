using System;
using System.Collections.Generic;

namespace MongoDB.Database.Models
{
    public interface IUser
    {
        Guid Id { get; }
        string Name { get; }
        string Email { get; }
        string Password { get; }
        List<Post> Posts { get; }
    }
}
