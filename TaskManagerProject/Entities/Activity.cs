using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using TaskManagerProject.Entities.Enums;
using static System.Net.Mime.MediaTypeNames;
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
        public string? UserId { get; set; }
        public string Id { get; set; }

        public Activity(string title, DateTime dueDate,
                         string description, TaskStatusEnum status, string? categoryId, string? userId)
        {
            Title = title;
            DueDate = dueDate;
            Description = description;
            Status = status;
            DateOfCriation = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            UserId = userId;

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new FormatException("Title cannot be empty!"); 
            }

            if (!string.IsNullOrWhiteSpace(categoryId))
                CategoryId = categoryId;

            if (dueDate < DateOfCriation)
            {
                throw new ArgumentException();
            }        
        }

        [JsonConstructor]
        public Activity()
        { }

        public void EditName(string name)
        {
            Title = name;
            Console.WriteLine("Nome alterado com sucesso!");
        }
        public void EditDescription(string description)
        {
            Description = description;
            Console.WriteLine("Descrição alterada com sucesso!");
        }
        public void EditStatus(int status)
        {  
            switch (status)
            {
                case 1:
                    Status = TaskStatusEnum.Pending;
                    break;
                case 2:
                    Status = TaskStatusEnum.InProgress;
                    break;
                case 3:
                    Status = TaskStatusEnum.Completed;
                    break;
                case 4:
                    Status = TaskStatusEnum.Canceled;
                    break;
                default:
                    Status = TaskStatusEnum.Pending;
                    Console.WriteLine("Esse status não exite, o status foi definido como pendente!");
                    break;
            }
        
            Console.WriteLine("Status alterado com sucesso!");
        }
    }
}