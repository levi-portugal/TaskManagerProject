using TaskManagerProject.DTOs.ActivityDTO;

namespace TaskManagerProject.Interfaces
{
    public interface IActivityService
    {
        public void CreateActivity(ActivityRequestDto dto);
        public void EditTask(string id, ActivityRequestDto dto);
        public void DeleteTask(string id);
        public List<ActivityResponseDto> GetAll();
        void FilterListTasks(); //Ver o pq não é pra isso ficar aqui
    }
}