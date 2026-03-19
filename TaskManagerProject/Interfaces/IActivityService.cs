using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;

namespace TaskManagerProject.Interfaces
{
    internal interface IActivityService
    {
        public void CreateActivity( string id,string title, DateTime dueDate,TaskStatusEnum status, string description);
        public void EditTask();
        public void DeleteTask(string id);

    }
}
