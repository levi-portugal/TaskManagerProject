using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TaskManagerProject.Entities
{
    internal class Task
    {
        List<Task> tasks = new List<Task>();
        public string Tittle { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCriation { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatusEnum Status { get; set; }
        public Category Category { get; set; }

        // ver parametro opcional - metodo / ctor para não fazer mil ctors
        //fazer talves um método para validar a regra de negócio
        //ctor que tem a validação
        public Task(string tittle, DateTime? dueDate = null , 
            TaskStatusEnum status = TaskStatusEnum.Pending,
            Category category = null, string description = null)
        {
            Tittle = tittle;
            DueDate = (DateTime)dueDate;
            Status = status;    
            Category = category;
            Description = description;


            if (tittle == null )
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
