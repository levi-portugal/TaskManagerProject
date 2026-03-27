using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.Interfaces
{
    internal interface ICategoryService
    {
        public void CreateCategory(string name, CategoryColor color);
        public List<Category> ListCategory();
        public bool DeleteCategory(string id);
    }
}
