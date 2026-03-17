using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.Services
{
    public class ActivityService : IActivityService
    {
        List <Activity> activities = new List<Activity>();

        public void CreateActivity(string title, DateTime dueDate, TaskStatusEnum status, string description)
        {
            Activity activity = new Activity(title, dueDate, status, description);

            activities.Add(activity);
        }

        public void DeleteTask()
        {
            throw new NotImplementedException();
        }

        public void EditTask()
        {
            throw new NotImplementedException();
        }
       
    }
}
