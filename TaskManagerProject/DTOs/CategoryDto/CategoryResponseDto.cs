using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.DTOs.CategoryDto
{
    public class CategoryResponseDto
    {
        public string Name { get; set; }
        public CategoryColor Color { get; set; }
        public string CategoryId { get; set; }
    }
}
