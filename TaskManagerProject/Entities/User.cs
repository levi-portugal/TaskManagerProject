using MongoDB.Bson.Serialization.Attributes;

namespace TaskManagerProject.Entities
{
    public class User
    {
        [BsonId]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User()
        { }
        public User(string name, string email)
        {
            Name = name;
            Email = email;
            UserId = Guid.NewGuid().ToString();
        }
    }
}

