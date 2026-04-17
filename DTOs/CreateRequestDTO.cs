using System.ComponentModel.DataAnnotations;

namespace TaskFlow.API.DTOs
{
    public class CreateRequestDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Range(1, int.MaxValue)]
        public int CreatedByUserId { get; set; } = 0;
    }
}
