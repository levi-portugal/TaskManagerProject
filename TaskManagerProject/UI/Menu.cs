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
        public CategoryService CategoryService { get; set; }

        public Menu()
        {
            CategoryService = new CategoryService();
           ActivityService = new ActivityService();
        }

        public void ShowMenu()
        {
            
            while (true)
            {
                int response;

                Console.Clear();

                Console.WriteLine("==== GERENCIADOR DE TAREFAS ====\n");
                Console.WriteLine("* Criar tarefas - 1");
                Console.WriteLine("* Listar Tarefas - 2");
                Console.WriteLine("* Editar tarefas - 3");
                Console.WriteLine("* remover tarefa - 4");
                Console.WriteLine("* Criar categoria - 5");
                Console.WriteLine("* Listar cateoria - 6");
                Console.WriteLine("* Sair - 0");


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
                    case 5:
                        MenuCreateCategory();
                        break;
                    case 6:
                        MenuListCategories();
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
            TaskStatusEnum status2;

            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("=== Criar nova tarefa ===\n");
                Console.Write("\nNome da tarefa: \n");
                string name = Console.ReadLine();
                Console.Write("Data de vencimento: \n");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Defina um Status:\nPending = 1\nInProgress = 2\nCompleted = 3\nCanceled = 4\n");
                int status = int.Parse(Console.ReadLine());

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

                ActivityService.CreateActivity(name, dueDate, status2, description);
                run = false;
            }
            

            Console.WriteLine("tarefa criada com sucesso!\n");
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        
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
                if (task.CategoryId == null)
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

                Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
                Console.ReadKey();
            } 
        public void MenuDeleteTask()
        {
            Console.WriteLine("---Deletar tarefa--\n");
            Console.WriteLine("Digite o id da tarefa que deseja excluir: ");
            string id = Console.ReadLine();

            ActivityService.DeleteTask(id);

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
        public void MenuCreateCategory()
        {
           Console.WriteLine("===== Criar categoria =====\n");

            Console.Write("Nome da categoria: ");
            string name = Console.ReadLine();

            Console.WriteLine("Defina uma cor para a categoria: ");
            Console.WriteLine("* vermelho - 1");        
            Console.WriteLine("* azul - 2");        
            Console.WriteLine("* verde - 3");
            int response = int.Parse(Console.ReadLine());
            CategoryColor categoryColor;

            switch (response)
            {
                case 1: categoryColor = CategoryColor.red;
                    break;
                case 2: categoryColor = CategoryColor.blue;
                    break;
                case 3: categoryColor = CategoryColor.green;
                    break;
                default:
                    categoryColor = CategoryColor.black;
                    Console.WriteLine("Essa cor não existe");
                    break;
            }

            CategoryService.CreateCategory(name, categoryColor);

        }

        public void MenuListCategories()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Categorias ===\n");
            foreach (var category in CategoryService.ListCategory())
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");          
                Console.WriteLine($"Nome da tarefa: {category.Name}");
                Console.WriteLine($"Cor: {category.Color}");
                Console.WriteLine($"Id da categoria: {category.CategoryId}");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
