using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
