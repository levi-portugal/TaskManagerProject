using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TaskManagerProject.Entities
{
    public class Activity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCriation { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatusEnum Status { get; set; }
        public string? CategoryId { get; set; }
        public string Id { get; set; }

        public Activity(string title, DateTime dueDate,
                         string description, TaskStatusEnum status)
        {
            Title = title;
            DueDate = dueDate;
            Status = status;
            Description = description;
            Status = status;
            Id = Guid.NewGuid().ToString();
            //CategoryId = categoryId ?? "";
            //string? categoryId
            if (title == null)
            {
                throw new FormatException();
            }

            if (dueDate < DateOfCriation)
            {
                throw new ArgumentException();
            }
        }

    }



}
