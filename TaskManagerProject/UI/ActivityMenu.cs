using TaskManagerProject.DTOs.ActivityDTO;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Helpers;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Services;

namespace TaskManagerProject.UI
{
    public class ActivityMenu
    {
        private readonly IActivityService _activityService;

        public ActivityMenu(IActivityService activityService)
        {
            _activityService = activityService;
        }
        public void MenuCreateTask()
        {
            TaskStatusEnum status2;

            bool run = true;
            while (run)
            {
                string title;
                DateTime dueDate;
                int status;
                string categoryId;
                string userId;
                Console.Clear();
                Console.WriteLine("=== Criar nova tarefa ===\n");

                try
                {
                    Console.Write("\nNome da tarefa: \n");
                    title = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    ExitToMenuHelper.RetryMensage(ex);
                    continue;
                }

                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("erro: Não é perimitido criar uma tarefa sem nome atribuido!");
                    break;
                }

                Console.WriteLine("insira o id de uma categoria:");
                Console.WriteLine("Obs: Caso não queira atribuir ou não tenha uma categoria criada, aperte 'enter'!");
                categoryId = Console.ReadLine();

                try
                    {
                        Console.Write("Data de vencimento: \n");
                        dueDate = DateTime.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {

                        ExitToMenuHelper.RetryMensage(ex);
                        continue;
                    }

                if (dueDate < DateTime.Now)
                {
                    Console.WriteLine("erro: Não é perimitido criar uma tarefa Com data de vencimento no passado!");
                    break;

                }
                try
                {
                    Console.WriteLine("Defina um Status:\nPending = 1\nInProgress = 2\nCompleted = 3\nCanceled = 4\n");
                    status = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    ExitToMenuHelper.RetryMensage(ex);
                    continue;
                }
               
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

                Console.WriteLine("insira o id de um usuário:");
                Console.WriteLine("Obs: Caso não queira atribuir ou não tenha um usuário criado, aperte 'enter'!");
                userId = Console.ReadLine();


                var newDto = new ActivityRequestDto
                {
                    Title = title,
                    DueDate = dueDate,
                    Status = status2,
                    Description = description,
                    CategoryId = categoryId,
                    UserId = userId
                };

                _activityService.CreateActivity(newDto);
                Console.WriteLine("tarefa criada com sucesso!\n");
                run = false;
            }

            ExitToMenuHelper.Exit();
            //REAFATORADO

        }
       
        public void MenuDeleteTask()
        {
            Console.WriteLine("---Deletar tarefa--\n");
            Console.WriteLine("Digite o id da tarefa que deseja excluir: ");
            string id = Console.ReadLine();

            _activityService.DeleteTask(id);
            Console.WriteLine("Removido");
            ExitToMenuHelper.Exit();
            //Refatorado
        }

        public void MenuEditTask()
        {
            Console.WriteLine("====Editar Tarefa====\n");
            Console.Write("Digite o Id da tarefa que deseja alterar: ");
            string id = Console.ReadLine();

            Console.Write("Digite o novo nome: ");
            string title = Console.ReadLine();

            Console.Write("Digite a nova data de validade: ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Defina um novo Status:\nPending = 1\nInProgress = 2\nCompleted = 3\nCanceled = 4\n");
            int status = int.Parse(Console.ReadLine());
            TaskStatusEnum status2;
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

            Console.WriteLine("insira o id de uma categoria:");
            Console.WriteLine("Obs: Caso não queira atribuir ou não tenha uma categoria criada, aperte 'enter'!");
            string categoryId = Console.ReadLine();

            Console.WriteLine("insira o id de um usuário:");
            Console.WriteLine("Obs: Caso não queira atribuir ou não tenha um usuário criado, aperte 'enter'!");
            string userId = Console.ReadLine();

            var newDto = new ActivityRequestDto
            {
                Title = title,
                DueDate = dueDate,
                Status = status2,
                CategoryId = categoryId,
                UserId = userId
            };

            _activityService.EditTask(id,newDto);

            Console.WriteLine("Alterado com sucesso!");
            Thread.Sleep(1000);
            //REFATORADO    
        }
    }
}
