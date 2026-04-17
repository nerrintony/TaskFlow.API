using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.DTOs;
using TaskFlow.API.Models;
using TaskFlow.API.Services;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userServive)
        {
            _userService = userServive;
        }

        [HttpGet]
        public ActionResult GetUser()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            var createUser = _userService.CreateUser(user);

            return Ok(new
            {
                message = "Successful",
                success = true,
                data = createUser
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound(new
                {
                    message = "User not found",
                    success = false
                });
            else
                return Ok(new
                {
                    message = "Successfull",
                    success = true,
                    data = user
                });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var user = _userService.DeleteUserById(id);

            if (user == null)
                return NotFound(new
                {
                    message = "User not found",
                    success = false
                });

            return Ok(new
            {
                message = "User deleted successfully",
                success = true
            });
        }
    }
}
