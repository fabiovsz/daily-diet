using daily_diet.Dto;
using daily_diet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace daily_diet.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        { 
           _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            if (user == null)
                return BadRequest(ModelState);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createUser = _userRepository.CreateUser(user);

            if (!createUser)
            {
                ModelState.AddModelError("", "Something went wrong while creating user");
                return StatusCode(500, ModelState);
            }

            return Ok("User created");
        }
    }
}
