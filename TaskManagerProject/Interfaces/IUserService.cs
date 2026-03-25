using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;

namespace TaskManagerProject.Interfaces
{
    internal interface IUserService
    {
        public void CreateUser(string name, string email);
        public List<User> ListUser();
    }
}
