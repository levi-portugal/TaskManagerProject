using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public CategoryColor Color { get; set; }

        public string CategoryId { get; set; }

        public Category() {  }
        public Category(string name, CategoryColor categoryColor)
        {
            Name = name;
            Color = categoryColor;
            CategoryId = Guid.NewGuid().ToString();
        }
    }
}
