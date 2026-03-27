using TaskManagerProject.DTOs.CategoryDto;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Helpers;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Services;
namespace TaskManagerProject.UI
{
    public class CategoryMenu
    {
        public ActivityService ActivityService { get; set; }
        public CategoryService CategoryService { get; set; }

        private readonly ICategoryService _categoryService;

        public CategoryMenu(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
                        categoryColor = CategoryColor.Red;
                        break;
                    case 2:
                        categoryColor = CategoryColor.Blue;
                        break;
                    case 3:
                        categoryColor = CategoryColor.Green;
                        break;
                    default:
                        categoryColor = CategoryColor.Black;
                        Console.WriteLine("Essa cor não existe");
                        break;
                }

                var newDto = new CategoryRequestDto
                {
                    Name = name,
                    Color = categoryColor
                };
                CategoryService.CreateCategory(newDto);
                Console.WriteLine("Categoria criada com sucesso!");
                Thread.Sleep(1000);
                run = false;
                //Refatorado
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
            //refatorado, com duvidas
        }
        public void MenuDeleteCategory()
        {
            Console.Clear();
            Console.WriteLine("====Deletar categoria====\n");
            Console.WriteLine("Digite o Id da categoria que deseja deletar:");
            string id = Console.ReadLine();
            
            CategoryService.DeleteCategory(id);
            
            ExitToMenuHelper.Exit();
            //refatorado
        }
    }
}
