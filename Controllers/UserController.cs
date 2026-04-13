using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Models;
using TaskFlow.API.Services;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController( UserService userServive)
        {
            _userService = userServive;
        }

        //private static List<User> users = new List<User>
        //{
        //    new User { Id = 1, Name = "Nerrin", Email = "nerrin@yopmail.com" },
        //    new User { Id = 2, Name = "TOny", Email = "tony@yopmail.com" },
        //};

        [HttpGet]
        public ActionResult GetUser()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var createUser = _userService.CreateUser(user);

            return Ok(createUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var user = _userService.DeleteUserById(id);

            if (user == null)
                return NotFound();
            
            return Ok();
        }
    }
}
