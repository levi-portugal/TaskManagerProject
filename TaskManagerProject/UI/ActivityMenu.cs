using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Helpers;
using TaskManagerProject.Services;
using static System.Net.WebRequestMethods;

namespace TaskManagerProject.UI
{
    public class ActivityMenu
    {
        public ActivityService ActivityService { get; set; }
        public CategoryService CategoryService { get; set; }


        public ActivityMenu()
        {
            CategoryService = new CategoryService();
            ActivityService = new ActivityService();
        }
        public void MenuCreateTask()
        {
            TaskStatusEnum status2;

            bool run = true;
            while (run)
            {
                string name;
                DateTime dueDate;
                int status;
                string categoryId;
                Console.Clear();
                Console.WriteLine("=== Criar nova tarefa ===\n");

                try
                {
                    Console.Write("\nNome da tarefa: \n");
                    name = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    ExitToMenuHelper.RetryMensage(ex);
                    continue;
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new FormatException();
                }

                Console.WriteLine("insira o id de uma categoria:");
                Console.WriteLine("Obs: Caso não queira atribuir ou não tenha uma categoria criada, aperte 'enter'!");
                categoryId = Console.ReadLine();

                try
                    {
                        Console.Write("Data de vencimento: \n");
                        dueDate = DateTime.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {

                        ExitToMenuHelper.RetryMensage(ex);
                        continue;
                    }

                try
                {
                    Console.WriteLine("Defina um Status:\nPending = 1\nInProgress = 2\nCompleted = 3\nCanceled = 4\n");
                    status = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    ExitToMenuHelper.RetryMensage(ex);
                    continue;
                }
               

                switch (status)
                {
                    case 1:
                        status2 = TaskStatusEnum.Pending;
                        break;
                    case 2:
                        status2 = TaskStatusEnum.InProgress;
                        break;
                    case 3:
                        status2 = TaskStatusEnum.Completed;
                        break;
                    case 4:
                        status2 = TaskStatusEnum.Canceled;
                        break;
                    default:
                        status2 = TaskStatusEnum.Pending;
                        Console.WriteLine("Esse status não exite, o status foi definido como pendente!");
                        break;
                }

                Console.WriteLine("descrição: ");
                string description = Console.ReadLine();

                ActivityService.CreateActivity(name, dueDate, status2, description, categoryId);
                run = false;
            }


            Console.WriteLine("tarefa criada com sucesso!\n");
            ExitToMenuHelper.Exit();

        }
        public void MenuListTasks()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de tarefas ===\n");

            foreach (var task in ActivityService.ListActivity())
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Nome da tarefa: {task.Title}");
                Console.WriteLine($"Descrição: {task.Description}");
                Console.WriteLine($"Data de criação: {task.DateOfCriation}");
                Console.WriteLine($"Data de validade: {task.DueDate}");
                if (string.IsNullOrWhiteSpace(task.CategoryId))
                {
                    Console.WriteLine("Sem categoria atribuída");
                }
                else
                {
                    Console.WriteLine($"Categoria: {task.CategoryId}");
                }
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            ExitToMenuHelper.Exit();

        }
        public void MenuDeleteTask()
        {
            Console.WriteLine("---Deletar tarefa--\n");
            Console.WriteLine("Digite o id da tarefa que deseja excluir: ");
            string id = Console.ReadLine();

            ActivityService.DeleteTask(id);

            ExitToMenuHelper.Exit();
        }

        public void MenuEditTask()
        {
            Console.WriteLine("====Editar Tarefa====\n");
            Console.Write("Digite o Id da tarefa que deseja alterar: ");
            string id = Console.ReadLine();
            ActivityService.EditTask(id);
        }

    }
}
