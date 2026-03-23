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

        public void CreateActivity( string title, DateTime dueDate, TaskStatusEnum status, string description, string categoryId)
        {
            ListActivity();
            
            Activity activity = new Activity( title, dueDate, description, status, categoryId);
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

        public void EditTask(string id)
        {
            ListActivity();

            Activity activitie = activities.Find(p => p.Id == id);

            Console.WriteLine($"O que deseja alterar na tarefa ?");
            Console.WriteLine("Titulo - 1\nDescrição - 2\nStatus - 3");
            int response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                    Console.Write("Digite o novo nome da tarefa: ");
                     string newName = Console.ReadLine();
                    activitie.EditName(newName);
                    break;
                case 2:
                    Console.Write("Digite a nova descrição: ");
                     string newDescription = Console.ReadLine();
                    activitie.EditDescription(newDescription);
                    break;
                case 3:
                    Console.Write("Qual o novo Status que deseja para a tarefa?");
                    Console.WriteLine("\nPending = 1\nInProgress = 2\nCompleted = 3\nCanceled = 4\n");
                    int newStatus = int.Parse(Console.ReadLine());
                    activitie.EditStatus(newStatus);
                    break;
                default:
                    Console.WriteLine("Essa opção não exite!");
                    break;
            }
            TaskManagerProject.Helpers.JsonHelper.Convert(activities, "JsonFileTM.json");
        }

        public List<Activity> ListActivity()
        {
            activities = TaskManagerProject.Helpers.JsonHelper.Deconvert<List<Activity>>("JsonFileTM.json")
                 ?? new List<Activity>();
            return activities;
        }
       
      
    }
}
