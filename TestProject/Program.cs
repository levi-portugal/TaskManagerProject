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