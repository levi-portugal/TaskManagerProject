using Microsoft.Extensions.DependencyInjection;
using TaskManagerProject.Data;
using TaskManagerProject.Data.Repositories;
using TaskManagerProject.Entities;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Services;
using TaskManagerProject.UI;


class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        // 2. Configurar o MongoDB Context
        // Substitua pela sua string de conexão real do Atlas ou Local
        string connectionString = "mongodb://localhost:27017/";
        string databaseName = "TaskManager";

        services.AddSingleton(new MongoContext(connectionString, databaseName));

        // 3. Registrar o Repositório Genérico para a Entidade Product
        // Note que passamos o nome da coleção "produtos" aqui
        services.AddScoped<IRepository<Activity>>(sp =>
            new Repository<Activity>(
                sp.GetRequiredService<MongoContext>(),
                "Activities"));

        services.AddScoped<IRepository<Category>>(sp =>
            new Repository<Category>(
                sp.GetRequiredService<MongoContext>(),
                "Categories"));

        services.AddScoped<IRepository<User>>(sp =>
            new Repository<User>(
                sp.GetRequiredService<MongoContext>(),
                "Users"));

        // 4. Registrar o Service e o Menu
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<Menu>();
        services.AddScoped<ActivityMenu>();
        services.AddScoped<CategoryMenu>();
        services.AddScoped<UserMenu>();
       
        // 5. Construir o Provedor e Iniciar o App
        var serviceProvider = services.BuildServiceProvider();

        try
        {
            var menu = serviceProvider.GetRequiredService<Menu>();
            menu.ShowMenu();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao iniciar a aplicação: {ex.Message}");
            Console.ResetColor();
        }
    }
}