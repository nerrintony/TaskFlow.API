using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Models;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Nerrin", Email = "nerrin@yopmail.com" },
            new User { Id = 2, Name = "TOny", Email = "tony@yopmail.com" },
        };

        [HttpGet]
        public ActionResult GetUser()
        {
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();
            else
            {
                users.Remove(user);
                return Ok();
            }
        }
    }
}
