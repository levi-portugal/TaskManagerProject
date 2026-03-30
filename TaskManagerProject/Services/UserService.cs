using TaskManagerProject.DTOs.UserDto;
using TaskManagerProject.Entities;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Data.Repositories;
namespace TaskManagerProject.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository <User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void CreateUser(UserRequestDto dto)
        {
            var user = new User(dto.Name,dto.Email)         
            {};

            _repository.Create(user);
            //Refatorado
        }

        public List<UserResponseDto> ListUser()
        {
            var users = _repository.GetAll();

            return users.Select(u => new UserResponseDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }
    }
}