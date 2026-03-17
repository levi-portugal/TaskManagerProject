using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Services;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using System.Reflection.Metadata.Ecma335;

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
            while (true)
            {
                int response;

                Console.Clear();

                Console.WriteLine("==== GERENCIADOR DE TAREFAS ====\n");
                Console.WriteLine("O que deseja fazer?\n");
                Console.WriteLine("Criar tarefas - 1");
                Console.WriteLine("Listar Tarefas - 2");
                Console.WriteLine("concluir tarefa - 3");
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
            Console.Write("Defina um Status:\n" +
                "Pending = 1\r\n InProgress = 2\r\n Completed = 3\r\n Canceled = 4");
            int status = int.Parse(Console.ReadLine());
            Console.Write("descrição: ");
            string description = Console.ReadLine();

            ActivityService.CreateActivity(name, dueDate, TaskStatusEnum.Pending, description);

            Console.WriteLine("tarefa criada com sucesso!");
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
        public void MenuListTasks()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de tarefas ===\n");

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
