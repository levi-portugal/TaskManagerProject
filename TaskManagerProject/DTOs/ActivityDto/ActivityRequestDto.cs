using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.DTOs.ActivityDTO
{
    public class ActivityRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatusEnum Status { get; set; }
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
    }
}
