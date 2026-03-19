using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Services;

namespace TaskManagerProject.UI
{
    public class Menu
    {
        

        public ActivityService ActivityService { get; set; }

        public Menu()
        {
           ActivityService = new ActivityService();
        }

        public void ShowMenu()
        {
            ActivityService.ListActivity();
            while (true)
            {
                int response;

                Console.Clear();

                Console.WriteLine("==== GERENCIADOR DE TAREFAS ====\n");
                Console.WriteLine("O que deseja fazer?\n");
                Console.WriteLine("Criar tarefas - 1");
                Console.WriteLine("Listar Tarefas - 2");
                Console.WriteLine("Editar tarefas - 3");
                Console.WriteLine("remover tarefa - 4");
                Console.WriteLine("Sair - 0");


                while (!int.TryParse(Console.ReadLine(), out response))
                {
                    Console.WriteLine("Valor inválido, tente novamente!");
                    continue;
                }

                switch (response)
                {
                    case 1:
                        MenuCreateTask();
                        break;
                    case 2:
                        MenuListTasks();
                        break;
                    case 4:
                        MenuDeleteTask();
                        break;
                    case 0:
                        Console.WriteLine("Até Mais!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Essa opção não existe!");
                        break;
                }
            }
        }

        public void MenuCreateTask()
        {
            Console.Clear();
            Console.WriteLine("=== Criar nova tarefa ===\n");
            Console.Write("\nNome da tarefa: \n");
            string name = Console.ReadLine();
            Console.Write("Data de vencimento: \n");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Defina um Status:\nPending = 1\nInProgress = 2\nCompleted = 3\nCanceled = 4\n");
            int status = int.Parse(Console.ReadLine());
            Console.Write("descrição: ");
            string description = Console.ReadLine();
            var id = Guid.NewGuid().ToString();

            ActivityService.CreateActivity(id, name, dueDate, TaskStatusEnum.Pending, description );

            Console.WriteLine("tarefa criada com sucesso!");
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        
        }
        public void MenuListTasks()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de tarefas ===\n");

            foreach(var task in ActivityService.ListActivity()) 
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Nome da tarefa: {task.Title}");
                Console.WriteLine($"Descrição: {task.Description}");
                Console.WriteLine($"Data de criação: {task.DateOfCriation}");
                Console.WriteLine($"Data de validade: {task.DueDate}");
                Console.WriteLine($"Categoria: {task.Category}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            }

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
        public void MenuDeleteTask()
        {
            Console.WriteLine("---Deletar tarefa--\n");
            Console.WriteLine("Digite o id da tarefa que deseja excluir: ");
            string id = Console.ReadLine();

            ActivityService.DeleteTask(id);

            Thread.Sleep(90000);
        }
    }
}
