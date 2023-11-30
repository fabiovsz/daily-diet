using daily_diet.Data;
using daily_diet.Repository;
using Microsoft.EntityFrameworkCore;

namespace daily_diet.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository) {  
            _userRepository = userRepository; 
        }
        
    }
}
