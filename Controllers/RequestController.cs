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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = new Request
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedByUserId = dto.CreatedByUserId,
            };

            var created = _requestService.Create(request);

            return Ok(new
            {
                message = "Request create successfully",
                data = created,
            });
        }

        [HttpPost("{id}/submit")]
        public IActionResult Submit(int id)
        {
            var result = _requestService.Submit(id);
            if (!result) return BadRequest(new
            {
                message = "Invalid Request",
                success = false
            });
            return Ok(new
            {
                message = "Request Submitted",
                success = true
            });

        }

        [HttpPost("{id}/approve")]
        public IActionResult Approve(int id)
        {
            var result = _requestService.Approval(id);
            if (!result) return BadRequest(new
            {
                message = "Invalid Request",
                success = false
            });
            return Ok(new { message = "Request Approved", success = true });
        }

        [HttpPost("{id}/reject")]
        public IActionResult Reject(int id)
        {
            var result = _requestService.Reject(id);
            if (!result) return BadRequest(new
            {
                message = "Invalid Request",
                success = false
            });
            return Ok("Request Rejected");
        }
    }
}
