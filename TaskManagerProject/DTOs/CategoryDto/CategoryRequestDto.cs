using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.DTOs.CategoryDto
{
    public class CategoryRequestDto
    {
        public string Name { get; set; }
        public CategoryColor Color { get; set; }
    }
}
