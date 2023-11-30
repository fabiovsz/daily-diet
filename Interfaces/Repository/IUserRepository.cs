using daily_diet.Dto;
using daily_diet.Models;

namespace daily_diet.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int userId);
        bool CreateUser(UserDto user);
        bool Save();

    }
}
