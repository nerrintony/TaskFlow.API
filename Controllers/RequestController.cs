using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.DTOs;
using TaskFlow.API.Models;
using TaskFlow.API.Services;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly RequestService _requestService;

        public RequestController(RequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_requestService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateRequestDTO dto)
        {
            var request = new Request
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedByUserId = dto.CreatedByUserId,
            };

            var created = _requestService.Create(request);

            return Ok(created);
        }

        [HttpPost("{id}/submit")]
        public IActionResult Submit(int id)
        {
            var result = _requestService.Submit(id);
            if (!result) return BadRequest();
            return Ok("Request Submitted");

        }
    }
}
