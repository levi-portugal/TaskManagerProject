using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.Interfaces
{
    internal interface ICategoryService
    {
        public void CreateCategory(string name, CategoryColor color);
    }
}
