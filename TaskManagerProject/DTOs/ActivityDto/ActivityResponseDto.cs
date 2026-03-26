using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.DTOs.ActivityDTO
{
    public class ActivityResponseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCriation { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatusEnum Status { get; set; }
        public string? CategoryId { get; set; }
        public string? UserId { get; set; }
        public string Id { get; set; }
    }
}
