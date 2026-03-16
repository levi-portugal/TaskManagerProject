using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerProject.UI
{
    internal class Menu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("--Bem vindo ao seu Gerênciador de Tarefas--\n");
                Console.WriteLine("O que deseja ver?\n");
                Console.WriteLine("Tarefas - 1");
                Console.WriteLine("Categorias - 2");
                int response;
                try
                {
                    response = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }

                switch (response)
                {
                    case 1: 
                    default:
                        Console.WriteLine("Essa opção não existe!");
                        break;
                }

                continue;
            }
        }

    }
}
