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
            var category = new Category (dto.Name, dto.Color)
            {};

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
            _repository.Delete(id.ToString());
            Console.WriteLine("excluido com sucesso meu nobre");
            //Refatorado
        }
    }
}

