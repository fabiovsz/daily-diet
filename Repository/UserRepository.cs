using daily_diet.Data;
using daily_diet.Dto;
using daily_diet.Interfaces;
using daily_diet.Models;

namespace daily_diet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(UserDto user)
        {

            var userRecord = new User(){ Name = user.name };
           _context.Add(userRecord);

            return Save();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
