using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.Services
{
    public class CategoryService : ICategoryService
    {
        List<Category> categories = new List<Category>();

        public void CreateCategory(string name, CategoryColor categoryColor)
        {
            ListCategory();

            Category category = new Category(name, categoryColor);
            categories.Add(category);

            TaskManagerProject.Helpers.JsonCategoryHelper.ConvertCategory(categories, "JsonCategoryFileTM.json");
        }

        public List<Category> ListCategory()
        {
            return categories = TaskManagerProject.Helpers.JsonCategoryHelper.DeconvertCategory<List<Category>>("JsonCategoryFileTM.json");
         
        }
    }
}
