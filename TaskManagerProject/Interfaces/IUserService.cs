using TaskManagerProject.DTOs.UserDto;

namespace TaskManagerProject.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(UserRequestDto dto);
        public List<UserResponseDto> ListUser();
    }
}
