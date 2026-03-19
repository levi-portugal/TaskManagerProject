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
        List<Activity> activities = new List<Activity>();

        public void CreateActivity(string id, string title, DateTime dueDate, TaskStatusEnum status, string description)
        {
            ListActivity();
            
            Activity activity = new Activity(id, title, dueDate, description, status);
            activities.Add(activity);
            TaskManagerProject.Helpers.JsonHelper.Convert(activities, "JsonFileTM.json");
        }

        public void DeleteTask(string id)
        {
            var idTask = id;
            foreach (var item in activities)
            {
                if (idTask.Equals(item.Id)) 
                {
                    activities.Remove(item);
                    Console.WriteLine("Tarefa removida com sucesso!");
                }
                else
                {
                    Console.WriteLine("nenhum Id encontrado com este id");
                }
            }

            TaskManagerProject.Helpers.JsonHelper.Convert(activities, "JsonFileTM.json");


        }

        public void EditTask()
        {
            throw new NotImplementedException();
        }

        public List<Activity> ListActivity()
        {
            activities = TaskManagerProject.Helpers.JsonHelper.Deconvert<List<Activity>>("JsonFileTM.json");
            return activities;
        }
    }
}
