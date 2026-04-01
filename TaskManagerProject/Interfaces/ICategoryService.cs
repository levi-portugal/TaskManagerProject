using TaskManagerProject.DTOs.CategoryDto;

namespace TaskManagerProject.Interfaces
{
    public interface ICategoryService
    {
        public void CreateCategory(CategoryRequestDto dto);
        public List<CategoryResponseDto> ListCategory();
        public void DeleteCategory(string id);
    }
}
