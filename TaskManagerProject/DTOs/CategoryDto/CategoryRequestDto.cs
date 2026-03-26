using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.DTOs.CategoryDto
{
    internal class CategoryRequestDto
    {
        public string Name { get; set; }
        public CategoryColor Color { get; set; }
    }
}
