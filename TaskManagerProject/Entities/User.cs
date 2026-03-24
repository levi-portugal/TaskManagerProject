using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerProject.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            UserId = Guid.NewGuid().ToString();

        }
    }
}

