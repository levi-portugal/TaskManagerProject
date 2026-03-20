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
        public bool DeleteCategory(string id) 
        {

            Category category = categories.Find(p => p.CategoryId == id);

            if (category == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return false;
            }

            categories.Remove(category);
            TaskManagerProject.Helpers.JsonCategoryHelper.ConvertCategory(categories, "JsonFileTM.json");

            Console.WriteLine($"Produto '{category.Name}' removido com sucesso.");
            return true;
        }
    }
}
