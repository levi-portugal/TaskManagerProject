using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.Interfaces
{
    internal interface IActivityService
    {
        public void CreateActivity(string title, DateTime dueDate,TaskStatusEnum status, string description, string categoryId, string userId);
        public void EditTask(string id);
        public bool DeleteTask(string id);
        public List<Activity> ListActivity();
        void FilterListTasks();
    }
}