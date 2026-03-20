using System;
using System.Collections;
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

        public void CreateActivity( string title, DateTime dueDate, TaskStatusEnum status, string description)
        {
            ListActivity();
            
            Activity activity = new Activity( title, dueDate, description, status);
            activities.Add(activity);
            TaskManagerProject.Helpers.JsonHelper.Convert(activities, "JsonFileTM.json");
        }

        public bool DeleteTask(string id)
        {
            Activity activitie = activities.Find(p => p.Id == id);

            if (activitie == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return false;
            }

            activities.Remove(activitie);
            TaskManagerProject.Helpers.JsonHelper.Convert(activities, "JsonFileTM.json");

            Console.WriteLine($"Produto '{activitie.Title}' removido com sucesso.");
            return true;
        }

        public void EditTask()
        {
            throw new NotImplementedException();
        }

        public List<Activity> ListActivity()
        {
            activities = TaskManagerProject.Helpers.JsonHelper.Deconvert<List<Activity>>("JsonFileTM.json")
                 ?? new List<Activity>();
            return activities;
        }

       
    }
}
