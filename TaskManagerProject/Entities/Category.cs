using MongoDB.Bson.Serialization.Attributes;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public CategoryColor Color { get; set; }

        [BsonId]
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
