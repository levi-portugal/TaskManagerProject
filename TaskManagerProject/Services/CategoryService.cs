using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Services;

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

            var activityList = new ActivityService().ListActivity();
            var activity = activityList.FirstOrDefault(i => i.Id == id);

            if (activity == default)
            {
                categories.Remove(category);
            }
            else
            {
                Console.WriteLine("Não é permitido excluir uma categoria com tarefas vinculadas!");
                return false;
            }



                TaskManagerProject.Helpers.JsonCategoryHelper.ConvertCategory(categories, "JsonCategoryFileTM.json");
            Console.WriteLine($"Produto '{category.Name}' removido com sucesso.");
            return true;
        }


        

    }
}

