using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Models;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> user = new List<User>
        {
            new User { Id = 1, Name = "Nerrin", Email = "nerrin@yopmail.com" },
            new User { Id = 2, Name = "TOny", Email = "tony@yopmail.com" },
        };

        [HttpGet]
        public ActionResult GetUser()
        {
            return Ok(user);
        }
    }
}
