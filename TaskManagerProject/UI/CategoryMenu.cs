using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Services;
using TaskManagerProject.Helpers;
using System.Reflection.Metadata.Ecma335;
namespace TaskManagerProject.UI
{
    public class CategoryMenu
    {
        public ActivityService ActivityService { get; set; }
        public CategoryService CategoryService { get; set; }


        public CategoryMenu()
        {
            CategoryService = new CategoryService();
            ActivityService = new ActivityService();
        }


        public void MenuCreateCategory()
        {
            int response;
            CategoryColor categoryColor;
            bool run = true;

            while (run)
            {
                Console.WriteLine("===== Criar categoria =====\n");

                Console.Write("Nome da categoria: ");
                string name = Console.ReadLine();

                Console.WriteLine("Defina uma cor para a categoria: ");
                Console.WriteLine("* vermelho - 1");
                Console.WriteLine("* azul - 2");
                Console.WriteLine("* verde - 3");

                try
                {
                    response = int.Parse(Console.ReadLine());
                    
                }
                catch (Exception ex)
                {

                    ExitToMenuHelper.RetryMensage(ex);
                    continue;

                }



                switch (response)
                {
                    case 1:
                        categoryColor = CategoryColor.red;
                        break;
                    case 2:
                        categoryColor = CategoryColor.blue;
                        break;
                    case 3:
                        categoryColor = CategoryColor.green;
                        break;
                    default:
                        categoryColor = CategoryColor.black;
                        Console.WriteLine("Essa cor não existe");
                        break;
                }

                CategoryService.CreateCategory(name, categoryColor);

                run = false;
            }
        }
        public void MenuListCategories()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Categorias ===\n");
            foreach (var category in CategoryService.ListCategory())
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"Nome da tarefa: {category.Name}");
                Console.WriteLine($"Cor: {category.Color}");
                Console.WriteLine($"Id da categoria: {category.CategoryId}");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }

            ExitToMenuHelper.Exit();
        }
        public void MenuDeleteCategory()
        {
            Console.Clear();
            Console.WriteLine("====Deletar categoria====\n");
            Console.WriteLine("Digite o Id da categoria que deseja deletar:");
            string id = Console.ReadLine();

            CategoryService.DeleteCategory(id);

            ExitToMenuHelper.Exit();

        }

    }
}
