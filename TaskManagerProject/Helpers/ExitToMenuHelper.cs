using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerProject.Services;
using TaskManagerProject.Entities;

namespace TaskManagerProject.Helpers
{
    public class ExitToMenuHelper
    {
        public static void Exit()
        {
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        public static void RetryMensage(Exception ex)
        {
            Console.WriteLine($"\nErro: {ex.Message}");
            Console.WriteLine("Aperte qualquer tecla para tentar novamente.");
            Console.ReadKey();
        }
        public static void GetTasks(Activity task)
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
    }
}
