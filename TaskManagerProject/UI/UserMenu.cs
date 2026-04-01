using TaskManagerProject.DTOs.UserDto;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.UI
{
    public class UserMenu
    {
        private readonly IUserService _userService;

        public UserMenu(IUserService userService)
        {
            _userService = userService;
        }

        public void ShowUserMenu()
        {     
            Console.WriteLine("==== Usuários ====\n");
            foreach (var user in _userService.ListUser())
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"Nome do usuário: {user.Name}");
                Console.WriteLine($"Email do usuário: {user.Email}");
                Console.WriteLine($"Id do usuário: {user.UserId}");
                Console.WriteLine("==================================");
            }
            if (_userService.ListUser().Count == 0)
            {
                Console.WriteLine("Nenhum usuário resgistrado\n");
                Console.WriteLine("==================================");

            }

            Console.WriteLine("Deseja criar um novo usuário? (s/n)");
            char response;
            while (!char.TryParse(Console.ReadLine(), out response))
            {
                Console.WriteLine("Valor inválido, tente novamente!");
                continue;
            }

            if (response == 's' || response == 'S')
            {
                CreateUserMenu();
            }
        }

        public void CreateUserMenu()
        {
            Console.Clear();
            Console.WriteLine("==== Criar novo usuário Usuário ====\n");

            Console.Write("Digite o nome do usuário: ");
            string name = Console.ReadLine();

            Console.Write("Digite o email do usuário: ");
            string email = Console.ReadLine();

            var newDto = new UserRequestDto
            {
                Name = name,
                Email = email
            };

            _userService.CreateUser(newDto);
            Console.WriteLine("Usuário criado com sucesso");
            Thread.Sleep(1000);
            //refatorado
        }
    }
}

