using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.DTOs.CategoryDto
{
    internal class CategoryResponseDto
    {
        public string Name { get; set; }
        public CategoryColor Color { get; set; }
        public string CategoryId { get; set; }
    }
}
