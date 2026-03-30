using System.Reflection.Metadata.Ecma335;
using TaskManagerProject.Data.Repositories;
using TaskManagerProject.DTOs.ActivityDTO;
using TaskManagerProject.Entities;
using TaskManagerProject.Entities.Enums;
using TaskManagerProject.Helpers;
using TaskManagerProject.Interfaces;

namespace TaskManagerProject.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository<Activity> _respository;

        public ActivityService(IRepository<Activity> repository)
        {
            _respository = repository;
        }

        public void CreateActivity(ActivityRequestDto dto)
        {
            var activity = new Activity(dto.Title, dto.DueDate, dto.Description, dto.Status??TaskStatusEnum.Pending, dto.CategoryId, dto.UserId)
            { };

            _respository.Create(activity);
            //REFATORADO
        }

        public List<ActivityResponseDto> GetAll()
        {
            var Activities = _respository.GetAll();

            return Activities.Select(a => new ActivityResponseDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                DateOfCriation = a.DateOfCriation,
                DueDate = a.DueDate,
                Status = a.Status,
                CategoryId = a.CategoryId,
                UserId = a.UserId
            }).ToList();
            //Refatorado
        }

        public void DeleteTask(string id)
        {
            _respository.Delete(id.ToString());
            //refatorado
        }

        public void EditTask(string id, ActivityRequestDto dto)
        {
            /*
            var activity = new Activity(dto.Title, dto.DueDate, dto.Description, dto.Status, dto.CategoryId, dto.UserId)
            {};
            */

            var activity = _respository.GetById(id);
            if (activity != null)
            {
                if (!string.IsNullOrWhiteSpace(dto.Title))
                    activity.Title = dto.Title;

                if (!string.IsNullOrWhiteSpace(dto.Description))
                    activity.Description = dto.Description;

                if (activity.DueDate != DateTime.MinValue)
                    activity.DueDate = dto.DueDate;

                if (!string.IsNullOrWhiteSpace(dto.CategoryId))
                    activity.CategoryId = dto.CategoryId;

                if (!string.IsNullOrWhiteSpace(dto.UserId))
                    activity.CategoryId = dto.CategoryId;

                if (dto.Status != null)
                    activity.Status = dto.Status ?? TaskStatusEnum.Pending;
     
                _respository.Update(id.ToString(), activity);
            }
            // se tiver uma task, continuar processo de edit
            // validar se cada prop do dto tem valor, se a prop tiver valor, alterar o activity


            //REFATORADO    
        }
        
        public void FilterListTasks()
        {
            Console.WriteLine("===Listar tarefas===\n");
            Console.WriteLine("* Listar por categoria - 1\n");
            Console.WriteLine("* Listar por status - 2\n");
            Console.WriteLine("* Listar por data de vencimento - 3\n");
            Console.WriteLine("* Listar todas as tarefas - 4\n");
            Console.WriteLine("* Tarefas atrasadas - 5\n");

            Console.Write("Qual deseja ver? ");
            int response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                    FilterByCategory();
                    break;
                case 2:
                    FilterByStatus();
                    break;
                case 3:
                    FilterByDueDate();
                    break;
                case 4:
                    GetAll();
                    break;
                case 5:
                    DelayedActivities();
                    break;
                default:
                    Console.WriteLine("Essa opção não existe!");
                    break;
            }      
            //REFATORADO
        }

        private void FilterByCategory()
        {
            var result = GetAll().OrderBy(x => x.CategoryId).ToList();
            ShowActivities(result);
            //REFATORADO
        }

        private void ShowActivities(List<ActivityResponseDto> result)
        {
            if (result.Count == 0)
                Console.WriteLine("não encontrado");
            foreach (var task in result)
            {
                ExitToMenuHelper.GetTasks(task);
            }
            ExitToMenuHelper.Exit();
            //REFATORADO
        }

        private void FilterByStatus()
        {
            var result = GetAll().OrderBy(x => x.Status).ToList();

            ShowActivities(result);
            //REFATORADO
        }

        private void FilterByDueDate()
        {
            var result = GetAll()
            .OrderBy(x => Math.Abs((x.DueDate - DateTime.Now).TotalDays))
            .ToList();

            ShowActivities(result);
            //REFATORADO
        }

        private void DelayedActivities()
        {
            Console.WriteLine("=== Tarefas atrsadas ===");

            var result = GetAll()
            .Where(x => (x.DueDate < DateTime.Now && x.Status != TaskStatusEnum.Completed))
            .ToList();

            ShowActivities(result);
            //REFATORADO
        }
    }   
}  