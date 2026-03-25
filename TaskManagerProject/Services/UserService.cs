using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Helpers;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.Services
{
    public class UserService : IUserService
    {
        List<User> users = new List<User>();

        public void CreateUser(string name, string email)
        {
            ListUser();

            User user = new User(name, email);
            users.Add(user);

            TaskManagerProject.Helpers.JsonHelper.Convert(users, "JsonUserFileTM.json");
        }

        public List<User> ListUser()
        {
            return users = TaskManagerProject.Helpers.JsonHelper.Deconvert<List<User>>("JsonUserFileTM.json");          
        }
    }
}
