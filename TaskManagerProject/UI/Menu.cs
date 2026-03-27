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
        public UserService UserService { get; set; }
        public CategoryMenu CategoryMenu { get; set; }
        public ActivityMenu ActivityMenu { get; set; }
        public UserMenu UserMenu { get; set; }

        public Menu()
        {
           ActivityService = new ActivityService();
           ActivityMenu = new ActivityMenu();
           CategoryMenu = new CategoryMenu();
           UserMenu = new UserMenu();
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
                Console.WriteLine("* Excluir cateoria - 7");
                Console.WriteLine("* Usuários - 8");
                Console.WriteLine("* Sair - 0");

                while (!int.TryParse(Console.ReadLine(), out response))
                {
                    Console.WriteLine("Valor inválido, tente novamente!");
                    continue;
                }

                switch (response)
                {
                    case 1:
                        ActivityMenu.MenuCreateTask();
                        break;
                    case 2:
                        ActivityService.FilterListTasks();
                        break;
                    case 3:
                        ActivityMenu.MenuEditTask();                      
                        break;
                    case 4:
                        ActivityMenu.MenuDeleteTask();
                        break;
                    case 5:
                        CategoryMenu.MenuCreateCategory();
                        break;
                    case 6:
                        CategoryMenu.MenuListCategories();
                        break;
                    case 7:
                        CategoryMenu.MenuDeleteCategory();
                        break;
                    case 8:
                        UserMenu.ShowUserMenu();
                        break;          
                    case 0:
                        Console.WriteLine("Até Mais!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Essa opção não existe!");
                        Thread.Sleep(800);
                        break;
                }
            }
        }
    }
}
