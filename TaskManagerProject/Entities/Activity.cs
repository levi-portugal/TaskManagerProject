using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TaskManagerProject.Entities
{
    internal class Activity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCriation { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Category Category { get; set; }

        public Activity(string title, DateTime? dueDate = null , 
            TaskStatusEnum status = TaskStatusEnum.Pending,
             string? description = null)
        {
            Title = title;
            DueDate = dueDate ?? DateTime.MinValue;
            Status = status;    
            //Category = category;
            Description = description;


            if (title == null )
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
