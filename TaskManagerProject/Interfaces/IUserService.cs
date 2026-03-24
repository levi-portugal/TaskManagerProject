using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerProject.Interfaces
{
    internal interface IUserService
    {
        public void CreateUser(string name, string email);

    }
}
