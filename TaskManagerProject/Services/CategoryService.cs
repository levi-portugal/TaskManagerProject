using TaskManagerProject.Data.Repositories;
using TaskManagerProject.DTOs.CategoryDto;
using TaskManagerProject.Entities;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public void CreateCategory(CategoryRequestDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Color = dto.Color
            };

            _repository.Create(category);
            //Refatoration
        }
        public List<CategoryResponseDto> ListCategory()
        {
            var categories = _repository.GetAll();
            return categories.Select(c => new CategoryResponseDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Color = c.Color
            }).ToList();
            //Refatorado
        }
        public void DeleteCategory(string id)
        {            
            var activity = ListCategory().FirstOrDefault(i => i.CategoryId == id);

            if (activity == null)
            {
                _repository.Delete(id.ToString());
            }
            else
            {
                Console.WriteLine("Não é permitido excluir uma categoria com tarefas vinculadas!");
            }
            Thread.Sleep(1000);
            //Refatorado
        }
    }
}

